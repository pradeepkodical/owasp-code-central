@echo off
regsvr32 "C:\Program Files\ABN AMRO\OWASP_Report_Generator\AuthenticPlugin\AuthenticPlugin.dll" /s
net use u: /d
net use u: "\\10.8.74.16\data\ORG_data" 
cd "C:\Program Files\ABN AMRO\OWASP_Report_Generator"
start "C:\Program Files\ABN AMRO\OWASP_Report_Generator\Owasp Report Generator.exe" "C:\Program Files\ABN AMRO\OWASP_Report_Generator\Owasp Report Generator.exe"
