namespace TetrisGame.Shared.Models.Common;

public abstract class Block
{
    private int rotationState = 0;
    private readonly Position offset;

    protected Block()
    {
        offset = new Position(StartOffset.Row, StartOffset.Column);
    }

    public abstract int Id { get; }

    public abstract Position StartOffset { get; }

    public abstract Position[][] Tiles { get; }

    public IEnumerable<Position> GetTilePositions()
    {
        foreach (Position position in Tiles[rotationState])
        {
            yield return new(position.Row + offset.Row, position.Column + offset.Column);
        }
    }

    public void RotateCW()
    {
        rotationState = (rotationState + 1) % Tiles.Length;
    }

    public void RotateCCW()
    {
        if (rotationState == 0)
        {
            rotationState = Tiles.Length - 1;
        }
        else
        {
            rotationState--;
        }
    }

    public void Move(int rows, int columns)
    {
        offset.Row += rows;
        offset.Column += columns;
    }

    public void Reset()
    {
        rotationState = 0;
        offset.Row = StartOffset.Row;
        offset.Column = StartOffset.Column;
    }
}