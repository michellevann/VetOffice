using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VetOffice.Data;
using VetOffice.Models;

namespace VetOffice.Services
{
    public class PetService
    {
        private readonly Guid _userId;
        public PetService(Guid userId)
        {
            _userId = userId;
        }

        public bool CreatePet(PetCreate model)
        {
            var entity = new Pet()
            {
                OwnerId = _userId,
                PetName = model.PetName,
                TypeOfPet = model.TypeOfPet,
                AgeOfPet = model.AgeOfPet,
                ReasonForVisit = model.ReasonForVisit
            };
            using (var ctx = new ApplicationDbContext())
            {
                ctx.Pets.Add(entity);
                return ctx.SaveChanges() == 1;
            }
        }

        public IEnumerable<PetListItem> GetPets()
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query = ctx
                    .Pets
                    .Where(e => e.OwnerId == _userId)
                    .Select(e => new PetListItem
                    {
                        PetId = e.PetId,
                        PetName = e.PetName,
                        TypeOfPet = e.TypeOfPet,
                        AgeOfPet = e.AgeOfPet,
                        ReasonForVisit = e.ReasonForVisit
                    });
                return query.ToArray();
            }
        }

        public PetDetail GetPetById(int petId)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity = ctx
                    .Pets
                    .Single(e => e.PetId == petId && e.OwnerId == _userId);
                return new PetDetail
                {
                    PetId = entity.PetId,
                    PetName = entity.PetName,
                    TypeOfPet = entity.TypeOfPet,
                    AgeOfPet = entity.AgeOfPet,
                    ReasonForVisit = entity.ReasonForVisit
                };
            }
        }

        public bool UpdatePet(PetEdit model)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity = ctx
                    .Pets
                    .Single(e => e.PetId == model.PetId && e.OwnerId == _userId);
                entity.PetName = model.PetName;
                entity.TypeOfPet = model.TypeOfPet;
                entity.AgeOfPet = model.AgeOfPet;
                entity.ReasonForVisit = model.ReasonForVisit;
                return ctx.SaveChanges() == 1;
            }
        }
    }
}
