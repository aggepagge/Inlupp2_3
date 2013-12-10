using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using Explotion.Controller;

namespace Explotion.View
{
    class Camera
    {
        private int screenWidth;
        private int screenHeight;

        private float scaleX;
        private float scaleY;

        private float widthMargin = 0;
        private float heightMargin = 0;

        internal Camera(Viewport viewPort)
        {
            this.screenWidth = viewPort.Width;
            this.screenHeight = viewPort.Height;

            this.scaleX = (float)screenWidth / XNAController.boardLogicWidth;
            this.scaleY = (float)screenHeight / XNAController.boardLogicHeight;

            if (scaleY < scaleX)
            {
                widthMargin = (screenWidth - screenHeight) / 2;
                scaleX = scaleY;
            }
            else if (scaleY > scaleX)
            {
                heightMargin = (screenHeight - screenWidth) / 2;
                scaleY = scaleX;
            }
        }

        internal Rectangle getExplotionCoordinates(float modelX, float modelY, float modelDimention)
        {
            return new Rectangle(
                                    (int)((modelX * scaleX) + (int)(widthMargin)) - (int)((modelDimention * scaleX) / 2),
                                    (int)((modelY * scaleY) + (int)(heightMargin)) - (int)((modelDimention * scaleX) / 2),
                                    (int)(modelDimention * scaleX),
                                    (int)(modelDimention * scaleY)
                                );
        }

        internal Rectangle getExplotionInnerRect(float numFramesX, float numFramesY, int frameX,
                int frameY, int outerRectDimentionX, int outerRectDimentionY, Rectangle outerRect)
        {
            return new Rectangle(
                                    (int)(frameX * outerRectDimentionX),
                                    (int)(frameY * outerRectDimentionY),
                                    outerRectDimentionX,
                                    outerRectDimentionY
                                );
        }

        internal int GetScale()
        {
            return (int)scaleX;
        }

        internal float GetDimention()
        {
            return scaleX;
        }
    }
}
