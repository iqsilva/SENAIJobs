using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SENAI_Jobs
{
    public partial class Logout : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["Usuario"] != null)
            {
                Session["Usuario"] = null;
                Session["Experiencias"] = null;
                Response.Redirect("Login.aspx");
            }
        }
    }
}