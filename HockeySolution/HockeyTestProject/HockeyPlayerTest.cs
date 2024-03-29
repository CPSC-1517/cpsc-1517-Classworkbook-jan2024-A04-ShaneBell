using FluentAssertions;
using Hockey.Data;
using System.Reflection.Metadata;

namespace HockeyTestProject
{
    public class HockeyPlayerTest
    {
        const string FIRST_NAME = "Shane";
        const string LAST_NAME = "Bell";
        const string BIRTH_PLACE = "Edmonton";
        const int HEIGHT_IN_INCHES = 70;
        const int WEIGHT_IN_POUNDS = 190;
        const Position PLAYER_POSITION = Position.Goalie;
        const Shot PLAYER_SHOT = Shot.Right;
        //Cannot create constants from date/time. 
        //can make it readonly to ensure it is not changed
        readonly DateOnly DATE_OF_BIRTH = new DateOnly(1972, 01, 20);
        const string TO_STRING_VALUE = $"{FIRST_NAME} {LAST_NAME}";
        const int JERSEY_NUMBER = 20;

        //Method to generate a greedy Hockey Player
        public HockeyPlayer GenerateGreedyTestPlayer()
        {
            return new HockeyPlayer(BIRTH_PLACE, FIRST_NAME, LAST_NAME, HEIGHT_IN_INCHES, WEIGHT_IN_POUNDS, DATE_OF_BIRTH, PLAYER_POSITION, PLAYER_SHOT, JERSEY_NUMBER, null);
        }

        //TEST FOR GREEDY CONSTRUCTOR
        [Fact]
        public void HockeyPlayer_Create_GreedyConstructorHockeyPlayer()
        {
            HockeyPlayer player = GenerateGreedyTestPlayer();
            player.Should().NotBeNull();//If it is not null then the constructor returned a valid instance of Hockey Player
        }

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
            Action act = () => player.FirstName = Empty_Name;

            act.Should().Throw<Exception>().WithMessage("First name cannot be empty!");
        }

        [Fact]
        public void HockeyPlayer_ToString_ReturnCorrectValue()
        {
            //Arrange
            HockeyPlayer player = GenerateGreedyTestPlayer();
            string actual;
            //Act
            actual = player.ToString();
            //Assert
            actual.Should().Be(TO_STRING_VALUE);
        }
        //create a test for a JerseyNumber Property. Test Get/Set for success. valid jersey number is 1-98.
        //
        [Theory]
        [InlineData(1)]
        [InlineData(98)]

        public void HockeyPlayer_JerseyNumber_GoodSetAndGet(int value)
        {
            HockeyPlayer player = GenerateGreedyTestPlayer();
            int actual;

            player.JerseyNumber = value;
            actual = player.JerseyNumber;
            actual.Should().Be(value);
        }
        //test for invalid data throwing an exception(0,99)
        [Theory]
        [InlineData(0)]
        [InlineData(99)]

        public void HockeyPlayer_JerseyNumber_BadSetThrowsException(int value)
        {
            HockeyPlayer player = GenerateGreedyTestPlayer();

            Action act = () => player.JerseyNumber = value;

            act.Should().Throw<Exception>().WithMessage("Jersey number out of range");
        }

        [Fact]
        public void Test_Creation_of_Greedy_Constructor_No_Teams()
        {
            //Arrange


            //Act
            HockeyPlayer player = new HockeyPlayer("Edmonton", "Shane", "Bell", 70, 190, new DateOnly(1972, 01, 20), Position.Goalie, Shot.Right, 1, null);

            //Assert
            player.Should().NotBeNull();//was it instantiated?
            //Optional
            player.FirstName.Should().Be("Shane");
            player.LastName.Should().Be("Bell");
            player.NumberOfTeams.Should().Be(0);
            player.teams.Should().BeEmpty();
        }

