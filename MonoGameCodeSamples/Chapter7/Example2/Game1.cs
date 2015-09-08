// Example showing playing sound effects using the simplified audio api
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Audio;
using System.Collections.Generic;

namespace Example2
{
    public class Game1 : Game
    {
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;
        List<SoundEffect> soundEffects;

        public Game1()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            soundEffects = new List<SoundEffect>();
        }

        protected override void Initialize()
        {
            base.Initialize();
        }

        protected override void LoadContent()
        {
            // Create a new SpriteBatch, which can be used to draw textures.
            spriteBatch = new SpriteBatch(GraphicsDevice);

            soundEffects.Add(Content.Load<SoundEffect>("airlockclose"));
            soundEffects.Add(Content.Load<SoundEffect>("ak47"));
            soundEffects.Add(Content.Load<SoundEffect>("icecream"));
            soundEffects.Add(Content.Load<SoundEffect>("sneeze"));

            // Fire and forget play
            soundEffects[0].Play();
            
            // Play that can be manipulated after the fact
            var instance = soundEffects[0].CreateInstance();
            instance.IsLooped = true;
            instance.Play();
        }


        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            if (Keyboard.GetState().IsKeyDown(Keys.D1))
                soundEffects[0].CreateInstance().Play();
            if (Keyboard.GetState().IsKeyDown(Keys.D2))
                soundEffects[1].CreateInstance().Play();
            if (Keyboard.GetState().IsKeyDown(Keys.D3))
                soundEffects[2].CreateInstance().Play();
            if (Keyboard.GetState().IsKeyDown(Keys.D4))
                soundEffects[3].CreateInstance().Play();


            if (Keyboard.GetState().IsKeyDown(Keys.Space))
            {
                if (SoundEffect.MasterVolume == 0.0f)
                    SoundEffect.MasterVolume = 1.0f;
                else
                    SoundEffect.MasterVolume = 0.0f;
            }
            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            base.Draw(gameTime);
        }
    }
}
