using Game1.GUI;
using Game1.Model;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;
using System;
using System.Collections.Generic;

namespace Game1
{
    /// <summary>
    /// This is the main type for your game.
    /// </summary>
    public class Game1 : Game
    {
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;
        levelModel level = new levelModel();
        enemyModel enemy1;
        // towerModel tower;
        playerModel player;
        // waveModel wave;
        waveManagerModel waveManager;
        Toolbar toolbar;
        Button basicButton;
        Button speedButton;
        Button slowButton;
        Button bomberButton;

        public static GameWindow WindowObject;

        public Game1()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            //6graphics.IsFullScreen = true;

            graphics.PreferredBackBufferHeight = level.Height * 60;
            graphics.PreferredBackBufferWidth = level.Width * 60;

            graphics.ApplyChanges();
            IsMouseVisible = true;


        }

        /// <summary>
        /// Allows the game to perform any initialization it needs to before starting to run.
        /// This is where it can query for any required services and load any non-graphic
        /// related content.  Calling base.Initialize will enumerate through any components
        /// and initialize them as well.
        /// </summary>
        protected override void Initialize()
        {
            // TODO: Add your initialization logic here
            Game1.WindowObject = Window;
            Mouse.WindowHandle = Window.Handle;
            Window.Position = Window.Position + new Point(0, 1);
            Window.Position = Window.Position - new Point(0, 1);
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

            Texture2D grass = Content.Load<Texture2D>("grass");
            Texture2D path = Content.Load<Texture2D>("path");
            Texture2D redPath = Content.Load<Texture2D>("redPath");
            Texture2D whitePath = Content.Load<Texture2D>("whitePath");
            Texture2D blueGrass = Content.Load<Texture2D>("grass");
            Texture2D shadowGrass = Content.Load<Texture2D>("shadowGrass");
            level.addTexture(grass);
            level.addTexture(path);
            level.addTexture(whitePath);
            level.addTexture(redPath);
            level.addTexture(blueGrass);
            level.addTexture(shadowGrass);

            //Texture2D enemyTexture = Content.Load<Texture2D>("zombie1");
            //Texture2D enemyTexture2 = Content.Load<Texture2D>("zombie2");



            //enemy1 = new enemyModel(enemyTexture, level.Waypoints.Peek(), 100, 10, 2.0f);
            //enemy1.setWaypoints(level.Waypoints);
            //wave = new waveModel(0, 100, level, enemyTexture);
            //wave.Start();

            Texture2D[] enemyTextures = new Texture2D[]
            {
            Content.Load<Texture2D>("zombie1"),
            Content.Load<Texture2D>("zombie2")
            };

            
            Texture2D bulletTexture = Content.Load<Texture2D>("bullet1");

            Texture2D[] towerTextures = new Texture2D[]
            {
            Content.Load<Texture2D>("basicTower"),
            Content.Load<Texture2D>("speedTower"),
            Content.Load<Texture2D>("slowTower"),
            Content.Load<Texture2D>("bomberTower")
            };

            //tower = new towerModel(towerTexture, Vector2.Zero);
            player = new playerModel(level, towerTextures, graphics.GraphicsDevice.Viewport, bulletTexture);
            waveManager = new waveManagerModel(player, level, 24, enemyTextures);

            Texture2D topBar = Content.Load<Texture2D>("toolBar");
            SpriteFont font = Content.Load<SpriteFont>("Arial");
            toolbar = new Toolbar(topBar, font, new Vector2(0, level.Height * 0));

            Texture2D basicNormal = Content.Load<Texture2D>("GUI\\basicTowerGUI");
            Texture2D basicHover = Content.Load<Texture2D>("GUI\\basicHoverGUI");
            Texture2D basicPressed = Content.Load<Texture2D>("GUI\\pressedButton");
            basicButton = new Button(basicNormal, basicHover, basicPressed, new Vector2(0, level.Height * 55));
            basicButton.Clicked += new EventHandler(basicButton_Clicked);

            Texture2D speedNormal = Content.Load<Texture2D>("GUI\\speedTowerGUI");
            Texture2D speedHover = Content.Load<Texture2D>("GUI\\speedHoverGUI");
            Texture2D speedPressed = Content.Load<Texture2D>("GUI\\pressedButton");
            speedButton = new Button(speedNormal, speedHover, speedPressed, new Vector2(60, level.Height * 55));
            speedButton.Clicked += new EventHandler(speedButton_Clicked);

            Texture2D slowNormal = Content.Load<Texture2D>("GUI\\slowTowerGUI");
            Texture2D slowHover = Content.Load<Texture2D>("GUI\\slowHoverGUI");
            Texture2D slowPressed = Content.Load<Texture2D>("GUI\\pressedButton");
            slowButton = new Button(slowNormal, slowHover, slowPressed, new Vector2(120, level.Height * 55));
            slowButton.Clicked += new EventHandler(slowButton_Clicked);

            Texture2D bomberNormal = Content.Load<Texture2D>("GUI\\bomberTowerGUI");
            Texture2D bomberHover = Content.Load<Texture2D>("GUI\\bomberHoverGUI");
            Texture2D bomberPressed = Content.Load<Texture2D>("GUI\\pressedButton");
            bomberButton = new Button(bomberNormal, bomberHover, bomberPressed, new Vector2(180, level.Height * 55));
            bomberButton.Clicked += new EventHandler(bomberButton_Clicked);

        }

        private void basicButton_Clicked(object sender, EventArgs e)
        {
            player.NewTowerType = "basicTower";
        }

        private void speedButton_Clicked(object sender, EventArgs e)
        {
            player.NewTowerType = "speedTower";
        }

        private void slowButton_Clicked(object sender, EventArgs e)
        {
            player.NewTowerType = "slowTower";
        }

        private void bomberButton_Clicked(object sender, EventArgs e)
        {
            player.NewTowerType = "bomberTower";
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
            if (Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();


            //enemy1.Update(gameTime);


            //if (tower.Target == null)
            //{
            //    List<enemyModel> enemies = new List<enemyModel>();

            //    enemies.Add(enemy1);
            //    tower.getTheClosestTarget(enemies);
            //}
            //tower.Update(gameTime);

            //base.Update(gameTime);


            //enemy1.Update(gameTime);

            //List<enemyModel> enemies = new List<enemyModel>();
            //enemies.Add(enemy1);

            waveManager.Update(gameTime);

            player.Update(gameTime, waveManager.Enemies);

            basicButton.Update(gameTime);
            speedButton.Update(gameTime);
            slowButton.Update(gameTime);
            bomberButton.Update(gameTime);

            base.Update(gameTime);


        }

        /// <summary>
        /// This is called when the game should draw itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            spriteBatch.Begin();

            level.Draw(spriteBatch);
            //enemy1.Draw(spriteBatch);

            waveManager.Draw(spriteBatch);

            player.Draw(spriteBatch);

            toolbar.Draw(spriteBatch, player, waveManager);

            basicButton.Draw(spriteBatch);
            speedButton.Draw(spriteBatch);
            slowButton.Draw(spriteBatch);
            bomberButton.Draw(spriteBatch);

            spriteBatch.End();

            base.Draw(gameTime);
        }
    }
}