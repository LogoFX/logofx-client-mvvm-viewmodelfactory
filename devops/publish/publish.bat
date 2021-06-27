SET package_name=LogoFX.Client.Mvvm.ViewModelFactory
SET package_version=2.2.0
cd ../../src
nuget restore
cd ../devops/build
call build.bat
cd ../pack
call ./pack.bat
cd ../publish
call ./copy.bat %package_name% %package_version% %1
cd ../install
call uninstall-global-single.bat %package_name% %package_version%
cd ..