using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace LinqQuiz.Library
{
    public static class Quiz
    {
        /// <summary>
        /// Returns all even numbers between 1 and the specified upper limit.
        /// </summary>
        /// <param name="exclusiveUpperLimit">Upper limit (exclusive)</param>
        /// <exception cref="ArgumentOutOfRangeException">
        ///     Thrown if <paramref name="exclusiveUpperLimit"/> is lower than 1.
        /// </exception>
        public static int[] GetEvenNumbers(int exclusiveUpperLimit)
        {
            if(exclusiveUpperLimit < 1)
            {
                throw new ArgumentOutOfRangeException();
            }
            int[] numbers = new int [exclusiveUpperLimit-1];
           
             for (int i = 1; i < exclusiveUpperLimit; i++){
                     numbers[i - 1] = i;
             }
             var evennum = (from num in numbers where (num % 2) == 0 select num).ToArray();
             return evennum;
        }

        /// <summary>
        /// Returns the squares of the numbers between 1 and the specified upper limit 
        /// that can be divided by 7 without a remainder (see also remarks).
        /// </summary>
        /// <param name="exclusiveUpperLimit">Upper limit (exclusive)</param>
        /// <exception cref="OverflowException">
        ///     Thrown if the calculating the square results in an overflow for type <see cref="System.Int32"/>.
        /// </exception>
        /// <remarks>
        /// The result is an empty array if <paramref name="exclusiveUpperLimit"/> is lower than 1.
        /// The result is in descending order.
        /// </remarks>
        public static int[] GetSquares(int exclusiveUpperLimit)
        {
            if(exclusiveUpperLimit < 1)
            {
                return new int[0];
            }
            
            if ( exclusiveUpperLimit >= Math.Sqrt(Int32.MaxValue))
            {
                throw new OverflowException();
            }

            int[] numbers = new int[exclusiveUpperLimit - 1];

            for (int i = 1; i < exclusiveUpperLimit; i++)
            {
                numbers[i - 1] = i;
            }
            var squares = (from num in numbers where (num % 7 == 0) orderby num descending select num*num).ToArray();
            
            return squares;
        }

        /// <summary>
        /// Returns a statistic about families.
        /// </summary>
        /// <param name="families">Families to analyze</param>
        /// <returns>
        /// Returns one statistic entry per family in <paramref name="families"/>.
        /// </returns>
        /// <exception cref="ArgumentNullException">
        ///     Thrown if <paramref name="families"/> is <c>null</c>.
        /// </exception>
        /// <remarks>
        /// <see cref="FamilySummary.AverageAge"/> is set to 0 if <see cref="IFamily.Persons"/>
        /// in <paramref name="families"/> is empty.
        /// </remarks>
        public static FamilySummary[] GetFamilyStatistic(IReadOnlyCollection<IFamily> families)
        {
            if (families != null)
            {
                int famId;
                int numofPersons;
                decimal ages = 0;
                decimal avgAge;
                FamilySummary[] famSum = new FamilySummary[families.Count];

                if (families.ElementAt(0).Persons.Count == 0)
                {
                    FamilySummary[] empty = new FamilySummary[1];
                    empty[0] = new FamilySummary { FamilyID = 1, NumberOfFamilyMembers = 0, AverageAge = 0 };
                    return empty;
                }

                for (int i = 0; i < families.Count(); i++)
                {
                    ages = 0;
                    famId = families.ElementAt(i).ID;
                    numofPersons = families.ElementAt(i).Persons.Count;
                    foreach (var per in families.ElementAt(i).Persons)
                    {
                        ages += per.Age;
                    }
                    avgAge = ages / numofPersons;

                    famSum[i] = new FamilySummary { FamilyID = famId, NumberOfFamilyMembers = numofPersons, AverageAge = avgAge };

                }
                return famSum;
            }
            else
            {
                throw new ArgumentNullException();
            }
        }

        /// <summary>
        /// Returns a statistic about the number of occurrences of letters in a text.
        /// </summary>
        /// <param name="text">Text to analyze</param>
        /// <returns>
        /// Collection containing the number of occurrences of each letter (see also remarks).
        /// </returns>
        /// <remarks>
        /// Casing is ignored (e.g. 'a' is treated as 'A'). Only letters between A and Z are counted;
        /// special characters, numbers, whitespaces, etc. are ignored. The result only contains
        /// letters that are contained in <paramref name="text"/> (i.e. there must not be a collection element
        /// with number of occurrences equal to zero.
        /// </remarks>
        public static (char letter, int numberOfOccurrences)[] GetLetterStatistic(string text)
        {
            throw new NotImplementedException();
        }
    }
}
