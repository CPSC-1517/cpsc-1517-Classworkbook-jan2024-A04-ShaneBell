//add project dependency to RenoSystem
 using FluentAssertions;
 using RenoSystem;

 namespace RenoUnitTestsEx1
 {
     public class Opening_Should
     {
         #region Constructor
         [Fact]
         public void Create_A_Good_Opening_With_Edging()
         {
             //Given - Arrange
             OpeningType expectedType = OpeningType.Window;
             int expectedWidth = 100;
             int expectedHeight = 120;
             int expectedEdging = 10;

             //When - Act
             Opening actual = new Opening( 100, 120, OpeningType.Window, 10);

             //Then - Assert
             actual.Type.Should().Be(expectedType);
             actual.Width.Should().Be(expectedWidth);
             actual.Height.Should().Be(expectedHeight);
             actual.Edging.Should().Be(expectedEdging);
         }
         [Fact]
         public void Create_A_Good_Opening_WithOut_Edging()
         {
             //Given - Arrange
             OpeningType expectedType = OpeningType.Window;
             int expectedWidth = 100;
             int expectedHeight = 120;

             //When - Act
             Opening actual = new Opening(100, 120, OpeningType.Window);

             //Then - Assert
             actual.Type.Should().Be(expectedType);
             actual.Width.Should().Be(expectedWidth);
             actual.Height.Should().Be(expectedHeight);
             actual.Edging.Should().Be(0);
         }

         [Theory]
         [InlineData(-3)]
         [InlineData(0)]
         [InlineData(30)]
         public void Throw_Exception_For_Width_Using_Constructor(int width)
         {
             //Given - Arrange
             OpeningType type = OpeningType.Window;
             int height = 120;
             int edging = 10;

             //When - Act
             Action action = () => new Opening(width, height, type, edging);

             //Then - Assert
             action.Should().Throw<ArgumentException>();
         }

         [Theory]
         [InlineData(-3)]
         [InlineData(0)]
         [InlineData(30)]
         public void Throw_Exception_For_Height_Using_Constructor(int height)
         {
             //Given - Arrange
             OpeningType type = OpeningType.Window;
             int width = 120;
             int edging = 10;

             //When - Act
             Action action = () => new Opening(width, height, type, edging);

             //Then - Assert
             action.Should().Throw<ArgumentException>();
         }

         [Theory]
         [InlineData(-3)]
         [InlineData(3)]
         public void Throw_Exception_For_Edging_Using_Constructor(int edging)
         {
             //Given - Arrange
             OpeningType type = OpeningType.Window;
             int height = 120;
             int width = 100;

             //When - Act
             Action action = () => new Opening(width, height, type, edging);

             //Then - Assert
             action.Should().Throw<ArgumentException>();
         }

         #endregion

         #region Properties
         [Fact]
         public void Change_Width()
         {
             //Given - Arrange
             Opening given = new Opening(100, 120, OpeningType.Window, 10);
             int expectedWidth = 150;


             //When - Act
             given.Width = 150;

             //Then - Assert
             given.Width.Should().Be(expectedWidth);
         }

         [Theory]
         [InlineData(-3)]
         [InlineData(0)]
         [InlineData(30)]
         public void Throw_Exception_For_Width_Using_Property(int width)
         {
             //Given - Arrange
             Opening given = new Opening(100, 120, OpeningType.Window, 10);


             //When - Act
             Action action = () => given.Width = width;

             //Then - Assert
             action.Should().Throw<ArgumentException>();
         }

         [Fact]
         public void Change_Height()
         {
             //Given - Arrange
             Opening given = new Opening(100, 120, OpeningType.Window, 10);
             int expectedHeight = 150;


             //When - Act
             given.Height = 150;

             //Then - Assert
             given.Height.Should().Be(expectedHeight);
         }
         [Theory]
         [InlineData(-3)]
         [InlineData(0)]
         [InlineData(30)]
         public void Throw_Exception_For_Height_Using_Property(int height)
         {
             //Given - Arrange
             Opening given = new Opening(100, 120, OpeningType.Window, 10);


             //When - Act
             Action action = () => given.Height = height;

             //Then - Assert
             action.Should().Throw<ArgumentException>();
         }

         [Theory]
         [InlineData(15)]
         [InlineData(0)]
         public void Change_Edging(int edging)
         {
             //Given - Arrange
             Opening given = new Opening(100, 120, OpeningType.Window, 10);
             int expectedEdging = edging;


             //When - Act
             given.Edging = edging;

             //Then - Assert
             given.Edging.Should().Be(expectedEdging);
         }
         [Theory]
         [InlineData(-3)]
         [InlineData(3)]
         public void Throw_Exception_For_Edging_Using_Property(int edging)
         {
             //Given - Arrange
             Opening given = new Opening(100, 120, OpeningType.Window, 10);


             //When - Act
             Action action = () => given.Edging = edging;

             //Then - Assert
             action.Should().Throw<ArgumentException>();
         }
         #endregion

         #region Read-Only Properties
         [Fact]
         public void Calculate_Area()
         {
             //Given - Arrange
             Opening given = new Opening(100, 120, OpeningType.Window, 10);
             int expectedArea = given.Width * given.Height;


             //When - Act
             int actualArea = given.Area;

             //Then - Assert
             actualArea.Should().Be(expectedArea);
         }
         [Fact]
         public void Calculate_Perimeter()
         {
             //Given - Arrange
             Opening given = new Opening(100, 120, OpeningType.Window, 10);
             int expectedPerimeter = 2 * (given.Width + given.Height);


             //When - Act
             int actualPerimeter = given.Perimeter;

             //Then - Assert
             actualPerimeter.Should().Be(expectedPerimeter);
         }


         #endregion

         #region Method
         [Fact]
         public void Create_CSV_String()
         {
             //Given - Arrange
             Opening given = new Opening(100, 120, OpeningType.Window, 10);
             string expectedToString = $"100,120,Window,10";


             //When - Act
             string actualToString = given.ToString();

             //Then - Assert
             actualToString.Should().Be(expectedToString);
         }
         #endregion

     }
 }