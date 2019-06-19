using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GluttonousSnake
{
    //英雄类
    class CHero
    {
        //身体
        struct _BODY
        {
            public int x;
            public int y;
        }
        //英雄姓名
        string m_Name;
        //英雄dir
        int m_dir;
        //身体长度
        int m_BodyLen;
        //身体链表
        CGameObjMgr<_BODY> m_BodyList;
        //物体插件
        CGameObject m_entity;
        //初始化英雄数据
        public CHero(string name, int x, int y)
        {
            m_Name = name;
            m_BodyLen = 0;
            m_dir = 0;
            m_entity = new CGameObject(x, y);
            m_BodyList = new CGameObjMgr<_BODY>();
        }
        //英雄移动
        public void Move()
        {
            switch (m_dir)
            {
                case 1: this.m_entity.Run(1); break;
                case 2: this.m_entity.Run(2); break;
                case 3: this.m_entity.Run(3); break;
                case 4: this.m_entity.Run(4); break;
            }
        }
        //添加英雄身体
        public void PushBody(int x, int y)
        {
            _BODY tmp = new _BODY();
            tmp.x = x;
            tmp.y = y;
            m_BodyList.LoadObj(m_BodyLen, tmp);
            m_BodyLen++;
        }
        //获取身体长度
        public int GetBodyLen()
        {
            return m_BodyLen;
        }
        //修改身体x
        public void SetBodyX(int id, int x)
        {
            //安全检测
            if (id > m_BodyLen)
                return;
            _BODY tmp = new _BODY();
            tmp.x = x;
            tmp.y = GetBodyY(id);
            m_BodyList.SetObj(id, tmp);
        }
        //修改身体y
        public void SetBodyY(int id, int y)
        {
            //安全检测
            if (id > m_BodyLen)
                return;
            _BODY tmp = new _BODY();
            tmp.y = y;
            tmp.x = GetBodyX(id);
            m_BodyList.SetObj(id, tmp);
        }
        //获取身体x
        public int GetBodyX(int id)
        {
            //安全检测
            if (id > m_BodyLen)
                return -1;
            return m_BodyList.GetObject(id).x;
        }
        //获取身体y
        public int GetBodyY(int id)
        {
            //安全检测
            if (id > m_BodyLen)
                return -1;
            //_BODY tmp = new _BODY();
            //m_BodyList.GetObject(id, tmp);
            //return tmp.y;
            return m_BodyList.GetObject(id).y;
        }
        //获取英雄x
        public int GetX()
        {
            return m_entity.GetX();
        }
        //获取英雄y
        public int GetY()
        {
            return m_entity.GetY();
        }
        //获取英雄方向
        public int GetDir()
        {
            return m_dir;
        }
        //设置英雄方向
        public void SetDir(int dir)
        {
            m_dir = dir;
        }
    }
}
