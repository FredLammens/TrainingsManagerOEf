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
            if (cycling == true || running == true) 
            {
            }
            //List<CyclingSession> cyles = m.GetPreviousCyclingSessions();
        }
    }
}
