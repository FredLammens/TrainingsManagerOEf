using DomainLibrary.Domain;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace TrainingManagerUI
{
    /// <summary>
    /// Interaction logic for LatestSessionWindow.xaml
    /// </summary>
    public partial class LatestSessionWindow : Window
    {
        private TrainingManager m;
        public LatestSessionWindow(TrainingManager trainingmg)
        {
            InitializeComponent();
            m = trainingmg;
        }
        #region menu
        private void Home_Click(object sender, RoutedEventArgs e)
        {
                MainWindow w = new MainWindow();
                w.Show();
            Close();
        }

        private void MenuItemCycling_Click(object sender, RoutedEventArgs e)
        {
                CyclingSessionWindow rw = new CyclingSessionWindow(m);
                rw.Show();
            Close();
        }

        private void MenuItemRunning_Click(object sender, RoutedEventArgs e)
        {
                RunningSessionWindow rw = new RunningSessionWindow(m);
                rw.Show();
            Close();
        }
        #endregion
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            bool? cycling = cyclingCheckBox.IsChecked;
            bool? running = runningCheckBox.IsChecked;
            int amount;
            bool amountW = int.TryParse(amountSession.Text, out amount);
            try
            {
                if (!amountW)
                    throw new ArgumentException("amount is not entered");
                if (cycling == true && running == true)
                    throw new ArgumentException("pls select only one checkbox");
                if (cycling == true)
                {
                    LatestSessionPerMonthDataGrid.ItemsSource = m.GetPreviousCyclingSessions(amount);
                    LatestSessionPerMonthDataGrid.Items.Refresh();
                }
                else if (running == true)
                {
                    LatestSessionPerMonthDataGrid.ItemsSource = m.GetPreviousRunningSessions(amount);
                    LatestSessionPerMonthDataGrid.Items.Refresh();
                }
                else 
                {
                    throw new ArgumentException("pls select at least one checkbox");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Latest Session", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
    }
}
