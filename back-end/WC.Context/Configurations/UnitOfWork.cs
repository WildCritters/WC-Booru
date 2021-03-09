using System;
using System.Threading.Tasks;
using WC.Model.Entity;

namespace WC.Context.Configurations
{
    public interface IUnitOfWork
    {
        Task Save();
    }

    public class UnitOfWork : IDisposable, IUnitOfWork
    {
        private WildCrittersDBContext context = null;
        private bool disposed = false;

        private WildCrittersRepository<Function> _functionRepository;
        private WildCrittersRepository<Role> _roleRepository;
        private WildCrittersRepository<User> _userRepository; 

        public WildCrittersRepository<Function> functionRepository
        {
            get
            {
                if (this._functionRepository == null)
                {
                    this._functionRepository = new WildCrittersRepository<Function>(context);
                }
                return this._functionRepository;
            }
        }

        public WildCrittersRepository<Role> roleRepository
        {
            get
            {
                if(this._roleRepository == null)
                {
                    this._roleRepository = new WildCrittersRepository<Role>(context);
                }
                return this._roleRepository;
            }
        }

        public WildCrittersRepository<User> userRepository
        {
            get
            {
                if(this._userRepository == null)
                {
                    this._userRepository = new WildCrittersRepository<User>(context);
                }
                return this._userRepository;
            }
        }

        public UnitOfWork(WildCrittersDBContext context)
        {
            this.context = context;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        public void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    context.Dispose();
                }
            }

            this.disposed = true;
        }

        public async Task Save()
        {
            await context.SaveChangesAsync();
        }
    }
}