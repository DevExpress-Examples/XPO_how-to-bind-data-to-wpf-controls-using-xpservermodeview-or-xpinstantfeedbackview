using System;
using DevExpress.Xpf.Core;
using DevExpress.Xpo;
using WpfApplication.ViewModels;
using XpoTutorial;

namespace WpfApplication {

    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : ThemedWindow {
        MainViewModel model;
        public MainWindow() {
            InitializeComponent();
            GenerateSampleData();
            model = new MainViewModel();
            DataContext = model;
        }

        void GenerateSampleData() {
            using(UnitOfWork uow = new UnitOfWork()) {
                ProgressWindow progressForm = new ProgressWindow(DemoDataHelper.RecordsCount);
                progressForm.Loaded += async (s, args) => {
                    if(DemoDataHelper.IsSeedRequired(uow)) {
                        await DemoDataHelper.SeedAsync(uow, progressForm);
                    }
                    progressForm.Close();
                };
                progressForm.ShowDialog();
            }
        }
    }
}