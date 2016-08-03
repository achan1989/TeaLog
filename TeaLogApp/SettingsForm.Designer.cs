/* 
 * Copyright (c) 2016 Adrian Chan
 * 
 * Permission is hereby granted, free of charge, to any person obtaining a copy
 * of this software and associated documentation files (the "Software"), to deal
 * in the Software without restriction, including without limitation the rights
 * to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
 * copies of the Software, and to permit persons to whom the Software is
 * furnished to do so, subject to the following conditions:
 * 
 * The above copyright notice and this permission notice shall be included in
 * all copies or substantial portions of the Software.
 * 
 * THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
 * IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
 * FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
 * AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
 * LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
 * OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN
 * THE SOFTWARE.
 */


namespace TeaLog
{
    partial class SettingsForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
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
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.topLayoutPanel = new System.Windows.Forms.TableLayoutPanel();
            this.logFileLayoutPanel = new System.Windows.Forms.TableLayoutPanel();
            this.logFileLabel = new System.Windows.Forms.Label();
            this.logFileTextBox = new System.Windows.Forms.TextBox();
            this.logFileButton = new System.Windows.Forms.Button();
            this.categoriesLayoutPanel = new System.Windows.Forms.TableLayoutPanel();
            this.categoriesLabel = new System.Windows.Forms.Label();
            this.categoriesLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.categoryButtonsLayoutPanel = new System.Windows.Forms.FlowLayoutPanel();
            this.addButton = new System.Windows.Forms.Button();
            this.removeButton = new System.Windows.Forms.Button();
            this.upButton = new System.Windows.Forms.Button();
            this.downButton = new System.Windows.Forms.Button();
            this.categoriesListView = new System.Windows.Forms.ListView();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.cancelButton = new System.Windows.Forms.Button();
            this.saveButton = new System.Windows.Forms.Button();
            this.topLayoutPanel.SuspendLayout();
            this.logFileLayoutPanel.SuspendLayout();
            this.categoriesLayoutPanel.SuspendLayout();
            this.categoriesLayoutPanel2.SuspendLayout();
            this.categoryButtonsLayoutPanel.SuspendLayout();
            this.flowLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // topLayoutPanel
            // 
            this.topLayoutPanel.ColumnCount = 1;
            this.topLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.topLayoutPanel.Controls.Add(this.logFileLayoutPanel, 0, 0);
            this.topLayoutPanel.Controls.Add(this.categoriesLayoutPanel, 0, 1);
            this.topLayoutPanel.Controls.Add(this.flowLayoutPanel1, 0, 3);
            this.topLayoutPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.topLayoutPanel.Location = new System.Drawing.Point(0, 0);
            this.topLayoutPanel.Name = "topLayoutPanel";
            this.topLayoutPanel.RowCount = 4;
            this.topLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.topLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.topLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.topLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.topLayoutPanel.Size = new System.Drawing.Size(584, 562);
            this.topLayoutPanel.TabIndex = 0;
            // 
            // logFileLayoutPanel
            // 
            this.logFileLayoutPanel.AutoSize = true;
            this.logFileLayoutPanel.ColumnCount = 3;
            this.logFileLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.logFileLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.logFileLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.logFileLayoutPanel.Controls.Add(this.logFileLabel, 0, 0);
            this.logFileLayoutPanel.Controls.Add(this.logFileTextBox, 1, 0);
            this.logFileLayoutPanel.Controls.Add(this.logFileButton, 2, 0);
            this.logFileLayoutPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.logFileLayoutPanel.Location = new System.Drawing.Point(3, 3);
            this.logFileLayoutPanel.Name = "logFileLayoutPanel";
            this.logFileLayoutPanel.RowCount = 1;
            this.logFileLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.logFileLayoutPanel.Size = new System.Drawing.Size(578, 29);
            this.logFileLayoutPanel.TabIndex = 0;
            // 
            // logFileLabel
            // 
            this.logFileLabel.AutoSize = true;
            this.logFileLabel.Location = new System.Drawing.Point(3, 6);
            this.logFileLabel.Margin = new System.Windows.Forms.Padding(3, 6, 3, 3);
            this.logFileLabel.Name = "logFileLabel";
            this.logFileLabel.Size = new System.Drawing.Size(44, 13);
            this.logFileLabel.TabIndex = 0;
            this.logFileLabel.Text = "Log File";
            // 
            // logFileTextBox
            // 
            this.logFileTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.logFileTextBox.Location = new System.Drawing.Point(53, 3);
            this.logFileTextBox.Name = "logFileTextBox";
            this.logFileTextBox.Size = new System.Drawing.Size(490, 20);
            this.logFileTextBox.TabIndex = 1;
            // 
            // logFileButton
            // 
            this.logFileButton.AutoSize = true;
            this.logFileButton.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.logFileButton.Location = new System.Drawing.Point(549, 3);
            this.logFileButton.Name = "logFileButton";
            this.logFileButton.Size = new System.Drawing.Size(26, 23);
            this.logFileButton.TabIndex = 2;
            this.logFileButton.Text = "...";
            this.logFileButton.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.logFileButton.UseVisualStyleBackColor = true;
            // 
            // categoriesLayoutPanel
            // 
            this.categoriesLayoutPanel.ColumnCount = 1;
            this.categoriesLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.categoriesLayoutPanel.Controls.Add(this.categoriesLabel, 0, 0);
            this.categoriesLayoutPanel.Controls.Add(this.categoriesLayoutPanel2, 0, 1);
            this.categoriesLayoutPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.categoriesLayoutPanel.Location = new System.Drawing.Point(3, 38);
            this.categoriesLayoutPanel.Name = "categoriesLayoutPanel";
            this.categoriesLayoutPanel.RowCount = 2;
            this.categoriesLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.categoriesLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.categoriesLayoutPanel.Size = new System.Drawing.Size(578, 240);
            this.categoriesLayoutPanel.TabIndex = 1;
            // 
            // categoriesLabel
            // 
            this.categoriesLabel.AutoSize = true;
            this.categoriesLabel.Location = new System.Drawing.Point(3, 0);
            this.categoriesLabel.Name = "categoriesLabel";
            this.categoriesLabel.Size = new System.Drawing.Size(57, 13);
            this.categoriesLabel.TabIndex = 0;
            this.categoriesLabel.Text = "Categories";
            // 
            // categoriesLayoutPanel2
            // 
            this.categoriesLayoutPanel2.ColumnCount = 2;
            this.categoriesLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.categoriesLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.categoriesLayoutPanel2.Controls.Add(this.categoryButtonsLayoutPanel, 1, 0);
            this.categoriesLayoutPanel2.Controls.Add(this.categoriesListView, 0, 0);
            this.categoriesLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.categoriesLayoutPanel2.Location = new System.Drawing.Point(3, 16);
            this.categoriesLayoutPanel2.Name = "categoriesLayoutPanel2";
            this.categoriesLayoutPanel2.RowCount = 1;
            this.categoriesLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.categoriesLayoutPanel2.Size = new System.Drawing.Size(572, 221);
            this.categoriesLayoutPanel2.TabIndex = 1;
            // 
            // categoryButtonsLayoutPanel
            // 
            this.categoryButtonsLayoutPanel.AutoSize = true;
            this.categoryButtonsLayoutPanel.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.categoryButtonsLayoutPanel.Controls.Add(this.addButton);
            this.categoryButtonsLayoutPanel.Controls.Add(this.removeButton);
            this.categoryButtonsLayoutPanel.Controls.Add(this.upButton);
            this.categoryButtonsLayoutPanel.Controls.Add(this.downButton);
            this.categoryButtonsLayoutPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.categoryButtonsLayoutPanel.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            this.categoryButtonsLayoutPanel.Location = new System.Drawing.Point(540, 3);
            this.categoryButtonsLayoutPanel.Name = "categoryButtonsLayoutPanel";
            this.categoryButtonsLayoutPanel.Size = new System.Drawing.Size(29, 215);
            this.categoryButtonsLayoutPanel.TabIndex = 0;
            // 
            // addButton
            // 
            this.addButton.AutoSize = true;
            this.addButton.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.addButton.Location = new System.Drawing.Point(3, 3);
            this.addButton.Name = "addButton";
            this.addButton.Size = new System.Drawing.Size(23, 23);
            this.addButton.TabIndex = 0;
            this.addButton.Text = "+";
            this.addButton.UseVisualStyleBackColor = true;
            // 
            // removeButton
            // 
            this.removeButton.AutoSize = true;
            this.removeButton.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.removeButton.Location = new System.Drawing.Point(3, 32);
            this.removeButton.Name = "removeButton";
            this.removeButton.Size = new System.Drawing.Size(20, 23);
            this.removeButton.TabIndex = 1;
            this.removeButton.Text = "-";
            this.removeButton.UseVisualStyleBackColor = true;
            // 
            // upButton
            // 
            this.upButton.AutoSize = true;
            this.upButton.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.upButton.Location = new System.Drawing.Point(3, 61);
            this.upButton.Name = "upButton";
            this.upButton.Size = new System.Drawing.Size(23, 23);
            this.upButton.TabIndex = 2;
            this.upButton.Text = "^";
            this.upButton.UseVisualStyleBackColor = true;
            // 
            // downButton
            // 
            this.downButton.AutoSize = true;
            this.downButton.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.downButton.Location = new System.Drawing.Point(3, 90);
            this.downButton.Name = "downButton";
            this.downButton.Size = new System.Drawing.Size(23, 23);
            this.downButton.TabIndex = 3;
            this.downButton.Text = "v";
            this.downButton.UseVisualStyleBackColor = true;
            // 
            // categoriesListView
            // 
            this.categoriesListView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.categoriesListView.Location = new System.Drawing.Point(3, 3);
            this.categoriesListView.Name = "categoriesListView";
            this.categoriesListView.Size = new System.Drawing.Size(531, 215);
            this.categoriesListView.TabIndex = 1;
            this.categoriesListView.UseCompatibleStateImageBehavior = false;
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.AutoSize = true;
            this.flowLayoutPanel1.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.flowLayoutPanel1.Controls.Add(this.cancelButton);
            this.flowLayoutPanel1.Controls.Add(this.saveButton);
            this.flowLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flowLayoutPanel1.FlowDirection = System.Windows.Forms.FlowDirection.RightToLeft;
            this.flowLayoutPanel1.Location = new System.Drawing.Point(3, 530);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(578, 29);
            this.flowLayoutPanel1.TabIndex = 2;
            // 
            // cancelButton
            // 
            this.cancelButton.Location = new System.Drawing.Point(500, 3);
            this.cancelButton.Name = "cancelButton";
            this.cancelButton.Size = new System.Drawing.Size(75, 23);
            this.cancelButton.TabIndex = 0;
            this.cancelButton.Text = "Cancel";
            this.cancelButton.UseVisualStyleBackColor = true;
            // 
            // saveButton
            // 
            this.saveButton.Location = new System.Drawing.Point(419, 3);
            this.saveButton.Name = "saveButton";
            this.saveButton.Size = new System.Drawing.Size(75, 23);
            this.saveButton.TabIndex = 1;
            this.saveButton.Text = "Save";
            this.saveButton.UseVisualStyleBackColor = true;
            // 
            // SettingsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(584, 562);
            this.Controls.Add(this.topLayoutPanel);
            this.Name = "SettingsForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "TeaLog Settings";
            this.topLayoutPanel.ResumeLayout(false);
            this.topLayoutPanel.PerformLayout();
            this.logFileLayoutPanel.ResumeLayout(false);
            this.logFileLayoutPanel.PerformLayout();
            this.categoriesLayoutPanel.ResumeLayout(false);
            this.categoriesLayoutPanel.PerformLayout();
            this.categoriesLayoutPanel2.ResumeLayout(false);
            this.categoriesLayoutPanel2.PerformLayout();
            this.categoryButtonsLayoutPanel.ResumeLayout(false);
            this.categoryButtonsLayoutPanel.PerformLayout();
            this.flowLayoutPanel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel topLayoutPanel;
        private System.Windows.Forms.TableLayoutPanel logFileLayoutPanel;
        private System.Windows.Forms.Label logFileLabel;
        private System.Windows.Forms.TextBox logFileTextBox;
        private System.Windows.Forms.Button logFileButton;
        private System.Windows.Forms.TableLayoutPanel categoriesLayoutPanel;
        private System.Windows.Forms.Label categoriesLabel;
        private System.Windows.Forms.TableLayoutPanel categoriesLayoutPanel2;
        private System.Windows.Forms.FlowLayoutPanel categoryButtonsLayoutPanel;
        private System.Windows.Forms.Button addButton;
        private System.Windows.Forms.Button removeButton;
        private System.Windows.Forms.Button upButton;
        private System.Windows.Forms.Button downButton;
        private System.Windows.Forms.ListView categoriesListView;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private System.Windows.Forms.Button cancelButton;
        private System.Windows.Forms.Button saveButton;
    }
}