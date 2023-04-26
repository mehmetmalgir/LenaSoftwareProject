
using LenaSoftware.API.Bussiness.Contracts;
using LenaSoftware.API.DataAccess.Contracts;
using LenaSoftware.API.Model.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace LenaSoftware.API.Bussiness.Implementations
{
    public class EfFieldBs : IFieldBs
    {
        private readonly IFieldsRepository _repo;

        public EfFieldBs(IFieldsRepository repo)
        {
            _repo = repo;
        }

        public Fields AddToField(LenaSoftware.API.Model.Entities.Fields entity)
        {
            return _repo.Add(entity);
        }
    }
}
