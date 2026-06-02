using Contracts.DTOs;

namespace Contracts
{
    public interface IGetDataInterface
    {
        Task<IEnumerable<MovieDTO>> GetMoviesAsync();
        Task<FormDataDTO> GetFormDataAsync();
    }
}
