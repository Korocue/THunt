namespace THuntGame;

public partial class MainForm : Form
{
    private const int BoardRows = 10;
    private const int BoardColumns = 10;
    private const int MineCount = 15;
    private const double TreasureChance = 0.05;

    private readonly GameBoard board = new(BoardRows, BoardColumns);
    private readonly Button[,] cellButtons = new Button[BoardRows, BoardColumns];

    private int score;
    private bool gameOver;

    public MainForm()
    {
        InitializeComponent();
        InitializeBoardButtons();
        ResetStage();
    }

    private void ResetButton_Click(object? sender, EventArgs e) => ResetStage();

    private void CellButton_MouseUp(object? sender, MouseEventArgs e)
    {
        if (sender is not Button button || button.Tag is not Point point)
        {
            return;
        }

        if (gameOver)
        {
            return;
        }

        var row = point.X;
        var column = point.Y;

        if (e.Button == MouseButtons.Right)
        {
            if (!board.ToggleFlag(row, column))
            {
                return;
            }

            var cell = board.GetCell(row, column);
            button.Text = cell.IsFlagged ? "F" : "";
            return;
        }

        if (e.Button != MouseButtons.Left)
        {
            return;
        }

        var result = board.Reveal(row, column);
        if (result.Revealed.Count == 0)
        {
            return;
        }

        if (result.HitMine)
        {
            gameOver = true;
            score /= 2;
            UpdateScoreLabel();
            RevealAllMines();
            MessageBox.Show("Game Over!", "T-Hunt", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            return;
        }

        if (result.FoundTreasure)
        {
            score++;
            UpdateScoreLabel();
        }

        foreach (var (r, c) in result.Revealed)
        {
            RenderRevealedCell(r, c);
        }

        if (result.FoundTreasure)
        {
            RenderRevealedCell(row, column);
        }
    }

    private void InitializeBoardButtons()
    {
        boardLayout.SuspendLayout();
        boardLayout.Controls.Clear();
        boardLayout.ColumnStyles.Clear();
        boardLayout.RowStyles.Clear();

        boardLayout.ColumnCount = BoardColumns;
        boardLayout.RowCount = BoardRows;

        for (var c = 0; c < BoardColumns; c++)
        {
            boardLayout.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100f / BoardColumns));
        }

        for (var r = 0; r < BoardRows; r++)
        {
            boardLayout.RowStyles.Add(new RowStyle(SizeType.Percent, 100f / BoardRows));
        }

        for (var r = 0; r < BoardRows; r++)
        {
            for (var c = 0; c < BoardColumns; c++)
            {
                var button = new Button
                {
                    Dock = DockStyle.Fill,
                    Margin = new Padding(1),
                    Font = new Font(FontFamily.GenericSansSerif, 10f, FontStyle.Bold),
                    Tag = new Point(r, c),
                    Text = "",
                };

                button.MouseUp += CellButton_MouseUp;
                cellButtons[r, c] = button;
                boardLayout.Controls.Add(button, c, r);
            }
        }

        boardLayout.ResumeLayout();
    }

    private void ResetStage()
    {
        gameOver = false;
        board.Reset(mineCount: MineCount, treasureChance: TreasureChance);

        for (var r = 0; r < BoardRows; r++)
        {
            for (var c = 0; c < BoardColumns; c++)
            {
                var button = cellButtons[r, c];
                button.Enabled = true;
                button.Text = "";
                button.BackColor = SystemColors.Control;
                button.ForeColor = SystemColors.ControlText;
            }
        }
    }

    private void UpdateScoreLabel()
    {
        scoreLabel.Text = $"Score: {score}";
    }

    private void RevealAllMines()
    {
        for (var r = 0; r < BoardRows; r++)
        {
            for (var c = 0; c < BoardColumns; c++)
            {
                var cell = board.GetCell(r, c);
                if (!cell.IsMine)
                {
                    continue;
                }

                var button = cellButtons[r, c];
                button.Enabled = false;
                button.Text = "X";
                button.BackColor = Color.IndianRed;
                button.ForeColor = Color.White;
            }
        }
    }

    private void RenderRevealedCell(int row, int column)
    {
        var cell = board.GetCell(row, column);
        var button = cellButtons[row, column];

        button.Enabled = false;
        button.BackColor = Color.Gainsboro;

        if (cell.IsTreasure)
        {
            button.Text = "★";
            button.ForeColor = Color.DarkGoldenrod;
            return;
        }

        if (cell.AdjacentMines > 0)
        {
            button.Text = cell.AdjacentMines.ToString();
            button.ForeColor = Color.Navy;
        }
        else
        {
            button.Text = "";
        }
    }
}

