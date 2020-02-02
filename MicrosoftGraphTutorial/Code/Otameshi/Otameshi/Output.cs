using System;

namespace Otameshi
{
    class Output
    {
        public event EventHandler? MessageChanged;

        private string message = string.Empty;
        public string Message
        {
            get => message;
            private set
            {
                if (message != value)
                {
                    message = value;
                    MessageChanged?.Invoke(this, EventArgs.Empty);
                }
            }
        }

        public void WriteLine(string message)
        {
            Message = message;
        }
    }
}
