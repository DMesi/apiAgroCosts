using Microsoft.AspNetCore.Identity;
using StorageServiceLibrary.IRepository;
using StorageServiceLibrary.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StorageServiceLibrary.Repository
{
    internal class UnitOfWork : IUnitOfWork
    {
        private readonly AppDB _context;

        private IGenericRepository<Field> _Fields;
        private IGenericRepository<Plan> _Plans;
        private IGenericRepository<Category> _Categories;
        private IGenericRepository<ReproMaterial> _Repromaterials;
        private IGenericRepository<IdentityUser> _Users;
        private IGenericRepository<IdentityRole> _Role;

       
        public UnitOfWork(AppDB context)
        {
            _context = context;
        }

        public IGenericRepository<Field> Fields => _Fields ??= new GenericRepositroy<Field>(_context);

        public IGenericRepository<Plan> Plans => _Plans ??= new GenericRepositroy<Plan>(_context);


        public IGenericRepository<ReproMaterial> ReproMaterials => _Repromaterials ??= new GenericRepositroy<ReproMaterial>(_context);

        public IGenericRepository<Category> Categorys => _Categories ??= new GenericRepositroy<Category>(_context);

        public IGenericRepository<IdentityUser> Users => _Users ??= new GenericRepositroy<IdentityUser>(_context);
     
        public IGenericRepository<IdentityRole> Role => _Role ??= new GenericRepositroy<IdentityRole> (_context);

        

        public void Dispose()
        {
            _context.Dispose();
            GC.SuppressFinalize(this);

        }

        public async Task Save()
        {
            await _context.SaveChangesAsync();
        }
    }
}
