using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PluginBase
{
    public interface ICommand
    {
        public string Id { get;}
        public string Description { get;}
        int Run();
    }
}