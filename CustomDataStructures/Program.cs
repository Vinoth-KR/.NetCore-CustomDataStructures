using System;
using CustomBinaryTree;
using CustomLinkedList;
using SortingAlgosForArrays;
using System.Collections.Generic;

namespace CustomDataStructures
{
    class Program
    {
        static CustomLinkedList.LinkedList<int> list = new CustomLinkedList.LinkedList<int>();
        static BinaryTree<int> binaryTree = new BinaryTree<int>();
        static int[] sourceArray = null;

        static void Main(string[] args)
        {


            #region SortingAlgos Samples
            SortingAlgosTest();
            #endregion

            #region BinaryTreeSamples          

            TreeTraversalTest();

            SymmetricTreeTest();

            Console.WriteLine("------------End of BinaryTree Samples----------------------");

            #endregion

            #region LinkedList Samples
            LinkedListReversalTest();

            LinkedListMiddleElementTest();

            CyclesTest();

            GetCycleNodesTest();

            Console.WriteLine("------------End of LinkedList Samples----------------------");
            #endregion


            Console.ReadLine();

        }

        #region SortingAlgos Samples
        private static void SortingAlgosTest()
        {
            PopulateArray(20);

            Console.WriteLine($"The generated array without sorting : "); sourceArray.PrintElements();

            Console.WriteLine("--------------------------------------------------");
            Console.Write("Bubble sort :    ");
            sourceArray.BubbleSort().PrintElements();
            Console.Write("Selection sort : ");
            sourceArray.SelectionSort().PrintElements();   
            Console.Write("Merge sort :     ");
            sourceArray.MergeSort().PrintElements();
            Console.Write("Quick sort :     ");
            sourceArray.QuickSort().PrintElements();

            Console.WriteLine("------------End of SortingAlgos----------------------");
        }

        private static void PopulateArray(int size)
        {            
            sourceArray = new int[size];
            var rnd = new Random();

            for (int i = 0; i < size; i++)
            {
                sourceArray[i] = rnd.Next(0, 200);
            }            
        }
        #endregion

        #region BinaryTree Samples
        private static void PopulateBinaryTreeForTraversal()
        {          
            //Level 0 - RootNode
            binaryTree.AddRootNode(new TreeNode<int>(60));

            //Level 1
            binaryTree.Root.AddNode(30, NodePosition.Left);
            binaryTree.Root.AddNode(100,NodePosition.Right);

            //Level 2
            binaryTree.Root.Left.AddNode(10, NodePosition.Left);
            binaryTree.Root.Left.AddNode(40, NodePosition.Right);
            binaryTree.Root.Right.AddNode(80, NodePosition.Left);
            binaryTree.Root.Right.AddNode(120,NodePosition.Right);

            //Level 3
            binaryTree.Root.Left.Left.AddNode(1, NodePosition.Left);
            binaryTree.Root.Left.Left.AddNode(20,NodePosition.Right);
            binaryTree.Root.Left.Right.AddNode(35,NodePosition.Left);
            binaryTree.Root.Left.Right.AddNode(50,NodePosition.Right);

            binaryTree.Root.Right.Left.AddNode(70,NodePosition.Left);
            binaryTree.Root.Right.Left.AddNode(90,NodePosition.Right);
            binaryTree.Root.Right.Right.AddNode(110,NodePosition.Left);

            Console.WriteLine($"BinaryTree populated with values");
        } 

        private static void TreeTraversalTest()
        {

            //PopulateBinaryTree
            PopulateBinaryTreeForTraversal();

            Console.WriteLine($"Pre-order Traversal of the tree");
            var list = BinaryTreeUtility.TraverseTreePreOrder(binaryTree.Root);
            PrintTreeElements(list);

            Console.WriteLine($"Post-order Traversal of the tree");
            list = BinaryTreeUtility.TraverseTreePostOrder(binaryTree.Root);
            PrintTreeElements(list);

            Console.WriteLine($"In-order Traversal of the tree");
            list = BinaryTreeUtility.TraverseTreeInOrder(binaryTree.Root);
            PrintTreeElements(list);


        }

        private static void PrintTreeElements(List<string> list)
        {
            list.ForEach(x => Console.WriteLine(x));

            Console.WriteLine("-------------------------------------------------------");
        }

