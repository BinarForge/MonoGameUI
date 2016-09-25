namespace MonoGameUI.Containers
{
	public class VerticalContainer : UiContainer
	{
		public override void Initialise(UIManager manager)
		{
			if (SumOfWeight == 0.0f)
				return;

			UpdatePosition();

			var sumSoFar = 0.0f;
			var sumOfWeights = SumOfWeight;
			for (var i = 0; i < _children.Count; i++) {
				var weighingHeight = _children[i].Weight / sumOfWeights * Position.Bottom;
				_children[i].Position = new Core.Position(Position.Left + _children[i].Margin.X, (int)(Position.Top + sumSoFar) + _children[i].Margin.Y, Position.Right - (_children[i].Margin.X + _children[i].Margin.Width), (int)weighingHeight - (_children[i].Margin.Y + _children[i].Margin.Height));
				sumSoFar += weighingHeight;
			}

			base.Initialise(manager);
		}
		
		public VerticalContainer()
			: base()
		{
		}
	}
}
