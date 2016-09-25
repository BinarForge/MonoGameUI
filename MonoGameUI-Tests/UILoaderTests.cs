using Microsoft.Xna.Framework;
using MonoGameUI.Containers;
using MonoGameUI.Core;
using MonoGameUI.Elements;
using MonoGameUI.Loader;
using NUnit.Framework;

namespace MonoUILibraryTests
{
	[TestFixture]
	public class GivenASingleRootUIElementInXml
	{
		UILoader<UiNode>    _uiLoader;
		string              _uiXml;

		[SetUp]
		public void SetUp()
		{
			_uiXml = "<monoui><vertical-container></vertical-container></monoui>";
			_uiLoader = new UILoader<UiNode>();
		}

		[Test]
		public void ThenTheUiTreeBeginsWithAContainerAndHasNoChildren()
		{
			var result = (_uiLoader.FromXml(_uiXml) as UiContainer)?.Children[0] as UiContainer;

			Assert.AreEqual(0, result.ChildCount);
			Assert.That(result is VerticalContainer, Is.True);
		}
	}

	[TestFixture]
	public class GivenAnInvalidXmlUIDescription
	{
		UILoader<UiNode>    _uiLoader;

		[SetUp]
		public void SetUp()
		{
			_uiLoader = new UILoader<UiNode>();
		}

		[TestCase("<other-crap>abc")]
		[TestCase("<other-crap></other-crap>")]
		public void ThenTheUiTreeIsEmpty(string uiXml)
		{
			var result = (_uiLoader.FromXml(uiXml) as UiContainer)?.Children[0];

			Assert.That(result == null, Is.True);
		}
	}

	[TestFixture]
	public class GivenARootElementAndTwoChildrenElements
	{
		UILoader<UiNode>    _uiLoader;
		string              _uiXml;

		[SetUp]
		public void SetUpUsingShortSingleTags()
		{
			_uiXml = "<monoui><horizontal-container><text-field/><button/></horizontal-container></monoui>";
			_uiLoader = new UILoader<UiNode>();
		}

		[Test]
		public void ThenTheUiTreeBeginsWithAContainerAndHasTwoChildren()
		{
			var result = (_uiLoader.FromXml(_uiXml) as UiContainer)?.Children[0] as UiContainer;

			Assert.AreEqual(2, result.ChildCount);
			Assert.That(result is HorizontalContainer, Is.True);
			Assert.That(result.Children[0] is TextField, Is.True);
			Assert.That(result.Children[1] is Button, Is.True);
		}
	}

	[TestFixture]
	public class GivenARootElementAndMultiLevelHierarchy
	{
		UILoader<UiNode>    _uiLoader;
		string              _uiXml;

		[SetUp]
		public void SetUp()
		{
			_uiXml = "<monoui><horizontal-container><vertical-container><button></button></vertical-container><vertical-container><text-field></text-field></vertical-container></horizontal-container></monoui>";
			_uiLoader = new UILoader<UiNode>();
		}

		[Test]
		public void ThenTheUiTreeBeginsWithAContainerAndHasMultipleChildren()
		{
			var result = (_uiLoader.FromXml(_uiXml) as UiContainer)?.Children[0] as UiContainer;

			Assert.AreEqual(2, result.ChildCount);
			Assert.That(result is HorizontalContainer, Is.True);

			Assert.That(result.Children[0] is VerticalContainer, Is.True);
			Assert.That(result.Children[1] is VerticalContainer, Is.True);

			Assert.That((result.Children[0] as VerticalContainer).Children[0] is Button, Is.True);
			Assert.That((result.Children[1] as VerticalContainer).Children[0] is TextField, Is.True);
		}
	}

	[TestFixture]
	public class GivenARootElementAndTwoChildrenElementsWithAttributes
	{
		UILoader<UiNode>    _uiLoader;
		string              _uiXml;

		[SetUp]
		public void SetUp()
		{
			_uiXml = "<monoui><horizontal-container bg-color='#ff0000'><text-field text='test' weight='1.0'></text-field><button weight='3.0' text='click me' bg-color='#0000ff'></button></horizontal-container></monoui>";
			_uiLoader = new UILoader<UiNode>();
		}

