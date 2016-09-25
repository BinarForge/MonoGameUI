using Microsoft.Xna.Framework.Graphics;
using MonoGameUI.Core;
using System;
using System.Collections.Generic;

namespace MonoGameUI.Containers
{
	public class UiContainer : UiNode
	{
		protected List<UiNode>	_children = new List<UiNode>();
		public List<UiNode>		Children { get { return _children; } }
		public int				ChildCount { get { return _children.Count; } }

		protected float			SumOfWeight { get { var sum = 0.0f; foreach (var childNode in _children) sum += childNode.Weight; return sum; } }

		public void AppendChild(UiNode childNode)
		{ 
			_children.Add(childNode);
			childNode.Parent = this;
		}

		public void UpdatePosition()
		{
			if (Parent == null)
				return;

			var parentPosition = Parent.Position;


			if (Position.Zero)
				Position = parentPosition;
			else if (Position.Type == PositionType.Percentage)
				Position = new Position(
					Position.Left < 100 ? (int)Math.Ceiling(parentPosition.Right * 0.01f * Position.Left) : parentPosition.Left,
					Position.Top < 100 ? (int)Math.Ceiling(parentPosition.Bottom * 0.01f * Position.Top) : parentPosition.Top,
					Position.Right < 100 ? (int)Math.Ceiling(parentPosition.Right * 0.01f * Position.Right) - (int)Math.Ceiling(parentPosition.Right * 0.01f * Position.Left) : parentPosition.Right,
					Position.Bottom < 100 ? (int)Math.Ceiling(parentPosition.Bottom * 0.01f * Position.Bottom) - (int)Math.Ceiling(parentPosition.Bottom * 0.01f * Position.Top) : parentPosition.Bottom
				);
		}

		public override void Draw(SpriteBatch batch)
		{
			if (!Visible)
				return;
						
			if (Visible && BgColor.A != 0)
				batch.Draw(_manager.GetDefaultTexture(), Position.ToRectangle(), BgColor);

			foreach (var childNode in _children)
				childNode.Draw(batch);
		}

		public override void Initialise(UIManager manager)
		{
			base.Initialise(manager);

			foreach (var childNode in _children)
				childNode.Initialise(manager);
		}

		public override UiNode FindById(string elementId)
		{
			if (ID == elementId)
				return this;

			foreach (var childNode in _children) {
				var result = childNode.FindById(elementId);

				if (result != null)
					return result;
			}

			return null;
		}

		public UiContainer()
			: base()
		{
		}
	}
}
