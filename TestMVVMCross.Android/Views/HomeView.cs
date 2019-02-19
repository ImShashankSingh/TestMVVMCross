using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Util;
using Android.Views;
using Android.Widget;
using MvvmCross.Binding.BindingContext;
using MvvmCross.Platforms.Android.Presenters.Attributes;
using MvvmCross.Platforms.Android.Views;

namespace TestMVVMCross.Android.Views
{
    [Activity(Label = "View for HomeViewModel")]
    public class HomeView : MvxActivity
    {
        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);
            SetContentView(Resource.Layout.HomeView);

            var editText = FindViewById<EditText>(Resource.Id.editText);
            var button = FindViewById<Button>(Resource.Id.button);
            var textView = FindViewById<EditText>(Resource.Id.textView);
            var textView2 = FindViewById<TextView>(Resource.Id.textView2);
            var nextButton = FindViewById<Button>(Resource.Id.buttonNext);

            var set = this.CreateBindingSet<HomeView, Core.ViewModel.HomeViewModel>();
            set.Bind(editText).To(vm => vm.Text);
            set.Bind(button).To(vm => vm.ResetTextCommand);
            set.Bind(textView).To(vm => vm.Value).WithConversion("TwoWayTest");
            set.Bind(textView2).To(vm => vm.Value);
            set.Apply();

            nextButton.Click += NextButton_Click;
        }

        void NextButton_Click(object sender, EventArgs e)
        {
            StartActivity(typeof(ListExampleView));
        }

    }
}
