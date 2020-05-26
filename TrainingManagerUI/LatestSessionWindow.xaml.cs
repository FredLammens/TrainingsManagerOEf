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
    }
}
