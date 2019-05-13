Imports System
Imports DevExpress.Xpf.Core
Imports DevExpress.Xpo
Imports WpfApplication.ViewModels
Imports XpoTutorial

Namespace WpfApplication

	''' <summary>
	''' Interaction logic for MainWindow.xaml
	''' </summary>
	Partial Public Class MainWindow
		Inherits ThemedWindow

		Private model As MainViewModel
		Public Sub New()
			InitializeComponent()
			GenerateSampleData()
			model = New MainViewModel()
			DataContext = model
		End Sub

		Private Sub GenerateSampleData()
			Using uow As New UnitOfWork()
				Dim progressForm As New ProgressWindow()
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