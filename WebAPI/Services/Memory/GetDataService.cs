using Contracts;
using Contracts.DTOs;

namespace Services.Memory
{
    public class GetDataService : IGetDataInterface
    {
        public Task<IEnumerable<MovieDTO>> GetMoviesAsync()
        {
            var movies = new List<MovieDTO>
            {
                new MovieDTO(1, "Incepcja"),
                new MovieDTO(2, "Interstellar"),
                new MovieDTO(3, "Matrix")
            };

            return Task.FromResult<IEnumerable<MovieDTO>>(movies);
        }

        public Task<FormDataDTO> GetFormDataAsync()
        {
            var formData = new FormDataDTO("Student_Stanowisko_11", "Angular");
            return Task.FromResult(formData);
        }
    }
}