        [Fact]
        public void Test_Creation_of_Greedy_Constructor_With_Teams()
        {
            //Arrange
            List<Team> teams = new List<Team>();
            teams.Add(new Team("Oilers", "Edmonton", Role.Player));
            teams.Add(new Team("Ooks", "Edmonton", Role.Player));
            teams.Add(new Team("Canucks", "Vancouver", Role.Other));

            //Act
            HockeyPlayer player = new HockeyPlayer("Edmonton", "Shane", "Bell", 70, 190, new DateOnly(1972, 01, 20), Position.Goalie, Shot.Right, 1, teams);

            //Assert
            //Assert
            player.Should().NotBeNull();//was it instantiated?
            //Optional
            player.FirstName.Should().Be("Shane");
            player.LastName.Should().Be("Bell");
            player.NumberOfTeams.Should().Be(3);
            player.teams.Should().NotBeNull();


        }
        //Change Jersey Number test
        //Create a player (team or no teams)
        //change the jersey number
        //Assert that the JerseyNumber property has the expected value

        [Fact]
        public void Test_Change_Jersey_Number()
        {
            //Arrange
            HockeyPlayer player = new HockeyPlayer("Edmonton", "Shane", "Bell", 70, 190, new DateOnly(1972, 01, 20), Position.Goalie, Shot.Right, 1, null);
            const int EXPECTED_VALUE = 20;

            //Act
            player.JerseyNumber = EXPECTED_VALUE;

            //Assert
            player.JerseyNumber.Should().Be(EXPECTED_VALUE);
        }
        [Fact]
        public void Add_First_Team()
        {
            //Arrange
            Team firstTeam = new Team("Oilers", "Edmonton", Role.Other);

            List<Team> expectedTeams = new List<Team>()
            {
                firstTeam
            };
            //expectedTeams.Add(firstTeam);
            HockeyPlayer player = new HockeyPlayer("Edmonton", "Shane", "Bell", 70, 190, new DateOnly(1972, 01, 20), Position.Goalie, Shot.Right, 1, null);
            //Act
            player.AddTeam(firstTeam);

            //Assert
            player.NumberOfTeams.Should().Be(1);
            player.teams.Should().ContainInConsecutiveOrder(expectedTeams);
        }
        [Fact]
        public void Add_Additional_Teams_To_Collection()
        {
            //Arrange
            Team team1 = new Team("Oilers", "Edmonton", Role.Other);
            Team team2 = new Team("Ooks", "Edmonton", Role.Other);
            Team team3 = new Team("Canucks", "Edmonton", Role.Other);
            Team additionalTeam = new Team("SQL  Warriors", "Edmonton", Role.Other);

            List<Team> expectedTeams = new List<Team>()
            {
                team1,
                team2,
                team3,
                additionalTeam
            };

            List<Team> teams = new List<Team>()
            {
                team1,
                team2,
                team3
            };

            HockeyPlayer player = new HockeyPlayer("Edmonton", "Shane", "Bell", 70, 190, new DateOnly(1972, 01, 20), Position.Goalie, Shot.Right, 1, teams);

            //Act
            player.AddTeam(additionalTeam);

            //Assert
            player.NumberOfTeams.Should().Be(4);
            player.teams.Should().ContainInConsecutiveOrder(expectedTeams);

        }
        [Fact]
        public void Throw_Missing_Team_Exception()
        {
            //Arrange
            HockeyPlayer player = new HockeyPlayer("Edmonton", "Shane", "Bell", 70, 190, new DateOnly(1972, 01, 20), Position.Goalie, Shot.Right, 1, null);

            //Act
            Action action = () => player.AddTeam(null);

            //Assert
            action.Should().Throw<Exception>().WithMessage("*not provided*");
            player.NumberOfTeams.Should().Be(0);
            player.teams.Should().BeEmpty();
        }
        //Remove Team success
        [Fact]
        public void Remove_Team_From_Collection()
        {
            //Arrange
            Team team1 = new Team("Oilers", "Edmonton", Role.Other);
            Team team2 = new Team("Ooks", "Edmonton", Role.Other);
            Team team3 = new Team("Canucks", "Edmonton", Role.Other);

            const string removeTeam = "Ooks";
            List<Team> teams = new List<Team>()
            {
                team1,
                team2,
                team3
            };

            List<Team> expectedTeams = new List<Team>()
            {
                team1,
                team3
            };
            HockeyPlayer player = new HockeyPlayer("Edmonton", "Shane", "Bell", 70, 190, new DateOnly(1972, 01, 20), Position.Goalie, Shot.Right, 1, teams);
            //Act
            player.RemoveTeam(removeTeam);
            //Arrange
            player.NumberOfTeams.Should().Be(2);
            player.teams.Should().ContainInConsecutiveOrder(expectedTeams);
        }

