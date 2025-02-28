﻿using System;
using System.Windows.Forms;

namespace MyDrawingForm
{
    partial class Form1
    {
        /// <summary>
        /// 設計工具所需的變數。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清除任何使用中的資源。
        /// </summary>
        /// <param name="disposing">如果應該處置受控資源則為 true，否則為 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form 設計工具產生的程式碼

        /// <summary>
        /// 此為設計工具支援所需的方法 - 請勿使用程式碼編輯器修改
        /// 這個方法的內容。
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.說明ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.關於ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.ShapeDataGridView = new System.Windows.Forms.DataGridView();
            this.Remove = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Shape = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.name = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.X = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Y = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Width = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Height = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.heightTextBox = new System.Windows.Forms.TextBox();
            this.widthTextBox = new System.Windows.Forms.TextBox();
            this.yTextBox = new System.Windows.Forms.TextBox();
            this.xTextBox = new System.Windows.Forms.TextBox();
            this.HLabel = new System.Windows.Forms.Label();
            this.WLabel = new System.Windows.Forms.Label();
            this.YLabel = new System.Windows.Forms.Label();
            this.XLabel = new System.Windows.Forms.Label();
            this.nameLabel = new System.Windows.Forms.Label();
            this.nameTextBox = new System.Windows.Forms.TextBox();
            this.shapeAddComboBox = new System.Windows.Forms.ComboBox();
            this.addShape = new System.Windows.Forms.Button();
            this.shapeBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.toolStripStartButton = new System.Windows.Forms.ToolStripButton();
            this.toolStripTerminatorButton = new System.Windows.Forms.ToolStripButton();
            this.toolStripProcessButton = new System.Windows.Forms.ToolStripButton();
            this.toolStripDecisionButton = new System.Windows.Forms.ToolStripButton();
            this.toolStripConnectorButton = new System.Windows.Forms.ToolStripButton();
            this.toolStripSelectButton = new System.Windows.Forms.ToolStripButton();
            this.toolStripUndoButton = new System.Windows.Forms.ToolStripButton();
            this.toolStripRedoButton = new System.Windows.Forms.ToolStripButton();
            this.toolStripSaveButton = new System.Windows.Forms.ToolStripButton();
            this.toolStripLoadButton = new System.Windows.Forms.ToolStripButton();
            this.drawPanel = new MyDrawingForm.DoubleBufferedPanel();
            this.menuStrip1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ShapeDataGridView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.shapeBindingSource)).BeginInit();
            this.toolStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(24, 24);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.說明ToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Padding = new System.Windows.Forms.Padding(4, 1, 0, 1);
            this.menuStrip1.Size = new System.Drawing.Size(1080, 24);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // 說明ToolStripMenuItem
            // 
            this.說明ToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.關於ToolStripMenuItem});
            this.說明ToolStripMenuItem.Name = "說明ToolStripMenuItem";
            this.說明ToolStripMenuItem.Size = new System.Drawing.Size(45, 22);
            this.說明ToolStripMenuItem.Text = "說明";
            // 
            // 關於ToolStripMenuItem
            // 
            this.關於ToolStripMenuItem.Name = "關於ToolStripMenuItem";
            this.關於ToolStripMenuItem.Size = new System.Drawing.Size(100, 22);
            this.關於ToolStripMenuItem.Text = "關於";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(12, 60);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(145, 110);
            this.button1.TabIndex = 1;
            this.button1.Text = "button1";
            this.button1.UseVisualStyleBackColor = true;
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(12, 177);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(145, 110);
            this.button2.TabIndex = 2;
            this.button2.Text = "button2";
            this.button2.UseVisualStyleBackColor = true;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.ShapeDataGridView);
            this.groupBox1.Controls.Add(this.heightTextBox);
            this.groupBox1.Controls.Add(this.widthTextBox);
            this.groupBox1.Controls.Add(this.yTextBox);
            this.groupBox1.Controls.Add(this.xTextBox);
            this.groupBox1.Controls.Add(this.HLabel);
            this.groupBox1.Controls.Add(this.WLabel);
            this.groupBox1.Controls.Add(this.YLabel);
            this.groupBox1.Controls.Add(this.XLabel);
            this.groupBox1.Controls.Add(this.nameLabel);
            this.groupBox1.Controls.Add(this.nameTextBox);
            this.groupBox1.Controls.Add(this.shapeAddComboBox);
            this.groupBox1.Controls.Add(this.addShape);
            this.groupBox1.Location = new System.Drawing.Point(692, 60);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(376, 625);
            this.groupBox1.TabIndex = 4;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "資料顯示";
            // 
            // ShapeDataGridView
            // 
            this.ShapeDataGridView.AllowUserToAddRows = false;
            this.ShapeDataGridView.AllowUserToDeleteRows = false;
            this.ShapeDataGridView.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.ShapeDataGridView.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.ShapeDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.ShapeDataGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Remove,
            this.Shape,
            this.ID,
            this.name,
            this.X,
            this.Y,
            this.Width,
            this.Height});
            this.ShapeDataGridView.Location = new System.Drawing.Point(11, 77);
            this.ShapeDataGridView.Name = "ShapeDataGridView";
            this.ShapeDataGridView.ReadOnly = true;
            this.ShapeDataGridView.RowHeadersWidth = 4;
            this.ShapeDataGridView.RowTemplate.Height = 24;
            this.ShapeDataGridView.Size = new System.Drawing.Size(354, 534);
            this.ShapeDataGridView.TabIndex = 17;
            this.ShapeDataGridView.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.ShapeDataGridView_CellContentClick);
            // 
            // Remove
            // 
            this.Remove.HeaderText = "刪除";
            this.Remove.MinimumWidth = 8;
            this.Remove.Name = "Remove";
            this.Remove.ReadOnly = true;
            this.Remove.ToolTipText = "Remove";
            this.Remove.Width = 54;
            // 
            // Shape
            // 
            this.Shape.HeaderText = "Shape";
            this.Shape.MinimumWidth = 8;
            this.Shape.Name = "Shape";
            this.Shape.ReadOnly = true;
            this.Shape.Width = 58;
            // 
            // ID
            // 
            this.ID.HeaderText = "ID";
            this.ID.MinimumWidth = 8;
            this.ID.Name = "ID";
            this.ID.ReadOnly = true;
            this.ID.Width = 42;
            // 
            // name
            // 
            this.name.HeaderText = "Text";
            this.name.MinimumWidth = 8;
            this.name.Name = "name";
            this.name.ReadOnly = true;
            this.name.Width = 51;
            // 
            // X
            // 
            this.X.HeaderText = "X";
            this.X.MinimumWidth = 8;
            this.X.Name = "X";
            this.X.ReadOnly = true;
            this.X.Width = 38;
            // 
            // Y
            // 
            this.Y.HeaderText = "Y";
            this.Y.MinimumWidth = 8;
            this.Y.Name = "Y";
            this.Y.ReadOnly = true;
            this.Y.Width = 38;
            // 
            // Width
            // 
            this.Width.HeaderText = "H";
            this.Width.MinimumWidth = 8;
            this.Width.Name = "Width";
            this.Width.ReadOnly = true;
            this.Width.Width = 38;
            // 
            // Height
            // 
            this.Height.HeaderText = "W";
            this.Height.MinimumWidth = 8;
            this.Height.Name = "Height";
            this.Height.ReadOnly = true;
            this.Height.Width = 41;
            // 
            // heightTextBox
            // 
            this.heightTextBox.AccessibleName = "heightTextBox";
            this.heightTextBox.Location = new System.Drawing.Point(335, 35);
            this.heightTextBox.Name = "heightTextBox";
            this.heightTextBox.Size = new System.Drawing.Size(30, 22);
            this.heightTextBox.TabIndex = 16;
            this.heightTextBox.TextChanged += new System.EventHandler(this.HeightTextBox_TextChanged);
            // 
            // widthTextBox
            // 
            this.widthTextBox.AccessibleName = "widthTextBox";
            this.widthTextBox.Location = new System.Drawing.Point(295, 35);
            this.widthTextBox.Name = "widthTextBox";
            this.widthTextBox.Size = new System.Drawing.Size(30, 22);
            this.widthTextBox.TabIndex = 15;
            this.widthTextBox.TextChanged += new System.EventHandler(this.WidthTextBox_TextChanged);
            // 
            // yTextBox
            // 
            this.yTextBox.AccessibleName = "yTextBox";
            this.yTextBox.Location = new System.Drawing.Point(255, 36);
            this.yTextBox.Name = "yTextBox";
            this.yTextBox.Size = new System.Drawing.Size(30, 22);
            this.yTextBox.TabIndex = 14;
            this.yTextBox.TextChanged += new System.EventHandler(this.YTextBox_TextChanged);
            // 
            // xTextBox
            // 
            this.xTextBox.AccessibleName = "xTextBox";
            this.xTextBox.Location = new System.Drawing.Point(219, 36);
            this.xTextBox.Name = "xTextBox";
            this.xTextBox.Size = new System.Drawing.Size(30, 22);
            this.xTextBox.TabIndex = 13;
            this.xTextBox.TextChanged += new System.EventHandler(this.XTextBox_TextChanged);
            // 
            // HLabel
            // 
            this.HLabel.AutoSize = true;
            this.HLabel.ForeColor = System.Drawing.Color.Red;
            this.HLabel.Location = new System.Drawing.Point(343, 22);
            this.HLabel.Name = "HLabel";
            this.HLabel.Size = new System.Drawing.Size(16, 12);
            this.HLabel.TabIndex = 12;
            this.HLabel.Text = "W";
            // 
            // WLabel
            // 
            this.WLabel.AutoSize = true;
            this.WLabel.ForeColor = System.Drawing.Color.Red;
            this.WLabel.Location = new System.Drawing.Point(301, 22);
            this.WLabel.Name = "WLabel";
            this.WLabel.Size = new System.Drawing.Size(13, 12);
            this.WLabel.TabIndex = 11;
            this.WLabel.Text = "H";
            // 
            // YLabel
            // 
            this.YLabel.AutoSize = true;
            this.YLabel.ForeColor = System.Drawing.Color.Red;
            this.YLabel.Location = new System.Drawing.Point(263, 22);
            this.YLabel.Name = "YLabel";
            this.YLabel.Size = new System.Drawing.Size(13, 12);
            this.YLabel.TabIndex = 10;
            this.YLabel.Text = "Y";
            // 
            // XLabel
            // 
            this.XLabel.AutoSize = true;
            this.XLabel.ForeColor = System.Drawing.Color.Red;
            this.XLabel.Location = new System.Drawing.Point(223, 22);
            this.XLabel.Name = "XLabel";
            this.XLabel.Size = new System.Drawing.Size(13, 12);
            this.XLabel.TabIndex = 9;
            this.XLabel.Text = "X";
            // 
            // nameLabel
            // 
            this.nameLabel.AutoSize = true;
            this.nameLabel.ForeColor = System.Drawing.Color.Red;
            this.nameLabel.Location = new System.Drawing.Point(171, 21);
            this.nameLabel.Name = "nameLabel";
            this.nameLabel.Size = new System.Drawing.Size(29, 12);
            this.nameLabel.TabIndex = 8;
            this.nameLabel.Text = "文字";
            // 
            // nameTextBox
            // 
            this.nameTextBox.AccessibleName = "nameTextBox";
            this.nameTextBox.Location = new System.Drawing.Point(159, 36);
            this.nameTextBox.Name = "nameTextBox";
            this.nameTextBox.Size = new System.Drawing.Size(57, 22);
            this.nameTextBox.TabIndex = 7;
            this.nameTextBox.TextChanged += new System.EventHandler(this.NameTextBox_TextChanged);
            // 
            // shapeAddComboBox
            // 
            this.shapeAddComboBox.AccessibleName = "shapeAddComboBox";
            this.shapeAddComboBox.FormattingEnabled = true;
            this.shapeAddComboBox.Items.AddRange(new object[] {
            "Start",
            "Terminator",
            "Process",
            "Decision"});
            this.shapeAddComboBox.Location = new System.Drawing.Point(65, 38);
            this.shapeAddComboBox.Margin = new System.Windows.Forms.Padding(2);
            this.shapeAddComboBox.Name = "shapeAddComboBox";
            this.shapeAddComboBox.Size = new System.Drawing.Size(89, 20);
            this.shapeAddComboBox.TabIndex = 6;
            this.shapeAddComboBox.Text = "形狀";
            this.shapeAddComboBox.SelectedIndexChanged += new System.EventHandler(this.ShapeAddComboBox_SelectedIndexChanged);
            // 
            // addShape
            // 
            this.addShape.AccessibleName = "addShape";
            this.addShape.Location = new System.Drawing.Point(6, 20);
            this.addShape.Margin = new System.Windows.Forms.Padding(2);
            this.addShape.Name = "addShape";
            this.addShape.Size = new System.Drawing.Size(55, 38);
            this.addShape.TabIndex = 5;
            this.addShape.Text = "新增";
            this.addShape.UseVisualStyleBackColor = true;
            this.addShape.Click += new System.EventHandler(this.AddShape_Click);
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.ImageScalingSize = new System.Drawing.Size(24, 24);
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(61, 4);
            // 
            // toolStrip1
            // 
            this.toolStrip1.ImageScalingSize = new System.Drawing.Size(24, 24);
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStartButton,
            this.toolStripTerminatorButton,
            this.toolStripProcessButton,
            this.toolStripDecisionButton,
            this.toolStripConnectorButton,
            this.toolStripSelectButton,
            this.toolStripUndoButton,
            this.toolStripRedoButton,
            this.toolStripSaveButton,
            this.toolStripLoadButton});
            this.toolStrip1.Location = new System.Drawing.Point(0, 24);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Padding = new System.Windows.Forms.Padding(0, 0, 2, 0);
            this.toolStrip1.Size = new System.Drawing.Size(1080, 31);
            this.toolStrip1.TabIndex = 5;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // toolStripStartButton
            // 
            this.toolStripStartButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripStartButton.Image = ((System.Drawing.Image)(resources.GetObject("toolStripStartButton.Image")));
            this.toolStripStartButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripStartButton.Name = "toolStripStartButton";
            this.toolStripStartButton.Size = new System.Drawing.Size(28, 28);
            this.toolStripStartButton.Text = "Start";
            this.toolStripStartButton.Click += new System.EventHandler(this.ToolStripStartButton_Click);
            // 
            // toolStripTerminatorButton
            // 
            this.toolStripTerminatorButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripTerminatorButton.Image = ((System.Drawing.Image)(resources.GetObject("toolStripTerminatorButton.Image")));
            this.toolStripTerminatorButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripTerminatorButton.Name = "toolStripTerminatorButton";
            this.toolStripTerminatorButton.Size = new System.Drawing.Size(28, 28);
            this.toolStripTerminatorButton.Text = "Terminator";
            this.toolStripTerminatorButton.Click += new System.EventHandler(this.ToolStripTerminatorButton_Click);
            // 
            // toolStripProcessButton
            // 
            this.toolStripProcessButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripProcessButton.Image = ((System.Drawing.Image)(resources.GetObject("toolStripProcessButton.Image")));
            this.toolStripProcessButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripProcessButton.Name = "toolStripProcessButton";
            this.toolStripProcessButton.Size = new System.Drawing.Size(28, 28);
            this.toolStripProcessButton.Text = "Process";
            this.toolStripProcessButton.Click += new System.EventHandler(this.ToolStripProcessButton_Click);
            // 
            // toolStripDecisionButton
            // 
            this.toolStripDecisionButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripDecisionButton.Image = ((System.Drawing.Image)(resources.GetObject("toolStripDecisionButton.Image")));
            this.toolStripDecisionButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripDecisionButton.Name = "toolStripDecisionButton";
            this.toolStripDecisionButton.Size = new System.Drawing.Size(28, 28);
            this.toolStripDecisionButton.Text = "Decision";
            this.toolStripDecisionButton.Click += new System.EventHandler(this.ToolStripDecisionButton_Click);
            // 
            // toolStripConnectorButton
            // 
            this.toolStripConnectorButton.AccessibleName = "toolStripConnectorButton";
            this.toolStripConnectorButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripConnectorButton.Image = ((System.Drawing.Image)(resources.GetObject("toolStripConnectorButton.Image")));
            this.toolStripConnectorButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripConnectorButton.Name = "toolStripConnectorButton";
            this.toolStripConnectorButton.Size = new System.Drawing.Size(28, 28);
            this.toolStripConnectorButton.Text = "toolStripConnectorButton";
            this.toolStripConnectorButton.Click += new System.EventHandler(this.ToolStripConnectorButton_Click);
            // 
            // toolStripSelectButton
            // 
            this.toolStripSelectButton.AccessibleName = "toolStripSelectButton";
            this.toolStripSelectButton.Checked = true;
            this.toolStripSelectButton.CheckState = System.Windows.Forms.CheckState.Checked;
            this.toolStripSelectButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripSelectButton.Image = ((System.Drawing.Image)(resources.GetObject("toolStripSelectButton.Image")));
            this.toolStripSelectButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripSelectButton.Name = "toolStripSelectButton";
            this.toolStripSelectButton.Size = new System.Drawing.Size(28, 28);
            this.toolStripSelectButton.Text = "toolStripSelectButton";
            this.toolStripSelectButton.ToolTipText = "Select";
            this.toolStripSelectButton.Click += new System.EventHandler(this.ToolStripSelectButton_Click);
            // 
            // toolStripUndoButton
            // 
            this.toolStripUndoButton.AccessibleName = "toolStripUndoButton";
            this.toolStripUndoButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripUndoButton.Enabled = false;
            this.toolStripUndoButton.Image = ((System.Drawing.Image)(resources.GetObject("toolStripUndoButton.Image")));
            this.toolStripUndoButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripUndoButton.Name = "toolStripUndoButton";
            this.toolStripUndoButton.Size = new System.Drawing.Size(28, 28);
            this.toolStripUndoButton.Text = "toolStripUndoButton";
            this.toolStripUndoButton.Click += new System.EventHandler(this.ToolStripUndoButton_Click);
            // 
            // toolStripRedoButton
            // 
            this.toolStripRedoButton.AccessibleName = "toolStripRedoButton";
            this.toolStripRedoButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripRedoButton.Enabled = false;
            this.toolStripRedoButton.Image = ((System.Drawing.Image)(resources.GetObject("toolStripRedoButton.Image")));
            this.toolStripRedoButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripRedoButton.Name = "toolStripRedoButton";
            this.toolStripRedoButton.Size = new System.Drawing.Size(28, 28);
            this.toolStripRedoButton.Text = "toolStripRedoButton";
            this.toolStripRedoButton.Click += new System.EventHandler(this.ToolStripRedoButton_Click);
            // 
            // toolStripSaveButton
            // 
            this.toolStripSaveButton.AccessibleName = "toolStripSaveButton";
            this.toolStripSaveButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripSaveButton.Image = ((System.Drawing.Image)(resources.GetObject("toolStripSaveButton.Image")));
            this.toolStripSaveButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripSaveButton.Name = "toolStripSaveButton";
            this.toolStripSaveButton.Size = new System.Drawing.Size(28, 28);
            this.toolStripSaveButton.Text = "toolStripSaveButton";
            this.toolStripSaveButton.Click += new System.EventHandler(this.ToolStripSaveButton_Click);
            // 
            // toolStripLoadButton
            // 
            this.toolStripLoadButton.AccessibleName = "toolStripLoadButton";
            this.toolStripLoadButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripLoadButton.Image = ((System.Drawing.Image)(resources.GetObject("toolStripLoadButton.Image")));
            this.toolStripLoadButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripLoadButton.Name = "toolStripLoadButton";
            this.toolStripLoadButton.Size = new System.Drawing.Size(28, 28);
            this.toolStripLoadButton.Text = "toolStripLoadButton";
            this.toolStripLoadButton.Click += new System.EventHandler(this.ToolStripLoadButton_Click);
            // 
            // drawPanel
            // 
            this.drawPanel.AccessibleName = "DrawPanel";
            this.drawPanel.Location = new System.Drawing.Point(163, 60);
            this.drawPanel.Name = "drawPanel";
            this.drawPanel.Size = new System.Drawing.Size(523, 617);
            this.drawPanel.TabIndex = 6;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1080, 690);
            this.Controls.Add(this.drawPanel);
            this.Controls.Add(this.toolStrip1);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.menuStrip1);
            this.KeyPreview = true;
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "Form1";
            this.Text = "MyDrawing";
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ShapeDataGridView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.shapeBindingSource)).EndInit();
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem 說明ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 關於ToolStripMenuItem;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.ComboBox shapeAddComboBox;
        private System.Windows.Forms.Button addShape;
        private System.Windows.Forms.TextBox nameTextBox;
        private System.Windows.Forms.Label XLabel;
        private System.Windows.Forms.Label nameLabel;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.TextBox heightTextBox;
        private System.Windows.Forms.TextBox widthTextBox;
        private System.Windows.Forms.TextBox yTextBox;
        private System.Windows.Forms.TextBox xTextBox;
        private System.Windows.Forms.Label HLabel;
        private System.Windows.Forms.Label WLabel;
        private System.Windows.Forms.Label YLabel;
        private System.Windows.Forms.DataGridViewTextBoxColumn shapeNameDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn xDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn yDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn widthDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn heightDataGridViewTextBoxColumn;
        private System.Windows.Forms.BindingSource shapeBindingSource;
        private DataGridView ShapeDataGridView;
        private ToolStrip toolStrip1;
        private ToolStripButton toolStripStartButton;
        private ToolStripButton toolStripTerminatorButton;
        private ToolStripButton toolStripProcessButton;
        private ToolStripButton toolStripDecisionButton;
        private ToolStripButton toolStripSelectButton;
        private DoubleBufferedPanel drawPanel;
        private ToolStripButton toolStripUndoButton;
        private ToolStripButton toolStripRedoButton;
        private ToolStripButton toolStripConnectorButton;
        private DataGridViewTextBoxColumn Remove;
        private DataGridViewTextBoxColumn Shape;
        private DataGridViewTextBoxColumn ID;
        private DataGridViewTextBoxColumn name;
        private DataGridViewTextBoxColumn X;
        private DataGridViewTextBoxColumn Y;
        private DataGridViewTextBoxColumn Width;
        private DataGridViewTextBoxColumn Height;
        private ToolStripButton toolStripSaveButton;
        private ToolStripButton toolStripLoadButton;
    }
}
