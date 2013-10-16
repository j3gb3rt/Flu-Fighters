using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Storage;
using Microsoft.Xna.Framework.GamerServices;

namespace Flu_Fighters
{
    
    class Heart
    {
        /*The beat interval is how often it switches between on beats and off beats. If you need the heart to beat slower
         edit the interval, NOT the two increments. If you need the ratio between the speed of off an on beats, THEN
         edit the on and off beat increments.*/
        public static float beatInterval = 1;
        public static float onBeatIncrement = 0.05f;
        public static float offBeatIncrement = 0.008f;
        public static bool onBeat = true;
        public static float timer = 0;
        public static int health = 10;
        public static int score = 0;

        

        /*an update call increments the timer by the appropriate value if it's on or offbeat, and if the timer
         becomes greater than the beat interval than the on beat state flips and the timer gets reset to zero*/
        static public void update()
        {
            if(onBeat)
                timer += onBeatIncrement;
            else
                timer += offBeatIncrement;

            if (timer >= beatInterval)
            {
                if (onBeat == true)
                {
                    timer = 0; 
                    onBeat = false;
                }
                else
                {
                    timer = 0;
                    onBeat = true;
                }
            }
            if (health <= 0)
            {
                
            }
            

        }

        public static void draw(SpriteBatch sb)
        {
            
            
        }

    }
}
