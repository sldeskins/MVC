 using System;
 using System.Collections.Generic;
 
 namespace PS.AspDotNet{
	public static class MyDataSource{
	    static int _itemCount = 10;
		
		public static int ItemCount { get {return _itemCount; } }
		
		public static IEnumerable<string> GetItems(){
			for(int i=0; i<_itemCount; i++) 
				yield return "Item #" + i.ToString();
			 
		}
	}
} 