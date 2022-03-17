using System;
using System.Collections.Generic;
using System.Linq;

//this is from the code exercises from the website
class Solution
{
    public int solution(int N)
    {
        char[] numberDigits = N.ToString().ToCharArray();
        Array.Sort(numberDigits);
        Array.Reverse(numberDigits);
        int largestNum = Convert.ToInt32(numberDigits);
        return largestNum;
        //int[] numberDigits = N.ToString().ToCharArray().Select(Convert.ToInt32).ToArray();
        //int[] numberDigits = N.ToString().ToCharArray().Select(x => Convert.ToInt32(x)).ToArray();

        //Array.Sort(numberDigits);
        //Array.Reverse(numberDigits);
        //int largestNum = Array.
        //return largestNum;
    }
    public int solution2(int[] a)
    {
        int numOfsame = 0;
        Console.WriteLine(a.Length);

        for (int i = 0; i < a.Length; i++)
        {
            Console.WriteLine("i: {0}", i);
            for (int k = i + 1; k < a.Length; k++)
            {
                Console.WriteLine("i: {0}", i);
                Console.WriteLine("k: {0}", k);

                if (a[i] == a[k])
                {
                    numOfsame++;
                }
                if(k == a.Length)
                {
                    break;
                }
            }
        }
        return numOfsame;

    }
}
