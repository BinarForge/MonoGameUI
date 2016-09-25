using Microsoft.Xna.Framework;

namespace MonoGameUI.Elements
{
	public enum ElementState { Idle = 0, MouseDown = 1, Hover = 2};

	public class Button : TextField
	{
		public override void Initialise(UIManager manager)
		{
			base.Initialise(manager);
		}

		public Button()
			: base()
		{
			BgColor = Color.White;
			Margin = Rectangle.Empty;
		}
	}
}
