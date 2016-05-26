using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Microsoft.Xna.Framework;

namespace radicalgame
{
    public class Camera2D
    {
        public Matrix viewMatrix;

        private Vector2 position;
        private Vector2 halfViewSize;

        public Camera2D(Rectangle clientRectangle)
        {
            this.halfViewSize = new Vector2(clientRectangle.Width * 0.5f, clientRectangle.Height * 0.5f);
            UpdateViewMatrix();
        }

        public Vector2 Position
        {
            get
            {
                return this.position;
            }
            set
            {
                this.position = value;
                UpdateViewMatrix();
            }
        }

        public float X
        {
            set
            {
                this.position.X = value;
            }
        }

        private void UpdateViewMatrix()
        {
            viewMatrix = Matrix.CreateTranslation(halfViewSize.X - position.X, halfViewSize.Y - position.Y, 0.0f);
        }
    }
}
