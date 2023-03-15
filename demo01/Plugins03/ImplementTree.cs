using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using PluginBase;

namespace Plugins03;
public class ImplementTree:ICommand
{
    public string Id { get;} = "tree0";
    public string Description { get;} = "Este es el plugins numero 3";

    public int Run(){
        return 3;
    }   
}
