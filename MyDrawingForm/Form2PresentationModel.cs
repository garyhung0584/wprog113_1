using System.ComponentModel;

namespace MyDrawingForm
{
    internal class Form2PresentationModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        public bool IsConfirmEnabled { get; set; }

        string _text;
        public Form2PresentationModel(string text)
        {
            _text = text;
            IsConfirmEnabled = false;
        }

        public void TextChanged(string text)
        {
            if (text.Length > 0 && text != _text)
            {
                IsConfirmEnabled = true;
            }
            else
            {
                IsConfirmEnabled = false;
            }
            Notify("IsConfirmEnabled");
        }


        private void Notify(string propertyName)
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
        }

    }
}
