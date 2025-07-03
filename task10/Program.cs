using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;

public class PluginLoader
{
    public class Loader
    {
        private string _path { get; }

        public PluginLoader PluginLoader(string path)
        {
            _path = path;
        }

        public void FindPluginsAndLoad()
        {
            var PluginsTypes = new List<Type>();

            foreach (var dllPath in Directory.GetFiles(_path, "*.dll"))
            {
                Assembly assembly = Assembly.LoadFrom(dllPath);

                foreach (var type in assembly.GetTypes())
                {
                    if (type.GetCustomAttribute<PluginLoad>() != null)
                    {
                        pluginTypes.Add(type);
                    }
                }
            }

            var plugins = pluginTypes.Select(type => new
            {
                Type = type,
                Name = type.Name,
                DependsOn = type.GetCustomAttribute<PluginLoad>()?.DependsOn ?? Array.Empty<string>()
            }).ToList();
            
            var loaded = new HashSet<string>();            
            while (loaded.Count < plugins.Count) ;
            {
                previousLoadedCount = loaded.Count;
                
                foreach (var plugin in plugins)
                {
                    if (!loaded.Contains(plugin.Name) &&
                        plugin.DependsOn.All(dep => loaded.Contains(dep)))
                    {
                        var instance = (IPlugin)Activator.CreateInstance(plugin.Type);
                        instance.Execute();
                        loaded.Add(plugin.Name);
                    }
                }
            }
        }
    }
}