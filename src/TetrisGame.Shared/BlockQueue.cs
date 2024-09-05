using TetrisGame.Shared.Models;
using TetrisGame.Shared.Models.Common;

namespace TetrisGame.Shared;

public class BlockQueue
{
    private readonly Block[] blocks =
    [
        new IBlock(),
        new OBlock()
    ];

    private readonly Random random = new();

    public BlockQueue()
    {
        NextBlock = RandomBlock();
    }

    public Block NextBlock { get; private set; }

    public Block GetBlockAndUpdate()
    {
        Block block = NextBlock;

        do
        {
            NextBlock = RandomBlock();
        }
        while (block.Id == NextBlock.Id);

        return block;
    }

    private Block RandomBlock()
    {
        int length = blocks.Length;
        return blocks[random.Next(length)];
    }
}