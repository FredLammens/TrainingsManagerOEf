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
    /// Interaction logic for CyclingSessionRemoveWindow.xaml
    /// </summary>
    public partial class CyclingSessionWindow : Window
    {
        private TrainingManager m;
        public CyclingSessionWindow(TrainingManager trainingmg)
        {
            InitializeComponent();
            m = trainingmg;
        }

        private void btnAddCyclingSession_Click(object sender, RoutedEventArgs e)
        {

        }

        private void btnRemoveCyclingSession_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
