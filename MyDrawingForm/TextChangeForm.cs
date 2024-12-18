using System;
using System.Windows.Forms;

namespace MyDrawingForm
{
    public partial class TextChangeForm : Form
    {
        Form2PresentationModel pModel;
        public TextChangeForm(string text)
        {
            InitializeComponent();
            pModel = new Form2PresentationModel(text);
            textBox1.Text = text;

            buttonConfirm.DataBindings.Add("Enabled", pModel, "IsConfirmEnabled");
        }


        private void TextBox1_TextChanged(object sender, EventArgs e)
        {
            pModel.TextChanged(textBox1.Text);
        }

        public string GetText()
        {
            return textBox1.Text;
        }
    }
}
