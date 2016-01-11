using Game1.GUI;
using Game1.Model;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
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
       
        playerModel player;
        
        waveManagerModel waveManager;
        waveModel waveModel;
        Toolbar toolbar;
        Button basicButton;
        Button speedButton;
        Button slowButton;
        Button bomberButton;
        Button rangeButton;
        

        public static Rectangle screen;
        
        

        public static GameWindow WindowObject;

        enum GameState
        {
            MainMenu,
            Play,
            Paused,
            GameOver,
            Won,
            Exit
        }

        GameState CurrentGameState = GameState.MainMenu;

        int screenWidth = 780;
        int screenHeight = 780;

        Menu playMenu;
        Menu pauseMenu;
        Menu exitMenu;
        Menu gameOMenu;

        


        public Game1()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            //graphics.IsFullScreen = true;
            
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


            

            graphics.PreferredBackBufferWidth = screenWidth;
            graphics.PreferredBackBufferHeight = screenHeight;

            playMenu = new Menu(Content.Load<Texture2D>("GUI\\playBtn"), graphics.GraphicsDevice);
            playMenu.setPosition(new Vector2(level.Width * 60 / 2 - playMenu.size.X / 2, level.Height * 60 / 2  - playMenu.size.Y / 2));

            pauseMenu = new Menu(Content.Load<Texture2D>("GUI\\resumeBtn"), graphics.GraphicsDevice);
            pauseMenu.setPosition(new Vector2(level.Width * 60 / 2 - pauseMenu.size.X / 2, level.Height * 60 / 2 - pauseMenu.size.Y / 2));

            exitMenu = new Menu(Content.Load<Texture2D>("GUI\\exitBtn"), graphics.GraphicsDevice);
            exitMenu.setPosition(new Vector2(level.Width * 60 / 2 - exitMenu.size.X / 2, level.Height * 60 / 2 + exitMenu.size.Y / 2));

            Texture2D bulletTexture = Content.Load<Texture2D>("bullet1");

            Texture2D[] towerTextures = new Texture2D[]
            {
            Content.Load<Texture2D>("basicTower"),
            Content.Load<Texture2D>("speedTower"),
            Content.Load<Texture2D>("slowTower"),
            Content.Load<Texture2D>("bomberTower"),
            Content.Load<Texture2D>("rangeTower")
            };


            player = new playerModel(level, towerTextures, graphics.GraphicsDevice.Viewport, bulletTexture);

            Texture2D[] enemyTextures = new Texture2D[]
            {
            Content.Load<Texture2D>("zombie1"),
            Content.Load<Texture2D>("zombie2"),
            Content.Load<Texture2D>("zombie3")
            };

            waveManager = new waveManagerModel(player, level, 24, enemyTextures);
            waveModel = new waveModel(0, 0, player, level, enemyTextures[0]);

            Texture2D grass = Content.Load<Texture2D>("grass");
            Texture2D path = Content.Load<Texture2D>("path");
            Texture2D redPath = Content.Load<Texture2D>("redPath");
            Texture2D whitePath = Content.Load<Texture2D>("whitePath");
            Texture2D blueGrass = Content.Load<Texture2D>("grass");
            Texture2D shadowGrass = Content.Load<Texture2D>("shadowGrass");
            Texture2D bushSprite = Content.Load<Texture2D>("bushSprite");
            Texture2D rockSprite = Content.Load<Texture2D>("rockSprite");
            level.addTexture(grass);
            level.addTexture(path);
            level.addTexture(whitePath);
            level.addTexture(redPath);
            level.addTexture(blueGrass);
            level.addTexture(shadowGrass);
            level.addTexture(bushSprite);
            level.addTexture(rockSprite);

            

            SpriteFont font = Content.Load<SpriteFont>("Arial");

            
            Texture2D topBar = Content.Load<Texture2D>("toolBar");
            toolbar = new Toolbar(topBar, font, new Vector2(0, level.Height * 0));


            Texture2D basicNormal = Content.Load<Texture2D>("GUI\\basicTowerGUI");
            Texture2D basicHover = Content.Load<Texture2D>("GUI\\basicHover");
            Texture2D basicPressed = Content.Load<Texture2D>("GUI\\pressedButton");
            basicButton = new Button(basicNormal, basicHover, basicPressed, new Vector2(0, level.Height * 55));
            basicButton.Clicked += new EventHandler(basicButton_Clicked);

            Texture2D speedNormal = Content.Load<Texture2D>("GUI\\speedTowerGUI");
            Texture2D speedHover = Content.Load<Texture2D>("GUI\\speedHover");
            Texture2D speedPressed = Content.Load<Texture2D>("GUI\\pressedButton");
            speedButton = new Button(speedNormal, speedHover, speedPressed, new Vector2(60, level.Height * 55));
            speedButton.Clicked += new EventHandler(speedButton_Clicked);

            Texture2D slowNormal = Content.Load<Texture2D>("GUI\\slowTowerGUI");
            Texture2D slowHover = Content.Load<Texture2D>("GUI\\slowHover");
            Texture2D slowPressed = Content.Load<Texture2D>("GUI\\pressedButton");
            slowButton = new Button(slowNormal, slowHover, slowPressed, new Vector2(120, level.Height * 55));
            slowButton.Clicked += new EventHandler(slowButton_Clicked);

            Texture2D bomberNormal = Content.Load<Texture2D>("GUI\\bomberTowerGUI");
            Texture2D bomberHover = Content.Load<Texture2D>("GUI\\bomberHover");
            Texture2D bomberPressed = Content.Load<Texture2D>("GUI\\pressedButton");
            bomberButton = new Button(bomberNormal, bomberHover, bomberPressed, new Vector2(180, level.Height * 55));
            bomberButton.Clicked += new EventHandler(bomberButton_Clicked);

            Texture2D rangeNormal = Content.Load<Texture2D>("GUI\\rangeTowerGUI");
            Texture2D rangeHover = Content.Load<Texture2D>("GUI\\rangeHover");
            Texture2D rangePressed = Content.Load<Texture2D>("GUI\\pressedButton");
            rangeButton = new Button(rangeNormal, rangeHover, rangePressed, new Vector2(240, level.Height * 55));
            rangeButton.Clicked += new EventHandler(rangeButton_Clicked);




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

        private void rangeButton_Clicked(object sender, EventArgs e)
        {
            player.NewTowerType = "rangeTower";
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

            MouseState mouse = Mouse.GetState();

            if (Keyboard.GetState().IsKeyDown(Keys.P))
            {
                CurrentGameState = GameState.Paused;
            }

            if (Keyboard.GetState().IsKeyDown(Keys.M))
            {
                CurrentGameState = GameState.MainMenu;
            }


            switch (CurrentGameState)
            {
                case GameState.MainMenu:

                    if (playMenu.isClicked == true)
                    {
                        LoadContent();
                        CurrentGameState = GameState.Play;
                        playMenu.isClicked = false;
                        

                    }
                    playMenu.Update(mouse);

                    if (exitMenu.isClicked == true)
                    {
                        
                        Exit();

                    }
                    exitMenu.Update(mouse);


                    break;

                case GameState.Play:

                    if (player.Lives <= 0)
                    {
                        CurrentGameState = GameState.GameOver;
                        playMenu.isClicked = false;

                    }

                    if (player.Lives >= 1 && waveManager.Round == 24)
                    {
                        CurrentGameState = GameState.Won;
                        playMenu.isClicked = false;
                    }


                    waveManager.Update(gameTime);

                    player.Update(gameTime, waveManager.Enemies);

                    basicButton.Update(gameTime);
                    speedButton.Update(gameTime);
                    slowButton.Update(gameTime);
                    bomberButton.Update(gameTime);
                    rangeButton.Update(gameTime);

                    break;

                case GameState.Paused:
                    if (pauseMenu.isClicked == true)
                    {

                        CurrentGameState = GameState.Play;

                    }
                    pauseMenu.Update(mouse);
                    break;

                case GameState.GameOver:

                    if (playMenu.isClicked == true)
                    {
                        LoadContent();
                        CurrentGameState = GameState.Play;
                        playMenu.isClicked = false;


                    }
                    playMenu.Update(mouse);

                    if (exitMenu.isClicked == true)
                    {

                        Exit();

                    }
                    exitMenu.Update(mouse);
                    break;

                case GameState.Won:

                    if (playMenu.isClicked == true)
                    {
                        LoadContent();
                        CurrentGameState = GameState.Play;
                        playMenu.isClicked = false;


                    }
                    playMenu.Update(mouse);

                    if (exitMenu.isClicked == true)
                    {

                        Exit();

                    }
                    exitMenu.Update(mouse);
                    break;


            }

            
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


            switch (CurrentGameState)
            {
                case GameState.MainMenu:
                    spriteBatch.Draw(Content.Load<Texture2D>("GUI\\mainMenu"), new Rectangle(0,0, screenWidth, screenHeight), Color.White);
                    
                    playMenu.Draw(spriteBatch);
                    exitMenu.Draw(spriteBatch);

                    break;

                case GameState.Play:

                    level.Draw(spriteBatch);
                    //enemy1.Draw(spriteBatch);

                    waveManager.Draw(spriteBatch);

                    player.Draw(spriteBatch);

                    toolbar.Draw(spriteBatch, player, waveManager);


                    basicButton.Draw(spriteBatch);
                    speedButton.Draw(spriteBatch);
                    slowButton.Draw(spriteBatch);
                    bomberButton.Draw(spriteBatch);
                    rangeButton.Draw(spriteBatch);


                    break;

                case GameState.Paused:

                    level.Draw(spriteBatch);
                    //enemy1.Draw(spriteBatch);

                    
                    pauseMenu.Draw(spriteBatch);


                    break;

                case GameState.GameOver:

                    
                    //enemy1.Draw(spriteBatch);


                    spriteBatch.Draw(Content.Load<Texture2D>("GUI\\overMenu"), new Rectangle(0, 0, screenWidth, screenHeight), Color.White);

                    playMenu.Draw(spriteBatch);
                    exitMenu.Draw(spriteBatch);


                    break;

                case GameState.Won:


                    //enemy1.Draw(spriteBatch);


                    spriteBatch.Draw(Content.Load<Texture2D>("GUI\\wonMenu"), new Rectangle(0, 0, screenWidth, screenHeight), Color.White);

                    playMenu.Draw(spriteBatch);
                    exitMenu.Draw(spriteBatch);


                    break;
            }



           

            spriteBatch.End();

            base.Draw(gameTime);
        }
    }
}