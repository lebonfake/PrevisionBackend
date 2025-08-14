using PrevisionBackend.DTO;
using PrevisionBackend.Models;
using PrevisionBackend.Repositories;

namespace PrevisionBackend.Service
{
    public class SystemVersionService
    {
        public SystemVersionRepository systemVersionRepository { get; set; }
        public SystemVersionService(SystemVersionRepository systemVersionRepository) { 
            this.systemVersionRepository = systemVersionRepository;
        }

        public async Task<SystemVersionReadDto> CreateSystemVersionAsync(SystemVersionCreateDto dto)
        {
            SystemVersion systemVersion = FromCreateToSystem(dto);
          await systemVersionRepository.createSystemVersionAsync(systemVersion);
            SystemVersion created = await systemVersionRepository.GetByIdAsync(systemVersion.Id);
            return FromSystemToRead(created);
        }

        public async Task<List<SystemVersionReadDto>> GetAllAsync()
        {
            List<SystemVersion> list = await systemVersionRepository.GetAllAsync();

            return list.Select(f => FromSystemToRead(f)).ToList();
        }


        public SystemVersion FromCreateToSystem(SystemVersionCreateDto systemVersionCreateDto) {

            SystemVersion systemVersion = new SystemVersion
            {
                Nom = systemVersionCreateDto.Nom,
                Versions = new List<Models.Version>()

            };

            Console.WriteLine(systemVersionCreateDto.VersionCreateDtos.Count);

            foreach(var version in systemVersionCreateDto.VersionCreateDtos)
            {
                var v  = new Models.Version
                {
                    Name = version.Name,
                    StartDay= version.StartDay,
                    EndDay= version.EndDay,
                    SystemVersion=systemVersion,

                };
                systemVersion.Versions.Add(v); 
                
            };

            return systemVersion;
            
        }

        public  SystemVersionReadDto FromSystemToRead(Models.SystemVersion systemVersion) // Utiliser Models.SystemVersion pour éviter l'ambiguïté si nécessaire
        {
            if (systemVersion == null)
            {
                return null;
            }

            return new SystemVersionReadDto
            {
                Id = systemVersion.Id,
                Name = systemVersion.Nom, // Mappe 'Nom' du modèle à 'Name' du DTO
                VersionReadDtos = systemVersion.Versions? // Vérifie si la collection Versions est chargée
                    .Select(v => new VersionReadDto // Mappe chaque Version du modèle à VersionReadDto
                    {
                        Id = v.Id,
                        Name = v.Name,
                        StartDay = v.StartDay,
                        EndDay = v.EndDay
                    })
                    .ToList() // Convertit la sélection en liste
                    ?? new List<VersionReadDto>() // Fournit une liste vide si Versions est null
            };
        }
    }
}
