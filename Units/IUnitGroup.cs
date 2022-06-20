using System.Collections.Generic;

namespace ManuscriptsProcessor
{
    public interface IUnitGroup<T> where T: ICorpusUnit
    {
        public List<T> subunits { get; set; }
    }
}
