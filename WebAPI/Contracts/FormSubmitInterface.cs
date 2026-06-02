using Contracts.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contracts
{
    public interface IFormSubmitInterface
    {
        Task<bool> AddDataAsync(DataDTO dataDTO);
        Task<bool> EditDataAsync(int id, DataDTO dataDTO);
    }
}
