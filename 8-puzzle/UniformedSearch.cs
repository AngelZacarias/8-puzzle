using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _8_puzzle
{
    class UniformedSearch
    {
        //Matybe we could use these variables for Iterative Depth Search
        int nLimite = 5;
        int nivelActual = 0;
        public UniformedSearch()
        {
           
        }

        public Stack<Node> DeepthFirstSearch(Node root)
        {
            Stack<Node> PathToSolution  = new Stack<Node>();
            Stack<Node> OpenList        = new Stack<Node>();
            Stack<Node> ClosedList      = new Stack<Node>();

            OpenList.Push(root);
            bool goalFound = false;

            while (OpenList.Count > 0 && !goalFound)
            {
                Node currentNode = OpenList.Pop();
                ClosedList.Push(currentNode);
                currentNode.ExpandNode();
                
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

        public List<Node> BreadFirstSearch(Node root)
        {
            List<Node> PathToSolution = new List<Node>();
            List<Node> OpenList = new List<Node>();
            List<Node> ClosedList = new List<Node>();

            OpenList.Add(root);
            bool goalFound = false;

            while (OpenList.Count > 0 && !goalFound)
            {
                Node currentNode = OpenList[0];
                ClosedList.Add(currentNode);
                OpenList.RemoveAt(0);

                currentNode.ExpandNode();
                //currentNode.PrintPuzzle();

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
                        OpenList.Add(currentChild);
                }
            }

            return PathToSolution;
        }

        public Stack<Node> IterativeDeepthFirstSearch(Node root)
        {
            Stack<Node> PathToSolution = new Stack<Node>();
            Stack<Node> OpenList = new Stack<Node>();
            Stack<Node> ClosedList = new Stack<Node>();

            nivelActual = 0;

            OpenList.Push(root);
            bool goalFound = false;
            
            while (true)
            {
                while (OpenList.Count > 0 || !goalFound)
                {
                    Node currentNode = OpenList.Pop();
                    ClosedList.Push(currentNode);
                    currentNode.ExpandNode();

                    for (int i = 0; i < currentNode.children.Count; i++)
                    {
                        Node currentChild = currentNode.children[i];
                        if (currentChild.GoalTest())
                        {
                            Console.WriteLine("Meta encontrada.");
                            goalFound = true;

                            PathTrace(PathToSolution, currentChild);
                            return PathToSolution;
                        }

                        if (!Contains(OpenList, currentChild) && !Contains(ClosedList, currentChild))
                            OpenList.Push(currentChild);
                    }

                }
            }
        }

        public void PathTrace(List<Node> path, Node n)
        {
            Console.WriteLine("Trazando ruta...");
            Node current = n;
            path.Add(current);

            while (current.parent != null)
            {
                current = current.parent;
                path.Add(current);
            }
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

        public static bool Contains(List<Node> list, Node c)
        {
            bool contains = false;

            for (int i = 0; i < list.Count; i++)
            {
                if (list[i].IsSamePuzzle(c.puzzle))
                    contains = true;
            }
            return contains;
        }

        public static bool Contains(Stack<Node> list, Node c)
        {
            bool contains = false;

            foreach (Node _node in list){
                if (_node.IsSamePuzzle(c.puzzle))
                    contains = true;
            }
            return contains;
        }

        /*This funtion was proposed as sustitution for a different way to manage the constraints 
         * in the DFS Algorithm.
         * It didn't worked as well as the original, but may be helpfull as idea in future.*/
        public static bool Contains2(Stack<Node> list, Node c)
        {
            bool contains = false;
            int xVisited = 0;
            int xCurrent = 0;
            for (int i = 0; i < c.puzzle.Length; i++)
            {
                if (c.puzzle[i] == 0)
                    xCurrent = i;
            }
            foreach (Node _node in list)
            {
                for (int i = 0; i < _node.puzzle.Length; i++)
                {
                    if (_node.puzzle[i] == 0)
                        xVisited = i;
                }
                if(xCurrent == xVisited)
                {
                    contains = true;
                    break;
                }
            }
            return contains;
        }

    }
}
