using System.Data.Entity;

namespace ScLookup.Models.Context
{
    public interface IContext
    {
        IDbSet<Unit> Units { get; }
    }
}
