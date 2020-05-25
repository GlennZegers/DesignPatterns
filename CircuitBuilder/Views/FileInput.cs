using System;
using System.IO;

namespace CircuitBuilder.Views
{
    public class FileInput
    {
        public string GetFileInput()
        {
            var validPath = false;
            var userInput = "";
            while (!validPath)
            {
                Console.WriteLine("Enter the path for your input file");
                userInput = Console.ReadLine();
                if (userInput != null && File.Exists(userInput))
                {
                    validPath = true;
                }
            }
            return userInput;
        }
    }
}