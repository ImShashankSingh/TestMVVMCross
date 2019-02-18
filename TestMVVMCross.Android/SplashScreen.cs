
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.Content.PM;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using MvvmCross.Platforms.Android.Core;
using MvvmCross.Platforms.Android.Views;
using TestMVVMCross.Android.Views;

namespace TestMVVMCross.Android
{
    [Activity(Label = "Splash Screen", MainLauncher = true, NoHistory = true, ScreenOrientation = ScreenOrientation.Portrait)]
    //<MvxAndroidSetup<TestMVVMCross.App>, TestMVVMCross.App>
    public class SplashScreen : MvxSplashScreenActivity<MvxAndroidSetup<TestMVVMCross.App>, TestMVVMCross.App>
    {
        public SplashScreen() : base(Resource.Layout.SplashScreen)
        {
        }
        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);
            StartActivity(typeof(HomeView));
        }
    }
}
