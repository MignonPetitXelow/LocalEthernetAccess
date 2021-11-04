using System;
using System.Net.NetworkInformation;
using System.Reflection;
using System.IO;

namespace LocalIpFounder
{   
    class Program
    {
        static void Main(string[] args)
        {
            String AppPath = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
            String LogPath = AppPath+@"\latest.log";
            String BuildVersion = Assembly.GetExecutingAssembly().GetName().Version.ToString();

            Console.BackgroundColor = ConsoleColor.White;
            Console.ForegroundColor = ConsoleColor.Black;
            Console.Title = "LIF 1.0.0.2";
            Console.WriteLine("LOCAL IP FOUNDER.   ");
            Console.WriteLine("Use \"help\" to see commands. ");
            while (true)
            {
                Console.BackgroundColor = ConsoleColor.Black;
                Console.ForegroundColor = ConsoleColor.White;
                Console.Write(Environment.UserName+": ");
                String cmd = Console.ReadLine();

                if (cmd == "help")
                {
                    Console.WriteLine("|- help");
                    Console.WriteLine("|- search");
                    Console.WriteLine("|- version");
                    Console.WriteLine(" ");
                }
                if (cmd == "search")
                {
                    foreach (NetworkInterface netInterface in NetworkInterface.GetAllNetworkInterfaces())
                    {
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.WriteLine("Name: " + netInterface.Name);
                        Console.WriteLine("Description: " + netInterface.Description);
                        Console.WriteLine("Addresses: ");
                        IPInterfaceProperties ipProps = netInterface.GetIPProperties();
                        foreach (UnicastIPAddressInformation addr in ipProps.UnicastAddresses)
                        {
                            Console.WriteLine(" " + addr.Address.ToString());
                        }
                        Console.WriteLine("");
                    }
                    Console.BackgroundColor = ConsoleColor.Black;
                    Console.ForegroundColor = ConsoleColor.White;
                }
                if (cmd == "version")
                {
                    Console.WriteLine("Build Version: "+Console.Title);
                }
            }
        }
    }
}
