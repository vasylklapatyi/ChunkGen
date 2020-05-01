using SFML.Graphics;
using System;
using System.Collections.Generic;
using System.Text;
using SFML.System;
using SFML.Window;

namespace dotnnetcoresfml.Entities
{
    class Entity:ICloneable
    {
		public Vector2f Position
		{
			get { return Sprite.Position; }
			set { Sprite.Position = value; }
		}

		private Sprite entitysprite;
		public Sprite Sprite
		{
			get { return entitysprite; }
			set { entitysprite = value; }
		}
		public float X
		{
			get { return entitysprite.Position.X; }
			set { entitysprite.Position = new Vector2f(value, entitysprite.Position.Y);}
		}
		public float Y
		{
			get { return entitysprite.Position.Y; }
			set { entitysprite.Position = new Vector2f(entitysprite.Position.X, value);}
		}
		private string texturepath = @"C:\Users\vklap\source\repos\dotnnetcoresfml\dotnnetcoresfml\Res\Empty.png";
		private Texture herotexture;
		public Texture Texture
		{
			get { return herotexture; }
			set { herotexture = value; }
		}
		public Entity(Texture texture,float x=0,float y=0)
		{
			this.Sprite = new Sprite();
			Sprite.Texture = texture;
			Sprite.Position = new Vector2f(x, y);
		}
		public Entity(string filename,float x=0,float y=0)
		{
			texturepath = filename;
			this.Sprite = new Sprite();
			Texture t = new Texture(filename);
			Sprite.Texture = t;
			Sprite.Position = new Vector2f(x, y);
		}
		public Entity()
		{}
		public object Clone()
		{
			Entity entity = new Entity(this.texturepath);
			entity.herotexture = new Texture(entity.texturepath);
			entity.entitysprite = new Sprite(entity.Texture);
			entity.Position = new Vector2f(this.X, this.Y);
			
			return entity;
		}
	}
}
