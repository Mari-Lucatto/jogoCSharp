
using System;
using System.Media;
using System.Threading.Tasks;

namespace Tabuleiro
{
	/// <summary>
	/// Description of Explosao.
	/// </summary>
	public static class Explosao
	{
		public async static void DestroiItem(Heroi ob)
		{
			ob.Load("explosion.gif");
			SoundPlayer die = new SoundPlayer("death.wav");
			die.Play();
			await Task.Delay(300);
			ob.Dispose();
		}
		
		public async static void DestroiItem(Inimigo ob)
		{
			ob.Load("explosion.gif");
			await Task.Delay(300);
			ob.Dispose();
		}
	}
}
