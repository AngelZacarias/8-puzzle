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
        int[,] arrPuzzle = new int[3,3];
        //Coordenates to analize how the empty space moves
        int xEmpty;
        int yEmpty;

        public MainWindow()
        {
            InitializeComponent();
        }

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
            //This will be used to manage the different kind of algorithms it can be selected by the user
            int nAlgorithmType = 1;
            //Fills the array and x,y for the empty space
            if (txt_1.Text == "")
            {
                xEmpty = 0;
                yEmpty = 0;
            }
            else
            {
                arrPuzzle[0, 0] = Convert.ToInt32(txt_1.Text);
            }
            if (txt_2.Text == "")
            {
                xEmpty = 1;
                yEmpty = 0;
            }
            else
            {
                arrPuzzle[0, 1] = Convert.ToInt32(txt_2.Text);
            }
            if (txt_3.Text == "")
            {
                xEmpty = 0;
                yEmpty = 2;
            }
            else
            {
                arrPuzzle[0, 2] = Convert.ToInt32(txt_3.Text);
            }
            if (txt_4.Text == "")
            {
                xEmpty = 1;
                yEmpty = 0;
            }
            else
            {
                arrPuzzle[1, 0] = Convert.ToInt32(txt_4.Text);
            }
            if (txt_5.Text == "")
            {
                xEmpty = 1;
                yEmpty = 1;
            }
            else
            {
                arrPuzzle[1, 1] = Convert.ToInt32(txt_5.Text);
            }
            if (txt_6.Text == "")
            {
                xEmpty = 1;
                yEmpty = 2;
            }
            else
            {
                arrPuzzle[1, 2] = Convert.ToInt32(txt_6.Text);
            }
            if (txt_7.Text == "")
            {
                xEmpty = 2;
                yEmpty = 0;
            }
            else
            {
                arrPuzzle[2, 0] = Convert.ToInt32(txt_7.Text);
            }
            if (txt_8.Text == "")
            {
                xEmpty = 2;
                yEmpty = 1;
            }
            else
            {
                arrPuzzle[2, 1] = Convert.ToInt32(txt_8.Text);
            }
            if (txt_9.Text == "")
            {
                xEmpty = 2;
                yEmpty = 2;
            }
            else
            {
                arrPuzzle[2, 2] = Convert.ToInt32(txt_9.Text);
            }

            switch (nAlgorithmType)
            {
                case 1://Width-first
                    solveBreadthFirst();
                    break;
                case 2://Width-first
                    solveDepthFirst();
                    break;
                default:
                    MessageBox.Show("Please select a valid option as algorithm", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                    break;
            }
            
            //Shows the finished puzzle
            txt_1.Text = "1";
            txt_2.Text = "2";
            txt_3.Text = "3";
            txt_4.Text = "4";
            txt_5.Text = "5";
            txt_6.Text = "6";
            txt_7.Text = "7";
            txt_8.Text = "8";
            txt_9.Text = "";
        }

        bool isCompleted()
        {
            bool bResult = true;
            bResult = bResult && arrPuzzle[0, 0] == 1;
            bResult = bResult && arrPuzzle[0, 1] == 2;
            bResult = bResult && arrPuzzle[0, 2] == 3;
            bResult = bResult && arrPuzzle[1, 0] == 4;
            bResult = bResult && arrPuzzle[1, 1] == 5;
            bResult = bResult && arrPuzzle[1, 2] == 6;
            bResult = bResult && arrPuzzle[2, 0] == 7;
            bResult = bResult && arrPuzzle[2, 1] == 8;
            //Nine is empty
            bResult = bResult && xEmpty == 2 && yEmpty == 2;
            return bResult;
        }

        void solveBreadthFirst()
        {
            while (!isCompleted())
            {

            }
        }

        void solveDepthFirst()
        {
            while (!isCompleted())
            {

            }
        }
    }
}
