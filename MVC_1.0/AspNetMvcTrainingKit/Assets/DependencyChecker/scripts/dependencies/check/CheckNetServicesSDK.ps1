function SearchUninstall($SearchFor, $UninstallKey)
{
$uninstallObjects = ls -path $UninstallKey;
$found = $FALSE;

foreach($uninstallEntry in  $uninstallObjects)
{
   $entryProperty = Get-ItemProperty -path registry::$uninstallEntry
   if($entryProperty.DisplayName -like $searchFor)
    {       
       $found = $TRUE;
       break;
    }
}

$found;
}

$os=Get-WMIObject win32_operatingsystem
if ($os.OSArchitecture -eq "64-bit") {
    SearchUninstall -SearchFor 'Microsoft .NET Services*SDK*' -UninstallKey 'HKLM:SOFTWARE\Wow6432Node\Microsoft\Windows\CurrentVersion\Uninstall\';
}
else {
    SearchUninstall -SearchFor 'Microsoft .NET Services*SDK*' -UninstallKey 'HKLM:SOFTWARE\Microsoft\Windows\CurrentVersion\Uninstall\';
}

