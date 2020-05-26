using DataLayer;
using DomainLibrary.Domain;
using System;
using System.Collections.Generic;
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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace TrainingManagerUI
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        TrainingManager m;
        public MainWindow()
        {
            InitializeComponent();
            m = new TrainingManager(new UnitOfWork(new TrainingContext("Production")));
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            bool? cycling = cyclingCheckBox.IsChecked;
            bool? running = runningCheckBox.IsChecked;
            int year;
            int month;
            int.TryParse(yearTextBox.Text, out year);
            int.TryParse(monthTextBox.Text, out month);
            Report rapport;
            //nbakijken + beste toevoegen aan overzicht 
            if (cycling.HasValue || running.HasValue)
            {
                if (cycling == true && running == true)
                {
                    rapport = m.GenerateMonthlyTrainingsReport(year, month);
                    trainingPerMonthDataGrid.ItemsSource = rapport.TimeLine;
                }
                else if (cycling == true)
                {
                    rapport = m.GenerateMonthlyCyclingReport(year, month);
                    trainingPerMonthDataGrid.ItemsSource = rapport.Rides;
                }
                else
                {
                    rapport = m.GenerateMonthlyRunningReport(year, month);
                    trainingPerMonthDataGrid.ItemsSource = rapport.Runs;
                }
            }

        }
    }
}
