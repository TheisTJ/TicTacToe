using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace TicTacToe
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private GameLogic Game { get; set; }
        public MainWindow()
        {
            Game = new GameLogic(); 
            InitializeComponent();
        }

        private void Label_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            Label label = (Label) sender;
            UniformGrid grid = (UniformGrid)label.Parent;

            int cols = grid.Columns;
            int rows = grid.Rows;
            
            int index = grid.Children.IndexOf(label);

            int col = index % cols;
            int row = index / cols;
            
            string token = Game.CurrentPlayer == Game.PlayerOne ? Game.PlayerOne.Name : Game.PlayerTwo.Name;
            Game.placeToken(col, row);

            label.Content = (token+"(" + col + "," + row + ")");

            if (Game.isFinished)
            {
                MessageBox.Show(Game.CurrentPlayer.Name + " WON!");
            }

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            resetGameBoard();
        }

        private void updateGrid()
        {
            UniformGrid grid = this.GameGrid;
            int cols = grid.Columns;
            foreach (Label label in grid.Children)
            {
                int index = grid.Children.IndexOf(label);

                int col = index % cols;
                int row = index / cols;

                if(Game.GameBoard[col,row] == null)
                {
                    label.Content = null;
                }
                else
                {
                    Player player = Game.GameBoard[col, row];
                    label.Content = ("Reset: " + player.Name + "(" + col + "," + row + ")");
                }
            }
        }
        private void resetGameBoard()
        {
            Game = new GameLogic();
            updateGrid();
        }
    }
}
