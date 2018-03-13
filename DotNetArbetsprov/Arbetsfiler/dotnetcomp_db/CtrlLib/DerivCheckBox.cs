using System;
using System.ComponentModel;
using System.Security;
using System.Security.Permissions;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;


//Custom checkbox som har uttökats med ett extra "lagringsaattribut": UnText. Som Text fast ej
//synlig i browsern. 

namespace TF.Namespace.Controls
{

    public class DerivCheckBox : CheckBox
    {
        public string UnText
        {     
            get { string un = (string)ViewState["UnText"]; return un; }
            set{ ViewState["UnText"] = value; }
        }
        
        
   }

}
        




    

        
    

