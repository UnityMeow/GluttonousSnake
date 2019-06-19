using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace GluttonousSnake
{
    //开始场景
    class CStartScene : CScene
    {
        int m_icon;
        CGameOutput go;
        int m_x;
        int m_y;
        int m_dir;
        string m_id;
        public override void Init()
        {
            m_icon = 1;
            GameState = 1;
            go = new CGameOutput(35, 15);
            //设置图素
            go.SetPixel("　¤●○开始游戏皮排行");
            //创建图片
            CBmp bmp1 = new CBmp();
            CBmp bmp2 = new CBmp();
            CBmp bmp3 = new CBmp();
            CBmp bmp4 = new CBmp();
            //设置图片数据
            bmp1.SetBmpData(5, 1, 1, 2, 3, 2, 3);
            bmp2.SetBmpData(5, 1, 3, 2, 3, 2, 1);
            bmp3.SetBmpData(4, 1, 4, 5, 6, 7);
            bmp4.SetBmpData(4, 1, 8, 8, 9, 10);
            //加载图片
            go.LoadBmp("头左", bmp1);
            go.LoadBmp("头右", bmp2);
            go.LoadBmp("开始", bmp3);
            go.LoadBmp("排行", bmp4);
            m_x = 2;
            m_y = 7;
            m_dir = 1;
            m_id = "头右";
            GameState = 2;
        }
        public override void Run()
        {
            go.Begin(0);
            go.DrawBmp(m_id, m_x, m_y);
            go.DrawBmp("开始", 14, 9);
            go.DrawBmp("排行", 14, 11);
            go.End();
            if (m_x + 5 > go.GetClientW() - 1)
            {
                m_id = "头左";
                m_dir = -1;
            }
            else if (m_x < 1)
            {
                m_id = "头右";
                m_dir = 1;
            }
            m_x += m_dir;
            Console.SetCursorPosition(11 * 2, 5);
            Console.Write("哦呦！这不是蛇皮皮嘛！");
            if (m_icon == 1)
            {
                CCommon.ColorBlack();
                Console.SetCursorPosition(14 * 2, 9);
                Console.Write("开始游戏");
            }
            if (m_icon == 2)
            {
                CCommon.ColorBlack();
                Console.SetCursorPosition(14 * 2, 11);
                Console.Write("皮皮排行");
            }
            CCommon.ColorWhite();
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
                            if (m_icon == 2)
                                m_icon = 1;
                        }
                        break;
                    case 's':
                        {
                            if (m_icon == 1)
                                m_icon = 2;
                        }
                        break;
                    case ' ':
                        {
                            GameState = 3;
                        }
                        break;
                }

            }
            Thread.Sleep(60);
        }
        public override void End()
        {
            if (m_icon == 1)
                CCommon.GameScene = new CRunScene();
            if (m_icon == 2)
                CCommon.GameScene = new CRankScene();
        }
    }
}
