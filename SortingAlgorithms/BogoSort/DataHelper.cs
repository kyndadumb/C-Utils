namespace BogoSort;
public class DataHelper
{
    public static void GenerateInput()
    {
        Random rand = new Random();

        List<int> numbers = new List<int>();

        for (int i = 0; i <= 100; i++)
        {
            numbers.Add(rand.Next(1,1001));
        }

        String filepath = "input.txt";

        using (StreamWriter writer = new StreamWriter(filepath))
        {
            foreach (int number in numbers)
            {
                writer.WriteLine(number);
            }
        }
    }

    public static List<int> ReadInput(String filename)
    {
        List<int> data = null;

        try 
        {
            using (StreamReader reader = new StreamReader(filename))
            {
                String line;
                
                while ((line = reader.ReadLine()) != null)
                {
                    int number = int.Parse(line);
                    data.Add(number);
                }
            }
        }
        
        catch (Exception e) 
        {
            Console.WriteLine("Error while Reading the file: " + e.Message);
        }

        return data;
    }
}
