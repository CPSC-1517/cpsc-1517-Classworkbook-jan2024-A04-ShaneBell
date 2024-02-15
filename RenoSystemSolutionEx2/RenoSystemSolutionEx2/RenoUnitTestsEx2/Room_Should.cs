//add project dependency to TrainSystem
using FluentAssertions;
using RenoSystem;

namespace RenoUnitTestsEx2
{
    public class Room_Should
    {
        #region Constructor
        [Fact]
        public void Create_New_Room_Without_Walls()
        {
            string expectedName = "Bedroom 1";
            string expectedFlooring = "Carpet";

            Room actual = new Room("Bedroom 1", "Carpet", null);

            actual.Name.Should().Be(expectedName);
            actual.Flooring.Should().Be(expectedFlooring);
            actual.Walls.Should().BeEmpty();
            actual.TotalWalls.Should().Be(0);
        }
        [Fact]
        public void Create_New_Room_With_Walls()
        {
            string expectedName = "Bedroom 1";
            string expectedFlooring = "Carpet";
            Opening window = new Opening(100, 120, OpeningType.Window, 12);
            Opening door = new Opening(60, 210, OpeningType.Door, 12);
            Wall wall1 = new Wall("brd1_1", 380, 280, "white", window);
            Wall wall2 = new Wall("brd1_2", 380, 280, "white", door);
            Wall wall3 = new Wall("brd1_3", 450, 280, "white", null);
            List<Wall> walls = new List<Wall>();
            walls.Add(wall1);
            walls.Add(wall2);
            walls.Add(wall3);
            List<Wall> expectedWalls = new List<Wall>()
            {
                wall1,
                wall2,
                wall3
            };

            Room actual = new Room("Bedroom 1", "Carpet", walls);

            actual.Name.Should().Be(expectedName);
            actual.Flooring.Should().Be(expectedFlooring);
            actual.TotalWalls.Should().Be(3);
            actual.Walls.Should().ContainInConsecutiveOrder(expectedWalls);
        }
        [Theory]
        [InlineData(null)]
        [InlineData("")]
        [InlineData("    ")]
        public void Throw_No_Name_Exception(string roomname)
        {
            
            Action action = () => new Room(roomname, "Carpet", null);

            action.Should().Throw<ArgumentNullException>();
        }
        #endregion
        #region Property
        [Fact]
        public void Change_Name()
        {
            //Given - Arrange
            Room given = new Room("Bedroom 1", "Carpet", null);
            string expectedName = "Living";

            //When - Act
            given.Name = "Living";

            //Then - Assert
            given.Name.Should().Be(expectedName);
        }
        [Theory]
        [InlineData(null)]
        [InlineData("")]
        [InlineData("    ")]
        public void Throw_Change_Name_Exception(string name)
        {
            //Given - Arrange
            Room given = new Room("Bedroom 1", "Carpet", null);

            //When - Act
            Action action = () => given.Name = name;

            //Then - Assert
            action.Should().Throw<ArgumentNullException>();
        }
        #endregion
        #region Methods
        [Fact]
        public void Create_Add_New_First_Wall()
        {
            //Arrange
            Opening window = new Opening(100, 120, OpeningType.Window, 12);
            Wall firstWall = new Wall("brd1_1", 380, 280, "white", window);
            List<Wall> expectedWalls = new List<Wall>()
            {
                firstWall
            };

            Room room = new Room("Bedroom 1", "Carpet", null);
            //Act
            room.AddWall(firstWall);

            //Assert
            room.TotalWalls.Should().Be(1);
            room.Walls.Should().ContainInConsecutiveOrder(expectedWalls);
        }
        
