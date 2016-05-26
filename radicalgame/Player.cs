using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace radicalgame
{
    class Player
    {
        public static Vector2 PlayerDimensions
        {
            get
            {
                return new Vector2(30.0f, 30.0f);
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
            Velocity = new Vector2();
        }

        public Vector2 Velocity { get; set; }
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

            Velocity = Vector2.Zero;

            if (_game.InputState.CurrentKS.IsKeyDown(Keys.D))
            {
                Velocity += new Vector2(3.0f, 0.0f);
            }
            if (_game.InputState.CurrentKS.IsKeyDown(Keys.A))
            {
                Velocity += new Vector2(-3.0f, 0.0f);
            }
            if (_game.InputState.CurrentKS.IsKeyDown(Keys.W))
            {
                Velocity += new Vector2(0.0f, -3.0f);
            }
            if (_game.InputState.CurrentKS.IsKeyDown(Keys.S))
            {
                Velocity += new Vector2(0.0f, 3.0f);
            }

            Position += Velocity;
        }

        public void Draw(SpriteBatch sb)
        {
            sb.Draw(_texture, (Rectangle)_boundingBox, Color.Red);
        }
    }
}
