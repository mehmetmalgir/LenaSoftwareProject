using Google.Protobuf.WellKnownTypes;
using LenaSoftware.API.DataAccess.Contracts;
using LenaSoftware.API.DataAccess.Implementations.EntityFramework.Contexts;
using LenaSoftware.API.Model.Entities;
using LenaSoftware.API.Structure.DataAccess.Implementations;
using System;
using System.Collections.Generic;
using System.Text;

namespace LenaSoftware.API.DataAccess.Implementations.EntityFramework.Repositories
{
    public class EfFieldsRepository : EfBaseEntityRepository<LenaSoftware.API.Model.Entities.Fields, LenaSoftwareDbContext>, IFieldsRepository
    {
        
    }
}
