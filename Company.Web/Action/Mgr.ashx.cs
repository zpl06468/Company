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
                case "m":
                    DoModify();
                    break;
                case "ms":
                    DoModifySon();
                    break;
                default:
                    break;
            }
        }
        BLL.MgrMenu bll = new BLL.MgrMenu();
        #region 1.0根据id获得菜单项
        /// <summary>
        /// 根据id获得菜单项
        /// </summary>
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
                string strJson = DataHelper.Obj2Json(model);
                AjaxMsgHelper.AjaxMsg("ok", "加载成功", strJson);
            }
            catch (Exception ex)
            {
                AjaxMsgHelper.AjaxMsg("err", "异常:" + ex.Message);
            }
        } 
        #endregion

        #region 2.0执行修改操作
        /// <summary>
        /// 执行修改操作
        /// </summary>
        public void DoModify()
        {
            Model.MgrMenu model = new Model.MgrMenu()
            {
                MgrId = int.Parse(Request.Form["MgrId"]),
                MgrName = Request.Form["MgrName"],
                MgrSort = int.Parse(Request.Form["MgrSort"])
            };

            try
            {
                bll.UpdateFather(model);
                string strJson = DataHelper.Obj2Json(model);
                AjaxMsgHelper.AjaxMsg("ok", "修改成功",strJson);
            }
            catch (Exception ex)
            {
                AjaxMsgHelper.AjaxMsg("err", "异常"+ex.Message);
            }
        } 
        #endregion
        public void DoModifySon()
        {
            Model.MgrMenu model = new Model.MgrMenu()
            {
                MgrId = int.Parse(Request.Form["MgrId"]),
                MgrName = Request.Form["MgrName"],
                MgrLinkUrl = Request.Form["MgrLinkUrl"],
                MgrSort = int.Parse(Request.Form["MgrSort"])
            };

            try
            {
                bll.UpdateSon(model);
                string strJson = DataHelper.Obj2Json(model);
                AjaxMsgHelper.AjaxMsg("ok", "修改成功", strJson);
            }
            catch (Exception ex)
            {
                AjaxMsgHelper.AjaxMsg("err", "异常" + ex.Message);
            }
        }
    }
}