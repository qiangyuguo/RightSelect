using System;
using System.Data;
using System.Data.Common;
using System.Collections;

namespace Com.Data
{
	/// <summary>
	/// QueryParameterCollection 的摘要说明。
	/// </summary>
	public sealed class Param : MarshalByRefObject 
	{
		int intitialCapacity=10;
		public Param()
		{		
		}
		public Param(int initCapacity)
		{
			intitialCapacity=initCapacity;
		}
		private ArrayList items;
		private ArrayList ArrayList()
		{
			if (this.items == null)
			{
				this.items = new ArrayList(intitialCapacity); 
			}
			return this.items; 
		} 
		public int Count
		{
			get
			{
				if (this.items == null)
				{
					return 0; 
				}
				return this.items.Count; 

			}
		}

		public QueryParameter Add(QueryParameter param)
		{
			this.ArrayList().Add(param);
			return param;
		} 

		public QueryParameter Add(string ParameterName, object Value)
		{
			return this.Add(new QueryParameter(ParameterName, Value)); 
		} 

		private void Replace(int index, QueryParameter newValue)
		{
			this.Validate(index, newValue);
			this.items[index] = newValue; 
		} 

		public QueryParameter this[int index]
		{
			get
			{
				this.RangeCheck(index);
				return ((QueryParameter) this.items[index]); 
			}

			set
			{
				this.RangeCheck(index);
				this.Replace(index, value);
			}
		}

		public QueryParameter this[string ParameterName]
		{
			get
			{
				int num1 = this.RangeCheck(ParameterName);
				return ((QueryParameter) this.items[num1]);
			}

			set
			{
				int num1 = this.RangeCheck(ParameterName);
				this.Replace(num1, value);
			}
		}

		private void ValidateType(object Value)
		{
		} 
		private void Validate(int index, QueryParameter Value)
		{}
		
		private void RangeCheck(int index)
		{
			if ((index < 0) || (this.Count <= index))
			{
			  throw new IndexOutOfRangeException("Number "+index.ToString()+" is out of Range");
 
			} 
		} 

		private int RangeCheck(string ParameterName)
		{
			int num1;
			num1 = this.IndexOf(ParameterName);
			if (num1 < 0)
			{
				throw new IndexOutOfRangeException("ParameterName "+ParameterName+" dose not exist"); 
			}
			return num1; 
		} 

		public int IndexOf(string ParameterName)
		{
			int index=-1;
			if (this.items != null)
			{
				for(int i=0;i<this.items.Count;i++)
				{
					if(((QueryParameter)items[i]).ParameterName.Equals(ParameterName))
					{
						index=i;
						break;
					}
				}
			}
			return index; 
		}

		public void Clear()
		{
			this.ArrayList().Clear();
		}
	}
}
