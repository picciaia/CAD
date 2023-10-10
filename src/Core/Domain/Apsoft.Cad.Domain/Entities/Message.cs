namespace Apsoft.Cad.Domain;

public class Message : EntityBase
{
	public Message(string text)
	{
		Text = text;
	}

    public string? Text { get; set; }
}
