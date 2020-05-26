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
    /// Interaction logic for CyclingSessionWindow.xaml
    /// </summary>
    public partial class CyclingSessionAddWindow : Window
    {
        private TrainingManager m;
        public CyclingSessionAddWindow(TrainingManager trainingmg)
        {
            InitializeComponent();
            m = trainingmg;
            DatePickerCycling.BlackoutDates.Add(new CalendarDateRange(DateTime.Now.AddDays(1), DateTime.MaxValue));
            trainingTypeCyclingSession.ItemsSource = Enum.GetNames(typeof(TrainingType)); // insert trainingtypes
            typeFietsListBox.ItemsSource = Enum.GetNames(typeof(BikeType));//Insert biketypes
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            DateTime when; TimeSpan whenAdditional;
            int distance; TimeSpan time; float averageSpeed;
            TrainingType trainingtype; string comment = commentaarCyclingSession.Text;
            BikeType bikeType; int averageWatt;
            #region parsers
            bool distanceW = int.TryParse(afstandCyclingSession.Text, out distance);
            bool timeW = TimeSpan.TryParse(tijdsduurCyclingSession.Text, out time);
            bool averageSpeedW = float.TryParse(gemiddeldeSnelheidCyclingSession.Text, out averageSpeed);
            bool whenAdditionalW = TimeSpan.TryParse(tijdStipCyclingSession.Text, out whenAdditional);
            bool averageWattW = int.TryParse(avgWattage.Text, out averageWatt);
            Enum.TryParse((string?)trainingTypeCyclingSession.SelectedItem, out trainingtype);
            Enum.TryParse((string?)typeFietsListBox.SelectedItem, out bikeType);
            #endregion
            if (!DatePickerCycling.SelectedDate.HasValue)
            {
                MessageBox.Show("Date not entered!", "CyclingSession", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            else if (!whenAdditionalW)
            {
                MessageBox.Show("Time not entered or incorrectly!", "CyclingSession", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            else if (!distanceW)
            {
                MessageBox.Show("Distance not entered or incorrectly!", "CyclingSession", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            else if (!timeW)
            {
                MessageBox.Show("Time not entered or incorrectly!", "CyclingSession", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            else if (!averageWattW) 
            {
                MessageBox.Show("Average Watt not entered or incorrectly!", "CyclingSession", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            else if (!averageSpeedW)
            {
                when = (DateTime)DatePickerCycling.SelectedDate;
                when.Add(whenAdditional);
                try
                {
                    m.AddCyclingTraining(when, distance, time, null,averageWatt, trainingtype, comment,bikeType);
                    MessageBox.Show("Cyclingsession added", "CyclingSession", MessageBoxButton.OK, MessageBoxImage.Information);
                }
                catch (Exception)
                {
                    MessageBox.Show("Recheck your values pls", "CyclingSession", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
            else
            {
                when = (DateTime)DatePickerCycling.SelectedDate;
                when.Add(whenAdditional);
                try
                {
                    m.AddCyclingTraining(when, distance, time, averageSpeed,averageWatt, trainingtype, comment,bikeType);
                    MessageBox.Show("Cyclingsession added", "CyclingSession", MessageBoxButton.OK, MessageBoxImage.Information);
                }
                catch (Exception)
                {
                    MessageBox.Show("Recheck your values pls", "CyclingSession", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
        }
    }
}
