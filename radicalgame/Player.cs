using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace radicalgame
{
    class Player
    {
        public static float GravitySpeed = 5.0f;

        public static Vector2 PlayerDimensions
        {
            get
            {
                return new Vector2(50.0f, 100.0f);
            }
        }

        public static float PlayerSpeed
        {
            get
            {
                return 5.0f;
            }
        }

        RadGame _game;
        RectangleF _boundingBox;
        Texture2D _texture;

        public Player(RadGame game, Texture2D texture, Vector2 position)
        {
            _game = game;
            _texture = texture;
            _boundingBox = new RectangleF();
            _boundingBox.XY = position;
            _boundingBox.Dimensions = PlayerDimensions;
        }

        public Vector2 Position
        {
            get
            {
                return _boundingBox.XY;
            }
            set
            {
                _boundingBox.XY = value;
            }
        }

        public Vector2 Center
        {
            get
            {
                return new Vector2(_boundingBox.X + _boundingBox.Width / 2.0f, _boundingBox.Y + _boundingBox.Height / 2.0f);
            }
        }

        public void Update()
        {
            // TODO: incorporate time into update calculations

            Vector2 Velocity = Vector2.Zero;

            // horizontal movement
            if (_game.InputState.CurrentKS.IsKeyDown(_game.Controls.Right))
            {
                Velocity += new Vector2(PlayerSpeed, 0.0f);
            }
            if (_game.InputState.CurrentKS.IsKeyDown(_game.Controls.Left))
            {
                Velocity += new Vector2(-PlayerSpeed, 0.0f);
            }

            // vertical movement
            Velocity += new Vector2(0.0f, GravitySpeed);

            Position += Velocity;
        }

        public void Draw(SpriteBatch sb)
        {
            sb.Draw(_texture, (Rectangle)_boundingBox, Color.Red);
        }
    }
}
