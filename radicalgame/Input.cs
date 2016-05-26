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
}