function CheckSDKFolder
{


$checked = $FALSE;
$programFile = get-content env:programfiles;


$sdkPath =  $programfile+"\Microsoft SDKs\Live Framework SDK\v0.9"


if ((test-path -path $sdkPath))
{
$checked = $TRUE;
}

$checked;

}

CheckSDKFolder;
