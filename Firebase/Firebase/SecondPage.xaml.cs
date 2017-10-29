using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Firebase
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class SecondPage : ContentPage
	{
        private bool add;
		public SecondPage (bool add)
		{
            this.add = add;
			InitializeComponent ();
            if(add)
            {
                Title = "Nuevo elemento";
            }
            else
            {
                Title = "Edición";
            }
		}

        private void Save_Clicked(object sender, EventArgs e)
        {
            var item = (Contact)BindingContext;
            if (add)
            {
            
            }else
            {

            }
        }
    }
}
