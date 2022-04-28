//using FluentAssertions;
//using Microsoft.EntityFrameworkCore;
//using PlumGuide.Exercises.PlutoRover.DataAccess.Entities;
//using System;
//using System.Threading.Tasks;
//using Xunit;
//using Rover = PlumGuide.Exercises.PlutoRover.Rovers.PlutoRover.PlutoRover;

//namespace PlumGuide.Exercises.PlutoRover.UnitTests.Rovers.PlutoRover;

//public class PlutoRoverTests
//{
//    [Fact]
//    public async Task When_GetPositionAsyncIsCalled_Then_RoverCurrentPositionIsReturned()
//    {
//        // Arrange
//        var currentPosition = new Position(Guid.NewGuid(), 0, 0, Direction.North);

//        var dbContext = InMemoryPlutoRoverDbContextProvider.GetInstance();

//        await dbContext.Positions.AddAsync(currentPosition);
//        await dbContext.SaveChangesAsync();

//        var sut = new Rover(dbContext);

//        // Act
//        var position = await sut.GetPositionAsync();

//        // Assert
//        position.Should().Be(position);
//    }

//    [Theory]
//    [MemberData(nameof(PlutoRoverMovementTestData.GetMoveForwardTestData), MemberType = typeof(PlutoRoverMovementTestData))]
//    public async Task When_MoveForwardIsCalled_Then_RoverMovesForwardByOneUnit(Position startPosition, Position afterMovePosition)
//    {
//        // Arrange
//        var dbContext = InMemoryPlutoRoverDbContextProvider.GetInstance();

//        await dbContext.Positions.AddAsync(startPosition);
//        await dbContext.SaveChangesAsync();

//        dbContext.Entry(startPosition).State = EntityState.Detached;

//        var sut = new Rover(dbContext);

//        // Act
//        var position = await sut.MoveForwardAsync();

//        // Assert
//        position.Should().Be(afterMovePosition);
//    }

//    [Theory]
//    [MemberData(nameof(PlutoRoverMovementTestData.GetMoveBackwardTestData), MemberType = typeof(PlutoRoverMovementTestData))]
//    public async Task When_MoveBackwardIsCalled_Then_RoverMovesBackwardByOneUnit(Position startPosition, Position afterMovePosition)
//    {
//        // Arrange
//        var dbContext = InMemoryPlutoRoverDbContextProvider.GetInstance();

//        await dbContext.Positions.AddAsync(startPosition);
//        await dbContext.SaveChangesAsync();

//        dbContext.Entry(startPosition).State = EntityState.Detached;

//        var sut = new Rover(dbContext);

//        // Act
//        var position = await sut.MoveBackwardAsync();

//        // Assert
//        position.Should().Be(afterMovePosition);
//    }

//    [Theory]
//    [MemberData(nameof(PlutoRoverMovementTestData.GetTurnLeftTestData), MemberType = typeof(PlutoRoverMovementTestData))]
//    public async Task When_TurnLeftIsCalled_Then_RoverTurnsLeft(Position startPosition, Position afterMovePosition)
//    {
//        // Arrange
//        var dbContext = InMemoryPlutoRoverDbContextProvider.GetInstance();

//        await dbContext.Positions.AddAsync(startPosition);
//        await dbContext.SaveChangesAsync();

//        dbContext.Entry(startPosition).State = EntityState.Detached;

//        var sut = new Rover(dbContext);

//        // Act
//        var position = await sut.TurnLeftAsync();

//        // Assert
//        position.Should().Be(afterMovePosition);
//    }

//    [Theory]
//    [MemberData(nameof(PlutoRoverMovementTestData.GetTurnRightTestData), MemberType = typeof(PlutoRoverMovementTestData))]
//    public async Task When_TurnRightIsCalled_Then_RoverTurnsRightLeft(Position startPosition, Position afterMovePosition)
//    {
//        // Arrange
//        var dbContext = InMemoryPlutoRoverDbContextProvider.GetInstance();

//        await dbContext.Positions.AddAsync(startPosition);
//        await dbContext.SaveChangesAsync();

//        dbContext.Entry(startPosition).State = EntityState.Detached;

//        var sut = new Rover(dbContext);

//        // Act
//        var position = await sut.TurnRightAsync();

//        // Assert
//        position.Should().Be(afterMovePosition);
//    }
//}
