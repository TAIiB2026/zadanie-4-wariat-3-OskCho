using Contracts;
using Contracts.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Memory
{
    public class FormSubmitService : IFormSubmitInterface
    {
        private static readonly List<DataDTO> _formDataList = new();

        public FormSubmitService()
        {
            if (!_formDataList.Any())
            {
                _formDataList.Add(new DataDTO(1, "TestowyUzytkownik", "Angular"));
                _formDataList.Add(new DataDTO(2, "TestowyUzytkownik2", "Angular2"));
            }
        }

        public Task<bool> AddDataAsync(DataDTO dataDTO)
        {
            _formDataList.Add(dataDTO);
            return Task.FromResult(true);
        }

        public Task<bool> EditDataAsync(int id, DataDTO dataDTO)
        {
            var existingData = _formDataList.FirstOrDefault(d => d.ID == id);

            if (existingData != null)
            {
                _formDataList.Remove(existingData);

                _formDataList.Add(dataDTO with { ID = id });

                return Task.FromResult(true);
            }

            return Task.FromResult(false);
        }
    }
}
