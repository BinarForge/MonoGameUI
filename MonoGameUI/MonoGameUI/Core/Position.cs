using Microsoft.Xna.Framework;

namespace MonoGameUI.Core
{
	public enum PositionType { Weight, Percentage };

	public class Position
	{
		protected Rectangle _rectangle = new Rectangle();

		public int Left { get { return _rectangle.X; } set { _rectangle.X = value; } }
		public int Top { get { return _rectangle.Y; } set { _rectangle.Y = value; } }
		public int Right { get { return _rectangle.Width; } set { _rectangle.Width = value; } }
		public int Bottom { get { return _rectangle.Height; } set { _rectangle.Height = value; } }

		public PositionType Type { get; set; }
		public bool Zero { get { return _rectangle.Location == Point.Zero && _rectangle.Size == Point.Zero; } }

		public Rectangle ToRectangle()
		{
			return _rectangle;
		}

		public bool Contains(int x, int y)
		{
			return _rectangle.Contains(x, y);
		}

		public bool Contains(Point point)
		{
			return Contains(point.X, point.Y);
		}

		public Position(int left = 0, int top = 0, int right = 0, int bottom = 0, PositionType type = PositionType.Weight)
		{
			Left = left;
			Top = top;
			Right = right;
			Bottom = bottom;
			Type = type;
		}

		public Position(Rectangle rectangle)
			:this(rectangle.X, rectangle.Y, rectangle.Width, rectangle.Height)
		{
		}

		public override string ToString()
		{
			return _rectangle.ToString();
		}
	}
}
