Imports System
Imports DevExpress.Xpf.Core
Imports DevExpress.Xpo
Imports XpoTutorial

Namespace WpfApplication

	''' <summary>
	''' Interaction logic for MainWindow.xaml
	''' </summary>
	Partial Public Class MainWindow
		Inherits ThemedWindow

		Public Sub New()
			InitializeComponent()
			GenerateSampleData()

			Dim viewProperties = New ServerViewProperty() {
				New ServerViewProperty("Oid", SortDirection.Ascending, "[Oid]"),
				New ServerViewProperty("OrderDate", SortDirection.None, "[OrderDate]"),
				New ServerViewProperty("Customer", SortDirection.None, "[Customer.ContactName]"),
				New ServerViewProperty("ProductName", SortDirection.None, "[ProductName]"),
				New ServerViewProperty("Price", SortDirection.None, "[Price]"),
				New ServerViewProperty("Quantity", SortDirection.None, "[Quantity]"),
				New ServerViewProperty("TotalPrice", SortDirection.None, "[Quantity] * [Price]"),
				New ServerViewProperty("Tax", SortDirection.None, "[Quantity] * [Price] * 0.13")
			}

			Dim session = New UnitOfWork(XpoDefault.DataLayer)
			Dim xpServerModeView1 = New XPServerModeView(session, GetType(Order))
			xpServerModeView1.Properties.AddRange(viewProperties)

			Dim xpInstantFeedbackView1 = New XPInstantFeedbackView(GetType(Order), viewProperties, Nothing)
			AddHandler xpInstantFeedbackView1.ResolveSession, Sub(s, e)
				e.Session = session
			End Sub

			gridServerModeView.ItemsSource = xpServerModeView1
			gridInstantFeedbackView.ItemsSource = xpInstantFeedbackView1
		End Sub

		Private Sub GenerateSampleData()
			Using uow As New UnitOfWork()
				Dim progressForm As New ProgressWindow(DemoDataHelper.RecordsCount)
				AddHandler progressForm.Loaded, Async Sub(s, args)
					If DemoDataHelper.IsSeedRequired(uow) Then
						Await DemoDataHelper.SeedAsync(uow, progressForm)
					End If
					progressForm.Close()
				End Sub
				progressForm.ShowDialog()
			End Using
		End Sub
	End Class
End Namespace