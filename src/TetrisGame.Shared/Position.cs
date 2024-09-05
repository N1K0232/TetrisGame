namespace TetrisGame.Shared;

public class Position
{
    internal Position(int row, int column)
    {
        Row = row;
        Column = column;
    }

    public int Row { get; set; }

    public int Column { get; set; }
}