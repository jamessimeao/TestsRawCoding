using Mocking.Units;

namespace Mocking.Tests
{
    public class CreateSomethingTests
    {
        public class StoreMock : CreateSomething.IStore
        {
            public int SaveAttempts { get; set; }

            public bool Save(CreateSomething.Something something)
            {
                SaveAttempts++;
                return false;
            }
        }

        [Fact]
        public void DoesntSaveToDatabaseWhenInvalidSomething()
        {
            var storeMock = new StoreMock();
            CreateSomething createSomething = new(storeMock);

            var createSomethingResult = createSomething.Create(null);

            Assert.False(createSomethingResult.Success);
            Assert.Equal(0, storeMock.SaveAttempts);
        }

    }
}
