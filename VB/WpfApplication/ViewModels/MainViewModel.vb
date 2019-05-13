Imports System
Imports System.Collections.Generic
Imports DevExpress.Xpo
Imports System.ComponentModel
Imports XpoTutorial
Imports System.Linq
Imports System.Threading.Tasks
Imports DevExpress.Data.Filtering

Namespace WpfApplication.ViewModels

	Friend Class MainViewModel

		Public Sub New()
			Dim viewProperties = New ServerViewProperty() {
				New ServerViewProperty("Oid", SortDirection.Ascending, "[Oid]"),
				New ServerViewProperty("OrderDate", SortDirection.None, "[OrderDate]"),
				New ServerViewProperty("Customer", SortDirection.None, "[Customer.ContactName]"),
				New ServerViewProperty("ProductName", SortDirection.None, "[ProductName]"),
				New ServerViewProperty("Price", SortDirection.None, "[Price]"),
				New ServerViewProperty("Quantity", SortDirection.None, "[Quantity]"),
				New ServerViewProperty("TotalPrice", SortDirection.None, "[Quantity] * [Price]"),
				New ServerViewProperty("PercentFromSalesByMonth", SortDirection.None, "[Quantity] * [Price] / [<Order>][GetYear([OrderDate]) = GetYear([^.OrderDate]) And GetMonth([OrderDate]) = GetMonth([^.OrderDate])].Sum([Quantity] * [Price]) * 100")
			}

			Dim session As New UnitOfWork(XpoDefault.DataLayer)
            _ordersXpServerModeView = New XPServerModeView(session, GetType(Order))
            _ordersXpServerModeView.Properties.AddRange(viewProperties)

            _ordersXpInstantFeedbackView = New XPInstantFeedbackView(GetType(Order), viewProperties, Nothing)
            AddHandler _ordersXpInstantFeedbackView.ResolveSession, Sub(s, e)
				e.Session = session
			End Sub
		End Sub

        Private ReadOnly _ordersXpServerModeView As XPServerModeView
        Public ReadOnly Property OrdersXPServerModeView() As XPServerModeView
			Get
                Return _ordersXpServerModeView
            End Get
		End Property

        Private ReadOnly _ordersXpInstantFeedbackView As XPInstantFeedbackView

        Public ReadOnly Property OrdersXPInstantFeedbackView() As XPInstantFeedbackView
			Get
                Return _ordersXpInstantFeedbackView
            End Get
		End Property
	End Class
End Namespace