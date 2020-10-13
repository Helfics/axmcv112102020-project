using Android.App;
using Android.Views;
using Android.Widget;
using RssReader.Common.Entities;
using System.Collections.Generic;

namespace RssReader.Droid.Adapters
{
    public class RssSourceAdapter : BaseAdapter<RssSource>
    {
        private readonly Activity context;
        private readonly List<RssSource> data;

        public RssSourceAdapter(Activity context, List<RssSource> data)
        {
            this.context = context;
            this.data = data;
        }

        public override RssSource this[int position] => data[position];

        public override int Count => data.Count;

        public override long GetItemId(int position)
        {
            return data[position].Id;
        }

        public override View GetView(int position, View convertView, ViewGroup parent)
        {
            var view = convertView ?? context.LayoutInflater.Inflate(Android.Resource.Layout.SimpleListItem2, parent, false);

            var titleTextview = view.FindViewById<TextView>(Android.Resource.Id.Text1);
            var subTitleTextview = view.FindViewById<TextView>(Android.Resource.Id.Text2);

            titleTextview.Text = data[position].Title;
            subTitleTextview.Text = $"Created at {data[position].CreatedAt:dd/MM/yyyy}";

            return view;
        }

        public void AddAndRefresh(RssSource item)
        {
            data.Insert(0, item);
            
            NotifyDataSetChanged();
        }
    }
}