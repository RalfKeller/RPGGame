using Entitys;
using System;
using System.Drawing;
using WaveEngine.Framework;
using WaveEngine.Framework.Graphics;

namespace ToBeDecided
{
    class CameraTrackBehaviour : Behavior
    {
        [RequiredComponent]
        Transform2D transform;

        private GameObject objectToTrack;
        private Rectangle outerBounds;
        private Rectangle freeMoveArea;

        public CameraTrackBehaviour(GameObject objectToTrack, Rectangle outerBounds)
        {
            this.objectToTrack = objectToTrack;
            this.outerBounds = outerBounds;
        }
        protected override void Update(TimeSpan gameTime)
        {
            transform.X = objectToTrack.transform.X;
            transform.Y = objectToTrack.transform.Y;

            float screenHeight  = RenderManager.Scene.VirtualScreenManager.VirtualHeight;
            float screenWidth   = RenderManager.Scene.VirtualScreenManager.VirtualWidth;

            float upperY    = transform.Y   - (screenHeight / 2);
            float lowerY    = transform.Y   + (screenHeight / 2);
            float leftX     = transform.X   - (screenWidth  / 2);
            float rightX    = transform.X   + (screenWidth  / 2);

            if (leftX < outerBounds.X)
                transform.X = outerBounds.X + (screenWidth / 2);

            if (upperY < outerBounds.Y)
                transform.Y = outerBounds.Y + (screenHeight / 2);

            if (rightX > outerBounds.X + outerBounds.Width)
                transform.X = (outerBounds.X + outerBounds.Width) - (screenWidth / 2);

            if (lowerY > outerBounds.Y + outerBounds.Height)
                transform.Y = (outerBounds.Y + outerBounds.Height) - (screenHeight / 2);

        }
    }
}
