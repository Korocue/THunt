namespace THuntGame;

public sealed class GameBoard
{
    private readonly Cell[,] cells;

    public int Rows { get; }
    public int Columns { get; }

    public GameBoard(int rows, int columns)
    {
        if (rows <= 0) throw new ArgumentOutOfRangeException(nameof(rows));
        if (columns <= 0) throw new ArgumentOutOfRangeException(nameof(columns));

        Rows = rows;
        Columns = columns;
        cells = new Cell[rows, columns];
    }

    public Cell GetCell(int row, int column) => cells[row, column];

    public void Reset(int mineCount, double treasureChance)
    {
        if (mineCount < 0) throw new ArgumentOutOfRangeException(nameof(mineCount));
        if (mineCount >= Rows * Columns) throw new ArgumentOutOfRangeException(nameof(mineCount));
        if (treasureChance < 0 || treasureChance > 1) throw new ArgumentOutOfRangeException(nameof(treasureChance));

        for (var r = 0; r < Rows; r++)
        {
            for (var c = 0; c < Columns; c++)
            {
                cells[r, c] = default;
            }
        }

        var placed = 0;
        while (placed < mineCount)
        {
            var index = Random.Shared.Next(Rows * Columns);
            var r = index / Columns;
            var c = index % Columns;

            if (cells[r, c].IsMine)
            {
                continue;
            }

            cells[r, c].IsMine = true;
            placed++;
        }

        for (var r = 0; r < Rows; r++)
        {
            for (var c = 0; c < Columns; c++)
            {
                if (cells[r, c].IsMine)
                {
                    continue;
                }

                cells[r, c].AdjacentMines = CountAdjacentMines(r, c);
            }
        }

        for (var r = 0; r < Rows; r++)
        {
            for (var c = 0; c < Columns; c++)
            {
                if (cells[r, c].IsMine)
                {
                    continue;
                }

                if (Random.Shared.NextDouble() < treasureChance)
                {
                    cells[r, c].IsTreasure = true;
                    cells[r, c].AdjacentMines = 0;
                }
            }
        }
    }

    public bool ToggleFlag(int row, int column)
    {
        ref var cell = ref cells[row, column];
        if (cell.IsRevealed)
        {
            return false;
        }

        cell.IsFlagged = !cell.IsFlagged;
        return true;
    }

    public RevealResult Reveal(int row, int column)
    {
        ref var startCell = ref cells[row, column];
        if (startCell.IsRevealed || startCell.IsFlagged)
        {
            return RevealResult.None;
        }

        if (startCell.IsMine)
        {
            startCell.IsRevealed = true;
            return new RevealResult(HitMine: true, FoundTreasure: false, Revealed: [(row, column)]);
        }

        if (startCell.IsTreasure)
        {
            startCell.IsRevealed = true;
            return new RevealResult(HitMine: false, FoundTreasure: true, Revealed: [(row, column)]);
        }

        var revealed = new List<(int row, int column)>();
        var queue = new Queue<(int row, int column)>();
        queue.Enqueue((row, column));

        while (queue.Count > 0)
        {
            var (r, c) = queue.Dequeue();
            ref var cell = ref cells[r, c];

            if (cell.IsRevealed || cell.IsFlagged)
            {
                continue;
            }

            cell.IsRevealed = true;
            revealed.Add((r, c));

            if (cell.AdjacentMines != 0)
            {
                continue;
            }

            foreach (var (nr, nc) in GetNeighbors(r, c))
            {
                ref var neighbor = ref cells[nr, nc];
                if (neighbor.IsRevealed || neighbor.IsFlagged || neighbor.IsMine || neighbor.IsTreasure)
                {
                    continue;
                }

                queue.Enqueue((nr, nc));
            }
        }

        return new RevealResult(HitMine: false, FoundTreasure: false, revealed);
    }

    private int CountAdjacentMines(int row, int column)
    {
        var count = 0;
        foreach (var (r, c) in GetNeighbors(row, column))
        {
            if (cells[r, c].IsMine)
            {
                count++;
            }
        }
        return count;
    }

    private IEnumerable<(int row, int column)> GetNeighbors(int row, int column)
    {
        for (var dr = -1; dr <= 1; dr++)
        {
            for (var dc = -1; dc <= 1; dc++)
            {
                if (dr == 0 && dc == 0)
                {
                    continue;
                }

                var r = row + dr;
                var c = column + dc;
                if (r < 0 || r >= Rows || c < 0 || c >= Columns)
                {
                    continue;
                }

                yield return (r, c);
            }
        }
    }

    public struct Cell
    {
        public bool IsMine;
        public bool IsTreasure;
        public int AdjacentMines;
        public bool IsRevealed;
        public bool IsFlagged;
    }

    public readonly record struct RevealResult(bool HitMine, bool FoundTreasure, IReadOnlyList<(int row, int column)> Revealed)
    {
        public static RevealResult None { get; } = new(HitMine: false, FoundTreasure: false, Revealed: Array.Empty<(int, int)>());
    }
}


