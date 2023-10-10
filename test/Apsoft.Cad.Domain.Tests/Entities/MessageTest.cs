namespace Apsoft.Cad.Domain.Tests;

public class MessageTest
{
    [Fact]
    public void MessagetCtor_ValidText_ReturnValidMessage()
    {
        var text = "msg1";
        var msg = new Message(text);

        Assert.NotNull(msg);
        Assert.NotNull(msg.Text);
        Assert.Equal(Guid.Empty, msg.Id);
    }

    [Fact]
    public void MessagetCtor_InvalidText_ReturnMessageNullText()
    {
        string text = null;
        var msg = new Message(text);

        Assert.NotNull(msg);
        Assert.Null(msg.Text);
        Assert.Equal(Guid.Empty, msg.Id);
    }
}