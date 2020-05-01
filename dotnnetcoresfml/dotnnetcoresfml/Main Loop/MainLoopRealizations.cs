using System;
using System.Collections.Generic;
using System.Text;
using dotnnetcoresfml.Entities;
using SFML.Window;
namespace dotnnetcoresfml.Main_Loop
{
   partial class MainLoop
    {
        private void Draw()
        {
            foreach (Entity item in entities)
            {
                window.Draw(item.Sprite); 
            }
        }
    }
}
