using System;
using System.Reflection;

class Program
{
    static void Main(string[] args)
    {
        Assembly assembly = Assembly.LoadFrom(args[0]);

        Console.WriteLine($"Анализ сборки: {assembly.FullName}");

        Console.WriteLine("------------------------------------------------------------------------");

        Type[] allTypes = assembly.GetTypes();

        foreach (Type type in allTypes)
        {
            Console.WriteLine($"Класс: {type.FullName}");

            var attributes = type.GetCustomAttributes();
            foreach (var attribute in attributes)
            {
                Console.WriteLine($"Атрибут: {attribute.GetType()}");
            }

            Console.WriteLine();

            var constructors = type.GetConstructors();
            foreach (var constructor in constructors)
            {
                Console.WriteLine($"Конструктор: {constructor}");
                foreach (var param in constructor.GetParameters())
                {
                    Console.WriteLine($"Имя: {param.Name} | тип параметра: {param.ParameterType.Name}");
                }
            }

            Console.WriteLine();

            var methods = type.GetMethods();
            foreach (var method in methods)
            {
                Console.WriteLine($"Метод: {method}");
                foreach (var param in method.GetParameters())
                {
                    Console.WriteLine($"Имя: {param.Name} | тип параметра: {param.ParameterType.Name}");
                }
            }

            Console.WriteLine("------------------------------------------------------------------------");
        }
        
    }
}
