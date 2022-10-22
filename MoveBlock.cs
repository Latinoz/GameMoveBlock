using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameBlock
{
    public class MoveBlock
    {

        int x = 15;
        int y = 15;
        ConsoleKeyInfo k;

        public void Doing()
        {
            Console.CursorVisible = false; // гасим курсор

            do
            {
                Console.SetCursorPosition(x, y);
                Console.Write((char)1);
                k = Console.ReadKey(true);

                if (k.Key == ConsoleKey.UpArrow)
                    y--;
                else if (k.Key == ConsoleKey.DownArrow)
                    y++;
                else if (k.Key == ConsoleKey.LeftArrow)
                    x--;
                else if (k.Key == ConsoleKey.RightArrow)
                    x++;

                Console.Clear();
            }
            while (k.Key != ConsoleKey.Escape); // выходим из цикла по нажатию Esc
        }
    }
}
