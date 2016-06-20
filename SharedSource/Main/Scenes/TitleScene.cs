///////////////////////////////////////////////////////////
//  TitleScene.cs
//  Implementation of the Class TitleScene
//  Generated by Enterprise Architect
//  Created on:      08-Jun-2016 18:24:51
//  Original author: Ralf
///////////////////////////////////////////////////////////

using Entitys;
using System;
using ToBeDecided;
using ToBeDecided.MapClasses;
using ToBeDecided.Scenes;
using WaveEngine.Components.Cameras;
using WaveEngine.Components.Transitions;
using WaveEngine.Components.UI;
using WaveEngine.Framework;
using WaveEngine.Framework.Services;

namespace Scenes
{
    public class TitleScene : Scene {

        private const int BUTTON_ABSTAND = 100;

		public TitleScene(){

		}

        protected override void CreateScene()
        {
            FixedCamera2D camera = new FixedCamera2D("Camera");
            EntityManager.Add(camera);

            Button newGameButton = new Button("New Game")
            {
                Text = "Neues Spiel",
                HorizontalAlignment = WaveEngine.Framework.UI.HorizontalAlignment.Center,
                VerticalAlignment = WaveEngine.Framework.UI.VerticalAlignment.Center,
            };
            newGameButton.SetValue(GridControl.RowProperty, 4);
            newGameButton.SetValue(GridControl.ColumnProperty, 0);
            newGameButton.Click += onNewGameButtonClick;

            Button loadGameButton = new Button("Load Game")
            {
                Text = "Spiel laden",
                HorizontalAlignment = WaveEngine.Framework.UI.HorizontalAlignment.Center,
                VerticalAlignment = WaveEngine.Framework.UI.VerticalAlignment.Center,
                //Margin = new WaveEngine.Framework.UI.Thickness(1),
            };
            loadGameButton.SetValue(GridControl.RowProperty, 6);
            loadGameButton.SetValue(GridControl.ColumnProperty, 0);
            loadGameButton.Click += onLoadGameButtonClick;

            Grid uiGrid = new Grid();
            for (int i = 0; i < 8; i++)
            {
                
                uiGrid.RowDefinitions.Add(new RowDefinition() { Height = new GridLength(i % 2 == 0?newGameButton.Height:newGameButton.Height / 2, GridUnitType.Pixel)});
            }

            uiGrid.ColumnDefinitions.Add(new ColumnDefinition() { Width = new GridLength(1, GridUnitType.Proportional) });
            uiGrid.HorizontalAlignment = WaveEngine.Framework.UI.HorizontalAlignment.Center;
            uiGrid.VerticalAlignment = WaveEngine.Framework.UI.VerticalAlignment.Center;
            EntityManager.Add(uiGrid);

            uiGrid.Add(newGameButton);
            uiGrid.Add(loadGameButton);
        }

        private void onNewGameButtonClick(object sender, EventArgs e)
        {

            GameScene gc = new GameScene(MapLoader.getInstance().load(WaveContent.Assets.desert_tmx));
            Player player = new Player(gc);
            gc.player = player;

            ScreenContext screenContext = new ScreenContext(gc);
            WaveServices.ScreenContextManager.To(screenContext, new CurtainsTransition(new TimeSpan(0,0,5)));
        }

        private void onLoadGameButtonClick(object sender, EventArgs e)
        {

        }
    }//end TitleScene

}//end namespace Scenes