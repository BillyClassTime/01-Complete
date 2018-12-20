namespace _02_Complete
{
    public interface IBeberage
    {
        string Nombre { get; set; }
        string Clase { get; }
        int TemperaturaServida { get; set; }
    }
    public struct Menu
    {
        public string[] beverages;
        //Define el indexer, puede poner indexer y tab tab y aparece la definicion
        public string this[int index]
        {
            get { return this.beverages[index]; }
            set { this.beverages[index]=value; }
        }
        public Menu(string bev1, string bev2)
        {
            beverages = new string[] { "Americano", "Café au Lait", "Cafè Macchiato" };
        }
        public int Length
        {
            get { return beverages.Length; }
        }
    }
    public partial class Coffee // esto era antes una public partial struct Coffee
                                // completada su definicion en 19A_RaisingAnEvent
                                // se cambio porque la struct no permite campos con definición
    {
        private int strength;
        public int Strength
        {
            get { return strength; }
            set { strength = value; }
        }
        public string CountryOfOrigin { get; set; }
        public string Bean{get; set;}

    }
    public struct StructsEx 
    {
        public int Strength;
        public string Bean;
        public string CountryOfOrigin;
    }
    public class Principal_01
    {
        public static void Main()
        {
            Coffee coffee = new Coffee();
            coffee.Bean = "Strong";
            coffee.CountryOfOrigin = "Colombia";
            coffee.Strength = 5;
            Coffee coffee2 = new Coffee
            {
                Bean = "Soft",CountryOfOrigin = "Ethiophya",Strength = 3
            };

            //Accediendo a la struct Menu
            Menu menu = new Menu("bev1","bev2");
            string firstDrink = menu.beverages[0];
            var SecondDrink = menu[1];
            //Accediento al array usando el indexer
            firstDrink = menu[0];
            string secondDrink = menu[1];
            int numberOfChoices = menu.Length;
        }
    }
}
