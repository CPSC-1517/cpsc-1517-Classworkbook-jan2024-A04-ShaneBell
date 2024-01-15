using FluentAssertions;

namespace HockeyTestProject
{
    public class UnitTest1
    {
        [Fact]//This attribute in front of a method indicates it is a testing method.
        public void Test1()
        {
            Assert.Equal(1, 2); 
        }
    }
}