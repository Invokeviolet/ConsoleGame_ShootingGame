using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 콘솔슈팅_3차
{
    internal class Bullet
    {
        public int x;
        public int y;

        // bool 값 프로퍼티 선언
        public int GetPosX() { return x; }
        public int GetPosY() { return y; }

        public void SetPosX(int x) { this.x = x; } // 클래스에 있는 자기 자신을 지칭 -> this
        public void SetPosY(int y) { this.y = y; }

        //총알의 스위치 역할이 되어줌
        bool isAlive = false; 
        public bool GetAlive() { return isAlive; } // 프로퍼티 사용을 대신 해줄 수 있는 메서드 생성
        public void SetAlive(bool isalive) { isAlive = isalive; }
        public void Awake()
        {
            
        }
        public void Update()
        {
            if (isAlive == false) 
            {
                return;
            }
            --y;
            if (y<1) 
            {
                y = 1;
                isAlive = false;
            }
            
        }
        
        
        public void Render()
        {
            if (isAlive == true)
            {
                Console.SetCursorPosition(x, y);
                Console.ForegroundColor = ConsoleColor.Green;
                Console.Write("0");
                Console.ResetColor();
            }
            else 
            {
                return;
            }
            
        }
    }
}
