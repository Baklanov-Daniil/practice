using System;
using System.Reflection;
using System.Collections.Generic;

public class ClassAnalyzer
{
    private Type _type;

    public ClassAnalyzer(Type type)
    {
        _type = type;
    }

    public IEnumerable<string> GetPublicMethods()
        => _type.GetMethods()
            .Where(m => m.IsPublic)
            .Select(m => m.Name);
    public IEnumerable<string> GetMethodParams(string methodName)
        =>_type.GetMethod(methodName)?
           .GetParameters()
           .Select(p => p.Name)
           .Where(name => name != null)!
           ?? Enumerable.Empty<string>();


    public IEnumerable<string> GetAllFields()
        => _type.GetFields(BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic)
            .Select(p => p.Name);

    public IEnumerable<string> GetProperties()
        => _type.GetProperties()
            .Select(p => p.Name);
    public bool HasAttribute<T>() where T : Attribute
        => _type.GetCustomAttribute<T>() != null;
}
