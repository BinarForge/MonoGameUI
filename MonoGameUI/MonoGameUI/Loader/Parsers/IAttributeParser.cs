namespace MonoGameUI.Loader.Parsers
{
	internal interface IAttributeParser
	{
		string GetPropertyName();
		object ParseAttribute(string attributeValue);
	}
}
