using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Content;

namespace Explotion.View
{
    class Animation
    {
        //private Vector2 possition;
        //private float size = 0.1f;
        //private float timeElapsed = 0;
        //private static float MAX_TIME = 0.5f;
        //private static int numberOfFrames = 24;
        //private static int numFramesX = 4;
        //private static int numFramesY = 6;
        //private int frameX = 0;
        //private int frameY = 0;

        //internal Animation(Vector2 startPossition, int scale)
        //{
        //    this.possition = new Vector2(startPossition.X, startPossition.Y);
        //}

        //internal void Update(float elapsedGameTime)
        //{
        //    timeElapsed += elapsedGameTime;
        //    float percentAnimated = timeElapsed / MAX_TIME;
        //    int frame = (int)(percentAnimated * numberOfFrames);

        //    frameX = frame % numFramesX;
        //    frameY = frame / numFramesX;
        //}

        private Vector2 possition;
        private float size = 0.5f;

        private int frameX = 1;
        private int frameY = 1;
        private static int numberOfFrames = 32;
        private static int numFramesX = 4;
        private static int numFramesY = 8;

        private float percentHeight;
        private float precentWidth;

        private static float MAX_TIME = 6.5f;
        private float imageTime;
        private int imageCount = 1;
        private float time = 0;
        private Texture2D texture;

        internal Animation(Vector2 startPossition, int scale, ContentManager contentManager)
        {
            this.possition = new Vector2(startPossition.X, startPossition.Y);
            imageTime = MAX_TIME / numberOfFrames;

            texture = contentManager.Load<Texture2D>("explosion");

            //TODO: Räkna ut procentdel för spriten mot yttre panelen

            updateSprite();
        }

        private void setPercentCordinates()
        {

        }

        internal void Update(float elapsedGameTime)
        {
            time += elapsedGameTime;

            if (time > imageTime)
            {
                if (imageCount > numberOfFrames)
                {
                    imageCount = 0;
                }
                else
                {
                    imageCount++;
                    time = 0;
                }

                updateSprite();
            }
        }

        private void updateSprite()
        {
            int countRowX = 1;

            while ((countRowX * numFramesX) < imageCount)
                countRowX++;

            frameX = numFramesX - ((countRowX * numFramesX) - imageCount);
            frameY = countRowX;
        }

        internal void Draw(SpriteBatch spriteBatch, Camera camera)
        {
            Rectangle frameRect = camera.getExplotionCoordinates(possition.X, possition.Y, size);

            int Xrow = 0;
            int Yrow = 0;

            if(frameY == 1)
                Yrow = 0;
            else if(frameY > 1)
                Yrow = (frameY - 1) * frameRect.Height;

            if (frameX == 1)
                Xrow = 0;
            else if (frameX > 1)
                Xrow = (frameX - 1) * frameRect.Width;

            Rectangle explotionRect = new Rectangle(Xrow, Yrow, frameRect.Width / numFramesX, (frameRect.Height * 2) / numFramesY);

            spriteBatch.Draw(texture, frameRect, explotionRect, Color.White);
        }
    }
}
