namespace Apsoft.Cad.Domain;


public static class MessageStatusExtensions
{
    public static MessageStatus ToMessageStatus(this string text) =>
        MessageStatusNames.Map(text);
}
