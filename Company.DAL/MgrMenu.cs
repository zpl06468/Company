using Company.Common;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;

namespace Company.DAL
{
    public class MgrMenu
    {
        #region 01.修改软删除标志
        /// <summary>
        /// 修改软删除标志
        /// </summary>
        /// <param name="ids">要修改软删除标志的id号们(1,2,5)</param>
        /// <param name="isDel">要将删除标志 改成 true/false</param>
        /// <returns>受影响行数</returns>
        public int UpdateDel(string ids, bool isDel)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("exec('update MgrMenu set mgrIsDel=''" + isDel.ToString() + "'' where mgrId in ('+@ids+')')");
            SqlParameter para = new SqlParameter("@ids", ids);
            return SQLHelper.ExcuteNonQuery(strSql.ToString(), para);
        }
        #endregion

        #region 01.2单个修改软删除标志
        /// <summary>
        /// 单个修改软删除标志
        /// </summary>
        /// <param name="idInt">要修改软删除标志的id号</param>
        /// <param name="isDel">要将删除标志 改成 true/false</param>
        /// <returns>受影响行数</returns>
        public int UpdateDel(int idInt, bool isDel)
        {
            string strSql = "update MgrMenu set mgrIsDel='" + isDel.ToString() + "' where mgrId = @id";
            SqlParameter para = new SqlParameter("@id", idInt);
            return SQLHelper.ExcuteNonQuery(strSql, para);
        }
        #endregion

