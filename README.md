# GluttonousSnake
### 项目说明  
- 入口脚本  
	主入口 -> Program.cs  
- 场景相关  
	场景基类 -> CScene.cs  
	开始场景 -> CStartScene.cs  
	游戏场景 -> CRunScene.cs  
	榜单场景 -> CRankScene.cs  
	结束场景 -> COverScene.cs  
- 绘制相关  
	图片类 -> CBmp.cs  
	绘制类 -> CGameOutput.cs  
- 物体相关  
	物体类 -> CGameObject.cs  
	物体管理 -> CGameObjMgr.cs  
- 英雄相关  
	英雄类 -> CHero.cs  
- 公共类  
	公用静态类 -> CCommon.cs  
- 数据相关  
	数据文件 -> rank.data  
### 游戏说明  
- 操作相关  
	回车键确认选项  
	键盘'a' 's' 'd' 'w'控制移动  
- 游戏规则  
	吃到星星可增加蛇身长度  
	蛇身达到一定长度速度会增加  
	蛇头碰到蛇身或碰到墙壁游戏结束   
- 榜单规则  
	分数高于历史榜单记录则可记录上榜  