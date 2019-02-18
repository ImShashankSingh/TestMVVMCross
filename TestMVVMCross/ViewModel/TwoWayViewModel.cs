using System;
using MvvmCross.ViewModels;

namespace TestMVVMCross.Core.ViewModel
{
    public class TwoWayViewModel : MvxViewModel
    {
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
