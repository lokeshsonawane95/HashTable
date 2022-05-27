namespace HashTable
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("\t\t\t\t\tWelcome to Hash Map Program");
            int choice;
            while (true)
            {
                Console.WriteLine("\n1. Find frequency of words in a sentence");
                Console.WriteLine("2. Find frequency of words in a large paragraph phrase");

                Console.WriteLine("0. Exit");
                Console.Write("Enter your choice : ");
                choice = Convert.ToInt32(Console.ReadLine());
                switch (choice)
                {
                    case 1:
                        //declaring string for counting operation
                        string frequency = "To be or not to be";

                        //declaring List to compare hash table items with
                        List<string> compareList = new List<string>();

                        //declaring List to store word and its frequency
                        List<string> storeCountList = new List<string>();

                        //spliting the string and converting it to an array for further calculation
                        string[] frequencyArray = frequency.Split(' ');

                        //decclaring hash table of the length of frequencyArray
                        MyMapNode<int, string> hash1 = new MyMapNode<int, string>(frequencyArray.Length);
                        for (int i = 0; i < frequencyArray.Length; i++)
                        {
                            //Adding each word to hash table
                            hash1.Add(i, frequencyArray[i]);

                            //Displaying each word stored in the hash table
                            Console.Write(hash1.Get(i) + " ");
                        }
                        Console.WriteLine();
                        for (int i = 0; i < frequencyArray.Length; i++)
                        {
                            //declaring count to count number of occurances of the words
                            int count = 0;
                            for (int j = 0; j < frequencyArray.Length; j++)
                            {
                                //if our phrase array contains same word
                                if (frequencyArray[j].ToLower() == hash1.Get(i).ToLower())
                                {
                                    //then we will increase the count
                                    count++;

                                    //Condition checking and loop breaking for internal loop
                                    //to avoid duplicate entries in our table we are using a condition
                                    if (compareList.Contains(hash1.Get(j).ToLower()))
                                    {
                                        //if value is already available in our compareList2 list then we'll break internal loop
                                        break;
                                    }
                                }
                            }
                            //Condition checking and loop breaking for external loop
                            //if value already present in our compareList2 list then we'll continue from next iteration
                            if (compareList.Contains(hash1.Get(i).ToLower()))
                            {
                                continue;
                            }
                            //Adding the word to compareList for further comparison for duplicates
                            compareList.Add(hash1.Get(i));

                            //finally storing the word and its frequency in storeCountList list
                            storeCountList.Add(hash1.Get(i) + "\t" + count);
                        }

                        //Printing each word in our sentence and its frequency stored in storeCountList
                        Console.WriteLine("Word and their frequencies shown below");
                        for (int i = 0; i < storeCountList.Count; i++)
                        {
                            Console.WriteLine(storeCountList[i]);
                        }
                        break;
                    case 2:
                        //declaring string for counting operation
                        string frequency2 = "Paranoids are not paranoid because they are paranoid but because they keep putting themselves deliberately into paranoid avoidable situations";

                        //declaring List to compare hash table items with
                        List<string> compareList2 = new List<string>();

                        //declaring List to store word and its frequency
                        List<string> storeCountList2 = new List<string>();

                        //spliting the string and converting it to an array for further calculation
                        string[] frequencyArray2 = frequency2.Split(' ');

                        //decclaring hash table of the length of frequencyArray
                        MyMapNode<int, string> hash2 = new MyMapNode<int, string>(frequencyArray2.Length);

                        Console.WriteLine("Given phrase is :\n");
                        for (int i = 0; i < frequencyArray2.Length; i++)
                        {
                            //Adding each word to hash table
                            hash2.Add(i, frequencyArray2[i]);

                            //Displaying each word stored in the hash table
                            Console.Write(hash2.Get(i) + " ");
                        }
                        Console.WriteLine("\n");
                        for (int i = 0; i < frequencyArray2.Length; i++)
                        {
                            //declaring count to count number of occurances of the words
                            int count = 0;
                            for (int j = 0; j < frequencyArray2.Length; j++)
                            {
                                //if our phrase array contains same word
                                if (frequencyArray2[j].ToLower() == hash2.Get(i).ToLower())
                                {
                                    //then we will increase the count
                                    count++;

                                    //Condition checking and loop breaking for internal loop
                                    //to avoid duplicate entries in our table we are using a condition
                                    if (compareList2.Contains(hash2.Get(j).ToLower()))
                                    {
                                        //if value is already available in our compareList2 list then we'll break internal loop
                                        break;
                                    }
                                }
                            }
                            //Condition checking and loop breaking for external loop
                            //if value already present in our compareList2 list then we'll continue from next iteration
                            if (compareList2.Contains(hash2.Get(i).ToLower()))
                            {
                                continue;
                            }
                            //Adding the word to compareList2 for further comparison for duplicates
                            compareList2.Add(hash2.Get(i));

                            //finally storing the word and its frequency in storeCountList2 list
                            storeCountList2.Add(hash2.Get(i) + "\t" + count);
                        }
                        //Printing each word in our phrase and its frequency stored in storeCountList2
                        Console.WriteLine("Word and their frequencies shown below");
                        for (int i = 0; i < storeCountList2.Count; i++)
                        {
                            Console.WriteLine(storeCountList2[i]);
                        }
                        break;
                    default:
                        Console.WriteLine("Please enter correct choice");
                        break;
                    case 0:
                        return;
                }
            }
        }
    }
}