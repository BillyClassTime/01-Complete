using System.Collections.Generic;
using System.Windows;
namespace ListView
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            var itemData = new List<MyData>();
            itemData.Add(new MyData() { ItemName = "01", Description="Primera descripción" });
            itemData.Add(new MyData() { ItemName = "02", Description = "Segunda descripción" });
            itemData.Add(new MyData() { ItemName = "04", Description = "Cuarta descripción" });
            itemData.Add(new MyData() { ItemName = "05", Description = "Quinta descripción" });
            itemData.Add(new MyData() { ItemName = "06", Description = "Sexta descripción" });
            itemData.Add(new MyData() { ItemName = "07", Description = "Septima descripción" });
            this.LvListaData.ItemsSource = itemData;
        }
        private void Exit_ListView(object sender, RoutedEventArgs e)
        {
            var k = 1;
            k++;
        }
    }
}
