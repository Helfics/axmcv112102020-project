using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Support.V7.App;
using Android.Widget;
using RssReader.Common.Services;
using Xamarin.Essentials;

namespace RssReader.Droid
{
    [Activity(Label = "@string/app_name", Theme = "@style/AppTheme")]
    public class AddRssSourceActivity : AppCompatActivity
    {
        private RssReaderService rssReaderService;

        private EditText titleEdittext;
        private EditText urlEditText;
        private Button saveBtn;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            rssReaderService = new RssReaderService(Constants.ConnectionString);

            base.OnCreate(savedInstanceState);

            SetContentView(Resource.Layout.activity_addrsssource);

            titleEdittext = FindViewById<EditText>(Resource.Id.addrsssource_titleEdittext);
            urlEditText = FindViewById<EditText>(Resource.Id.addrsssource_urlEdittext);
            saveBtn = FindViewById<Button>(Resource.Id.addrsssource_saveBtn);

            saveBtn.Click += SaveBtn_Click;
        }

        private void SaveBtn_Click(object sender, System.EventArgs e)
        {
            var id = rssReaderService.AddRssSource(titleEdittext.Text, urlEditText.Text);

            var intent = new Intent();
            
            intent.PutExtra("ID", id);

            SetResult(Result.Ok, intent);

            Finish();
        }

        public override void OnRequestPermissionsResult(int requestCode, string[] permissions, [GeneratedEnum] Android.Content.PM.Permission[] grantResults)
        {
            Xamarin.Essentials.Platform.OnRequestPermissionsResult(requestCode, permissions, grantResults);

            base.OnRequestPermissionsResult(requestCode, permissions, grantResults);
        }
    }
}