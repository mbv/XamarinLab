using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Rg.Plugins.Popup.Pages;
using Rg.Plugins.Popup.Services;
using Xamarin.Forms;
using XamarinLab.Models;

namespace XamarinLab.Views
{
    public partial class NewPositionPage : PopupPage
    {

        public Position Position { get; set; }

        public NewPositionPage()
        {
            InitializeComponent();

            Position = new Position();

            BindingContext = this;
        }


        async void CancelButton_Clicked(object sender, EventArgs e)
        {
            await PopupNavigation.PopAsync(true);
        }
        async void OkButton_Clicked(object sender, EventArgs e)
        {
            MessagingCenter.Send(this, "AddPosition", Position);
            await PopupNavigation.PopAsync(true);
        }
    }
}
