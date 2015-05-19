##http://msdn.microsoft.com/en-us/library/cc280268(VS.85).aspx
$query = Get-WmiObject -Query "SELECT * FROM Win32_ServerFeature WHERE ID = 222"
$query -ne $null