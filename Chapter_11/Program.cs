﻿using System;
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
        public static void Typewrite(string message)
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
            OpeningLore();
        }

        
        // Text that explains the backstory, starts at the beginning of the game.
        public static void OpeningLore()
        {
            Typewrite("Placeholder");
            Console.ReadKey();
        }

        // Profile creation system, probably
        public static void ProfileCreation()
        {

        }

    }
    class Program 
    {
        //Starts the program up in full screen or something
        [DllImport("kernel32.dll", ExactSpelling = true)]

        private static extern IntPtr GetConsoleWindow();
        private static IntPtr ThisConsole = GetConsoleWindow();

        [DllImport("user32.dll", CharSet = CharSet.Auto, SetLastError = true)]

        private static extern bool ShowWindow(IntPtr hWnd, int nCmdShow);
        private const int HIDE = 0;
        private const int MAXIMIZE = 3;
        private const int MINIMIZE = 6;
        private const int RESTORE = 9;

        static void Main(string[] args) // program game running thingy. stick stuff you want the program to run at launch in here
        {
            //Relates to earlier code about starting the program in full screen
            Console.SetWindowSize(Console.LargestWindowWidth, Console.LargestWindowHeight);
            ShowWindow(ThisConsole, MAXIMIZE);
            Console.ForegroundColor = ConsoleColor.White;
            Console.Title = "Chapter 11";
            Game.StartGame(); //Start the game
            ExternalData.Menu();
        }
    }
    class ExternalData // External Data Reading
    {

        // public things relating to the file reading thing
        public static string DataFile = "data.txt";
        public static string Content = "(Empty File)";
        public static string Input = "";
        public static bool Run = true;
        public static int Choice = 0;

        // Color... text?
        static void ColorText(string Message)
        {
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.BackgroundColor = ConsoleColor.White;
            Console.WriteLine(Message);
            Console.ResetColor();

        }

        // Placeholder thing
        static void Placeholder()
        {
            Console.Title = "Chapter 11 - Save Mode";
            while (Run == true)
            {
                Menu();
            }
        }

        // Menu where you select what you what to do relating to a file
        // will later to change to a save system
        public static void Menu()
        {
            string input = "";
            int Choice = 0;

            // Print menu to the screen
            Console.WriteLine("\n\n\n\n\n------------------------------------------");
            Console.WriteLine(" 1) Read Content 2) Update Content 3) Exit");
            Console.WriteLine("------------------------------------------");


            Input = Console.ReadLine();
            Choice = Convert.ToInt32(Input);
            if (Choice == 1)
            {
                Console.Clear();
                if (File.Exists(DataFile))
                {
                    ColorText("The File contents are: ");
                    Content = File.ReadAllText(DataFile);
                }
                Console.WriteLine(Content);
                Console.ReadKey();
                Menu();
            }
            else if (Choice == 2)
            {
                Console.Clear();
                ColorText("\n\nEnter new content and press enter to save it:");
                Input = Console.ReadLine();
                Content = Input;

                ColorText("\nConfirm that file contents will be replaced.\nType Y or N:");

                Input = Console.ReadLine();
                Input = Input.ToLower();

                if (Input == "y")
                {
                    File.WriteAllText(DataFile, Content);
                    ColorText("File updated.");
                    Menu();
                }
                else
                {
                    ColorText("File not updated.");
                    Menu();
                }
            }
            
        }
    }
}

            
            
                    






                
            
           

        

        

    
    

