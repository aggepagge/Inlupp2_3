using System;
using Explotion.Controller;

namespace Explotion
{
#if WINDOWS || XBOX
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        static void Main(string[] args)
        {
            using (XNAController game = new XNAController())
            {
                game.Run();
            }
        }
    }
#endif
}

