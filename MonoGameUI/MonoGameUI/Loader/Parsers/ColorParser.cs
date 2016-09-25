using MonoGameUI.Core.Helpers;

namespace MonoGameUI.Loader.Parsers
{
	internal class ColorParser : BaseAttributeParser
	{
		public ColorParser(string propertyName)
		{
			_propertyName = propertyName;
		}

		public override object ParseAttribute(string attributeValue)
		{
			return HexColor.FromString(attributeValue);
		}
	}
}
