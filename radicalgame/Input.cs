using Microsoft.Xna.Framework.Input;

namespace radicalgame
{
    public class UserInputState
    {
        public UserInputState()
        {
            CurrentKS = new KeyboardState();
            OldKS = new KeyboardState();
        }

        public KeyboardState CurrentKS;
        public KeyboardState OldKS;
    }

    public class ControlScheme
    {
        public Keys Up { get; set; }
        public Keys Down { get; set; }
        public Keys Left { get; set; }
        public Keys Right { get; set; }
        public Keys Pause { get; set; }

        public static ControlScheme Default
        {
            get
            {
                ControlScheme val = new ControlScheme();
                val.Up = Keys.W;
                val.Down = Keys.S;
                val.Left = Keys.A;
                val.Right = Keys.D;
                val.Pause = Keys.Escape;
                return val;
            }
        }

        public static ControlScheme Alternate
        {
            get
            {
                ControlScheme val = new ControlScheme();
                val.Up = Keys.Up;
                val.Down = Keys.Down;
                val.Left = Keys.Left;
                val.Right = Keys.Right;
                val.Pause = Keys.Escape;
                return val;
            }
        }
    }
}
