namespace TeststingInfoFromDotNetLearningMaterials
{
    using BinaryTreeFolder;
    using HashTable;
    using ImplementationOfGraphs;
    using System;
    using System.Collections.Generic;

    public class Program
    {

        public static void Main()
        {

        }

        private static void HardCodedHashTable()
        {
            CustomHashTable<string, string> phoneBook = new CustomHashTable<string, string>();

            phoneBook.Add("Ivan", "0885");
            phoneBook.Add("Petko", "0839");
            phoneBook.Add("Gosho", "1234");

            var searchedItem = phoneBook.Search("Gosho");

            Console.WriteLine(searchedItem.Key + " - " + searchedItem.Value);

            phoneBook.Remove(new KeyValuePair<string, string>("Gosho", "1234"));
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

            tree.TraverseDFS(node , "    ");
        }
    }
}
