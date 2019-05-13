using DevExpress.Xpo;
using System;
using System.Threading.Tasks;
using System.Windows;
using XpoTutorial;

namespace WpfApplication {
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application {
        protected override void OnStartup(StartupEventArgs e) {
            base.OnStartup(e);
            try {
                ConnectionHelper.Connect();
            } catch(Exception ex) {
                MessageBox.Show(ex.Message, "Error", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }
        }
    }
}
