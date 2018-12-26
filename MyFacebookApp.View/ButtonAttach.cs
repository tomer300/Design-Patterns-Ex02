using System.Windows.Forms;

namespace MyFacebookApp.View
{
	public class ButtonAttach
	{
		public void AddButton(ButtonBase i_Button, IAddable i_ButtonAttachTo, Panel i_OptionalPanelToAttachTo)
		{
			Control	controlToAttachTo = i_ButtonAttachTo as Control;

			if (controlToAttachTo != null)
			{
				if(i_OptionalPanelToAttachTo != null)
				{
					controlToAttachTo = i_OptionalPanelToAttachTo;
				}

				controlToAttachTo.Controls.Add(i_Button);
			}
		}
	}
}
