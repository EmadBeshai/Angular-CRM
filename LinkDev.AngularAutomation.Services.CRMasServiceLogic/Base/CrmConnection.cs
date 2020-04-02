using Microsoft.Crm.Sdk.Messages;
using Microsoft.Xrm.Sdk;
using Microsoft.Xrm.Sdk.Query;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Yagasoft.Libraries.EnhancedOrgService.Helpers;
using Yagasoft.Libraries.EnhancedOrgService.Pools;
using Yagasoft.Libraries.EnhancedOrgService.Services;

namespace LinkDev.AngularAutomation.Services.CRMasServiceLogic.Base
{
    public class CrmConnection : ICrmConnection
    {
        public IOrganizationService OrganizationService;

        public string CrmConnectionString { get; set; }

        // [Sawalhy | 2018-MAY-29 | Changed] integrated the EnhancedOrgService library for more robust control of service
        private static EnhancedServicePool<EnhancedOrgService> servicePool;

        private EnhancedServicePool<EnhancedOrgService> ServicePool =>
            servicePool = servicePool ?? EnhancedServiceHelper.GetPool(CrmConnectionString);
        private bool isTested;


        public void ConnectToCrm(string connectionString)
        {
            CrmConnectionString = connectionString;

            if (!isTested)
            {
                using (var svc = ServicePool.GetService())
                {
                    svc.Execute(new WhoAmIRequest());
                }

                isTested = true;
            }
        }

        public IEnhancedOrgService GetCurrentOrganizationService()
        {
            return servicePool.GetService();
        }



        public Guid Create(Entity entity)
        {
            using (var svc = ServicePool.GetService())
            {
                return svc.Create(entity);
            }
        }

        public Entity Retrieve(string entityName, Guid id, ColumnSet columnSet)
        {
            using (var svc = ServicePool.GetService())
            {
                return svc.Retrieve(entityName, id, columnSet);
            }
        }

        public void Update(Entity entity)
        {
            using (var svc = ServicePool.GetService())
            {
                svc.Update(entity);
            }
        }
        public void Delete(string entityName, Guid id)
        {
            using (var svc = ServicePool.GetService())
            {
                svc.Delete(entityName, id);
            }
        }

        public OrganizationResponse Execute(OrganizationRequest request)
        {
            using (var svc = ServicePool.GetService())
            {
                return svc.Execute(request);
            }
        }

        public void Associate(string entityName, Guid entityId, Relationship relationship, EntityReferenceCollection relatedEntities)
        {
            using (var svc = ServicePool.GetService())
            {
                svc.Associate(entityName, entityId, relationship, relatedEntities);
            }
        }

        public void Disassociate(string entityName, Guid entityId, Relationship relationship, EntityReferenceCollection relatedEntities)
        {
            using (var svc = ServicePool.GetService())
            {
                svc.Disassociate(entityName, entityId, relationship, relatedEntities);
            }
        }



        public EntityCollection RetrieveMultiple(QueryBase query)
        {
            using (var svc = ServicePool.GetService())
            {
                return svc.RetrieveMultiple(query);
            }
        }


    }
}
