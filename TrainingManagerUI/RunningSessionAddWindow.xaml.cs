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
using System.Windows.Media.Animation;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace TrainingManagerUI
{
    /// <summary>
    /// Interaction logic for RunningSessionWindow.xaml
    /// </summary>
    public partial class RunningSessionAddWindow : Window
    {
        private TrainingManager m;
        public RunningSessionAddWindow(TrainingManager trainingmg)
        {
            InitializeComponent();
            m = trainingmg;
            DatePickerRunning.BlackoutDates.Add(new CalendarDateRange(DateTime.Now.AddDays(1), DateTime.MaxValue));
            trainingTypeRunningSession.ItemsSource = Enum.GetNames(typeof(TrainingType)); // insert trainingtypes
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            DateTime when; TimeSpan whenAdditional;
            int distance; TimeSpan time; float averageSpeed;
            TrainingType trainingtype; string comment = commentaarRunningSession.Text;
            #region parsers
            bool distanceW = int.TryParse(afstandRunningSession.Text, out distance);
            bool timeW = TimeSpan.TryParse(tijdsduurRunningSession.Text, out time);
            bool averageSpeedW = float.TryParse(gemiddeldeSnelheidRunningSession.Text, out averageSpeed);
            bool whenAdditionalW = TimeSpan.TryParse(tijdStipRunningSession.Text, out whenAdditional);
            Enum.TryParse((string?)trainingTypeRunningSession.SelectedItem, out trainingtype);
            #endregion
            if (!DatePickerRunning.SelectedDate.HasValue)
            {
                MessageBox.Show("Date not entered!", "RunningSession", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            else if (!whenAdditionalW)
            {
                MessageBox.Show("Time not entered or incorrectly!", "RunningSession", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            else if (!distanceW)
            {
                MessageBox.Show("Distance not entered or incorrectly!", "RunningSession", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            else if (!timeW)
            {
                MessageBox.Show("Time not entered or incorrectly!", "RunningSession", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            else if (!averageSpeedW)
            {
                when = (DateTime)DatePickerRunning.SelectedDate;
                when.Add(whenAdditional);
                try
                {
                    m.AddRunningTraining(when, distance, time, null, trainingtype, comment);
                    MessageBox.Show("Runningsession added", "RunningSession", MessageBoxButton.OK, MessageBoxImage.Information);
                }
                catch (Exception)//TODO: uitgebreider maken
                {
                    MessageBox.Show("Recheck your values pls", "RunningSession", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
            else
            {
                when = (DateTime)DatePickerRunning.SelectedDate;
                when.Add(whenAdditional);
                try
                {
                    m.AddRunningTraining(when, distance, time, averageSpeed, trainingtype, comment);
                    MessageBox.Show("Runningsession added", "RunningSession", MessageBoxButton.OK, MessageBoxImage.Information);
                }
                catch (Exception)//TODO: uitgebreide maken
                {
                    MessageBox.Show("Recheck your values pls", "RunningSession", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
        }
    }
}
