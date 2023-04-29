
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Runtime.Remoting.Channels;
using System.Windows.Forms;
using System.Media;
using System.Windows.Forms.VisualStyles;

namespace Tabuleiro
{
	public partial class MainForm : Form
	{
		public MainForm()
		{
			InitializeComponent();
			title.PlayLooping();
		}
		
		Random rnd = new Random();
		public Heroi heroi = new Heroi();
        public PictureBox fundo= new PictureBox();
        public Recompensa tomato = new Recompensa();
        
        public SoundPlayer title = new SoundPlayer("titulo.wav");
        
        Timer criar_inimigo = new Timer();
        Timer colisoes = new Timer();
        
        Label lblHp = new Label();
        Label lblEscudo = new Label();
        Label lblDano = new Label();
        Label lblXp = new Label();
        Label lblNivel = new Label();
        Label lblSpeed = new Label();
        
        void Button1Click(object sender, EventArgs e)
        {
            button1.Visible=false;
            button1.Enabled = false;
            
            button2.Visible = false;
            button2.Enabled = false;
            this.KeyPreview = true;
            
            title.Stop();
            
            string[] textos = {"HP: "+heroi.hp, "DEF: "+heroi.escudo, "POW: "+heroi.dano, "EXP: "+heroi.xp, "LV: "
            				   +heroi.lv, "SPD: "+heroi.speed};
            Label[] lbl = {lblHp, lblEscudo, lblDano, lblXp, lblNivel, lblSpeed};
            for(int i = 0; i<6; i++)
            {
            	lbl[i].Parent = this;
            	lbl[i].AutoSize = true;
            	lbl[i].Text = textos[i];
            	lbl[i].Top = 390;
            	lbl[i].Left = 20 + i*90;
            	lbl[i].BringToFront();
            	lbl[i].BackColor = Color.Moccasin;
            	lbl[i].Font = new Font("Ink free", 12);
            }
            heroi.garden.Play();

            fundo.Parent = this;
            fundo.SizeMode= PictureBoxSizeMode.StretchImage;
            fundo.Width= this.Width;
            fundo.Height= this.Height-100;
            fundo.Load("fundo0.png");
            fundo.Tag = "fundo0.png";
            Colide.heroi = heroi;
            tomato.hero = heroi;
                        
            heroi.alturaFundo = fundo.Height;
            heroi.larguraFundo= fundo.Width;
            heroi.Parent= fundo;
            heroi.Disposed += HeroiDisposed;
            
            tomato.Parent = fundo;
            tomato.Enabled = false;
            tomato.Visible = false;
            tomato.timerT.Enabled = false;
            
            
            
            CriarInimigo();
            
            criar_inimigo.Interval = 1;
            criar_inimigo.Tick += Timer_GerarInimigoAleatorio;
            
            colisoes.Interval = 1;
            colisoes.Tick += Timer_Colisoes;
            
            ChaveTimers(true);
            
        }
        void MainFormKeyDown(object sender, KeyEventArgs e)
        {
        	e.Handled = e.SuppressKeyPress = true;
        	if (!heroi.IsDisposed)
        	{
        		if(e.KeyCode == Keys.A) heroi.Esq();
            	if(e.KeyCode == Keys.D) heroi.Dir();
            	if(e.KeyCode == Keys.W) heroi.Cima();
            	if(e.KeyCode == Keys.S) heroi.Baixo();
            	if(e.KeyCode == Keys.Space)
            	{
            		if(Listas.ListaTiro.Items.Count<6)
            		{
            			Atirar();
            		}
            	}
            	
            	if (heroi.imagemFundo != fundo.Tag.ToString())
            	{
            		fundo.Tag = heroi.imagemFundo;
            		fundo.Load(heroi.imagemFundo);
            		CriarInimigo();     		
            	}
            	
            	if(heroi.countFundo == 2 && heroi.countUp != 1)
            	{
            		tomato.Enabled = true;
            		tomato.Visible = true;
            		tomato.timerT.Enabled = true;           		
            	}
            	else
            	{
            		tomato.Enabled = false;
            		tomato.Visible = false;
            		tomato.timerT.Enabled = false;  
            	}
            	
        	}
            
           
        }
        
        void CriarInimigo()
        {
        	Inimigo inimigo = new Inimigo(fundo.Width, fundo.Height);
        	inimigo.Parent = fundo;
        	Listas.AddItem(inimigo);
        }
        
        void Atirar()
        {
        	Tiro tiro = new Tiro(heroi.Left, heroi.Top);
        	tiro.Parent = fundo;
        	tiro.fundoWidth = fundo.Width;
        	Listas.AddItem(tiro);
        }
        
        void ChaveTimers(bool ligaDesliga)
        {
        	colisoes.Enabled = ligaDesliga;
        	criar_inimigo.Enabled = ligaDesliga;
        }
        
        void Timer_GerarInimigoAleatorio(object sender, EventArgs e)
        {
        	if (rnd.Next(0,401) < 2) CriarInimigo();
        	this.Text = "número de inimigos na lista: " +Listas.ListaInimigo.Items.Count + " e tiros: " + 
        				Listas.ListaTiro.Items.Count;
        }
        
        void Timer_Colisoes(object sender, EventArgs e)
        {
        	AtualizaLabels();
        }
        
        void AtualizaLabels()
        {
        	Label[] lbl = {lblHp, lblEscudo, lblDano, lblXp, lblNivel, lblSpeed};
        	string[] textos = {"HP: "+heroi.hp, "DEF: "+heroi.escudo, "POW: "+heroi.dano, "EXP: "+heroi.xp, "LV: "
        						+heroi.lv, "SPD: "+heroi.speed};
        	for (int i = 0;i<6;i++)
        	{
        		lbl[i].Text = textos[i];
        	}
        }
        
        void HeroiDisposed(object sender, EventArgs e)
        {
        	
        	ChaveTimers(false);
        	
        	
        	if (heroi.IsDisposed)
        	{
        		for (int i=0;i<Listas.ListaInimigo.Items.Count;i++)
        		{
        			Inimigo inimigo = (Inimigo) Listas.ListaInimigo.Items[i];
        			inimigo.Dispose();
        		}
        		
        	
        	}
        	var fim = new FormGameOver();
        	fim.ShowDialog();
        	Application.Restart();
        	
        }
		void Button2Click(object sender, EventArgs e)
		{
			var story = new FormStory();
			story.ShowDialog();
			
		}
   
	}
}
