﻿using SplashKitSDK;

namespace Bomberman_V2
{ //How do the game objects communicate with the map without linking to each other? I wanna seperate them out for low cohesion.
    public abstract class GameObject : IDrawable, ICollidable
    {
        private int x = 0;
        private int y = 0;
        public virtual void ResolveCollision(ICollidable collidable) { }
        //virtual methods: optional
        public virtual void ResolveCollision(Player player) { }
        public virtual void ResolveCollision(Bomb bomb) { }
        public virtual void ResolveCollision(Enemy enemy) { }
        public virtual Color Color  { get; set; }
        public virtual int RowIndex { get; }
        public virtual int ColIndex { get; }
        public virtual int X { get { return RowIndex * (int) Tile.TileSize; } set { x= value; } }
        public virtual int Y { get { return ColIndex * (int) Tile.TileSize; } set { y = value; } }
        public virtual double Size { get; }
        public GameObject(int RowIndex, int ColIndex)
        {
            this.RowIndex = RowIndex;
            this.ColIndex = ColIndex;
            Game.Instance().AddNewObject(this);
        }
        private bool IsCollidingWith(GameObject gameobject)
        {
            if (gameobject.X < X + Size &&
                gameobject.X + gameobject.Size > X &&
                gameobject.Y < Y + Size &&
                gameobject.Y + gameobject.Size > Y)
            {
                return true;
            }
            return false;
        }
        public virtual void Draw() { }
    }
}
