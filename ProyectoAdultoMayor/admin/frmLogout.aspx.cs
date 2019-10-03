using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ProyectoAdultoMayor.admin
{
    public partial class frmLogout : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            string url = "/admin/frmInicio.aspx";
            // This kills the cookie 
            FormsAuthentication.SignOut();
            // This redirects them to the login page 
            Response.Clear();
            if (Request.UrlReferrer != null && !Request.UrlReferrer.ToString().ToLower().Contains("frmlogout"))
            {
                url = Request.UrlReferrer.ToString();
            }
            Response.Redirect(url);
        }
    }
}