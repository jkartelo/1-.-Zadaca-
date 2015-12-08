using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PongGame
{
    public class Ball : Sprite
    {
        // Initial ball speed. Constant
        public const float InitialSpeed = 0.4f; // Defines a factor of speed increase when bumping on the paddle. 
        public const float BumpSpeedIncreaseFactor = 1.01f; // Defines ball size. Constant 
        public const int BallSize = 50; // Defines current ball speed in time. 
        public float Speed { get; set; }// Defines ball direction. 
        // Valid values (-1,-1), (1,1), (1,-1), (-1,1). 
        // Using Vector2 to simplify game calculation. Potentially 
        // dangerous because vector 2 can swallow other values as well. 
        // Think about creating your own, more suitable type. 
        public Vector2 Direction;
        public Ball(Texture2D spriteTexture)
            : base(spriteTexture, BallSize, BallSize)
        {
            Speed = InitialSpeed;
            // Initial direction 
            Direction = new Vector2(1, 1);
        }
    }
}
