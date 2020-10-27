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
            UniformedSearch ui = new UniformedSearch();

            List<Node> solution = ui.BreadFirstSearch(root);
            txt_puzzle.Text = "";

            if (solution.Count > 0)
            {
                for (int i = 0; i < solution.Count; i++)
                {
                    BoxA = solution[i].PrintPuzzle();
                    txt_puzzle.Text += BoxA;
                }
            }
            else
            {
                Console.WriteLine("El camino a la solución no fue encontrado.");
                txt_puzzle.Text = "El camino a la solución no fue encontrado.";
            }
        }
    }
}
