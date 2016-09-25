using Microsoft.Xna.Framework.Graphics;
using MonoGameUI.Containers;
using MonoGameUI.Core;
using MonoGameUI.Loader;
using System.IO;

namespace MonoGameUI
{
	public class UIManager
	{
		private INode _rootNode;
		private IResourceManager _resources;
		private GraphicsDevice _graphicsDevice;

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
			_graphicsDevice = graphicsDevice;
		}

		public bool Load(string uiFilePath)
		{
			var builder = new UILoader<UiContainer>();
			var sr = new StreamReader(File.OpenRead(uiFilePath));
			try {
				_rootNode = builder.FromXml(sr.ReadToEnd());
				_rootNode.Position = new Position(0, 0, _graphicsDevice.PresentationParameters.Bounds.Width, _graphicsDevice.PresentationParameters.Bounds.Height);
				Initialise();
			}
			catch {
				return false;
			}

			return true;
		}
	}
}
