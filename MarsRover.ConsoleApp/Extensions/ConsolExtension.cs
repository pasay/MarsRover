using System;

namespace MarsRover.ConsoleApp.ConsolExtension
{
    public static class Consol
    {
        public static void WriteColor(ConsoleColor highlightColor, string line)
        {
            WriteColor(Console.ForegroundColor, highlightColor, line);
        }
        public static void WriteColor(ConsoleColor normalColor, ConsoleColor highlightColor, string line)
        {
            WriteLineColor(normalColor, highlightColor, line, false);
        }

        public static void WriteLineColor(ConsoleColor highlightColor, string line)
        {
            WriteLineColor(Console.ForegroundColor, highlightColor, line);
        }

        public static void WriteLineColor(ConsoleColor normalColor, ConsoleColor highlightColor, string line)
        {
            WriteLineColor(normalColor, highlightColor, line, true);
        }

        private static void WriteLineColor(ConsoleColor normalColor, ConsoleColor highlightColor, string line, bool newLine)
        {
            try
            {
                Console.ForegroundColor = normalColor;
                foreach (var item in line ?? "")
                {
                    switch (item)
                    {
                        case '[':
                            Console.ForegroundColor = highlightColor;
                            break;
                        case ']':
                            Console.ForegroundColor = normalColor;
                            break;
                        default:
                            Console.Write(item);
                            break;
                    }
                }

                if (newLine)
                {
                    Console.WriteLine("");
                }
            }
            finally
            {
                Console.ResetColor();
            }
        }
    }
}
