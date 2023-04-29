
using System;
using System.Windows.Forms;
namespace Tabuleiro
{

	public static class Listas
	{
		static Listas()
		{
			
		}
		
		public static ListBox ListaInimigo = new ListBox();
		public static ListBox ListaTiro = new ListBox();
		
		public static void AddItem(Inimigo inimigo)
		{
			ListaInimigo.Items.Add(inimigo);
		}
		public static void AddItem(Tiro tiro)
		{
			ListaTiro.Items.Add(tiro);
		}
		public static void RemoveItem(Inimigo inimigo)
		{
			ListaInimigo.Items.Remove(inimigo);
		}
		public static void RemoveItem(Tiro tiro)
		{
			ListaTiro.Items.Remove(tiro);
		}
		
		public static void KillThemAll()
		{
			for (int i=0; i<ListaInimigo.Items.Count; i++)
			{
				Inimigo inimigo = (Inimigo) ListaInimigo.Items[i];
				inimigo.Dispose();
				RemoveItem(inimigo);
				inimigo.timerIn.Enabled = false;
			}
		}
	}
}
