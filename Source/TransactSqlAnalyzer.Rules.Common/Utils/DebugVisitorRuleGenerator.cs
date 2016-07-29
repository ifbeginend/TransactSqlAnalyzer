using Microsoft.SqlServer.TransactSql.ScriptDom;
using System;
using System.CodeDom;
using System.CodeDom.Compiler;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;

namespace TransactSqlAnalyzer.Rules.Common.Utils
{
    /// <summary>
    /// Generates a debug visitor that helps understanding the TSql parse tree structure.
    /// </summary>
    public class DebugVisitorRuleGenerator
    {
        /// <summary>
        /// Creates a class source code for a visitor that visits and logs every Visit/ExplicitVisit method
        /// </summary>
        /// <returns></returns>
        public string CreateDebugVisitor()
        {
            // https://msdn.microsoft.com/en-us/library/ms404245(v=vs.110).aspx
            var targetCodeCompileUnit = new CodeCompileUnit();
            var targetNamespace = new CodeNamespace("TransactSqlAnalyzer.Rules.Common.Utils");
            //samples.Imports.Add(new CodeNamespaceImport("System"));
            var targetClass = new CodeTypeDeclaration("DebugVisitorRule");
            targetClass.IsClass = true;
            targetClass.TypeAttributes = TypeAttributes.Public;
            targetClass.BaseTypes.Add(typeof(VisitorRuleBase));
            targetNamespace.Types.Add(targetClass);
            targetCodeCompileUnit.Namespaces.Add(targetNamespace);

            var ruleTypeDescriptionProperty = CreateRuleTypeDescriptionProperty();
            targetClass.Members.Add(ruleTypeDescriptionProperty);

            var visitorType = typeof(TSqlFragmentVisitor);
            var allMethods = visitorType.GetMethods();
            var visitMethods = allMethods.ToList().Where(aX => aX.Name == "Visit" || aX.Name == "ExplicitVisit");
            foreach (var method in visitMethods)
            {
                var parameters = method.GetParameters();
                if (parameters.Count() == 1 && typeof(TSqlFragment).IsAssignableFrom(parameters[0].ParameterType))
                {
                    var parameterType = parameters[0].ParameterType;
                    var visitMethod = CreateVisitMethod(method.Name, parameterType);
                    targetClass.Members.Add(visitMethod);
                }
            }

            var code = GenerateCSharpCode(targetCodeCompileUnit);
            return code;
        }

        private CodeTypeMember CreateRuleTypeDescriptionProperty()
        {
            var ruleTypeDescriptionProperty = new CodeSnippetTypeMember("        public override string RuleTypeDescription => \"Implements all visit methods (for debugging).\";");
            return ruleTypeDescriptionProperty;
        }

        private CodeTypeMember CreateVisitMethod(string methodName, Type parameterType)
        {
            // Declaring a ToString method
            var visitMethod = new CodeMemberMethod();
            visitMethod.Attributes = MemberAttributes.Public | MemberAttributes.Override;
            visitMethod.Name = methodName;
            visitMethod.Parameters.Add(new CodeParameterDeclarationExpression(parameterType, "node"));

            var baseVisitCall = new CodeSnippetStatement($"            base.{methodName}(node);");
            visitMethod.Statements.Add(baseVisitCall);
            var addFindingCall = new CodeSnippetStatement($"            AddFinding(node, \"{methodName}: {parameterType.Name}\");");
            visitMethod.Statements.Add(addFindingCall);

            return visitMethod;
        }

        public string GenerateCSharpCode(CodeCompileUnit codeUnit)
        {
            CodeDomProvider provider = CodeDomProvider.CreateProvider("CSharp");
            CodeGeneratorOptions options = new CodeGeneratorOptions();
            options.BracingStyle = "C";
            var stringBuilder = new StringBuilder();

            using (var textWriter = new StringWriter(stringBuilder))
            {
                provider.GenerateCodeFromCompileUnit(codeUnit, textWriter, options);
            }
            return stringBuilder.ToString();
        }
    }
}
