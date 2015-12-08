using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PongGame
{
    public class CollisionDetector
    { /// <summary> /// Calculates if rectangles describing two sprites /// are overlapping on screen. /// </summary> /// <param name="s1">First sprite</param> /// <param name="s2">Second sprite</param> /// <returns>Returns true if overlapping</returns>
        public static bool Overlaps(Sprite s1, Sprite s2) 
        {
            if (s1 == s2)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
