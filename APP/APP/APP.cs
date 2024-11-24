using System;
using System.Collections.Concurrent;
using System.IO;
using System.Runtime.InteropServices.Marshalling;
using System.Threading.Tasks;
using Swopblock;

namespace APP
{
    public class App : Swopblock.Console
    {
        public App(string processorName, string[] args, out Task whenAll) : base(processorName, args, out whenAll)
        {
        }
    }
}

