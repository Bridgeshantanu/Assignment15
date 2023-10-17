using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Reflection
{
    public class EvenDigitNumberFinder
    {       
        public int FindClosestEvenNumber(int N)
        {
            int closestEvenNumber;

            if (N < 0)
                N = -N;

            int i = 0;
            while (true)
            {
                int lower = N - i;
                int upper = N + i;

                if (AllDigitsEven(lower))
                {
                    closestEvenNumber = -lower;
                    break;
                }

                if (AllDigitsEven(upper))
                {
                    closestEvenNumber = upper;
                    break;
                }

                i++;
            }

            return (N < 0) ? -closestEvenNumber : closestEvenNumber;
        }

        public bool AllDigitsEven(int number)
        {
            while (number > 0)
            {
                int digit = number % 10;
                if (digit % 2 != 0)
                {
                    return false;
                }
                number /= 10;
            }

            return true;
        }
    }
}
