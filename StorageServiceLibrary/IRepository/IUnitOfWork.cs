using StorageServiceLibrary.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StorageServiceLibrary.IRepository
{
    public interface IUnitOfWork :IDisposable
    {
        IGenericRepository<Field> Fields { get; }
        IGenericRepository<Plan> Plans { get; }
        IGenericRepository<Category> Categorys { get; }
        IGenericRepository<ReproMaterial> ReproMaterials { get; }
      

        Task Save();

    }
}
