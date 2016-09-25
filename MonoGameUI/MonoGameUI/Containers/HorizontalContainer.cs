namespace MonoGameUI.Containers
{
	public class HorizontalContainer : UiContainer
	{
		public override void Initialise(UIManager manager)
		{
			if (SumOfWeight == 0.0f)
				return;

			UpdatePosition();

			var sumSoFar = 0.0f;
			var sumOfWeights = SumOfWeight;
			for (var i = 0; i < _children.Count; i++) {
				var weighingWidth = _children[i].Weight / sumOfWeights * Position.Right;
				_children[i].Position = new Core.Position((int)(Position.Left + sumSoFar) + _children[i].Margin.X, Position.Top + _children[i].Margin.Y, (int)weighingWidth - (_children[i].Margin.X + _children[i].Margin.Width), Position.Bottom - (_children[i].Margin.Y + _children[i].Margin.Height));
				sumSoFar += weighingWidth;
			}

			base.Initialise(manager);
		}

		public HorizontalContainer()
			: base()
		{
		}
	}
}
