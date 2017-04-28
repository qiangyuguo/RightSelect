using System;
using System.Data;
using System.Collections.Generic;

namespace Com.ZY.JXKK.Json
{

    /// <summary>
    /// 树
    /// </summary>
    /// <typeparam name="T">节点类型</typeparam>
    public class Tree<T>
    {

        /// <summary>
        /// 节点名称
        /// </summary>
        public string text = "";

        /// <summary>
        /// 节点状态
        /// </summary>
        public string state = "open";

        /// <summary>
        /// 复选框状态
        /// </summary>
        public bool need_to_json_checked = false;

        /// <summary>
        /// 节点其他属性
        /// </summary>
        public T attributes;

        /// <summary>
        /// 子树
        /// </summary>
        public List<Tree<T>> children = new List<Tree<T>>();
    }
}