using PluginBase;
using System.Reflection;
using AppWithPlugin;

// See https://aka.ms/new-console-template for more information

string PluginsFolder(){
    string pexe = Path.GetDirectoryName(typeof(Program).Assembly.Location);
    string pplugins = Directory.GetParent(pexe).Parent.Parent.FullName + "/plugins";
    return pplugins;
}

string rootplugins = PluginsFolder(); 
Console.WriteLine(rootplugins);

try
{
    var loadLocations = new string[] {
        rootplugins + "/Plugins01.dll",
        rootplugins + "/Plugins02.dll",
        rootplugins + "/Plugins03.dll"
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
