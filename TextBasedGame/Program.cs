using System;
using FSPG;

namespace TextBasedGame
{
    class Program
    {
        static void Main(string[] args)
        {
            Room r = new Room();

            Console.BufferWidth = 100;
            Console.WindowWidth = 100;

            //Starting the game
            r.Beginning();
            //First room
            r.Room0();
            
        }
    }
}
