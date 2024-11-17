using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MyDrawingForm
{
    public partial class Form1 : Form
    {
        Model _model;
        PresentationModel pModel;
        List<Shape> shapeList = new List<Shape>();

        public Form1(PresentationModel presentationModel)
        {
            InitializeComponent();

            this.pModel = presentationModel;
            this._model = pModel.model;

            drawPanel.MouseDown += HandleCanvasPointerPressed;
            drawPanel.MouseUp += HandleCanvasPointerReleased;
            drawPanel.MouseMove += HandleCanvasPointerMoved;
            drawPanel.Paint += HandleCanvasPaint;

            KeyDown += KeyDownHandler;
            KeyUp += KeyUpHandler;

            _model.ModelChanged += HandleModelChanged;


            addShape.DataBindings.Add("Enabled", pModel, "IsCreateEnabled");

            _model.EnterPointerState();
        }

        private void AddShape_Click(object sender, EventArgs e)
        {
            pModel.AddShape();
        }

        private void ShapeDataGridView_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 0 && e.RowIndex >= 0)
            {
                shapeList.RemoveAt(e.RowIndex);
                HandleModelChanged();
            }
        }

        public void HandleCanvasPointerPressed(object sender, MouseEventArgs e)
        {
            _model.PointerPressed(e.X, e.Y);
        }

        public void HandleCanvasPointerReleased(object sender, MouseEventArgs e)
        {
            _model.PointerReleased(e.X, e.Y);
        }

        public void HandleCanvasPointerMoved(object sender, MouseEventArgs e)
        {
            _model.PointerMoved(e.X, e.Y);
        }
        private void KeyDownHandler(object sender, KeyEventArgs e)
        {
            // 注意：同一個鍵持續按著不放會自動Auto repeat
            _model.KeyDown(e.KeyValue);
            // Invalidate(); // 如果Model不會變就不需要Invalidate
        }

        private void KeyUpHandler(object sender, KeyEventArgs e)
        {
            _model.KeyUp(e.KeyValue);
            // Invalidate(); // 如果Model不會變就不需要Invalidate
        }


        public void HandleCanvasPaint(object sender, PaintEventArgs e)
        {
            _model.Draw(new GraphicsAdaptor(e.Graphics));
        }

        private void ToolStripStartButton_Click(object sender, EventArgs e)
        {
            pModel.SetStartMode();
        }

        private void ToolStripTerminatorButton_Click(object sender, EventArgs e)
        {
            pModel.SetTerminatorMode();
        }

        private void ToolStripProcessButton_Click(object sender, EventArgs e)
        {
            pModel.SetProcessMode();
        }

        private void ToolStripDecisionButton_Click(object sender, EventArgs e)
        {
            pModel.SetDecisionMode();
        }
        private void ToolStripSelectButton_Click(object sender, EventArgs e)
        {
            pModel.SetSelectMode();
        }

        private void RefreshState()
        {
            drawPanel.Cursor = pModel.GetCursor();
            toolStripStartButton.Checked = pModel.IsStartChecked;
            toolStripTerminatorButton.Checked = pModel.IsTerminatorChecked;
            toolStripProcessButton.Checked = pModel.IsProcessChecked;
            toolStripDecisionButton.Checked = pModel.IsDecisionChecked;
            toolStripSelectButton.Checked = pModel.IsSelectChecked;

            ShapeDataGridView.Rows.Clear();
            shapeList = _model.GetShapes();
            foreach (Shape s in shapeList)
            {
                ShapeDataGridView.Rows.Add("刪除", s.GetType().Name, s.ShapeId, s.ShapeText, s.X, s.Y, s.Height, s.Width);
            }
        }

        public void HandleModelChanged()
        {
            Invalidate(true);
            RefreshState();
        }


        private void NameTextBox_TextChanged(object sender, EventArgs e)
        {
            pModel.NameTextBoxTextChanged(nameTextBox.Text);
            nameLabel.ForeColor = pModel.NameLabelColor;
        }

        private void XTextBox_TextChanged(object sender, EventArgs e)
        {
            pModel.XTextBoxTextChanged(xTextBox.Text);
            XLabel.ForeColor = pModel.XLabelColor;
        }

        private void YTextBox_TextChanged(object sender, EventArgs e)
        {
            pModel.YTextBoxTextChanged(yTextBox.Text);
            YLabel.ForeColor = pModel.YLabelColor;
        }

        private void HeightTextBox_TextChanged(object sender, EventArgs e)
        {
            pModel.HeightTextBoxTextChanged(heightTextBox.Text);
            HLabel.ForeColor = pModel.HeightLabelColor;
        }

        private void WidthTextBox_TextChanged(object sender, EventArgs e)
        {
            pModel.WidthTextBoxTextChanged(widthTextBox.Text);
            WLabel.ForeColor = pModel.WidthLabelColor;
        }

        private void ShapeAddComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            pModel.ShapeAddComboBoxSelectedIndexChanged(shapeAddComboBox.SelectedItem.ToString());
        }

    }
}
