Imports System.IO
Imports System.Media
Imports System.Timers
Imports System.Windows.Forms.VisualStyles.VisualStyleElement
Imports DrakeUI.Framework

Public Class AudioVisualizer
    Private audioPlayer As SoundPlayer
    Private audioAmplitudeTimer As Timer
    Private progressBar As DrakeUITrackBar
    Private amplitude As Integer = 0
    Private ran As Random
    Public Sub New(progressBarControl As DrakeUITrackBar)

        Me.progressBar = progressBarControl
        Me.audioPlayer = New SoundPlayer()

        Me.audioAmplitudeTimer = New Timer(70)
        AddHandler audioAmplitudeTimer.Elapsed, AddressOf UpdateProgressBar

        If ran Is Nothing Then
            ran = New Random
        End If

    End Sub

    Public Sub Play(wavData As Byte())


        Using ms As New MemoryStream(wavData)
            audioPlayer.Stream = ms
            audioPlayer.Play()
        End Using

        amplitude = ran.Next(10, 100)

        If Not audioAmplitudeTimer.Enabled Then
            audioAmplitudeTimer.Start()
        End If

    End Sub

    Private Sub UpdateProgressBar(sender As Object, e As ElapsedEventArgs)



        If amplitude > 0 Then

            progressBar.Invoke(Sub()
                                   progressBar.Value = amplitude
                                   amplitude = 0
                               End Sub)
        End If

        If progressBar.Value > 0 Then
            progressBar.Value = progressBar.Value - 1
        End If
    End Sub

    Public Sub StopVisualization()

        audioAmplitudeTimer.Stop()
        progressBar.Value = 0
    End Sub
End Class
