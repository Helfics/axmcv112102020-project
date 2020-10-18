using System;
using Android.App;
using Android.Content;
using AndroidX.Work;

namespace RssReader.Droid.Services
{
    public class SyncWorker : Worker
    {
        private readonly Context context;

        public SyncWorker(Context context, WorkerParameters workerParam) : base(context, workerParam)
        {
            this.context = context;
        }

        public override Result DoWork()
        {
            var nm = context.GetSystemService(Context.NotificationService) as NotificationManager;

            nm.CreateNotificationChannel(new NotificationChannel("rssreadersyncworker", "rssreadersyncworker", NotificationImportance.Default));

            var notification = new Notification.Builder(context, "rssreadersyncworker")
                .SetContentTitle("Hello")
                .SetContentText($"Notification depuis le sync service at {DateTime.Now.ToString():dd/MM/yyyy}")
                .SetSmallIcon(Resource.Mipmap.ic_launcher)
                .Build();

            nm.Notify(1, notification);

            return Result.InvokeSuccess();
        }
    }

    [BroadcastReceiver]
    [IntentFilter(new string[] {
        Intent.ActionBootCompleted,
        Intent.ActionReboot
    })]
    public class BootBroadcastReceiver : BroadcastReceiver
    {
        public override void OnReceive(Context context, Intent intent)
        {
            var pr = PeriodicWorkRequest.Builder.From<SyncWorker>(TimeSpan.FromSeconds(15)).Build();

            WorkManager.Instance.EnqueueUniquePeriodicWork("fr.orsys.rssreader.syncworker", ExistingPeriodicWorkPolicy.Replace, pr);
        }
    }
}
