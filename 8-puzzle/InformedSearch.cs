using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _8_puzzle
{
    class InformedSearch
    {
        public InformedSearch()
        {

        }
        public Stack<Node> GreedyFirstSearch(Node root)
        {
            Stack<Node> PathToSolution = new Stack<Node>();
            Stack<Node> OpenList = new Stack<Node>();
            Stack<Node> ClosedList = new Stack<Node>();

            OpenList.Push(root);
            bool goalFound = false;

            while (OpenList.Count > 0 && !goalFound)
            {
                Node currentNode = OpenList.Pop();
                ClosedList.Push(currentNode);
                currentNode.ExpandNode();

                GBFSC MyComparer = new GBFSC();
                foreach(Node child in currentNode.children)
                {
                    child.Heurs();
                }
                currentNode.children.Sort(MyComparer);

                for (int i = 0; i < currentNode.children.Count; i++)
                {
                    Node currentChild = currentNode.children[i];
                    if (currentChild.GoalTest())
                    {
                        Console.WriteLine("Meta encontrada.");
                        goalFound = true;

                        PathTrace(PathToSolution, currentChild);
                    }

                    if (!Contains(OpenList, currentChild) && !Contains(ClosedList, currentChild))
                        OpenList.Push(currentChild);
                }

            }

            return PathToSolution;
        }

        public Stack<Node> AStarSearch(Node root)
        {
            Stack<Node> PathToSolution = new Stack<Node>();
            Stack<Node> OpenList = new Stack<Node>();
            Stack<Node> ClosedList = new Stack<Node>();

            OpenList.Push(root);
            bool goalFound = false;

            while (OpenList.Count > 0 && !goalFound)
            {
                Node currentNode = OpenList.Pop();
                ClosedList.Push(currentNode);
                currentNode.ExpandNode();

                AStarC MyComparer = new AStarC();
                foreach (Node child in currentNode.children)
                {
                    child.Heurs();
                }
                currentNode.children.Sort(MyComparer);

                for (int i = 0; i < currentNode.children.Count; i++)
                {
                    Node currentChild = currentNode.children[i];
                    if (currentChild.GoalTest())
                    {
                        Console.WriteLine("Meta encontrada.");
                        goalFound = true;

                        PathTrace(PathToSolution, currentChild);
                    }

                    if (!Contains(OpenList, currentChild) && !Contains(ClosedList, currentChild))
                        OpenList.Push(currentChild);
                }

            }

            return PathToSolution;
        }

        public void PathTrace(Stack<Node> path, Node n)
        {
            Console.WriteLine("Trazando ruta...");
            Node current = n;
            path.Push(current);

            while (current.parent != null)
            {
                current = current.parent;
                path.Push(current);
            }
        }

        public static bool Contains(Stack<Node> list, Node c)
        {
            bool contains = false;

            foreach (Node _node in list)
            {
                if (_node.IsSamePuzzle(c.puzzle))
                    contains = true;
            }
            return contains;
        }
    }
    
}
