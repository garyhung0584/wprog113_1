using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
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
            this._model = pModel._model;
            
            drawPanel.MouseDown += HandleCanvasPointerPressed;
            drawPanel.MouseUp += HandleCanvasPointerReleased;
            drawPanel.MouseMove += HandleCanvasPointerMoved;
            drawPanel.Paint += HandleCanvasPaint;

            _model.ModelChanged += RefreshState;
            _model.ModelChanged += RefreshDataGrid;
            _model.ModelChanged += HandleModelChanged;
        }
        private void Form1_Load(object sender, EventArgs e)
        {

        }


        private void RefreshDataGrid()
        {
            ShapeDataGridView.Rows.Clear();
            shapeList = _model.GetShapes();
            foreach (Shape s in shapeList)
            {
                ShapeDataGridView.Rows.Add("刪除", s.GetType().Name,s.ShapeId, s.ShapeName, s.X, s.Y, s.Height, s.Width);
            }
        }

        private void AddShape_Click(object sender, EventArgs e)
        {
            try
            {
                string shape = (string)shapeAddComboBox.SelectedItem;
                string name = nameTextBox.Text;
                int x = Convert.ToInt32(xTextBox.Text);
                int y = Convert.ToInt32(yTextBox.Text);
                int height = Convert.ToInt32(heightTextBox.Text);
                int width = Convert.ToInt32(widthTextBox.Text);
                _model.AddShape(shape, name, x, y, height, width);
                RefreshDataGrid();
            }
            catch (Exception)
            {
                MessageBox.Show("Please fill in all fields accordingly");
                return;
            }
        }

        private void ShapeDataGridView_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 0 && e.RowIndex >= 0)
            {
                shapeList.RemoveAt(e.RowIndex);
                RefreshDataGrid();
            }
        }



        private void RefreshState()
        {
            drawPanel.Cursor = pModel.GetCursor();
            toolStripStartButton.Checked = pModel.IsStartChecked();
            toolStripTerminatorButton.Checked = pModel.IsTerminatorChecked();
            toolStripProcessButton.Checked = pModel.IsProcessChecked();
            toolStripDecisionButton.Checked = pModel.IsDecisionChecked();
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
        public void HandleCanvasPaint(object sender, PaintEventArgs e)
        {
            // e.Graphics物件是Paint事件帶進來的，只能在當次Paint使用
            // 而Adaptor又直接使用e.Graphics，因此，Adaptor不能重複使用
            // 每次都要重新new
            _model.Draw(new GraphicsAdaptor(e.Graphics));
        }

        private void ToolStripStartButton_Click(object sender, EventArgs e)
        {
            _model.SetDrawingMode("Start");
        }

        private void ToolStripTerminatorButton_Click(object sender, EventArgs e)
        {
            _model.SetDrawingMode("Terminator");
        }

        private void ToolStripProcessButton_Click(object sender, EventArgs e)
        {
            _model.SetDrawingMode("Process");
        }

        private void ToolStripDecisionButton_Click(object sender, EventArgs e)
        {
            _model.SetDrawingMode("Decision");
        }

        public void HandleModelChanged()
        {
            Invalidate(true);
        }
    }
}
