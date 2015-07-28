﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;

namespace Company.Common
{
    public class PageHelper
    {
        /// <summary>
        /// 读取文件字符串
        /// </summary>
        /// <param name="strPath">文件路径-物理路径</param>
        /// <returns></returns>
        public static string ReadFile(string strPath)
        {
            return System.IO.File.ReadAllText(strPath);
        }

        /// <summary>
        /// 获取提示和跳转 js 代码字符串
        /// </summary>
        /// <param name="strMsg"></param>
        /// <param name="strBackUrl"></param>
        /// <returns></returns>
        public static void WriteJsMsg(string strMsg,string strBackUrl)
        {
            string strBack = "<script>alert('" + strMsg + "');window.location='" + strBackUrl + "';</script>";
            HttpContext.Current.Response.Write(strBack);
        }

        /// <summary>
        /// 获取提示字符串
        /// </summary>
        /// <param name="strMsg"></param>
        /// <param name="strBackUrl"></param>
        /// <returns></returns>
        public static void WriteJsMsg(string strMsg)
        {
            string strBack = "<script>alert('" + strMsg + "');</script>";
            HttpContext.Current.Response.Write(strBack);
        }

        /// <summary>
        /// 将bool值转成 是 / 否
        /// </summary>
        /// <param name="isDelStr"></param>
        /// <returns></returns>
        public static string Bool2CnStr(string isDelStr)
        {
            return isDelStr == "true" ? "是" : "否";
        }
    }
}