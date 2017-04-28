using System;
namespace Com.Data
{
	/// <summary>
	/// Command 的摘要说明。
	/// </summary>
	public class ComCommand
	{
		private System.Data.OracleClient.OracleCommand _cmd = null;
		public System.Data.OracleClient.OracleCommand Command
		{
			get
			{
				return _cmd ;
			}
			set
			{
				_cmd = value ;
			}
		}
		public string CommandText
		{
			get
			{
				return _cmd.CommandText ;
			}
			set
			{
				_cmd.CommandText = value ;
			}
		}
		
		public System.Data.CommandType CommandType
		{
			get
			{
				return _cmd.CommandType ;
			}
			set
			{
				_cmd.CommandType = value ;
			}
		}
		public ComConnection Connection
		{
			get
			{
				ComConnection con = new ComConnection();
				con.Connection = _cmd.Connection ;
				return con ;
			}
			set
			{
				ComConnection con = value ;
				_cmd.Connection = con.Connection ;
			}
		}
		public System.ComponentModel.IContainer Container
		{
			get
			{
				return _cmd.Container ;
			}
		}
		public bool DesignTimeVisible
		{
			get
			{
				return _cmd.DesignTimeVisible ;
			}
			set
			{
				_cmd.DesignTimeVisible = value ;
			}
		}
		public System.Data.OracleClient.OracleParameterCollection  Parameters
		{
			get
			{
				return _cmd.Parameters ;
			}
		}
		public System.ComponentModel.ISite Site
		{
			get
			{
				return _cmd.Site ;
			}
			set
			{
				_cmd.Site = value ;
			}
		}
				public System.Data.OracleClient.OracleTransaction Transaction
				{
					get
					{
						return  _cmd.Transaction ;
					}
					set
					{
						_cmd.Transaction = value ;
					}
				}
		public System.Data.UpdateRowSource UpdatedRowSource
		{
			get
			{
				return _cmd.UpdatedRowSource ;
			}
			set
			{
				_cmd.UpdatedRowSource = value ;
			}
		}
		public ComCommand()
		{
			_cmd = new System.Data.OracleClient.OracleCommand();
		}
		public ComCommand(string cmdText)
		{
			_cmd = new System.Data.OracleClient.OracleCommand(cmdText);
		}
		public ComCommand(string cmdText,ComConnection con)
		{
			_cmd = new System.Data.OracleClient.OracleCommand(cmdText,con.Connection);
		}
		public ComCommand(string cmdText,ComConnection con,ComTransaction trans)
		{
			_cmd = new System.Data.OracleClient.OracleCommand(cmdText,con.Connection,trans.Transaction);
		}
		public void Cancel()
		{
			_cmd.Cancel();
		}
		public System.Runtime.Remoting.ObjRef Close(System.Type requestedType)
		{
			return _cmd.CreateObjRef(requestedType);			 
		}
		public System.Data.OracleClient.OracleParameter CreateParameter()
		{
			return _cmd.CreateParameter();
		}
		public void Dispose()
		{
			_cmd.Dispose();
		}
		public override bool Equals(object obj)
		{
			return _cmd.Equals(obj);
		}
		public int ExecuteNonQuery()
		{
			return _cmd.ExecuteNonQuery();
		}
		public ComDataReader ExecuteReader()
		{
			ComDataReader dr = new ComDataReader() ;
			dr.DataReader = _cmd.ExecuteReader();
			return dr ;
		}
		public object ExecuteScalar()
		{
			return  _cmd.ExecuteScalar();
		}
		public override int GetHashCode()
		{
			return  _cmd.GetHashCode();
		}
		public object GetLifetimeService()
		{
			return _cmd.GetLifetimeService();
		}
		public new System.Type GetType()
		{
			return _cmd.GetType();
		}
		public object InitializeLifetimeService()
		{
			return _cmd.InitializeLifetimeService();
		}
		public void Prepare()
		{
			_cmd.Prepare();
		}
		public override string ToString()
		{
			return _cmd.ToString();
		}
	}
}
