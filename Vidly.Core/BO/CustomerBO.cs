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

        public CustomerViewModel GetViewModel()
        {
            return GetViewModel(0);
        }

        public CustomerViewModel GetViewModel(long id)
        {
            var membershiptypes = Mapper.Map<IEnumerable<MembershipTypeTO>>(this.MembershipTypeDAO.ListAll());
            var customer        = (id == 0) ? new CustomerTO() : Mapper.Map<CustomerTO>(DefaultDAO.Get(id));

            return new ViewModel.CustomerViewModel
            {
                MembershipTypes = membershiptypes,
                Customer        = customer
            };
        }
    }
}
