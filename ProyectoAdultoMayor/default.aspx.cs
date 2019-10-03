using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Odbc;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ProyectoAdultoMayor
{
    public partial class _default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnLogin_Click(Object sender, EventArgs e)
        {
            // Initialize FormsAuthentication, for what it's worth
            FormsAuthentication.Initialize();

            // Create our connection and command objects
            OdbcConnection conn = new OdbcConnection(Utilities.ObtenerCadenaConexion());
            OdbcCommand cmd = conn.CreateCommand();
            cmd.CommandText = "SELECT roles FROM users WHERE username=? AND password=?";

            // Fill our parameters
            cmd.Parameters.Add("@username", OdbcType.NVarChar, 200).Value = Username.Value;
            cmd.Parameters.Add("@password", OdbcType.NVarChar, 200).Value = FormsAuthentication.HashPasswordForStoringInConfigFile(Password.Value, "SHA1");


            // Execute the command
            conn.Open();
            OdbcDataReader reader = cmd.ExecuteReader();
            if (reader.Read())
            {
                // Create a new ticket used for authentication
                FormsAuthenticationTicket ticket = new FormsAuthenticationTicket(
                   1, // Ticket version
                   Username.Value, // Username associated with ticket
                   DateTime.Now, // Date/time issued
                   DateTime.Now.AddMinutes(30), // Date/time to expire
                   true, // "true" for a persistent user cookie
                   reader.GetString(0), // User-data, in this case the roles
                   FormsAuthentication.FormsCookiePath);// Path cookie valid for

                // Encrypt the cookie using the machine key for secure transport
                string hash = FormsAuthentication.Encrypt(ticket);
                HttpCookie cookie = new HttpCookie(
                   FormsAuthentication.FormsCookieName, // Name of auth cookie
                   hash); // Hashed ticket

                // Set the cookie's expiration time to the tickets expiration time
                if (ticket.IsPersistent) cookie.Expires = ticket.Expiration;

                // Add the cookie to the list for outgoing response
                Response.Cookies.Add(cookie);

                // Redirect to requested URL, or homepage if no previous page
                // requested
                string returnUrl = Request.QueryString["ReturnUrl"];
                if (returnUrl == null) returnUrl = "/admin/frmInicio.aspx";

                // Don't call FormsAuthentication.RedirectFromLoginPage since it
                // could
                // replace the authentication ticket (cookie) we just added
                Response.Redirect(returnUrl);
            }
            else
            {
                // Never tell the user if just the username is password is incorrect.
                // That just gives them a place to start, once they've found one or
                // the other is correct!
                ErrorLabel.Text = "Por favor revise sus datos ya que no fue posible validarlos.";
                ErrorLabel.Visible = true;
            }

            reader.Close();
            conn.Close();
        }
    }
}