using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Company.Web.View
{
    public partial class Menu : System.Web.UI.Page
    {
        BLL.Menu bll = new BLL.Menu();
        protected void Page_Load(object sender, EventArgs e)
        {
           IList<Model.Menu> list=bll.GetList();
           rptList.DataSource = list;
           rptList.DataBind();
        }
    }
}