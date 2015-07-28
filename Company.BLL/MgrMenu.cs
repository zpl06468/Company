using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Company.BLL
{
    public class MgrMenu
    {
        private readonly Company.DAL.MgrMenu dal = new Company.DAL.MgrMenu();

        #region 01.根据ID获得实体对象 +MODEL.MgrMenu GetModel(int intId)
        /// <summary>
        /// 根据ID获得实体对象
        /// </summary>
        /// <param name="intId">id值</param>
        /// <returns>实体对象</returns>
        public Company.Model.MgrMenu GetModel(int intId)
        {
            return dal.GetModel(intId);
        }
        #endregion

        #region GET DATA LIST
        /// <summary>
        /// GET DATA LIST
        /// </summary>
        public IList<Company.Model.MgrMenu> GetList()
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
        /// <param name="model">数据实体对象</param>
        /// <returns>新增行的ID</returns>
        public int Add(Company.Model.MgrMenu model)
        {
            return dal.Add(model);
        }
        #endregion

        #region 07.修改记录
        /// <summary>
        /// 修改记录
        /// </summary>
        /// <param name="model">数据实体对象</param>
        /// <returns>受影响行数</returns>
        public bool Update(Company.Model.MgrMenu model)
        {
            return dal.Update(model) > 0;
        }
        #endregion

        //-----------------------------------

        #region 1.0 获取所有的 后台菜单 +IList<MODEL.MgrMenu> GetAllMrgMenu()
        /// <summary>
        /// 获取所有的 后台菜单
        /// </summary>
        /// <returns></returns>
        public IList<Model.MgrMenu> GetAllMrgMenu()
        {
            return dal.GetAllMrgMenu(false);
        }
        #endregion

        #region 2.0 根据 父菜单Id 查询 子菜单 +IList<MODEL.MgrMenu> GetListByPid(int pid)
        /// <summary>
        /// 2.0 根据 父菜单Id 查询 子菜单
        /// </summary>
        /// <param name="pid"></param>
        /// <returns></returns>
        public IList<Model.MgrMenu> GetListByPid(int pid)
        {
            return dal.GetListByPid(pid);
        }
        #endregion

        #region 3.0 更新父菜单 + int UpdateFather(Company.DAL.MgrMenu model)
        /// <summary>
        /// 3.0 更新父菜单
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public int UpdateFather(Company.Model.MgrMenu model)
        {
            return dal.UpdateFather(model);
        }
        #endregion

        #region 4.0 更新子菜单 + int UpdateSon(Company.DAL.MgrMenu model)
        /// <summary>
        /// 4.0 更新子菜单
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public int UpdateSon(Company.Model.MgrMenu model)
        {
            return dal.UpdateSon(model);
        }
        #endregion

        #region 5.0 新增父菜单 +int AddFather(Company.Model.MgrMenu model)
        /// <summary>
        /// 新增父菜单
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public int AddFather(Company.Model.MgrMenu model)
        {
            return dal.AddFather(model);
        }
        #endregion
    }
}
