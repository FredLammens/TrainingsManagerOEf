﻿using DataLayer;
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
        //verbetering : RunningSession en CyclingSession 1 window met visibility to whatever is selected 
        //databinding in xaml , hardcode verwijderen
        //minimum size adden
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
            //cycling en running nakijken + sorteren op maandbasis + beste toevoegen aan overzicht 
            //checken voor values !
            if (yearW || monthW)
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
        }

        private void MenuItemCycling_Click(object sender, RoutedEventArgs e)
        {
            CyclingSessionWindow csw = new CyclingSessionWindow(m);
            csw.Show();
        }

        private void MenuItemLatest_Click(object sender, RoutedEventArgs e)
        {
            LatestSessionWindow lsw = new LatestSessionWindow(m);
            lsw.Show();
        }
        #endregion
    }
}
