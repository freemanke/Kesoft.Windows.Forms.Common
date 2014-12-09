using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace System.Windows.Forms
{
    /// <summary>
    /// 树视图控件扩展。
    /// </summary>
    public static class TreeViewExtensions
    {
        /// <summary>
        /// 获取子节点。
        /// </summary>
        public static List<TreeNode> GetChildren(this TreeNode node)
        {
            return node.Nodes.Cast<TreeNode>().ToList();
        }

        /// <summary>
        /// 获取子节点。
        /// </summary>
        public static List<TreeNode> GetChildren(this TreeView view)
        {
            return view.Nodes.Cast<TreeNode>().ToList();
        }

        /// <summary>
        /// 获取子孙节点。
        /// </summary>
        public static List<TreeNode> GetDescendants(this TreeNode node)
        {
            var nodes = new List<TreeNode>();
            foreach (TreeNode child in node.Nodes)
            {
                nodes.Add(child);
                if (child.Nodes.Count != 0)
                    nodes.AddRange(GetChildren(child));
            }

            return nodes;
        }

        /// <summary>
        /// 获取子孙节点。
        /// </summary>
        public static List<TreeNode> GetDescendants(this TreeView view)
        {
            var nodes = new List<TreeNode>();
            foreach (TreeNode node in view.Nodes)
            {
                nodes.Add(node);
                nodes.AddRange(node.GetDescendants());
            }
            return nodes;
        }

        /// <summary>
        /// 获取选中的子节点。
        /// </summary>
        public static List<TreeNode> GetChildren(this TreeNode node, bool check)
        {
            return node.GetChildren().Where(a => a.Checked == check).ToList();
        }

        /// <summary>
        /// 获取选中的子节点。
        /// </summary>
        public static List<TreeNode> GetChildren(this TreeView view, bool check)
        {
            return view.GetChildren().Where(a => a.Checked == check).ToList();
        }

        /// <summary>
        /// 获取选中的子孙节点。
        /// </summary>
        public static List<TreeNode> GetDescendants(this TreeNode node, bool check)
        {
            var nodes = new List<TreeNode>();
            nodes.AddRange(node.GetDescendants().Where(a => a.Checked == check));

            return nodes;
        }

        /// <summary>
        /// 获取选中的子孙节点。
        /// </summary>
        public static List<TreeNode> GetDescendants(this TreeView view, bool check)
        {
            var nodes = new List<TreeNode>();
            foreach (TreeNode node in view.Nodes)
            {
                if (node.Checked == check) nodes.Add(node);
                if (node.Nodes.Count != 0) nodes.AddRange(node.GetDescendants().Where(a => a.Checked == check));
            }

            return nodes;
        }

        /// <summary>
        /// 设置子节点选中状态。
        /// </summary>
        /// <param name="node"></param>
        /// <param name="check">是否选中。</param>
        public static TreeNode CheckChildren(this TreeNode node, bool check)
        {
            node.GetChildren().ForEach(a => a.Checked = check);
            return node;
        }

        /// <summary>
        /// 设置子节点选中状态。
        /// </summary>
        /// <param name="view"></param>
        /// <param name="check">是否选中。</param>
        public static TreeView CheckChildren(this TreeView view, bool check)
        {
            view.GetChildren(!check).ForEach(a => a.Checked = check);
            return view;
        }

        /// <summary>
        /// 设置子孙节点选中状态。
        /// </summary>
        /// <param name="node"></param>
        /// <param name="check">是否选中。</param>
        public static TreeNode CheckDescendants(this TreeNode node, bool check)
        {
            node.GetDescendants().ForEach(a => a.Checked = check);
            return node;
        }

        /// <summary>
        /// 设置子孙节点选中状态。
        /// </summary>
        /// <param name="view"></param>
        /// <param name="check">是否选中。</param>
        public static TreeView CheckDescendants(this TreeView view, bool check)
        {
            foreach (TreeNode node in view.Nodes)
            {
                node.Checked = check;
                node.CheckDescendants(check);
            }

            return view;
        }
    }
}