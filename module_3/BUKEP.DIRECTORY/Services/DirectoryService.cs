using BUKEP.DATA.Db;
using BUKEP.DIRECTORY.Db;
using System.Collections.Generic;
using System.Linq;

namespace BUKEP.DIRECTORY
{
    public class DirectoryService : IDirectoryService
    {
        private readonly IDataSourceService _sourceService;
        private readonly IDbRepository<DirectoryEntity> _directoryRepo;

        public DirectoryService(IDbRepository<DirectoryEntity> directoryRepo, IDataSourceService sourceService)
        {
            _directoryRepo = directoryRepo;
            _sourceService = sourceService;
        }

        /// <inheritdoc/>
        public Directory Add(string title, int sourceId, long accessObjectId)
        {
            var entity = new DirectoryEntity
            {
                Title = title,
                DataSourceId = sourceId,
                AccessObjectId = accessObjectId
            };

            _directoryRepo.Add(entity);

            var directory = new Directory
            {
                Id = entity.Id,
                Title = entity.Title,
                AccessObjectId = entity.AccessObjectId
            };

            return directory;
        }

        /// <inheritdoc/>
        public void Delete(int id)
        {
            _directoryRepo.Remove(i => i.Id == id);
        }

        /// <inheritdoc/>
        public IEnumerable<Directory> Get()
        {
            var sources = _sourceService.Get();
            var entities = _directoryRepo.Table.ToList();

            var directories = entities.Select(i => new Directory
            {
                Id = i.Id,
                AccessObjectId = i.AccessObjectId,
                Title = i.Title,
                Source = sources.First(s => s.Id == i.DataSourceId)
            }).ToList();

            return directories;
        }

        /// <inheritdoc/>
        public Directory Get(int id)
        {
            return Get().FirstOrDefault(i => i.Id == id);
        }
    }
}
