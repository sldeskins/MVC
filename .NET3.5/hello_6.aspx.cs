using System;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace PS 
{
	//add partial
	public partial class HelloCbBase6 : Page
	{
		//match the control ID and type -- Is not needed in V2
	    //protected BulletedList _displayList;
		
		string[] _displayItemData = {
		"Item #1", 
		"Item #2",
		"Item #3",
		"Item #4",
		"Item #5",
		"Item #6",
		"Item #7",
		"Item #8"};
		
		protected const int _itemCount=10;

		string GetDisplayItem(int n){
			return "Item #" + n.ToString();
		}
 
		protected override void OnLoad(EventArgs e){
			  _displayList.DataSource = _displayItemData ;
			  _displayList.DataBind();
			base.OnLoad(e);
		}
		
		//implicit wireUP
		protected void Page_LoadComplete(object sender, EventArgs e){
			Response.Write("Page load complete called!");
		}
		
		protected void _clickMeButton_Click(object sender, EventArgs e){
			_msgLabel.Text ="Hi there from Button click";
		}
	}
}