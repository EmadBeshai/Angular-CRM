using Microsoft.Xrm.Sdk;
using Microsoft.Xrm.Sdk.Query;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Yagasoft.Libraries.EnhancedOrgService.Services;

namespace LinkDev.AngularAutomation.Services.CRMasServiceLogic.Base
{
    public interface ICrmConnection
    {
        string CrmConnectionString { get; set; }

        // [Sawalhy | 2018-MAY-29 | Removed] the return value to avoid using services outside of the pool
        void ConnectToCrm(string connectionString);
        IEnhancedOrgService GetCurrentOrganizationService();
        Guid Create(Entity entity);

        /// <summary>
        /// Retrieves a record from the CRM organization, if the specified ID is not found, returns null.
        /// </summary>
        /// <param name="entityName">Type: <see cref="https://msdn.microsoft.com/library/system.string.aspx">String</see>. The logical name of the entity that is specified in the <paramref name="entityId">entityId</paramref> parameter.</param>
        /// <param name="id">Type: <see cref="https://msdn.microsoft.com/library/system.guid.aspx">Guid</see>. The ID of the record that you want to retrieve.</param>
        /// <param name="columnSet">Type: <see cref="T:Microsoft.Xrm.Sdk.Query.ColumnSet"></see>. A query that specifies the set of columns, or attributes, to retrieve. </param>
        /// <returns>Type: <see cref="Microsoft.Xrm.Sdk.Entity"></see>
        /// The requested entity.</returns>
        Entity Retrieve(string entityName, Guid id, ColumnSet columnSet);
        void Update(Entity entity);
        void Delete(string entityName, Guid id);
        OrganizationResponse Execute(OrganizationRequest request);
        void Associate(string entityName, Guid entityId, Relationship relationship, EntityReferenceCollection relatedEntities);

        void Disassociate(string entityName, Guid entityId, Relationship relationship,
            EntityReferenceCollection relatedEntities);

        EntityCollection RetrieveMultiple(QueryBase query);
    }
}
