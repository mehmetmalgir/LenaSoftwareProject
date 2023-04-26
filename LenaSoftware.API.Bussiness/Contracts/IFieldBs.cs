
using LenaSoftware.API.DataAccess.Contracts;
using LenaSoftware.API.Model.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace LenaSoftware.API.Bussiness.Contracts
{
    public interface IFieldBs
    {
       Fields AddToField(Fields entity);
       
    }
}
