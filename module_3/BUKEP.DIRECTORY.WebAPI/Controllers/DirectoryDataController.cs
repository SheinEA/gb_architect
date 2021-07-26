using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using BUKEP.DIRECTORY;
using BUKEP.DIRECTORY.WebAPI.ViewModels;
using BUKEP.DIRECTORY.WebAPI.Services;
using System.Linq;
using Microsoft.Extensions.Logging;

namespace BUKEP.DIRECTORY.WebAPI.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class DirectoryDataController : ControllerBase
    {
        private readonly ILogger<DirectoryDataController> _logger;

        public DirectoryDataController(ILogger<DirectoryDataController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        public IEnumerable<DataRowViewModel> Get(int directoryNumber)
        {
            // Получать из БД по id
            var directory = new Directory() { Id = directoryNumber };
            // Строить на основе провайдера
            IDirectoryDataGateway dataGateway = new InMemoryDirectoryDataGateway(directory);
            // Преобразовывать мапером
            var data = dataGateway.Get()
                .Select(r => new DataRowViewModel()
                {
                    Fields = r.Fields.Select(f => new DataFieldViewModel()
                    {
                        Name = f.Field.Name,
                        Value = f.Value.ToString()
                    }).ToList()
                });

            return data;
        }

        [HttpPost]
        [Route("Add")]
        public DataRowViewModel Add(int directoryNumber, DataRowViewModel dataRow)
        {
            // Получать из БД по id
            var directory = new Directory() { Id = directoryNumber };
            // Строить на основе провайдера
            IDirectoryDataGateway dataGateway = new InMemoryDirectoryDataGateway(directory);
            // Преобразовывать мапером
            var row = new DataRow()
            {
                Fields = dataRow.Fields.Select(f => new DataField()
                {
                    Value = f.Value,
                    Field = new Field() { Name = f.Name }
                }).ToList()
            };

            try
            {
                dataGateway.Add(row);
                return dataRow;
            }
            catch (System.Exception)
            {
                throw;
            }
        }
    }
}
 