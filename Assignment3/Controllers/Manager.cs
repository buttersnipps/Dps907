using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
// new...
using AutoMapper;
using Assignment3.Models;

namespace Assignment3.Controllers
{
    public class Manager
    {
        // Reference to the data context
        private DataContext ds = new DataContext();

        // AutoMapper components
        MapperConfiguration config;
        public IMapper mapper;

        public Manager()
        {
            // If necessary, add your own code here

            // Configure AutoMapper...
            config = new MapperConfiguration(cfg =>
            {
                // Define the mappings below, for example...
                // cfg.CreateMap<SourceType, DestinationType>();
                // cfg.CreateMap<Employee, EmployeeBase>();

                cfg.CreateMap<Models.Invoice, Controllers.InvoiceBase>();

                cfg.CreateMap<Models.Invoice, Controllers.InvoicewithCustomer>();
                cfg.CreateMap<Models.Invoice, Controllers.InvoiceWithInvoiceLine>();
                cfg.CreateMap<Models.InvoiceLine, Controllers.InvoiceWithTrack>();
                cfg.CreateMap<Models.Customer, Controllers.CustomerBase>();
                cfg.CreateMap<Models.Employee, Controllers.EmployeeBase>();
          
                cfg.CreateMap<Models.Employee, Controllers.EmployeeWithAssociations>();
                cfg.CreateMap<Controllers.EmployeeWithAssociations, Controllers.EmployeeWithAssociations2>();
                cfg.CreateMap<Controllers.EmployeeAdd, Models.Employee>();
            });

            mapper = config.CreateMapper();

            // Data-handling configuration

            // Turn off the Entity Framework (EF) proxy creation features
            // We do NOT want the EF to track changes - we'll do that ourselves
            ds.Configuration.ProxyCreationEnabled = false;

            // Also, turn off lazy loading...
            // We want to retain control over fetching related objects
            ds.Configuration.LazyLoadingEnabled = false;
        }

        // Add methods below
        // Controllers will call these methods
        // Ensure that the methods accept and deliver ONLY view model objects and collections
        // The collection return type is almost always IEnumerable<T>

        // Suggested naming convention: Entity + task/action
        // For example:
        // ProductGetAll()
        // ProductGetById()
        // ProductAdd()
        // ProductEdit()
        // ProductDelete()


       //Get All Methods
        public IEnumerable<InvoiceBase> InvoiceGetAll()
        {
            var c = ds.Invoices.Include("Customer.Employee");
            return mapper.Map<IEnumerable<InvoicewithCustomer>>(c);
        }
        public IEnumerable<EmployeeBase> EmployeeGetAll()
        {
            var c = ds.Employees.OrderBy(e => e.LastName).ThenBy(e => e.FirstName);
            return mapper.Map<IEnumerable<EmployeeBase>>(c);
        }

        //Get One Methods
       public InvoiceWithInvoiceLine GetInvoice(int id)
        {
            var c = ds.Invoices.Include("Customer.Employee").Include("InvoiceLines.Track.Album.Artist").Include("InvoiceLines.Track.MediaType").SingleOrDefault(e => e.InvoiceId == id);
            return mapper.Map<InvoiceWithInvoiceLine>(c);
        }

        public EmployeeWithAssociations2 GetEmployee(int id)
        {

            var c = ds.Employees.Include("Employee1").Include("Employee2").Include("Customers").SingleOrDefault(p => p.EmployeeId == id);

            if (c == null)
                return null;

            var a = mapper.Map<EmployeeWithAssociations>(c);

            EmployeeWithAssociations2 result = new EmployeeWithAssociations2();


            result = mapper.Map<EmployeeWithAssociations2>(a);

            result.EmployeeSupervised = a.Employee1;

            result.SupervisorFirstName = a.Employee2FirstName;

            result.SupervisorLastName = a.Employee2LastName;

            return (result == null) ? null : result;

        }
        //Add new Methods

        public EmployeeBase EmployeeAdd(EmployeeAdd newItem)
        {
            if (newItem == null) { return null; }
            else
            {
                Employee addedItem = mapper.Map<Employee>(newItem);
                ds.Employees.Add(addedItem);
                ds.SaveChanges();

                return mapper.Map<EmployeeBase>(addedItem);
            }
        }
        

        public bool LoadData()
        {
            /*
            // Return immediately if there's existing data
            if (ds.[entity collection].Courses.Count() > 0) { return false; }

            // Otherwise, add objects...

            ds.[entity collection].Add(new [whatever] { Property1 = "value", Property2 = "value" });
            */

            return ds.SaveChanges() > 0 ? true : false;
        }

    }
}