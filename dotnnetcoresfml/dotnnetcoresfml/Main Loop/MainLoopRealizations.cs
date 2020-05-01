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
        Up,Down,Left,Right
    }
   partial class MainLoop
    {
        private Entity HeroHandler;
        private void draw()
        {
            for (int i = 0; i < EntityList.Count; i++)
            {
                window.Draw(EntityList[i].Sprite);
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
            FindHeroChunkOwner();
            switch (e.Code)
            {
                case Keyboard.Key.A:
                    {
                        CurrentFrame += 0.02f * time;
                        if (CurrentFrame > 3) CurrentFrame -= 3;
                        Console.WriteLine("A");
                        LoadChunks(Direction.Left);
                        hero.Sprite.Position = new Vector2f(hero.X + -0.2f * time, hero.Y);
                        break;
                    }
                case Keyboard.Key.D:
                    {
                        CurrentFrame += 0.02f * time;
                        if (CurrentFrame > 3) CurrentFrame -= 3;
                        hero.Sprite.Position = new Vector2f(hero.X- -0.3f * time, hero.Y);
                      //  Console.WriteLine("D");
                        LoadChunks(Direction.Right);
                        break;
                    }
                case Keyboard.Key.S:
                    {
                        CurrentFrame += 0.02f * time;
                        if (CurrentFrame > 3) CurrentFrame -= 3;
                        Console.WriteLine("S");
                        LoadChunks(Direction.Down);
                        hero.Sprite.Position = new Vector2f(hero.X, hero.Y - -0.2f * time);
                        break;
                    }
                case Keyboard.Key.W:
                    {
                        CurrentFrame += 0.02f * time;
                        if (CurrentFrame > 3) CurrentFrame -= 3;
                        Console.WriteLine("W");
                        LoadChunks(Direction.Up);
                        hero.Sprite.Position = new Vector2f(hero.X,hero.Y+ -0.2f * time);
                        break;
                    }
      
                default:
                    break;
            }
        }
        int NormalizeToChunkSize(int pos)
        {
            int k = pos % MainVars.CHUNK_SIZE;
            pos += (MainVars.CHUNK_SIZE - k);
            return pos;
        }
        private void LoadChunks(Direction dir)
        {
            int nextlinepos = 0, FurthestRectI = 0;
            float smallestY = hero.Y;
            for (int i = 1; i < EntityList.Count; i++)
            {
                if (EntityList[i].Y < smallestY) smallestY = EntityList[i].Y;
                if (EntityList[i].Position.X - Hero.Position.X >
                 EntityList[i - 1].Position.X - Hero.Position.X)
                    FurthestRectI = i;
            }
            nextlinepos = NormalizeToChunkSize((int)EntityList[FurthestRectI].X);
            if (EntityList[FurthestRectI].Position.X - Hero.Position.X < MainVars.CHUNK_SIZE * MainVars.VISIBILITY_DISTANCE)
            for (int i = 0; i < MainVars.VISIBILITY_DISTANCE; i++)
            {
                    Entity newchunk = new Entity(@"C:\Users\vklap\Source\Repos\ChunkGen\dotnnetcoresfml\dotnnetcoresfml\Res\Chunk.png");
                    newchunk.Position = new Vector2f(nextlinepos, smallestY + (MainVars.CHUNK_SIZE * i));
                    EntityList.Add(newchunk);
            }
        }
        private async Task FindHeroChunkOwner()
        {
           await Task.Run(delegate { 
                foreach (Entity item in EntityList)
                {
                    if((Hero.X - item.X <= MainVars.CHUNK_SIZE)&& (Hero.Y - item.Y <= MainVars.CHUNK_SIZE))
                    {
                        HeroHandler = item.Clone() as Entity;
                      //  Console.WriteLine("found");
                        break;
                    }
               }
           }) ;
        }
    }
   
}
