using HTMLRenderer;
using System.Reflection;
using Microsoft.CSharp;
using System.CodeDom.Compiler;
using System.Text;
using System.Linq;
using System.Collections.Generic;
using System;
namespace HTMLRenderer
{
	public class HTMLElements : IElement
	{
		public string Name
		{
			get { throw new NotImplementedException(); }
		}

		public string TextContent
		{
			get
			{
				throw new NotImplementedException();
			}
			set
			{
				throw new NotImplementedException();
			}
		}

		public IEnumerable<IElement> ChildElements
		{
			get { throw new NotImplementedException(); }
		}

		public void AddElement(IElement element)
		{
			throw new NotImplementedException();
		}

		public void Render(StringBuilder output)
		{
			throw new NotImplementedException();
		}
	}
}

namespace HTMLRenderer
{
	public interface IElement
	{
		string Name { get; }
		string TextContent { get; set; }
		IEnumerable<IElement> ChildElements { get; }
		void AddElement(IElement element);
		void Render(StringBuilder output);
		string ToString();
	}

	public interface ITable : IElement
	{
		int Rows { get; }
		int Cols { get; }
		IElement this[int row, int col] { get; set; }
	}

    public interface IElementFactory
    {
		IElement CreateElement(string name);
		IElement CreateElement(string name, string content);
		ITable CreateTable(int rows, int cols);
    }

    public class HTMLElementFactory : IElementFactory
    {
		public IElement CreateElement(string name)
		{
			throw new NotImplementedException();
		}

		public IElement CreateElement(string name, string content)
		{
			throw new NotImplementedException();
		}

		public ITable CreateTable(int rows, int cols)
		{
			throw new NotImplementedException();
		}
	}

    public class HTMLRendererCommandExecutor
    {
        static void Main()
        {
			string csharpCode = ReadInputCSharpCode();
			CompileAndRun(csharpCode);
        }

        private static string ReadInputCSharpCode()
        {
            StringBuilder result = new StringBuilder();
            string line;
            while ((line = Console.ReadLine()) != "")
            {
                result.AppendLine(line);
            }
            return result.ToString();
        }

        static void CompileAndRun(string csharpCode)
        {
            // Prepare a C# program for compilation
            string[] csharpClass =
            {
                @"
                  

                  public class RuntimeCompiledClass
                  {
                     public static void Main()
                     {"
                        + csharpCode + @"
                     }
                  }"
            };

            // Compile the C# program
            CompilerParameters compilerParams = new CompilerParameters();
            compilerParams.GenerateInMemory = true;
            compilerParams.TempFiles = new TempFileCollection(".");
            compilerParams.ReferencedAssemblies.Add("System.dll");
            compilerParams.ReferencedAssemblies.Add(Assembly.GetExecutingAssembly().Location);
            CSharpCodeProvider csharpProvider = new CSharpCodeProvider();
            CompilerResults compile = csharpProvider.CompileAssemblyFromSource(
                compilerParams, csharpClass);

            // Check for compilation errors
            if (compile.Errors.HasErrors)
            {
                string errorMsg = "Compilation error: ";
                foreach (CompilerError ce in compile.Errors)
                {
                    errorMsg += "\r\n" + ce.ToString();
                }
                throw new Exception(errorMsg);
            }

            // Invoke the Main() method of the compiled class
            Assembly assembly = compile.CompiledAssembly;
            Module module = assembly.GetModules()[0];
            Type type = module.GetType("RuntimeCompiledClass");
            MethodInfo methInfo = type.GetMethod("Main");
            methInfo.Invoke(null, null);
        }
    }
}

namespace HTMLRenderer
{
	public class HTMLTables : HTMLElements, ITable
	{
		
		public int Rows
		{
			get { return this.Rows; }
		}

		public int Cols
		{
			get { return this.Cols; }
		}

		public IElement this[int row, int col]
		{
			get
			{
				throw new NotImplementedException();
			}
			set
			{
				throw new NotImplementedException();
			}
		}
	}
}

