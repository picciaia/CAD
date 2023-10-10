namespace Apsoft.Cad.Domain;

public enum MessageStatus
{
    Undefined,
    Original,
    Translated
}

public static class MessageStatusNames 
{
    public static MessageStatus Map(string text) =>
        text switch
        {
            "Original" => MessageStatus.Original,
            "Translated" => MessageStatus.Translated,
            _ => MessageStatus.Undefined
        };
}
