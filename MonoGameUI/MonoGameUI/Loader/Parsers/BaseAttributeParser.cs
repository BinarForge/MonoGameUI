namespace MonoGameUI.Loader.Parsers
{
	internal class BaseAttributeParser : IAttributeParser
	{
		protected string _propertyName;

		public string GetPropertyName()
		{
			return _propertyName;
		}

		public virtual object ParseAttribute(string attributeValue)
		{
			return null;
		}
	}
}
