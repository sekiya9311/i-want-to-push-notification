using Prism.Commands;
using Prism.Mvvm;
using Prism.Navigation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PushShitaiYo.ViewModels
{
    public class MainPageViewModel : ViewModelBase
    {
        private readonly INotificationService notificationService;

        public MainPageViewModel(INavigationService navigationService, INotificationService notificationService)
            : base(navigationService)
        {
            Title = "Main Page";
            this.notificationService = notificationService;

            this.notificationService.ChangeToAvailable();
        }
    }
}
