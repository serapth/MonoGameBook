using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System.Text;

namespace Example1
{
    public class Game1 : Game
    {
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;
        Vector2 position;
        Texture2D texture;
        KeyboardState previousState;

        public Game1()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
        }

        protected override void Initialize()
        {
            base.Initialize();
            position = new Vector2(graphics.GraphicsDevice.Viewport.Width / 2 -64, 
                                    graphics.GraphicsDevice.Viewport.Height / 2 -64);

            previousState = Keyboard.GetState();
        }

        protected override void LoadContent()
        {
            spriteBatch = new SpriteBatch(GraphicsDevice);
            texture = this.Content.Load<Texture2D>("logo128");
        }

        protected override void Update(GameTime gameTime)
        {
            KeyboardState state = Keyboard.GetState();
            
            // If they hit esc, exit
            if (state.IsKeyDown(Keys.Escape))
                Exit();

            // Move our sprite based on arrow keys being pressed:
            if (state.IsKeyDown(Keys.Right) & !previousState.IsKeyDown(Keys.Right))
                position.X += 10;
            if (state.IsKeyDown(Keys.Left) & !previousState.IsKeyDown(Keys.Left))
                position.X -= 10;
            if (state.IsKeyDown(Keys.Up))
                position.Y -= 10;
            if (state.IsKeyDown(Keys.Down))
                position.Y += 10;

            base.Update(gameTime);

            previousState = state;
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            spriteBatch.Begin();
            spriteBatch.Draw(texture, position);
            spriteBatch.End();
            base.Draw(gameTime);
        }
    }
}
