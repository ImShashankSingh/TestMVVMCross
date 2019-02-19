using System;
using MvvmCross.Commands;
using MvvmCross.Navigation;
using MvvmCross.ViewModels;
using TestMVVMCross.NavigationArgs;

namespace TestMVVMCross.Core.ViewModel
{
    public class ListExampleViewModel : MvxViewModel<ListExampleViewModelArgs, ListExampleReturnArgs>
    {

        private readonly IMvxNavigationService _navigationService;

        public ListExampleViewModel(IMvxNavigationService navigationService)
        {
            _navigationService = navigationService;
        }

        public IMvxCommand ResetTextCommand => new MvxCommand(ResetText);
        private void ResetText()
        {
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
            _navigationService.Close(this, new ListExampleReturnArgs { textToHomeViewModel = Text });
        }

        public override void Prepare(ListExampleViewModelArgs parameter)
        {
            Text = parameter.textToSecondViewModel;
        }
    }
}
