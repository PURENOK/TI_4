namespace TI_4
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
            OpenFileButton = new Button();
            SignatureFileButton = new Button();
            GenerateSign = new Button();
            CheckSign = new Button();
            SaveSignFile = new Button();
            textBoxQ = new TextBox();
            TextBoxH = new TextBox();
            textBoxX = new TextBox();
            textBoxK = new TextBox();
            textBoxP = new TextBox();
            TextBoxForHash = new TextBox();
            textBoxForSign = new TextBox();
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            label4 = new Label();
            label5 = new Label();
            textBoxFileContent = new TextBox();
            SuspendLayout();
            // 
            // OpenFileButton
            // 
            OpenFileButton.Location = new Point(174, 164);
            OpenFileButton.Name = "OpenFileButton";
            OpenFileButton.Size = new Size(108, 54);
            OpenFileButton.TabIndex = 0;
            OpenFileButton.Text = "Открыть файл";
            OpenFileButton.UseVisualStyleBackColor = true;
            OpenFileButton.Click += OpenFileButton_Click;
            // 
            // SignatureFileButton
            // 
            SignatureFileButton.Location = new Point(303, 164);
            SignatureFileButton.Name = "SignatureFileButton";
            SignatureFileButton.Size = new Size(121, 54);
            SignatureFileButton.TabIndex = 1;
            SignatureFileButton.Text = "Открыть подписанный файл";
            SignatureFileButton.UseVisualStyleBackColor = true;
            SignatureFileButton.Click += SignatureFileButton_Click;
            // 
            // GenerateSign
            // 
            GenerateSign.Location = new Point(32, 164);
            GenerateSign.Name = "GenerateSign";
            GenerateSign.Size = new Size(108, 54);
            GenerateSign.TabIndex = 2;
            GenerateSign.Text = "Сгенерировать подпись";
            GenerateSign.UseVisualStyleBackColor = true;
            GenerateSign.Click += GenerateSign_Click;
            // 
            // CheckSign
            // 
            CheckSign.Location = new Point(445, 164);
            CheckSign.Name = "CheckSign";
            CheckSign.Size = new Size(108, 54);
            CheckSign.TabIndex = 3;
            CheckSign.Text = "Проверить подпись";
            CheckSign.UseVisualStyleBackColor = true;
            CheckSign.Click += CheckSign_Click;
            // 
            // SaveSignFile
            // 
            SaveSignFile.Location = new Point(174, 224);
            SaveSignFile.Name = "SaveSignFile";
            SaveSignFile.Size = new Size(108, 54);
            SaveSignFile.TabIndex = 4;
            SaveSignFile.Text = "Сохранить подписанный файл";
            SaveSignFile.UseVisualStyleBackColor = true;
            SaveSignFile.Click += SaveSignFile_Click;
            // 
            // textBoxQ
            // 
            textBoxQ.Location = new Point(32, 43);
            textBoxQ.Name = "textBoxQ";
            textBoxQ.Size = new Size(100, 23);
            textBoxQ.TabIndex = 5;
            // 
            // TextBoxH
            // 
            TextBoxH.Location = new Point(191, 43);
            TextBoxH.Name = "TextBoxH";
            TextBoxH.Size = new Size(100, 23);
            TextBoxH.TabIndex = 6;
            // 
            // textBoxX
            // 
            textBoxX.Location = new Point(191, 94);
            textBoxX.Name = "textBoxX";
            textBoxX.Size = new Size(100, 23);
            textBoxX.TabIndex = 7;
            // 
            // textBoxK
            // 
            textBoxK.Location = new Point(353, 43);
            textBoxK.Name = "textBoxK";
            textBoxK.Size = new Size(100, 23);
            textBoxK.TabIndex = 8;
            // 
            // textBoxP
            // 
            textBoxP.Location = new Point(32, 94);
            textBoxP.Name = "textBoxP";
            textBoxP.Size = new Size(100, 23);
            textBoxP.TabIndex = 9;
            // 
            // TextBoxForHash
            // 
            TextBoxForHash.Location = new Point(32, 321);
            TextBoxForHash.Multiline = true;
            TextBoxForHash.Name = "TextBoxForHash";
            TextBoxForHash.ReadOnly = true;
            TextBoxForHash.Size = new Size(132, 106);
            TextBoxForHash.TabIndex = 10;
            // 
            // textBoxForSign
            // 
            textBoxForSign.Location = new Point(191, 321);
            textBoxForSign.Multiline = true;
            textBoxForSign.Name = "textBoxForSign";
            textBoxForSign.ReadOnly = true;
            textBoxForSign.Size = new Size(132, 106);
            textBoxForSign.TabIndex = 11;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(32, 25);
            label1.Name = "label1";
            label1.Size = new Size(16, 15);
            label1.TabIndex = 12;
            label1.Text = "Q";
           
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(32, 76);
            label2.Name = "label2";
            label2.Size = new Size(14, 15);
            label2.TabIndex = 13;
            label2.Text = "P";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(191, 25);
            label3.Name = "label3";
            label3.Size = new Size(16, 15);
            label3.TabIndex = 14;
            label3.Text = "H";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(191, 76);
            label4.Name = "label4";
            label4.Size = new Size(14, 15);
            label4.TabIndex = 15;
            label4.Text = "X";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(353, 25);
            label5.Name = "label5";
            label5.Size = new Size(14, 15);
            label5.TabIndex = 16;
            label5.Text = "K";
            // 
            // textBoxFileContent
            // 
            textBoxFileContent.Location = new Point(353, 321);
            textBoxFileContent.Multiline = true;
            textBoxFileContent.Name = "textBoxFileContent";
            textBoxFileContent.ReadOnly = true;
            textBoxFileContent.Size = new Size(132, 106);
            textBoxFileContent.TabIndex = 17;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(textBoxFileContent);
            Controls.Add(label5);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(textBoxForSign);
            Controls.Add(TextBoxForHash);
            Controls.Add(textBoxP);
            Controls.Add(textBoxK);
            Controls.Add(textBoxX);
            Controls.Add(TextBoxH);
            Controls.Add(textBoxQ);
            Controls.Add(SaveSignFile);
            Controls.Add(CheckSign);
            Controls.Add(GenerateSign);
            Controls.Add(SignatureFileButton);
            Controls.Add(OpenFileButton);
            Name = "Form1";
            Text = "Form1";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button OpenFileButton;
        private Button SignatureFileButton;
        private Button GenerateSign;
        private Button CheckSign;
        private Button SaveSignFile;
        private TextBox textBoxQ;
        private TextBox TextBoxH;
        private TextBox textBoxX;
        private TextBox textBoxK;
        private TextBox textBoxP;
        private TextBox TextBoxForHash;
        private TextBox textBoxForSign;
        private Label label1;
        private Label label2;
        private Label label3;
        private Label label4;
        private Label label5;
        private TextBox textBoxFileContent;
    }
}
