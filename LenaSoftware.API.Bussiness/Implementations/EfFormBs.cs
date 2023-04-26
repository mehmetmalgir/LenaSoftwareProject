
using LenaSoftware.API.Bussiness.Contracts;
using LenaSoftware.API.DataAccess.Contracts;
using LenaSoftware.API.Model.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace LenaSoftware.API.Bussiness.Implementations
{
    public class EfFormBs : IFormBs
    {
        private readonly IFormsRepository _repo;
        public EfFormBs(IFormsRepository repo)
        {
            _repo = repo;
        }
      
        public Form AddNewForm(Form entity)
        {
            return _repo.Add(entity);
        }


        public List<Form> GetAllForms(Expression<Func<Form, bool>> filter = null, params string[] includeList)
        {
            return _repo.GetAll(filter, includeList).ToList();
        }

        public Form GetFormById(int id, params string[] includeList)
        {
            return _repo.GetById(id, includeList);
        }
    }
}
