using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.SessionState;

namespace WebAppSample
{
    public class SessionManager
    {
        public class UserInfo
        {
            private readonly HttpSessionState session;

            public UserInfo(HttpSessionState session)
            {
                this.session = session;
            }

            public string UserId
            {
                get
                {
                    return session["UserId"]?.ToString();
                }
                set
                {
                    session["UserId"] = value;
                }
            }
        }
    }
}