using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace GluttonousSnake
{
    //结束场景
    class COverScene : CScene
    {
        string m_path;
        byte[] m_rdata;
        int m_icon;
        bool on;
        bool win;
        int num;
        public override void Init()
        {
            win = false;
            on = true;
            m_icon = 1;
            num = 0;
            m_rdata = new byte[8];
            m_path = "..\\..\\rank.data";
            //安全检测
            if (!File.Exists(m_path))
                return;
            GameState = 2;
        }
        public override void Run()
        {
            CCommon.ColorWhite();
            //打开文件
            FileStream stream = new FileStream(m_path, FileMode.OpenOrCreate);
            //移动指针位置
            stream.Seek(0, SeekOrigin.Begin);
            //读取文件信息
            stream.Read(m_rdata, 0, m_rdata.Length);
            //关闭文件
            stream.Close();


            Console.SetCursorPosition(13 * 2, 3);
            Console.Write("游戏结束！总得分:{0}", CCommon.Score * 5);

            if (on)
            {
                if ((byte)CCommon.Score >= m_rdata[m_rdata.Length - 1])
                {
                    m_rdata[m_rdata.Length - 1] = (byte)CCommon.Score;
                    win = true;
                }

                for (int i = m_rdata.Length - 1; i > 0;)
                {

                    if (m_rdata[i] > m_rdata[i - 1])
                    {
                        byte bTmp = m_rdata[i];
                        m_rdata[i] = m_rdata[i - 1];
                        m_rdata[i - 1] = bTmp;
                    }
                    i--;
                    if (m_rdata[i] == (byte)CCommon.Score)
                        num = i + 1;
                }
                on = false;
                //for (int i = 0; i < 8; i++)
                //{
                //    m_rdata[i] = 1;
                //}
                FileStream stream1 = new FileStream(m_path, FileMode.OpenOrCreate);
                //移动指针位置
                stream1.Seek(0, SeekOrigin.Begin);
                //读取文件信息
                stream1.Write(m_rdata, 0, 8);
                //关闭文件
                stream1.Close();
            }
            if (win)
            {
                Console.SetCursorPosition(8 * 2, 5);
                Console.Write("大兄弟厉害呀！成功登上皮皮排行榜第{0}名！", num);
            }
            else
            {
                Console.SetCursorPosition(7 * 2, 5);
                Console.Write("你是手残吗！连我蛇皮皮的排行榜都上不去！丢人！");
            }
            if (m_icon == 1)
                CCommon.ColorBlack();
            else
                CCommon.ColorWhite();
            Console.SetCursorPosition(10 * 2, 8);
            Console.Write("天生傲骨怎能服输！再来一局！");
            if (m_icon == 2)
                CCommon.ColorBlack();
            else
                CCommon.ColorWhite();
            Console.SetCursorPosition(12 * 2, 9);
            Console.Write("认怂！认怂！不玩了！");
            if (m_icon == 3)
                CCommon.ColorBlack();
            else
                CCommon.ColorWhite();
            Console.SetCursorPosition(12 * 2, 10);
            Console.Write("返回蛇皮皮的主菜单");
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
                            else if (m_icon == 3)
                                m_icon = 2;
                        }
                        break;
                    case 's':
                        {
                            if (m_icon == 1)
                                m_icon = 2;
                            else if (m_icon == 2)
                                m_icon = 3;
                        }
                        break;
                    case ' ':
                        {
                            GameState = 3;
                        }
                        break;
                }

            }
            Thread.Sleep(100);

        }
        public override void End()
        {
            switch (m_icon)
            {
                case 1: CCommon.GameScene = new CRunScene(); break;
                case 2: GameState = -1; return;
                case 3: CCommon.GameScene = new CStartScene(); break;
            }
        }
    }
}
