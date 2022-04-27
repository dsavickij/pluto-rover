namespace PlumGuide.Exercises.PlutoRover.SDK.DTOs;

public record PositionDTO
{
    public int X { get; set; }
    public int Y { get; set; }
    public char Direction { get; set; }
}