using System.Collections.Generic;

namespace ppedv.Cooky.Model.Contracts
{
    public interface IRezeptRepository: IBaseRepository<Rezept>
    {
        IEnumerable<Rezept> GetAllRezepteWithZuaten();
    }
}
