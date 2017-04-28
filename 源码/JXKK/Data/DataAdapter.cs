using System;
using System.Data.SqlClient;

namespace Com.Data
{
	/// <summary>
	/// Class1 的摘要说明。
	/// </summary>
	public class ComDataAdapter
	{
	//	private Oracle.ManagedDataAccess.Client.OracleDataAdapter _da = null ;
        private SqlDataAdapter _da = null;
        public bool AcceptChangesDuringFill
		{
			get
			{
				return _da.AcceptChangesDuringFill;
			}
			set
			{
				_da.AcceptChangesDuringFill = value ;
			}
		}
		public System.ComponentModel.IContainer Container
		{
			get
			{
				return _da.Container;
			}
		}
		public bool ContinueUpdateOnError
		{
			get
			{
				return _da.ContinueUpdateOnError;
			}
			set
			{
				_da.ContinueUpdateOnError = value ;
			}
		}
		public ComCommand DeleteCommand
		{
			get
			{
				ComCommand cmd = new ComCommand();
				cmd.Command = _da.DeleteCommand;
				return cmd;
			}
			set
			{
				ComCommand cmd = value ;
				_da.DeleteCommand = cmd.Command ;
			}
		}
		public ComCommand InsertCommand
		{
			get
			{
				ComCommand cmd = new ComCommand();
				cmd.Command = _da.InsertCommand;
				return cmd;
			}
			set
			{
				ComCommand cmd = value ;
				_da.InsertCommand = cmd.Command ;
			}
		}
		public System.Data.MissingMappingAction MissingMappingAction
		{
			get
			{
				return _da.MissingMappingAction;
			}
			set
			{
				_da.MissingMappingAction = value ;
			}
		}
		public System.Data.MissingSchemaAction MissingSchemaAction
		{
			get
			{
				return _da.MissingSchemaAction;
			}
			set
			{
				_da.MissingSchemaAction = value ;
			}
		}
		public ComCommand SelectCommand
		{
			get
			{
				ComCommand cmd = new ComCommand();
				cmd.Command = _da.SelectCommand;
				return cmd;
			}
			set
			{
				ComCommand cmd = value ;
				_da.SelectCommand = cmd.Command ;
			}
		}
		public System.ComponentModel.ISite Site
		{
			get
			{
				return _da.Site;
			}
			set
			{
				_da.Site = value ;
			}
		}
		public System.Data.Common.DataTableMappingCollection TableMappings
		{
			get
			{
				return _da.TableMappings;
			}
		}
		public ComCommand UpdateCommand
		{
			get
			{
				ComCommand cmd = new ComCommand();
				cmd.Command = _da.UpdateCommand;
				return cmd;
			}
			set
			{
				ComCommand cmd = value ;
				_da.UpdateCommand = cmd.Command ;
			}
		}
		public ComDataAdapter()
		{
			_da = new SqlDataAdapter() ;
		}
		public ComDataAdapter(string selectCommandText,string selectConnectionString)
		{
			_da = new SqlDataAdapter(selectCommandText,selectConnectionString) ;
		}
		public ComDataAdapter(string selectCommandText,ComConnection con)
		{
            _da = new SqlDataAdapter(selectCommandText, con.Connection);
		}
		public ComDataAdapter(ComCommand cmd)
		{
            _da = new SqlDataAdapter(cmd.Command);
		}
		public System.Runtime.Remoting.ObjRef CreateObjRef(System.Type requestedType)
		{
			return _da.CreateObjRef(requestedType);			 
		}
		public void Dispose()
		{
			_da.Dispose(); 
		}
		public override bool Equals(object obj)
		{
			return _da.Equals(obj); 
		}
		public int Fill(System.Data.DataSet dataSet,int startRecord,int maxRecords,string srcTable)
		{
			return _da.Fill(dataSet,startRecord,maxRecords,srcTable);
		}
		public int Fill(System.Data.DataSet dataSet,string srcTable)
		{
			return _da.Fill(dataSet,srcTable);
		}
		public int Fill(System.Data.DataSet dataSet)
		{
			return _da.Fill(dataSet);
		}
		public int Fill(System.Data.DataTable dataTable)
		{
			return _da.Fill(dataTable);
		}
		public System.Data.DataTable [] FillSchema(System.Data.DataSet dataSet,System.Data.SchemaType schemaType,string srcTable)
		{
			return _da.FillSchema(dataSet,schemaType,srcTable);
		}
		public System.Data.DataTable [] FillSchema(System.Data.DataSet dataSet,System.Data.SchemaType schemaType)
		{
			return _da.FillSchema(dataSet,schemaType);
		}
		public System.Data.DataTable FillSchema(System.Data.DataTable dataTable,System.Data.SchemaType schemaType)
		{
			return _da.FillSchema(dataTable,schemaType);
		}
		public System.Data.IDataParameter [] GetFillParameters()
		{
			return _da.GetFillParameters();
		}
		public override int GetHashCode()
		{
			return _da.GetHashCode();
		}
		public object GetLifetimeService()
		{
			return _da.GetLifetimeService();
		}
		public new System.Type GetType()
		{
			return _da.GetType();
		}
		public object InitializeLifetimeService()
		{
			return _da.InitializeLifetimeService();
		}
		public override string ToString()
		{
			return _da.ToString ();
		}
		public int Update(System.Data.DataSet dataSet ,string srcTable)
		{
			return _da.Update(dataSet,srcTable);
		}
		public int Update(System.Data.DataTable dataTable)
		{
			return _da.Update(dataTable);
		}
		public int Update(System.Data.DataRow[] dataRows)
		{
			return _da.Update(dataRows);
		}
		public int Update(System.Data.DataSet dataSet)
		{
			return _da.Update(dataSet);
		}
	}
}
