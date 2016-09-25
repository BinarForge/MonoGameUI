using Microsoft.Xna.Framework;

namespace MonoGameUI.Core.Helpers
{
	public class HexColor
	{
		private static readonly Color _default = Color.Black;

		private static int hex2dec(char character)
		{
			if(character >= '0' && character <= '9')
				return (character - '0');
			if (character >= 'a' && character <= 'f')
				return 10 + (character - 'a');

			return 0;
		}

		public static Color FromString(string hexColor)
		{
			var color = _default;
			hexColor = hexColor.ToLower();

			if (hexColor[0] != '#')
				return color;
			
			if(hexColor.Length == 4) {
				color = new Color(
					16 * hex2dec(hexColor[1]) + hex2dec(hexColor[1]), 
					16 * hex2dec(hexColor[2]) + hex2dec(hexColor[2]),
					16 * hex2dec(hexColor[3]) + hex2dec(hexColor[3])
				);
			}
			else if(hexColor.Length == 7) {
				color = new Color(
					16 * hex2dec(hexColor[1]) + (hex2dec(hexColor[2])),
					16 * hex2dec(hexColor[3]) + (hex2dec(hexColor[4])),
					16 * hex2dec(hexColor[5]) + (hex2dec(hexColor[6])) 
				);
			}

			return color;
		}
	}
}
