using System;

namespace Otameshi
{
    class SigninState
    {
        public event EventHandler? IsSigninedChanged;

        private bool isSignined;
        public bool IsSignined
        {
            get => isSignined;
            set
            {
                if (isSignined != value)
                {
                    isSignined = value;
                    IsSigninedChanged?.Invoke(this, EventArgs.Empty);
                }
            }
        }
    }
}
