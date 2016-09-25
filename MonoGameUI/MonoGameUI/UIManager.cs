using Microsoft.Xna.Framework.Graphics;
using MonoGameUI.Core;

namespace MonoGameUI
{
	public class UIManager
	{
		private INode _rootNode;
		private IResourceManager _resources;

		public void SetRootNode(INode rootNode)
		{
			_rootNode = rootNode;
		}

		public void Initialise()
		{
			_rootNode.Initialise(this);
		}

		public void Draw(SpriteBatch spriteBatch)
		{
			_rootNode.Draw(spriteBatch);
		}

		internal Texture2D GetDefaultTexture()
		{
			return _resources?.GetDefaultTexture();
		}

		internal SpriteFont GetDefaultFont()
		{
			return _resources?.GetDefaultFont();
		}

		public void Setup(IResourceManager resourceManager)
		{
			_resources = resourceManager;
		}

		public UIManager(GraphicsDevice graphicsDevice)
		{
		}
	}
}
