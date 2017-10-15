using System;

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
