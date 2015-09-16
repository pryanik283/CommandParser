using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CommandParser
{
    class Program
    {
        public const string DELIMITER_SPACE = " ";

        static void Main(string[] args)
        {
            try
            {
                if (args.Length.Equals(0))
                {
                    ShowHelp();
                }

                for (int i = 0; i < args.Length; ++i)
                {
                    var argPair = processArgument(args[i]);
                    switch (argPair.Key)
                    {
                        case "?":
                            ShowHelp();
                            break;
                        case "help":
                            ShowHelp();
                            break;
                        case "k":
                            {
                                for (i = 0; i < args.Length - 1; )
                                {
                                    var key = ++i < args.Length ? args[i] : "null";
                                    var value = ++i < args.Length ? args[i] : "null";

                                    Print(key + " - " + value);
                                }
                            }
                            break;
                        case "ping":
                            Pinging();
                            break;
                        case "print":
                            {
                                string message = ++i < args.Length ? args[i] : "null";
                                Print(message);
                            }
                            break;
                            
                        case "exit":
                            { }
                                break;
                
                       case "sort":
                                {
                                   
                                    string message = args[i+1].Remove(0, 1);
                                    int cn = message.Length;
                                        message = message.Remove(cn - 1, 1);
                                    Print(message);
                                   
                                }
                               break;
                            
                            
                        default:
                            ComNotSupported(argPair.Key);
                            break;
                    }
                   
                }
                Console.Read();
                
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
 
          
        }
        
        
        public static KeyValuePair<string, string> processArgument(string argument)
        {
            
            if (argument[0].Equals('/') || argument[0].Equals('-'))
                argument = argument.Remove(0, 1);

            var delimiterIndex = argument.IndexOf(DELIMITER_SPACE);

            string key = null;
            string value = null;

            if (delimiterIndex <= 0)
            {
                key = argument;
            }
            else
            {
                key = argument.Substring(0, delimiterIndex);
                value = argument.Substring(delimiterIndex);
            }

            return new KeyValuePair<string, string>(key, value);
        }

       
        public static void Pinging()
        {
            Console.WriteLine("Pinging ...");
            Console.Beep(2000, 1000);
        }
        
        public static void Print(string message)
        {
            Console.WriteLine(message);
        }
        
        public static void ShowHelp()
        {
            Console.WriteLine("CommandParser.exe [/?] [/help] [-help] [-k key value] [-ping] [-print <print a value>]");
        }
        public static void ComNotSupported(string arg)
        {
            Console.WriteLine("Command <" + arg + "> is not supported, use CommandParser.exe /? to see set of allowed commands");
            ShowHelp();
        }
    }
}
