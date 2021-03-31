using System;
using System.Linq;

namespace SecretChat
{
    class Program
    {
        static void Main(string[] args)
        {
            string concealedMessage = Console.ReadLine();

            while (true)
            {
                string line = Console.ReadLine();

                if (line == "Reveal")
                {
                    //ToDo
                    break;
                }

                string[] parts = line.Split(":|:", StringSplitOptions.RemoveEmptyEntries);

                string command = parts[0];

                // InsertSpace:|:{index}
                if (command == "InsertSpace")
                {
                    int idx = int.Parse(parts[1]);

                    concealedMessage = concealedMessage.Insert(idx, " ");

                    Console.WriteLine(concealedMessage);
                }
                else if (command == "Reverse")
                {
                    //Reverse:|:{substring}
                    string substring = parts[1];

                    if (concealedMessage.Contains(substring))
                    {
                        int idx = concealedMessage.IndexOf(substring);
                        int length = substring.Length;
                        concealedMessage = concealedMessage.Remove(idx, length);
                        char[] reversedArr = substring.Reverse().ToArray();
                        string reversed = string.Join("", reversedArr);

                        concealedMessage = concealedMessage + reversed;

                        Console.WriteLine(concealedMessage);
                    }
                    else // if (!concealedMessage.Contains(substring))
                    {
                        Console.WriteLine($"error");
                    }
                }
                else  // if (command == "ChangeAll")
                {
                    // ChangeAll:|:{substring}:|:{replacement}
                    string substr = parts[1];
                    string replacement = parts[2];

                    while (true)
                    {
                        if (!concealedMessage.Contains(substr))
                        {
                            break;
                        }

                        concealedMessage = concealedMessage.Replace(substr, replacement);
                    }

                    Console.WriteLine(concealedMessage);
                }
            }

            Console.WriteLine($"You have a new text message: {concealedMessage}");           
        }
    }
}
