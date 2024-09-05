namespace TetrisGame.Shared;

public class GameGrid
{
    private int[,] grid;
    private int rows;
    private int columns;

    public GameGrid(int rows, int columns)
    {
        Rows = rows;
        Columns = columns;
    }

    public int Rows
    {
        get
        {
            return rows;
        }
        set
        {
            if (value != rows)
            {
                rows = value;
                RefreshGrid();
            }
        }
    }

    public int Columns
    {
        get
        {
            return columns;
        }
        set
        {
            if (value != columns)
            {
                columns = value;
                RefreshGrid();
            }
        }
    }

    public int this[int row, int column]
    {
        get => GetGridValue(row, column);
        set => SetGridValue(row, column, value);
    }

    public bool IsInside(int row, int column)
    {
        return row >= 0 && row < Rows && column >= 0 && column < Columns;
    }

    public bool IsEmpty(int row, int column)
    {
        return IsInside(row, column) && GetGridValue(row, column) == 0;
    }

    public bool IsRowFull(int row)
    {
        for (int column = 0; column < Columns; column++)
        {
            if (GetGridValue(row, column) == 0)
            {
                return false;
            }
        }

        return true;
    }

    public int ClearFullRows()
    {
        int rowsCleared = 0;

        for (int row = Rows - 1; row >= 0; row--)
        {
            if (IsRowFull(row))
            {
                ClearRow(row);
                rowsCleared++;
            }
            else if (rowsCleared > 0)
            {
                MoveRowDown(row, rowsCleared);
            }
        }

        return rowsCleared;
    }

    private void ClearRow(int row)
    {
        for (int column = 0; column < Columns; column++)
        {
            SetGridValue(row, column, 0);
        }
    }

    private void MoveRowDown(int row, int rowCount)
    {
        for (int column = 0; column < Columns; column++)
        {
            SetGridValue(row + rowCount, column, GetGridValue(row, column));
            SetGridValue(row, column, 0);
        }
    }

    private int GetGridValue(int row, int column)
    {
        return grid[row, column];
    }

    private void SetGridValue(int row, int column, int value)
    {
        int oldValue = GetGridValue(row, column);
        if (oldValue != value)
        {
            grid[row, column] = value;
        }
    }

    private void RefreshGrid()
    {
        grid = new int[rows, columns];
        for (int row = 0; row < rows; row++)
        {
            for (int column = 0; column < columns; column++)
            {
                grid[row, column] = 0;
            }
        }
    }
}