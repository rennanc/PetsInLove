using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace PetsInLove.Controls
{
    public class CardView : Frame
    {
        public CardView()
        {
            if (Device.RuntimePlatform.Equals("iOS"))
            {
                HasShadow = false;
                BorderColor = Color.Transparent;
                BackgroundColor = Color.Transparent;
            }

            if (Device.RuntimePlatform.Equals("Android"))
            {
                HasShadow = true;
                BorderColor = Color.Transparent;
                BackgroundColor = Color.Transparent;
            }
        }
    }
}
