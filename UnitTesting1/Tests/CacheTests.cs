using UnitTesting1.Units;

namespace UnitTesting1.Tests
{
    public class CacheTests
    {
        [Fact]
        public void CachesItemWithinTimeSpan()
        {
            Cache cache = new Cache(TimeSpan.FromDays(1));
            const string url = "url";
            cache.Add(new(url, "content", DateTime.Now));

            bool contains = cache.Contains(url);

            Assert.True(contains);
        }

        [Fact]
        public void Contains_ReturnsFalse_WhenOutsideTimeSpan()
        {
            var cache = new Cache(TimeSpan.FromDays(1));

            cache.Add(
                new(
                    "url",
                    "content",
                    DateTime.Now.AddDays(-2))
                );

            bool contains = cache.Contains("url");
            Assert.False(contains);
        }
        
        [Fact]
        public void Contains_ReturnsFalse_WhenDoesntContainItem()
        {
            Cache cache = new Cache(TimeSpan.FromDays(1));

            bool contains = cache.Contains("url");
            Assert.False(contains);
        }
    }
}