        [Fact]
        public void Throw_Duplicate_Team_Name_Exception_When_Adding_Team()
        {
            //Arrange
            Team team1 = new Team("Oilers", "Edmonton", Role.Other);
            Team team2 = new Team("Ooks", "Edmonton", Role.Other);
            Team team3 = new Team("Canucks", "Edmonton", Role.Other);
            Team duplicateTeam = new Team("Oilers", "Edmonton", Role.Other);

            List<Team> teams = new List<Team>()
            {
                team1,
                team2,
                team3
            };

            HockeyPlayer player = new HockeyPlayer("Edmonton", "Shane", "Bell", 70, 190, new DateOnly(1972, 01, 20), Position.Goalie, Shot.Right, 1, teams);

            //Act
            Action act = () => player.AddTeam(duplicateTeam);

            //Assert
            player.NumberOfTeams.Should().Be(3);
            player.teams.Should().ContainInConsecutiveOrder(teams);
            act.Should().Throw<Exception>().WithMessage("*already listed*");
        }
        [Fact]
        public void Throw_Team_Name_Not_Found_Exception_Removing_Team()
        {
            //Arrange
            Team team1 = new Team("Oilers", "Edmonton", Role.Other);
            Team team2 = new Team("Ooks", "Edmonton", Role.Other);
            Team team3 = new Team("Canucks", "Edmonton", Role.Other);

            const string removeTeam = "Ooksssssss";
            List<Team> teams = new List<Team>()
            {
                team1,
                team2,
                team3
            };

            List<Team> expectedTeams = new List<Team>()
            {
                team1,
                team2,
                team3
            };
            HockeyPlayer player = new HockeyPlayer("Edmonton", "Shane", "Bell", 70, 190, new DateOnly(1972, 01, 20), Position.Goalie, Shot.Right, 1, teams);
            //Act
            Action act = () => player.RemoveTeam(removeTeam);
            //Arrange
            player.NumberOfTeams.Should().Be(3);
            player.teams.Should().ContainInConsecutiveOrder(expectedTeams);
            act.Should().Throw<Exception>().WithMessage("*not in the list*");
        }

        [Theory]
        [InlineData(null)]
        [InlineData("")]
        [InlineData("   ")]
        public void Throw_Missing_TeamName_Exception_For_Remove_Team(string teamName)
        {
            //Arrange
            Team team1 = new Team("Oilers", "Edmonton", Role.Other);
            Team team2 = new Team("Ooks", "Edmonton", Role.Other);
            Team team3 = new Team("Canucks", "Edmonton", Role.Other);

            List<Team> teams = new List<Team>()
            {
                team1,
                team2,
                team3   
            };

            List<Team> expectedTeams = new List<Team>()
            {
                team1,
                team2,
                team3
            };
            HockeyPlayer player = new HockeyPlayer("Edmonton", "Shane", "Bell", 70, 190, new DateOnly(1972, 01, 20), Position.Goalie, Shot.Right, 1, teams);
            //Act
            Action act = () => player.RemoveTeam(teamName);
            //Arrange
            player.NumberOfTeams.Should().Be(3);
            player.teams.Should().ContainInConsecutiveOrder(expectedTeams);
            act.Should().Throw<Exception>().WithMessage("Team name is required");
        }
    }
}