using Com.ZY.JXKK.Model;
using Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WCFWebServices;

namespace WCFTestWinForm
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void btnTestWcf_Click(object sender, EventArgs e)
        {
            try
            {

                RightWebService.RightWebServiceSoapClient now = new RightWebService.RightWebServiceSoapClient();
                //RightWebService d = new RightWebService();
                RightWebService.APIResult user = now.GetLoginUserInfo("admin", "1");
                Console.WriteLine(user);
            }catch(Exception ex)
            {

                Console.WriteLine(ex);
            }
        }
    }
}
