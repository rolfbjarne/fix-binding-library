using System;
using Mono.Cecil;
namespace fixbindinglibrary {
	class MainClass {
		public static void Main (string [] args)
		{
			foreach (var arg in args) {
				Console.WriteLine ("Processing {0}", arg);
				var ad = AssemblyDefinition.ReadAssembly (arg, new ReaderParameters () { InMemory = true });
				foreach (var type in ad.MainModule.Types) {
					if (!type.HasCustomAttributes)
						continue;
					var hasProtocolAttribute = false;
					var hasModelAttribute = false;
					CustomAttribute registerAttribute = null;
					foreach (var ca in type.CustomAttributes) {
						if (ca.AttributeType.Namespace != "Foundation")
							continue;

						switch (ca.AttributeType.Name) {
						case "ProtocolAttribute":
							hasProtocolAttribute = true;
							break;
						case "ModelAttribute":
							hasModelAttribute = true;
							break;
						case "RegisterAttribute":
							registerAttribute = ca;
							break;
						}
					}
					if (!hasProtocolAttribute || !hasModelAttribute)
						continue;
					if (registerAttribute == null)
						continue;
					if ((bool) registerAttribute.ConstructorArguments [1].Value == false) {
						Console.WriteLine ("No need to fix {0}", type.FullName);
						continue;
					}
					Console.WriteLine ("Fixing {0}", type.FullName);
					registerAttribute.ConstructorArguments [1] = new CustomAttributeArgument (registerAttribute.ConstructorArguments [1].Type, false);
				}
				ad.Write (arg);
				Console.WriteLine ("Processed {0} successfully", arg);
			}
		}
	}
}
