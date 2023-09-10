namespace Lab_1_Inlämning_Iths
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            // Ask user to input string with random digits and letters.
            Console.WriteLine("\nWrite a random string with digits and letters and then press enter:\n");

            // Variables
            string input = Console.ReadLine(); // Exempelsträng: "29535123p48723487597645723645"
            string newSubstring = "";
            long totalSum = 0;

            // List holding all numbers 
            List<string> listWithNumbers = new List<string>();

            // Iterates through input word
            for (int i = 0; i < input.Length; i++)
            {
                // Runs if char is a digit
                if (IsDigit(input[i]))
                {
                    newSubstring += input[i];

                    // Iterates through input word again starting at i+1 
                    for (int j = i + 1; j < input.Length; j++)
                    {
                        newSubstring += input[j];

                        // Runs if a match is found
                        if (input[j] == input[i])
                        {
                            //Add number to list, reset and break
                            listWithNumbers.Add(newSubstring);
                            newSubstring = "";
                            break;
                        }
                        // Runs if char is not a digit, reset and break
                        else if (IsDigit(input[j]) == false)
                        {
                            newSubstring = "";
                            break;
                        }
                    }
                    // If no match is found
                    newSubstring = "";
                    continue;
                }
            }

            Console.WriteLine();

            // Print string with substrings in different color and calculate sum
            foreach (string substring in listWithNumbers)
            {
                DifferentColorSubstringInString(substring, input);
                Console.WriteLine();

                //Convert substrings to long and calculate sum
                long newNumber = long.Parse(substring);
                totalSum += newNumber;
            }

            PrintTotalSum(totalSum);

            Console.ReadKey();

        }

        static bool IsDigit(char digit)
        {
            if (digit >= '0' && digit <= '9')
            {
                return true;
            }
            return false;
        }

        static void PrintTotalSum(long totalSum)
        {
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("\n************************************");
            Console.WriteLine($"\nTotal sum = {totalSum}");
            Console.WriteLine("\n************************************");
            Console.WriteLine();
        }

        static void DifferentColorSubstringInString(string substring, string input)
        {

            int currentIndex = 0;

            while (currentIndex < input.Length)
            {
                int nextSubstringIndex = input.IndexOf(substring, currentIndex);

                // Runs if no match is found
                if (nextSubstringIndex == -1)
                {
                    Console.Write(input.Substring(currentIndex));
                    break;
                }
                else
                {
                    // Input before substring
                    Console.Write(input.Substring(currentIndex, nextSubstringIndex - currentIndex));

                    // Substring in different color
                    Console.ForegroundColor = ConsoleColor.Magenta;
                    Console.Write(substring);

                    // Reset Color
                    Console.ResetColor();

                    currentIndex = nextSubstringIndex + substring.Length;
                }
            }
        }
    }
}