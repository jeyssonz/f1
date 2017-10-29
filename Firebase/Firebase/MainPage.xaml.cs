using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.ObjectModel;
using Xamarin.Forms;
using Firebase.Xamarin.Database;
using Firebase.Xamarin.Database.Query;
using System.Diagnostics;

namespace Firebase
{
	public partial class MainPage : ContentPage
	{
        ObservableCollection<Contact> people = new ObservableCollection<Contact> ();
        FirebaseClient firebase;
		public MainPage()
		{
			InitializeComponent();

            firebase = new FirebaseClient("https://xamarinrubrica.firebaseio.com/");

            BindingContext = this;

            laLista.ItemsSource = people;

            getList();
		}

        public async void getList()
        {

            var list = (await firebase
                .Child("yourentiti") 
                .OnceAsync<Contact>());

            people.Clear();

            Debug.WriteLine("Lista con " + list.Count);

            foreach(var item in list)
            {
                Contact c = item.Object as Contact;
                c.Uid = item.Key;
                people.Add(c);
            }

           
        }

        void Handle_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {

        }

        async void OnDeleteItem(object sender, EventArgs e)
        {

        }

        public async void Handel_Toolbar_Add(object sender, EventArgs e)
        {
            Contact c = new Contact();
            var seconPage = new SecondPage(true);
            seconPage.BindingContext = c;
            await Navigation.PushAsync(seconPage);
        }
        public async void Handel_Toolbar_DeleteAll(object sender, EventArgs e)
        {

        }

        protected async override void OnAppearing()
        {
            base.OnAppearing();
            getList();
        }

       
    }
}
