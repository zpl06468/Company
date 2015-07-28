using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Company.BLL
{
   public class Users
    {
        private readonly Company.DAL.Users dal = new Company.DAL.Users();

        #region 01.根据ID获得实体对象 +Model.Users GetModel(int intId)
        /// <summary>
        /// 根据ID获得实体对象
        /// </summary>
        /// <param name="intId">id值</param>
        /// <returns>实体对象</returns>
        public Company.Model.Users GetModel(int intId)
        {
            return dal.GetModel(intId);
        }
        #endregion

        #region GET DATA LIST
        /// <summary>
        /// GET DATA LIST
        /// </summary>
        public IList<Company.Model.Users> GetList()
        {
            return dal.GetList();
        }
        #endregion

        #region 03.还原 +int UpdateRe(string ids)
        /// <summary>
        /// 还原（将删除标志设置为false）
        /// </summary>
        /// <param name="ids">要还原的 id们</param>
        /// <returns>还原成功与否</returns>
        public bool UpdateRe(string ids)
        {
            return dal.UpdateDel(ids, false) > 0;
        }
        #endregion

        #region 04.软删除+ int UpdateDel(string ids)
        /// <summary>
        /// 软删除（将删除标志设置为true）
        /// </summary>
        /// <param name="ids">要软删除的 id们</param>
        /// <returns>软删除成功与否</returns>
        public bool UpdateDel(string ids)
        {
            return dal.UpdateDel(ids, true) > 0;
        }
        #endregion

        #region 05.物理删除 +int Del(string ids)
        /// <summary>
        /// 物理删除（将删除标志设置为true）
        /// </summary>
        /// <param name="ids">要删除的 id们</param>
        /// <returns>删除成功与否</returns>
        public bool Del(string ids)
        {
            return dal.Del(ids) > 0;
        }
        #endregion

        #region 06.新增记录
        /// <summary>
        /// 新增记录
        /// </summary>
        /// <param name="Model">数据实体对象</param>
        /// <returns>新增行的ID</returns>
        public int Add(Company.Model.Users Model)
        {
            return dal.Add(Model);
        }
        #endregion

        #region 07.修改记录
        /// <summary>
        /// 修改记录
        /// </summary>
        /// <param name="Model">数据实体对象</param>
        /// <returns>受影响行数</returns>
        public bool Update(Company.Model.Users Model)
        {
            return dal.Update(Model) > 0;
        }
        #endregion

        //----------------------------------------------
        #region 1.0 登录操作 + Model.Users Login(string strLoginName, string strPwd)
        /// <summary>
        /// 登录操作
        /// </summary>
        /// <param name="strLoginName"></param>
        /// <param name="strPwd"></param>
        /// <returns></returns>
        public Company.Model.Users Login(string strLoginName, string strPwd)
        {
            Company.Model.Users userModel = dal.Login(strLoginName);
            if (userModel != null && userModel.UPwd == strPwd)
            {
                return userModel;
            }
            return null;
        }
        #endregion
    }
}
