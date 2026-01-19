using Mocking.Units;
using Moq;

namespace Mocking.Tests
{
    public class CreateSomethingTests
    {
        public class StoreMock : CreateSomething.IStore
        {
            public int SaveAttempts { get; set; }
            public bool SaveResult { get; set; }

            public CreateSomething.Something? LastSavedSomething { get; set; }

            public bool Save(CreateSomething.Something something)
            {
                SaveAttempts++;
                LastSavedSomething = something;
                return SaveResult;
            }
        }

        public readonly Mock<CreateSomething.IStore> _storeMock = new();

        [Fact]
        public void DoesntSaveToDatabaseWhenInvalidSomething()
        {
            var storeMock = new StoreMock();
            CreateSomething createSomething = new(storeMock);

            var createSomethingResult = createSomething.Create(null);

            Assert.False(createSomethingResult.Success);
            Assert.Equal(0, storeMock.SaveAttempts);
        }

        [Fact]
        public void SaveSomethingToDatabaseWhenValid()
        {
            var storeMock = new StoreMock();
            storeMock.SaveResult = true;
            CreateSomething createSomething = new(storeMock);

            var something = new CreateSomething.Something { Name = "Foo" };
            var createSomethingResult = createSomething.Create(something);

            Assert.True(createSomethingResult.Success);
            Assert.Equal(1, storeMock.SaveAttempts);
            Assert.Equal(something, storeMock.LastSavedSomething);
        }
    }
}
