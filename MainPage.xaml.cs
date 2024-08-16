using System;

namespace Numero3716370
{
    public partial class MainPage : ContentPage
    {
        private readonly LocalDbService _dbService;
        private int _editRegistroId;


        public MainPage(LocalDbService dbService)
        {
            InitializeComponent();
            _dbService = dbService;
            Task.Run(async () => listview.ItemsSource = await _dbService.GetSigno());
        }

        private async void saveButton_Clicked(object sender, EventArgs e)
        {
     

            
            if (double.TryParse(numeroEntryField.Text, out double numero1))
            {
                if (numero1 > 0)
                {
                    determinadoEntryField.Text = "El numeros es positivo";
                }
                else if (numero1 <0)
                {
                    determinadoEntryField.Text = "El numero es negativo";
                }
                else
                {
                    determinadoEntryField.Text = "el numero es nulo";
                }
               
                if (_editRegistroId == 0)
                {
                    await _dbService.Create(new Signo
                    {
                        Numero = numeroEntryField.Text,
                        Determinado = determinadoEntryField.Text,

                    });

                }
                else
                {
                    
                    await _dbService.Update(new Signo
                    {
                        id = _editRegistroId,
                        Numero = numeroEntryField.Text,
                        Determinado = determinadoEntryField.Text,
                    });
                    _editRegistroId = 0;
                }
                numeroEntryField.Text = string.Empty;
                determinadoEntryField.Text = string.Empty;

                listview.ItemsSource = await _dbService.GetSigno();
            }
            else
            {
                
                await DisplayAlert("Error", "Debe ingresar un numero.", "OK");
            }

        }

        private async void listview_ItemTapped(object sender, ItemTappedEventArgs e)
        {
            var clientes = (Signo)e.Item;
            var action = await DisplayActionSheet("Action", "Cancel", null, "Edit", "Delete");

            switch (action)
            {
                case "Edit":
                    _editRegistroId = clientes.id;
                    numeroEntryField.Text = clientes.Numero;
                    determinadoEntryField.Text = clientes.Determinado;
                    break;

                case "Delete":
                    await _dbService.Delete(clientes);
                    listview.ItemsSource = await _dbService.GetSigno();
                    break;

            }
        }
    }

}
