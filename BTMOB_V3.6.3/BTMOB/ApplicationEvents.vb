Imports System.IO
Imports Microsoft.VisualBasic.ApplicationServices

Namespace My
    ' The following events are available for MyApplication:
    ' Startup: Raised when the application starts, before the startup form is created.
    ' Shutdown: Raised after all application forms are closed.  This event is not raised if the application terminates abnormally.
    ' UnhandledException: Raised if the application encounters an unhandled exception.
    ' StartupNextInstance: Raised when launching a single-instance application and the application is already active. 
    ' NetworkAvailabilityChanged: Raised when the network connection is connected or disconnected.
    Partial Friend Class MyApplication
        Private ReadOnly ExceptionLogPath As String = "Resources\logs\Unhandled"

        Private Sub MyApplication_UnhandledException(sender As Object, e As UnhandledExceptionEventArgs) Handles Me.UnhandledException
            If Not Directory.Exists(ExceptionLogPath) Then
                Directory.CreateDirectory(ExceptionLogPath)
            End If

            Dim exeption_message As String = ""
            Try
                exeption_message = e.Exception.Message
            Catch ex As Exception

            End Try
            Dim exeption_Source As String = ""
            Try
                exeption_Source = e.Exception.Source
            Catch ex As Exception

            End Try
            Dim exeption_TargetSite As String = ""
            Try
                exeption_TargetSite = e.Exception.TargetSite.Name
            Catch ex As Exception

            End Try
            Dim exeption_InnerException As String = ""
            Try
                exeption_InnerException = e.Exception.InnerException.Message
            Catch ex As Exception

            End Try

            Dim exeption_StackTrace As String = ""
            Try
                exeption_StackTrace = e.Exception.StackTrace
            Catch ex As Exception

            End Try

            Dim exeption_Base As String = ""
            Try
                exeption_Base = EXtoString(e.Exception)
            Catch ex As Exception

            End Try


            Dim timestamp As String = DateTime.Now.ToString("yyyyMMdd_HHmmss")

            Dim filePath As String = Path.Combine(ExceptionLogPath, timestamp + ".log")
            IO.File.AppendAllText(filePath,
                     $"{vbNewLine}" &
                     $"--- Exception Log Start ---{vbNewLine}" &
                     $"Message: {exeption_message}{vbNewLine}" &
                     $"Source: {exeption_Source}{vbNewLine}" &
                     $"Timestamp: {DateTime.Now:yyyy-MM-dd HH:mm:ss}{vbNewLine}" &
                     $"TargetSite: {exeption_TargetSite}{vbNewLine}" &
                     $"StackTrace: {vbNewLine}{exeption_StackTrace}{vbNewLine}" &
                     $"BaseException: {exeption_Base}{vbNewLine}" &
                     $"InnerException: {If(exeption_InnerException, "None")}{vbNewLine}" &
                     $"--- Exception Log End ---{vbNewLine}{vbNewLine}"
             )

        End Sub
    End Class
End Namespace
