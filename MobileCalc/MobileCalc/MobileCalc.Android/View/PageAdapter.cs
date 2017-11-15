using System.Collections.Generic;
using Android.Support.V7.Widget;
using Android.Views;
using Android.Widget;

namespace MobileCalc.Droid.View
{
    public class PageAdapter : RecyclerView.Adapter
    {
        private readonly List<string> _pages;
        private readonly IOnItemClickListener _listener;
        //Associated Objects
        public interface IOnItemClickListener
        {
            void OnClick(Android.Views.View view, int position);
        }

        private class ViewHolder : RecyclerView.ViewHolder
        {
            public readonly TextView TextView;
            public ViewHolder(TextView textView) : base(textView)
            {
                TextView = textView;
            }
        }

        public PageAdapter(List<string> pages, IOnItemClickListener listener)
        {
            _pages = pages;
            _listener = listener;
        }

        public override RecyclerView.ViewHolder OnCreateViewHolder(ViewGroup parent, int viewType)
        {
            var vi = LayoutInflater.From(parent.Context);
            var v = vi.Inflate(Resource.Layout.drawer_list_item, parent, false);
            var tv = v.FindViewById<TextView>(Android.Resource.Id.Text1);
            return new ViewHolder(tv);
        }

        public override void OnBindViewHolder(RecyclerView.ViewHolder holderRaw, int position)
        {
            var holder = (ViewHolder)holderRaw;
            holder.TextView.Text = _pages[position];
            // todo: remove Xamarin's crappy memory leak right here!!!
            holder.TextView.Click += (sender, args) => {
                _listener.OnClick((Android.Views.View)sender, position);
            };

            //			holder.textView.SetOnClickListener ((View v) => {
            //				mListener.OnClick (View, position);
            //			});
        }

        public override int ItemCount
        {
            get
            {
                return _pages.Count;
            }
        }
    }

}
