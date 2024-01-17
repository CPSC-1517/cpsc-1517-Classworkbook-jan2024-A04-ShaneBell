using FluentAssertions;
using Hockey.Data;

namespace HockeyTestProject
{
    public class HockeyPlayerTest
    {

        public HockeyPlayer GenerateTestPlayer()
        {
            return new HockeyPlayer();
        }

        [Fact]//This attribute in front of a method indicates it is a testing method.
        public void Test1()
        {
            Assert.Equal(1, 1);
        }

        [Fact]
        public void AddOnePlusOne()
        {
            //Test if 1 + 1 =2
            //Arrange
            int a = 1;
            int b = 1;
            int actual;
            //Act
            actual = a + b;
            //Assert
            //XUnit syntax
            //Assert.Equal(2, actual);
            //FluentAssertions
            actual.Should().Be(2);
        }
        [Fact]
        public void HockeyPlayer_FirstName_ReturnsGoodFirstName()
        {
            //Arrange
            string actual;
            HockeyPlayer player = GenerateTestPlayer();
            const string NAME = "test";
            player.FirstName = NAME;
            //Act
            actual = player.FirstName;
            //Assert
            actual.Should().Be(NAME);
        }
        [Fact]
        public void HockeyPlayer_FirstName_ThrowsExceptionForEmptyArgument()
        {
            HockeyPlayer player = GenerateTestPlayer();
            const string Empty_Name = "";
            //We want to create an action that will run in the assertion only.
            //create an action called act. This is like a mini method that can be called/executed in the assertion
            Action act= () => player.FirstName = Empty_Name;

            act.Should().Throw<Exception>().WithMessage("First name cannot be empty!");            
        }
    }
}