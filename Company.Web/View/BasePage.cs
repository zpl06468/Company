using Company.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Company.Web.View
{
    /// <summary>
    /// 父页面类
    /// </summary>
    public abstract class BasePage:System.Web.UI.Page
    {
        public Model.Users UserNow
        {
            get
            {
                return Session["uinfo"] as Model.Users;
            }
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["uinfo"]==null)
            {
                if (Request.Cookies["uinfo"] == null)
                {
                    //AjaxMsgHelper.AjaxMsg("状态", "您还没登陆", null, "Login.html");
                    PageHelper.WriteJsMsg("您还没登陆", "Login.html");
                    Response.End();
                }
                else
                {
                    string strId = Request.Cookies["uinfo"].Value;
                    Session["uinfo"] = new BLL.Users().GetModel(int.Parse(strId));

                }
            }
            SonLoad();
        }

        public abstract void SonLoad();
    }
}