		[Test]
		public void ThenTheUiTreeBeginsWithAContainerAndHasTwoChildren()
		{
			var result = (_uiLoader.FromXml(_uiXml) as UiContainer)?.Children[0] as UiContainer;

			Assert.AreEqual(2, result.ChildCount);
			Assert.AreEqual(result.BgColor, Color.Red);
			Assert.AreEqual("test", (result.Children[0] as TextField)?.Text);
			Assert.AreEqual("click me", (result.Children[1] as Button)?.Text);
			Assert.AreEqual(1.0f, (result.Children[0] as TextField)?.Weight);
			Assert.AreEqual(3.0f, (result.Children[1] as Button)?.Weight);
		}
	}

	[TestFixture]
	public class GivenTheColorAttributeInHex
	{
		UILoader<UiNode>    _uiLoader = new UILoader<UiNode>();

		[TestCase("#fff", 255, 255, 255)]
		[TestCase("#ffffff", 255, 255, 255)]
		[TestCase("#000", 0, 0, 0)]
		[TestCase("#000000", 0, 0, 0)]
		[TestCase("#bfde2a", 191, 222, 42)]
		[TestCase("#xyz012", 0, 0, 18)]
		[TestCase("#qwqrty", 0, 0, 0)]
		[TestCase("test23", 0, 0, 0)]
		public void ThenTheUiElementHasBgColorConvertedCorrectly(string hexColor, int r, int g, int b)
		{
			var uiXml = $"<monoui><horizontal-container bg-color='{hexColor}' /></monoui>";
			var result = ((_uiLoader.FromXml(uiXml) as UiContainer)?.Children[0] as UiContainer);

			Assert.That(result is HorizontalContainer, Is.True);
			Assert.AreEqual(r, result.BgColor.R);
			Assert.AreEqual(g, result.BgColor.G);
			Assert.AreEqual(b, result.BgColor.B);
		}
	}

	[TestFixture]
	public class GivenTheMarginAttribute
	{
		UILoader<UiNode>    _uiLoader = new UILoader<UiNode>();

		[TestCase("0", 0, 0, 0, 0)]
		[TestCase("10", 10, 10, 10, 10)]
		[TestCase("10 20", 10, 20, 0, 0)]
		[TestCase("10 20 30", 10, 20, 30, 0)]
		[TestCase("10 20 30 40", 10, 20, 30, 40)]
		public void ThenTheUiElementHasMarginParsedCorrectly(string marginValue, int a, int b, int c, int d)
		{
			var uiXml = $"<monoui><vertical-container margin='{marginValue}' /></monoui>";
			var result = (_uiLoader.FromXml(uiXml) as UiContainer).Children[0];

			Assert.That(result is VerticalContainer, Is.True);
			Assert.AreEqual(a, result.Margin.X);
			Assert.AreEqual(b, result.Margin.Y);
			Assert.AreEqual(c, result.Margin.Width);
			Assert.AreEqual(d, result.Margin.Height);
		}
	}

	[TestFixture]
	public class GivenTheTextAlignmentAttribute
	{
		UILoader<UiNode>    _uiLoader = new UILoader<UiNode>();

		[TestCase("", TextAlignment.TopLeft)]
		[TestCase("MiddleCenter", TextAlignment.MiddleCenter)]
		[TestCase("center", TextAlignment.MiddleCenter)]
		[TestCase("topleft", TextAlignment.TopLeft)]
		public void ThenTheUiElementHasMarginParsedCorrectly(string attrValue, TextAlignment expected)
		{
			var uiXml = $"<monoui><vertical-container><text-field text-align='{attrValue}' /></vertical-container></monoui>";
			var result = (_uiLoader.FromXml(uiXml) as UiContainer)?.Children[0] as UiContainer;

			Assert.That(result is VerticalContainer, Is.True);
			Assert.AreEqual(1, result.Children.Count);
			Assert.AreEqual(expected, (result.Children[0] as TextField)?.TextAlignment);
		}
	}
}
