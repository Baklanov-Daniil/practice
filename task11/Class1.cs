using System;
using System.IO;
using System.Linq;
using System.Reflection;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp;

public interface ICalculator
{
    int Add(int a, int b);
    int Subtract(int a, int b);
    int Multiply(int a, int b);
    int Divide(int a, int b);
}

public class CalculatorGenerator
{
    public static ICalculator CreateCalculator()
    {
        string code = @"
            public class DynamicCalculator : ICalculator
            {
                public int Add(int a, int b) => a + b;
                public int Subtract(int a, int b) => a - b;
                public int Multiply(int a, int b) => a * b;
                public int Divide(int a, int b) => a / b;
            }";

        var references = new MetadataReference[]
        {
            MetadataReference.CreateFromFile(typeof(object).Assembly.Location),
            MetadataReference.CreateFromFile(typeof(ICalculator).Assembly.Location),
        };

        var compilation = CSharpCompilation.Create(
            assemblyName: "CalculatorAssembly",
            syntaxTrees: new[] { CSharpSyntaxTree.ParseText(code) },
            references: references,
            options: new CSharpCompilationOptions(OutputKind.DynamicallyLinkedLibrary));

        using var memoryStream = new MemoryStream();
        var result = compilation.Emit(memoryStream);

        memoryStream.Seek(0, SeekOrigin.Begin);
        var assembly = Assembly.Load(memoryStream.ToArray());
        var calculatorType = assembly.GetType("DynamicCalculator");

        if (calculatorType == null)
            throw new Exception("Класс не создан");

        return (ICalculator)Activator.CreateInstance(calculatorType)!;
    }
}
