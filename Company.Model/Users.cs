using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Company.Model
{
    public class Users
    {
        public Users()
        { }

        #region 字段们
        protected int _uId;
        protected string _uLoginName;
        protected string _uPwd;
        #endregion

        #region 属性们
        /// <summary>
        /// 
        /// </summary>
        public int UId
        {
            set { _uId = value; }
            get { return _uId; }
        }

        /// <summary>
        /// 
        /// </summary>
        public string ULoginName
        {
            set { _uLoginName = value; }
            get { return _uLoginName; }
        }

        /// <summary>
        /// 
        /// </summary>
        public string UPwd
        {
            set { _uPwd = value; }
            get { return _uPwd; }
        }
        #endregion
    }
}
