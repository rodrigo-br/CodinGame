using System;
using System.Linq;
using System.IO;
using System.Text;
using System.Collections;
using System.Collections.Generic;

class Player
{
    static void Main(string[] args)
    {
        int width = int.Parse(Console.ReadLine());
        int height = int.Parse(Console.ReadLine());
        string[] str = new string[height];
        int save_i;
        int save_j;

        // CREATE DATA
        for (int i = 0; i < height; i++)
        {
            string line = Console.ReadLine();
            str[i] = line;
        }

        // MAIN LOOP
        for (int i = 0; i < height; ++i)
        {
            save_i = i;
            for (int j = 0; j < width; ++j)
            {
                string result = "";
                save_j = j;
                if (str[i][j] == '0')
                {
                    // MAIN NODE
                    StringBuilder sb_1 = new StringBuilder(str[i]);
                    sb_1[j] = '1';
                    str[i] = sb_1.ToString();
                    result += j.ToString() + " " + i.ToString() + " ";
                    save_j++;

                    // RIGHT NEIGHBOR
                    while (save_j != width && str[i][save_j] != '0')
                    {
                        save_j++;
                    }
                    if (save_j == width)
                    {
                        result += "-1 -1 ";
                    }
                    else
                    {
                        result += save_j.ToString() + " " + i.ToString() + " ";
                    }

                    // BOTTOM NEIGHBOR
                    while (save_i < height && str[save_i][j] != '0')
                    {
                        save_i++;
                    }
                    if (save_i == height)
                    {
                        result += "-1 -1 ";
                    }
                    else
                    {
                        result += j.ToString() + " " + save_i.ToString() + " ";
                    }
                }

                // CHECK FOR RESULTS
                string[] r = result.Split(' ');
                if (r.Length >= 6)
                {
                    Console.WriteLine("{0} {1} {2} {3} {4} {5}", r[0], r[1], r[2], r[3], r[4], r[5]);
                    j = 0;
                    save_i = i;
                }
            }
        }
    }
}