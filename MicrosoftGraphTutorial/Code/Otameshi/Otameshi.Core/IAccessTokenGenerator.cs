using System.Threading.Tasks;

namespace Otameshi.Core
{
    public interface IAccessTokenGenerator
    {
        Task<string> GenerateAsync();
    }
}
