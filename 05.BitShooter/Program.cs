/* Problem 5. Bit Shooter
 */

using System;

class Program
{
    static void Main()
    {
        ulong n = ulong.Parse(Console.ReadLine());
        //Console.WriteLine(Convert.ToString((long)n, 2).PadLeft(64, '0'));
        for (int i = 0; i < 3; i++)
        {
            string[] numStr = Console.ReadLine().Split(' ');
            int target = int.Parse(numStr[0]);
            int size = int.Parse(numStr[1]);
            int rLeft = (target - size / 2)-1;
            int lRight = (target + size / 2)+1;
            ulong leftNum = (lRight <= 63) ? ((n >> lRight) << lRight) : 0;
            ulong rightNum = (rLeft >= 0) ? (n << (63 - rLeft)) >> (63 - rLeft) : 0;
            n = leftNum + rightNum;
        }
        ulong leftSplit = (n >> 32) << 32;
        ulong rightSplit = (n << 32) >> 32;
        
        int countLeft = 0;
        int countRight = 0;
        while (leftSplit > 0)
        {
            countLeft += (int)leftSplit & 1;
            leftSplit >>= 1;
        }
        while (rightSplit > 0)
        {
            countRight += (int)rightSplit & 1;
            rightSplit >>= 1;
        }
        Console.WriteLine("left: {0}", countLeft);
        Console.WriteLine("right: {0}", countRight);
    }

}