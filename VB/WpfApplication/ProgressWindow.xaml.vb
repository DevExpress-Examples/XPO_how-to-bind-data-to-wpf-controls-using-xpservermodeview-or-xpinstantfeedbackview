Imports DevExpress.Xpf.Core
Imports System
Imports System.Windows


Namespace WpfApplication
	''' <summary>
	''' Interaction logic for ProgressWindow.xaml
	''' </summary>
	Partial Public Class ProgressWindow
		Inherits ThemedWindow
		Implements IProgress(Of Integer)

		Public Sub New()
			InitializeComponent()
		End Sub

		Public Sub Report(ByVal value As Integer) Implements IProgress(Of Integer).Report
			progressBarEdit.Value = value
		End Sub
	End Class
End Namespace
