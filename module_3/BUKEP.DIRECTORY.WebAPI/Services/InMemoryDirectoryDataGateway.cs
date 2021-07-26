using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BUKEP.DIRECTORY.WebAPI.Services
{
    public class InMemoryDirectoryDataGateway : IDirectoryDataGateway
    {
        private static Dictionary<int, List<DataRow>> StateInMemory;

        private Directory Directory { get; }

        public InMemoryDirectoryDataGateway(Directory directory)
        {
            Directory = directory;

            if (StateInMemory == null)
            {
                StateInMemory = new Dictionary<int, List<DataRow>>();
            }
        }

        public void Add(DataRow dataRow)
        {
            if (!StateInMemory.ContainsKey(Directory.Id))
            {
                StateInMemory.Add(Directory.Id, new List<DataRow>());
            }

            StateInMemory[Directory.Id].Add(dataRow);
        }

        public void Delete(DataRow dataRow)
        {
            if (StateInMemory.ContainsKey(Directory.Id))
            {

            }
        }

        public List<DataRow> Get(List<DataField> dataFields)
        {
            if (StateInMemory.ContainsKey(Directory.Id))
            {

            }

            return new List<DataRow>();
        }

        public void Update(DataRow dataRow)
        {
            if (StateInMemory.ContainsKey(Directory.Id))
            {

            }
        }

        public List<DataRow> Get()
        {
            if (StateInMemory.ContainsKey(Directory.Id))
            {
                return StateInMemory[Directory.Id];
            }

            return new List<DataRow>();
        }
    }
}
