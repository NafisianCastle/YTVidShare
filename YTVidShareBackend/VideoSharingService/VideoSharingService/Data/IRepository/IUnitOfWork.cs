using System;
using System.Threading.Tasks;
using VideoSharingService.Data.Models;

namespace VideoSharingService.Data.IRepository
{
    public interface IUnitOfWork : IDisposable
    {
        IGenericRepository<User> Users {get;}
        IGenericRepository<Video> Videos {get;}
        IGenericRepository<Reaction> Reactions {get;}

        Task Save();
    }
}
