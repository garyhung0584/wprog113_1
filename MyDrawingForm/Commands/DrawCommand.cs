
namespace MyDrawingForm
{
    public class DrawCommand : ICommand
    {
        Shape shape;
        Model model;
        public DrawCommand(Model m, Shape s)
        {
            model = m;
            shape = s;
        }

        public void Execute()
        {
            model.AddShape(shape);
        }
        
        public void UnExecute()
        {
            model.RemoveShape(shape);
        }
    }
}
