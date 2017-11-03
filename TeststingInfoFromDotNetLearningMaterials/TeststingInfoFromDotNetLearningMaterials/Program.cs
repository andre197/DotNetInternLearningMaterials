namespace TeststingInfoFromDotNetLearningMaterials
{
    using BinaryTreeFolder;
    using HashTable;
<<<<<<< HEAD
    using MergeSortProject;
=======
    using GraphsProject;
>>>>>>> refs/remotes/origin/master
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using TreeProject;
    using ImplementationOfGraphs;

    public class Program
    {
        // To create vertex connection using matrix use the MatrixCreator method which expects string
        // To create a HashTable and check if it works use the HardCodedHashTable method below
        // To create a tree and search in it use the CreateATree method below
        // To create a non binary tree use the method HardCodedNonBinaryTree below
        // To merge sort use the MergeSort method below, it expects list of elements to search and if it is TopUp or BottomDown true or false value. (TopDownMergeSort/BottomUpMergeSort it is generic)

        public static void Main()
        {
            CreateMatrix matrix = new CreateMatrix();

            matrix.CreateMatrixVertex("abcde");
        }

        private static void MergeSort<T>(IList<T> collection, bool isTopDown = true)
            where T : IComparable
        {
            MergeSorter sorter = new MergeSorter();

            var returned = sorter.SplitThenSort(collection, isTopDown);

            PrintCollection(returned);
        }

        private static void MatrixCreator(string vertecies)
        {
            CreateMatrix matrix = new CreateMatrix();

            matrix.CreateMatrixVertex(vertecies);
        }

        /// <summary>
        /// ajksdhkjashdasd
        /// </summary>
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

            Console.WriteLine("--------------BFS traverse--------------");
            Console.WriteLine();

            Queue<Node<int>> nodes = tree.BFSTraverse(tree.Root);

            PrintCollection(nodes.Select(n => n.Value));

            Console.WriteLine();
            Console.WriteLine("--------------DFS traverse--------------");
            Console.WriteLine();

            tree.PrintDFSTraverse(tree.Root, "  ");

            Console.WriteLine();
            Console.WriteLine("--------------DFS traverse with stack--------------");
            Console.WriteLine();

            Stack<Node<int>> moreNodes = tree.DFSTraverseWithStack(tree.Root);

            PrintCollection(moreNodes.Select(n => n.Value));
        }

        /// <summary>
        /// asdasdasd
        /// </summary>
        /// <typeparam name="T"> </typeparam>
        /// <param name="collection"> The collection to be printed</param>
        private static void PrintCollection<T>(IEnumerable<T> collection)
        {
            foreach (var item in collection)
            {
                Console.WriteLine(item);
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
