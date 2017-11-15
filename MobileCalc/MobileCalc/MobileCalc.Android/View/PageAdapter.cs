using System;
using Android.Support.V7.Widget;
using Android.Views;
using Android.Widget;

namespace MobileCalc.Droid.View
{
    public class PageAdapter : RecyclerView.Adapter
    {
        private readonly String[] _dataset;
        private readonly IOnItemClickListener _listener;
        //Associated Objects
        public interface IOnItemClickListener
        {
            void OnClick(Android.Views.View view, int position);
        }

        public class ViewHolder : RecyclerView.ViewHolder
        {
            public readonly TextView textView;
            public ViewHolder(TextView v) : base(v)
            {
                textView = v;
            }
        }

        public PageAdapter(string[] myDataSet, IOnItemClickListener listener)
        {
            _dataset = myDataSet;
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
            holder.textView.Text = _dataset[position];
            // todo: remove Xamarin's crappy memory leak right here!!!
            holder.textView.Click += (object sender, EventArgs args) => {
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
                return _dataset.Length;
            }
        }
    }

}
