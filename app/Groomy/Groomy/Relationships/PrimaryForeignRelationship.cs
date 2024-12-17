using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Groomy.Relationships
{
    internal class PrimaryForeignRelationship : IRelationship
    {
        public string primaryID;
        public string foreignID;
        public string relationshipFilePath;

        public PrimaryForeignRelationship(string primaryID, string foreignID, string relationshipFilePath)
        {
            this.primaryID = primaryID;
            this.foreignID = foreignID;
            this.relationshipFilePath = relationshipFilePath;
        }

        public string GetFilePath()
        {
            return relationshipFilePath;
        }
        public Dictionary<string, string> GetIDs()
        {
            var ids = new Dictionary<string, string>();
            ids.Add("PrimaryID", primaryID);
            ids.Add("ForeignID", foreignID);
            return ids;
        }
    }
}
