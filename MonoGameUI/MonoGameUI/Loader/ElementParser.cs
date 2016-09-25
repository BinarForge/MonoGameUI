using MonoGameUI.Core;
using MonoGameUI.Loader.Parsers;
using System.Collections.Generic;
using System.Xml;

namespace MonoGameUI.Loader
{
	internal interface IElementParser
	{
		UiNode Parse(XmlNode xmlNode, Dictionary<string, IAttributeParser> _attributeTranslator);
	}

	internal class ElementParser<T> : IElementParser where T : UiNode, new()
	{
		public UiNode Parse(XmlNode elementInfo, Dictionary<string, IAttributeParser> _attributeTranslator)
		{
			var element = new T();

			for (int i = 0; i < elementInfo.Attributes.Count; i++) {
				var attr = elementInfo.Attributes[i];

				if (!_attributeTranslator.ContainsKey(attr.Name))
					continue;

				var property = element.GetType().GetProperty(_attributeTranslator[attr.Name].GetPropertyName());
				if (property == null)
					continue;

				property.SetValue(element, _attributeTranslator[attr.Name].ParseAttribute(attr.Value), null);
			}

			return element;
		}
	}
}
