using TetrisGame.Shared.Models.Common;

namespace TetrisGame.Shared.Models;

public class IBlock : Block
{
    public override Position[][] Tiles
    {
        get
        {
            return
            [
                [new(1, 0), new(1, 1), new(1, 2), new(1, 3)],
                [new(0, 2), new(1, 2), new(2, 2), new(3, 2)],
                [new(2, 0), new(2, 1), new(2, 2), new(2, 3)],
                [new(0, 1), new(1, 1), new(2, 1), new(3, 1)]
            ];
        }
    }

    public override Position StartOffset => new(-1, 3);

    public override int Id => 1;
}