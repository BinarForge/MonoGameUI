using NUnit.Framework;
using MonoGameUI.Core;
using MonoGameUI.Containers;
using MonoGameUI.Elements;

namespace MonoUILibraryTests
{
	[TestFixture]
	public class UILayout_GivenAVerticalContainerAndTwoChildElements
	{
		private UiContainer _rootNode;
		UiNode _node1;
		UiNode _node2;

		[SetUp]
		public void SetUp()
		{
			_rootNode = new VerticalContainer();
			_rootNode.Position = new Position(0, 0, 800, 600);

			_node1 = new TextField();
			_node1.Weight = 2.5f;
			_node2 = new TextField();
			_node2.Weight = 7.5f;

			_rootNode.AppendChild(_node1);
			_rootNode.AppendChild(_node2);

			_rootNode.Initialise(null);
		}

		[Test]
		public void TheVerticalChildCountIsUpdatedAfterAppending()
		{
			Assert.AreEqual(_rootNode.ChildCount, 2);
		}

		[Test]
		public void TheVerticalPositionIsCalculatedCorrectly()
		{
			Assert.AreEqual(0, _node1.Position.Top);
			Assert.AreEqual(150, _node2.Position.Top);

			Assert.AreEqual(150, _node1.Position.Bottom);
			Assert.AreEqual(450, _node2.Position.Bottom);
		}
	}

	[TestFixture]
	public class UILayout_GivenAHorizontalContainerAndTwoChildElements
	{
		private UiContainer _rootNode;
		UiNode _node1;
		UiNode _node2;
		UiNode _node3;

		[SetUp]
		public void SetUp()
		{
			_rootNode = new HorizontalContainer();
			_rootNode.Position = new Position(0, 0, 800, 600);
			_node1 = new TextField();
			_node1.Weight = 1.0f;
			_node2 = new TextField();
			_node2.Weight = 1.0f;
			_node3 = new TextField();
			_node3.Weight = 8.0F;

			_rootNode.AppendChild(_node1);
			_rootNode.AppendChild(_node2);
			_rootNode.AppendChild(_node3);

			_rootNode.Initialise(null);
		}

		[Test]
		public void TheHorizontalChildCountIsUpdatedAfterAppending()
		{
			Assert.AreEqual(_rootNode.ChildCount, 3);
		}

		[Test]
		public void TheHorizontalPositionIsCalculatedCorrectly()
		{
			Assert.AreEqual(0, _node1.Position.Left);
			Assert.AreEqual(80, _node2.Position.Left);
			Assert.AreEqual(160, _node3.Position.Left);

			Assert.AreEqual(80, _node1.Position.Right);
			Assert.AreEqual(80, _node2.Position.Right);
			Assert.AreEqual(640, _node3.Position.Right);
		}
	}
	[TestFixture]
	public class UILayout_GivenAHorizontalContainerAndInnerContainer
	{
		private UiContainer _rootNode;
		private UiContainer _innerContainer;
		UiNode _node1;
		UiNode _node2Inner;
		UiNode _node3;

		UiNode _node4Inner;

		[SetUp]
		public void SetUp()
		{
			_rootNode = new HorizontalContainer();
			_rootNode.Position = new Position(0, 0, 800, 600);
			_node1 = new TextField();
			_node1.Weight = 2.5f;
			_innerContainer = new VerticalContainer();
			_innerContainer.Weight = 5.0f;
			_node3 = new TextField();
			_node3.Weight = 2.5f;

			_rootNode.AppendChild(_node1);
			_rootNode.AppendChild(_innerContainer);
			_rootNode.AppendChild(_node3);

			_node2Inner = new TextField();
			_node2Inner.Weight = 1.0f;
			_node4Inner = new TextField();
			_node4Inner.Weight = 3.0f;
			_innerContainer.AppendChild(_node2Inner);
			_innerContainer.AppendChild(_node4Inner);

			_rootNode.Initialise(null);
		}

		[Test]
		public void TheHorizontalChildCountIsUpdatedAfterAppending()
		{
			Assert.AreEqual(_rootNode.ChildCount, 3);
		}

		[Test]
		public void TheInnerVerticalChildCountIsUpdatedAfterAppending()
		{
			Assert.AreEqual(_innerContainer.ChildCount, 2);
		}

		[Test]
		public void TheInnerContainerPositionIsCalculatedCorrectly()
		{
			Assert.AreEqual(200, _innerContainer.Position.Left);
			Assert.AreEqual(400, _innerContainer.Position.Right);
		}

		[Test]
		public void TheInnerNodePositionIsCalculatedCorrectly()
		{
			Assert.AreEqual(0, _node2Inner.Position.Top);
			Assert.AreEqual(150, _node2Inner.Position.Bottom);

			Assert.AreEqual(150, _node4Inner.Position.Top);
			Assert.AreEqual(450, _node4Inner.Position.Bottom);
		}
	}
}
