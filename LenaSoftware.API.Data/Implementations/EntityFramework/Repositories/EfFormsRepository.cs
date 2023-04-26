
using LenaSoftware.API.DataAccess.Contracts;
using LenaSoftware.API.DataAccess.Implementations.EntityFramework.Contexts;
using LenaSoftware.API.Model.Entities;
using LenaSoftware.API.Structure.DataAccess.Implementations;
using System;
using System.Collections.Generic;
using System.Text;

namespace LenaSoftware.API.DataAccess.Implementations.EntityFramework.Repositories
{
    public class EfFormsRepository : EfBaseEntityRepository<Form,LenaSoftwareDbContext>,IFormsRepository
    {

    }
}
