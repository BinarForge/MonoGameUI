﻿using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

using MonoGameUI;
using MonoGameUI.Core;
using MonoGameUI.Containers;
using MonoGameUI.Elements;
using System;

namespace MonoGameUi_Examples
{
	/// <summary>
	/// This is the main type for your game.
	/// </summary>
	public class Game : Microsoft.Xna.Framework.Game
	{
		GraphicsDeviceManager graphics;
		SpriteBatch spriteBatch;
		protected int SCREEN_WIDTH;
		protected int SCREEN_HEIGHT;

		UIManager			_uiManager;
		UiContainer			_uiRoot;
		IResourceManager    _resourceManager;
		private	 SpriteFont _uiFont;

		int                 _exampleID = 0;
		ExampleNavigation   _navigation;

		public Game()
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
			// TODO: Add your initialization logic here
			SCREEN_WIDTH = GraphicsDevice.PresentationParameters.Bounds.Width;
			SCREEN_HEIGHT = GraphicsDevice.PresentationParameters.Bounds.Height;

			_uiManager = new UIManager(GraphicsDevice);
			SetupExample(1);

			base.Initialize();
		}

		private void SetupExample(int v)
		{
			if (_exampleID == v)
				return;

			_exampleID = v;

			if(v == 1) {
				_uiRoot = new UiContainer();

				_uiRoot.Position = new Position(
					0,
					0,
					SCREEN_WIDTH,
					SCREEN_HEIGHT
				);

				var verticalContainer = new VerticalContainer();
				verticalContainer.AppendChild(new TextField {
					Text = "Hello top container!",
					TextAlignment = TextAlignment.MiddleCenter,
					BgColor = Color.Maroon,
					TextColor = Color.GreenYellow,
					Weight = 25
				});
				verticalContainer.AppendChild(new TextField {
					Text = "Hello bottom container...",
					TextAlignment = TextAlignment.MiddleCenter,
					BgColor = Color.CadetBlue,
					TextColor = Color.Wheat,
					Weight = 75
				});
				_uiRoot.AppendChild(verticalContainer);
				_uiManager.SetRootNode(_uiRoot);
				_uiManager.Initialise();
			}
			else if(v == 2) {
				_uiManager.Load("Content\\ui_test.xml");
			}

			_navigation?.Set(v);
		}

		/// <summary>
		/// LoadContent will be called once per game and is the place to load
		/// all of your content.
		/// </summary>
		protected override void LoadContent()
		{
			// Create a new SpriteBatch, which can be used to draw textures.
			spriteBatch = new SpriteBatch(GraphicsDevice);

			_uiFont = Content.Load<SpriteFont>("ui_font");
			_resourceManager = new ResourceManager(GraphicsDevice, _uiFont);
			_resourceManager.Initialise();
			_uiManager.Setup(_resourceManager);
			_uiManager.Initialise();

			_navigation = new ExampleNavigation();
			_navigation.Initialise(_uiManager, SCREEN_WIDTH, SCREEN_HEIGHT);
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

			// TODO: Add your update logic here
			if (Keyboard.GetState().IsKeyDown(Keys.D1))
				SetupExample(1);
			else if (Keyboard.GetState().IsKeyDown(Keys.D2))
				SetupExample(2);

			base.Update(gameTime);
		}

		/// <summary>
		/// This is called when the game should draw itself.
		/// </summary>
		/// <param name="gameTime">Provides a snapshot of timing values.</param>
		protected override void Draw(GameTime gameTime)
		{
			GraphicsDevice.Clear(Color.CornflowerBlue);

			// TODO: Add your drawing code here
			spriteBatch.Begin(SpriteSortMode.Deferred, null, SamplerState.PointClamp);
			_uiManager.Draw(spriteBatch);
			_navigation.Draw(spriteBatch);
			spriteBatch.End();

			base.Draw(gameTime);
		}
	}
}
