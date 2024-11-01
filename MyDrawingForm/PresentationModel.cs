using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MyDrawingForm
{
    public class PresentationModel
    {
        private bool _isStartChecked;
        private bool _isTerminatorChecked;
        private bool _isProcessChecked;
        private bool _isDecisionChecked;

        private Cursor _cursor;

        public Model _model;

        public PresentationModel(Model model)
        {
            this._model = model;

            _model.ModelChanged += UpdateState;
        }
        public bool IsStartChecked()
        {
            return _isStartChecked;
        }
        public bool IsTerminatorChecked()
        {
            return _isTerminatorChecked;
        }
        public bool IsProcessChecked()
        {
            return _isProcessChecked;
        }
        public bool IsDecisionChecked()
        {
            return _isDecisionChecked;
        }
        public Cursor GetCursor()
        {
            return _cursor;
        }
        public void UpdateState()
        {
            string mode = _model.GetDrawingMode();

            if (mode != "")
            {
                _cursor = Cursors.Cross;
            }
            else
            {
                _cursor = Cursors.Default;
            }

            _isStartChecked = mode == "Start";
            _isTerminatorChecked = mode == "Terminator";
            _isProcessChecked = mode == "Process";
            _isDecisionChecked = mode == "Decision";
        }

    }
}
