using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SENAI_Jobs
{
    public partial class SENAIJobs : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            this.ID = "SENAIJobs";
        }
    }
}