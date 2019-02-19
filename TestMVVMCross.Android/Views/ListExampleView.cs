
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using MvvmCross.Binding.BindingContext;
using MvvmCross.Platforms.Android.Views;

namespace TestMVVMCross.Android.Views
{
    [Activity(Label = "ListView")]
    public class ListExampleView : MvxActivity
    {
        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);
            SetContentView(Resource.Layout.ListExampleView);
            // Create your application here

            var editText = FindViewById<EditText>(Resource.Id.editText);
            var button = FindViewById<Button>(Resource.Id.button);
            var backButton = FindViewById<Button>(Resource.Id.backButton);

            var set = this.CreateBindingSet<ListExampleView, Core.ViewModel.ListExampleViewModel>();
            set.Bind(editText).To(vm => vm.Text);
            set.Bind(button).To(vm => vm.ResetTextCommand);
            set.Bind(backButton).To(vm => vm.NavigateBackCommand);
            set.Apply();
        }
    }
}
