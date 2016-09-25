using Microsoft.Xna.Framework;

namespace MonoGameUI.Loader.Parsers
{
	internal class RectangleParser : BaseAttributeParser
	{
		public RectangleParser(string propertyName)
		{
			_propertyName = propertyName;
		}

		public override object ParseAttribute(string attributeValue)
		{
			int[] components = new int[4] { 0, 0, 0, 0 };
			var values = attributeValue.Split(' ');

			for (int i = 0; i < values.Length; i++) {
				try {
					components[i] = int.Parse(values[i]);
				} catch {
					components[i] = 0;
				}
			}

			if (values.Length == 1)
				return new Rectangle(components[0], components[0], components[0], components[0]);

			return new Rectangle(components[0], components[1], components[2], components[3]);
		}
	}
}
