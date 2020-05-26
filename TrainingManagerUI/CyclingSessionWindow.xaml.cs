using DomainLibrary.Domain;
using System;
using System.Collections.Generic;
using System.Security.Cryptography;
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
    /// Interaction logic for CyclingSessionRemoveWindow.xaml
    /// </summary>
    public partial class CyclingSessionWindow : Window
    {
        private TrainingManager m;
        public CyclingSessionWindow(TrainingManager trainingmg)
        {
            InitializeComponent();
            m = trainingmg;
            cyclingSessionBox.ItemsSource = m.GetAllCyclingSessions();
        }

        private void btnAddCyclingSession_Click(object sender, RoutedEventArgs e)
        {
            CyclingSessionAddWindow csa = new CyclingSessionAddWindow(m);
            csa.Show();
        }

        private void btnRemoveCyclingSession_Click(object sender, RoutedEventArgs e)
        {
            CyclingSession toRemove = (CyclingSession)cyclingSessionBox.SelectedItem;
            List<int> toRemoveID = new List<int>(toRemove.Id);
            List<int> RunningSessions = new List<int>();
            if (cyclingSessionBox.SelectedItem != null) 
            {
                m.RemoveTrainings(toRemoveID, RunningSessions);
                MessageBox.Show($"{toRemove} is removed!", "CyclingSession", MessageBoxButton.OK, MessageBoxImage.Information);
            }
            else
            {
                MessageBox.Show($"Nothing selected", "CyclingSession", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void MenuItemHome_Click(object sender, RoutedEventArgs e)
        {
            MainWindow w = new MainWindow();
            w.Show();
            Close();
        }

        private void MenuItemRunning_Click(object sender, RoutedEventArgs e)
        {
            RunningSessionWindow rw = new RunningSessionWindow(m);
            rw.Show();
            Close();
        }

        private void MenuItemLatest_Click(object sender, RoutedEventArgs e)
        {
            LatestSessionWindow lw = new LatestSessionWindow(m);
            lw.Show();
            Close();
        }
    }
}
