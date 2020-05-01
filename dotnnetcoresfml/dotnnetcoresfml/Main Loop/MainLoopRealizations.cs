using System;
using System.Collections.Generic;
using System.Linq;
using dotnnetcoresfml.Entities;
using SFML.Graphics;
using SFML.Window;
using SFML.System;
using System.Threading.Tasks;

namespace dotnnetcoresfml.Main_Loop
{
   enum Direction
    {
        Up,Down,Left,Right,UpRight,LeftRight,LeftDown,RightDown
    }
   partial class MainLoop
    {
        private Entity HeroHandler;
        private void draw()
        {
            foreach (Entity item in entities)
            {
                window.Draw(item.Sprite); 
            }
        }
        private void Init()
        {
            for (int i = 0; i < MainVars.VISIBILITY_DISTANCE; i++)
            {
                for (int j = 0; j < MainVars.VISIBILITY_DISTANCE; j++)
                {
                    Entity chunk = new Entity(new Texture(@"C:\Users\vklap\Source\Repos\ChunkGen\dotnnetcoresfml\dotnnetcoresfml\Res\Chunk.png"));
                    chunk.Position = new Vector2f(i * MainVars.CHUNK_SIZE, j * MainVars.CHUNK_SIZE);
                    EntityList.Add(chunk);
                }
            }
        }
        private void Window_KeyPressed(object sender, KeyEventArgs e)
        {
            switch (e.Code)
            {

                case Keyboard.Key.A:
                    {

                        break;
                    }
                case Keyboard.Key.D:
                    {

                        break;
                    }
                case Keyboard.Key.S:
                    {

                        break;
                    }
                case Keyboard.Key.W:
                    {

                        break;
                    }

                default:
                    break;
            }
        }
        private void LoadChunks(Direction dir)
        {
            FindHeroChunkOwner();
        }
        private async Task FindHeroChunkOwner()
        {
            await Task.Run(() =>
            {
                foreach (Entity item in EntityList)
                {
                    if((Hero.X - item.X <= 16)&& (Hero.Y - item.Y <= 16))
                    {
                        HeroHandler = item.Clone() as Entity;
                        Console.WriteLine("found");
                        break;
                    }
                }
            });
        }
    }
   
}
