using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Com.ZY.JXKK.BLL
{
    public interface ILogin
    {
        void Log(string userEvent);

        string GetUserId();

        string GetUserName();
    }
}
