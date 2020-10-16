using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Support.V4.Widget;
using Android.Support.V7.App;
using Android.Support.V7.Widget;
using Android.Views;
using Android.Widget;
using RssReader.Common.Api;
using RssReader.Common.Entities;
using RssReader.Common.Services;
using RssReader.Droid.Adapters;
using System.Runtime.InteropServices;
using System.Threading.Tasks;
using Xamarin.Essentials;

namespace RssReader.Droid
{
    [Activity(Label = "@string/app_name", Theme = "@style/AppTheme")]
    public class RssItemsActivity : AppCompatActivity
    {
        private RssReaderService rssReaderService;

        private SwipeRefreshLayout itemsSwipeRefreshLayout;
        private RecyclerView itemsRecyclerview;
        private RssSource item;

        protected override async void OnCreate(Bundle savedInstanceState)
        {
            rssReaderService = new RssReaderService(Constants.ConnectionString);

            base.OnCreate(savedInstanceState);

            SetContentView(Resource.Layout.activity_rssitems);

            var toolbar = FindViewById<Android.Support.V7.Widget.Toolbar>(Resource.Id.toolbar);

            SetSupportActionBar(toolbar);

            SupportActionBar.SetHomeButtonEnabled(true);
            SupportActionBar.SetDisplayHomeAsUpEnabled(true);

            itemsSwipeRefreshLayout = FindViewById<SwipeRefreshLayout>(Resource.Id.rssitems_swiperefreshlayout);
            itemsRecyclerview = FindViewById<RecyclerView>(Resource.Id.rssitems_itemsRecyclerview);


            itemsRecyclerview.SetLayoutManager(new LinearLayoutManager(this));
            //itemsRecyclerview.SetLayoutManager(new GridLayoutManager(this, 2));

            // https://www.lemonde.fr/rss/une.xml

            // Recuperer l'element depuis l'id
            var id = Intent.GetIntExtra("ID", -1);

            if (id != -1)
            {
                item = rssReaderService.GetRssSourceById(id);

                SupportActionBar.Title = item.Title;

                itemsSwipeRefreshLayout.Refresh += ItemsSwipeRefreshLayout_Refresh;

                var _ = Load();
            }
        }

        private async void ItemsSwipeRefreshLayout_Refresh(object sender, System.EventArgs e)
        {
            await Load();
        }

        private async Task Load()
        {
            itemsSwipeRefreshLayout.Refreshing = true;

            var items = await rssReaderService.GetAllRssItems(item.Url);

            var rssItemAdapter = new RssItemAdapter(this, items);

            itemsRecyclerview.SetAdapter(rssItemAdapter);

            itemsSwipeRefreshLayout.Refreshing = false;
        }

        public override bool OnOptionsItemSelected(IMenuItem item)
        {
            if (item.ItemId == Android.Resource.Id.Home)
            {
                Finish();
                return true;
            }

            return base.OnOptionsItemSelected(item);
        }

        public override void OnRequestPermissionsResult(int requestCode, string[] permissions, [GeneratedEnum] Android.Content.PM.Permission[] grantResults)
        {
            Xamarin.Essentials.Platform.OnRequestPermissionsResult(requestCode, permissions, grantResults);

            base.OnRequestPermissionsResult(requestCode, permissions, grantResults);
        }
    }
}