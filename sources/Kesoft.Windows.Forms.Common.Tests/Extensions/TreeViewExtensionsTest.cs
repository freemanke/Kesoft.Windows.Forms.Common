using System.Windows.Forms;
using NUnit.Framework;

namespace System.Tests.Windows.Forms
{
    [TestFixture]
    public class TreeViewExtensionsTest
    {
        private TreeView view;

        [TestFixtureSetUp]
        public void SetUp()
        {
            view = new TreeView {CheckBoxes = true};

            var node1 = new TreeNode();
            var node2 = new TreeNode();
            var node3 = new TreeNode();

            var node21 = new TreeNode();

            var node31 = new TreeNode();
            var node32 = new TreeNode();

            var node321 = new TreeNode();
            var node322 = new TreeNode();

            view.Nodes.Add(node1);
            view.Nodes.Add(node2);
            view.Nodes.Add(node3);
            node2.Nodes.Add(node21);
            node3.Nodes.Add(node31);
            node3.Nodes.Add(node32);
            node32.Nodes.Add(node321);
            node32.Nodes.Add(node322);
        }

        [Test]
        public void GetChildren()
        {
            SetUp();
            Assert.AreEqual(0, view.Nodes[0].GetChildren().Count);
            Assert.AreEqual(1, view.Nodes[1].GetChildren().Count);
            Assert.AreEqual(2, view.Nodes[2].GetChildren().Count);
        }

        [Test]
        public void GetDesendants()
        {
            SetUp();

            Assert.AreEqual(8, view.GetDescendants().Count);
            Assert.AreEqual(8, view.GetDescendants(false).Count);
            Assert.AreEqual(0, view.GetDescendants(true).Count);

            Assert.AreEqual(0, view.Nodes[0].GetDescendants().Count);
            Assert.AreEqual(1, view.Nodes[1].GetDescendants().Count);
            Assert.AreEqual(4, view.Nodes[2].GetDescendants().Count);

            Assert.AreEqual(0, view.Nodes[0].GetDescendants(false).Count);
            Assert.AreEqual(1, view.Nodes[1].GetDescendants(false).Count);
            Assert.AreEqual(4, view.Nodes[2].GetDescendants(false).Count);

            Assert.AreEqual(0, view.Nodes[0].GetDescendants(true).Count);
            Assert.AreEqual(0, view.Nodes[1].GetDescendants(true).Count);
            Assert.AreEqual(0, view.Nodes[2].GetDescendants(true).Count);
        }

        [Test]
        public void CheckChildren()
        {
            SetUp();

            Assert.AreEqual(1, view.Nodes[1].CheckChildren(true).GetChildren(true).Count);
            Assert.AreEqual(1, view.Nodes[1].CheckChildren(false).GetChildren(false).Count);

            Assert.AreEqual(3, view.CheckChildren(true).GetChildren(true).Count);
            Assert.AreEqual(3, view.CheckChildren(false).GetChildren(false).Count);
        }

        [Test]
        public void CheckDesendants()
        {
            SetUp();

            Assert.AreEqual(1, view.Nodes[1].CheckDescendants(true).GetDescendants(true).Count);
            Assert.AreEqual(1, view.Nodes[1].CheckDescendants(false).GetDescendants(false).Count);

            Assert.AreEqual(8, view.CheckDescendants(true).GetDescendants(true).Count);
            Assert.AreEqual(8, view.CheckDescendants(false).GetDescendants(false).Count);
        }
    }
}
