using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System.Text;

namespace Example2
{
    public class Game1 : Game
    {
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;
        Vector2 position;
        Texture2D texture;

        public Game1()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
        }

        protected override void Initialize()
        {
            base.Initialize();
            position = new Vector2(graphics.GraphicsDevice.Viewport.Width / 2 ,
                                    graphics.GraphicsDevice.Viewport.Height / 2 );
            IsMouseVisible = true;
        }

        protected override void LoadContent()
        {
            spriteBatch = new SpriteBatch(GraphicsDevice);
            texture = this.Content.Load<Texture2D>("logo128");
        }

        protected override void Update(GameTime gameTime)
        {
            MouseState state = Mouse.GetState();

            // Update our sprites position to the current cursor location
            position.X = state.X;
            position.Y = state.Y;

            // Check if Right Mouse Button pressed, if so, exit
            if (state.RightButton == ButtonState.Pressed)
                Exit();

            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            spriteBatch.Begin();
            spriteBatch.Draw(texture, position, origin:new Vector2(64,64));
            spriteBatch.End();
            base.Draw(gameTime);
        }
    }
}
