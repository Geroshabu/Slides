using System;
using System.ComponentModel;
using System.Windows.Input;
using Otameshi.Authentication;

namespace Otameshi
{
    public class MainWindowViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler? PropertyChanged;

        private readonly Output output;
        public string Message
        {
            get => output.Message;
        }

        public ICommand AuthenticationCommand { get; }

        public ICommand GetMeCommand { get; }

        public MainWindowViewModel()
        {
            output = new Output();
            output.MessageChanged += handleMessageChanged;

            var signinState = new SigninState();
            var generator = new InteractiveAccessTokenGenerator();

            AuthenticationCommand = new Commands.AuthenticationCommand(
                generator,
                signinState,
                output);
            GetMeCommand = new Commands.GetMeCommand(
                generator,
                signinState,
                output);
        }

        private void handleMessageChanged(object? sender, EventArgs e)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(Message)));
        }
    }
}
