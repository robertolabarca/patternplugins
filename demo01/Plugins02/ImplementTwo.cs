using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using PluginBase;

namespace Plugins02;
public class ImplementTwo:ICommand
{
    public string Id { get;} = "two";
    public string Description { get;} = "Este es el plugins numero 2";

    public int Run(){
        return 2;
    }   
}
