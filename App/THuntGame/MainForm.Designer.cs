namespace THuntGame;

partial class MainForm
{
    private System.ComponentModel.IContainer components = null;

    private Button resetButton;
    private Label scoreLabel;
    private TableLayoutPanel rootLayout;
    private FlowLayoutPanel headerLayout;
    private TableLayoutPanel boardLayout;

    protected override void Dispose(bool disposing)
    {
        if (disposing && (components != null))
        {
            components.Dispose();
        }
        base.Dispose(disposing);
    }

    #region Windows Form Designer generated code

    private void InitializeComponent()
    {
        components = new System.ComponentModel.Container();
        resetButton = new Button();
        scoreLabel = new Label();
        rootLayout = new TableLayoutPanel();
        headerLayout = new FlowLayoutPanel();
        boardLayout = new TableLayoutPanel();
        rootLayout.SuspendLayout();
        headerLayout.SuspendLayout();
        SuspendLayout();

        resetButton.AutoSize = true;
        resetButton.Name = "resetButton";
        resetButton.Size = new Size(110, 30);
        resetButton.TabIndex = 0;
        resetButton.Text = "Start / Reset";
        resetButton.UseVisualStyleBackColor = true;
        resetButton.Click += ResetButton_Click;

        scoreLabel.AutoSize = true;
        scoreLabel.Margin = new Padding(16, 8, 3, 3);
        scoreLabel.Name = "scoreLabel";
        scoreLabel.Size = new Size(64, 20);
        scoreLabel.TabIndex = 1;
        scoreLabel.Text = "Score: 0";

        headerLayout.AutoSize = true;
        headerLayout.Controls.Add(resetButton);
        headerLayout.Controls.Add(scoreLabel);
        headerLayout.Dock = DockStyle.Fill;
        headerLayout.FlowDirection = FlowDirection.LeftToRight;
        headerLayout.Location = new Point(3, 3);
        headerLayout.Name = "headerLayout";
        headerLayout.Size = new Size(794, 38);
        headerLayout.TabIndex = 0;
        headerLayout.WrapContents = false;

        boardLayout.Dock = DockStyle.Fill;
        boardLayout.Location = new Point(3, 47);
        boardLayout.Name = "boardLayout";
        boardLayout.Size = new Size(794, 400);
        boardLayout.TabIndex = 1;

        rootLayout.ColumnCount = 1;
        rootLayout.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
        rootLayout.Controls.Add(headerLayout, 0, 0);
        rootLayout.Controls.Add(boardLayout, 0, 1);
        rootLayout.Dock = DockStyle.Fill;
        rootLayout.Location = new Point(0, 0);
        rootLayout.Name = "rootLayout";
        rootLayout.RowCount = 2;
        rootLayout.RowStyles.Add(new RowStyle(SizeType.Absolute, 44F));
        rootLayout.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
        rootLayout.Size = new Size(800, 450);
        rootLayout.TabIndex = 0;

        AutoScaleMode = AutoScaleMode.Font;
        ClientSize = new Size(800, 450);
        Controls.Add(rootLayout);
        Name = "MainForm";
        Text = "T-Hunt";

        rootLayout.ResumeLayout(false);
        rootLayout.PerformLayout();
        headerLayout.ResumeLayout(false);
        headerLayout.PerformLayout();
        ResumeLayout(false);
    }

    #endregion
}
