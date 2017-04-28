using System;
using System.Data;
using System.Xml;
namespace Com.Data
{
	/// <summary>
	/// OdbcDataAccess 的摘要说明。
	/// </summary>
	public class DataAccess 
	{
        /// <summary>
        /// 数据库连接
        /// </summary>
        public static string DBConn;
 
		private ComConnection _dbconn=null;     ///定义连接;
		private ComTransaction trans=null; ///定义事务; 
		/// <summary>
		/// 构造函数
		/// </summary>
		public DataAccess( ComConnection conn )
		{
			this._dbconn = conn;
		}
		public DataAccess(string connstr)
		{
			this._dbconn = new ComConnection(connstr);
		}

		/// <summary>
		/// 取得连接
		/// </summary>
		public ComConnection DbConnection
		{
			get
			{
				return _dbconn;
			}
		}
        
		/// <summary>
		/// 打开连接
		/// </summary>
		public void Open()
		{
			if(this.IsClosed())
				_dbconn.Open();		
		}
        
		/// <summary>
		/// 关闭连接
		/// </summary>
		public void Close()
		{
			if(!this.IsClosed())
			_dbconn.Close();
		}
        
		/// <summary>
		/// 判断连接是否打开
		/// </summary>
		public bool IsClosed()
		{
			return _dbconn.State.Equals(ConnectionState.Closed);
		}
        
		/// <summary>
		/// 开始事务，并返回事务对象
		/// </summary>
		public ComTransaction BeginTransaction()
		{ 
			trans = this._dbconn.BeginTransaction();
			return trans ;
		}
		public  int ExecuteNonQuery(CommandType commandType, string commandText, Param commandParameters)
		{
			ComCommand cmd=new ComCommand() ;
			PrepareCommand(cmd,commandType, commandText,commandParameters);
			int tmpValue=cmd.ExecuteNonQuery();
			cmd.Parameters.Clear();
			return tmpValue;
		}

		public  DataSet ExecuteDataset(CommandType commandType, string commandText, Param commandParameters,DataSet ds,string tableName)
		{
			ComCommand cmd=new ComCommand() ;
			PrepareCommand(cmd,commandType, commandText,commandParameters);
			ComDataAdapter da = new ComDataAdapter ( cmd ) ;
			if( Object.Equals(tableName,null) || (tableName.Length<1) )
				da.Fill(ds);
			else
				da.Fill(ds,tableName);
			cmd.Parameters.Clear();
			return ds;
		}

		public  ComDataReader ExecuteReader(CommandType commandType, string commandText, Param commandParameters)
		{
			ComCommand cmd=new ComCommand() ;
			PrepareCommand(cmd,commandType, commandText,commandParameters);
			ComDataReader dr = cmd.ExecuteReader();
			cmd.Parameters.Clear();
			return dr;
			
		}

		public  object ExecuteScalar(CommandType commandType, string commandText, Param commandParameters)
		{
			ComCommand cmd = new ComCommand() ;
			PrepareCommand(cmd,commandType, commandText,commandParameters);
			object tmpValue=cmd.ExecuteScalar();
			cmd.Parameters.Clear();
			return tmpValue;
		}
		public DataView ExecuteDataView(CommandType commandType, string commandText, Param commandParameters)
		{
			DataSet ds = new DataSet();
			ComCommand cmd = new ComCommand() ;
			PrepareCommand(cmd,commandType, commandText,commandParameters);

			ComDataAdapter da = new ComDataAdapter ( cmd ) ;
			da.Fill(ds,"MyTableName");

			cmd.Parameters.Clear();
			return ds.Tables["MyTableName"].DefaultView;
		} 

		private void PrepareCommand(ComCommand cmd,CommandType commandType, string commandText, Param commandParameters)
		{
			cmd.CommandType = commandType;
			cmd.CommandText = commandText;
			cmd.Connection  = this._dbconn;
			if(trans==null)
				cmd.Transaction = null ;
			else
				cmd.Transaction = trans.Transaction;
			if((commandParameters!=null) && (commandParameters.Count>0) )
			{
				for(int i=0;i<commandParameters.Count;i++)
				{
                    cmd.Parameters.AddWithValue(commandParameters[i].ParameterName, commandParameters[i].Value);
                }
			}
		}
	}
}
