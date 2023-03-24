using System;

namespace SieveOfEratosthenes;

class Program
{
    static void Main()
    {
        const int MAX = 100;

        // Create an boolean array for indication if a number is prime
        // start by setting all true

        bool[] isPrime = new bool[MAX+1];

        // for - all values in bool[] isPrime
        for (int i = 0; i < isPrime.Length; i++)
        {
            isPrime[i] = true;
        }

        // how does the sieve work?
        // loop through number i --> start with 2 - each multiple of this isPrime = false
        for (int i=2; i < Math.Sqrt(MAX)+1; i++) 
        {
            // if - isPrime
            if (isPrime[i]) 
            {
                // for - all multiples of i
                for (int j = (int)Math.Pow(i,2); j<=MAX; j += i) 
                {
                    // set isPrime to false
                    isPrime[j] = false;
                }
            }
        }

        // print results
        
        // for - each number until MAX
        for (int k = 2; k <= MAX; k++)
        {
            // if k isPrime - print result
            if (isPrime[k])
            {
                Console.WriteLine(k);
            }
        }
    }
}
