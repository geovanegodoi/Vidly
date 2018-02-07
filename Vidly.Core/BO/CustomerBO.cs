using AutoMapper;
using System.Collections.Generic;
using Vidly.Core.DAO;
using Vidly.Domain;
using Vidly.Interfaces.BO;
using Vidly.Interfaces.DAO;
using Vidly.TO;
using Vidly.ViewModel;

namespace Vidly.Core.BO
{
    public class CustomerBO : BaseBO<long, CustomerTO, CustomerViewModel, CustomerCriteriaTO, Customer, ICustomerDAO>, ICustomerBO
    {
        private MembershipTypeDAO MembershipTypeDAO = null;

        public CustomerBO()
        {
            this.DefaultDAO        = new CustomerDAO();
            this.MembershipTypeDAO = new MembershipTypeDAO();
        }

        public CustomerViewModel NewCustomerViewModel()
        {
            var membershiptypes = Mapper.Map<IEnumerable<MembershipTypeTO>>(this.MembershipTypeDAO.ListAll());

            return new ViewModel.CustomerViewModel
            {
                MembershipTypes = membershiptypes,
                Customer        = new CustomerTO()
            };
        }
    }
}
