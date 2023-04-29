using System;
using System.Drawing;
using System.Media;
using System.Windows.Forms;
using System.Threading.Tasks;

namespace Tabuleiro
{

	public class Heroi : PictureBox
	{
		public Heroi()
		{
			Load(imagem);
			Width = 100;
			Height = 100;
			SizeMode = PictureBoxSizeMode.StretchImage;
			BackColor = Color.Transparent;
		}
		
		public string imagem = "kirbyanda.gif";
		public int hp = 100;
		int hpMax = 100;
		public int speed = 25;
		int speedMax = 25;
		public int escudo = 20;
		int escudoMax = 20;
		public int xp=0, lv=0;
		public int dano = 20;
		
		public string imagemFundo = "fundo0.png";
		public int larguraFundo = 500, alturaFundo = 500;
		
		public int countFundo=0;
		public int countUp=0;
		
        
		public SoundPlayer space = new SoundPlayer("outerrings.wav");
		public SoundPlayer garden = new SoundPlayer("gardens.wav");
		public SoundPlayer water = new SoundPlayer("waterworks.wav");
		public SoundPlayer dungeon = new SoundPlayer("dungeon.wav");
		
		public void GanhaXP()
        {
            xp += 1;
            if (xp > 4)
            {
                int aux = this.Left;
                this.Left = -500;
                Listas.KillThemAll();
                
                
                var frm = new FormSobeNivel();
                frm.ShowDialog();
                lv ++;
                switch (frm.escolha)
                {
                    case 1:
                        MessageBox.Show("You got more HP");
                        hpMax += 20;
                        hp = hpMax;
                        break;
                    case 2:
                        MessageBox.Show("You got more Power");
                        dano += 3;
                        break;
                    case 3:
                        MessageBox.Show("You got more Defense");
                        escudo += 10;
                        escudoMax += 10;
                        break;
                    case 4:
                        MessageBox.Show("You got more Speed");
                        speedMax += 2;
                        speed += 2;
                        break;
                }
                this.Left = aux;
                xp = 0;
            }
        }
		
		public void LevouDano(int danoInimigo)
		{
			int danoRemanescente = danoInimigo - escudo;
			escudo -= danoInimigo;
			if (escudo < 0) escudo = 0;
			if (danoRemanescente < 0) danoRemanescente = 0;
			hp -= danoRemanescente;
			if (hp < 0) hp = 0;
		}
		
		public void Dir()
		{
			Left +=speed; 
			Load("kirbyvoa.gif");

			if (Left>larguraFundo-100)
			{
				countFundo++;
				Left = 0;				
				
				if (countFundo==3)
				{
					countFundo=0;
					if (countUp==0)
					{
						garden.PlayLooping();
					}
					
				}
				if (countUp==1)
				{
					imagemFundo = "espaço.gif";
					
				}
				else
				{
					imagemFundo = "fundo"+countFundo+".png";
					if (countFundo==1)
					{
						water.PlayLooping();
					}
					if (countFundo==2)
					{
						dungeon.PlayLooping();
					}
					
				}
				
			}
		}
		
		public void Esq()
		{
			Left -=speed;
			Load("kirbyvoavolta.gif");
			
			if (Left<0)
				Left = 0;
		}
		
		public void Cima()
		{
			Top -= speed;
			Load("kirbyvoa.gif");
			if (Top<0)
			{
				if (countUp==0)
				{
					countUp++;
					imagemFundo = "espaço.gif";
					space.Play();
					Top = 250;
				}
				else
				{
					Top = 0;
				}
			}
		}
		
		public void Baixo()
		{
			Top += speed;
			Load("kirbyvoa.gif");
			if (Top>alturaFundo-100)
			{
				if (countUp==1)
				{
					countUp=0;
					imagemFundo = "fundo"+countFundo+".png";
					Top = 0;
					if (countFundo==0)
					{
						garden.PlayLooping();
					}
					if (countFundo==1)
					{
						water.PlayLooping();
					}
					if(countFundo==2)
					{
						
						dungeon.PlayLooping();
					}
				}
				else
				{
					Top = alturaFundo-100;
				}
			}
		}
	}
}
