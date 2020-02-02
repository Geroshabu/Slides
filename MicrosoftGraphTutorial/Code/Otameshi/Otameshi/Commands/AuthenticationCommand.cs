using System;
using System.Windows.Input;
using Otameshi.Authentication;
using Otameshi.Core;

namespace Otameshi.Commands
{
    class AuthenticationCommand : ICommand
    {
        private readonly IAccessTokenGenerator generator;
        private readonly SigninState signinState;
        private readonly Output output;

        public event EventHandler? CanExecuteChanged;

        public AuthenticationCommand(
            IAccessTokenGenerator generator,
            SigninState signinState,
            Output output)
        {
            this.generator = generator;
            this.signinState = signinState;
            this.output = output;
        }

        public bool CanExecute(object parameter) => true;

        public async void Execute(object parameter)
        {
            var accessToken = await generator.GenerateAsync();

            signinState.IsSignined = true;

            output.WriteLine(accessToken);
        }
    }
}
