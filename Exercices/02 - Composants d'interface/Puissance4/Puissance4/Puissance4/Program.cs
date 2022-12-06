using System;

namespace Puissance4
{
    class Program
    {
        public static int ModeArg { get; set; }
        public static bool Standard { get; set; }

        static void Main(string[] args)
        {
            
            ModeArg = 0;
            Standard = false;
            if (args.Length != 0)
            {
                foreach (var arg in args)
                {
                    
                    if (arg.StartsWith("--Mode="))
                    {
                        bool modeValide = int.TryParse(arg.Substring(7, 1), out int mode);
                        if (0<mode && mode<4)
                        {
                            ModeArg = mode;
                        }
                    }
                    if (arg.StartsWith("--Std"))
                    {
                        Standard = true;
                    }
                }
            }
            Parties game = new Parties();
            game.lancerPartie();

        }
    }
}
