
function HasVStheSP1($RegKeyVersion)
{
 $returnValue = $FALSE;
 if(Test-Path "$RegKeyVersion")
 {
   $returnValue = (Get-ItemProperty "$RegKeyVersion").SP -eq "1"  
 }
 $returnValue
}

function CheckForVSSP()
{
	$returnValue = $FALSE;

	#Indicates the service pack level for Visual Studio 2008 standard edition and higher
	if(HasVStheSP1 -RegKeyVersion 'HKLM:\SOFTWARE\Microsoft\DevDiv\VS\Servicing\9.0')
	{
	   $returnValue = $TRUE;
	}
	#Indicates the service pack level for Visual C# 2008 Express Edition
	elseif (HasVStheSP1 -RegKeyVersion 'HKLM:\SOFTWARE\Microsoft\DevDiv\VCS\Servicing\9.0')
	{
	  $returnValue = $TRUE;
	}
	#Indicates the service pack level for Visual Studio 2008 Team Foundation
	elseif (HasVStheSP1 -RegKeyVersion 'HKLM:\SOFTWARE\Microsoft\DevDiv\VSTF\Servicing\9.0')
	{
	  $returnValue = $TRUE;
	}

	$returnValue
}

CheckForVSSP
