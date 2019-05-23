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

		Public Sub New(ByVal progressBarMaximum As Integer)
			InitializeComponent()
			progressBarEdit.Maximum = progressBarMaximum
			Report(0)
		End Sub

		Public Sub Report(ByVal value As Integer) Implements IProgress(Of Integer).Report
			progressBarEdit.Value = value
			progressLabel.Content = String.Format("{0} of {1} records created", value, progressBarEdit.Maximum)
		End Sub
	End Class
End Namespace
