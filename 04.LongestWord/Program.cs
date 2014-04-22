/* Problem 4. Longest Alphabetical Word
 */

using System;
using System.Collections.Generic;
using System.Text;

class Program
{
    static List<string> posibles = new List<string>();

    static void Main()
    {
        string word = Console.ReadLine().ToLower();
        int n = int.Parse(Console.ReadLine());
        char[,] matrix = new char[n, n];


        int index = 0;
        for (int i = 0; i < n; i++) //generate the matrix
            for (int j = 0; j < n; j++)
            {
                matrix[i, j] = word[index];
                index++;
                if (index == word.Length) index = 0;
            }
        //print(matrix);
        //Console.WriteLine();
        extractWords(matrix);
        posibles.Sort();
        string answer = "";
        int maxLength = 0;
        for (int i = 0; i < posibles.Count; i++)
        {
            if (posibles[i].Length > maxLength) { maxLength = posibles[i].Length; answer = posibles[i]; }
        }

        for (int i = 1; i < posibles.Count; i++)
        {
            if (posibles[i].Length == maxLength && string.Compare(posibles[i], answer) < 0) answer = posibles[i];
        }
        Console.WriteLine(answer);
    }

    private static void extractWords(char[,] matrix)
    {
        int width = matrix.GetLength(1);
        int height = matrix.GetLength(0);
        StringBuilder line = new StringBuilder();
        for (int row = 0; row < height; row++)
        {
            for (int col = 0; col < width; col++)
            {
                if (line.Length == 0) line.Append(matrix[row, col]);

                line.Length = 1; //read to left
                for (int i = col - 1; i >= 0; i--)
                    if (line[line.Length - 1] < matrix[row, i]) line.Append(matrix[row, i]); else break;
                if (!posibles.Contains(line.ToString())) posibles.Add(line.ToString());
                line.Length = 1; //read to right
                for (int i = col + 1; i < width; i++)
                    if (line[line.Length - 1] < matrix[row, i]) line.Append(matrix[row, i]); else break;
                if (!posibles.Contains(line.ToString())) posibles.Add(line.ToString());
                line.Length = 1; //read to up
                for (int i = row - 1; i >= 0; i--)
                    if (line[line.Length - 1] < matrix[i, col]) line.Append(matrix[i, col]); else break;
                if (!posibles.Contains(line.ToString())) posibles.Add(line.ToString());
                line.Length = 1; //read to down
                for (int i = row + 1; i < height; i++)
                    if (line[line.Length - 1] < matrix[i, col]) line.Append(matrix[i, col]); else break;
                if (!posibles.Contains(line.ToString())) posibles.Add(line.ToString());
                line.Length = 0;
            }
        }

    }


    static void print(char[,] matrix)
    {
        int rows = matrix.GetLength(0);
        int cols = matrix.GetLength(1);
        for (int i = 0; i < rows; i++)
        {
            for (int j = 0; j < cols; j++)
            {
                Console.Write(matrix[i, j]);
            }
            Console.WriteLine();
        }
    }
}