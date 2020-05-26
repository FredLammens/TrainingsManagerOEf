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
            try
            {
                if (!yearW)
                    throw new ArgumentException("year is not correct or not inserted");
                else if (!monthW)
                    throw new ArgumentException("Month is not correct or not inserted");
                if (cycling == true && running == true)
                {
                    rapport = m.GenerateMonthlyTrainingsReport(year, month);
                    trainingPerMonthDataGrid.ItemsSource = rapport.TimeLine;
                    trainingPerMonthDataGrid.Items.Refresh();
                    //beste toevoegen
                    besteTrainingen.Text = "CyclingSSession \n" +
                                           "----------------\n" +
                                           $"MaxDistance: {rapport.MaxDistanceSessionCycling} \n" +
                                           $"MaxSpeed: {rapport.MaxSpeedSessionCycling}\n" +
                                           $"MaxWatt: {rapport.MaxWattSessionCycling}\n\n" +
                                           "RunningSession \n" +
                                            "----------------\n" +
                                           $"MaxDistance: {rapport.MaxDistanceSessionRunning}\n" +
                                           $"MaxSpeed: {rapport.MaxSpeedSessionRunning}\n";
                }
                else if (cycling == true)
                {
                    rapport = m.GenerateMonthlyCyclingReport(year, month);
                    trainingPerMonthDataGrid.ItemsSource = rapport.Rides;
                    trainingPerMonthDataGrid.Items.Refresh();
                    //beste toevoegen 
                    besteTrainingen.Text = "CyclingSSession \n" +
                                           "----------------\n" +
                                           $"MaxDistance: {rapport.MaxDistanceSessionCycling}\n" +
                                           $"MaxSpeed: {rapport.MaxSpeedSessionCycling}\n" +
                                           $"MaxWatt: {rapport.MaxWattSessionCycling} \n";
                }
                else if (running == true)
                {
                    rapport = m.GenerateMonthlyRunningReport(year, month);
                    trainingPerMonthDataGrid.ItemsSource = rapport.Runs;
                    trainingPerMonthDataGrid.Items.Refresh();
                    //beste toevoegen
                    besteTrainingen.Text = "RunningSession \n" +
                                           "----------------\n" +
                                           $"MaxDistance: {rapport.MaxDistanceSessionRunning} m \n" +
                                           $"MaxSpeed: {rapport.MaxSpeedSessionRunning} m/s \n";

                }
                else
                    throw new ArgumentException("Please check at least one checkbox");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Home", MessageBoxButton.OK, MessageBoxImage.Error);
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
