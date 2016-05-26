using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace radicalgame
{
    /// <summary>
    /// This is the main type for your game.
    /// </summary>
    public class RadGame : Game
    {
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;

        public UserInputState InputState { get; set; }
        Texture2D blank;
        Camera2D viewCamera;
        Player testPlayer;

        public RadGame()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
        }

        /// <summary>
        /// Allows the game to perform any initialization it needs to before starting to run.
        /// This is where it can query for any required services and load any non-graphic
        /// related content.  Calling base.Initialize will enumerate through any components
        /// and initialize them as well.
        /// </summary>
        protected override void Initialize()
        {
            // initialization
            blank = new Texture2D(GraphicsDevice, 1, 1);
            blank.SetData(new Color[] { Color.White });

            viewCamera = new Camera2D(new Rectangle(0, 0, GraphicsDevice.PresentationParameters.BackBufferWidth, GraphicsDevice.PresentationParameters.BackBufferHeight));
            viewCamera.Position = new Vector2(0.0f, 0.0f);

            testPlayer = new Player(this, blank, Vector2.Zero);

            IsMouseVisible = true;

            InputState = new UserInputState();

            base.Initialize();
        }

        /// <summary>
        /// LoadContent will be called once per game and is the place to load
        /// all of your content.
        /// </summary>
        protected override void LoadContent()
        {
            // Create a new SpriteBatch, which can be used to draw textures.
            spriteBatch = new SpriteBatch(GraphicsDevice);

            // TODO: use this.Content to load your game content here
        }

        /// <summary>
        /// UnloadContent will be called once per game and is the place to unload
        /// game-specific content.
        /// </summary>
        protected override void UnloadContent()
        {
            // TODO: Unload any non ContentManager content here
        }

        /// <summary>
        /// Allows the game to run logic such as updating the world,
        /// checking for collisions, gathering input, and playing audio.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            // update input
            InputState.CurrentKS = Keyboard.GetState();

            // game update logic
            testPlayer.Update();

            viewCamera.Position = testPlayer.Center;

            // store the input state for the next iteration
            InputState.OldKS = InputState.CurrentKS;

            base.Update(gameTime);
        }

        /// <summary>
        /// This is called when the game should draw itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            // Draw the game
            spriteBatch.Begin(SpriteSortMode.Deferred, null, null, null, null, null, viewCamera.viewMatrix);

            spriteBatch.Draw(blank, new Rectangle(-50, -50, 30, 30), Color.White);
            spriteBatch.Draw(blank, new Rectangle(130, 30, 30, 30), Color.White);
            spriteBatch.Draw(blank, new Rectangle(70, 70, 30, 30), Color.White);

            testPlayer.Draw(spriteBatch);

            spriteBatch.End();

            base.Draw(gameTime);
        }
    }
}
