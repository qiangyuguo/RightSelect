using System;
using System.Data;
using System.Web;
using System.Collections.Generic;
using Com.Data;
using Com.ZY.JXKK.Util;
using Com.ZY.JXKK.DAO;
using Com.ZY.JXKK.DAO.Set;
using Com.ZY.JXKK.Model;

namespace Com.ZY.JXKK.BLL.Set
{
    /// <summary>
    /// 游戏类型
    /// Author:代码生成器
    /// </summary>
    public class GameBLL
    {
        private HttpContext context;//HTTP请求上下文
        private ILogin loginSession;//登录对象信息
        private CommonDao commonDao = new CommonDao();
        private TBGameDAO tbGameDAO= new TBGameDAO();
        
        /// <summary>
        /// 类构造方法
        /// <param name="context">HTTP请求上下文</param>
        /// <param name="loginSession">登录对象信息</param>
        /// </summary>
        public GameBLL(HttpContext context, ILogin loginSession)
        {
            this.context = context;
            this.loginSession = loginSession;
        }
        
        /// <summary>
        /// 加载DataGrid
        /// <param name="page">查询页数</param>
        /// <param name="rows">每页记录数</param>
        /// </summary>
        public void LoadGrid(int page, int rows)
        {
            string strSQL = "select * from TBGame";
            string str = commonDao.DataGrid(strSQL, null, page, rows);
            WebJson.Write(context, str);
        }
        
        /// <summary>
        /// 加载指定游戏类型
        /// <param name="gameId">游戏编号</param>
        /// </summary>
        public void Load(string gameId)
        {
            try
            {
                TBGame tbGame=tbGameDAO.Get(gameId);
                WebJson.ToJson(context, tbGame);
            }
            catch (Exception e)
            {
                Message.error(context, e.Message);
            }
        }
        /// <summary>
        /// 获取指定游戏信息
        /// <param name="areaId">区域编号</param>
        /// </summary>
        public TBGame Get(string gameId)
        {
            TBGame tbGame = new TBGame();
            try
            {
                tbGame = tbGameDAO.Get(gameId);
            }
            catch (Exception e)
            {
                Message.error(context, e.Message);
            }
            return tbGame;
        }
        /// <summary>
        /// 增加游戏类型
        /// <param name="tbGame">游戏类型</param>
        /// </summary>
        public void Add(TBGame tbGame)
        {
            try
            {
                tbGameDAO.Add(tbGame);
                Message.success(context, "游戏类型增加成功");
                loginSession.Log("XXXXXX游戏类型增加成功");
            }
            catch (Exception e)
            {
                Message.error(context, "游戏类型增加失败");
                loginSession.Log(e.Message);
            }
        }
        
        /// <summary>
        /// 修改游戏类型
        /// <param name="tbGame">游戏类型</param>
        /// </summary>
        public void Edit(TBGame tbGame)
        {
            try
            {
                tbGameDAO.Edit(tbGame);
                Message.success(context, "游戏类型修改成功");
                loginSession.Log("XXXXXX游戏类型修改成功");
            }
            catch (Exception e)
            {
                Message.error(context, "游戏类型修改失败");
                loginSession.Log(e.Message);
            }
        }
        
        /// <summary>
        /// 删除游戏类型
        /// <param name="gameId">游戏编号</param>
        /// </summary>
        public void Delete(string gameId)
        {
            try
            {
                tbGameDAO.Delete(gameId);
                Message.success(context, "游戏类型删除成功");
                loginSession.Log("XXXXXX游戏类型删除成功");
            }
            catch (Exception e)
            {
                Message.error(context, "游戏类型删除失败");
                loginSession.Log(e.Message);
            }
        }

       
        /// <summary>
        /// 获取DataSet(游戏类型)
        /// <param name="strSQL">查询语句</param>
        /// <param name="param">查询参数</param>
        /// </summary>
        /// <returns>游戏类型DataSet</returns>
        public DataSet GetDataSet(string strSQL)
        {
            Param param = new Param();
            return tbGameDAO.GetDataSet(strSQL, param);
        }
    }
}

