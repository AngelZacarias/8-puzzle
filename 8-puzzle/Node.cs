using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _8_puzzle
{
    class Node
    {
        const int n = 3;
        public List<Node> children = new List<Node>();
        public Node parent;
        public int[] puzzle = new int[9];
        public int[,] puzzle2 = new int[3,3];
        public int x = 0;
        public int col = 3;
        public int costg = 3;
        public int costh = 3;
        public int costt = 3;

        public Node(int[] p)
        {
            SetPuzzle(p);
        }

        public void SetPuzzle(int[] p)
        {
            for (int i = 0; i < puzzle.Length; i++)
            {
                this.puzzle[i] = p[i];
            }
        }

        public void ExpandNode()
        {
            for (int i = 0; i < puzzle.Length; i++)
            {
                if (puzzle[i] == 0)
                {
                    x = i;
                    this.costg += 1;
                    this.Heurs();
                    this.costt = this.costg + this.costh;
                }
            }
            MoveToRight(puzzle, x);
            MoveToLeft(puzzle, x);
            MoveToDown(puzzle, x);
            MoveToUp(puzzle, x);
        }

        public void MoveToRight(int[] p, int i)
        {
            if (i % col < col - 1)
            {
                int[] pc = new int[9];
                CopyPuzzle(pc, p);

                int temp = pc[i + 1];
                pc[i + 1] = pc[i];
                pc[i] = temp;

                Node child = new Node(pc);
                children.Add(child);
                child.parent = this;

                this.costg += 1;
                this.Heurs();
                this.costt = this.costg + this.costh;
            }
        }

        public void MoveToLeft(int[] p, int i)
        {
            if (i % col > 0)
            {
                int[] pc = new int[9];
                CopyPuzzle(pc, p);

                int temp = pc[i - 1];
                pc[i - 1] = pc[i];
                pc[i] = temp;

                Node child = new Node(pc);
                children.Add(child);
                child.parent = this;

                this.costg += 1;
                this.Heurs();
                this.costt = this.costg + this.costh;
            }
        }

        public void MoveToUp(int[] p, int i)
        {
            if (i - col >= 0)
            {
                int[] pc = new int[9];
                CopyPuzzle(pc, p);

                int temp = pc[i - 3];
                pc[i - 3] = pc[i];
                pc[i] = temp;

                Node child = new Node(pc);
                children.Add(child);
                child.parent = this;

                this.costg += 1;
                this.Heurs();
                this.costt = this.costg + this.costh;
            }
        }

        public void MoveToDown(int[] p, int i)
        {
            if (i + col < puzzle.Length)
            {
                int[] pc = new int[9];
                CopyPuzzle(pc, p);

                int temp = pc[i + 3];
                pc[i + 3] = pc[i];
                pc[i] = temp;

                Node child = new Node(pc);
                children.Add(child);
                child.parent = this;

                this.costg += 1;
                this.Heurs();
                this.costt = this.costg + this.costh;
            }
        }

        public string PrintPuzzle()
        {
            string puzzleString = "";
            Console.WriteLine();
            puzzleString += "\n";

            int m = 0;
            for (int i = 0; i < col; i++)
            {
                for (int j = 0; j < col; j++)
                {
                    Console.Write(puzzle[m] + " ");
                    puzzleString += puzzle[m] + "  ";
                    m++;
                }
                Console.WriteLine();
                puzzleString += "\n";
            }
            return puzzleString;
        }

        public bool IsSamePuzzle(int[] p)
        {
            bool samePuzzle = true;
            for (int i = 0; i < p.Length; i++)
            {
                if (puzzle[i] != p[i])
                {
                    samePuzzle = false;
                }
            }
            return samePuzzle;
        }


        public void CopyPuzzle(int[] a, int[] b)
        {
            for (int i = 0; i < b.Length; i++)
            {
                a[i] = b[i];
            }
        }

        public bool GoalTest()
        {
            bool isGoal = true;
            int m = puzzle[0];

            for (int i = 1; i < puzzle.Length; i++)
            {
                if (m > puzzle[i])
                    isGoal = false;
                m = puzzle[i];
            }
            return isGoal;
        }
        public void Heurs()
        {
            int[,] Goal = new int[,] { { 0, 1, 2 }, { 3, 4, 5 }, { 6, 7, 8 } };
            int[,] A = new int[,] { { puzzle[0], puzzle[1], puzzle[2] }, { puzzle[3], puzzle[4], puzzle[5] }, { puzzle[6], puzzle[7], puzzle[8] } };
            puzzle2 = A;
            int i, i2, j, j2, Heuristic = 0;
            bool found;
            for (i = 0; i < n; i++)
            {
                for (j = 0; j < n; j++)
                {
                    found = false;
                    for (i2 = 0; i2 < n; i2++)
                    {
                        for (j2 = 0; j2 < n; j2++)
                        {
                            // finding similar elements.
                            if (Goal[i,j] == A[i2,j2])
                            {
                                //Manhaten Based Heuristic displacement cost.
                                Heuristic += Math.Abs(i - i2) + Math.Abs(j - j2);
                                found = true;
                            }
                            if (found)
                                break;
                        }
                        if (found)
                            break;
                    }
                }
            }
            // setting the state heurisitc cost.
            this.costh = Heuristic;
        }
    }
}
