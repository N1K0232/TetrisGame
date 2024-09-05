using TetrisGame.Shared;
using TetrisGame.Shared.Models.Common;

namespace TetrisGame.BusinessLayer.Services.Interfaces;
public interface IGameService
{
    BlockQueue BlockQueue { get; }
    Block CurrentBlock { get; }
    GameGrid GameGrid { get; }
    bool GameOver { get; }

    void MoveBlockDown();
    void MoveBlockLeft();
    void MoveBlockRight();
    void RotateBlockCCW();
    void RotateBlockCW();
}