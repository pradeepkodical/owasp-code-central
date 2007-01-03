@echo off
net use V: /d
net use V: "\\10.8.74.16\data\Sectech\GSS\ISS Pentest\Owasp VulnReport" 
regsvr32 "V:\V-drive_vulnreport\1. Application (i.e. run VulnReport from the network)\v0.86 (BETA)\COM Objects\AuthenticPlugin.dll" /s
regsvr32 "V:\V-drive_vulnreport\1. Application (i.e. run VulnReport from the network)\v0.86 (BETA)\COM Objects\pdf.ocx" /s
%windir%\Microsoft.NET\Framework\v2.0.50727\CasPol.exe -q -m -ag 1 -url file://V:/* FullTrust -name "V Drive - VulnReport" 
net use u: "\\10.8.74.16\data\ORG_data"
cd "V:\V-drive_vulnreport\1. Application (i.e. run VulnReport from the network)\v0.86 (BETA)"
V:
Start "Owasp Report Generator.exe"  "Owasp Report Generator.exe" 
