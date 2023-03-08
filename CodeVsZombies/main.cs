using System;
using System.Linq;
using System.IO;
using System.Text;
using System.Collections;
using System.Collections.Generic;

class Player
{
    static string findClosestZombie(int x, int y, int myX, int myY, string closestZombie)
    {
        if (closestZombie.Length == 0)
        {
            return x.ToString() + " " + y.ToString();
        }
        string[] splited = closestZombie.Split(' ');
        int x1 = int.Parse(splited[0]);
        int y1 = int.Parse(splited[1]);
        int distance_1 = (Math.Abs(x - myX) + Math.Abs(y - myY));
        int distance_2 = (Math.Abs(x1 - myX) + Math.Abs(y1 - myY));
        if (distance_1 <= distance_2)
        {
            return x.ToString() + " " + y.ToString();
        }
        return x1.ToString() + " " + y1.ToString();
    }

    static void Main(string[] args)
    {
        string[] inputs;

        while (true)
        {
            inputs = Console.ReadLine().Split(' ');
            int x = int.Parse(inputs[0]);
            int y = int.Parse(inputs[1]);
            int humanCount = int.Parse(Console.ReadLine());
            for (int i = 0; i < humanCount; i++)
            {
                inputs = Console.ReadLine().Split(' ');
                int humanId = int.Parse(inputs[0]);
                int humanX = int.Parse(inputs[1]);
                int humanY = int.Parse(inputs[2]);
            }
            int zombieCount = int.Parse(Console.ReadLine());
            string closestZombie = "";
            for (int i = 0; i < zombieCount; i++)
            {
                inputs = Console.ReadLine().Split(' ');
                int zombieId = int.Parse(inputs[0]);
                int zombieX = int.Parse(inputs[1]);
                int zombieY = int.Parse(inputs[2]);
                int zombieXNext = int.Parse(inputs[3]);
                int zombieYNext = int.Parse(inputs[4]);
                closestZombie = findClosestZombie(zombieXNext, zombieYNext, x, y, closestZombie);
            }
            Console.WriteLine(closestZombie);
        }
    }
}