using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace tilemap_generator.Class
{
    internal class Tile
    {
        public Texture2D _texture { get; set; }
        public int _textureResolution { get;  }
        public int _tileId { get; }

        public Tile(Texture2D texture, int textureResolution, int tileId)
        {
            _texture = texture;
            _textureResolution = textureResolution;
            _tileId = tileId;
        }
    }
}
