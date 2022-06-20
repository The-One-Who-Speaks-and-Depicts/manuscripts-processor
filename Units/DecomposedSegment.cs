using System.Collections.Generic;

namespace ManuscriptsProcessor
{
    public record DecomposedSegment
    {
        public string clause {get; init;}
        public List<DecomposedToken> tokens {get; init;}
    }
}
