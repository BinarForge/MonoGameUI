using Microsoft.Xna.Framework.Graphics;
using MonoGameUI;
using MonoGameUI.Containers;
using MonoGameUI.Elements;
using Microsoft.Xna.Framework;
using MonoGameUI.Core;

namespace MonoGameUi_Examples
{
	public class ExampleNavigation
	{
		UiContainer		_navigation;

		public void Initialise(UIManager manager, int screenWidth, int screenHeight)
		{
			_navigation = new UiContainer();
			_navigation.Position = new Position(0, 0, screenWidth, screenHeight);
			var navContainer = new HorizontalContainer { Position = new Position(0, 90, 50, 100, PositionType.Percentage) };
			navContainer.AppendChild(new TextField {
				Text = "View example\nusing keys",
				TextColor = Color.Wheat,
				TextAlignment = TextAlignment.MiddleCenter,
				BgColor = new Color(33, 33, 33),
				Weight = 1
			});
			navContainer.AppendChild(new TextField {
				Text = "1",
				TextColor = Color.Wheat,
				TextAlignment = TextAlignment.MiddleCenter,
				BgColor = new Color(43, 43, 43),
				Weight = 1
			});
			navContainer.AppendChild(new TextField {
				Text = "2",
				TextColor = Color.Wheat,
				TextAlignment = TextAlignment.MiddleCenter,
				BgColor = new Color(53, 53, 53),
				Weight = 1
			});
			_navigation.AppendChild(navContainer);

			_navigation.Initialise(manager);	
		}

		internal void Set(int v)
		{
			if (_navigation == null)
				return;

			var navButtons = (_navigation.Children[0] as UiContainer).Children;
			for (var i = 0; i < navButtons.Count; i++) {
				(navButtons[i] as TextField).TextColor = (i == v ? Color.GreenYellow : Color.Wheat);
			}
		}

		internal void Draw(SpriteBatch spriteBatch)
		{
			_navigation.Draw(spriteBatch);
		}
	}
}
