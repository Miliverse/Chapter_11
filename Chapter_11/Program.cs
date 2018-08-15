using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Media;
using System.Threading;
using System.IO;
using System.Diagnostics;
using System.Runtime.InteropServices;

namespace Chapter_11
{
    public static class Game
    {
        //Establish typewriting effect
        static void Typewrite(string message)
        {
            for (int i = 0; i < message.Length; i++)
            {
                Console.Write(message[i]);
                System.Threading.Thread.Sleep(30);
            }
            // End the message with \n
            Console.Write(Environment.NewLine);
        }

        //Start the game. Duh
        public static void StartGame()
        {
            Console.ForegroundColor = ConsoleColor.White;

        }

        // Text that explains the backstory, starts at the beginning of the game.
        public static void OpeningLore()
        {
            Typewrite("Placeholder");


        }



    }
    class Program
    {
        //I'm not commenting this, figure it out
        [DllImport("kernel32.dll", ExactSpelling = true)]

        private static extern IntPtr GetConsoleWindow();
        private static IntPtr ThisConsole = GetConsoleWindow();

        [DllImport("user32.dll", CharSet = CharSet.Auto, SetLastError = true)]

        private static extern bool ShowWindow(IntPtr hWnd, int nCmdShow);
        private const int HIDE = 0;
        private const int MAXIMIZE = 3;
        private const int MINIMIZE = 6;
        private const int RESTORE = 9;

        static void Main(string[] args)
        {
            //I'm not commenting this, figure it out
            Console.SetWindowSize(Console.LargestWindowWidth, Console.LargestWindowHeight);
            ShowWindow(ThisConsole, MAXIMIZE);
            Game.StartGame(); //Start the game

        }

   
    }
    
}
