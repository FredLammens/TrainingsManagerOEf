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
        private TrainingManager m;
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
            bool yearW = int.TryParse(yearTextBox.Text, out year);
            bool monthW = int.TryParse(monthTextBox.Text, out month);
            Report rapport;
            if (yearW || monthW)
            {
                if (cycling == true && running == true) //needs to be fixed
                {
                    rapport = m.GenerateMonthlyTrainingsReport(year, month);
                    trainingPerMonthDataGrid.ItemsSource = rapport.TimeLine;
                    trainingPerMonthDataGrid.Items.Refresh();
                }
                else if (cycling == true)
                {
                    rapport = m.GenerateMonthlyCyclingReport(year, month);
                    trainingPerMonthDataGrid.ItemsSource = rapport.Rides;
                    trainingPerMonthDataGrid.Items.Refresh();
                }
                else if(running == true)
                {
                    rapport = m.GenerateMonthlyRunningReport(year, month);
                    trainingPerMonthDataGrid.ItemsSource = rapport.Runs;
                    trainingPerMonthDataGrid.Items.Refresh();
                }
            }
            else if (!yearW)
            {
                MessageBox.Show("year is not correct or not inserted", "Trainingmanager", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            else if (!monthW) 
            {
                MessageBox.Show("Month is not correct or not inserted", "Trainingmanager", MessageBoxButton.OK, MessageBoxImage.Error);
            }

        }
        #region Menu

        private void MenuItemRunning_Click(object sender, RoutedEventArgs e)
        {
            RunningSessionWindow rsw = new RunningSessionWindow(m);
            rsw.Show();
            Close();
        }

        private void MenuItemCycling_Click(object sender, RoutedEventArgs e)
        {
            CyclingSessionWindow csw = new CyclingSessionWindow(m);
            csw.Show();
            Close();
        }

        private void MenuItemLatest_Click(object sender, RoutedEventArgs e)
        {
            LatestSessionWindow lsw = new LatestSessionWindow(m);
            lsw.Show();
            Close();
        }
        #endregion
    }
}
