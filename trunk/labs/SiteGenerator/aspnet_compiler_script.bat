@echo off
aspnet_compiler -f -v \ -p SiteGenerator_ContentPages SiteGenerator_ContentPages_PreCompiled
del SiteGenerator_IIS_Website\bin\*aspx*.compiled
del SiteGenerator_IIS_Website\bin\App_Web*.dll
copy SiteGenerator_ContentPages_PreCompiled\PrecompiledApp.config SiteGenerator_IIS_Website\PrecompiledApp.config
copy SiteGenerator_ContentPages_PreCompiled\bin SiteGenerator_IIS_Website\bin 
rd /S /Q SiteGenerator_ContentPages_PreCompiled
pause
