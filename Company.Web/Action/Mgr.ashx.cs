using Company.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Company.Web.Action
{
    /// <summary>
    /// Mgr 的摘要说明
    /// </summary>
    
    public class Mgr : BaseHandler
    {
       
        public override void SonLoad()
        {
            string strType = Request.Params["type"];
            switch (strType)
            {
                case "get":
                    GetMenu();
                    break;
                default:
                    break;
            }
        }
        BLL.MgrMenu bll = new BLL.MgrMenu();
        public void GetMenu()
        {
            string strId = Request.QueryString["mid"];
            if (!ValidateHelper.IsNum(strId))
            {
                AjaxMsgHelper.AjaxMsg("err", "参数异常");
                Response.End();
            }
            try
            {
                Model.MgrMenu model = bll.GetModel(int.Parse(strId));
                string strJson=DataHelper.Obj2Json(model);
                AjaxMsgHelper.AjaxMsg("ok", "加载成功", strJson);
            }
            catch (Exception ex)
            {
                AjaxMsgHelper.AjaxMsg("err", "异常:"+ex.Message);
            }
        }
    }
}