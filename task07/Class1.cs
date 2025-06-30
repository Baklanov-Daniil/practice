using System;
using System.Reflection;

[AttributeUsage(AttributeTargets.Class | AttributeTargets.Method | AttributeTargets.Property)]
public class DisplayNameAttribute : Attribute
{
    public string DisplayName { get; }

    public DisplayNameAttribute(string displayName)
    {
        DisplayName = displayName;
    }
}

[AttributeUsage(AttributeTargets.Class)]
public class VersionAttribute : Attribute
{
    public int Major { get; }
    public int Minor { get; }

    public VersionAttribute(int major, int minor)
    {
        Major = major;
        Minor = minor;
    }
}

[DisplayName("Пример класса")]
[Version(1, 0)]
public class SampleClass
{
    [DisplayName("Числовое свойство")]
    public int Number { get; set; }

    [DisplayName("Тестовый метод")]
    public void TestMethod() { }
}
    

public static class ReflectionHelper
{
    public static void PrintTypeInfo(Type type)
    {
        if (type == null)
        {
            return; 
        }
        
        var displayNameAttr = type.GetCustomAttribute<DisplayNameAttribute>();
        if (displayNameAttr != null)
        {
            Console.WriteLine($"Отображаемое имя класса: {displayNameAttr.DisplayName}");
        }

        var displayVersionAttr = type.GetCustomAttribute<VersionAttribute>();
        if (displayVersionAttr != null)
        {
            Console.WriteLine($"Версия класса: {displayVersionAttr.Major}.{displayVersionAttr.Minor}");
        }

        foreach (var prop in type.GetProperties())
        {
            var propDisplayNameAttr = prop.GetCustomAttribute<DisplayNameAttribute>();
            if (prop != null)
            {
                Console.WriteLine("Имя свойства: {propDisplayNameAttr}");
            }
        }

        foreach (var meth in type.GetMethods())
        {
            var methDisplayNameAttr = meth.GetCustomAttribute<DisplayNameAttribute>();
            if (meth != null)
            {
                Console.WriteLine("Имя метода: {methDisplayNameAttr}");
            }
        }
    }
}
