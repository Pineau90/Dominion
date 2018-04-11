using System;

namespace Dominion
{
    class Program
    {
        static void Main(string[] args)
        {
            Gameboard gameboard = new Gameboard();

            Console.WriteLine(gameboard.Name);
            Console.ReadKey();
        }
    }

    public class Gameboard
    {
        // Properties
        public string Name { get; set; }

        // Method
        public string Stack()
        {
            return "Hi";
        }


        // Instance constructor
        public Gameboard()
        {
            Name = "Gameboard";
        }
    }
}
