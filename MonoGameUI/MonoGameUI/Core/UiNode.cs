using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace MonoGameUI.Core
{
	public interface INode
	{
		Position Position { get; set; }
		Rectangle Margin { get; set; }
		float Weight { get; set; }
		void Initialise(UIManager manager);
		void Draw(SpriteBatch batch);
	}

	[System.Serializable]
	public class UiNode : INode
	{
		protected string _id;
		public string ID { get { return _id; } set { _id = value; } }

		protected UIManager _manager;

		public bool Visible { get; set; }
		public float Weight { get; set; }
		public Color BgColor { get; set; }
		public Position Position { get; set; }
		public Rectangle Margin { get; set; }

		private UiNode _parent;
		public UiNode Parent { get { return _parent; } set { _parent = value; } }

		public virtual UiNode FindById(string elementId)
		{
			if (ID == elementId)
				return this;
			
			return null;
		}

		public virtual void Draw(SpriteBatch batch)
		{
		}

		public virtual void Initialise(UIManager manager)
		{
			_manager = manager;
			Visible = true;
		}

		public UiNode()
			: base()
		{
			Position = new Position();
			Margin = new Rectangle();
			Weight = 1.0f;
		}
	}
}
