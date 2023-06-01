using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using CsvHelper;

namespace Prog_124_S23_L14_CSVReadWrite.CSVExample
{
    /// <summary>
    /// Interaction logic for Demonstration_Code.xaml
    /// </summary>
    public partial class Demonstration_Code : Window
    {
        public Demonstration_Code()
        {
            InitializeComponent();
            Preload();

        } // Demonstration_Code


        public void Preload()
        {

            List<Player> players = new List<Player>
            {
                new Player("Will", "Professor", 20, 56),
                new Player("Josh", "Professor", 30, 35)
            };

            SaveCSV("players.csv", players);

        }

        public void SaveCSV<T>(string filePath, List<T> list)
        {


            CultureInfo ci = CultureInfo.InvariantCulture;

            using (var stream = File.Open(filePath, FileMode.OpenOrCreate))
            using (var writer = new StreamWriter(stream))
            using (var csvWriter = new CsvWriter(writer, ci))
            {
                // .WriteRecords(list);
                csvWriter.WriteRecords(list);
                writer.Flush();
            }
        } // LoadCSV

        public void LoadCsv<T>(string filePath, List<T> list)
        {

            using (StreamReader sr = new StreamReader(filePath))
            using (CsvReader csv = new CsvReader(sr, CultureInfo.InvariantCulture))
            {

                players = csv.GetRecords<T>().ToList();
            }
        }




        class Player
        {
            string _firstName;
            string _class;
            int _currentHp;
            int _maxHp;

            public Player(string firstName, string @class, int currentHp, int maxHp)
            {
                _firstName = firstName;
                _class = @class;
                _currentHp = currentHp;
                _maxHp = maxHp;
            }

            public string FirstName { get => _firstName; set => _firstName = value; }
            public string Class { get => _class; set => _class = value; }
            public int CurrentHp { get => _currentHp; set => _currentHp = value; }
            public int MaxHp { get => _maxHp; set => _maxHp = value; }
        }



         

         
    } // class

} // namespace
