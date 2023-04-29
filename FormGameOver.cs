
using System;
using System.Drawing;
using System.Windows.Forms;

namespace Tabuleiro
{
	/// <summary>
	/// Description of FormGameOver.
	/// </summary>
	public partial class FormGameOver : Form
	{
		public FormGameOver()
		{
			
			InitializeComponent();
			
		}
		void Button2Click(object sender, EventArgs e)
		{
			this.Close();
		}
	}
}
