using System;
using MvvmCross.Commands;
using MvvmCross.Navigation;
using MvvmCross.ViewModels;

namespace TestMVVMCross.Core.ViewModel
{
    public class ListExampleViewModel : MvxViewModel
    {

        private readonly IMvxNavigationService _navigationService;

        public ListExampleViewModel(IMvxNavigationService navigationService)
        {
            _navigationService = navigationService;
        }

        public IMvxCommand ResetTextCommand => new MvxCommand(ResetText);
        private void ResetText()
        {
            Text = "Hello MvvmCross";
        }

        private string _text = "Hello MvvmCross";

        public string Text
        {
            get { return _text; }
            set { SetProperty(ref _text, value); }
        }

        public IMvxCommand NavigateBackCommand => new MvxCommand(NavigateBack);

        private void NavigateBack()
        {
            _navigationService.Close(this);
        }

    }
}
