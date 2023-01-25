using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using tilemap_generator.Class;

namespace tilemap_generator
{
    public class Game1 : Game
    {
        private GraphicsDeviceManager _graphics;
        private SpriteBatch _spriteBatch;

        #region variables
        //Overall Defines
        private int _targetTextureResolution = 64;

        //UI
        private Texture2D _texture_tileEmpty;
        private MapGenerator _mapGenerator;
        private Texture2D _texture_fullWhite;
        
        //Gameworld Textures
        private Texture2D _texture_ground;
        #endregion

        public Game1()
        {
            _graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            IsMouseVisible = true;
        }

        protected override void Initialize()
        {
            // TODO: Add your initialization logic here
            _graphics.PreferredBackBufferWidth = 1920;
            _graphics.PreferredBackBufferHeight = 1080;
            _graphics.ApplyChanges();
            IsMouseVisible = true;
            IsFixedTimeStep = true;
            TargetElapsedTime = TimeSpan.FromSeconds(1.0f / 30.0f);

            base.Initialize();
        }

        protected override void LoadContent()
        {
            _spriteBatch = new SpriteBatch(GraphicsDevice);

            _texture_tileEmpty = Content.Load<Texture2D>(@"Textures\UI\border_white");
            _mapGenerator = new MapGenerator(15, 15, new Tile(_texture_tileEmpty, 64, 0));

            _texture_fullWhite = Content.Load<Texture2D>(@"Textures\UI\full_white");
        }

        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            // TODO: Add your update logic here

            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);
            _spriteBatch.Begin();

            _mapGenerator.Draw(_spriteBatch, new Vector2(50, 50));

            drawUi(gameTime);

            _spriteBatch.End();
            base.Draw(gameTime);
        }

        private void drawUi(GameTime gameTime)
        {
            Vector2 _uiOriginVector = new Vector2(_graphics.PreferredBackBufferWidth/3*2, 0);
            _spriteBatch.Draw(_texture_fullWhite, new Rectangle((int)_uiOriginVector.X, (int)_uiOriginVector.Y, _graphics.PreferredBackBufferWidth/3, _graphics.PreferredBackBufferHeight), Color.White);
        }
    }
}