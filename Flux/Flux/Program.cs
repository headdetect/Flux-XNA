using System;

namespace Flux
{
#if WINDOWS || XBOX
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        static void Main(string[] args)
        {
            using (FluxGame game = new FluxGame())
            {
                game.Run();
            }
        }
    }
#endif
}

