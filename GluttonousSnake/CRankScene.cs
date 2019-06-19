using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace GluttonousSnake
{
    //榜单场景
    class CRankScene : CScene
    {
        string m_path;
        byte[] m_rdata;
        public override void Init()
        {
            m_rdata = new byte[8];
            m_path = "..\\..\\rank.data";
            //安全检测
            if (!File.Exists(m_path))
                return;
            GameState = 2;
            Console.Clear();
        }
        public override void Run()
        {
            //打开文件
            FileStream stream = new FileStream(m_path, FileMode.Open);
            //移动指针位置
            stream.Seek(0, SeekOrigin.Begin);
            //读取文件信息
            stream.Read(m_rdata, 0, m_rdata.Length);
            //关闭文件
            stream.Close();
            CCommon.ColorWhite();
            Console.SetCursorPosition(10 * 2, 2);
            Console.Write(" 嘿！这里是蛇皮皮的排行榜哦~");
            for (int i = 0; i < 8; i++)
            {

                Console.SetCursorPosition(12 * 2, i + 4);
                Console.Write("第{0}名   \t{1}分", i + 1, ((int)m_rdata[i]) * 5);
            }
            CCommon.ColorBlack();
            Console.SetCursorPosition(15 * 2, 13);
            Console.Write("空格键返回");
            while (Console.KeyAvailable)
            {
                //按键
                char input = new char();
                ConsoleKeyInfo c = Console.ReadKey(true);
                input = c.KeyChar;
                if (input == ' ')
                {
                    GameState = 3;
                }
            }
            Thread.Sleep(100);
        }
        public override void End()
        {
            CCommon.GameScene = new CStartScene();
        }
    }
}
