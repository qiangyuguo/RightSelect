using System;

namespace Com.Data
{
	/// <summary>
	/// Connection 的摘要说明。
	/// </summary>
	public class ComConnection
	{
		private System.Data.OracleClient.OracleConnection _con = null ;
		public System.Data.OracleClient.OracleConnection Connection
		{
			get
			{
				return _con ;
			}
			set
			{
				_con = value ; 
			}
		}
		public string ConnectionString
		{
			get
			{
				return _con.ConnectionString;
			}
			set
			{
				_con.ConnectionString = value ;
			}
		}
		public System.ComponentModel.IContainer Container
		{
			get
			{
				return _con.Container ;
			}
		}
//		public string Database
//		{
//			get
//			{
//				return _con.Database ;
//			}
//		}
		public string DataSource
		{
			get
			{
				return _con.DataSource ;
			}
		}
//		public string Driver
//		{
//			get
//			{
//				return _con.Driver ;
//			}
//		}
		public string ServerVersion
		{
			get
			{
				return _con.ServerVersion ;
			}
		}
		public System.ComponentModel.ISite Site
		{
			get
			{
				return _con.Site ;
			}
			set
			{
				_con.Site = value ;  
			}
		}
		public System.Data.ConnectionState State
		{
			get
			{
				return _con.State ;
			}
		}
		public ComConnection()
		{
			_con = new System.Data.OracleClient.OracleConnection();
		}
		public ComConnection(string connectionString)
		{
			_con = new System.Data.OracleClient.OracleConnection(connectionString);
		}
		public ComTransaction BeginTransaction(System.Data.IsolationLevel idolevel)
		{
			ComTransaction trans = new ComTransaction() ;
			trans.Transaction = _con.BeginTransaction(idolevel);
			return  trans ;
		}
		public ComTransaction BeginTransaction()
		{
			ComTransaction trans = new ComTransaction() ;
			trans.Transaction = _con.BeginTransaction();
			return  trans ;

		}
		public void Close()
		{
			_con.Close();
		}
		public ComCommand CreateCommand()
		{
			ComCommand cmd = new ComCommand() ;
			cmd.Command = _con.CreateCommand();
			return cmd ;
		}
		public System.Runtime.Remoting.ObjRef CreateObjRef(System.Type requestedType)
		{
			return _con.CreateObjRef(requestedType);			 
		}
		public void Dispose()
		{
			_con.Dispose();
		}
		public void EnlistDistributedTransaction(System.EnterpriseServices.ITransaction transaction)
		{
			_con.EnlistDistributedTransaction(transaction);
		}
		public override bool Equals(object obj)
		{
			return _con.Equals(obj);
		}
		public override int GetHashCode()
		{
			return _con.GetHashCode();
		}
		public object GetLifetimeService()
		{
			return _con.GetLifetimeService();
		}
		public System.Type Equals()
		{
			return _con.GetType();
		}
		public object InitializeLifetimeService()
		{
			return _con.InitializeLifetimeService();
		}
		public void Open()
		{
			_con.Open();
		}
		public override string ToString()
		{
			return _con.ToString();
		}
	}
}
