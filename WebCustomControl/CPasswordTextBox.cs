using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.UI.WebControls;

namespace WebCustomControl
{
    public class CPasswordTextBox: TextBox
    {
        public CPasswordTextBox()
        {
            TextMode = TextBoxMode.Password;
        }
    }
}
