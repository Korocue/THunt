namespace THuntGame;

partial class MainForm
{
    /// <summary>
    ///  Required designer variable.
    /// </summary>
    private System.ComponentModel.IContainer components = null;

    private Button newGameButton;

    /// <summary>
    ///  Clean up any resources being used.
    /// </summary>
    /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
    protected override void Dispose(bool disposing)
    {
        if (disposing && (components != null))
        {
            components.Dispose();
        }
        base.Dispose(disposing);
    }

    #region Windows Form Designer generated code

    /// <summary>
    ///  Required method for Designer support - do not modify
    ///  the contents of this method with the code editor.
    /// </summary>
    private void InitializeComponent()
    {
        components = new System.ComponentModel.Container();
        newGameButton = new Button();
        SuspendLayout();

        newGameButton.Location = new Point(12, 12);
        newGameButton.Name = "newGameButton";
        newGameButton.Size = new Size(120, 29);
        newGameButton.TabIndex = 0;
        newGameButton.Text = "New Game";
        newGameButton.UseVisualStyleBackColor = true;
        newGameButton.Click += NewGameButton_Click;

        AutoScaleMode = AutoScaleMode.Font;
        ClientSize = new Size(800, 450);
        Controls.Add(newGameButton);
        Name = "MainForm";
        Text = "T-Hunt";

        ResumeLayout(false);
    }

    #endregion
}
