Imports DevExpress.Xpo
Imports System
Imports System.Threading.Tasks
Imports System.Windows
Imports XpoTutorial

Namespace WpfApplication
	''' <summary>
	''' Interaction logic for App.xaml
	''' </summary>
	Partial Public Class App
		Inherits Application

		Protected Overrides Sub OnStartup(ByVal e As StartupEventArgs)
			MyBase.OnStartup(e)
			Try
				ConnectionHelper.Connect()
			Catch ex As Exception
				MessageBox.Show(ex.Message, "Error", MessageBoxButton.OK, MessageBoxImage.Warning)
				Return
			End Try
		End Sub
	End Class
End Namespace
