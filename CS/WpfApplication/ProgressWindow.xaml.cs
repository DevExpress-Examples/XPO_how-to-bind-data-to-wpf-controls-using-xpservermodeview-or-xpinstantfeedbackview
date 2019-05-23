using DevExpress.Xpf.Core;
using System;
using System.Windows;


namespace WpfApplication {
    /// <summary>
    /// Interaction logic for ProgressWindow.xaml
    /// </summary>
    public partial class ProgressWindow : ThemedWindow, IProgress<int> {
        public ProgressWindow(int progressBarMaximum) {
            InitializeComponent();
            progressBarEdit.Maximum = progressBarMaximum;
            Report(0);
        }

        public void Report(int value) {
            progressBarEdit.Value = value;
            progressLabel.Content = string.Format("{0} of {1} records created", value, progressBarEdit.Maximum);
        }
    }
}
