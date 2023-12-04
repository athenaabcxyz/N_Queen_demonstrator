namespace NQueens
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

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
            panel1 = new Panel();
            numericUpDown_queen = new NumericUpDown();
            label1 = new Label();
            button_loadBoard = new Button();
            button_validate = new Button();
            button_solve = new Button();
            ((System.ComponentModel.ISupportInitialize)numericUpDown_queen).BeginInit();
            SuspendLayout();
            // 
            // panel1
            // 
            panel1.AutoScroll = true;
            panel1.Location = new Point(12, 12);
            panel1.Name = "panel1";
            panel1.Size = new Size(776, 433);
            panel1.TabIndex = 0;
            // 
            // numericUpDown_queen
            // 
            numericUpDown_queen.Location = new Point(12, 473);
            numericUpDown_queen.Minimum = new decimal(new int[] { 4, 0, 0, 0 });
            numericUpDown_queen.Name = "numericUpDown_queen";
            numericUpDown_queen.Size = new Size(120, 23);
            numericUpDown_queen.TabIndex = 1;
            numericUpDown_queen.Value = new decimal(new int[] { 4, 0, 0, 0 });
            numericUpDown_queen.ValueChanged += numericUpDown_queen_ValueChanged;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(12, 455);
            label1.Name = "label1";
            label1.Size = new Size(111, 15);
            label1.TabIndex = 2;
            label1.Text = "Number of Queens:";
            // 
            // button_loadBoard
            // 
            button_loadBoard.Location = new Point(138, 473);
            button_loadBoard.Name = "button_loadBoard";
            button_loadBoard.Size = new Size(127, 23);
            button_loadBoard.TabIndex = 3;
            button_loadBoard.Text = "Generate board";
            button_loadBoard.UseVisualStyleBackColor = true;
            button_loadBoard.Click += button_loadBoard_Click;
            // 
            // button_validate
            // 
            button_validate.Location = new Point(271, 473);
            button_validate.Name = "button_validate";
            button_validate.Size = new Size(127, 23);
            button_validate.TabIndex = 4;
            button_validate.Text = "Validate Board";
            button_validate.UseVisualStyleBackColor = true;
            button_validate.Click += button_validate_Click;
            // 
            // button_solve
            // 
            button_solve.Location = new Point(661, 473);
            button_solve.Name = "button_solve";
            button_solve.Size = new Size(127, 23);
            button_solve.TabIndex = 5;
            button_solve.Text = "Solve board";
            button_solve.UseVisualStyleBackColor = true;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 517);
            Controls.Add(button_solve);
            Controls.Add(button_validate);
            Controls.Add(button_loadBoard);
            Controls.Add(label1);
            Controls.Add(numericUpDown_queen);
            Controls.Add(panel1);
            Name = "Form1";
            Text = "NQueenIllustrator";
            ((System.ComponentModel.ISupportInitialize)numericUpDown_queen).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Panel panel1;
        private NumericUpDown numericUpDown_queen;
        private Label label1;
        private Button button_loadBoard;
        private Button button_validate;
        private Button button_solve;
    }
}