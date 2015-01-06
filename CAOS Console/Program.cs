using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CAOS;

namespace CAOS_Console
{
    class Program
    {
        static CaosInjector ci;
        static string Version = "0.1.1";
        static string Website = "http://Creatures.Ham5ter.de";
        static string GameName;
        static void Main(string[] args)
        {
            Console.WriteLine("Ham5ter's CAOS Console Version " + Version + "\nFor Updates and more visit:" + Website + "\n");
            bool initialized = false;
            if (args.Length >= 1)
            {
                if (InitializeInjector(args[0]))
                {
                    Console.WriteLine("Game Name: \"" + args[0] + "\"");
                    GameName = args[0];
                    initialized = true;
                }
            }
            else if (InitializeInjector("Docking Station"))
            {
                GameName = "Docking Station";
                initialized = true;
            }
            else if (InitializeInjector("Creatures 3"))
            {
                GameName = "Creatures 3";
                initialized = true;
            }


            while (initialized)
            {
                Console.Write(">>> ");
                try
                {
                    Console.WriteLine(ci.ExecuteCaosGetResult(Console.ReadLine()).Content);
                }
                catch (Exception)
                {
                    initialized = false;
                }
            }

            Console.WriteLine("Ooops... Something went wrong, is the Game Started?\n\n\tPress Any Key to Quit!");
            Console.ReadKey(true);
        }
        static bool InitializeInjector(string GameName)
        {
            try
            {
                ci = new CaosInjector(GameName);
            }
            catch (Exception)
            {
                return false;
            }
            return true;
        }
    }
}
