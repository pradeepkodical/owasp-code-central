@echo off

AltovaXML /xslt1 "C:\ORG - Owasp Report Generator\V-Drive\Application (exe)\v0.83\VulnReport_Files\xslt\misc\MapToGVADataFeedXsd_v0_5.xslt" /in "C:\my Temp\_VulnReport_tempFiles\tmp4D3.xml" /out "C:\ORG - Owasp Report Generator\V-Drive\Application (exe)\v0.83\VulnReport_Files\xsd\GVADataFeedXsd_v0.5.xml" %*
IF ERRORLEVEL 1 EXIT/B %ERRORLEVEL%
