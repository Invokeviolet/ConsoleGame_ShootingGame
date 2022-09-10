using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace 콘솔슈팅_3차
{
    internal class GameLoop
    {
        Player player;
        Enermy enermy;
        Bullet[] bullet; // 배열로 선언

        //시간계산
        int curTime;
        int oldTime = 0;
        int Score = 0;

        bool isNeedRefresh = false;

        Random random = new Random();
        public void Init()
        {
            Console.BufferHeight = Console.WindowHeight = 40;
            Console.BufferWidth = Console.WindowWidth = 30;
            Console.CursorVisible = false;
        }
        public void Awake()
        {
            player = new Player();
            player.Awake(); // 플레이어 초기 위치
            enermy = new Enermy();
            enermy.Awake(); // 적 초기 위치
            bullet = new Bullet[10];

            for (int i = 0; i < bullet.Length; i++) // 총알 초기 위치
            {
                bullet[i] = new Bullet();
                bullet[i].x = player.pos_x;
                bullet[i].y = player.pos_y;
                bullet[i].SetAlive(false);
            }

        }
        public void Start()
        {

        }
        public void Update()
        {
            //충돌체크
            for (int i = 0; i < bullet.Length; i++)
            {
                if (bullet[i].GetPosX() == enermy.GetPosX() && bullet[i].GetPosY() == enermy.GetPosY())
                {
                    //1.총알이 삭제 되어야 함
                    bullet[i].SetAlive(false);

                    //2.적도 삭제
                    enermy.Awake(); // 새로운 곳에 재생성

                    //3.점수 증가
                    Score += 100;
                }

            }

            int curTime = System.Environment.TickCount & Int32.MaxValue;            
            if (curTime - oldTime > 1000 / 10)
            {
                oldTime = curTime;

                //적 이동
                enermy.Update();
                if (player.pos_x==enermy.pos_x)
                {
                    enermy.pos_x += random.Next(-2, 2); // 플레이어의 x 값과 겹치지 않게 하기 위함
                }

                //총알 이동
                for (int i = 0; i < bullet.Length; i++)
                {
                    bullet[i].Update();
                }    
                
                isNeedRefresh = true;
            }
            //Thread.Sleep(100);

            for (int i = 0; i < bullet.Length; i++) //for문을 밖에서 돌려야 하는 이유?
            {
                //플레이어 이동
                if (Console.KeyAvailable)
                {
                    ConsoleKeyInfo Key = Console.ReadKey();

                    switch (Key.Key)
                    {
                        case ConsoleKey.RightArrow:
                            player.RightArrow();
                            break;

                        case ConsoleKey.LeftArrow:
                            player.LeftArrow();
                            break;

                        case ConsoleKey.Spacebar: // 스페이바를 누르면 총알 활성화
                            {

                                if (bullet[i].GetAlive() == false)
                                {
                                    bullet[i].SetPosX(player.GetPosX());
                                    bullet[i].SetPosY(player.GetPosY());
                                    bullet[i].SetAlive(true);
                                }
                            }
                            break;

                    }

                }

            }

        }
        public void Render()
        {
            if (isNeedRefresh == false)
            {
                return;
            }
            else
            {
                player.Render();
                enermy.Render();
                Console.SetCursorPosition(1, 1);
                Console.ForegroundColor = ConsoleColor.DarkGray;
                Console.Write($"Score : {Score}");
                Console.ResetColor();

                for (int i = 0; i < bullet.Length; i++)
                {
                    bullet[i].Render();

                }
                isNeedRefresh = false;

            }

        }
    }
}
