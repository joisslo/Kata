using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace CodeKata

{
    public class Kata
    {
        #region ArrayDiff(int[] a, int[] b)

        // Using List
        public static int[] ArrayDiff(int[] a, int[] b)
        {
            // Your goal in this kata is to implement an difference function, which subtracts one
            // list from another.

            // It should remove all values from list a, which are present in list b.

            //Kata.ArrayDiff(new int[] { 1, 2 }, new int[] { 1 }) => new int[] { 2 }

            //If a value is present in b, all of its occurrences must be removed from the other:

            //Kata.ArrayDiff(new int[] { 1, 2, 2, 2, 3 }, new int[] { 2 }) => new int[] { 1, 3 }
            List<int> newArray = new List<int>();
            bool isUnique;

            foreach (int target in a)
            {
                isUnique = true;
                foreach (int num in b)
                {
                    if (target == num)
                    {
                        isUnique = false;
                    }
                }
                if (isUnique)
                {
                    newArray.Add(target);
                }
            }

            int[] finishedArray = newArray.ToArray();
            return finishedArray;
        }

        // Resizing the array using Array.resize<>()
        public static int[] ArrayDiff2(int[] a, int[] b)
        {
            // Your goal in this kata is to implement an difference function, which subtracts one
            // list from another.

            // It should remove all values from list a, which are present in list b.

            //Kata.ArrayDiff(new int[] { 1, 2 }, new int[] { 1 }) => new int[] { 2 }

            //If a value is present in b, all of its occurrences must be removed from the other:

            //Kata.ArrayDiff(new int[] { 1, 2, 2, 2, 3 }, new int[] { 2 }) => new int[] { 1, 3 }
            int[] newArray = new int[0];
            bool isUnique;

            foreach (int target in a)
            {
                isUnique = true;
                foreach (int num in b)
                {
                    if (target == num)
                    {
                        isUnique = false;
                    }
                }
                if (isUnique)
                {
                    Array.Resize<int>(ref newArray, newArray.Length + 1);
                    newArray[newArray.Length - 1] = target;
                }
            }

            return newArray;
        }

        // Resizing the array manually
        public static int[] ArrayDiff3(int[] a, int[] b)
        {
            // Your goal in this kata is to implement an difference function, which subtracts one
            // list from another.

            // It should remove all values from list a, which are present in list b.

            //Kata.ArrayDiff(new int[] { 1, 2 }, new int[] { 1 }) => new int[] { 2 }

            //If a value is present in b, all of its occurrences must be removed from the other:

            //Kata.ArrayDiff(new int[] { 1, 2, 2, 2, 3 }, new int[] { 2 }) => new int[] { 1, 3 }
            int[] newArray = new int[0];
            bool isUnique;

            foreach (int target in a)
            {
                isUnique = true;
                foreach (int num in b)
                {
                    if (target == num)
                    {
                        isUnique = false;
                        break;
                    }
                }
                if (isUnique)
                {
                    int[] tempArray = new int[newArray.Length + 1];
                    for (int i = 0; i < newArray.Length; i++)
                    {
                        tempArray[i] = newArray[i];
                    }
                    tempArray[newArray.Length] = target;
                    newArray = tempArray;
                }
            }

            return newArray;
        }

        #endregion ArrayDiff(int[] a, int[] b)

        #region RemoveSmallest(List<int> numbers)

        // Using List
        public static List<int> RemoveSmallest(List<int> numbers)
        {
            //Given an array of integers, remove the smallest value. Do not mutate the original array/ list.If there are multiple
            //elements with the same value, remove the one with a lower index. If you get an empty array/ list,
            //return an empty array/ list.

            //Don't change the order of the elements that are left.
            //Examples

            //Remover.RemoveSmallest(new List<int> { 1, 2, 3, 4, 5 }) = new List<int> { 2, 3, 4, 5 }
            //Remover.RemoveSmallest(new List<int> { 5, 3, 2, 1, 4 }) = new List<int> { 5, 3, 2, 4 }
            //Remover.RemoveSmallest(new List<int> { 2, 2, 1, 2, 1 }) = new List<int> { 2, 2, 2, 1 }

            if (numbers.Count == 0)
            {
                return numbers;
            }

            int smallest = numbers.First();
            int index = 0;

            for (int i = 0; i < numbers.Count; i++)
            {
                if (numbers.ElementAt<int>(i) < smallest)
                {
                    smallest = numbers.ElementAt<int>(i);
                    index = i;
                }
            }

            numbers.RemoveAt(index);

            return numbers;
        }

        // Using Linq
        public static List<int> RemoveSmallest2(List<int> numbers)
        {
            //Given an array of integers, remove the smallest value. Do not mutate the original array/ list.If there are multiple
            //elements with the same value, remove the one with a lower index. If you get an empty array/ list,
            //return an empty array/ list.

            //Don't change the order of the elements that are left.
            //Examples

            //Remover.RemoveSmallest(new List<int> { 1, 2, 3, 4, 5 }) = new List<int> { 2, 3, 4, 5 }
            //Remover.RemoveSmallest(new List<int> { 5, 3, 2, 1, 4 }) = new List<int> { 5, 3, 2, 4 }
            //Remover.RemoveSmallest(new List<int> { 2, 2, 1, 2, 1 }) = new List<int> { 2, 2, 2, 1 }

            numbers.Remove(numbers.DefaultIfEmpty().Min());
            return numbers;
        }

        #endregion RemoveSmallest(List<int> numbers)

        #region FindNextSquare(long num)

        // With Math.sqrt()
        public static long FindNextSquare(long num)
        {
            //Complete the findNextSquare method that finds the next integral perfect square after the one passed
            //as a parameter. Recall that an integral perfect square is an integer n such that sqrt(n) is also an integer.

            //If the parameter is itself not a perfect square, then - 1 should be returned. You may assume the parameter is positive.

            //Examples:

            //findNextSquare(121)-- > returns 144
            //findNextSquare(625)-- > returns 676
            //findNextSquare(114)-- > returns - 1 since 114 is not a perfect
            if (Math.Sqrt(num) % 1 != 0)
            {
                return -1;
            }
            var squareRoot = Math.Sqrt(num) + 1;
            return (long)(squareRoot * squareRoot);
        }

        // Brute Force
        public static long FindNextSquare2(long num)
        {
            //Complete the findNextSquare method that finds the next integral perfect square after the one passed
            //as a parameter. Recall that an integral perfect square is an integer n such that sqrt(n) is also an integer.

            //If the parameter is itself not a perfect square, then - 1 should be returned. You may assume the parameter is positive.

            //Examples:

            //findNextSquare(121)-- > returns 144
            //findNextSquare(625)-- > returns 676
            //findNextSquare(114)-- > returns - 1 since 114 is not a perfect

            //In the event that the input is very large, we should cut down on the time necessary
            //to step through values incrementally.
            long split = num / 2;
            while ((long)(split * split) > num || split * split < 0)
            {
                split /= 2;
            }

            //Now begin stepping through the values until we find a solution
            long root = split;
            long squared = root * root;

            while (squared <= num)
            {
                if (squared == num)
                {
                    //success, now increment by 1 and return new square
                    root++;
                    return root * root;
                }
                root++;
                squared = root * root;
            }

            return -1;
        }

        #endregion FindNextSquare(long num)

        #region GetVowelCount(string str)

        // Using Linq
        public static int GetVowelCount(string str)
        {
            var numberOfVowels = from ch in str where new char[] { 'a', 'e', 'i', 'o', 'u' }.Contains(ch) select ch;
            return numberOfVowels.Count();
        }

        #endregion GetVowelCount(string str)

        #region FriendOrFoe(string[] names)

        public static IEnumerable<string> FriendOrFoe(string[] names)
        {
            //Make a program that filters a list of strings and returns a list with only your friends name in it.
            //If a name has exactly 4 letters in it, you can be sure that it has to be a friend of yours!
            //Otherwise, you can be sure he's not...
            //Ex: Input = ["Ryan", "Kieran", "Jason", "Yous"], Output = ["Ryan", "Yous"]
            //Note: keep the original order of the names in the output.
            List<string> friends = new List<string>();
            foreach (string name in names)
            {
                if (name.Length == 4)
                {
                    friends.Add(name);
                }
            }

            return friends;
        }

        #endregion FriendOrFoe(string[] names)

        #region GetSum(int a, int b)

        //GetSum(1, 0) == 1   // 1 + 0 = 1
        //GetSum(1, 2) == 3   // 1 + 2 = 3
        //GetSum(0, 1) == 1   // 0 + 1 = 1
        //GetSum(1, 1) == 1   // 1 Since both are same
        //GetSum(-1, 0) == -1 // -1 + 0 = -1
        //GetSum(-1, 2) == 2  // -1 + 0 + 1 + 2 = 2

        // Manually
        public static int GetSum(int a, int b)
        {
            int smaller = (a < b) ? a : b;
            int larger = (a > b) ? a : b;
            int sum = 0;
            for (; smaller <= larger; smaller++)
            {
                sum += smaller;
            }
            return sum;
        }

        // Using Math.Abs()
        public static int GetSum2(int a, int b)
        {
            return (a + b) * (Math.Abs(a - b) + 1) / 2;
        }

        #endregion GetSum(int a, int b)

        #region FindOddInt(int[] seq)

        // Manually
        public static int FindOddInt(int[] seq)
        {
            int count = 0;
            foreach (int target in seq)
            {
                foreach (int num in seq)
                {
                    count = (num == target) ? ++count : count;
                }
                if (count % 2 != 0)
                {
                    return target;
                }
                else
                {
                    count = 0;
                }
            }
            return 0;
        }

        // Binary XOR
        public static int FindOddInt2(int[] seq)
        {
            int found = 0;

            foreach (var num in seq)
            {
                found ^= num;
            }

            return found;
        }

        #endregion FindOddInt(int[] seq)

        #region IsTriangle(int a, int b, int c)

        public static bool IsTriangle(int a, int b, int c)
        {
            return (Math.Abs(a) + Math.Abs(b) <= Math.Abs(c)) ? false : true;
        }

        #endregion IsTriangle(int a, int b, int c)

        #region CountBits(int n)

        public static int CountBits(int n)
        {
            var binaryRepresentation = Convert.ToString(n, 2);
            var numOfOnes = 0;
            foreach (char ch in binaryRepresentation)
            {
                if (ch == '1')
                {
                    numOfOnes++;
                }
            }
            return numOfOnes;
        }

        #endregion CountBits(int n)

        #region TripleDouble(long num1, long num2)

        //which takes in numbers num1 and num2 and returns 1 if there is a straight triple of a number
        //at any place in num1 and also a straight double of the same number in num2.
        //For example:
        //TripleDouble(451999277, 41177722899) == 1 // num1 has straight triple 999s and
        //                                          // num2 has straight double 99s
        //TripleDouble(1222345, 12345) == 0 // num1 has straight triple 2s but num2 has only a single 2
        //TripleDouble(12345, 12345) == 0
        //TripleDouble(666789, 12345667) == 1

        //Regex
        public static int TripleTrouble(long num1, long num2)
        {
            Regex triplePattern = new Regex("([\\d])\\1\\1");
            Regex doublePattern = new Regex("([\\d])\\1");

            return (triplePattern.IsMatch(num1.ToString()) && doublePattern.IsMatch(num2.ToString())) ? 1 : 0;
        }

        //Manually
        public static int TripleTrouble2(long num1, long num2)
        {
            char unique;
            bool isTriple = false;
            bool isDouble = false;
            string num1String = num1.ToString();
            string num2String = num2.ToString();

            for (int i = 0; i < num1String.Length - 2; i++)
            {
                if (num1String[i].Equals(num1String[i + 1]) && num1String[i].Equals(num1String[i + 2]))
                {
                    isTriple = true;
                    unique = num1String[i];
                    Console.WriteLine("Unique Char: " + unique);
                    Console.WriteLine("i = " + i);
                    for (int j = 0; j < num2String.Length - 1; j++)
                    {
                        if (num2String[j].Equals(unique) && num2String[j + 1].Equals(unique))
                        {
                            isDouble = true;
                        }
                    }
                }
            }

            return (isTriple && isDouble) ? 1 : 0;
        }

        #endregion TripleDouble(long num1, long num2)

        #region Likes(string[] name)

        public static string Likes(string[] name)
        {
            switch (name.Length)
            {
                case 0:
                    {
                        return "no one likes this";
                    }
                case 1:
                    {
                        return string.Format("{0} likes this", name[0]);
                    }
                case 2:
                    {
                        return string.Format("{0} and {1} like this", name[0], name[1]);
                    }
                case 3:
                    {
                        return string.Format("{0}, {1} and {2} like this", name[0], name[1], name[2]);
                    }
                default:
                    {
                        return string.Format("{0}, {1} and {2} others like this", name[0], name[1], name.Length - 2);
                    }
            }
        }

        #endregion Likes(string[] name)

        #region Tribonacci(double[] signature, int n)

        // Fibonacci sequencer except summing previous 3 values instead of 2 Manually
        public static double[] Tribonacci(double[] signature, int n)
        {
            if (n == 0)
            {
                return new double[1];
            }
            else if (n < 3)
            {
                double[] newArray = new double[n];
                for (int element = 0; element < newArray.Length; element++)
                {
                    newArray[element] = signature[element];
                }
                return newArray;
            }
            else
            {
                double[] tribonacci = new double[n];
                signature.CopyTo(tribonacci, 0);
                for (int index = 0; index < n - 3; index++)
                {
                    tribonacci[index + 3] = tribonacci[index] + tribonacci[index + 1] + tribonacci[index + 2];
                }
                return tribonacci;
            }
        }

        #endregion Tribonacci(double[] signature, int n)

        #region CountSmileys(string[] smileys)

        // Using '.Contains()'
        public static int CountSmileys(string[] smileys)
        {
            int count = 0;
            string[] validSmileys = { ":D", ":~)", ";~D", ":)" };
            foreach (string smiley in smileys)
            {
                if (validSmileys.Contains(smiley))
                {
                    count++;
                }
            }
            return count;
        }

        // Manually
        public static int CountSmileys2(string[] smileys)
        {
            int count = 0;
            string[] validSmileys = { ":)", ":D", ";-D", ":~)" };
            foreach (string smiley in smileys)
            {
                foreach (string validSmiley in validSmileys)
                {
                    if (smiley.Equals(validSmiley))
                    {
                        count++;
                    }
                }
            }
            return count;
        }

        #endregion CountSmileys(string[] smileys)

        //TODO:

        #region BouncingBall(double h, double bounce, double window)

        //A child plays with a ball on the nth floor of a big building.The height of this floor is known.
        //(float parameter "h" in meters.Condition 1) : h > 0)
        //He lets out the ball.The ball bounces for example to two-thirds of its height.
        //(float parameter "bounce". Condition 2) : 0 < bounce< 1)
        //His mother looks out of a window that is 1.5 meters from the ground.
        //(float parameters "window". Condition 3) : window<h).
        //How many times will the mother see the ball either falling or bouncing in front of the window?
        //If all three conditions above are fulfilled, return a positive integer, otherwise return -1.
        //Note
        //You will admit that the ball can only be seen if the height of the rebouncing
        //ball is stricty greater than the window parameter.
        //Example:
        //h = 3, bounce = 0.66, window = 1.5, result is 3
        //h = 3, bounce = 1, window = 1.5, result is -1 (Condition 2) not fulfilled).

        public static int BouncingBall(double h, double bounce, double window)
        {
            return 0;
        }

        #endregion BouncingBall(double h, double bounce, double window)

        #region SongDecoder(string input)

        public static string SongDecoder(string input)
        {
            input = input.ToUpper().Replace("WUB", " ").Trim();
            while (input.Contains("  "))
            {
                input = input.Replace("  ", " ");
            }
            return input;
        }

        #endregion SongDecoder(string input)

        #region DuplicateCount(string input)
        public static int DuplicateCount(string input)
        {
            input = input.ToLower();
            int count = 0;
            for (char c = 'a'; c <= 'z'; c++)
            {
                int match = 0;
                foreach (char letter in input)
                {
                    if (c.Equals(letter))
                    {
                        match++;
                    }
                }
                if (match > 1)
                {
                    count++;
                }
            }
            return count;
        }
        #endregion
    }
}