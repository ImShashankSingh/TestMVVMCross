using System;

using Foundation;
using MvvmCross.Platforms.Ios.Binding.Views;
using UIKit;

namespace TestMVVMCross.iOS.Views
{
    public partial class MyTableViewCell : MvxTableViewCell
    {
        public static readonly NSString Key = new NSString("MyTableViewCell");
        public static readonly UINib Nib;
        public string Name { get { return TextField.Text; } set { TextField.Text = value; } }
        static MyTableViewCell()
        {
            Nib = UINib.FromName("MyTableViewCell", NSBundle.MainBundle);
        }

        protected MyTableViewCell(IntPtr handle) : base(handle)
        {
            // Note: this .ctor should not contain any initialization logic.
        }

    }
}
