using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using MySql.Data.MySqlClient;
using System.Text.RegularExpressions;
using System.Web.Caching;
using System.Web.UI.HtmlControls;

using DB_proc_Artist;
using TF.Namespace.Controls;
using Common_Tasks_Artist;

namespace DB_Callcode_Artist.Artist
{
    public class Borja_om
    {
        Page sida = new Page();

        //Raderar innehållet i alla textrutor och dropdownmenyer:
        public void button_Borja_om()
        {
            Control myForm = sida.FindControl("form1");
            foreach (Control ctl in myForm.Controls)
                if (ctl.GetType().ToString().Equals("System.Web.UI.WebControls.TextBox"))
                    ((TextBox)ctl).Text = "";
        }

    }
}
