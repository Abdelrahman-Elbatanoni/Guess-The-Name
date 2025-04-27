using System;
using System.Collections.Generic;
using System.IO;

namespace GameServer
{
    class WordManager
    {
        private static List<string> words = new List<string>();

        public static string GetRandomWord(string category)
        {
            words.Clear();
            if (File.Exists($"..\\..\\..\\Categories\\{category}.txt"))
            {
                words.AddRange(File.ReadAllLines($"..\\..\\..\\Categories\\{category}.txt"));
            }
            else
            {
                words.AddRange(new[] {"COMPUTER", "PROGRAMMING", "NETWORK" });
            }

            Random rand = new Random();
            return words[rand.Next(words.Count)];
        }
    }

}