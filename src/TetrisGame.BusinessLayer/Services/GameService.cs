using TetrisGame.BusinessLayer.Services.Interfaces;
using TetrisGame.Shared;
using TetrisGame.Shared.Models.Common;

namespace TetrisGame.BusinessLayer.Services;

public class GameService : IGameService
{
    private Block currentBlock;
    private bool gameOver;

    public GameService()
    {
        GameGrid = new GameGrid(22, 10);
        BlockQueue = new BlockQueue();
        CurrentBlock = BlockQueue.GetBlockAndUpdate();
    }

    public Block CurrentBlock
    {
        get
        {
            return currentBlock;
        }
        private set
        {
            if (value != currentBlock)
            {
                currentBlock = value;
                currentBlock.Reset();
            }
        }
    }

    public GameGrid GameGrid { get; }

    public BlockQueue BlockQueue { get; }

    public bool GameOver => gameOver;

    public void RotateBlockCW()
    {
        CurrentBlock.RotateCW();

        if (!BlockFits())
        {
            CurrentBlock.RotateCCW();
        }
    }

    public void RotateBlockCCW()
    {
        CurrentBlock.RotateCCW();

        if (!BlockFits())
        {
            CurrentBlock.RotateCW();
        }
    }

    public void MoveBlockLeft()
    {
        CurrentBlock.Move(0, -1);

        if (!BlockFits())
        {
            CurrentBlock.Move(0, 1);
        }
    }

    public void MoveBlockRight()
    {
        CurrentBlock.Move(0, 1);

        if (!BlockFits())
        {
            CurrentBlock.Move(0, -1);
        }
    }

    public void MoveBlockDown()
    {
        CurrentBlock.Move(1, 0);

        if (!BlockFits())
        {
            CurrentBlock.Move(-1, 0);
            PlaceBlock();
        }
    }

    private bool IsGameOver()
    {
        return !(GameGrid.IsRowEmpty(0) && GameGrid.IsRowEmpty(1));
    }

    private bool BlockFits()
    {
        foreach (Position p in CurrentBlock.GetTilePositions())
        {
            if (!GameGrid.IsEmpty(p.Row, p.Column))
            {
                return false;
            }
        }

        return true;
    }

    private void PlaceBlock()
    {
        foreach (Position p in CurrentBlock.GetTilePositions())
        {
            GameGrid[p.Row, p.Column] = CurrentBlock.Id;
        }

        GameGrid.ClearFullRows();
        if (IsGameOver())
        {
            gameOver = true;
        }
        else
        {
            CurrentBlock = BlockQueue.GetBlockAndUpdate();
        }
    }
}