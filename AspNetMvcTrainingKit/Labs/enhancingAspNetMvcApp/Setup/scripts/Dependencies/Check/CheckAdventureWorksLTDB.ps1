$db = sqlcmd -Q "select count(*) from [master].sys.databases where name = 'AdventureWorksLT'" -S ".\SQLEXPRESS"

$found = $TRUE;

if ($db -match "0")
{  	
   $found = $FALSE;
}

$found
