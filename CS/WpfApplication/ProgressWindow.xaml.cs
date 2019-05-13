using DevExpress.Xpf.Core;
using System;
using System.Windows;


namespace WpfApplication {
    /// <summary>
    /// Interaction logic for ProgressWindow.xaml
    /// </summary>
    public partial class ProgressWindow : ThemedWindow, IProgress<int> {
        public ProgressWindow() {
            InitializeComponent();
        }

        public void Report(int value) {
            progressBarEdit.Value = value;
        }
    }
}
