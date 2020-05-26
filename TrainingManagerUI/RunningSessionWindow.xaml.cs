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
        //TODO: add InotifyPropertyChanged for updating to RunningSession
        private TrainingManager m;
        public RunningSessionWindow(TrainingManager trainingmg)
        {
            InitializeComponent();
            m = trainingmg;
            runninsSessionBox.ItemsSource = m.GetAllRunningSessions();
        }

        private void btnAddRunningSession_Click(object sender, RoutedEventArgs e)
        {
            RunningSessionAddWindow rsa = new RunningSessionAddWindow(m);
            rsa.Show();
        }

        private void btnRemoveRunningSession_Click(object sender, RoutedEventArgs e)
        {
            RunningSession toRemove = (RunningSession) runninsSessionBox.SelectedItem;
            List<int> toRemoveID = new List<int>(toRemove.Id);
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
    }
}
