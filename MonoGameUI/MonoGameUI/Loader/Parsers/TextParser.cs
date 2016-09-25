namespace MonoGameUI.Loader.Parsers
{
	internal class TextParser : BaseAttributeParser
	{
		public TextParser(string propertyName)
		{
			_propertyName = propertyName;
		}

		public override object ParseAttribute(string attributeValue)
		{
			return attributeValue;
		}
	}
}
