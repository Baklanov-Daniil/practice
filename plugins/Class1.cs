public interface IPlugin
{
    void Execute();
}

[AttributeUsage(AttributeTargets.Class)]
public class PluginLoad : Attribute
{
    public string[] DependsOn { get; }

    public PluginLoad()
    {
        DependsOn = Array.Empty<string>();
    }
    
    public PluginLoad(string[] depends_on)
    {
        DependsOn = depends_on;
    }
}