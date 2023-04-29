
using System;

namespace Tabuleiro
{
	/// <summary>
	/// Description of Colide.
	/// </summary>
	public static class Colide
	{
		static Colide()
		{
			
		}
		public static Heroi heroi;
		
		public static bool TesteColisao (Inimigo inimigo)
		{
			bool retorno = false;
			if (inimigo.Bounds.IntersectsWith(heroi.Bounds))
			{
				heroi.LevouDano(inimigo.dano);
				
				if (heroi.hp <= 0)
				{
					Explosao.DestroiItem(heroi);
				}
				retorno = true;
			}
			return retorno;
				
		}
		public static bool TesteColisao (Tiro tiro)
		{
			bool retorno = false;
			foreach (object ob in Listas.ListaInimigo.Items)
			{
				var inimigo = ob as Inimigo;
				if (inimigo.Bounds.IntersectsWith(tiro.Bounds))
				{
					Listas.RemoveItem(tiro);
					Listas.RemoveItem(inimigo);
					Explosao.DestroiItem(inimigo);
					inimigo.timerIn.Enabled = false;
					heroi.GanhaXP();
					retorno = true;
					break;
				}
			}
			return retorno;
		}
		
	}
}
