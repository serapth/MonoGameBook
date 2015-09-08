// Display positional audio

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Audio;

namespace Example3
{
    public class Game1 : Game
    {
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;
        SoundEffect soundEffect;
        SoundEffectInstance instance;
        AudioListener listener;
        AudioEmitter emitter;


        public Game1()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
        }

        protected override void Initialize()
        {
            base.Initialize();
        }

        protected override void LoadContent()
        {
            spriteBatch = new SpriteBatch(GraphicsDevice);
            
            soundEffect = this.Content.Load<SoundEffect>("circus");
            instance = soundEffect.CreateInstance();
            instance.IsLooped = true;

            listener = new AudioListener();
            emitter = new AudioEmitter();

            // WARNING!!!!  Apply3D requires sound effect be Mono!  Stereo will throw exception
            instance.Apply3D(listener, emitter);
            instance.Play();
        }

        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            if (Keyboard.GetState().IsKeyDown(Keys.Left))
            {
                listener.Position = new Vector3(listener.Position.X-0.1f, listener.Position.Y, listener.Position.Z);
                instance.Apply3D(listener, emitter);
            }
            if (Keyboard.GetState().IsKeyDown(Keys.Right))
            {
                listener.Position = new Vector3(listener.Position.X + 0.1f, listener.Position.Y, listener.Position.Z);
                instance.Apply3D(listener, emitter);
            }

            if (Keyboard.GetState().IsKeyDown(Keys.Up))
            {
                listener.Position = new Vector3(listener.Position.X, listener.Position.Y +0.1f, listener.Position.Z);
                instance.Apply3D(listener, emitter);
            }
            if (Keyboard.GetState().IsKeyDown(Keys.Down))
            {
                listener.Position = new Vector3(listener.Position.X, listener.Position.Y -0.1f, listener.Position.Z);
                instance.Apply3D(listener, emitter);
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
