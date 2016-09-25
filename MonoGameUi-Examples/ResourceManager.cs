using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using MonoGameUI;

namespace MonoGameUi_Examples
{
	public class ResourceManager : IResourceManager
	{
		private GraphicsDevice _gd;
		private Texture2D _defaultTexture = null;
		private SpriteFont _defaultFont = null;

		public ResourceManager(GraphicsDevice gd, SpriteFont defaultFont)
		{
			_gd = gd;
			_defaultTexture = _defaultTexture = new Texture2D(gd, 1, 1);
			_defaultTexture.SetData(new Color[] { Color.White });

			_defaultFont = defaultFont;
		}

		public void Initialise()
		{
			_defaultFont.LineSpacing = 15;
		}

		public SpriteFont GetDefaultFont()
		{
			return _defaultFont;
		}

		public Texture2D GetDefaultTexture()
		{
			return _defaultTexture;
		}
	}
}
