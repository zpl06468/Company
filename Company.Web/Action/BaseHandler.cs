using Company.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.SessionState;

namespace Company.Web.Action
{
    /// <summary>
    /// 一般处理程序 父类-统一验证
    /// </summary>
    public abstract class BaseHandler:IHttpHandler,System.Web.SessionState.IRequiresSessionState
    {
       protected HttpContext context = null;

       protected HttpSessionState Session
       {
           get
           {
               return context.Session;
           }
       }
       protected HttpRequest Request
       {
           get
           {
               return context.Request;
           }
       }

       protected HttpResponse Response
       {
           get
           {
               return context.Response;
           }
       }
       Model.Users userNow = null;
       public Model.Users UserNow
       {
           get
           {
               if (userNow==null)
               {
                   userNow = Session["uinfo"] as Model.Users;
               }
               return userNow;
           }
       }
        public void ProcessRequest(HttpContext context)
        {
            this.context = context;
            if (Session["uinfo"] == null)
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
        public bool IsReusable
        {
            get
            {
                return false;
            }
        }
    }
}