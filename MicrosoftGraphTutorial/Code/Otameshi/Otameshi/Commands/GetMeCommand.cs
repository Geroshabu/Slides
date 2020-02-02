using System;
using System.Windows.Input;
using Otameshi.Core;
using Otameshi.GraphApi;

namespace Otameshi.Commands
{
    class GetMeCommand : ICommand
    {
        private readonly IAccessTokenGenerator generator;
        private readonly SigninState signinState;
        private readonly Output output;

        public event EventHandler? CanExecuteChanged;

        public GetMeCommand(
            IAccessTokenGenerator generator,
            SigninState signinState,
            Output output)
        {
            this.generator = generator;
            this.signinState = signinState;
            this.output = output;

            this.signinState.IsSigninedChanged += handleIsSigninedChanged;
        }

        public bool CanExecute(object parameter) => signinState.IsSignined;

        public async void Execute(object parameter)
        {
            var userRepository = new UserRepository(generator);

            var user = await userRepository.GetMeAsync();

            output.WriteLine($"User:{user}");
        }

        private void handleIsSigninedChanged(object? sender, EventArgs e)
            => CanExecuteChanged?.Invoke(this, EventArgs.Empty);
    }
}
