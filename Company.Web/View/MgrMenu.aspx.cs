using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Company.Web.View
{
    public partial class MgrMenu : BasePage
    {
        BLL.MgrMenu bll = new BLL.MgrMenu();
        public override void SonLoad()
        {
            IList<Model.MgrMenu> list = bll.GetListByPid(0);
            this.rptList.DataSource = list;
            this.rptList.DataBind();
        }
    }
}