using Android.App;
using Android.Content;
using Android.Support.V7.Widget;
using Android.Views;
using Android.Widget;
using FFImageLoading;
using RssReader.Common.Entities;
using System.Collections.Generic;

namespace RssReader.Droid.Adapters
{
    public class RssItemAdapter : RecyclerView.Adapter
    {
        public class RssItemViewHolder : RecyclerView.ViewHolder
        {
            public RssItemViewHolder(View view) : base(view)
            {
            }
        }

        private readonly Activity context;
        private readonly List<RssItem> data;

        public RssItemAdapter(Activity context, List<RssItem> data)
        {
            this.context = context;
            this.data = data;
        }

        public override int ItemCount => data.Count;

        public override RecyclerView.ViewHolder OnCreateViewHolder(ViewGroup parent, int viewType)
        {
            var view = context.LayoutInflater.Inflate(Resource.Layout.viewholder_rssitem, parent, false);
            
            return new RssItemViewHolder(view);
        }

        public override void OnBindViewHolder(RecyclerView.ViewHolder holder, int position)
        {
            var rssItemViewHolder = holder as RssItemViewHolder;

            var titleTextview = rssItemViewHolder.ItemView.FindViewById<TextView>(Resource.Id.rssitem_title);

            titleTextview.Text = data[position].Title;

            var descriptionTextview = rssItemViewHolder.ItemView.FindViewById<TextView>(Resource.Id.rssitem_description);

            descriptionTextview.Text = data[position].Description;

            var imageView = rssItemViewHolder.ItemView.FindViewById<ImageView>(Resource.Id.rssitem_image);

            ImageService
                .Instance
                .LoadUrl(data[position].ImageUrl)
                .LoadingPlaceholder("loadingplaceholder",FFImageLoading.Work.ImageSource.CompiledResource)
                .ErrorPlaceholder("errorplaceholder", FFImageLoading.Work.ImageSource.CompiledResource)
                .Into(imageView);

            rssItemViewHolder.ItemView.Click += (s,e) =>
            {
                if (!string.IsNullOrEmpty(data[position].Url))
                {
                    var intent = new Intent(Intent.ActionView, Android.Net.Uri.Parse(data[position].Url));

                    context.StartActivity(intent);
                }
            };
        }
    }
}