using Company.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Company.Web.View
{
    public partial class MgrMenuSon :BasePage
    {
        protected Model.MgrMenu fatherMenu = null;
        BLL.MgrMenu bll = new BLL.MgrMenu();
        public override void SonLoad()
        {
            try
            {
                string pid = Request.QueryString["mid"];
                IList<Model.MgrMenu> listSon = bll.GetListByPid(int.Parse(pid));

                fatherMenu = bll.GetModel(int.Parse(pid));

                this.rptList.DataSource = listSon;
                this.rptList.DataBind();
            }
            catch (Exception ex)
            {
                PageHelper.WriteJsMsg("异常："+ex.Message);
                Response.End();
            }        
        }
    }
}