﻿using System;
using dotnnetcoresfml.Main_Loop;

namespace dotnnetcoresfml
{
    class Program
    {
        static void Main(string[] args)
        {
            MainLoop mainLoop = new MainLoop();
            mainLoop.StartLoop();
            Console.ReadKey();
        }

    }
}
