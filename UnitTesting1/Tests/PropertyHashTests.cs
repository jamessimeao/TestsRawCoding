using System.Data;
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

        [Fact]
        public void AlgorithmPropertyHash_AppliesHashingAlgorithmToSeed()
        {
            var hasher = new AlgorithmPropertyHash("sha256");
            Cache.Item item = new Cache.Item("url", "content", DateTime.Now);
            string hash = hasher.Hash(item, itm => itm.Url, itm => itm.Content);
            Assert.Equal("9FyLxk+9z73XO8xhZ15emMaK+oa8aDg6LWiY6y40KyQ=", hash);
        }
    }
}
