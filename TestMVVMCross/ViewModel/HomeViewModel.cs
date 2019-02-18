using System;
using MvvmCross.Commands;
using MvvmCross.ViewModels;

namespace TestMVVMCross.Core.ViewModel
{
    public class HomeViewModel : MvxViewModel
    {
        public IMvxCommand ResetTextCommand => new MvxCommand(ResetText);
        private void ResetText()
        {
            Text = "Hello MvvmCross";
            TextView = Text;
        }

        private string _text = "Hello MvvmCross";
        private string _text2 = "Hello MvvmCross";

        public string Text
        {
            get { return _text; }
            set { SetProperty(ref _text, value); }
        }

        public string TextView
        {
            get { return _text; }
            set { SetProperty(ref _text2, value); }
        }

        private double _value;

        public double Value
        {
             get { return _value; }
            set
            {
                SetProperty(ref _value, value);
            }
        }

    }
}
