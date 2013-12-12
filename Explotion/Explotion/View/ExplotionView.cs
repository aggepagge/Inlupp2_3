using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Explotion.Model;
using Explotion.View;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;


namespace Explotion.View
{
    class ExplotionView
    {
        internal ExplotionModel m_particleModel;
        internal Camera camera;
        internal GraphicsDevice graphDevice;
        internal SpriteBatch spriteBatch;
        internal Animation explotion;

        //Konstruktor som initsierar objektet
        internal ExplotionView(GraphicsDevice graphDevice, ExplotionModel particleModel, Camera camera, SpriteBatch spriteBatch)
        {
            this.graphDevice = graphDevice;
            this.m_particleModel = particleModel;
            this.camera = camera;
            this.spriteBatch = spriteBatch;

            explotion = new Animation(m_particleModel.Level.StartPossition, camera.GetScale());
        }

        //Metod som startar om animeringen
        internal void restart(ContentManager contentManager)
        {
            explotion = new Animation(m_particleModel.Level.StartPossition, camera.GetScale());
        }

        //Uppdaterar explotionen med förfluten tid
        internal void UpdateView(float elapsedGameTime)
        {
            explotion.Update(elapsedGameTime);
        }

        //Anropar spritbatchen för utritning samt explotionens Draw-funktion
        internal void Draw(float elapsedGameTime, Texture2D texture)
        {
            graphDevice.Clear(Color.White);
            spriteBatch.Begin(SpriteSortMode.BackToFront, BlendState.AlphaBlend);

            explotion.Draw(spriteBatch, camera, texture);

            spriteBatch.End();
        }
    }
}
