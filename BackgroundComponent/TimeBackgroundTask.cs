using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.ApplicationModel.Background;
using Windows.UI.Notifications;

namespace BackgroundComponent
{
    public sealed class TimeBackgroundTask : IBackgroundTask
    {
        public async void Run(IBackgroundTaskInstance taskInstance)
        {
            var deferral = taskInstance.GetDeferral();
            await SendToast();
            deferral.Complete();
        }

        private Task SendToast()
        {
            return Task.Factory.StartNew(() =>
            {
                var notificationXml = ToastNotificationManager.GetTemplateContent(ToastTemplateType.ToastText02);
                var toeastElement = notificationXml.GetElementsByTagName("text");
                toeastElement[0].AppendChild(notificationXml.CreateTextNode("TestBGT-OutProcess"));
                toeastElement[1].AppendChild(notificationXml.CreateTextNode($"{DateTime.Now.ToString("HH:mm:ss")}"));
                var toastNotification = new ToastNotification(notificationXml);
                ToastNotificationManager.CreateToastNotifier().Show(toastNotification);
            });
        }
    }
}
