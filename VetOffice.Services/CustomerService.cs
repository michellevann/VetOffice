using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VetOffice.Data;
using VetOffice.Models;

namespace VetOffice.Services
{
    public class CustomerService
    {
        private readonly Guid _userId;
        public CustomerService(Guid userId)
        {
            _userId = userId;
        }
    
        public bool CreateCustomer(CustomerCreate model)
        {
            var entity = new Customer()
            {
                CustomerId = model.CustomerId,
                FullName = model.FullName,
                StreetAddress = model.StreetAddress,
                City = model.City,
                State = model.State,
                ZipCode = model.ZipCode,
                Phone = model.Phone,
                CanText = model.CanText,
                Email = model.Email
            };
            using (var ctx = new ApplicationDbContext())
            {
                ctx.Customers.Add(entity);
                return ctx.SaveChanges() == 1;
            }
        }

        public IEnumerable<CustomerListItem> GetCustomers()
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query = ctx
                    .Customers
                    .Where(e => e.OwnerId == _userId)
                    .Select(e => new CustomerListItem
                    {
                        CustomerId = e.CustomerId,
                        FullName = e.FullName,
                        StreetAddress = e.StreetAddress,
                        Apt = e.Apt,
                        City = e.City,
                        State = e.State,
                        ZipCode = e.ZipCode,
                        Phone = e.Phone,
                        CanText = e.CanText,
                        Email = e.Email
                    });
                return query.ToArray();
            }
        }

        public CustomerDetail GetCustomerById(int customerId)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity = ctx.Customers.Single(e => e.CustomerId == customerId);
                return new CustomerDetail
                {
                    CustomerId = entity.CustomerId,
                    FullName = entity.FullName,
                    StreetAddress = entity.StreetAddress,
                    Apt = entity.Apt,
                    City = entity.City,
                    State = entity.State,
                    ZipCode = entity.ZipCode,
                    Phone = entity.Phone,
                    CanText = entity.CanText,
                    Email = entity.Email
                };
            }
        }

        public bool UpdateCustomer(CustomerEdit model)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity = ctx
                    .Customers
                    .Single(e => e.CustomerId == model.CustomerId);
                entity.FullName = model.FullName;
                entity.StreetAddress = model.StreetAddress;
                entity.Apt = model.Apt;
                entity.City = model.City;
                entity.State = model.State;
                entity.ZipCode = model.ZipCode;
                entity.Phone = model.Phone;
                entity.CanText = model.CanText;
                entity.Email = model.Email;
                return ctx.SaveChanges() == 1;
            }
        }

        public bool DeleteCustomer(int customerId)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity = ctx
                    .Customers
                    .Single(e => e.CustomerId == customerId);
                ctx.Customers.Remove(entity);
                return ctx.SaveChanges() == 1;
            }
        }
    }
}
