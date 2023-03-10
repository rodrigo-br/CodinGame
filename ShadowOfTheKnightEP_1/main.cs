using System;
using System.Linq;
using System.IO;
using System.Text;
using System.Collections;
using System.Collections.Generic;

public class Position
{
    public static int posX;
    public static int posY;

    public Position(int x, int y)
    {
        posX = x;
        posY = y;
    }

    public string newPosition(int x, int y)
    {
        string newPos;

        posX = posX + x;
        posY = posY + y;
        newPos = posX.ToString() + " " + posY.ToString();
        return newPos;
    }
}

public class Moviment : Position
{
    public static int yMax;
    public static int xMax;
    public static int yMin;
    public static int xMin;

    public Moviment(int x, int y, int x0, int y0) : base(x0, y0)
    {

        xMin = 0;
        yMin = 0;
        xMax = x;
        yMax = y;
    }

    public void updateMax(string c)
    {
        if (c.ToUpper().Contains('L'))
        {
            xMax = posX;
        }
        else if (c.ToUpper().Contains('R'))
        {
            xMin = posX;
        }
        else
        {
            xMin = 0;
            xMax = 0;
        }
        if (c.ToUpper().Contains('U'))
        {
            yMax = posY;
        }
        else if (c.ToUpper().Contains('D'))
        {
            yMin = posY;
        }
        else
        {
            yMax = 0;
            yMin = 0;
        }
    }

    public int calcMovX(string c)
    {
        int movX = 0;
        int mlm = xMax - xMin;

        if (mlm == 0)
        {
            return 0;
        }
        if (mlm % 2 != 0)
        {
            mlm++;
        }
        movX = mlm / 2;
        if (c.ToUpper().Contains('L'))
        {
            movX *= -1;
        }
        return movX;
    }

    public int calcMovY(string c)
    {
        int movY = 0;
        int mlm = (yMax - yMin);

        if (mlm == 0)
        {
            return 0;
        }
        if (mlm % 2 != 0)
        {
            mlm++;
        }
        movY = mlm / 2;
        if (c.ToUpper().Contains('U'))
        {
            movY *= -1;
        }
        return movY;
    }
}

class Player
{
    static void Main(string[] args)
    {
        string[] inputs;
        inputs = Console.ReadLine().Split(' ');
        int Width = int.Parse(inputs[0]);
        int Height = int.Parse(inputs[1]);
        int N = int.Parse(Console.ReadLine()); // maximum number of turns before game over.
        inputs = Console.ReadLine().Split(' ');
        int X0 = int.Parse(inputs[0]);
        int Y0 = int.Parse(inputs[1]);
        Moviment mov = new Moviment(Width, Height, X0, Y0);

        while (true)
        {
            string bombDir = Console.ReadLine(); // the direction of the bombs from batman's current location (U, UR, R, DR, D, DL, L or UL)
            mov.updateMax(bombDir);
            Console.WriteLine(mov.newPosition(mov.calcMovX(bombDir), mov.calcMovY(bombDir)));
        }
    }
}