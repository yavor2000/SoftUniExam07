/* Problem 1. Fruit Market
 */

using System;

class Program
{
    static void Main()
    {
        string[] name = { "banana", "cucumber", "tomato", "orange", "apple" };
        double[] price = { 1.8, 2.75, 3.2, 1.6, 0.86 };
        double[] quant = { 0.0, 0.0, 0.0, 0.0, 0.0 };
        double[] dis = { 1.0, 1.0, 1.0, 1.0, 1.0 };

        switch (Console.ReadLine())
        {
            case "Friday": dis[0] = 0.9; dis[1] = dis[0]; dis[2] = dis[0]; dis[3] = dis[0]; dis[4] = dis[0]; break;
            case "Sunday": dis[0] = 0.95; dis[1] = dis[0]; dis[2] = dis[0]; dis[3] = dis[0]; dis[4] = dis[0]; break;
            case "Tuesday": dis[0] = 0.8; dis[3] = dis[0]; dis[4] = dis[0]; break;
            case "Wednesday": dis[1] = 0.9; dis[2] = dis[1]; break;
            case "Thursday": dis[0] = 0.70; break;
        }

        for (int i = 0; i < 3; i++)
        {
            double tmp = double.Parse(Console.ReadLine());
            string nam = Console.ReadLine();
            for (int k = 0; k < name.GetLength(0); k++)
                if (nam == name[k]) quant[k] += tmp;
        }
        double totalPrice = 0;
        for (int i = 0; i < name.GetLength(0); i++)
            totalPrice += quant[i] * price[i] * dis[i];

        Console.WriteLine("{0:F2}", totalPrice);
    }
}