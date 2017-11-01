namespace TeststingInfoFromDotNetLearningMaterials
{
    using BinaryTreeFolder;
    using HashTable;
    using ImplementationOfGraphs;
    using System;
    using System.Collections.Generic;
    using TreeProject;

    public class Program
    {
        // To create vertex connection using matrix use the CreateMatrixVertex class in ImplementationOfGraphs folder
        // To create a HashTable and check if it works use the HardCodedHashTable method below
        // To create a tree and search in it use the CreateATree method below
        // To create a non binary tree use the method HardCodedNonBinaryTree below

        public static void Main()
        {
            HardCodedNonBinaryTree();
        }

        private static void HardCodedNonBinaryTree()
        {
            Tree<int> tree = new Tree<int>(7,
                                    new Tree<int>(19,
                                        new Tree<int>(1),  
                                        new Tree<int>(12),
                                        new Tree<int>(31)),
                                    new Tree<int>(21),
                                    new Tree<int>(14,
                                        new Tree<int>(23),  
                                        new Tree<int>(6)));

            Queue<Node<int>> nodes = tree.BFSTraverse(tree.Root);

            foreach (var node in nodes)
            {
                Console.WriteLine(node.Value);
            }
        }

        private static void HardCodedHashTable()
        {
            CustomHashTable<string, string> phoneBook = new CustomHashTable<string, string>();

            // It is 17 in order to check if the phonebook resizes itself after reaching its initial lenght
            const int loopTo = 17;

            for (int i = 0; i < loopTo; i++)
            {
                phoneBook.Add($"Ivan{i}", $"0885{i}");

                // Checks if the phonebook resized itself after adding the 17th element
                if (i == loopTo - 1)
                {
                    Console.WriteLine(phoneBook.Size);
                }
            }

            var searchedItem = phoneBook.Search("Ivan5");

            Console.WriteLine(searchedItem.Key + " - " + searchedItem.Value);

            phoneBook.Remove(new KeyValuePair<string, string>("Ivan5", "12345"));

            // Checks if the phonebook resized itself after removing the 17th element
            Console.WriteLine(phoneBook.Size);
        }

        private static void CreateATree()
        {
            BinaryTree tree = new BinaryTree();
            Node node = null;
            Random rnd = new Random();

            int size = int.Parse(Console.ReadLine());

            for (int i = 0; i < size; i++)
            {
                node = tree.InsertNode(rnd.Next(1000), node);
            }

            tree.TraverseDFS(node, "    ");

            while (true)
            {
                try
                {
                    string input = Console.ReadLine();

                    if (!int.TryParse(input, out int itemToSearch))
                    {
                        break;
                    }

                    int pointAtWhichTheItemWasFound = tree.SearchByValue(itemToSearch, node);

                    Console.WriteLine(pointAtWhichTheItemWasFound);
                }
                catch (InvalidOperationException ioe)
                {
                    Console.WriteLine(ioe.Message);
                }
            }
        }
    }
}
