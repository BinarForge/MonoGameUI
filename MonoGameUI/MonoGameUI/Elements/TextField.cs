using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using MonoGameUI.Core;

namespace MonoGameUI.Elements
{
	public enum TextAlignment { TopLeft, MiddleLeft, BottomLeft, TopCenter, MiddleCenter, BottomCenter, TopRight, MiddleRight, BottomRight };

	public class TextField : UiNode
	{
		public string Text { get; set; }
		public Color TextColor { get; set; }
		public TextAlignment TextAlignment { get; set; }
		protected SpriteFont _font;
		protected Vector2 _textPosition;

		public override void Initialise(UIManager manager)
		{
			base.Initialise(manager);

			_font = _manager?.GetDefaultFont();
			CalculateAlignment();
		}

		private void CalculateAlignment()
		{
			if (_font == null || string.IsNullOrEmpty(Text))
				return;

			if (TextAlignment == TextAlignment.TopLeft)
				_textPosition = new Vector2(Position.Left, Position.Top);
			else if (TextAlignment == TextAlignment.MiddleCenter) {
				var textSize = _font.MeasureString(Text);
				_textPosition = new Vector2(Position.Left + (Position.Right - textSize.X) * 0.5f, Position.Top + (Position.Bottom - textSize.Y) * 0.5f);
			}
		}

		public override void Draw(SpriteBatch batch)
		{
			base.Draw(batch);

			if (Visible && BgColor.A != 0)
				batch.Draw(_manager.GetDefaultTexture(), Position.ToRectangle(), BgColor);

			if (!string.IsNullOrEmpty(Text))
				batch.DrawString(_font, Text, _textPosition, TextColor);
		}

		public void AppendLine(string line)
		{
			Text += line + System.Environment.NewLine;
		}

		public TextField()
			: base()
		{
		}
	}
}
