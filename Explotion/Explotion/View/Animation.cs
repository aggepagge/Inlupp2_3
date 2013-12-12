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
        //Vector för possition av explotionen
        private Vector2 possition;
        //Storleken i logisk skala (1.0-skala)
        private float size = 0.5f;

        //Aktuell ruta i X-led
        private int frameX = 1;
        //Aktuell ruta i Y-led
        private int frameY = 1;
        //Totalt antal rutor på spriten
        private static int numberOfFrames = 32;
        //Antal rutor i X-led
        private static int numFramesX = 4;
        //Antal rutor i Y-led
        private static int numFramesY = 8;

        //Totala tiden explotionen ska visas
        private static float MAX_TIME = 0.5f;
        //Tiden varje bild ska visas
        private float imageTime;
        //Aktuell bildruta
        private int imageCount = 1;
        //Variabel för den förflutna tiden
        private float time = 0;

        internal Animation(Vector2 startPossition, int scale)
        {
            //Initsierar possitionen
            this.possition = new Vector2(startPossition.X, startPossition.Y);
            //Räknar ut tiden för varje bildruta genom att dela den totala tiden med antalet bildrutor
            imageTime = MAX_TIME / numberOfFrames;

            //Initsierar första rutan
            updateSprite();
        }

        //Uppdaterar explotionen
        internal void Update(float elapsedGameTime)
        {
            time += elapsedGameTime;

            //Om time är större än visningstid för en bildruta så visas nästa bild 
            //och time sätts till noll igen för uppräkning av nästa bildruta
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

                //Uppdaterar bildrutan
                updateSprite();
            }
        }

        //Räkar ut vilken ruta i X-led och Y-led som ska visas
        private void updateSprite()
        {
            int countRowX = 1;

            while ((countRowX * numFramesX) < imageCount)
                countRowX++;

            frameX = numFramesX - ((countRowX * numFramesX) - imageCount);
            frameY = countRowX;
        }

        //Ritar ut explotionen med Draw-funktionen som tar två rektanglar som argument.
        //Den första rektangeln skapas genom kameraklass-objektet och sätts till rätt visuell
        //storlek.
        //Den andra rektangeln sätts till del av den första rektangeln (För att visa en del av spriten)
        internal void Draw(SpriteBatch spriteBatch, Camera camera, Texture2D texture)
        {
            //Yttre rektangel med startpossition (X och Y) samt logisk storlek.
            Rectangle frameRect = camera.getExplotionCoordinates(possition.X, possition.Y, size);

            int Xrow = 0;
            int Yrow = 0;

            int spriteWidth = (int)(texture.Width / numFramesX);
            int spriteHeight = (int)(texture.Height / numFramesY);

            //Sätter rätt bredd och höjd i pixlar för aktuell ruta
            if(frameY == 1)
                Yrow = 0;
            else if(frameY > 1)
                Yrow = (frameY - 1) * spriteHeight;

            if (frameX == 1)
                Xrow = 0;
            else if (frameX > 1)
                Xrow = (frameX - 1) * spriteWidth;

            //Skapar den inre rektangeln där spriten ritas ut
            Rectangle explotionRect = new Rectangle(Xrow, Yrow, spriteWidth, spriteHeight);

            spriteBatch.Draw(texture, frameRect, explotionRect, Color.White);
        }
    }
}
