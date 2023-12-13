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
        private IGenericRepository<Seed> _Seeds;

        public UnitOfWork(AppDB context)
        {
            _context = context;
        }

        public IGenericRepository<Field> Fields => _Fields ??= new GenericRepositroy<Field>(_context);

        public IGenericRepository<Plan> Plans => _Plans ??= new GenericRepositroy<Plan>(_context);

        public IGenericRepository<Seed> Seeds => _Seeds ??= new GenericRepositroy<Seed>(_context);

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
