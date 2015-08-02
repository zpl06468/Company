using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Company.Model
{
    public class Menu
    {
        public Menu()
        { }

        #region 字段们
        protected int _mId;
        protected string _mName;
        protected int _mSort;
        protected string _mUrl;
        protected bool _mIsDel;
        protected DateTime _mAddtime;
        #endregion

        #region 属性们
        /// <summary>
        /// 
        /// </summary>
        public int MId
        {
            set { _mId = value; }
            get { return _mId; }
        }

        /// <summary>
        /// 
        /// </summary>
        public string MName
        {
            set { _mName = value; }
            get { return _mName; }
        }

        /// <summary>
        /// 
        /// </summary>
        public int MSort
        {
            set { _mSort = value; }
            get { return _mSort; }
        }

        /// <summary>
        /// 
        /// </summary>
        public string MUrl
        {
            set { _mUrl = value; }
            get { return _mUrl; }
        }

        /// <summary>
        /// 
        /// </summary>
        public bool MIsDel
        {
            set { _mIsDel = value; }
            get { return _mIsDel; }
        }

        /// <summary>
        /// 
        /// </summary>
        public DateTime MAddtime
        {
            set { _mAddtime = value; }
            get { return _mAddtime; }
        }
        #endregion
    }
}
