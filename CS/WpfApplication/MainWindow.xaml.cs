using System;
using DevExpress.Xpf.Core;
using DevExpress.Xpo;
using XpoTutorial;

namespace WpfApplication {

    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : ThemedWindow {
        public MainWindow() {
            InitializeComponent();
            GenerateSampleData();

            var viewProperties = new ServerViewProperty[] {
                new ServerViewProperty("Oid", SortDirection.Ascending, "[Oid]"),
                new ServerViewProperty("OrderDate", SortDirection.None, "[OrderDate]"),
                new ServerViewProperty("Customer", SortDirection.None, "[Customer.ContactName]"),
                new ServerViewProperty("ProductName", SortDirection.None, "[ProductName]"),
                new ServerViewProperty("Price", SortDirection.None, "[Price]"),
                new ServerViewProperty("Quantity", SortDirection.None, "[Quantity]"),
                new ServerViewProperty("TotalPrice", SortDirection.None, "[Quantity] * [Price]"),
                new ServerViewProperty("Tax", SortDirection.None, "[Quantity] * [Price] * 0.13")
            };

            var session = new UnitOfWork(XpoDefault.DataLayer);
            var xpServerModeView1 = new XPServerModeView(session, typeof(Order));
            xpServerModeView1.Properties.AddRange(viewProperties);

            var xpInstantFeedbackView1 = new XPInstantFeedbackView(typeof(Order), viewProperties, null);
            xpInstantFeedbackView1.ResolveSession += (s, e) => {
                e.Session = session;
            };

            gridServerModeView.ItemsSource = xpServerModeView1;
            gridInstantFeedbackView.ItemsSource = xpInstantFeedbackView1;
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