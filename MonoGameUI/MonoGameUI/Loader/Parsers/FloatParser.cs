using System.Globalization;

namespace MonoGameUI.Loader.Parsers
{
	internal class FloatParser : BaseAttributeParser
	{
		public FloatParser(string propertyName)
		{
			_propertyName = propertyName;
		}

		public override object ParseAttribute(string attributeValue)
		{
			try {
				return float.Parse(attributeValue, CultureInfo.InvariantCulture);
			} catch {
				return 1.0f;
			}
		}
	}
}
