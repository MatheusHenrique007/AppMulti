using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using AppMulti.Controller;
using AppMulti.Models;

namespace AppMulti
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class PageListar : ContentPage
    {
        public PageListar()
        {
            InitializeComponent();
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            lsvClientes.ItemsSource = MySQLCon.listacliente();

        }

        private void lsvClientes_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            if (e.SelectedItem != null)
            {
                NavegarCliente(e.SelectedItem as Cliente);
            }
        }

        private void btnNovo_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new MainPage());
        }

        void NavegarCliente(Cliente cliente)
        {
            PageUpDel updel = new PageUpDel();
            updel.cliente = cliente;
            Navigation.PushAsync(updel);
        }
    }
}