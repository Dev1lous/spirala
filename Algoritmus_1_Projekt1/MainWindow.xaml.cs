using System.Reflection;
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

namespace Algoritmus_1_Projekt1
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

            int top = 0;
            int bottom = mapY - 1;
            int left = 0;
            int right = mapX - 1;
            bool jePrvni = false;
            while (top <= bottom && left <= right) // while loop funguje dokud se nepotkaji řady veprostřed (protože jinak bych vykresloval dál a možna by to ani nebyla spirála
            {

                // Horní řada (zleva doprava)
                if (jePrvni == true)
                {
                    for (int t = left - 1; t <= right; t++)
                    {
                        Border border = new Border();
                        border.Background = Brushes.Black;
                        Grid.SetColumn(border, t);
                        Grid.SetRow(border, top);
                        map.Children.Add(border);

                    }
                }
                else
                {
                    for (int t = left; t <= right; t++)
                    {
                        Border border = new Border();
                        border.Background = Brushes.Black;
                        Grid.SetColumn(border, t);
                        Grid.SetRow(border, top);
                        map.Children.Add(border);

                    }
                }
                jePrvni = true;
                top += 2;



                // pravá strana (zhora dolu)
                for (int r = top - 1; r <= bottom; r++)
                {
                    Border border = new Border();
                    border.Background = Brushes.Black;
                    Grid.SetColumn(border, right);
                    Grid.SetRow(border, r);
                    map.Children.Add(border);
                }
                right -= 2;

                // dolni strana (zprava doleva)
                for (int b = right + 1; b >= left; b--)
                {
                    Border border = new Border();
                    border.Background = Brushes.Black;
                    Grid.SetColumn(border, b);
                    Grid.SetRow(border, bottom);
                    map.Children.Add(border);
                }
                bottom -= 2;  // pohne to dolní stranu o 2 blocky nahoru protoze tam musi byt mezera tak proto2


                // Levá strana (zdola nahoru)
                for (int l = bottom + 1; l >= top; l--)
                {
                    Border border = new Border();
                    border.Background = Brushes.Black;
                    Grid.SetColumn(border, left);
                    Grid.SetRow(border, l);
                    map.Children.Add(border);
                }
                left += 2;  // zase klasik pohne to levou stranu o 2 blocky (protože 1 block musí být mezera, to je převelice sigma)
            }
        }
    }
}