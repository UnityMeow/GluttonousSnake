using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace GluttonousSnake
{
    //游戏场景
    class CRunScene : CScene
    {
        //创建英雄
        CHero snake;
        int foodx;
        int foody;
        bool food_b;
        int speed;

        //创建画布
        CGameOutput go;
        public override void Init()
        {
            speed = 180;
            CCommon.Score = 0;
            snake = new CHero("snake", 2, 3);
            foodx = 8;
            foody = 8;
            food_b = false;
            go = new CGameOutput(35, 15);
            //设置图素
            go.SetPixel("　◆¤●★○▼▲");
            //创建图片
            CBmp bmp1 = new CBmp();
            CBmp bmp2 = new CBmp();
            CBmp bmp3 = new CBmp();
            CBmp bmp4 = new CBmp();
            //设置图片数据
            bmp1.SetBmpData(1, 1, 2);
            bmp2.SetBmpData(1, 1, 3);
            bmp3.SetBmpData(1, 1, 4);
            bmp4.SetBmpData(1, 1, 5);
            //加载图片
            go.LoadBmp("头", bmp1);
            go.LoadBmp("身1", bmp2);
            go.LoadBmp("星", bmp3);
            go.LoadBmp("身2", bmp4);
            //游戏运行
            GameState = 2;
            Console.Clear();
        }
        public override void Run()
        {
            //初始化画布
            go.Begin(1);
            CCommon.ColorWhite();
            //随机食物
            if (food_b)
            {
                Random r = new Random();
                foodx = r.Next(1, go.GetClientW() - 1);
                foody = r.Next(1, go.GetClientH() - 1);
            }
            if (snake.GetX() == foodx && snake.GetY() == foody)
            {
                food_b = true;
                snake.PushBody(snake.GetX(), snake.GetY());
                CCommon.Score++;
            }
            else
                food_b = false;
            //导入图片
            go.DrawBmp("星", foodx, foody);
            Console.SetCursorPosition(foodx * 2, foody);
            Console.Write("☆");
            go.DrawBmp("头", snake.GetX(), snake.GetY());
            for (int i = 0; i < snake.GetBodyLen(); ++i)
            {
                if (i % 2 == 0)
                    go.DrawBmp("身1", snake.GetBodyX(i), snake.GetBodyY(i));
                else if (i % 2 == 1)
                    go.DrawBmp("身2", snake.GetBodyX(i), snake.GetBodyY(i));
            }
            //绘制
            go.End();
            //修改蛇身位置
            for (int i = snake.GetBodyLen() - 1; i >= 0; --i)
            {
                snake.SetBodyX(i, snake.GetBodyX(i - 1));
                snake.SetBodyY(i, snake.GetBodyY(i - 1));
            }
            if (snake.GetBodyLen() != 0)
            {
                snake.SetBodyX(0, snake.GetX());
                snake.SetBodyY(0, snake.GetY());
            }
            switch (CCommon.Score)
            {
                case 3: speed = 150; break;
                case 5: speed = 120; break;
                case 7: speed = 90; break;
                case 9: speed = 75; break;
                case 12: speed = 60; break;
                case 20: speed = 30; break;
                case 30: speed = 15; break;

            }

            while (Console.KeyAvailable)
            {
                //按键
                char input = new char();
                ConsoleKeyInfo c = Console.ReadKey(true);
                input = c.KeyChar;
                switch (input)
                {
                    case 'w':
                        {
                            if (snake.GetDir() != 2 || snake.GetBodyLen() == 0)
                                snake.SetDir(1);
                        }
                        break;
                    case 's':
                        {
                            if (snake.GetDir() != 1 || snake.GetBodyLen() == 0)
                                snake.SetDir(2);
                        }
                        break;
                    case 'a':
                        {
                            if (snake.GetDir() != 4 || snake.GetBodyLen() == 0)
                                snake.SetDir(3);
                        }
                        break;
                    case 'd':
                        {
                            if (snake.GetDir() != 3 || snake.GetBodyLen() == 0)
                                snake.SetDir(4);
                        }
                        break;
                }
            }
            //自动移动
            snake.Move();
            //游戏结束
            if (snake.GetX() > go.GetClientW() - 2
                || snake.GetY() > go.GetClientH() - 2
                || snake.GetX() < 1
                || snake.GetY() < 1)
                GameState = 3;
            for (int i = 0; i < snake.GetBodyLen(); ++i)
            {
                if (snake.GetX() == snake.GetBodyX(i) && snake.GetY() == snake.GetBodyY(i))
                    GameState = 3;
            }
            Thread.Sleep(speed);
        }
        public override void End()
        {
            CCommon.GameScene = new COverScene();
        }

    }
}
