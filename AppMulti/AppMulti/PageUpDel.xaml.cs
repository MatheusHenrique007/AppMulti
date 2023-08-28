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
    public partial class PageUpDel : ContentPage
    {
        public Cliente cliente;
        public PageUpDel()
        {
            InitializeComponent();
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            BindingContext = this.cliente;
        }

        private void btnAtualizar_Clicked(object sender, EventArgs e)
        {
            MySQLCon.Atualizar(cliente);
            Navigation.PopAsync();
        }

        private void btnApagar_Clicked(object sender, EventArgs e)
        {
            if (cliente.id != 0)
            {
                MySQLCon.Excluir(cliente);
                Navigation.PopAsync();
            }
        }
    }
}