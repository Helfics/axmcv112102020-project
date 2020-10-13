using Android.App;
using Android.Support.V7.Widget;
using Android.Views;
using Android.Widget;
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
        }
    }
}