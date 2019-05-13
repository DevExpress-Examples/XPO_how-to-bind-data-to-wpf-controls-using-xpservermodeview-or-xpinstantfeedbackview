using System;
using System.Collections.Generic;
using DevExpress.Xpo;
using System.ComponentModel;
using XpoTutorial;
using System.Linq;
using System.Threading.Tasks;
using DevExpress.Data.Filtering;

namespace WpfApplication.ViewModels {

    class MainViewModel {

        public MainViewModel() {
            var viewProperties = new ServerViewProperty[] {
                new ServerViewProperty("Oid", SortDirection.Ascending, "[Oid]"),
                new ServerViewProperty("OrderDate", SortDirection.None, "[OrderDate]"),
                new ServerViewProperty("Customer", SortDirection.None, "[Customer.ContactName]"),
                new ServerViewProperty("ProductName", SortDirection.None, "[ProductName]"),
                new ServerViewProperty("Price", SortDirection.None, "[Price]"),
                new ServerViewProperty("Quantity", SortDirection.None, "[Quantity]"),
                new ServerViewProperty("TotalPrice", SortDirection.None, "[Quantity] * [Price]"),
                new ServerViewProperty("PercentFromSalesByMonth", SortDirection.None, "[Quantity] * [Price] / [<Order>][GetYear([OrderDate]) = GetYear([^.OrderDate]) And GetMonth([OrderDate]) = GetMonth([^.OrderDate])].Sum([Quantity] * [Price]) * 100")
            };

            UnitOfWork session = new UnitOfWork(XpoDefault.DataLayer);
            ordersXpServerModeView = new XPServerModeView(session, typeof(Order));
            ordersXpServerModeView.Properties.AddRange(viewProperties);

            ordersXpInstantFeedbackView = new XPInstantFeedbackView(typeof(Order), viewProperties, null);
            ordersXpInstantFeedbackView.ResolveSession += (s, e) => {
                e.Session = session;
            };
        }

        readonly XPServerModeView ordersXpServerModeView;
        public XPServerModeView OrdersXPServerModeView {
            get {
                return ordersXpServerModeView;
            }
        }

        readonly XPInstantFeedbackView ordersXpInstantFeedbackView;

        public XPInstantFeedbackView OrdersXPInstantFeedbackView {
            get {
                return ordersXpInstantFeedbackView;
            }
        }
    }
}