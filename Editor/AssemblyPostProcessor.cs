using Mono.Cecil;
using UnityEditor;
using UnityEditor.Compilation;

namespace NewBlood
{
    [InitializeOnLoad]
    static class AssemblyPostProcessor
    {
        static AssemblyPostProcessor()
        {
            CompilationPipeline.compilationFinished += OnCompilationFinished;
        }

        static void OnCompilationFinished(object context)
        {
            bool modified = false;
            EditorApplication.LockReloadAssemblies();

            try
            {
                var parameters     = new ReaderParameters { ReadWrite = true };
                using var assembly = AssemblyDefinition.ReadAssembly(typeof(AssemblyPostProcessor).Assembly.Location, parameters);

                foreach (ModuleDefinition module in assembly.Modules)
                {
                    foreach (TypeDefinition type in module.Types)
                    {
                        foreach (FieldDefinition field in type.Fields)
                        {
                            foreach (CustomAttribute attribute in field.CustomAttributes)
                            {
                                if (attribute.AttributeType.Name != nameof(MetadataNameAttribute))
                                    continue;

                                modified   = true;
                                field.Name = attribute.ConstructorArguments[0].Value.ToString();
                                field.CustomAttributes.Remove(attribute);
                                break;
                            }
                        }
                    }
                }

                if (modified)
                {
                    assembly.Write();
                    EditorApplication.delayCall += EditorUtility.RequestScriptReload;
                }
            }
            finally
            {
                EditorApplication.UnlockReloadAssemblies();
            }
        }
    }
}
