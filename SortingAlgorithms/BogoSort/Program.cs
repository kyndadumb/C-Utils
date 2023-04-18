using System.IO;
using System;

namespace BogoSort;
class Program
{
    static void Main()
    {
        // Create sample Data
        //DataHelper.GenerateInput();

        // Read sample Data
        //List<int> numbers = DataHelper.ReadInput(".\\input.txt");

        List<int> numbers = new List<int>();

        Random rand = new Random();

        for (int i = 0; i < 1; i++)
        {
            numbers.Add(rand.Next(1000));
        }


        Console.WriteLine("BogoSort is sorting");

        Sort(numbers);
    }


    // Check if the list is correctely sorted
    static bool IsSorted(List<int> data)
    {
        for (int i = 0; i <= data.Count; i++)
        {
            if (data[i] > data[i + 1])
            {
                return false;
            }
        }        
        
        return true;
    }

    static void PrintIteration(List<int> data, int iteration)
    {
        Console.WriteLine("BogoSort iteration #{0}: ", iteration);

        foreach (int value in data)
        {
            Console.WriteLine($"{value}");
        }
    }

    static void Sort(List<int> data)
    {
        int iteration = 0;

        while (!IsSorted(data))
        {
            PrintIteration(data, iteration);
            data = Shuffle(data);
            iteration++;
        }

        PrintIteration(data,iteration);
        Console.WriteLine("BogoSort completed after {0} iterations.", iteration);
    }

    static List<int> Shuffle(List<int> numbers)
    {
        Random rand = new Random();

        for (int i = numbers.Count - 1; i > 0; --i)
        {
            int k = rand.Next(i + 1);

            int temp = numbers[i];
            numbers[i] = numbers[k];
            numbers[k] = temp;
        }
        
        return numbers;
    }
}
