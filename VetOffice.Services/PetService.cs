using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VetOffice.Contracts;
using VetOffice.Data;
using VetOffice.Models;

namespace VetOffice.Services
{
    public class PetService : IPetService
    {
        private readonly Guid _userId;
        public PetService(Guid userId)
        {
            _userId = userId;
        }

        public bool CreatePet(PetCreate model)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var customer = ctx

                    .Customers
                    .Single(x => x.CustomerId == model.CustomerId);

                var entity = new Pet
                {
                    PetId = model.PetId,
                    CustomerId = model.CustomerId,
                    Customer = customer,
                    PetName = model.PetName,
                    TypeOfPet = model.TypeOfPet,
                    Breed = model.Breed,
                    AgeOfPet = model.AgeOfPet
                };

                ctx.Pets.Add(entity);
                return ctx.SaveChanges() == 1;
            }
        }

        public IEnumerable<InfoListItem> GetPets()
        {
            List<InfoListItem> infoListItems = new List<InfoListItem>();
            List<int> customerIds = new List<int>();
            using (var ctx = new ApplicationDbContext())
            {
                foreach (var pet in ctx.Pets)
                {
                    if (!customerIds.Contains(pet.CustomerId))
                    {
                        customerIds.Add(pet.CustomerId);
                    }
                }
                foreach (var id in customerIds)
                {
                    var query = ctx
                        .Customers
                        .Single(e => e.CustomerId == id);
                    infoListItems.Add(new InfoListItem
                    {
                        CustomerId = id,
                        FullName = query.FullName,
                        Pets = GetCustomerPetsById(id).ToList()
                    });
                }
                return infoListItems;
            }
        }

        public IEnumerable<PetListItem> GetCustomerPetsById(int customerId)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query = ctx
                   .Pets
                   .Where(e => e.CustomerId == customerId)
                   .Select(e => new PetListItem
                   {
                       PetId = e.PetId,
                       PetName = e.PetName,
                       TypeOfPet = e.TypeOfPet,
                       Breed = e.Breed,
                       AgeOfPet = e.AgeOfPet
                   });
                return query.ToList();
            }
        }

        public PetDetail GetPetById(int petId)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity = ctx.Pets.Single(e => e.PetId == petId);
                return new PetDetail
                {
                    PetId = entity.PetId,
                    CustomerId = entity.CustomerId,
                    Customer = entity.Customer,
                    PetName = entity.PetName,
                    TypeOfPet = entity.TypeOfPet,
                    Breed = entity.Breed,
                    AgeOfPet = entity.AgeOfPet
                };
            }
        }

        public bool UpdatePet(PetEdit model)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity = ctx
                    .Pets
                    .Single(e => e.PetId == model.PetId);
                entity.PetName = model.PetName;
                entity.TypeOfPet = model.TypeOfPet;
                entity.Breed = model.Breed;
                entity.AgeOfPet = model.AgeOfPet;
                return ctx.SaveChanges() == 1;
            }
        }

        public bool DeletePet(int petId)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity = ctx
                    .Pets
                    .Single(e => e.PetId == petId);
                ctx.Pets.Remove(entity);
                return ctx.SaveChanges() == 1;
            }
        }
    }
}
