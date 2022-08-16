using System;
using System.Threading.Tasks;
using VideoSharingService.Data.IRepository;
using VideoSharingService.Data.Models;

namespace VideoSharingService.Data.Repository
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly VidShareDbContext _context;

        private IGenericRepository<User> _users;
        private IGenericRepository<Video> _videos;
        private IGenericRepository<Reaction> _reactions;

        public UnitOfWork(VidShareDbContext context)
        { 
            _context = context;

        }

        public IGenericRepository<User> Users => _users ??=  new GenericRepository<User>(_context);

        public IGenericRepository<Video> Videos => _videos ??= new GenericRepository<Video>(_context);

        public IGenericRepository<Reaction> Reactions => _reactions ??= new GenericRepository<Reaction>(_context);

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
