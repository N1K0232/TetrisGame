using TetrisGame.Shared.Models.Common;

namespace TetrisGame.Shared.Models;

public class OBlock : Block
{
    public override int Id => 4;

    public override Position StartOffset => new(0, 4);

    public override Position[][] Tiles
    {
        get
        {
            return [[new(0, 0), new(0, 1), new(1, 0), new(1, 1)]];
        }
    }
}