using System;
using System.Threading.Tasks;

namespace WC.Context.Configurations
{
    public interface IUnitOfWork
    {
        Task Save();
    }
    
    public class UnitOfWork : IDisposable, IUnitOfWork {
        private WildCrittersDBContext context = null;
        private bool disposed = false;

        public UnitOfWork(WildCrittersDBContext context) {
            this.context = context;
        }

        public void Dispose() {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        public void Dispose(bool disposing) {
            if (!this.disposed) {
                if (disposing) {
                    context.Dispose();
                }
            }

            this.disposed = true;
        }

        public async Task Save() {
            await context.SaveChangesAsync();
        }
    }
}