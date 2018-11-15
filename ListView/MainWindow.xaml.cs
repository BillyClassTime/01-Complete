using System.Collections.Generic;
using System.Windows;
namespace ListView
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            List<MyData> itemData = new List<MyData>();
            itemData.Add(new MyData() { ItemName = "01", Description="Primera descripción" });
            itemData.Add(new MyData() { ItemName = "02", Description = "Primera descripción" });
            itemData.Add(new MyData() { ItemName = "04", Description = "Primera descripción" });
            itemData.Add(new MyData() { ItemName = "05", Description = "Primera descripción" });
            itemData.Add(new MyData() { ItemName = "06", Description = "Primera descripción" });
            itemData.Add(new MyData() { ItemName = "07", Description = "Primera descripción" });
            this.LvListaData.ItemsSource = itemData;
        }
        private void Exit_ListView(object sender, RoutedEventArgs e)
        {
            int k = 1;
            k++;
        }
    }
}
