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
    /// 彩种类型
    /// Author:代码生成器
    /// </summary>
    public class LotteryBLL
    {
        private HttpContext context;//HTTP请求上下文
        private ILogin loginSession;//登录对象信息
        private CommonDao commonDao = new CommonDao();
        private TBLotteryDAO tbLotteryDAO= new TBLotteryDAO();
        
        /// <summary>
        /// 类构造方法
        /// <param name="context">HTTP请求上下文</param>
        /// <param name="loginSession">登录对象信息</param>
        /// </summary>
        public LotteryBLL(HttpContext context, ILogin loginSession)
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
            string strSQL = "select * from TBLottery";
            string str = commonDao.DataGrid(strSQL, null, page, rows);
            WebJson.Write(context, str);
        }
        
        /// <summary>
        /// 加载指定彩种类型
        /// <param name="LotteryType">彩种编号</param>
        /// </summary>
        public void Load(string LotteryType)
        {
            try
            {
                TBLottery tbLottery=tbLotteryDAO.Get(LotteryType);
                WebJson.ToJson(context, tbLottery);
            }
            catch (Exception e)
            {
                Message.error(context, e.Message);
            }
        }
        /// <summary>
        /// 获取指定彩种信息
        /// <param name="areaId">区域编号</param>
        /// </summary>
        public TBLottery Get(string lotteryType)
        {
            TBLottery tbLottery = new TBLottery();
            try
            {
                tbLottery = tbLotteryDAO.Get(lotteryType);
            }
            catch (Exception e)
            {
                Message.error(context, e.Message);
            }
            return tbLottery;
        }
        /// <summary>
        /// 增加彩种类型
        /// <param name="tbLottery">彩种类型</param>
        /// </summary>
        public void Add(TBLottery tbLottery)
        {
            try
            {
                tbLotteryDAO.Add(tbLottery);
                Message.success(context, "彩种类型增加成功");
                loginSession.Log("XXXXXX彩种类型增加成功");
            }
            catch (Exception e)
            {
                Message.error(context, "彩种类型增加失败");
                loginSession.Log(e.Message);
            }
        }
        
        /// <summary>
        /// 修改彩种类型
        /// <param name="tbLottery">彩种类型</param>
        /// </summary>
        public void Edit(TBLottery tbLottery)
        {
            try
            {
                tbLotteryDAO.Edit(tbLottery);
                Message.success(context, "彩种类型修改成功");
                loginSession.Log("XXXXXX彩种类型修改成功");
            }
            catch (Exception e)
            {
                Message.error(context, "彩种类型修改失败");
                loginSession.Log(e.Message);
            }
        }
        
        /// <summary>
        /// 删除彩种类型
        /// <param name="LotteryType">彩种编号</param>
        /// </summary>
        public void Delete(string LotteryType)
        {
            try
            {
                tbLotteryDAO.Delete(LotteryType);
                Message.success(context, "彩种类型删除成功");
                loginSession.Log("XXXXXX彩种类型删除成功");
            }
            catch (Exception e)
            {
                Message.error(context, "彩种类型删除失败");
                loginSession.Log(e.Message);
            }
        }

        

        /// <summary>
        /// 获取DataSet(彩种类型)
        /// <param name="strSQL">查询语句</param>
        /// <param name="param">查询参数</param>
        /// </summary>
        /// <returns>彩种类型DataSet</returns>
        public DataSet GetDataSet(string strSQL)
        {
            Param param = new Param();
            return tbLotteryDAO.GetDataSet(strSQL, param);
        }
    }
}

