using LanguageExt;
using Moq;
using System.Transactions;

namespace Apsoft.Cad.Domain.Tests;

public class MessageRepositoryTest
{
    private readonly Mock<IMessageRepository> _messageRepository = new Mock<IMessageRepository>();
    
    [Fact]
    public async void GetMessage_ValidID_ValidMessage()
    {
        var id = Guid.NewGuid();
        var text = "Message1";
        var msg = Task.FromResult(Option<Message>.Some(
            new Message(text) { Id = id }));
        _messageRepository
            .Setup(s => s.Get(It.IsAny<Guid>()))
            .Returns(msg);

        var tCall = await _messageRepository.Object.Get(id);

        tCall.Match(
            Some: tRet =>
            {
                Assert.NotNull(tRet);
                Assert.Equal(id, tRet.Id);
                Assert.Equal(text, tRet.Text);
            },
            None: () => Assert.Fail("Damn it..."));
    }

    [Fact]
    public async void GetAllMessages_None_ListOfValidMessages()
    {
        var id1 = Guid.NewGuid();
        var text1 = "Message1";
        var msg1 = new Message(text1) { Id = id1 };

        var id2 = Guid.NewGuid();
        var text2 = "Message2";
        var msg2 = new Message(text2) { Id = id2 };

        var messages = Task.FromResult(
            Option<IEnumerable<Message>>.Some(new[] { msg1, msg2 }.AsEnumerable()));

        _messageRepository
            .Setup(s => s.GetAll())
            .Returns(messages);

        var tCall = await _messageRepository.Object.GetAll();

        tCall.Match(
            Some: tRet =>
            {
                Assert.NotNull(tRet);
                Assert.Equal(2, tRet.Count());
                Assert.Equal(msg1, tRet.ElementAt(0));
                Assert.Equal(msg2, tRet.ElementAt(1));
            },
            None: () => Assert.Fail("Damn it..."));
    }
}