using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Algoritmus_1_Rekurzne_Spirala
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            
            int mapX = 10;
            int mapY = 10;
            Grid map = new Grid();

            for (int x = 0; x < mapX; x++)
            {
                map.RowDefinitions.Add(new RowDefinition());
                map.ColumnDefinitions.Add(new ColumnDefinition());
            }

            for (int row = 0; row < mapX; row++)
            {
                for (int col = 0; col < mapY; col++)
                {
                    Border border = new Border();
                    border.BorderBrush = Brushes.Black;
                    border.BorderThickness = new Thickness(1);

                    Grid.SetRow(border, row);
                    Grid.SetColumn(border, col);
                    map.Children.Add(border);
                }
            }

            this.Content = map;

            DrawSpiral(map, 0, mapY - 1, 0, mapX - 1, false);
        }

        private void AddBlock(Grid map, int row, int col) // na pridani blocku v řadě
        {
            Border border = new Border();
            border.Background = Brushes.Black;
            Grid.SetRow(border, row);
            Grid.SetColumn(border, col);
            map.Children.Add(border);
        }

        private void DrawSpiral(Grid map, int top, int bottom, int left, int right, bool isFirst)
        {
            if (top > bottom || left > right) // kontrola abych nekreslil někam kam bych neměl (veprostřed se to ukonči)
                return;

            // Horní řada (zleva doprava)
            if (isFirst)
            {
                for (int t = left - 1; t <= right; t++)
                {
                    AddBlock(map, top, t);
                }
            }
            else
            {
                for (int t = left; t <= right; t++)
                {
                    AddBlock(map, top, t);
                }
            }
            isFirst = true;
            top += 2;

            // Pravá řada (zhora dolu)
            for (int r = top - 1; r <= bottom; r++)
            {
                AddBlock(map, r, right);
            }
            right -= 2;

            // dolní (zpravadoleva)
            for (int b = right + 1; b >= left; b--)
            {
                AddBlock(map, bottom, b);
            }
            bottom -= 2;

            // Llevá řada (zdola nahoru)
            for (int l = bottom + 1; l >= top; l--)
            {
                AddBlock(map, l, left);
            }
            left += 2;

            // tady volam metodu a spusti znovu
            DrawSpiral(map, top, bottom, left, right, isFirst);
        }        
    }
}