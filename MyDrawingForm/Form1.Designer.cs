using System;
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
            this.刪除 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Shape = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.name = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.X = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Y = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Height = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Width = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.widthTextBox = new System.Windows.Forms.TextBox();
            this.heightTextBox = new System.Windows.Forms.TextBox();
            this.yTextBox = new System.Windows.Forms.TextBox();
            this.xTextBox = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
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
            this.drawPanel = new System.Windows.Forms.Panel();
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
            this.說明ToolStripMenuItem.Size = new System.Drawing.Size(43, 22);
            this.說明ToolStripMenuItem.Text = "說明";
            // 
            // 關於ToolStripMenuItem
            // 
            this.關於ToolStripMenuItem.Name = "關於ToolStripMenuItem";
            this.關於ToolStripMenuItem.Size = new System.Drawing.Size(98, 22);
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
            this.groupBox1.Controls.Add(this.widthTextBox);
            this.groupBox1.Controls.Add(this.heightTextBox);
            this.groupBox1.Controls.Add(this.yTextBox);
            this.groupBox1.Controls.Add(this.xTextBox);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.nameTextBox);
            this.groupBox1.Controls.Add(this.shapeAddComboBox);
            this.groupBox1.Controls.Add(this.addShape);
            this.groupBox1.Location = new System.Drawing.Point(692, 52);
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
            this.刪除,
            this.Shape,
            this.ID,
            this.name,
            this.X,
            this.Y,
            this.Height,
            this.Width});
            this.ShapeDataGridView.Location = new System.Drawing.Point(11, 77);
            this.ShapeDataGridView.Name = "ShapeDataGridView";
            this.ShapeDataGridView.ReadOnly = true;
            this.ShapeDataGridView.RowHeadersWidth = 4;
            this.ShapeDataGridView.RowTemplate.Height = 24;
            this.ShapeDataGridView.Size = new System.Drawing.Size(354, 534);
            this.ShapeDataGridView.TabIndex = 17;
            this.ShapeDataGridView.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.ShapeDataGridView_CellContentClick);
            // 
            // 刪除
            // 
            this.刪除.HeaderText = "刪除";
            this.刪除.Name = "刪除";
            this.刪除.ReadOnly = true;
            this.刪除.Width = 54;
            // 
            // Shape
            // 
            this.Shape.HeaderText = "Shape";
            this.Shape.Name = "Shape";
            this.Shape.ReadOnly = true;
            this.Shape.Width = 58;
            // 
            // ID
            // 
            this.ID.HeaderText = "ID";
            this.ID.Name = "ID";
            this.ID.ReadOnly = true;
            this.ID.Width = 42;
            // 
            // name
            // 
            this.name.HeaderText = "Text";
            this.name.Name = "name";
            this.name.ReadOnly = true;
            this.name.Width = 51;
            // 
            // X
            // 
            this.X.HeaderText = "X";
            this.X.Name = "X";
            this.X.ReadOnly = true;
            this.X.Width = 38;
            // 
            // Y
            // 
            this.Y.HeaderText = "Y";
            this.Y.Name = "Y";
            this.Y.ReadOnly = true;
            this.Y.Width = 38;
            // 
            // Height
            // 
            this.Height.HeaderText = "H";
            this.Height.Name = "Height";
            this.Height.ReadOnly = true;
            this.Height.Width = 38;
            // 
            // Width
            // 
            this.Width.HeaderText = "W";
            this.Width.Name = "Width";
            this.Width.ReadOnly = true;
            this.Width.Width = 41;
            // 
            // widthTextBox
            // 
            this.widthTextBox.Location = new System.Drawing.Point(335, 35);
            this.widthTextBox.Name = "widthTextBox";
            this.widthTextBox.Size = new System.Drawing.Size(30, 22);
            this.widthTextBox.TabIndex = 16;
            // 
            // heightTextBox
            // 
            this.heightTextBox.Location = new System.Drawing.Point(295, 35);
            this.heightTextBox.Name = "heightTextBox";
            this.heightTextBox.Size = new System.Drawing.Size(30, 22);
            this.heightTextBox.TabIndex = 15;
            // 
            // yTextBox
            // 
            this.yTextBox.Location = new System.Drawing.Point(255, 36);
            this.yTextBox.Name = "yTextBox";
            this.yTextBox.Size = new System.Drawing.Size(30, 22);
            this.yTextBox.TabIndex = 14;
            // 
            // xTextBox
            // 
            this.xTextBox.Location = new System.Drawing.Point(219, 36);
            this.xTextBox.Name = "xTextBox";
            this.xTextBox.Size = new System.Drawing.Size(30, 22);
            this.xTextBox.TabIndex = 13;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(343, 22);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(17, 12);
            this.label5.TabIndex = 12;
            this.label5.Text = "寬";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(301, 22);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(17, 12);
            this.label4.TabIndex = 11;
            this.label4.Text = "長";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(263, 22);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(13, 12);
            this.label3.TabIndex = 10;
            this.label3.Text = "Y";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(223, 22);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(13, 12);
            this.label2.TabIndex = 9;
            this.label2.Text = "X";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(171, 21);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(29, 12);
            this.label1.TabIndex = 8;
            this.label1.Text = "文字";
            // 
            // nameTextBox
            // 
            this.nameTextBox.Location = new System.Drawing.Point(159, 36);
            this.nameTextBox.Name = "nameTextBox";
            this.nameTextBox.Size = new System.Drawing.Size(57, 22);
            this.nameTextBox.TabIndex = 7;
            // 
            // shapeAddComboBox
            // 
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
            // 
            // addShape
            // 
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
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStartButton,
            this.toolStripTerminatorButton,
            this.toolStripProcessButton,
            this.toolStripDecisionButton});
            this.toolStrip1.Location = new System.Drawing.Point(0, 24);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(1080, 25);
            this.toolStrip1.TabIndex = 5;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // toolStripStartButton
            // 
            this.toolStripStartButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripStartButton.Image = ((System.Drawing.Image)(resources.GetObject("toolStripStartButton.Image")));
            this.toolStripStartButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripStartButton.Name = "toolStripStartButton";
            this.toolStripStartButton.Size = new System.Drawing.Size(23, 22);
            this.toolStripStartButton.Text = "Start";
            this.toolStripStartButton.Click += new System.EventHandler(this.ToolStripStartButton_Click);
            // 
            // toolStripTerminatorButton
            // 
            this.toolStripTerminatorButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripTerminatorButton.Image = ((System.Drawing.Image)(resources.GetObject("toolStripTerminatorButton.Image")));
            this.toolStripTerminatorButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripTerminatorButton.Name = "toolStripTerminatorButton";
            this.toolStripTerminatorButton.Size = new System.Drawing.Size(23, 22);
            this.toolStripTerminatorButton.Text = "Terminator";
            this.toolStripTerminatorButton.Click += new System.EventHandler(this.ToolStripTerminatorButton_Click);
            // 
            // toolStripProcessButton
            // 
            this.toolStripProcessButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripProcessButton.Image = ((System.Drawing.Image)(resources.GetObject("toolStripProcessButton.Image")));
            this.toolStripProcessButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripProcessButton.Name = "toolStripProcessButton";
            this.toolStripProcessButton.Size = new System.Drawing.Size(23, 22);
            this.toolStripProcessButton.Text = "Process";
            this.toolStripProcessButton.Click += new System.EventHandler(this.ToolStripProcessButton_Click);
            // 
            // toolStripDecisionButton
            // 
            this.toolStripDecisionButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripDecisionButton.Image = ((System.Drawing.Image)(resources.GetObject("toolStripDecisionButton.Image")));
            this.toolStripDecisionButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripDecisionButton.Name = "toolStripDecisionButton";
            this.toolStripDecisionButton.Size = new System.Drawing.Size(23, 22);
            this.toolStripDecisionButton.Text = "Decision";
            this.toolStripDecisionButton.Click += new System.EventHandler(this.ToolStripDecisionButton_Click);
            // 
            // drawPanel
            // 
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
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "Form1";
            this.Text = "MyDrawing";
            this.Load += new System.EventHandler(this.Form1_Load);
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
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.TextBox widthTextBox;
        private System.Windows.Forms.TextBox heightTextBox;
        private System.Windows.Forms.TextBox yTextBox;
        private System.Windows.Forms.TextBox xTextBox;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
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
        private DataGridViewTextBoxColumn 刪除;
        private DataGridViewTextBoxColumn Shape;
        private DataGridViewTextBoxColumn ID;
        private DataGridViewTextBoxColumn name;
        private DataGridViewTextBoxColumn X;
        private DataGridViewTextBoxColumn Y;
        private DataGridViewTextBoxColumn Height;
        private DataGridViewTextBoxColumn Width;
        private Panel drawPanel;
    }
}

