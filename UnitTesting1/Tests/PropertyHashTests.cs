using UnitTesting1.Units;

namespace UnitTesting1.Tests
{
    public class PropertyHashTests
    {
        [Fact]
        public void PropertyHash_ConcatenateSelectedFieldInOrder()
        {
            PropertyHash hasher = new PropertyHash();
            Cache.Item item = new Cache.Item("url", "content", DateTime.Now);

            string hash = hasher.Hash(item, itm => itm.Url, itm => itm.Content);

            Assert.Equal("urlcontent", hash);
        }
    }
}
