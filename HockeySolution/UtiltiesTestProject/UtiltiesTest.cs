using FluentAssertions;
using ValidationUtilities;
using System.Security.Cryptography.X509Certificates;

namespace UtiltiesTestProject
{
    public class UtiltiesTest
    {
        //we need to check null,""," ", valid string
        [Fact]
        public void Utilties_IsNullOrEmptyOrWhiteSpace_ReturnsFalseForNonEmpty()
        {
            //Arrange
            bool actual;
            const string GOOD_STRING = "X";//Could be any good string
            //Act
            actual=Utilities.IsNullOrEmptyOrWhiteSpace(GOOD_STRING);
            //Assert
            actual.Should().BeFalse();
            //OR
            actual.Should().Be(false);           
        }
        //We can use [Theory] test methods with inline data to call the method several times with different arguments
        [Theory]
        [InlineData("")]
        [InlineData(" ")]
        [InlineData(null)]

        public void Utilties_IsNullOrEmptyOrWhiteSpace_ReturnsTrueForEmptyNullOrWhiteSpace(string value)
        {
            //Arrange
            bool actual;

            //Act
            actual=Utilities.IsNullOrEmptyOrWhiteSpace(value);
            
            //Assert
            actual.Should().BeTrue();
        }
        
        [Theory]
        [InlineData(-1)]//Test for negative int
        [InlineData(-1.0)]

        //All datattypes inherit from system.object
        public void Utilities_IsNegative_ReturnsTrueForNegative(object value)
        {
            bool actual;
            //Determine if the value passed as an argument is an int or double
            //Then cast the value to each type which will then call the correct corresponding overloaded validation method
            if (value.GetType() == typeof(int))
            {
                actual = Utilities.IsNegative((int)value);
            }
            else
            {
                actual = Utilities.IsNegative((double)value);
            }                    
            actual.Should().BeTrue();   
        }
    }
}