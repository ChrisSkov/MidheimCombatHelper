using MidTest.ViewModels;
using System.ComponentModel;
using Xamarin.Forms;

namespace MidTest.Views
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