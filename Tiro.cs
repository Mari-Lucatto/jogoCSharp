
using System;
using System.Drawing;
using System.Media;
using System.Windows.Forms;

namespace Tabuleiro
{
	/// <summary>
	/// Description of Tiro.
	/// </summary>
	public class Tiro : PictureBox
	{
		public Tiro(int leftHeroi, int topHeroi)
		{
			Load("kirbystar.gif");
			SizeMode = PictureBoxSizeMode.StretchImage;
			BackColor = Color.Transparent;
			Width = 60;
			Height = 30;
			
			speed = rnd.Next(25,50);
			dano = speed;
			Left = leftHeroi + 100;
			Top = topHeroi + 35;
			timer1.Tick += Movimento;
			timer1.Interval = 100;
			timer1.Enabled = true;
		}
		
		public int dano;
		public int speed;
		public int fundoWidth;
		public string imagem;
		Random rnd = new Random();
		public Timer timer1 = new Timer();
		
		public void Movimento (object sender, EventArgs e)
		{
			Left += speed;
			if (Left > fundoWidth - 100)
			{
				Listas.RemoveItem(this);
				timer1.Enabled = false;
				Dispose();
			}
			else{
				if (Colide.TesteColisao(this))
				{
				timer1.Enabled = false;
				Dispose();
				}
			}
		}
	}
}
