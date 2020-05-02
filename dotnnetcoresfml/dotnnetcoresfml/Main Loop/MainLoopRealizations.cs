using System;
using System.Collections.Generic;
using System.Linq;
using dotnnetcoresfml.Entities;
using SFML.Graphics;
using SFML.Window;
using SFML.System;
using System.Threading.Tasks;
//юзати замість ліста дерево де ключ обєкта буде його значення якесь
//створити сет-дзеркало тільки з числами самими де ігрек буде ключ,а індекс значенням
//попробувати скоротити на основі видалення,якщо видалення здійснилось - додати рядок в протилежному напрямку
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
            //  FindHeroChunkOwner();
            int speed = 2;
            if (speed >= MainVars.CHUNK_SIZE) speed = MainVars.CHUNK_SIZE;
            switch (e.Code)
            {
                case Keyboard.Key.A:
                    {
                        CurrentFrame += 0.02f * time;
                        if (CurrentFrame > 3) CurrentFrame -= 3;
                        Console.WriteLine("A");
                        LoadChunks(Direction.Left);
                        hero.Sprite.Position = new Vector2f(hero.X - speed, hero.Y);
                        break;
                    }
                case Keyboard.Key.D:
                    {
                        LoadChunks(Direction.Right);
                        CurrentFrame += 0.01f * time;
                        if (CurrentFrame > 3) CurrentFrame -= 3;
                        hero.Sprite.Position = new Vector2f(hero.X+ speed, hero.Y);
                      //  Console.WriteLine("D");
                        break;
                    }
                case Keyboard.Key.S:
                    {
                        CurrentFrame += 0.02f * time;
                        if (CurrentFrame > 3) CurrentFrame -= 3;
                        Console.WriteLine("S");
                        LoadChunks(Direction.Down);
                        hero.Sprite.Position = new Vector2f(hero.X, hero.Y + speed);
                        break;
                    }
                case Keyboard.Key.W:
                    {
                        CurrentFrame += 0.02f * time;
                        if (CurrentFrame > 3) CurrentFrame -= 3;
                        Console.WriteLine("W");
                        LoadChunks(Direction.Up);
                        hero.Sprite.Position = new Vector2f(hero.X,hero.Y-speed);
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
            switch (dir)
            {
                case Direction.Up:
                    {

                        break;
                    }
                case Direction.Down:
                    {

                        break;
                    }
                case Direction.Left:
                    {
                        int s = EntityList.Count;
                        bool generate = false;
                        for (int i = 0; i < s; i++)
                        {
                            if (EntityList[i].X > (hero.X + (MainVars.CHUNK_SIZE * MainVars.VISIBILITY_DISTANCE)))
                            {
                                EntityList.RemoveAt(i);
                                s--;
                                generate = true;
                            }
                        }
                      if(generate)
                            AddVerticalLine((NormalizeToChunkSize((int)hero.X)-(MainVars.CHUNK_SIZE*MainVars.VISIBILITY_DISTANCE)-MainVars.CHUNK_SIZE), smallestY);
                        break;
                    }
                case Direction.Right:
                    {
                        int s = EntityList.Count;
                        for (int i = 0; i < s; i++)
                        {
                            if (EntityList[i].X < (hero.X - (MainVars.CHUNK_SIZE * MainVars.VISIBILITY_DISTANCE)))
                            {
                                EntityList.RemoveAt(i);
                                s--;
                            }
                        }
                        for (int i = 1; i < EntityList.Count; i++)
                        {
                            if (EntityList[i].Y < smallestY) smallestY = EntityList[i].Y;
                            if (EntityList[i].Position.X - Hero.Position.X >
                             EntityList[i - 1].Position.X - Hero.Position.X)
                                FurthestRectI = i;
                        }
                        nextlinepos = NormalizeToChunkSize((int)EntityList[FurthestRectI].X);
                        if (EntityList[FurthestRectI].Position.X - Hero.Position.X < MainVars.CHUNK_SIZE * MainVars.VISIBILITY_DISTANCE)
                            AddVerticalLine(nextlinepos, smallestY);
                        break;
                    }
                default:
                    break;
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
        private void AddVerticalLine(int pos,float smallestY)
        {
            for (int i = 0; i < MainVars.VISIBILITY_DISTANCE; i++)
            {
                Entity newchunk = new Entity(@"C:\Users\vklap\Source\Repos\ChunkGen\dotnnetcoresfml\dotnnetcoresfml\Res\Chunk.png");
                newchunk.Position = new Vector2f(pos, smallestY + (MainVars.CHUNK_SIZE * i));
                EntityList.Add(newchunk);
            }
        }
    }
   
}
