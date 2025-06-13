using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

class Program
{
    static void Main()
    {

        string text = @"Вот дом,Который построил Джек.А это пшеница,Которая в темном чулане хранится В доме,Который построил 
Джек. А это веселая птица-синица,Которая часто ворует пшеницу, Которая в темном чулане хранитится В доме Который построил Джек
Который построил Джек.";


        string cleanedText = Regex.Replace(text, @"[^\w\s]", " ");
        cleanedText = cleanedText.ToLower();

 
        string[] words = cleanedText.Split(new char[] { ' ', '\n', '\r', '\t' }, StringSplitOptions.RemoveEmptyEntries);

        
        Dictionary<string, int> wordCount = new Dictionary<string, int>();

        foreach (var word in words)
        {
            if (wordCount.ContainsKey(word))
                wordCount[word]++;
            else
                wordCount[word] = 1;
        }
        Console.WriteLine("{0,-20} | {1,5}", "Слово", "Кол-во");
        Console.WriteLine(new string('-', 28));
        foreach (var pair in wordCount)
        {
            Console.WriteLine("{0,-20} | {1,5}", pair.Key, pair.Value);
        }
    }
}
