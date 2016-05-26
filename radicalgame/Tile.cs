using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace radicalgame
{
    public class Tile
    {
        public static Vector2 TileDimensions
        {
            get
            {
                return new Vector2(100.0f, 100.0f);
            }
        }

        RectangleF _boundingBox;
        Texture2D _texture;

        public Tile(Vector2 position, Texture2D texture)
        {
            _boundingBox = new RectangleF(position, TileDimensions);
            _texture = texture;
        }

        public void Draw(SpriteBatch sb)
        {
            sb.Draw(_texture, (Rectangle)_boundingBox, Color.White);
        }
    }
}
