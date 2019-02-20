using System;
using Foundation;
using MvvmCross.Binding.BindingContext;
using MvvmCross.Platforms.Ios.Binding.Views;
using MvvmCross.Platforms.Ios.Presenters.Attributes;
using MvvmCross.Platforms.Ios.Views;
using TestMVVMCross.Core.ViewModel;
using UIKit;

namespace TestMVVMCross.iOS.Views
{
    [MvxRootPresentation(WrapInNavigationController = true)]
    public partial class ListExampleView : MvxViewController
    {
        public ListExampleView() : base("ListExampleView", null)
        {
        }

        public string[] list = {
            "Xamarin",
            "Windows",
            "iOS",
            "Android",
            "Visual Studio",
            "Azure",
            "UWP",
            "Xcode",
            "Cognitive Service"
        };

        public override void ViewDidLoad()
        {
            base.ViewDidLoad();

            var source = new TableSource(TableView);

            var set = this.CreateBindingSet<ListExampleView, Core.ViewModel.ListExampleViewModel>();
            set.Bind(TextField).To(vm => vm.Text);
            set.Bind(Button).To(vm => vm.ResetTextCommand);
            set.Bind(BackButton).To(vm => vm.NavigateBackCommand);
            set.Bind(source).To(vm => vm.Items);
            set.Bind(source).For(s => s.SelectionChangedCommand).To(vm => vm.ItemClickCommand);
            set.Apply();


            TableView.Source = source;
            // Perform any additional setup after loading the view, typically from a nib.
        }

        public override void DidReceiveMemoryWarning()
        {
            base.DidReceiveMemoryWarning();
            // Release any cached data, images, etc that aren't in use.
        }
    }

    public class TableSource : MvxTableViewSource
    {
        public TableSource(UITableView tableView) : base(tableView)
        {
            tableView.SeparatorStyle = UITableViewCellSeparatorStyle.None;
            tableView.RegisterNibForCellReuse(UINib.FromName("MyTableViewCell", NSBundle.MainBundle), "Cell");
        }

        protected override UITableViewCell GetOrCreateCellFor(UITableView tableView, NSIndexPath indexPath, object item)
        {
            var cell = (MyTableViewCell)TableView.DequeueReusableCell("Cell", indexPath);
            cell.Name = ((ListItemsModel)item).Name;
            return cell;
        }
    }
}

