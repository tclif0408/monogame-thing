using Microsoft.Xna.Framework;

namespace radicalgame
{
    public class RectangleF
    {
        public RectangleF() { }
        public RectangleF(float x, float y, float width, float height)
        {
            X = x;
            Y = y;
            Width = width;
            Height = height;
        }
        public RectangleF(Vector2 position, Vector2 size)
        {
            XY = position;
            Dimensions = size;
        }

        public float X { get; set; }
        public float Y { get; set; }
        public float Width { get; set; }
        public float Height { get; set; }

        public Vector2 XY
        {
            get
            {
                return new Vector2(X, Y);
            }
            set
            {
                X = value.X;
                Y = value.Y;
            }
        }

        public Vector2 Dimensions
        {
            get
            {
                return new Vector2(Width, Height);
            }
            set
            {
                Width = value.X;
                Height = value.Y;
            }
        }

        public static explicit operator Rectangle(RectangleF rf)
        {
            return new Rectangle((int)rf.X, (int)rf.Y, (int)rf.Width, (int)rf.Height);
        }
    }
}
