
using LenaSoftware.API.Model.Entities;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace LenaSoftware.API.Bussiness.Contracts
{
    public interface IFormBs
    {
        List<Form> GetAllForms(Expression<Func<Form, bool>> filter = null, params string[] includeList);
        Form GetFormById(int id,params string[] includeList);
        Form AddNewForm(Form entity);

    }
}
