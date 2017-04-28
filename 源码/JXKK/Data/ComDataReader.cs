using System;
using System.Data.SqlClient;

namespace Com.Data
{
	/// <summary>
	/// DataReader 的摘要说明。
	/// </summary>
	public class ComDataReader
	{
		private  SqlDataReader _dr = null ;
		public SqlDataReader DataReader
		{
			get
			{
				return _dr ;
			}
			set
			{
				_dr = value ;
			}
		}
		public int Depth
		{
			get
			{
				return _dr.Depth ;
			}
		}
		public int FieldCount
		{
			get
			{
				return _dr.FieldCount ;
			}
		}
		public bool HasRows
		{
			get
			{
				return _dr.HasRows ;
			}
		}
		public bool IsClosed
		{
			get
			{
				return _dr.IsClosed ;
			}
		}
		public int RecordsAffected
		{
			get
			{
				return _dr.RecordsAffected ;
			}
		}

        public object this[int index]
        {
            get
            {
                return this.DataReader[index];
            }
        }

        public object this[string name]
        {
            get
            {
                return this.DataReader[name];
            }
        }

		public ComDataReader()
		{
		}
		public void Close()
		{
			_dr.Close();
		}
		public System.Runtime.Remoting.ObjRef CreateObjRef(System.Type requestedType)
		{
			return _dr.CreateObjRef(requestedType);			 
		}
		public override bool Equals(object obj)
		{
			return _dr.Equals(obj);
		}
		public bool GetBoolean(int i)
		{
			return _dr.GetBoolean(i);
		}
		public byte GetByte(int i)
		{
			return _dr.GetByte(i);
		}
		public long GetBytes(int i,long dataIndex,byte[] buffer,int bufferIndex,int length)
		{
			return _dr.GetBytes(i,dataIndex,buffer,bufferIndex,length);
		}
		public char GetChar(int i)
		{
			return _dr.GetChar(i);
		}
		public long GetChars(int i,long dataIndex,char[] buffer,int bufferIndex,int length)
		{
			return _dr.GetChars(i,dataIndex,buffer,bufferIndex,length);
		}
		public String GetDataTypeName(int i)
		{
			return _dr.GetDataTypeName(i);
		}
		public System.DateTime GetDateTime(int i)
		{
			return _dr.GetDateTime(i);
		}
		public System.Decimal GetDecimal(int i)
		{
			return _dr.GetDecimal(i);
		}
		public double GetDouble(int i)
		{
			return _dr.GetDouble(i);
		}
		public System.Type GetFieldType(int i)
		{
			return _dr.GetFieldType(i);
		}
		public float GetFloat(int i)
		{
			return _dr.GetFloat(i);
		}
		public System.Guid GetGuid(int i)
		{
			return _dr.GetGuid(i);
		}
		public override int GetHashCode()
		{
			return _dr.GetHashCode();
		}
		public short GetInt16(int i)
		{
			return _dr.GetInt16(i);
		}
		public int GetInt32(int i)
		{
			return _dr.GetInt32(i);
		}
		public long GetInt64(int i)
		{
			return _dr.GetInt64(i);
		}
		public object GetLifetimeService()
		{
			return _dr.GetLifetimeService();
		}
		public string GetName(int i)
		{
			return _dr.GetName(i);
		}
		public int GetOrdinal(string sValue)
		{
			return _dr.GetOrdinal(sValue);
		}
		public System.Data.DataTable GetSchemaTable()
		{
			return _dr.GetSchemaTable();
		}
		public string GetString(int i)
		{
			return _dr.GetString(i);
		}
		public new System.Type GetType()
		{
			return _dr.GetType();
		}
		public object GetValue(int i)
		{
			return _dr.GetValue(i);
		}
		public int GetValues(object[] values)
		{
			return _dr.GetValues(values);
		}
		public object InitializeLifetimeService()
		{
			return _dr.InitializeLifetimeService();
		}
		public bool IsDBNull(int i)
		{
			return _dr.IsDBNull(i);
		}
		public bool NextResult()
		{
			return _dr.NextResult();
		}
		public bool Read()
		{
			return _dr.Read();
		}
		public override string ToString()
		{
			return _dr.ToString();
		}
	}
}
