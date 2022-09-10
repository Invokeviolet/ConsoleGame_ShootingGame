using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 콘솔슈팅_3차
{
    internal class Player
    {
        public int pos_x;
        public int pos_y;
        int dir;

        public int GetPosX() { return pos_x; }
        public int GetPosY() { return pos_y; }
        public void SetPosX(int x) { this.pos_x = x; } // 클래스에 있는 자기 자신을 지칭 -> this
        public void SetPosY(int y) { this.pos_y = y; }
        public void Awake()
        {
            pos_x = 14;
            pos_y = 39;

        }
        public void Start()
        {

        }

        public void RightArrow()
        {
            ++pos_x;
            if (pos_x >= 28) pos_x = 28;
        }
        public void LeftArrow()
        {
            --pos_x;
            if (pos_x <= 1) pos_x = 1;
        }

        public void Render() //커서 위치 생각좀
        {
            Console.Clear();
            Console.SetCursorPosition(pos_x, pos_y);
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("P");
            Console.ResetColor();
        }
    }
}
