using System;
using System.Threading;
class Program
{
    static async Task Main(string[] args)
    {      
        Program Action = new Program();

        Console.WriteLine("0,0");
        Console.CursorVisible = false; // гасим курсор
        //Допуски на перемещение
        bool up = true, left = true, right = true, down = true;
        int x = 15, y = 15;
        int xPr = 15, yPr = 15;
        Action.Draw(x, y, ref up, ref left, ref right, ref down, true);
        //Console.SetCursorPosition(xPr, yPr);
        //Console.Write(" ");
        Console.SetCursorPosition(x, y);
        Console.Write("*");
        while (true)
        {
            Console.CursorVisible = false; // гасим курсор
            switch (Console.ReadKey().Key)
            {
                case ConsoleKey.UpArrow:
                    if (up)
                        //do
                        //{
                        //    y--;                            
                        //}
                        //while (y > 6);
                        y--;
                    break;
                case ConsoleKey.DownArrow:
                    if (down)
                        //do
                        //{
                        //    y++;
                        //}
                        //while (y < 19);
                        y++;
                    break;
                case ConsoleKey.LeftArrow:
                    if (left)
                        //do
                        //{
                        //    x--;
                        //}
                        //while (x > 11);
                        x--;
                    break;
                case ConsoleKey.RightArrow:
                    if (right)
                        //do
                        //{
                        //    x++;
                        //}
                        //while (x < 44);
                        x++;
                    break;
                case ConsoleKey.Escape:
                    return;
                default: break;
            }
            up = true; left = true; right = true; down = true;
            //Рисуем карту:            
            Action.Draw(x, y, ref up, ref left, ref right, ref down, false);
            //Запрет на преодоление границ ком.строки:
            if (x > 78) right = false;
            if (x < 1) left = false;
            if (y < 1) up = false;
            if (y > 23) down = false;
            //Выводим точку
            Console.SetCursorPosition(xPr, yPr);
            Console.Write(" ");   //Замена знака на пустоту, чтобы не было "следов"
            Console.SetCursorPosition(x, y);
            xPr = x; yPr = y;
            Console.Write("*");
            //await Task.Delay(100);
            Action.DisplayCurrentPosition(xPr, yPr);
        }
    }

    //Карта
    void Draw(int x, int y, ref bool up, ref bool left, ref bool right, ref bool down, bool canDraw)
    {
        DrawHLine(x, y, 10, 45, 5, ref up, ref down, canDraw);
        DrawVLine(x, y, 5, 16, 45, ref left, ref right, canDraw);
        DrawVLine(x, y, 17, 20, 45, ref left, ref right, canDraw);
        DrawHLine(x, y, 44, 45, 19, ref up, ref down, canDraw);
        DrawHLine(x, y, 10, 45, 20, ref up, ref down, canDraw);
        DrawVLine(x, y, 5, 15, 10, ref left, ref right, canDraw);
        DrawVLine(x, y, 17, 20, 10, ref left, ref right, canDraw);
    }

    //Горизонтальная
    void DrawHLine(int x, int y, int from, int to, int yLine,
                   ref bool up, ref bool down, bool canDraw)
    {
        for (int i = from; i <= to; i++)
        {
            if ((y - yLine == -1) && (x >= from) && (x <= to))
                down = false;
            if ((y - yLine == 1) && (x >= from) && (x <= to))
                up = false;
            Console.SetCursorPosition(i, yLine);
            if (canDraw) 
                Console.Write("#");
        }
    }
    //Вертикальная
    void DrawVLine(int x, int y, int from, int to, int xLine,
                   ref bool left, ref bool right, bool canDraw)
    {
        for (int i = from; i <= to; i++)
        {
            if ((x - xLine == -1) && (y >= from) && (y <= to))
                right = false;
            if ((x - xLine == 1) && (y >= from) && (y <= to))
                left = false;
            Console.SetCursorPosition(xLine, i);
            Console.Write("#");
        }
    }


    

    //Текущие координаты курсора
    void DisplayCurrentPosition(int x, int y)
    {
        Console.SetCursorPosition(0,0);        
        Console.WriteLine($"{x},{y}");
    }

}