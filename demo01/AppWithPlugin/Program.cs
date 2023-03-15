using PluginBase;
using System.Reflection;
using AppWithPlugin;

// See https://aka.ms/new-console-template for more information
Console.WriteLine("Hello, World!");
try
{
    var loadLocations = new string[] {
        "/home/robertolabarca/Documentos/projects/GitHub/patternplugins/demo01/Plugins01/bin/Debug/net7.0/Plugins01.dll",
        "/home/robertolabarca/Documentos/projects/GitHub/patternplugins/demo01/Plugins02/bin/Debug/net7.0/Plugins02.dll",
        "/home/robertolabarca/Documentos/projects/GitHub/patternplugins/demo01/Plugins03/bin/Debug/net7.0/Plugins03.dll"
    };
    IEnumerable <ICommand> tasks = loadLocations.SelectMany(pluginPath => {
        Assembly pluginAssembly = LoadPlugin(pluginPath);
        return CreateCommands(pluginAssembly);
    }).ToList();
    foreach(ICommand task in tasks) {
        Console.WriteLine($"{task.Id}\t - {task.Description}");
        Console.WriteLine($" The running task returns - {task.Run()}");
    }
    
}
catch (System.Exception ex)
{
    Console.WriteLine(ex);
}


 static Assembly LoadPlugin(string relativePath) {
    var pluginLocation = relativePath;
    var loadContext = new PluginLoadContext(pluginLocation);
    return loadContext.LoadFromAssemblyName(new AssemblyName(Path.GetFileNameWithoutExtension(pluginLocation)));
}

 static IEnumerable <ICommand> CreateCommands(Assembly assembly) {
    int count = 0;
    foreach(Type type in assembly.GetTypes()) {
        if (typeof(ICommand).IsAssignableFrom(type)) {
            ICommand ? result = Activator.CreateInstance(type) as ICommand;
            if (result != null) {
                count++;
                yield
                return result;
            }
        }
    }
}   
