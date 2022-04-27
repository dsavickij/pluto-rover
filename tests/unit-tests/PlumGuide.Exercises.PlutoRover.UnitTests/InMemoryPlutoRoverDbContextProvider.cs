using Microsoft.EntityFrameworkCore;
using PlumGuide.Exercises.PlutoRover.DataAccess;
using System;

namespace PlumGuide.Exercises.PlutoRover.UnitTests;

public class InMemoryPlutoRoverDbContextProvider
{
    public static PlutoRoverDbContext GetInstance()
    {
        var builder = new DbContextOptionsBuilder<PlutoRoverDbContext>()
                .UseInMemoryDatabase(Guid.NewGuid().ToString());

        return new PlutoRoverDbContext(builder.Options);
    }
}
