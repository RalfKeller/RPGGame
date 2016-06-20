using System;
using System.Collections.Generic;
using System.Text;
using WaveEngine.Common.Math;

namespace ToBeDecided
{
    class Oval
    {
        private Vector2 center;
        private float radiusOben;
        private float radiusSeite;

        public Oval(Vector2 center, float radiusOben, float radiusSeite)
        {
            this.center         = center;
            this.radiusOben     = radiusOben;
            this.radiusSeite    = radiusSeite;
        }
    }
}
