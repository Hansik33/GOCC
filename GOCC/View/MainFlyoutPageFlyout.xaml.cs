using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using GOCC.Model;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace GOCC.View
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MainFlyoutPageFlyout : ContentPage
    {
        public ListView ListView;

        public MainFlyoutPageFlyout()
        {
            InitializeComponent();

            BindingContext = new MainFlyoutPageFlyoutViewModel();
            ListView = MenuItemsListView;
        }

        class MainFlyoutPageFlyoutViewModel : INotifyPropertyChanged
        {
            public ObservableCollection<MainFlyoutPageFlyoutMenuItem> MenuItems { get; set; }

            public MainFlyoutPageFlyoutViewModel()
            {
                MenuItems = new ObservableCollection<MainFlyoutPageFlyoutMenuItem>(new[]
                {
                    new MainFlyoutPageFlyoutMenuItem { Id = 0, Title = "Strona główna", TargetType = typeof(MainFlyoutPageDetail) },
                    new MainFlyoutPageFlyoutMenuItem { Id = 1, Title = "Wydarzenia", TargetType = typeof(CalendarPage) },
                    new MainFlyoutPageFlyoutMenuItem { Id = 2, Title = "Regulamin", TargetType = typeof(RegulationsPage) },
                    new MainFlyoutPageFlyoutMenuItem { Id = 3, Title = "Sponsorzy", TargetType = typeof(SponsorsPage) },
                });
            }

            #region INotifyPropertyChanged Implementation
            public event PropertyChangedEventHandler PropertyChanged;
            void OnPropertyChanged([CallerMemberName] string propertyName = "")
            {
                if (PropertyChanged == null)
                    return;

                PropertyChanged.Invoke(this, new PropertyChangedEventArgs(propertyName));
            }
            #endregion
        }
    }
}