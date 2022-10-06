using System;

namespace LAB_6
{
    internal class Program
    {
        static void Main(string[] args)
        {
			Console.WriteLine("Created by Andriy Malyava.");
			var Comander = new classes.Circuit.Comander();
            Comander.run();
        }
    }
}
