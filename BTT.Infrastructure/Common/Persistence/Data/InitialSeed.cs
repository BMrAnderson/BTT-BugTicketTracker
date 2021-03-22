using BTT.Domain.Models.Issues;
using BTT.Domain.Models.Members;
using BTT.Domain.Models.Organizations;
using BTT.Domain.Models.Projects;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BTT.Infrastructure.Common.Persistence.Data
{
    public static class InitialSeed
    {
        public static Organization CreateOrganizationData()
        {
            var organization = new Organization("Oodah Advisory");
            var project = new Project(organization, "CMS 1.0", "Content Management System v1.0", DateTimeOffset.Now.AddMonths(5));


            return organization;
        }
    }
}
