using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 콘솔슈팅_3차
{
    internal class Enermy
    {
        public int pos_x;
        public int pos_y;
        Random random = new Random();
        bool isDie;

        public int GetPosX() { return pos_x; }
        public int GetPosY() { return pos_y; }
        public void Awake()
        {
            pos_x = random.Next(1, 28);
            pos_y = 3;
            isDie = false;
        }

        public void Update()
        {
            this.pos_x += random.Next(-1, 2);
            this.pos_y = 3;
            if (pos_x == 0) { pos_x += random.Next(-1, 2); }
            if (pos_x <= 1)
            {
                pos_x = 1;
                pos_x += 1;
            }

            if (pos_x > 28)
            {
                pos_x = 28;
                pos_x -= 1;
            }
        }

        public void Render()
        {
            Console.SetCursorPosition(pos_x, pos_y); //커서값
            Console.ForegroundColor = ConsoleColor.Red; // 글씨 색상변경
            Console.WriteLine("E");
            Console.ResetColor();//글씨색상 초기화
        }
    }
}
