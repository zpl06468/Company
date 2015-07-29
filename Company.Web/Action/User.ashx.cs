using Company.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Company.Web.Action
{
    /// <summary>
    /// User 的摘要说明
    /// </summary>
    public class User : IHttpHandler, System.Web.SessionState.IRequiresSessionState
    {
        HttpContext context = null;
        BLL.Users bll = new BLL.Users();
        public void ProcessRequest(HttpContext context)
        {
            this.context = context;
            string strType = context.Request.Params["t"];
            switch (strType)
            {
                case "l":
                    Longin();
                    break;
                default:
                    break;
            }
        }

        public void Longin()
        {
            if (context.Request.Form["UCode"] == null || context.Request.Form["UCode"] != context.Session["code"].ToString())
            {
                AjaxMsgHelper.AjaxMsg("302", "验证码错误");
                context.Response.End();
            }
            try
            {
                Model.Users model = bll.Login(context.Request.Form["ULoginName"], context.Request.Form["UPwd"]);
                if (model == null)
                {
                    AjaxMsgHelper.AjaxMsg("err", "登录失败");
                }
                else
                {
                    context.Session["uinfo"] = model;

                    if (!string.IsNullOrEmpty(context.Request.Form["chkAlways"]))
                    {
                        HttpCookie cookie = new HttpCookie("uinfo", model.UId.ToString());
                        cookie.Expires = DateTime.Now.AddMinutes(60);
                        cookie.Path = "/View/";
                        context.Response.Cookies.Add(cookie);
                    }
                    AjaxMsgHelper.AjaxMsg("ok", "登录成功", null, "/View/Index.aspx");
                }
            }
            catch (Exception ex)
            {

                AjaxMsgHelper.AjaxMsg("err", "异常：" + ex.Message);
                
            }
        }

        public bool IsReusable
        {
            get
            {
                return false;
            }
        }
    }
}