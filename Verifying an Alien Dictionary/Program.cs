using System;
using System.Collections.Generic;

namespace Verifying_an_Alien_Dictionary
{
  class Program
  {
    static void Main(string[] args)
    {
      string[] words = new string[] { "apple", "app" };
      string order = "abcdefghijklmnopqrstuvwxyz";
      Program p = new Program();
      Console.WriteLine(p.IsAlienSorted(words, order));
    }

    public bool IsAlienSorted(string[] words, string order)
    {
      Dictionary<char, int> alienDic = new Dictionary<char, int>();
      for (int i = 0; i < order.Length; i++)
      {
        alienDic.Add(order[i], i);
      }

      for (int i = 0; i < words.Length - 1; i++)
      {
        int j = 0, k = 0;
        while (j < words[i].Length && k < words[i + 1].Length)
        {
          //["bbb", "aaa"]
          if (alienDic[words[i + 1][k]] < alienDic[words[i][j]]) return false;
          // ["aaa", "bbb"]
          if (alienDic[words[i + 1][k]] > alienDic[words[i][j]]) break;
          j++; k++;
        }

        // ["aaaa", "aaa"]
        if (k == words[i + 1].Length && j < words[i].Length) return false;
      }

      return true;
    }
  }
}
