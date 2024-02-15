//add project dependency to TrainSystem
using FluentAssertions;
using RenoSystem;

namespace RenoUnitTestsEx1
{
    public class Utilities_Should
    {
        [Fact]
        public void Validate_Is_Positive_Non_Zero()
        {
            //Given - Arrange


            //When - Act
            bool actual = Utilities.IsNonZeroPositive(1);

            //Then - Assert
            actual.Should().BeTrue();
        }
        [Fact]
        public void Validate_Is_Not_Positive_Non_Zero()
        {
            //Given - Arrange


            //When - Act
            bool actual = Utilities.IsNonZeroPositive(0);

            //Then - Assert
            actual.Should().BeFalse();
        }
        [Theory]
        [InlineData(0)]
        [InlineData(1)]
        public void Validate_Is_Positive_Or_Zero(int value)
        {
            //Given - Arrange


            //When - Act
            bool actual = Utilities.IsZeroPositive(value);

            //Then - Assert
            actual.Should().BeTrue();
        }
        [Fact]
        public void Validate_Is_Not_Positive_Or_Zero()
        {
            //Given - Arrange


            //When - Act
            bool actual = Utilities.IsZeroPositive(-1);

            //Then - Assert
            actual.Should().BeFalse();
        }
        [Fact]
        public void Validate_Value_Is_Minimum()
        {
            //Given - Arrange


            //When - Act
            bool actual = Utilities.IsValidMinimum(10,10);

            //Then - Assert
            actual.Should().BeTrue();
        }
        [Fact]
        public void Validate_Value_Is_Not_Minimum()
        {
            //Given - Arrange


            //When - Act
            bool actual = Utilities.IsValidMinimum(9, 10);

            //Then - Assert
            actual.Should().BeFalse();
        }
    }
}
