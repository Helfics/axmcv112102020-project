using System;
using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Support.Design.Widget;
using Android.Support.V7.App;
using Android.Views;
using Android.Widget;
using RssReader.Common.Services;
using RssReader.Common.Services.Exceptions;
using Xamarin.Essentials;

namespace RssReader.Droid
{
    [Activity(Label = "@string/app_name", Theme = "@style/AppTheme")]
    public class AddRssSourceActivity : AppCompatActivity
    {
        private RssReaderService rssReaderService;

        private TextInputLayout titleTextInputLayout;
        private TextInputLayout urlTextInputLayout;

        private EditText titleEdittext;
        private EditText urlEditText;
        private Button saveBtn;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            rssReaderService = new RssReaderService(Constants.ConnectionString);

            base.OnCreate(savedInstanceState);

            SetContentView(Resource.Layout.activity_addrsssource);

            var toolbar = FindViewById<Android.Support.V7.Widget.Toolbar>(Resource.Id.toolbar);

            SetSupportActionBar(toolbar);

            SupportActionBar.Title = "Add RSS Item";

            SupportActionBar.SetHomeButtonEnabled(true);
            SupportActionBar.SetDisplayHomeAsUpEnabled(true);

            titleTextInputLayout = FindViewById<TextInputLayout>(Resource.Id.addrsssource_titleEdittextInputLayout);
            urlTextInputLayout = FindViewById<TextInputLayout>(Resource.Id.addrsssource_urlEdittextInputLayout);

            titleEdittext = FindViewById<EditText>(Resource.Id.addrsssource_titleEdittext);
            urlEditText = FindViewById<EditText>(Resource.Id.addrsssource_urlEdittext);
            saveBtn = FindViewById<Button>(Resource.Id.addrsssource_saveBtn);

            saveBtn.Click += SaveBtn_Click;
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

        private void SaveBtn_Click(object sender, System.EventArgs e)
        {
            try
            {
                var id = rssReaderService.AddRssSource(titleEdittext.Text, urlEditText.Text);

                var intent = new Intent();

                intent.PutExtra("ID", id);

                SetResult(Result.Ok, intent);

                Finish();
            }
            catch (AddRssSourceTitleRequiredException)
            {
                titleTextInputLayout.Error = "Le champs est requis";
            }
            catch (AddRssSourceUrlRequiredException)
            {
                urlTextInputLayout.Error = "Le champs est requis ou invalide";
            }
            catch (Exception)
            {
                var alert = new Android.Support.V7.App.AlertDialog.Builder(this);

                alert
                    .SetMessage("Something wrong has happened")
                    .SetPositiveButton("Ok", handler: (s, _) => { })
                    .Show();
            }
        }

        public override void OnRequestPermissionsResult(int requestCode, string[] permissions, [GeneratedEnum] Android.Content.PM.Permission[] grantResults)
        {
            Xamarin.Essentials.Platform.OnRequestPermissionsResult(requestCode, permissions, grantResults);

            base.OnRequestPermissionsResult(requestCode, permissions, grantResults);
        }
    }
}