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
            else if (s1 is Rectangle && s2 is Circle)
            {
                Rectangle Rs1 = s1 as Rectangle;
                Circle Cs2 = s2 as Circle;
                return CheckCollision(Rs1, Cs2);
            }
            else if (s2 is Rectangle && s1 is Circle)
            {
                Rectangle Rs2 = s2 as Rectangle;
                Circle Cs1 = s1 as Circle;
                return CheckCollision(Rs2, Cs1);
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
            float s2X = Conversion.Instance().GetTileCornerCoordByPlayerCoord(s2.X);
            float s2Y = Conversion.Instance().GetTileCornerCoordByPlayerCoord(s2.Y);
            float s2Size = 2 * s2.Radius;
            if (s1.X < s2X + s2Size &&
                s1.X + s1.Width > s2X &&
                s1.Y < s2Y + s2Size &&
                s1.Y + s1.Height > s2Y)
            {
                return true;
            }
            return false;
            /*float circleDistanceX = (s2.X - s1.X);
            float circleDistanceY = (s2.Y - s1.Y);

            if (circleDistanceX > (s1.Width / 2 + s2.Radius)) { return false; }
            if (circleDistanceY> (s1.Height / 2 + s2.Radius)) { return false; }

            if (circleDistanceX <= (s1.Width / 2)) { return true; }
            if (circleDistanceY<= (s1.Height / 2)) { return true; }

            float cornerDistance_sq = (circleDistanceX - s1.Width / 2) * (circleDistanceX - s1.Width / 2) 
                                        + (circleDistanceY- s1.Height / 2) * (circleDistanceY - s1.Height / 2);

            return (cornerDistance_sq <= (s2.Radius * s2.Radius));*/
        }
    }
}
