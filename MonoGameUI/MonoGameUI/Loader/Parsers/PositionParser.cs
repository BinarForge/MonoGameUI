using Microsoft.Xna.Framework;
using MonoGameUI.Core;

namespace MonoGameUI.Loader.Parsers
{
	internal class PositionParser : BaseAttributeParser
	{
		public PositionParser(string propertyName)
		{
			_propertyName = propertyName;
		}

		public override object ParseAttribute(string attributeValue)
		{
			if (attributeValue.Contains("%")) {
				var percentages = (Rectangle)(new RectangleParser(string.Empty).ParseAttribute(attributeValue.Replace("%", string.Empty)));
				return new Position(percentages.X, percentages.Y, percentages.Width, percentages.Height, PositionType.Percentage);
			}

			var values = (Rectangle)(new RectangleParser(string.Empty).ParseAttribute(attributeValue));
			return new Position(values);
		}
	}
}
