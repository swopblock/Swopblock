using System;
using System.Collections.Concurrent;
using System.IO;
using System.Runtime.InteropServices.Marshalling;
using System.Threading.Tasks;
using Swopblock;

namespace CORE
{
    public class Core : Swopblock.Console
    {
        public Core(string processorName, string[] args, out Task whenAll) : base(processorName, args, out whenAll)
        {
        }
    }
}

