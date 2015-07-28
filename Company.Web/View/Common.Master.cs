using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Company.Web.View
{
    public partial class Common : System.Web.UI.MasterPage
    {
        protected System.Text.StringBuilder sb = new System.Text.StringBuilder(1000);
        protected void Page_Load(object sender, EventArgs e)
        {
            Company.BLL.MgrMenu bll = new BLL.MgrMenu();
            IList<Model.MgrMenu> list = bll.GetAllMrgMenu();
            MakeMenuHtml(list);
        }

        public void MakeMenuHtml(IList<Model.MgrMenu> list)
        {
            foreach (Model.MgrMenu menu in list)
            {
                if (menu.MgrPId==0)
                {
                    sb.AppendLine("<ul>");
                    sb.AppendLine("<li class=\"claTitle\">"+menu.MgrName+"</li>");
                    sb.AppendLine("<li>");
                    MakeSonMenuHtml(list, menu.MgrId);
                    sb.AppendLine("</li>");
                    sb.AppendLine("</ul>");
                }
            }
        }

        public void MakeSonMenuHtml(IList<Model.MgrMenu> list,int pId)
        {
            foreach (Model.MgrMenu menuSon in list)
            {
                if (menuSon.MgrPId==pId)
                {
                    sb.AppendLine("<ul>");
                    sb.AppendLine("<li><a href=\""+menuSon.MgrLinkUrl+"\">"+menuSon.MgrName+"</a></li>");
                    sb.AppendLine("</ul>");
                }
            }
        }
    }
}