using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using MySqlConnector;

namespace Foglalasok
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        private readonly string connectionString = "datasource=127.0.0.1; port=3306; username=root; password=; database=foglalas";
        private MySqlConnection connection;
        private List<Foglalas> foglalasok;
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Betoltes()
        {
            try
            {
                foglalasok = new List<Foglalas>();
                connection = new MySqlConnection(connectionString);
                connection.Open();

                string connectionQuery = "SELECT fsorsz AS Sorszám," +
                    "vnev AS Vendég_neve, " +
                    "sznev AS Szoba_neve, " +
                    "erk AS Érekezés_dátuma, " +
                    "tav AS Távozás_dátuma, " +
                    "fo AS Létszám" +
                    "FROM foglalasok " +
                    " INNER JOIN vendegek ON foglalasok.fsorsz = vendegek.vsorsz " +
                    " INNER JOIN szobak ON foglalasok.fsorsz = szobak.szazon ";

                MySqlCommand query = new MySqlCommand(connectionQuery, connection);
                MySqlDataReader reader = query.ExecuteReader();

                while (reader.Read())
                {
                    int sorszam = Convert.ToInt32(reader[0]);
                    string vendegnev = reader.GetString(1);
                    string szobanev = reader.GetString(2);
                    DateTime erkezes = Convert.ToDateTime(reader[3]);
                    DateTime tavozas = Convert.ToDateTime(reader[4]);
                    int letszam = Convert.ToInt32(reader[5]);

                    foglalasok.Add(new Foglalas(sorszam, vendegnev, szobanev, erkezes, tavozas, letszam));
                }
                reader.Close();
                connection.Close();
                dgAdatok.ItemsSource = foglalasok;
            }
            catch (Exception hiba)
            {
                MessageBox.Show(hiba.Message);
            }
        }

        private void dgAdatok_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            
        }

        private void dgAdatok_Loaded(object sender, RoutedEventArgs e)
        {
          Betoltes();
        }
    }
}