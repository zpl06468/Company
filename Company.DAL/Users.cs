using Company.Common;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;

namespace Company.DAL
{
   public class Users
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
            strSql.Append("exec('update Users set noDelKey=''" + isDel.ToString() + "'' where uId in ('+@ids+')')");
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
            string strSql = "update Users set noDelKey='" + isDel.ToString() + "' where uId = @id";
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
            strSql.Append("exec('delete Users where uId in ('+@ids+')')");
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
            string strSql = "delete Users where uId = @id";
            SqlParameter para = new SqlParameter("@id", idInt);
            return SQLHelper.ExcuteNonQuery(strSql, para);
        }
        #endregion

        #region 03.根据ID获得实体对象 +Model.Users GetModel(int intId)
        /// <summary>
        /// 根据ID获得实体对象
        /// </summary>
        /// <param name="intId">id值</param>
        /// <returns>实体对象</returns>
        public Company.Model.Users GetModel(int intId)
        {
            StringBuilder strSql = new StringBuilder("select uId,uLoginName,uPwd from Users ");
            strSql.Append(" where uId=@intId ");
            Company.Model.Users Model = new Company.Model.Users();
            DataTable dt = SQLHelper.GetDataTable(strSql.ToString(), new SqlParameter("@intId", intId));
            if (dt.Rows.Count > 0)
            {
                LoadEntityData(Model, dt.Rows[0]);
                return Model;
            }
            else
            {
                return null;
            }
        }
        #endregion

        #region 04.查询数据集合 +IList<Company.Model.Users> GetList()
        /// <summary>
        /// 查询数据集合
        /// </summary>
        public IList<Company.Model.Users> GetList()
        {
            return GetListByWhere("");
        }
        #endregion

        #region 根据where条件查询数据集合 -IList<Company.Model.Users> GetListByWhere(string strWhere)
        /// <summary>
        /// 根据where条件查询数据集合
        /// </summary>
        internal IList<Company.Model.Users> GetListByWhere(string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select uId,uLoginName,uPwd ");
            strSql.Append(" FROM Users ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            DataTable dt = SQLHelper.GetDataTable(strSql.ToString());
            IList<Company.Model.Users> list = null;
            if (dt.Rows.Count > 0)
            {
                list = Table2List(dt);
            }
            return list;
        }
        #endregion

        #region a01.将数据表转换成泛型集合接口+ IList<Model.Users> Table2List(DataTable dt)
        /// <summary>
        /// a01.将数据表转换成泛型集合接口
        /// </summary>
        /// <param name="dt">数据表对象</param>
        /// <returns>泛型集合接口</returns>
        public IList<Company.Model.Users> Table2List(DataTable dt)
        {
            List<Company.Model.Users> list = null;
            if (dt.Rows.Count > 0)
            {
                list = new List<Company.Model.Users>();
                Company.Model.Users Model = null;
                foreach (DataRow dr in dt.Rows)
                {
                    Model = new Company.Model.Users();
                    LoadEntityData(Model, dr);
                    list.Add(Model);
                }
                return list;
            }
            return null;
        }
        #endregion

        #region a04.加载实体数据(将行数据装入实体对象中)-void LoadEntityData(Model.BlogArticleCate Model, DataRow dr)
        /// <summary>
        /// 加载实体数据(将行数据装入实体对象中)
        /// </summary>
        /// <param name="Model">实体对象</param>
        /// <param name="dr">数据行</param>
        internal void LoadEntityData(Company.Model.Users Model, DataRow dr)
        {
            if (dr.Table.Columns.Contains("uId") && !dr.IsNull("uId"))
            {
                Model.UId = int.Parse(dr["uId"].ToString());
            }
            Model.ULoginName = dr["uLoginName"].ToString();
            Model.UPwd = dr["uPwd"].ToString();

        }
        #endregion

        #region 07.新增数据 +int Add(Model.BlogArticleCate Model)
        /// <summary>
        /// 新增数据
        /// </summary>
        /// <param name="Model">数据实体对象</param>
        /// <returns>新增成功的ID号</returns>
        public int Add(Company.Model.Users Model)
        {
            int result = 0;
            try
            {
                StringBuilder strSql = new StringBuilder();
                strSql.Append("insert into Users(");
                strSql.Append("uLoginName,uPwd)");
                strSql.Append(" values (");
                strSql.Append("@uLoginName,@uPwd)");
                strSql.Append(";select @@IDENTITY");
                SqlParameter[] parameters = {
                    new SqlParameter("@uLoginName", SqlDbType.VarChar,50),
                    new SqlParameter("@uPwd", SqlDbType.VarChar,32)};
                parameters[0].Value = Model.ULoginName;
                parameters[1].Value = Model.UPwd;
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
        /// <param name="Model">数据实体对象</param>
        /// <returns>修改成功的行数</returns>
        public int Update(Company.Model.Users Model)
        {
            int res = -2;
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update Users set ");
            strSql.Append("uLoginName=@uLoginName,");
            strSql.Append("uPwd=@uPwd");
            strSql.Append(" where uId=@uId ");
            SqlParameter[] parameters = {
                    new SqlParameter("@uId", SqlDbType.Int,4),
                    new SqlParameter("@uLoginName", SqlDbType.VarChar,50),
                    new SqlParameter("@uPwd", SqlDbType.VarChar,32)};
            parameters[0].Value = Model.UId;
            parameters[1].Value = Model.ULoginName;
            parameters[2].Value = Model.UPwd;

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

        //-------------------------------------------------------
        #region 1.0 根据用户登录名 查询用户 + Model.Users Login(string strLoginName)
        /// <summary>
        /// 根据用户登录名 查询用户
        /// </summary>
        /// <param name="strLoginName"></param>
        /// <returns></returns>
        public Company.Model.Users Login(string strLoginName)
        {
            DataTable dt = SQLHelper.GetDataTable("select * from Users where uLoginName=@uLoginName", new SqlParameter("@uLoginName", strLoginName));
            if (dt != null && dt.Rows.Count > 0)
            {
                Company.Model.Users userModel = new Company.Model.Users();
                LoadEntityData(userModel, dt.Rows[0]);
                return userModel;
            }
            return null;
        }
        #endregion
    }
}
