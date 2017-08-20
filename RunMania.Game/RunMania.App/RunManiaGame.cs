using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace RunMania.App
{
    /// <summary>
    /// This is the main type for your game.
    /// </summary>
    public class RunManiaGame : Game
    {
        private readonly GraphicsDeviceManager _graphics;
        private SpriteBatch _spriteBatch;

        private Texture2D _sampleTexture;

        private Viewport _port1;

        private Viewport _port2;

        private readonly Matrix _pointScaleMatrix;
        private readonly Matrix _screenScaleMatrix;
        private readonly Matrix _pointReverseScaleMatrix;

        private readonly Matrix _player1Matrix;

        private readonly Matrix _player2Matrix;



        public RunManiaGame()
        {
            _graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            _graphics.IsFullScreen = true;
            _graphics.SupportedOrientations = DisplayOrientation.LandscapeLeft | DisplayOrientation.LandscapeRight;
            _screenScaleMatrix = Matrix.CreateScale(Window.ClientBounds.Width / 801.0f, Window.ClientBounds.Height / 480.0f,
                0f);

            _pointScaleMatrix = Matrix.CreateScale(800 / (float)Window.ClientBounds.Width,
                480 / (float)Window.ClientBounds.Height, 0f);

            _pointReverseScaleMatrix = Matrix.CreateScale( (float)Window.ClientBounds.Width/ 800,
                (float)Window.ClientBounds.Height / 480, 0f);

            _graphics.PreferredBackBufferWidth = 800;
            _graphics.PreferredBackBufferHeight = 480;
        }

        protected override void Initialize()
        {
            base.Initialize();
        }
        
        protected override void LoadContent()
        {
            _spriteBatch = new SpriteBatch(GraphicsDevice);

            _sampleTexture = this.Content.Load<Texture2D>("sprites/tile");


            var rectangle = new Rectangle(0,0,(int)(400*_pointReverseScaleMatrix.Scale.X), (int)(480 *_pointReverseScaleMatrix.Scale.Y));
            var rectangle2 = new Rectangle((int)(400 * _pointReverseScaleMatrix.Scale.X), 0, (int)(400 * _pointReverseScaleMatrix.Scale.X), (int)(480 * _pointReverseScaleMatrix.Scale.Y));


            _port1 = new Viewport(rectangle);
            _port2 = new Viewport(rectangle2);
        }

        protected override void UnloadContent()
        {

        }

        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed)
                Exit();

            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);
            var original = GraphicsDevice.Viewport;

            GraphicsDevice.Viewport = _port1;

            _spriteBatch.Begin(SpriteSortMode.Deferred,null,SamplerState.PointClamp,transformMatrix:_screenScaleMatrix);

            _spriteBatch.Draw(_sampleTexture, Vector2.Zero, Color.White);
            _spriteBatch.Draw(_sampleTexture, new Vector2(336,0), Color.White);
            _spriteBatch.Draw(_sampleTexture, new Vector2(336,416), Color.White);
            _spriteBatch.Draw(_sampleTexture, new Vector2(0,416), Color.White);

            _spriteBatch.End();


            GraphicsDevice.Viewport = _port2;

            _spriteBatch.Begin(SpriteSortMode.Deferred, null, SamplerState.PointClamp, transformMatrix: _screenScaleMatrix);


            _spriteBatch.Draw(_sampleTexture, Vector2.Zero, Color.White);
            _spriteBatch.Draw(_sampleTexture, new Vector2(336, 0), Color.White);
            _spriteBatch.Draw(_sampleTexture, new Vector2(336, 416), Color.White);
            _spriteBatch.Draw(_sampleTexture, new Vector2(0, 416), Color.White);

            _spriteBatch.End();

            GraphicsDevice.Viewport = original;

            base.Draw(gameTime);
        }
    }
}
