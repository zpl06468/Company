﻿using Company.Common;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;

namespace Company.DAL
{
    public class Menu
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
            strSql.Append("exec('update Menu set mIsDel=''" + isDel.ToString() + "'' where mId in ('+@ids+')')");
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
            string strSql = "update Menu set mIsDel='" + isDel.ToString() + "' where mId = @id";
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
            strSql.Append("exec('delete Menu where mId in ('+@ids+')')");
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
            string strSql = "delete Menu where mId = @id";
            SqlParameter para = new SqlParameter("@id", idInt);
            return SQLHelper.ExcuteNonQuery(strSql, para);
        }
        #endregion

        #region 03.根据ID获得实体对象 +MODEL.Menu GetModel(int intId)
        /// <summary>
        /// 根据ID获得实体对象
        /// </summary>
        /// <param name="intId">id值</param>
        /// <returns>实体对象</returns>
        public Company.Model.Menu GetModel(int intId)
        {
            StringBuilder strSql = new StringBuilder("select mId,mName,mSort,mUrl,mIsDel,mAddtime from Menu ");
            strSql.Append(" where mId=@intId ");
            Company.Model.Menu model = new Company.Model.Menu();
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

        #region 04.查询数据集合 +IList<Company.Model.Menu> GetList()
        /// <summary>
        /// 查询数据集合
        /// </summary>
        public IList<Company.Model.Menu> GetList()
        {
            return GetListByWhere("");
        }
        #endregion

        #region 根据where条件查询数据集合 -IList<Company.Model.Menu> GetListByWhere(string strWhere)
        /// <summary>
        /// 根据where条件查询数据集合
        /// </summary>
        internal IList<Company.Model.Menu> GetListByWhere(string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select mId,mName,mSort,mUrl,mIsDel,mAddtime ");
            strSql.Append(" FROM Menu ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            DataTable dt = SQLHelper.GetDataTable(strSql.ToString());
            IList<Company.Model.Menu> list = null;
            if (dt.Rows.Count > 0)
            {
                list = Table2List(dt);
            }
            return list;
        }
        #endregion

        #region a01.将数据表转换成泛型集合接口+ IList<MODEL.Menu> Table2List(DataTable dt)
        /// <summary>
        /// a01.将数据表转换成泛型集合接口
        /// </summary>
        /// <param name="dt">数据表对象</param>
        /// <returns>泛型集合接口</returns>
        public IList<Company.Model.Menu> Table2List(DataTable dt)
        {
            List<Company.Model.Menu> list = null;
            if (dt.Rows.Count > 0)
            {
                list = new List<Company.Model.Menu>();
                Company.Model.Menu model = null;
                foreach (DataRow dr in dt.Rows)
                {
                    model = new Company.Model.Menu();
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
        internal void LoadEntityData(Company.Model.Menu model, DataRow dr)
        {
            if (dr.Table.Columns.Contains("mId") && !dr.IsNull("mId"))
            {
                model.MId = int.Parse(dr["mId"].ToString());
            }
            model.MName = dr["mName"].ToString();
            if (dr.Table.Columns.Contains("mSort") && !dr.IsNull("mSort"))
            {
                model.MSort = int.Parse(dr["mSort"].ToString());
            }
            model.MUrl = dr["mUrl"].ToString();
            if (dr.Table.Columns.Contains("mIsDel") && !dr.IsNull("mIsDel"))
            {
                model.MIsDel = bool.Parse(dr["mIsDel"].ToString());
            }
            if (dr.Table.Columns.Contains("mAddtime") && !dr.IsNull("mAddtime"))
            {
                model.MAddtime = DateTime.Parse(dr["mAddtime"].ToString());
            }

        }
        #endregion

        #region 07.新增数据 +int Add(MODEL.BlogArticleCate model)
        /// <summary>
        /// 新增数据
        /// </summary>
        /// <param name="model">数据实体对象</param>
        /// <returns>新增成功的ID号</returns>
        public int Add(Company.Model.Menu model)
        {
            int result = 0;
            try
            {
                StringBuilder strSql = new StringBuilder();
                strSql.Append("insert into Menu(");
                strSql.Append("mName,mSort,mUrl)");
                strSql.Append(" values (");
                strSql.Append("@mName,@mSort,@mUrl)");
                strSql.Append(";select @@IDENTITY");
                SqlParameter[] parameters = {
                    new SqlParameter("@mName", SqlDbType.VarChar,50),
                    new SqlParameter("@mSort", SqlDbType.Int,4),
                    new SqlParameter("@mUrl", SqlDbType.VarChar,150)};
                parameters[0].Value = model.MName;
                parameters[1].Value = model.MSort;
                parameters[2].Value = model.MUrl;
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
        public int Update(Company.Model.Menu model)
        {
            int res = -2;
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update Menu set ");
            strSql.Append("mName=@mName,");
            strSql.Append("mSort=@mSort,");
            strSql.Append("mUrl=@mUrl");
            strSql.Append(" where mId=@mId ");
            SqlParameter[] parameters = {
                    new SqlParameter("@mId", SqlDbType.Int,4),
                    new SqlParameter("@mName", SqlDbType.VarChar,50),
                    new SqlParameter("@mSort", SqlDbType.Int,4),
                    new SqlParameter("@mUrl", SqlDbType.VarChar,150)};
            parameters[0].Value = model.MId;
            parameters[1].Value = model.MName;
            parameters[2].Value = model.MSort;
            parameters[3].Value = model.MUrl;

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
    }
}
