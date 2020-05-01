using dotnnetcoresfml.Entities;
using SFML.Graphics;
using SFML.Window;
using System;
using System.Collections.Generic;
using System.Text;

namespace dotnnetcoresfml.Main_Loop
{
	partial class MainLoop
    {
		private List<Entity> entities = new List<Entity>();
		public List<Entity> EntityList
		{
			get { return entities; }
			set { entities = value; }
		}
		private RenderWindow window;
		public RenderWindow Window
		{
			get { return window; }
			set { window = value; }
		}
		private Entity hero = new Entity(@"C:\Users\vklap\source\repos\dotnnetcoresfml\dotnnetcoresfml\Res\Player.png");
		public Entity Hero
		{
			get { return hero; }
			set { hero = value; }
		}
		public void StartLoop()
		{
			Init();
			window.KeyPressed += Window_KeyPressed;
			while (window.IsOpen)
			{
				window.DispatchEvents();
				window.Clear();
				draw();
				window.Draw(hero.Sprite);
				window.Display();
			}
		}



		public MainLoop(RenderWindow _window)
		{
			window = _window;
		}
		public MainLoop(uint width = 1000,uint height = 500, string header = "DotNetCoreSFML")
		{
			window = new RenderWindow(new VideoMode(width, height), header);
		}
	}
}
