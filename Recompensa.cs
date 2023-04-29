
using System;
using System.Drawing;
using System.Media;
using System.Windows.Forms;

namespace Tabuleiro
{
	/// <summary>
	/// Description of Recompensa.
	/// </summary>
	public class Recompensa : PictureBox
	{
		public Recompensa()
		{
			Load("tomato.png");
			SizeMode = PictureBoxSizeMode.StretchImage;
			BackColor = Color.Transparent;
			Width = 50;
			Height = 50;
			Left = 450;
			Top = 160;
			
			timerT.Tick += Colisao;
		}
		
		public Timer timerT = new Timer();
		public Heroi hero;
		
		public void Colisao (object sender, EventArgs e)
		{
			
			if(this.Bounds.IntersectsWith(hero.Bounds))
			{
				
				Dispose();
				hero.Visible = false;
				hero.Width = 1;
				hero.Height = 1;
				timerT.Enabled = false;
				var test = new FormTheEnd();
				test.ShowDialog();
				Application.Exit();
				
				
			}
		}
	}
}
