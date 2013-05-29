using System;

namespace ElementalGame
{
#if WINDOWS || XBOX
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        static void Main(string[] args)
        {
            using (MainScreen game = new MainScreen())
            {
                game.Run();
            }
        }
    }
#endif
}

