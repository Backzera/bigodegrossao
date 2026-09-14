# Run this script as Administrator
$RegPath = "HKLM:\SYSTEM\CurrentControlSet\Services\Tcpip\Parameters"

# Function to create or update a registry key
Function Set-RegistryValue {
    param (
        [string]$Path,
        [string]$Name,
        [int]$Value
    )
    if (Get-ItemProperty -Path $Path -Name $Name -ErrorAction SilentlyContinue) {
        Set-ItemProperty -Path $Path -Name $Name -Value $Value -Force
    } else {
        New-ItemProperty -Path $Path -Name $Name -Value $Value -PropertyType DWORD -Force
    }
}

# Create or update registry keys
Set-RegistryValue -Path $RegPath -Name "TcpTimedWaitDelay" -Value 0x1e
Set-RegistryValue -Path $RegPath -Name "MaxUserPort" -Value 0xfffe
Set-RegistryValue -Path $RegPath -Name "TcpNumConnections" -Value 0xfffffe
Set-RegistryValue -Path $RegPath -Name "TcpMaxDataRetransmissions" -Value 0x05

Write-Host "Registry values updated successfully!"