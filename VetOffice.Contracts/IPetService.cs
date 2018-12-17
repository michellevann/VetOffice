using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VetOffice.Models;

namespace VetOffice.Contracts
{
    public interface IPetService
    {
        bool CreatePet(PetCreate model);
        IEnumerable<InfoListItem> GetPets();
        IEnumerable<PetListItem> GetCustomerPetsById(int customerId);
        PetDetail GetPetById(int petId);
        bool UpdatePet(PetEdit model);
        bool DeletePet(int petId);
    }
}
