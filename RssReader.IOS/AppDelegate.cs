using System;
using Foundation;
using UIKit;

namespace RssReader.IOS
{
    // The UIApplicationDelegate for the application. This class is responsible for launching the
    // User Interface of the application, as well as listening (and optionally responding) to application events from iOS.
    [Register("AppDelegate")]
    public class AppDelegate : UIResponder, IUIApplicationDelegate
    {

        [Export("window")]
        public UIWindow Window { get; set; }

        [Export("application:didFinishLaunchingWithOptions:")]
        public bool FinishedLaunching(UIApplication application, NSDictionary launchOptions)
        {
            UIApplication.SharedApplication.SetMinimumBackgroundFetchInterval(10);

            application
                .RegisterUserNotificationSettings(UIUserNotificationSettings.GetSettingsForTypes(UIUserNotificationType.Alert, null));

            return true;
        }

        // UISceneSession Lifecycle

        [Export("application:configurationForConnectingSceneSession:options:")]
        public UISceneConfiguration GetConfiguration(UIApplication application, UISceneSession connectingSceneSession, UISceneConnectionOptions options)
        {
            // Called when a new scene session is being created.
            // Use this method to select a configuration to create the new scene with.
            return UISceneConfiguration.Create("Default Configuration", connectingSceneSession.Role);
        }

        [Export("application:didDiscardSceneSessions:")]
        public void DidDiscardSceneSessions(UIApplication application, NSSet<UISceneSession> sceneSessions)
        {
            // Called when the user discards a scene session.
            // If any sessions were discarded while the application was not running, this will be called shortly after `FinishedLaunching`.
            // Use this method to release any resources that were specific to the discarded scenes, as they will not return.
        }

        [Export("application:performFetchWithCompletionHandler:")]
        public void PerformFetch(UIApplication application, System.Action<UIBackgroundFetchResult> completionHandler)
        {
            var notification = new UILocalNotification();

            notification.FireDate = NSDate.FromTimeIntervalSinceNow(2);
            notification.AlertTitle = "Hello";
            notification.AlertBody = $"Notification depuis background fetch {DateTime.Now:dd/MM/yyyy}";

            UIApplication.SharedApplication.ScheduleLocalNotification(notification);

            completionHandler(UIBackgroundFetchResult.NewData);
        }
    }
}