        [Fact]
        public void Create_Add_Another_Wall_To_Collection()
        {
            //Arrange
            Opening window = new Opening(100, 120, OpeningType.Window, 12);
            Opening door = new Opening(60, 210, OpeningType.Door, 12);
            Wall wall1 = new Wall("brd1_1", 380, 280, "white", window);
            Wall wall2 = new Wall("brd1_2", 380, 280, "white", door);
            Wall wall3 = new Wall("brd1_3", 450, 280, "white", null);
            Wall nextWall = new Wall("brd1_4", 450, 280, "white", null);
            List<Wall> walls = new List<Wall>();
            walls.Add(wall1);
            walls.Add(wall2);
            walls.Add(wall3);
            List<Wall> expectedWalls = new List<Wall>()
            {
                wall1,
                wall2,
                wall3,
                nextWall
            };

            Room given = new Room("Bedroom 1", "Carpet", walls);

            //Act
            given.AddWall(nextWall);

            //Assert
            given.TotalWalls.Should().Be(4);
            given.Walls.Should().ContainInConsecutiveOrder(expectedWalls);
        }
        [Fact]
        public void Throw_Missing_Wall_Exception()
        {
            //Arrange
            Room given = new Room("Bedroom 1", "Carpet", null);
            //Act
            Action action = () => given.AddWall(null);

            //Assert
            given.TotalWalls.Should().Be(0);
            given.Walls.Should().BeEmpty();
            action.Should().Throw<ArgumentNullException>().WithMessage("*Wall required*");
        }
        [Fact]
        public void Throw_Duplicate_PlanId_Exception_When_Adding_Wall()
        {
            //Arrange
            Opening window = new Opening(100, 120, OpeningType.Window, 12);
            Opening door = new Opening(60, 210, OpeningType.Door, 12);
            Wall wall1 = new Wall("brd1_1", 380, 280, "white", window);
            Wall wall2 = new Wall("brd1_2", 380, 280, "white", door);
            Wall wall3 = new Wall("brd1_3", 450, 280, "white", null);
            Wall duplicateWall = new Wall("brd1_2", 450, 280, "white", null);
            List<Wall> walls = new List<Wall>();
            walls.Add(wall1);
            walls.Add(wall2);
            walls.Add(wall3);
            List<Wall> expectedWalls = new List<Wall>()
            {
                wall1,
                wall2,
                wall3
            };

            Room given = new Room("Bedroom 1", "Carpet", walls);

            //Act
            Action action = () => given.AddWall(duplicateWall);

            //Assert
            given.TotalWalls.Should().Be(3);
            given.Walls.Should().ContainInConsecutiveOrder(expectedWalls);
            action.Should().Throw<ArgumentException>().WithMessage("*brd1_2*");

        }
        [Fact]
        public void Create_Remove_Wall_From_Collection()
        {
            //Arrange
            Opening window = new Opening(100, 120, OpeningType.Window, 12);
            Opening door = new Opening(60, 210, OpeningType.Door, 12);
            Wall wall1 = new Wall("brd1_1", 380, 280, "white", window);
            Wall wall2 = new Wall("brd1_2", 380, 280, "white", door);
            Wall wall3 = new Wall("brd1_3", 450, 280, "white", null);
            string removeWall = "brd1_2";
            List<Wall> walls = new List<Wall>();
            walls.Add(wall1);
            walls.Add(wall2);
            walls.Add(wall3);
            List<Wall> expectedWalls = new List<Wall>()
            {
                wall1,
                wall3
            };

            Room given = new Room("Bedroom 1", "Carpet", walls);

            //Act
            given.RemoveWall("brd1_2");

            //Assert
            given.TotalWalls.Should().Be(2);
            given.Walls.Should().ContainInConsecutiveOrder(expectedWalls);
        }
        [Theory]
        [InlineData(null)]
        [InlineData("")]
        [InlineData("    ")]
        public void Throw_Missing_PlanId_Exception(string planid)
        {
            //Arrange
            Opening window = new Opening(100, 120, OpeningType.Window, 12);
            Opening door = new Opening(60, 210, OpeningType.Door, 12);
            Wall wall1 = new Wall("brd1_1", 380, 280, "white", window);
            Wall wall2 = new Wall("brd1_2", 380, 280, "white", door);
            Wall wall3 = new Wall("brd1_3", 450, 280, "white", null);

            List<Wall> walls = new List<Wall>();
            walls.Add(wall1);
            walls.Add(wall2);
            walls.Add(wall3);
            List<Wall> expectedWalls = new List<Wall>()
            {
                wall1,
                wall2,
                wall3
            };

            Room given = new Room("Bedroom 1", "Carpet", walls);
            //Act
            Action action = () => given.RemoveWall(planid);

            //Assert
            given.TotalWalls.Should().Be(3);
            given.Walls.Should().ContainInConsecutiveOrder(expectedWalls);
            action.Should().Throw<ArgumentNullException>().WithMessage("*Plan Id required*");
        }
        [Fact]
        public void Throw_PlanId_Not_Found_Exception_When_Removing_Wall()
        {
            //Arrange
            Opening window = new Opening(100, 120, OpeningType.Window, 12);
            Opening door = new Opening(60, 210, OpeningType.Door, 12);
            Wall wall1 = new Wall("brd1_1", 380, 280, "white", window);
            Wall wall2 = new Wall("brd1_2", 380, 280, "white", door);
            Wall wall3 = new Wall("brd1_3", 450, 280, "white", null);
            string removeWall = "brd1_22";
            List<Wall> walls = new List<Wall>();
            walls.Add(wall1);
            walls.Add(wall2);
            walls.Add(wall3);
            List<Wall> expectedWalls = new List<Wall>()
            {
                wall1,
                wall2,
                wall3
            };

            Room given = new Room("Bedroom 1", "Carpet", walls);

            //Act
            Action action = () => given.RemoveWall("brd1_22");

            //Assert
            given.TotalWalls.Should().Be(3);
            given.Walls.Should().ContainInConsecutiveOrder(expectedWalls);
            action.Should().Throw<ArgumentException>().WithMessage("*brd1_22*");

        }
        #endregion
    }
}