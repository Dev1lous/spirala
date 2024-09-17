# Spirály

## Logika
- Vykreslím horní řadu a poté ji posunu o 2 místa dolu, poté vykreslím pravou řadu a posunu o 2 místa doleva..
- To stejné udělam u dalších řad a posunuju je dokud muj while loop neskončí, skončí poté co se třeba pravá řada a levá setkají a jdou tam kde už jedna z těch stran byla.
- Nevýhoda kódu jé že to funguje jen na čtverce, to nevadí.
## Kód bez rekurze
```cs
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
```
- Tenhle kód nastavuje rozměr gridu a uděla grid mapu.
```cs
   int top = 0;
            int bottom = mapY - 1;
            int left = 0;
            int right = mapX - 1;
            bool jePrvni = false;
```
- Tady si nastavuju hodnoty pro horni, dolni, levou a pravou řadu.
```cs
  while (top <= bottom && left <= right)
```
- While loop funguje tak že jednodušše vysvětleno veprostřed se loop zastaví protože se ty řady potkají.

```cs
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



                for (int r = top - 1; r <= bottom; r++)
                {
                    Border border = new Border();
                    border.Background = Brushes.Black;
                    Grid.SetColumn(border, right);
                    Grid.SetRow(border, r);
                    map.Children.Add(border);
                }
                right -= 2;


                for (int b = right + 1; b >= left; b--)
                {
                    Border border = new Border();
                    border.Background = Brushes.Black;
                    Grid.SetColumn(border, b);
                    Grid.SetRow(border, bottom);
                    map.Children.Add(border);
                }
                bottom -= 2;  


                for (int l = bottom + 1; l >= top; l--)
                {
                    Border border = new Border();
                    border.Background = Brushes.Black;
                    Grid.SetColumn(border, left);
                    Grid.SetRow(border, l);
                    map.Children.Add(border);
                }
                left += 2;  
```
- U horní řady mam if statement a pokud je true tak spustím for loop, kdybych to nechal bez toho if statementu a toho for loopu v tom statementu tak mi to nevykreslí začáteční block.
- For loop kde podle toho kam ty blocky posílám tak udělám for loop, v for loopu je kód na vykreslování a poté posunu tu určitou řadu/sloupec o 2 blocky.

## Kód rekurzní
```cs
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
```
- Tady zase dělám grid a volám metodu ```DrawSpiral```
```cs
        private void AddBlock(Grid map, int row, int col)
        {
            Border border = new Border();
            border.Background = Brushes.Black;
            Grid.SetRow(border, row);
            Grid.SetColumn(border, col);
            map.Children.Add(border);
        }
```
- Zde mam metodu na vykreslení jednotlivých blocků
```cs
 private void DrawSpiral(Grid map, int top, int bottom, int left, int right, bool isFirst)
        {
            if (top > bottom || left > right) 
                return;


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


            for (int r = top - 1; r <= bottom; r++)
            {
                AddBlock(map, r, right);
            }
            right -= 2;


            for (int b = right + 1; b >= left; b--)
            {
                AddBlock(map, bottom, b);
            }
            bottom -= 2;


            for (int l = bottom + 1; l >= top; l--)
            {
                AddBlock(map, l, left);
            }
            left += 2;


            DrawSpiral(map, top, bottom, left, right, isFirst);
        }        
    }
}
```
- Celá metoda funguje uplně stejně jak bez rekurze akorát zde to vykresluji ```AddBlock``` metodou a na konci volám metodu ```DrawSpiral``` a zase se to opakuje dokud muj while loop neskončí.
