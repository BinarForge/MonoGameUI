using System.Collections.Generic;
using System.Xml;
using MonoGameUI.Loader.Parsers;
using MonoGameUI.Containers;
using MonoGameUI.Core;
using MonoGameUI.Elements;

namespace MonoGameUI.Loader
{
	public interface IBuilder<T>
	{
		UiContainer FromXml(string _uiXml);
	}

	public class UILoader<T> : IBuilder<T>
	{
		private XmlDocument _xmlDocument = new XmlDocument();

		private Dictionary<string, IElementParser> _elementMapper = new Dictionary<string, IElementParser>
		{
			{ "vertical-container", new ElementParser<VerticalContainer>() },
			{ "horizontal-container", new ElementParser<HorizontalContainer>() },
			{ "text-field", new ElementParser<TextField>() },
			{ "button", new ElementParser<Button>() }
		};
		private Dictionary<string, IAttributeParser> _attributeTranslator = new Dictionary<string, IAttributeParser>
		{
			{ "bg-color", new ColorParser("BgColor") },
			{ "text-color", new ColorParser("TextColor") },
			{ "text", new TextParser("Text") },
			{ "weight", new FloatParser("Weight") },
			{ "margin", new RectangleParser("Margin") },
			{ "text-align", new TextAlignmentParser("TextAlignment") },
			{ "position", new PositionParser("Position") }
		};
		private readonly string _rootElementName = "monoui";

		private void HandleElement(ref UiNode node, XmlNode xmlNode)
		{
			if (_elementMapper.ContainsKey(xmlNode.Name))
				node = _elementMapper[xmlNode.Name].Parse(xmlNode, _attributeTranslator);

			var container = node as UiContainer;
			if (container == null)
				return;

			for(var i=0; i<xmlNode.ChildNodes.Count; i++) {
				var childElement = new UiNode();
				HandleElement(ref childElement, xmlNode.ChildNodes[i]);
				container.AppendChild(childElement);
			}
		}

		public UiContainer FromXml(string _uiXml)
		{
			try {
				_xmlDocument.LoadXml(_uiXml);
			}
			catch {
				return null;
			}

			UiContainer uiTree = new UiContainer();
			var xmlUiDescription = _xmlDocument.ChildNodes[0];

			if (_xmlDocument.ChildNodes == null || _xmlDocument.ChildNodes.Count != 1 || xmlUiDescription.Name != _rootElementName)
				return null;

			for (var i = 0; i < xmlUiDescription.ChildNodes.Count; i++) {
				var childElement = new UiNode();
				HandleElement(ref childElement, xmlUiDescription.ChildNodes[i]);
				uiTree.AppendChild(childElement);
			}

			return uiTree;
		}
	}
}
