using System;
using TiledSharp;
using WaveEngine.Common.Graphics;
using WaveEngine.Common.Math;
using WaveEngine.Components.Graphics2D;
using WaveEngine.Framework;
using WaveEngine.Framework.Graphics;

namespace ToBeDecided.MapClasses
{
    public class MapDrawer : Drawable2D
    {
        private TmxMap tmxMap;
        private TmxTileset tileset;
        private Sprite thisSprite;
        private bool init = false;

        public MapDrawer(TmxMap map)
        {
            this.tmxMap = map;
            tileset = map.Tilesets[0];
            thisSprite = new Sprite(WaveContent.Assets.tmw_desert_spacing_png);
        }

        protected override void Initialize()
        {
            base.Initialize();

        }
        public override void Draw(TimeSpan gameTime)
        {
            /*
             * Der einzige Weg (von dem ich bis jetzt weiß) eine Textur zu laden ist, eine neue Entity mit der Sprite-Komponente zu erstellen und 
             * diese Entity dem EntityManager hinzuzufügen.
             * Das soll aber nur ein einziges mal passieren, darum diese Abfrage. 
             */

            if(!init)
            {
                EntityManager.Add(new Entity().AddComponent(new Transform2D()).AddComponent(thisSprite));
                init = true;
            }

            foreach (TmxLayer layer in tmxMap.Layers)
            {
                for (int i = 0; i < layer.Tiles.Count; i++)
                {
                    TmxLayerTile currentTile = layer.Tiles[i];

                    /*  GID = Global ID
                     *  Exkurs: GIDs in einer Tiled-Map 
                     *  Eine TileSheet hat z.B das Format 5x6 (5 Zeilen und 6 Spalten).
                     *  Tiles in diesem Sheet werden der Reihe nach durchnummeriert (Also hat das erste Tile oben links die GID 1).
                     *  Die ID ist über alle Tilesheets einzigartig, das heißt, dass wenn man zwei Tilesheets hat, das erste die IDs von 1 bis 31
                     *  und das zweite Tilesheet hat die IDs 32 bis 62.
                     *  Bei welcher GID das Tilesheet anfängt ist in der "FirstGid" Eigenschaft gespeichert.
                     */
                     
                    int gid = currentTile.Gid - tileset.FirstGid;

                    //TODO: Verstehen
                    int column = gid % ((int)tileset.Image.Width / tileset.TileWidth);
                    int row = (int)(gid / (tileset.Image.Width / tileset.TileWidth));


                    /*
                     *  Unsere Tiles sind in einer jpg-Datei gespeichert. Wird wissen wie viel Abstand die Teils zum Rand (Spacing) und zueinander (Margin) haben.
                     *  Damit können wir berechnen, welches Rechteck auf dem Bild unser gesuchtes Tile ist.
                     */

                    int tilesheetX = tileset.Spacing + column * (tileset.TileWidth + tileset.Margin);
                    int tilesheetY = tileset.Spacing + row * (tileset.TileHeight + tileset.Margin);

                    int worldX = currentTile.X * tileset.TileWidth;
                    int worldY = currentTile.Y * tileset.TileHeight;

                    Rectangle tilesheetRectangle = new Rectangle(tilesheetX, tilesheetY, tileset.TileWidth, tileset.TileHeight);

                    this.layer.SpriteBatch.Draw(thisSprite.Texture, new Vector2(worldX, worldY),
                        tilesheetRectangle, Color.White, 0f, new Vector2(), Vector2.One, 
                        SpriteEffects.None, 1f, AddressMode.PointClamp); 
                }
            }
        }

        protected override void Dispose(bool disposing)
        {
            //throw new NotImplementedException();
        }

        protected override void DrawDebugLines()
        {
            //throw new NotImplemen tedException();
        }

    }
}
