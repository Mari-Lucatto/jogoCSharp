
using System;
using System.Drawing;
using System.Media;
using System.Windows.Forms;

namespace Tabuleiro
{
	public partial class FormTheEnd : Form
	{
		public FormTheEnd()
		{
			InitializeComponent();
			
			victory.PlayLooping();
		}
		public SoundPlayer victory = new SoundPlayer("victory.wav");
		
		void Button2Click(object sender, EventArgs e)
		{
			this.Close();
		}
	}
}
