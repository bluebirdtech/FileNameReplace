using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FileNameReplace
{
    class Program
    {
        static void Main( string[] args )
        {
            var replacer = new FileNameReplacer( args[0], args[1], args[2] );
            replacer.Execute();
        }
    }
}
