using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Reflection;
using System.Runtime.Loader;

namespace AppWithPlugin
{
    public class PluginLoadContext:AssemblyLoadContext
    {
        private AssemblyDependencyResolver _resolver;
        public PluginLoadContext(string pluginpath)
        {
            _resolver = new AssemblyDependencyResolver(pluginpath);
        }

        protected override Assembly Load(AssemblyName assemblyName) {
            string assemblyPath = _resolver.ResolveAssemblyToPath(assemblyName);
            if (assemblyPath != null) {
                return LoadFromAssemblyPath(assemblyPath);
            }
            return null;
        }

        protected override IntPtr LoadUnmanagedDll(string unmanagedDllName) {
            string libraryPath = _resolver.ResolveUnmanagedDllToPath(unmanagedDllName);
            if (libraryPath != null) {
                return LoadUnmanagedDllFromPath(libraryPath);
            }
            return IntPtr.Zero;
        }
        

    }
}