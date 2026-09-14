$taskName = "PM2 Auto Restore"
$pm2Path = "$env:APPDATA\npm\pm2.cmd"
$arguments = "start C:\inetpub\wwwroot\yaarsa\server\websocket-server.js"

# Define the action
$action = New-ScheduledTaskAction -Execute $pm2Path -Argument $arguments

# Define the trigger (At startup)
$trigger = New-ScheduledTaskTrigger -AtStartup

# Run with highest privileges
$principal = New-ScheduledTaskPrincipal -UserId "SYSTEM" -LogonType ServiceAccount -RunLevel Highest

# Updated settings to allow indefinite runtime
$settings = New-ScheduledTaskSettingsSet -AllowStartIfOnBatteries -DontStopIfGoingOnBatteries -StartWhenAvailable -ExecutionTimeLimit 0

# Register the task with compatibility (Win8 is closest to Win10/Server 2022)
Register-ScheduledTask -TaskName $taskName -Action $action -Trigger $trigger -Principal $principal -Settings $settings
