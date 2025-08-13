using PrevisionBackend.DTO;
using PrevisionBackend.Models;
using PrevisionBackend.Repositories;

namespace PrevisionBackend.Service
{
    public class ValidateurService
    {

        private ValidateurRepository _validateurRepository;
        private UserRepository _userRepository;
        public ValidateurService(ValidateurRepository validateurRepository, UserRepository userRepository)
        {
            _validateurRepository = validateurRepository;
            _userRepository = userRepository;
        }

        // Méthode pour obtenir tous les validateurs
        // Nouvelle méthode pour récupérer tous les validateurs
        public async Task<List<ValidateurReadDto>> GetAllValidateursAsync()
        {
            // IMPORTANT : Le repository doit inclure les données User (via .Include)
            var validateurs = await _validateurRepository.GetAllValidateursAsync();

            // Utilise la méthode mapper existante pour la cohérence
            return validateurs.Select(v => MapToValidateurReadDto(v)).ToList();
        }


        //Métode pour ajouter un nouveau validateur 
        public async Task<ValidateurReadDto> AddValidateurAsync(ValidateurCreateDto validateurCreateDto)
        {
            // Vérifier si l'utilisateur existe
            var user = await _userRepository.GetUserByIdAsync(validateurCreateDto.UserId);
            if (user == null)
            {
                throw new Exception("User not found");
            }

            var existingValidateur = await _validateurRepository.GetValidateurByUserIdAsync(user.UserID);
            if (existingValidateur!=null)
            {
                return null;
            }
            // Créer un nouvel objet Validateur
            var validateur = new Validateur
            {
                User = user,

            };
            // Ajouter le validateur à la base de données
            var createdValidateur = await _validateurRepository.AddValidateurAsync(validateur);
            // Retourner le DTO du validateur créé
            return MapToValidateurReadDto(createdValidateur);
        }
        // Récupère un Validateur par son ID et le mappe en DTO de lecture
        public async Task<ValidateurReadDto> GetValidateurByIdAsync(int id)
        {
            var validateur = await _validateurRepository.GetValidateurByIdAsync(id);
            if (validateur == null)
            {
                return null;
            }
            return MapToValidateurReadDto(validateur);
        }

        public async Task<bool> DeleteValidateurByIdAsync(int id)
        {
          return  await _validateurRepository.DeleteValidatuerByIdAsync(id);
            


        }


      private ValidateurReadDto MapToValidateurReadDto(Validateur validateur)
        {
            return new ValidateurReadDto
            {
                Id = validateur.Id,
                // Accède aux propriétés de l'utilisateur via la propriété de navigation User.
                // Le '?' (opérateur de navigation conditionnelle) assure qu'il n'y a pas d'erreur
                // si l'objet User n'a pas été chargé (est null).
                FirstName = validateur.User?.FirstName,
                LastName = validateur.User?.LastName
            };
        }

        
    }
    }

