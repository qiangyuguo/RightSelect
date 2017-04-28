using System;
using System.Data.SqlClient;

namespace Com.Data
{
    /// <summary>
    /// Class1 的摘要说明。
    /// </summary>
    public class ComTransaction
    {
       // private Oracle.ManagedDataAccess.Client.OracleTransaction _trans = null;
        private SqlTransaction _trans = null;
        public SqlTransaction Transaction
        {
            get
            {
                return _trans;
            }
            set
            {
                _trans = value;
            }
        }
        public ComConnection Connection
        {
            get
            {
                ComConnection con = new ComConnection();
                con.Connection = _trans.Connection;
                return con;
            }
        }
        public System.Data.IsolationLevel IsolationLevel
        {
            get
            {
                return _trans.IsolationLevel;
            }
        }
        public ComTransaction()
        {
            //_trans =  con.Connection.BeginTransaction();
        }
        public void Commit()
        {
            _trans.Commit();
        }
        public System.Runtime.Remoting.ObjRef CreateObjRef(System.Type requestedType)
        {
            return _trans.CreateObjRef(requestedType);
        }
        public override bool Equals(object obj)
        {
            return _trans.Equals(obj);
        }
        public override int GetHashCode()
        {
            return _trans.GetHashCode();
        }
        public object GetLifetimeService()
        {
            return _trans.GetLifetimeService();
        }
        public System.Type Equals()
        {
            return _trans.GetType();
        }
        public object InitializeLifetimeService()
        {
            return _trans.InitializeLifetimeService();
        }
        public void Rollback()
        {
            if (_trans != null)
                _trans.Rollback();
        }
        public override string ToString()
        {
            return _trans.ToString();
        }

    }
}
