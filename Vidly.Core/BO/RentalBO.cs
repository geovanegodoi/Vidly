using AutoMapper;
using System.Linq;
using System.Collections.Generic;
using Vidly.Core.DAO;
using Vidly.Interfaces.BO;
using Vidly.TO;
using Vidly.ViewModel;
using System;
using Vidly.Core.Domain;

namespace Vidly.Core.BO
{
    public class RentalBO : BaseBO<long, RentalTO, RentalCriteriaTO, Rental, IRentalDAO>, IRentalBO
    {
        public RentalBO()
        {
            this.DefaultDAO = new RentalDAO();
        }
    }
}