using System;
using System.Linq;
using System.IO;
using System.Text;
using System.Collections;
using System.Collections.Generic;

class Solution
{
    static void Main(string[] args)
    {
        int n = int.Parse(Console.ReadLine()); // the number of temperatures to analyse
        if (n == 0)
        {
            Console.WriteLine(0);
            return ;
        }
        string[] inputs = Console.ReadLine().Split(' ');
        int smallestTemp = 10001;
        for (int i = 0; i < n; i++)
        {
            int t = int.Parse(inputs[i]);// a temperature expressed as an integer ranging from -273 to 5526
            if (Math.Abs(t) < Math.Abs(smallestTemp))
            {
                smallestTemp = t;
            }
            else if (Math.Abs(t) == Math.Abs(smallestTemp) && t > smallestTemp)
            {
                smallestTemp = t;
            }
        }
        Console.WriteLine(smallestTemp);
    }
}