        #region 02.执行物理删除 +int Del(string ids)
        /// <summary>
        /// 执行物理删除
        /// </summary>
        /// <param name="ids">要删除的id号们(1,2,5)</param>
        /// <returns>受影响行数</returns>
        public int Del(string ids)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("exec('delete MgrMenu where mgrId in ('+@ids+')')");
            SqlParameter para = new SqlParameter("@ids", ids);
            return SQLHelper.ExcuteNonQuery(strSql.ToString(), para);
        }
        #endregion

        #region 02.2单个物理删除
        /// <summary>
        /// 单个物理删除
        /// </summary>
        /// <param name="idInt">要删除的id号</param>
        /// <returns>受影响行数</returns>
        public int Del(int idInt)
        {
            string strSql = "delete MgrMenu where mgrId = @id";
            SqlParameter para = new SqlParameter("@id", idInt);
            return SQLHelper.ExcuteNonQuery(strSql, para);
        }
        #endregion

        #region 03.根据ID获得实体对象 +MODEL.MgrMenu GetModel(int intId)
        /// <summary>
        /// 根据ID获得实体对象
        /// </summary>
        /// <param name="intId">id值</param>
        /// <returns>实体对象</returns>
        public Company.Model.MgrMenu GetModel(int intId)
        {
            StringBuilder strSql = new StringBuilder("select mgrId,mgrPId,mgrName,mgrLinkUrl,mgrSort,mgrIsDel,mgrAddtime from MgrMenu ");
            strSql.Append(" where mgrId=@intId ");
            Company.Model.MgrMenu model = new Company.Model.MgrMenu();
            DataTable dt = SQLHelper.GetDataTable(strSql.ToString(), new SqlParameter("@intId", intId));
            if (dt.Rows.Count > 0)
            {
                LoadEntityData(model, dt.Rows[0]);
                return model;
            }
            else
            {
                return null;
            }
        }
        #endregion

        #region 04.查询数据集合 +IList<Company.Model.MgrMenu> GetList()
        /// <summary>
        /// 查询数据集合
        /// </summary>
        public IList<Company.Model.MgrMenu> GetList()
        {
            return GetListByWhere("");
        }
        #endregion

        #region 根据where条件查询数据集合 -IList<Company.Model.MgrMenu> GetListByWhere(string strWhere)
        /// <summary>
        /// 根据where条件查询数据集合
        /// </summary>
        internal IList<Company.Model.MgrMenu> GetListByWhere(string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select mgrId,mgrPId,mgrName,mgrLinkUrl,mgrSort,mgrIsDel,mgrAddtime ");
            strSql.Append(" FROM MgrMenu ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            DataTable dt = SQLHelper.GetDataTable(strSql.ToString() + " order by mgrSort asc");
            IList<Company.Model.MgrMenu> list = null;
            if (dt.Rows.Count > 0)
            {
                list = Table2List(dt);
            }
            return list;
        }
        #endregion

        #region a01.将数据表转换成泛型集合接口+ IList<MODEL.MgrMenu> Table2List(DataTable dt)
        /// <summary>
        /// a01.将数据表转换成泛型集合接口
        /// </summary>
        /// <param name="dt">数据表对象</param>
        /// <returns>泛型集合接口</returns>
        public IList<Company.Model.MgrMenu> Table2List(DataTable dt)
        {
            List<Company.Model.MgrMenu> list = null;
            if (dt.Rows.Count > 0)
            {
                list = new List<Company.Model.MgrMenu>();
                Company.Model.MgrMenu model = null;
                foreach (DataRow dr in dt.Rows)
                {
                    model = new Company.Model.MgrMenu();
                    LoadEntityData(model, dr);
                    list.Add(model);
                }
                return list;
            }
            return null;
        }
        #endregion

        #region a04.加载实体数据(将行数据装入实体对象中)-void LoadEntityData(MODEL.BlogArticleCate model, DataRow dr)
        /// <summary>
        /// 加载实体数据(将行数据装入实体对象中)
        /// </summary>
        /// <param name="model">实体对象</param>
        /// <param name="dr">数据行</param>
        internal void LoadEntityData(Company.Model.MgrMenu model, DataRow dr)
        {
            if (dr.Table.Columns.Contains("mgrId") && !dr.IsNull("mgrId"))
            {
                model.MgrId = int.Parse(dr["mgrId"].ToString());
            }
            if (dr.Table.Columns.Contains("mgrPId") && !dr.IsNull("mgrPId"))
            {
                model.MgrPId = int.Parse(dr["mgrPId"].ToString());
            }
            model.MgrName = dr["mgrName"].ToString();
            model.MgrLinkUrl = dr["mgrLinkUrl"].ToString();
            if (dr.Table.Columns.Contains("mgrSort") && !dr.IsNull("mgrSort"))
            {
                model.MgrSort = int.Parse(dr["mgrSort"].ToString());
            }
            if (dr.Table.Columns.Contains("mgrIsDel") && !dr.IsNull("mgrIsDel"))
            {
                model.MgrIsDel = bool.Parse(dr["mgrIsDel"].ToString());
            }
            if (dr.Table.Columns.Contains("mgrAddtime") && !dr.IsNull("mgrAddtime"))
            {
                model.MgrAddtime = DateTime.Parse(dr["mgrAddtime"].ToString());
            }

        }
        #endregion

        #region 07.新增数据 +int Add(MODEL.BlogArticleCate model)
        /// <summary>
        /// 新增数据
        /// </summary>
        /// <param name="model">数据实体对象</param>
        /// <returns>新增成功的ID号</returns>
        public int Add(Company.Model.MgrMenu model)
        {
            int result = 0;
            try
            {
                StringBuilder strSql = new StringBuilder();
                strSql.Append("insert into MgrMenu(");
                strSql.Append("mgrPId,mgrName,mgrLinkUrl,mgrSort,mgrIsDel,mgrAddtime)");
                strSql.Append(" values (");
                strSql.Append("@mgrPId,@mgrName,@mgrLinkUrl,@mgrSort,@mgrIsDel,@mgrAddtime)");
                strSql.Append(";select @@IDENTITY");
                SqlParameter[] parameters = {
                    new SqlParameter("@mgrPId", SqlDbType.Int,4),
                    new SqlParameter("@mgrName", SqlDbType.VarChar,50),
                    new SqlParameter("@mgrLinkUrl", SqlDbType.VarChar,150),
                    new SqlParameter("@mgrSort", SqlDbType.Int,4),
                    new SqlParameter("@mgrIsDel", SqlDbType.Bit,1),
                    new SqlParameter("@mgrAddtime", SqlDbType.DateTime,8)};
                parameters[0].Value = model.MgrPId;
                parameters[1].Value = model.MgrName;
                parameters[2].Value = model.MgrLinkUrl;
                parameters[3].Value = model.MgrSort;
                parameters[4].Value = model.MgrIsDel;
                parameters[5].Value = model.MgrAddtime;
                result = Convert.ToInt32(SQLHelper.ExcuteScalar(strSql.ToString(), parameters));
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return result;
        }
        #endregion

        #region 08.修改
        /// <summary>
        /// 修改
        /// </summary>
        /// <param name="model">数据实体对象</param>
        /// <returns>修改成功的行数</returns>
        public int Update(Company.Model.MgrMenu model)
        {
            int res = -2;
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update MgrMenu set ");
            strSql.Append("mgrPId=@mgrPId,");
            strSql.Append("mgrName=@mgrName,");
            strSql.Append("mgrLinkUrl=@mgrLinkUrl,");
            strSql.Append("mgrSort=@mgrSort,");
            strSql.Append("mgrIsDel=@mgrIsDel,");
            strSql.Append("mgrAddtime=@mgrAddtime");
            strSql.Append(" where mgrId=@mgrId ");
            SqlParameter[] parameters = {
                    new SqlParameter("@mgrId", SqlDbType.Int,4),
                    new SqlParameter("@mgrPId", SqlDbType.Int,4),
                    new SqlParameter("@mgrName", SqlDbType.VarChar,50),
                    new SqlParameter("@mgrLinkUrl", SqlDbType.VarChar,150),
                    new SqlParameter("@mgrSort", SqlDbType.Int,4),
                    new SqlParameter("@mgrIsDel", SqlDbType.Bit,1),
                    new SqlParameter("@mgrAddtime", SqlDbType.DateTime,8)};
            parameters[0].Value = model.MgrId;
            parameters[1].Value = model.MgrPId;
            parameters[2].Value = model.MgrName;
            parameters[3].Value = model.MgrLinkUrl;
            parameters[4].Value = model.MgrSort;
            parameters[5].Value = model.MgrIsDel;
            parameters[6].Value = model.MgrAddtime;

            try
            {
                res = SQLHelper.ExcuteNonQuery(strSql.ToString(), parameters);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return res;
        }
        #endregion

        //-----------------------------------

        #region 1.0 获取所有的 后台菜单 +IList<MODEL.MgrMenu> GetAllMrgMenu()
        /// <summary>
        /// 获取所有的 后台菜单
        /// </summary>
        /// <returns></returns>
        public IList<Model.MgrMenu> GetAllMrgMenu(bool isDel)
        {
            return GetListByWhere(" mgrIsDel = " + (isDel ? "1" : "0"));
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
            return this.GetListByWhere(" mgrPid = " + pid);
        }
        #endregion

        #region 3.0 跟新父菜单 + int UpdateFather(Company.Model.MgrMenu model)
        /// <summary>
        /// 3.0 跟新父菜单
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public int UpdateFather(Company.Model.MgrMenu model)
        {
            int res = -2;
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update MgrMenu set ");
            strSql.Append("mgrName=@mgrName,");
            strSql.Append("mgrSort=@mgrSort");
            strSql.Append(" where mgrId=@mgrId ");
            SqlParameter[] parameters = {
                    new SqlParameter("@mgrId", SqlDbType.Int,4),
                    new SqlParameter("@mgrName", SqlDbType.VarChar,50),
                    new SqlParameter("@mgrSort", SqlDbType.Int,4)};
            parameters[0].Value = model.MgrId;
            parameters[1].Value = model.MgrName;
            parameters[2].Value = model.MgrSort;

            try
            {
                res = SQLHelper.ExcuteNonQuery(strSql.ToString(), parameters);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return res;
        }
        #endregion

        #region 4.0 更新子菜单 + int UpdateSon(Company.Model.MgrMenu model)
        /// <summary>
        /// 4.0 更新子菜单
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public int UpdateSon(Company.Model.MgrMenu model)
        {
            int res = -2;
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update MgrMenu set ");
            strSql.Append("mgrName=@mgrName,");
            strSql.Append("mgrLinkUrl=@mgrLinkUrl,");
            strSql.Append("mgrSort=@mgrSort");
            strSql.Append(" where mgrId=@mgrId ");
            SqlParameter[] parameters = {
                    new SqlParameter("@mgrId", SqlDbType.Int,4),
                    new SqlParameter("@mgrName", SqlDbType.VarChar,50),
                    new SqlParameter("@mgrLinkUrl", SqlDbType.VarChar,150),
                    new SqlParameter("@mgrSort", SqlDbType.Int,4)};
            parameters[0].Value = model.MgrId;
            parameters[1].Value = model.MgrName;
            parameters[2].Value = model.MgrLinkUrl;
            parameters[3].Value = model.MgrSort;

            try
            {
                res = SQLHelper.ExcuteNonQuery(strSql.ToString(), parameters);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return res;
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
            int result = 0;
            try
            {
                StringBuilder strSql = new StringBuilder();
                strSql.Append("insert into MgrMenu(");
                strSql.Append("mgrName,mgrSort)");
                strSql.Append(" values (");
                strSql.Append("@mgrName,@mgrSort)");
                strSql.Append(";select @@IDENTITY");
                SqlParameter[] parameters = {
                    new SqlParameter("@mgrName", SqlDbType.VarChar,50),
                    new SqlParameter("@mgrSort", SqlDbType.Int,4)};
                parameters[0].Value = model.MgrName;
                parameters[1].Value = model.MgrSort;
                result = Convert.ToInt32(SQLHelper.ExcuteScalar(strSql.ToString(), parameters));
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return result;
        }
        #endregion
    }
}
