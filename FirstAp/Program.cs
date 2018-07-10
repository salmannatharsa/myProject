using System;
using System.Linq;

namespace FirstAp
{
    class Program
    {
        static char[] alpha = { 'a', 'b', 'c', 'd', 'e', 'f', 'g', 'h', 'i', 'j', 'k', 'l', 'm', 'n', 'o', 'p', 'q', 'r', 's', 't', 'u', 'v', 'w', 'x', 'y', 'z' };
        static void Main(string[] args)
        {
            //Console.WriteLine("Enter a number :");
            //string a = Console.ReadLine();
            //string leadingzero = a.PadLeft(6, '0');

            //Console.WriteLine("Number with leading zero:" + leadingzero);
            //Console.ReadKey();

            Console.WriteLine("Enter Key :");
            int Key = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine("Enter Statement : ");
            string statement = Console.ReadLine();

            string[] array = statement.Split(' ');

            string finalStatement = string.Empty;
            foreach (var item in array)
            {
                finalStatement += getEncryptedString(Key, item) + " ";
            }

            finalStatement = finalStatement.Substring(0, finalStatement.Length - 1);

            Console.WriteLine(finalStatement);
            Console.ReadKey();
        }

        static string getEncryptedString(int key, string word)
        {
            char[] charArray = word.ToArray();
            string returnString = string.Empty;

            foreach (char c in charArray)
            {
                bool isLower = char.IsLower(c);
                if (c != ',' && c != '.')
                {
                    var encrypted = getEncryptedChar(key, c);
                    returnString += (isLower ? encrypted : char.ToUpper(encrypted));
                }
                else
                {
                    returnString += c;
                }
            }
            return returnString;
        }

        static char getEncryptedChar(int key, char letter)
        {
            int foundedIndex = 0;
            for (int i = 0; i < alpha.Length; i++)
            {
                if (alpha[i] == char.ToLower(letter))
                {
                    foundedIndex = i;
                    break;
                }
            }
            int totalIndex = foundedIndex + key;
            int finalIndex = (totalIndex <= 25 ? totalIndex : (totalIndex - 26));
            return alpha[finalIndex];
        }
    }
}
