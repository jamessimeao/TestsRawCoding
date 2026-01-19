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


    }
}
