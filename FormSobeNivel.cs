
using System;
using System.Drawing;
using System.Runtime.Remoting.Channels;
using System.Windows.Forms;

namespace Tabuleiro
{
	/// <summary>
	/// Description of FormSobeNivel.
	/// </summary>
	public partial class FormSobeNivel : Form
	{
		public FormSobeNivel()
		{
			InitializeComponent();
			
			pictureBox1.Parent = pictureBox2;
			button1.Parent = pictureBox2;
			button2.Parent = pictureBox2;
			button3.Parent = pictureBox2;
			button4.Parent = pictureBox2;
		}
		
		public int escolha = 0;
		
		void BtnClick(object sender, EventArgs e)
		{
			escolha = int.Parse((sender as Button).Name[6].ToString());
			this.Close();
		}
	}
}