        private static void PopulateBinaryTreeForSymmetricTest()
        {
            if (binaryTree.Root != null) binaryTree.Clear();

            //Level 0
            binaryTree.AddRootNode(1);
            
            //Level 1
            binaryTree.Root.AddNode(2, NodePosition.Left);
            binaryTree.Root.AddNode(2,NodePosition.Right);

            //Level 2
            binaryTree.Root.Left.AddNode(3,NodePosition.Left);
            binaryTree.Root.Left.AddNode(4,NodePosition.Right);
            binaryTree.Root.Right.AddNode(4,NodePosition.Left);
            binaryTree.Root.Right.AddNode(3,NodePosition.Right);


        }

        private static void SymmetricTreeTest()
        {
            PopulateBinaryTreeForSymmetricTest();

            Console.WriteLine($"The populated BinaryTree is Symmetric : {binaryTree.IsSymmetric()}");
            Console.WriteLine("--------------------------------------------------------"); ;
        }
        #endregion

        #region LinkedList Samples
        #region LinkedList MiddleElement Sample
        private static void LinkedListMiddleElementTest()
        {
            list.AddLast(1);
            list.AddLast(2);
            list.AddLast(3);
            list.AddLast(4);
            list.AddLast(5);
            list.AddLast(6);
            list.AddLast(7);

            printLinkedList();

            Console.WriteLine($"Middle Element is : {list.FindMiddleElement().Value}");

            Console.WriteLine("----------------------------------------------------------------------");

            list.Clear();
        }
        #endregion

        #region LinkedList Reversal Sample
        private static void LinkedListReversalTest()
        {
            list.AddLast(1);
            list.AddLast(2);
            list.AddLast(3);
            list.AddLast(4);
            list.AddLast(5);

            Console.WriteLine($"First and Last element of the list is {list.Head.Value} and {list.Last.Value}");
            printLinkedList();
            Console.WriteLine($"Reversing the LinkedList");

            list.Reverse();

            Console.WriteLine($"First and Last element of the list is {list.Head.Value} and {list.Last.Value}");
            printLinkedList();
            Console.WriteLine("----------------------------------------------------------------------");

            list.Clear();
        }

        private static void printLinkedList()
        {
            var node = list.Head;
            while (node != null)
            {
                Console.Write($"{node.Value} -> ");
                node = node.Next;
            }
            Console.Write("null");

            Console.WriteLine();
        }
        #endregion

        #region LinkedList GetCycleNode Samples
        private static void GetCycleNodesTest()
        {
            list.AddLast(1);
            list.AddLast(2);
            var node = list.AddLast(3);
            list.AddLast(4);
            list.AddLast(5);

            printLinkedList();

            Console.WriteLine($"Does the LinkedList have cycle : {list.HasCycle()}");
            Console.WriteLine("Adding cyclic Node to the LinkedList");

            var cycleNode = new Node<int>(6, node);
            list.AddLast(cycleNode);
            Console.WriteLine($"Does the LinkedList have cycle : {list.HasCycle()}");
            var (previous, loopNode) = list.GetCycleNodes();
            Console.WriteLine($"The node, that causes the loop: {previous.Value}");
            Console.WriteLine($"The node, that starts the loop: {loopNode.Value}");
            Console.WriteLine("Removing cycle in the LinedList");

            previous.Next = null;
            Console.WriteLine($"Does the LinkedList have cycle :{list.HasCycle()}");

            printLinkedList();
            Console.WriteLine("----------------------------------------------------------------------");

            list.Clear();
        }
        #endregion

        #region LinkedList CyclesTest Samples
        private static void CyclesTest()
        {
            list.AddLast(1);
            list.AddLast(2);
            var node = list.AddLast(3);
            list.AddLast(4);
            list.AddLast(5);
            printLinkedList();
            Console.WriteLine($"Does the LinkedList have cycle : {list.HasCycle()}");
            Console.WriteLine("Adding cyclic Node to the LinkedList");
            var cycleNode = new Node<int>(6, node);
            list.AddLast(cycleNode);
            Console.WriteLine($"Does the LinkedList have cycle : {list.HasCycle()}");

            Console.WriteLine("----------------------------------------------------------------------");

            list.Clear();
        }
        #endregion 
        #endregion
    }
}
