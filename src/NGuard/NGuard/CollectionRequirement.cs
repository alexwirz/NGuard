using System;
using System.Collections.Generic;
using System.Linq;

namespace NGuard
{
    public class CollectionRequirement
    {
        private readonly string _description;
        private readonly IEnumerable<object> _collection;

        public CollectionRequirement(string requirementDescription, IEnumerable<object> collection)
        {
            if (requirementDescription == null) throw new ArgumentNullException("requirementDescription");
            if (collection == null) throw new ArgumentNullException("collection");
            _description = requirementDescription;
            _collection = collection;
        }

        public void IsNotEmpty()
        {
            Requirement.AssertIsTrue(_collection.Any(), _description);
        }
    }
}
