using System;

namespace Displyy_Template.UI
{
	public class ButtonInfo
	{
		public string buttonText = "Error";

		public Action method;

		public Action disableMethod;

		public bool? enabled = new bool?(false);

		public string toolTip = "This button doesn't have a tooltip/tutorial";
	}
}
