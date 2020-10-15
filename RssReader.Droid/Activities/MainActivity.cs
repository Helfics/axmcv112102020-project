using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Support.V7.App;
using Android.Widget;
using RssReader.Common.Services;
using RssReader.Droid.Adapters;

namespace RssReader.Droid
{
    [Activity(Label = "@string/app_name", Theme = "@style/AppTheme", MainLauncher = true)]
    public class MainActivity : AppCompatActivity
    {
        private const int ADD_RSS_SOURCE_REQUEST = 1;

        private RssReaderService rssReaderService;

        private Button addBtn;
        private ListView rssSourcesListView;
        private RssSourceAdapter rssSourceAdapter;

        protected override void OnActivityResult(int requestCode, [GeneratedEnum] Result resultCode, Intent data)
        {
            switch (requestCode)
            {
                case ADD_RSS_SOURCE_REQUEST when resultCode == Result.Ok:
                    var id = data.GetIntExtra("ID", -1);

                    if (id != -1)
                    {
                        var item = rssReaderService.GetRssSourceById(id);

                        rssSourceAdapter.AddAndRefresh(item);
                    }

                    break;
                default: break;
            }
        }

        protected override void OnCreate(Bundle savedInstanceState)
        {
            rssReaderService = new RssReaderService(Constants.ConnectionString);

            base.OnCreate(savedInstanceState);

            Xamarin.Essentials.Platform.Init(this, savedInstanceState);

            SetContentView(Resource.Layout.activity_main);

            addBtn = FindViewById<Button>(Resource.Id.main_addBtn);
            addBtn.Click += AddBtn_Click;

            rssSourcesListView = FindViewById<ListView>(Resource.Id.main_rsssourcesListview);
            rssSourceAdapter = new RssSourceAdapter(this, rssReaderService.GetAllRssSources());
            rssSourcesListView.Adapter = rssSourceAdapter;
            rssSourcesListView.ItemClick += RssSourcesListView_ItemClick;
        }

        private void RssSourcesListView_ItemClick(object sender, AdapterView.ItemClickEventArgs e)
        {
            var item = rssSourceAdapter[e.Position];

            var intent = new Intent(this, typeof(RssItemsActivity));

            intent.PutExtra("ID", item.Id);

            StartActivity(intent);
        }

        private void AddBtn_Click(object sender, System.EventArgs e)
        {
            var intent = new Intent(this, typeof(AddRssSourceActivity));

            StartActivityForResult(intent, ADD_RSS_SOURCE_REQUEST);
        }

        public override void OnRequestPermissionsResult(int requestCode, string[] permissions, [GeneratedEnum] Android.Content.PM.Permission[] grantResults)
        {
            Xamarin.Essentials.Platform.OnRequestPermissionsResult(requestCode, permissions, grantResults);

            base.OnRequestPermissionsResult(requestCode, permissions, grantResults);
        }
    }
}