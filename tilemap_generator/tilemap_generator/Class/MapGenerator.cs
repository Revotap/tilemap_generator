using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace tilemap_generator.Class
{
    internal class MapGenerator
    {
        private int[,] _map { get; }

        public List<TileEntry> _tileMap { get; set; }

        private Tile _defaultTile;

        public MapGenerator(int width, int height, Tile defaulTile)
        {
            _map = new int[width, height];
            _defaultTile = defaulTile;

            for(int x = 0; x < width; x++)
            {
                for(int y = 0; y < height; y++)
                {
                    _map[x, y] = defaulTile._tileId;
                }
            }

            GenerateTileMap();
        }

        public void ChangeTileAt(Vector2 location, Texture2D newTexture)
        {
            //ToDo

            //Refresh TileMap
            GenerateTileMap();
        }

        private void GenerateTileMap()
        {
            _tileMap = new List<TileEntry>();

            for (int x = 0; x < _map.GetLength(0); x++)
            {
                for (int y = 0; y < _map.GetLength(1); y++)
                {
                    _tileMap.Add(new TileEntry(_defaultTile, new Vector2(_defaultTile._textureResolution * x, _defaultTile._textureResolution * y)));
                }
            }
        }

        public List<TileEntry> GetTileMap()
        {
            return _tileMap;
        }

        public void Draw(SpriteBatch spriteBatch, Vector2 originDrawVector)
        {   
            foreach(TileEntry entry in _tileMap)
            {
                spriteBatch.Draw(entry._tile._texture, new Rectangle((int)originDrawVector.X + (int)entry._drawVector.X, (int)originDrawVector.Y + (int)entry._drawVector.Y, 64,64), Color.White);
            }
        }
    }
}
