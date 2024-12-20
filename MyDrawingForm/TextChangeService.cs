using System.Windows.Forms;
using MyDrawingForm.Commands;

namespace MyDrawingForm
{
    internal class TextChangeService
    {
        private Model _model;

        public TextChangeService(Model model)
        {
            _model = model;
        }

        public virtual void ShowTextChangeForm(Shape shape)
        {
            TextChangeForm textChangeform = new TextChangeForm(shape.ShapeText);
            DialogResult result = textChangeform.ShowDialog();
            if (result == DialogResult.OK)
            {
                _model.commandManager.Execute(new TextChangeCommand(shape, textChangeform.GetText()));
                _model.NotifyModelChanged();
            }
        }
    }
}
