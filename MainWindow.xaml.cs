using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Windows;
using System.Windows.Documents;
using CsvHelper;



namespace Prog_124_S23_L14_CSVReadWrite
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        const string filePath = "students.csv";
        public List<Student> loadedStudents = new List<Student>();

        public MainWindow()
        {
            InitializeComponent();
            Preload(); // COMMENT THIS OUT TO TEST YOUR OWN SAVE 

            //LoadCSV(filePath, loadedStudents); // Old LoadCSV Call

            loadedStudents = LoadCSV<Student>(filePath);

            lvStudents.ItemsSource = loadedStudents;
        }

        public List<T> LoadCSV<T>(string filePath)
        {
            // Loading a csv file to a list of type that we can work with
            List<T> tempList = new List<T>();
            using (StreamReader sr = new StreamReader(filePath))
            using (CsvReader csv = new CsvReader(sr, CultureInfo.InvariantCulture))
            {
                // We are saving a list of an object to work with in our program
                tempList = csv.GetRecords<T>().ToList();
            }

            return tempList;
        }

        public void LoadCSV(string filePath, List<Student> list)
        {
            // Loading a csv file to a list of type that we can work with
            using (StreamReader sr = new StreamReader(filePath))
            using (CsvReader csv = new CsvReader(sr, CultureInfo.InvariantCulture))
            {
                // We are saving a list of an object to work with in our program
                list = csv.GetRecords<Student>().ToList();
            }
        }



        // How to make a preload method to help generate a csv file to work with
        public void Preload()
        {
            List<Student> students = new List<Student>
            {
                new Student("Will", "Cram", 57, 93),
                new Student("Josh", "Emery", 101, 105)
            };

            SaveCSVFile(filePath, students);
        }

        // Two fields that will ever change
        // the file path 
        // the list
        public void SaveCSVFile<T>(string filePath, List<T> list)
        {

            CultureInfo ci = CultureInfo.InvariantCulture;

            // Make sure to include the extension
            //string csvExtension = ".csv";
            //string txtExtension = ".txt";
            //string fullPath = filePath + csvExtension;

            //// usings
            ///
            // First using is opening the connection to our file
            using (var stream = File.Open(filePath, FileMode.OpenOrCreate))
            {
                using (var writer = new StreamWriter(stream))
                {
                    using (var csvWriter = new CsvWriter(writer, ci))
                    {
                        // .WriteRecords(list);
                        // WriteRecords(list)
                        // Your class needs to have public properties in order to be properly written
                        csvWriter.WriteRecords(list);
                        // writer.Flush()
                        writer.Flush();
                    }
                }

            }

        } // SaveCSVFile

        // Reading CSV Data

        private void btnDemo_Click(object sender, RoutedEventArgs e)
        {
            new CSVExample.Demonstration_Code().Show();
        }

        private void btnSaveToList_Click(object sender, RoutedEventArgs e)
        {
            string firstName = txtFirst.Text;
            string lastName = txtLast.Text;
            int csi = int.Parse(txtCSI.Text);
            int genEd = int.Parse(txtGenEd.Text);

            loadedStudents.Add(new Student(firstName, lastName, csi, genEd));

            lvStudents.Items.Refresh();

            SaveCSVFile(filePath, loadedStudents);
            MessageBox.Show("Students were saved to the csv");

        } // btnSaveToList_Click

        private void btnSaveToCSV_Click(object sender, RoutedEventArgs e)
        {
            SaveCSVFile(filePath, loadedStudents);
        }
    } // class

} // namespace
