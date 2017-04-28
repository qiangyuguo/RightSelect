using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;

namespace JXKK.Util
{
   public class ControlBindHelper
    {
       public static Hashtable GetWebControlsValue(HttpContext context, int count, int index = 1)
       {
           Hashtable ht = new Hashtable();
           int size = HttpContext.Current.Request.Params.Count;
           for (int i = index; i < count; i++)
           {
               string id = context.Request.Params.GetKey(i);
               var value = context.Request[id];
               ht[id] = value;
              
           }
           return ht;
       }
    }
}
