using System;
using System.Data;

namespace Com.Data
{
	/// <summary>
	/// QueryParameter 的摘要说明。
	/// </summary>
	public sealed class QueryParameter : MarshalByRefObject
	{
		public QueryParameter(string ParameterName,object Value)
		{
			this.m_ParameterName=ParameterName;
			this.m_Value=Value;
		}
	
		private string m_ParameterName ;
		public string ParameterName 
		{
			get{return this.m_ParameterName;}
			set{this.m_ParameterName=value;}
		}

		private object m_Value;
		public object Value
		{
			get{return this.m_Value;}
			set{this.m_Value=value;}
		}
	}
}
