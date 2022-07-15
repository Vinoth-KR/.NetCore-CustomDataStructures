# .NetCore - CustomDataStructures

### Contents

Data Structures Library developed in .Net Core 3.1, and a console application which demonstrates the library implementation with Usage.

This repo consists of Custom LinkedList, BinaryTree and Array Extensions with Sorting algorithms.


### Array Extensions Library - SortingAlgosforArrays.csproj

Implemented few extension methods for Arrays, which includes Sorting Algorithms for Integer Arrays.

The list of Sorting Algorithms implemented are,
- BubbleSort
- SelectionSort
- MergerSort
- QuickSort


### Custom Tree Library - CustombinaryTree.csproj

Implemented Tree datastructure with IsSymmetric() method in-built and Traversal mechanism as a Utility.

Traversal Mechanisms - BinaryTreeUtility
- TraverseTreePreOrder
- TraverseTreePostOrder
- TraverseTreeInOrder

#### IsSymmetric()
 Determines whether the Tree is mirror image of it, checking the Symmetry of the Tree.
 
### Custom LinkedList Library - CustomLinkedList.csproj
  Implemented LinkedList based on custom Node<T> data structure. 
  This implementation incorporates mutiple Basic features from the actual LinkedList from *System.Collections.Generic* namespace.
  
  Additional custom features implemented apart from Basic Functionality are,
  - Reversal of LinkedList. Using *Reverse()* method, which reverses the LinkedList in-line without creation of a new LinkedList.
  - Checking for Loops in LinkedList - *HasCycles()* returns a boolean based on whether the LinkedList contains any loop.
  - Getting nodes which causes the Loop in LinkedList - *GetCycleNodes()* method returns the Node causing the Loop and the Node which starts the Loop
  - Finding MiddleElement of LinkedList - *FindMiddleElement()* returns the middle node of the LinkedList.
  
  
  The above mentioned Libraries are for personal use purposes and not for Professinoal use.
  Suggestions for Improvements/ Colloborations are welcome.

