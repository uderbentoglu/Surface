using System;
using System.Linq;
using System.IO;
using System.Text;
using System.Collections;
using System.Collections.Generic;
using System.Drawing;

/**
 * Auto-generated code below aims at helping you parse
 * the standard input according to the problem statement.
 **/
class Solution
{
    static int result;
    static void Main(string[] args)
    {
        int L = int.Parse(Console.ReadLine());
        int H = int.Parse(Console.ReadLine());
        char[,] map = new char[L, H];
        for (int i = 0; i < H; i++)
        {
            string row = Console.ReadLine();
            for (int j = 0; j < L; j++)
            {
                map[j, i] = row[j];
            }
        }
        int N = int.Parse(Console.ReadLine());
        Point[] pointsToBeTested = new Point[N];
        for (int i = 0; i < N; i++)
        {
            string[] inputs = Console.ReadLine().Split(' ');
            Point p = new Point(int.Parse(inputs[0]), int.Parse(inputs[1]));
            pointsToBeTested[i] = p;
        }
        for (int i = 0; i < N; i++)
        {
            result = 0;
            char[,] mapCopy = map.Clone() as char[,];
            CalculateWaterArea(pointsToBeTested[i], mapCopy);
            Console.WriteLine(result);
        }
    }

    static void CalculateWaterArea(Point p, char[,] map)
    {
        List<Point> pointsNeedToBeChecked = new List<Point>();
        pointsNeedToBeChecked.Add(p);

        while(pointsNeedToBeChecked.Count > 0)
        {
            var currPoint = pointsNeedToBeChecked.First();

            if (currPoint.X >= map.GetLength(0) || currPoint.X < 0 || currPoint.Y >= map.GetLength(1) || currPoint.Y < 0)
            {
                pointsNeedToBeChecked.Remove(currPoint);
                continue;
            }

            if (map[currPoint.X, currPoint.Y] == 'O')
            {
                result++;
                map[currPoint.X, currPoint.Y] = 'X';

                pointsNeedToBeChecked.Add(new Point(currPoint.X - 1, currPoint.Y));
                pointsNeedToBeChecked.Add(new Point(currPoint.X + 1, currPoint.Y));
                pointsNeedToBeChecked.Add(new Point(currPoint.X, currPoint.Y - 1));
                pointsNeedToBeChecked.Add(new Point(currPoint.X, currPoint.Y + 1));
            }
            pointsNeedToBeChecked.Remove(currPoint);
        }
    }
}
