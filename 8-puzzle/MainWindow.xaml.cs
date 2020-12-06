using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Globalization;
using System.Xml.Schema;

namespace _8_puzzle
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        //Coordenates to analize how the empty space moves
        int xEmpty;
        int yEmpty;

        public MainWindow()
        {
            this.DataContext = this;
            InitializeComponent();
        }

        public string BoxA { get; set; }

        private void btn_Close_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void btn_About_Click(object sender, RoutedEventArgs e)
        {
            About winAbout = new About();
            winAbout.Show();
        }

        private void btn_Run_Click(object sender, RoutedEventArgs e)
        {
            int[] puzzle = new int[9];

            //Fills the array and x,y for the empty space
            if (txt_1.Text == "")
            {
                xEmpty = 0;
                yEmpty = 0;
            }
            else
            {
                puzzle[0] = Convert.ToInt32(txt_1.Text);
            }
            if (txt_2.Text == "")
            {
                xEmpty = 1;
                yEmpty = 0;
            }
            else
            {
                puzzle[1] = Convert.ToInt32(txt_2.Text);
            }
            if (txt_3.Text == "")
            {
                xEmpty = 0;
                yEmpty = 2;
            }
            else
            {
                puzzle[2] = Convert.ToInt32(txt_3.Text);
            }
            if (txt_4.Text == "")
            {
                xEmpty = 1;
                yEmpty = 0;
            }
            else
            {
                puzzle[3] = Convert.ToInt32(txt_4.Text);
            }
            if (txt_5.Text == "")
            {
                xEmpty = 1;
                yEmpty = 1;
            }
            else
            {
                puzzle[4] = Convert.ToInt32(txt_5.Text);
            }
            if (txt_6.Text == "")
            {
                xEmpty = 1;
                yEmpty = 2;
            }
            else
            {
                puzzle[5] = Convert.ToInt32(txt_6.Text);
            }
            if (txt_7.Text == "")
            {
                xEmpty = 2;
                yEmpty = 0;
            }
            else
            {
                puzzle[6] = Convert.ToInt32(txt_7.Text);
            }
            if (txt_8.Text == "")
            {
                xEmpty = 2;
                yEmpty = 1;
            }
            else
            {
                puzzle[7] = Convert.ToInt32(txt_8.Text);
            }
            if (txt_9.Text == "")
            {
                xEmpty = 2;
                yEmpty = 2;
            }
            else
            {
                puzzle[8] = Convert.ToInt32(txt_9.Text);
            }

            //Test puzzle
            //int[] puzzle =
            //{
            //    1, 2, 4,
            //    3, 0, 5,
            //    7, 6, 8
            //};

            Node root = new Node(puzzle);
            root.costg = 0; // start cost
            root.Heurs(); // calculating the heuristic cost.
            root.costt = root.costg + root.costh; //total cost.
            UniformedSearch ui = new UniformedSearch();
            InformedSearch infS = new InformedSearch();
            DateTime startedTime;
            DateTime finalizedTime;
            //Selects the algorithm to solve it
            switch (CBOX_Type.SelectedValue.ToString())
            {
                case "Breadth First Search":
                    startedTime = DateTime.Now;
                    List<Node> BFSsolution = ui.BreadFirstSearch(root);
                    finalizedTime = DateTime.Now;
                    Lbl_SolutionResults.Content = "Elapsed Time:" + finalizedTime.Subtract(startedTime).TotalSeconds.ToString()+" seconds."+ Environment.NewLine + "Total Movements: "+ BFSsolution.Count.ToString();
                    txt_puzzle.Text = "";

                    if (BFSsolution.Count > 0)
                    {
                        foreach (Node movement in BFSsolution)
                        {
                            BoxA = movement.PrintPuzzle();
                            txt_puzzle.Text += BoxA;
                        }
                    }
                    else
                    {
                        Console.WriteLine("El camino a la solución no fue encontrado.");
                        txt_puzzle.Text = "El camino a la solución no fue encontrado.";
                    }
                    break;
                case "Depth First Search":
                    startedTime = DateTime.Now;
                    Stack<Node> DFSsolution = ui.DeepthFirstSearch(root);
                    finalizedTime = DateTime.Now;
                    Lbl_SolutionResults.Content = "Elapsed Time:" + finalizedTime.Subtract(startedTime).TotalSeconds.ToString() +" seconds." + Environment.NewLine + "Total Movements: " + DFSsolution.Count.ToString();
                    txt_puzzle.Text = "";

                    if (DFSsolution.Count > 0)
                    {
                        foreach (Node movement in DFSsolution)
                        {
                            BoxA = movement.PrintPuzzle();
                            txt_puzzle.Text += BoxA;
                        }
                    }
                    else
                    {
                        Console.WriteLine("El camino a la solución no fue encontrado.");
                        txt_puzzle.Text = "El camino a la solución no fue encontrado.";
                    }
                    break;
                case "Iterative Depth First Search":
                    startedTime = DateTime.Now;
                    Stack<Node> IDFSsolution = ui.IterativeDeepthFirstSearch(root);
                    finalizedTime = DateTime.Now;
                    Lbl_SolutionResults.Content = "Elapsed Time:" + finalizedTime.Subtract(startedTime).TotalSeconds.ToString() + " seconds." + Environment.NewLine + "Total Movements: " + IDFSsolution.Count.ToString();
                    txt_puzzle.Text = "";

                    if (IDFSsolution.Count > 0)
                    {
                        foreach (Node movement in IDFSsolution)
                        {
                            BoxA = movement.PrintPuzzle();
                            txt_puzzle.Text += BoxA;
                        }
                    }
                    else
                    {
                        Console.WriteLine("El camino a la solución no fue encontrado.");
                        txt_puzzle.Text = "El camino a la solución no fue encontrado.";
                    }
                    break;
                case "Greedy Best First Search":
                    startedTime = DateTime.Now;
                    Stack<Node> GBFSsolution = infS.GreedyFirstSearch(root);
                    finalizedTime = DateTime.Now;
                    Lbl_SolutionResults.Content = "Elapsed Time:" + finalizedTime.Subtract(startedTime).TotalSeconds.ToString() + " seconds." + Environment.NewLine + "Total Movements: " + GBFSsolution.Count.ToString();
                    txt_puzzle.Text = "";
                    
                    if (GBFSsolution.Count > 0)
                    {
                        foreach (Node movement in GBFSsolution)
                        {
                            BoxA = movement.PrintPuzzle();
                            txt_puzzle.Text += BoxA;
                        }
                    }
                    else
                    {
                        Console.WriteLine("El camino a la solución no fue encontrado.");
                        txt_puzzle.Text = "El camino a la solución no fue encontrado.";
                    }
                    break;
                case "A* Search":
                    startedTime = DateTime.Now;
                    Stack<Node> AStarSsolution = infS.AStarSearch(root);
                    finalizedTime = DateTime.Now;
                    Lbl_SolutionResults.Content = "Elapsed Time:" + finalizedTime.Subtract(startedTime).TotalSeconds.ToString() + " seconds." + Environment.NewLine + "Total Movements: " + AStarSsolution.Count.ToString();
                    txt_puzzle.Text = "";

                    if (AStarSsolution.Count > 0)
                    {
                        foreach (Node movement in AStarSsolution)
                        {
                            BoxA = movement.PrintPuzzle();
                            txt_puzzle.Text += BoxA;
                        }
                    }
                    else
                    {
                        Console.WriteLine("El camino a la solución no fue encontrado.");
                        txt_puzzle.Text = "El camino a la solución no fue encontrado.";
                    }
                    break;
                default:
                    MessageBox.Show("Not Supported Algorithm");
                    break;
            }
        }

        private void CBOX_Type_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            switch (CBOX_Type.SelectedValue)
            {
                case "Breadth First Search":
                    Lbl_SolutionOrder.Content = "Sorted From Solution to Problem";
                    break;
                case "Depth First Search":
                    Lbl_SolutionOrder.Content = "Sorted From Problem to Solution";
                    break;
                case "Iterative Depth First Search":
                    Lbl_SolutionOrder.Content = "Sorted From Problem to Solution";
                    break;
                case "Greedy Best First Search":
                    Lbl_SolutionOrder.Content = "Sorted From Problem to Solution";
                    break;
                case "A* Search":
                    Lbl_SolutionOrder.Content = "Sorted From Problem to Solution";
                    break;
                default:
                    MessageBox.Show("Not Supported Algorithm");
                    break;
            }
        }
    }
}
