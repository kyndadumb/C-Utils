using System.IO;

namespace StalinSort;
class Program
{
    static void Main(string[] args)
    {
        List<int> randoms = CreateRandomIntList(1000);

        Console.WriteLine("Unsorted:");
        for (int i = 0; i < randoms.Count; i++)
        {
            Console.WriteLine(randoms[i]);
        }

        List<int> sorted = StalinSort(randoms);

        Console.WriteLine("Sorted:");
        for (int y = 0; y < sorted.Count; y++)
        {
            Console.WriteLine(sorted[y]);
        }
    }

    // StalinSort
    public static List<int> StalinSort(List<int> inputs)
    {
        List<int> result = inputs;

        // case: length of list is only one
        if (result.Count == 1)
        {
            return result;
        }

        // loop through the list from behind, remove if next int is bigger
        for (int i = result.Count - 2; i >= 0; i--)
        {
            if (result[i] > result[i + 1])
            {
                result.RemoveAt(i);
            }
        }

        return result;
    }


    // create list with random ints
    static List<int> CreateRandomIntList(int count)
    {
        List<int> result = new List<int>();
        Random random = new Random();

        for (int i = 0; i <= count; i++)
        {
            result.Add(random.Next(100));
        }

        return result;
    }
}
