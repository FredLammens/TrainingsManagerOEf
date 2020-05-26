using DomainLibrary.Domain;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
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
    /// Interaction logic for RunningSessionRemoveWindow.xaml
    /// </summary>
    public partial class RunningSessionWindow : Window
    {
        private TrainingManager m;
        public RunningSessionWindow(TrainingManager trainingmg)
        {
            InitializeComponent();
            m = trainingmg;
            runninsSessionBox.ItemsSource = m.GetAllRunningSessions();
        }

        private void btnAddRunningSession_Click(object sender, RoutedEventArgs e)
        {
            RunningSessionAddWindow rsa = new RunningSessionAddWindow(m, this);
            rsa.Show();
        }

        private void btnRemoveRunningSession_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                RunningSession toRemove = (RunningSession)runninsSessionBox.SelectedItem;
                List<int> toRemoveID = new List<int>() {toRemove.Id};
                List<int> CyclingSession = new List<int>();
                if (runninsSessionBox.SelectedItem != null)
                {
                    m.RemoveTrainings(CyclingSession, toRemoveID);
                    MessageBox.Show($"{toRemove} is removed!", "RunningSession", MessageBoxButton.OK, MessageBoxImage.Information);
                }
                else
                {
                    MessageBox.Show($"Nothing selected", "RunningSession", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message, "Running session", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
        #region menu
        private void MenuItemHome_Click(object sender, RoutedEventArgs e)
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

        private void MenuItemLatest_Click(object sender, RoutedEventArgs e)
        {
            LatestSessionWindow lw = new LatestSessionWindow(m);
            lw.Show();
            Close();
        }
        #endregion
        public void RefreshRunningSessions()
        {
            runninsSessionBox.ItemsSource = m.GetAllRunningSessions();
        }
    }
}
