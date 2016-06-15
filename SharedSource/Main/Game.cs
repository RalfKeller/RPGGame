#region Using Statements
using Scenes;
using System;
using WaveEngine.Common;
using WaveEngine.Common.Graphics;
using WaveEngine.Framework;
using WaveEngine.Framework.Services;
#endregion

namespace ToBeDecided
{
    public class Game : WaveEngine.Framework.Game
    {
        public override void Initialize(IApplication application)
        {
            base.Initialize(application);

			ScreenContext screenContext = new ScreenContext(new TitleScene());	
			WaveServices.ScreenContextManager.To(screenContext);
        }
    }
}
