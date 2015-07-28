using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Company.Model
{
    [Serializable]
   public class MgrMenu
    {
        public MgrMenu()
        { }

        #region 字段们
        protected int _mgrId;
        protected int _mgrPId;
        protected string _mgrName;
        protected string _mgrLinkUrl;
        protected int _mgrSort;
        protected bool _mgrIsDel;
        protected DateTime _mgrAddtime;
        #endregion

        #region 属性们
        /// <summary>
        /// 后台菜单表 id
        /// </summary>
        public int MgrId
        {
            set { _mgrId = value; }
            get { return _mgrId; }
        }

        /// <summary>
        /// 菜单父id
        /// </summary>
        public int MgrPId
        {
            set { _mgrPId = value; }
            get { return _mgrPId; }
        }

        /// <summary>
        /// 菜单名
        /// </summary>
        public string MgrName
        {
            set { _mgrName = value; }
            get { return _mgrName; }
        }

        /// <summary>
        /// 菜单连接地址
        /// </summary>
        public string MgrLinkUrl
        {
            set { _mgrLinkUrl = value; }
            get { return _mgrLinkUrl; }
        }

        /// <summary>
        /// 排序
        /// </summary>
        public int MgrSort
        {
            set { _mgrSort = value; }
            get { return _mgrSort; }
        }

        /// <summary>
        /// 
        /// </summary>
        public bool MgrIsDel
        {
            set { _mgrIsDel = value; }
            get { return _mgrIsDel; }
        }

        /// <summary>
        /// 
        /// </summary>
        public DateTime MgrAddtime
        {
            set { _mgrAddtime = value; }
            get { return _mgrAddtime; }
        }
        #endregion
    }
}
