using log4net;
using log4net.Appender;
using log4net.Core;
using System;
using System.Diagnostics;

namespace TransactSqlAnalyzer.Core
{
    public static class LogExtensions
    {
        //log4net.ILog log = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        /// <summary>
        /// Surrounds the code with log messages (Info level) at start, at end, on exceptions and also (on request) time measurement.
        /// Catches all exceptions!
        /// </summary>
        /// <param name="log">Logger instance</param>
        /// <param name="code">Code to execute</param>
        /// <param name="codeName">Name of the code: This string is included in the messages</param>
        /// <param name="measureTime">set to true to measure time and - finally - log the elapsed time</param>
        public static void AssistedExecute(this ILog log, Action code, string codeName = "", bool measureTime = false)
        {
            Stopwatch watch = null;
            try
            {
                if (log.IsInfoEnabled)
                {
                    log.Info("Starting " + codeName);
                }

                if (measureTime)
                {
                    watch = Stopwatch.StartNew();
                }

                code();

                if (measureTime)
                {
                    watch.Stop();
                }
                if (log.IsInfoEnabled)
                {
                    log.Info("Done " + codeName);
                    if (measureTime)
                    {
                        log.Info("Elapsed Time: " + watch.Elapsed);
                    }
                }
            }
            catch (Exception ex)
            {
                if (measureTime)
                {
                    watch?.Stop();
                }
                log.Info("Incomplete " + codeName);
                if (measureTime && watch != null)
                {
                    log.Info("Elapsed Time: " + watch.Elapsed);
                }
                log.Error("Error in " + codeName, ex);
            }
        }

        /// <summary>
        /// Registers an EventingAppender in log4net, i.e. the handler is called for each log message above/equal treshold
        /// </summary>
        /// <param name="log"></param>
        /// <param name="handler"></param>
        /// <param name="threshold"></param>
        public static void RegisterEventingAppender(this ILog log, Action<LoggingEvent> handler, Level threshold = null)
        {
            var myAppender = new EventingAppender(handler)
            {
                Name = "EventingAppender",
                Threshold = threshold ?? Level.All
            };
            myAppender.ActivateOptions();
            log4net.Config.BasicConfigurator.Configure(myAppender);
        }


        /// <summary>
        /// A log4net appender that calls an action upon each log message
        /// </summary>
        private class EventingAppender : AppenderSkeleton
        {
            private readonly Action<LoggingEvent> handler;

            public EventingAppender(Action<LoggingEvent> handler)
            {
                this.handler = handler;
            }

            protected override void Append(LoggingEvent loggingEvent)
            {
                handler?.Invoke(loggingEvent);
            }
        }
    }
}
