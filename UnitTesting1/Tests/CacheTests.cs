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
    }
}
