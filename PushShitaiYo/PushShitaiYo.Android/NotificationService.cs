using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Android.App;
using Android.Content;
using Android.Gms.Common;
using Android.Gms.Extensions;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Firebase.Iid;
using Xamarin.Forms;

namespace PushShitaiYo.Droid
{
    class NotificationService : INotificationService
    {
        private const string ChannelId = "my_notification_Channel";

        public bool IsAvailable()
        {
            var context = Android.App.Application.Context;
            int resultCode = GoogleApiAvailability.Instance.IsGooglePlayServicesAvailable(context);

            return resultCode == ConnectionResult.Success;
        }

        public void ChangeToAvailable()
        {
            if (Build.VERSION.SdkInt < BuildVersionCodes.O) return;


            var channel = new NotificationChannel(
                ChannelId,
                "FCM Notifications",
                NotificationImportance.Default
            )
            {
                Description = "Firebase Cloud Messages appear in this channel"
            };

            var context = Android.App.Application.Context;
            var notifivationManager = (NotificationManager)context.GetSystemService(
                Context.NotificationService
            );
            notifivationManager.CreateNotificationChannel(channel);
        }

        public async Task<string> GetTokenAsync()
        {
            var result = await FirebaseInstanceId.Instance
                .GetInstanceId()
                .AsAsync<IInstanceIdResult>();

            return result.Token;
        }
    }
}
