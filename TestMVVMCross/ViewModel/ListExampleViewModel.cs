using System;
using System.Collections.ObjectModel;
using MvvmCross.Commands;
using MvvmCross.Navigation;
using MvvmCross.ViewModels;
using TestMVVMCross.NavigationArgs;

namespace TestMVVMCross.Core.ViewModel
{
    public class ListExampleViewModel : MvxViewModel<ListExampleViewModelArgs, ListExampleReturnArgs>
    {

        private readonly IMvxNavigationService _navigationService;

        //public static event EventHandler<ListItemsModel> ClickEvent;

        public ListExampleViewModel(IMvxNavigationService navigationService)
        {
            _navigationService = navigationService;

            Items = new ObservableCollection<ListItemsModel>() {
                new ListItemsModel()
                {
                    Name = "Tesla Model S"
                },
                  new ListItemsModel()
                {
                    Name = "Audi R8"
                }
            };
        }

        public IMvxCommand ResetTextCommand => new MvxCommand(ResetText);
        private void ResetText()
        {
            Items.Add(new ListItemsModel() {
                Name = Text
            });
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

        private ObservableCollection<ListItemsModel> _items;
        public ObservableCollection<ListItemsModel> Items
        {
            get { return _items; }
            set
            {
                _items = value;
            }
        }

        public IMvxCommand ItemClickCommand
        {
            get
            {
                return new MvxCommand<ListItemsModel>(HandleClickAction);
            }
        }


        void HandleClickAction(ListItemsModel obj)
        {
            //ClickEvent?.Invoke(this, obj);
        }


        //private void ClickCommand()
        //{

        //}

    }

    public class ListItemsModel
    {
        public string Name { get; set; }
    }
}
