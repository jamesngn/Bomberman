using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bomberman_V3
{
    class CollisionChecker
    {
        private static CollisionChecker _instance;
        public static CollisionChecker Instance()
        {
            if (_instance == null)
                _instance = new CollisionChecker();
            return _instance;
        }
        public bool IsColliding(Shape s1, Shape s2)
        {
            if (s1 is Rectangle && s2 is Rectangle)
            {
                Rectangle Rs1 = s1 as Rectangle;
                Rectangle Rs2 = s2 as Rectangle;
                return CheckCollision(Rs1, Rs2);
            }
            else
            {
                Console.WriteLine("Invalid Shape for Collision Checker! ");
                return false;
            } 
        }
        private bool CheckCollision(Rectangle s1, Rectangle s2)
        {
            if (s1.X < s2.X + s2.Width  &&
                s1.X + s1.Width > s2.X  &&
                s1.Y < s2.Y + s2.Height &&
                s1.Y + s1.Height > s2.Y)
            {
                return true;
            }
            return false;
        }
        private bool CheckCollision(Rectangle s1, Circle s2)
        {
            //wait for research
            return false;
        }
    }
}
