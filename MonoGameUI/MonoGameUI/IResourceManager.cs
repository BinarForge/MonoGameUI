using Microsoft.Xna.Framework.Graphics;

namespace MonoGameUI
{
	public interface IResourceManager
	{
		void Initialise();
		SpriteFont GetDefaultFont();
		Texture2D GetDefaultTexture();
	}
}