/* Problem 2. Biggest Tripple
 */

using System;

class Program
{
    static void Main()
    {
        string[] str = Console.ReadLine().Split(' ');
        long[] num = new long[str.GetLength(0)];
        long index = 0;
        long endd = 0;
        long sum = long.MinValue;
        long tmpSum = 0;
        for (long i = 0; i < num.GetLength(0); i++)
        {
            num[i] = long.Parse(str[i]);
            tmpSum += num[i];
            if ((i + 1) % 3 == 0 || i == num.GetLength(0) - 1)
            {
                if (tmpSum > sum)
                {
                    sum = tmpSum;
                    index = i-i % 3;
                    endd = i;
                }
                tmpSum = 0;
            }
        }
        //Console.WriteLine(sum);
        //Console.WriteLine(index);
        //Console.WriteLine(endd);
        
        for (long i = index; i <= endd; i++)
        {
            Console.Write("{0} ", num[i]);
        }
    }
}