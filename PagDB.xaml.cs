namespace ProyectoSQLite
{
    public partial class PagDB : ContentPage
    {
        private readonly BaseDeDatos _dbService;
        private int _editCustomerId;

        public PagDB(BaseDeDatos dbService)
        {
            InitializeComponent();
            _dbService = dbService;
            Task.Run(async () => listView.ItemsSource = await _dbService.GetCustomers());
        }

        private async void listView_ItemTapped(object sender, ItemTappedEventArgs e)
        {
            var customer = (Customer)e.Item;
            var action = await DisplayActionSheet("Menu", "Cancelar", null, "Editar", "Borrar");

            switch(action)
            {
                case "Editar":

                    _editCustomerId = customer.Id;
                    ProductoEntry.Text = customer.Producto;
                    StockEntry.Text = customer.Stock;
                    MarcaEntry.Text = customer.Marca;
                    VentasEntry.Text = customer.Ventas;
                    PrecioEntry.Text = customer.Precio;
                    EstadoEntry.Text = customer.Estado;

                    break;
                case "Borrar":

                    await _dbService.Delete(customer);
                    listView.ItemsSource = await _dbService.GetCustomers();
                    ProductoEntry.Text = string.Empty;
                    StockEntry.Text = string.Empty;
                    PrecioEntry.Text = string.Empty;
                    EstadoEntry.Text = string.Empty;
                    MarcaEntry.Text = string.Empty;
                    VentasEntry.Text = string.Empty;

                    break;
            }
        }

        private async void guardarB_Clicked(object sender, EventArgs e)
        {
            if(_editCustomerId == 0)
            {
                if(ProductoEntry.Text == string.Empty || StockEntry.Text == string.Empty || PrecioEntry.Text == string.Empty
                    || EstadoEntry.Text == string.Empty || MarcaEntry.Text == string.Empty || VentasEntry.Text == string.Empty) 
                {
                    await DisplayAlert("Error", "No se han introducido todos los datos. Rellena todas las casillas con los datos solicitados", "Aceptar");
                }
                else
                {
                    await _dbService.Create(new Customer
                    {
                        Producto = ProductoEntry.Text,
                        Stock = StockEntry.Text,
                        Precio = PrecioEntry.Text,
                        Estado = EstadoEntry.Text,
                        Marca = MarcaEntry.Text,
                        Ventas = VentasEntry.Text,
                    });
                    ProductoEntry.Text = string.Empty;
                    StockEntry.Text = string.Empty;
                    PrecioEntry.Text = string.Empty;
                    EstadoEntry.Text = string.Empty;
                    MarcaEntry.Text = string.Empty;
                    VentasEntry.Text = string.Empty;
                }
            }
            else
            {
                if (ProductoEntry.Text == string.Empty || StockEntry.Text == string.Empty || PrecioEntry.Text == string.Empty
                    || EstadoEntry.Text == string.Empty || MarcaEntry.Text == string.Empty || VentasEntry.Text == string.Empty)
                {
                    await DisplayAlert("Error", "No se han introducido todos los datos. Rellena todas las casillas con los datos solicitados", "Aceptar");
                }
                else
                {
                    await _dbService.Uptade(new Customer
                    {
                        Id = _editCustomerId,
                        Producto = ProductoEntry.Text,
                        Stock = StockEntry.Text,
                        Precio = PrecioEntry.Text,
                        Estado = EstadoEntry.Text,
                        Marca = MarcaEntry.Text,
                        Ventas = VentasEntry.Text,
                    });
                    _editCustomerId = 0;
                    ProductoEntry.Text = string.Empty;
                    StockEntry.Text = string.Empty;
                    PrecioEntry.Text = string.Empty;
                    EstadoEntry.Text = string.Empty;
                    MarcaEntry.Text = string.Empty;
                    VentasEntry.Text = string.Empty;
                }
                
            }
            listView.ItemsSource = await _dbService.GetCustomers();
            
        }
    }

}
