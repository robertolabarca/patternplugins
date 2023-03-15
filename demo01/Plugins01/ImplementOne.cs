using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using PluginBase;

namespace Plugins01
{
    public class ImplementOne:ICommand
    {
        public string Id { get;} = "One";
        public string Description { get;} = "Este es el primer Plugins";
        public int Run()
        {
            return 1;
        }
    }
}