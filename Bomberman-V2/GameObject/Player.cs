using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SplashKitSDK;

namespace Bomberman_V2
{
    public class Player : GameObject
    {
        private const int SPEED = 5;
        private int SIZE = 20;
        private int bombRadius = 2;
        private int bombCount = 1;
        private string _name;
        private int x;
        private int y;
        public int BombRadius { get { return bombRadius; } set { bombRadius = value; } }
        public int BombCount { get { return bombCount; } set { bombCount = value; } }
        public string Name { get { return _name; } }
        public int LastX { get; set; }
        public int LastY { get; set; }
        public Player(string name) : base(0,0)
        {
            _name = name;
            SetColor();
            Respawn();
            CommandProcessor.Instance().AddPlayer(this);
        }
        public void SetColor()
        {
            if (_name == "p1")
            {
                Color = SplashKit.ColorPurple();
            }
            else if (_name == "p2")
            {
                Color = SplashKit.ColorRed();
            }
        }
        public void Respawn()
        {
            if (_name == "p1")
            {
                x = 1 * Tile.TileSize;
                y = 1 * Tile.TileSize;
            }
            else if (_name == "p2")
            {
                x = 2 * Tile.TileSize;
                y = 1 * Tile.TileSize;
            }
        }
        public void StoreOldPosition()
        {
            LastX = X;
            LastY = Y;
        }
        public void MoveBack()
        {
            X = LastX;
            Y = LastY;
        }
        public override int RowIndex
        {
            get { return ((x + Tile.TileSize - 1) / Tile.TileSize) - 1; }
        }
        public override int ColIndex
        {
            get { return ((y + Tile.TileSize - 1) / Tile.TileSize) - 1; }
        }
        public override int X { get { return x; } set { x = value; } }
        public override int Y { get { return y; } set { y = value; } }
        public override int Size => SIZE;
        public int Speed => SPEED;
        public override void Draw()
        {
            SplashKit.FillRectangle(Color, X, Y, SIZE, SIZE);
        }
        public override void ResolveCollision(ICollidable collidable)
        {
            collidable.ResolveCollision(this);
        }
        //Reason not to have resolvecollision with tile because the player will unable to differentiate which tile is collidable or not.
    }
}
