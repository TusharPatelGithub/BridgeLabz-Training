using System;
using System.Collections.Generic;
using System.IO;
using System.Text.RegularExpressions;
class WordFrequency
{
    static void Main(string[] args)
    {
        string filePath = "sample.txt"; // Replace with your file path
        if (!File.Exists(filePath))
        {
            Console.WriteLine("File not found!");
            return;
        }
        string text = File.ReadAllText(filePath);
        Dictionary<string, int> wordFrequency = CountWordFrequency(text);
        Console.WriteLine("Word Frequencies:");
        foreach (var pair in wordFrequency)
        {
            Console.WriteLine(pair.Key + " : " + pair.Value);
        }
    }
    static Dictionary<string, int> CountWordFrequency(string text)
    {
        Dictionary<string, int> frequency = new Dictionary<string, int>();
        // Remove punctuation and convert to lowercase
        string cleanText = Regex.Replace(text, @"[^\w\s]", "").ToLower();
        string[] words = cleanText.Split(new char[] { ' ', '\n', '\r', '\t' }, StringSplitOptions.RemoveEmptyEntries);
        foreach (string word in words)
        {
            if (frequency.ContainsKey(word))
            {
                frequency[word]++;
            }
            else
            {
                frequency[word] = 1;
            }
        }
        return frequency;
    }
}