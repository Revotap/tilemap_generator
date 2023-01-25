using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace tilemap_generator.Class
{
    internal class TileEntry
    {
        public Tile _tile;
        public Vector2 _drawVector;

        public TileEntry(Tile tile, Vector2 drawVector)
        {
            _tile = tile;
            _drawVector = drawVector;
        }
    }
}
