
using System;
using System.Drawing;
using System.Media;
using System.Windows.Forms;

namespace Tabuleiro
{

	public class Inimigo : PictureBox
	{
		public Inimigo(int largura, int altura)
		{
			Load ("birdon.gif");
			SizeMode = PictureBoxSizeMode.StretchImage;
			BackColor = Color.Transparent;
			Width = 70;
			Height = 70;			
			Left = largura - rnd.Next(100,200);
			Top = rnd.Next(65,altura) - 50;
			
			speed = rnd.Next(15,30);
			timerIn.Interval = 100;
			timerIn.Tick += Movimento;
			timerIn.Enabled = true;
			
			hp = 20;
			dano = speed;
			die.LoadAsync();
		
		}

		public int dano;
		public int hp;
		public int speed;
		
		Random rnd = new Random();
		public Timer timerIn = new Timer();
		
		SoundPlayer die = new SoundPlayer("death.wav");
		
		
		public void Movimento(object sender, EventArgs e)
		{
			Left -= speed;
			
			if(Left<0)
			{
				Listas.RemoveItem(this);
				Dispose();
				timerIn.Enabled = false;
			}
			
			if(Colide.TesteColisao(this))
			{
				Listas.RemoveItem(this);
				timerIn.Enabled = false;
				Explosao.DestroiItem(this);
			}
 
		}
	}
}
