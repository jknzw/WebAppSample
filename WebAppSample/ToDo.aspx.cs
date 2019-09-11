using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebAppSample
{
    public partial class ToDo : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            SessionManager.UserInfo userInfo = new SessionManager.UserInfo(Page.Session);

            if (userInfo.UserId != null)
            {
                // Success
            }
            else
            {
                Response.Redirect("~/Login.aspx", false);
            }
        }
    }
}
