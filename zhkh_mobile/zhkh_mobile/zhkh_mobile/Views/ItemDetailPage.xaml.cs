using System.ComponentModel;
using Xamarin.Forms;
using zhkh_mobile.ViewModels;

namespace zhkh_mobile.Views
{
    public partial class ItemDetailPage : ContentPage
    {
        public ItemDetailPage()
        {
            InitializeComponent();
            BindingContext = new ItemDetailViewModel();
        }
    }
}