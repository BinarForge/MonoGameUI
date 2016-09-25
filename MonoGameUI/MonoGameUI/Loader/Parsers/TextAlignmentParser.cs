using MonoGameUI.Elements;

namespace MonoGameUI.Loader.Parsers
{
	internal class TextAlignmentParser : BaseAttributeParser
	{
		public TextAlignmentParser(string propertyName)
		{
			_propertyName = propertyName;
		}

		public override object ParseAttribute(string attributeValue)
		{
			attributeValue = attributeValue.ToLower();

			if (attributeValue == "center" || attributeValue == "middlecenter")
				return TextAlignment.MiddleCenter;

			return TextAlignment.TopLeft;
		}
	}
}
