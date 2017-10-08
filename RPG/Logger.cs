using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPG
{
    public static class Logger
    {
        public static string Log { get; private set; } = "";

        public static void Write(string input)
        {
            Log += input;
            
        }

        public static void WriteLine(string input)
        {
            Log += $"{input}{Environment.NewLine}";
        }

    }
}
