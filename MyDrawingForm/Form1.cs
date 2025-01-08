using System;
using System.Collections.Generic;
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
                _model.DataGridRemoveShape(shapeList[e.RowIndex]);
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

        private void ToolStripConnectorButton_Click(object sender, EventArgs e)
        {
            pModel.SetConnectorMode();
        }

        private void ToolStripUndoButton_Click(object sender, EventArgs e)
        {
            pModel.Undo();
        }

        private void ToolStripRedoButton_Click(object sender, EventArgs e)
        {
            pModel.Redo();
        }

        private void RefreshState()
        {
            drawPanel.Cursor = pModel.CurrentCursor;
            toolStripStartButton.Checked = pModel.IsStartChecked;
            toolStripTerminatorButton.Checked = pModel.IsTerminatorChecked;
            toolStripProcessButton.Checked = pModel.IsProcessChecked;
            toolStripDecisionButton.Checked = pModel.IsDecisionChecked;
            toolStripSelectButton.Checked = pModel.IsSelectChecked;
            toolStripConnectorButton.Checked = pModel.IsConnectorChecked;

            toolStripUndoButton.Enabled = pModel.IsUndoEnabled;
            toolStripRedoButton.Enabled = pModel.IsRedoEnabled;

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


        private async void AutoSaveTimer_Tick(object sender, EventArgs e)
        {
            try
            {
                await Task.Factory.StartNew(() => pModel.AutoSaveAsync(this.Text));
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Auto-save failed. Error: {ex.Message}", "Auto-Save Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }
        private async void ToolStripSaveButton_Click(object sender, EventArgs e)
        {
            using (SaveFileDialog saveFileDialog = new SaveFileDialog())
            {
                saveFileDialog.Filter = "Backup (*.bak)|*.bak|All files (*.*)|*.*";
                if (saveFileDialog.ShowDialog() == DialogResult.OK)
                {
                    toolStripSaveButton.Enabled = false;
                    try
                    {
                        await Task.Factory.StartNew(() => pModel.SaveAsync(saveFileDialog.FileName));
                        MessageBox.Show("Save completed successfully.", "Save", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"Failed to save the file. Error: {ex.Message}", "Save Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    finally
                    {
                        toolStripSaveButton.Enabled = true;
                    }
                }
            }
        }

        private void ToolStripLoadButton_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                openFileDialog.Filter = "Backup (*.bak)|*.bak|All files (*.*)|*.*";
                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    try
                    {
                        pModel.Load(openFileDialog.FileName);
                        MessageBox.Show("Load completed successfully.", "Load", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"Failed to load the file. Error: {ex.Message}", "Load Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }
    }
}
