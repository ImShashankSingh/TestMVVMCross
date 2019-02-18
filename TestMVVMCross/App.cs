using System;
using MvvmCross.IoC;
using MvvmCross.ViewModels;
using TestMVVMCross.Core.ViewModel;

namespace TestMVVMCross
{
    public class App : MvxApplication
    {
        public override void Initialize()
        {
            CreatableTypes()
                .EndingWith("Service")
                .AsInterfaces()
                .RegisterAsLazySingleton();
            RegisterAppStart<HomeViewModel>();
        }
    }
}
