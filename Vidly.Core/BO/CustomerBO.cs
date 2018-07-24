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
    public class CustomerBO : BaseBO<long, CustomerTO, CustomerViewModel, CustomerCriteriaTO, Customer, ICustomerDAO>, ICustomerBO
    {
        private IMembershipTypeDAO MembershipTypeDAO = null;
        private IPermissionDAO PermissionDAO = null;

        public CustomerBO()
        {
            this.DefaultDAO = new CustomerDAO();
            this.MembershipTypeDAO = new MembershipTypeDAO();
            this.PermissionDAO = new PermissionDAO();
        }

        public override CustomerTO CreateModelInstance()
        {
            return new CustomerTO();
        }

        public CustomerViewModel GetViewModel()
        {
            return GetViewModel(0);
        }

        public CustomerViewModel GetViewModel(long id)
        {
            var membershiptypes = Mapper.Map<IEnumerable<MembershipTypeTO>>(this.MembershipTypeDAO.GetAll());
            var customer = (id == 0) ? new CustomerTO() : Mapper.Map<CustomerTO>(DefaultDAO.Get(id));

            return new ViewModel.CustomerViewModel
            {
                MembershipTypes = membershiptypes,
                Customer = customer
            };
        }

        public CustomerTO ValidateCustomer(CustomerTO model)
        {
            CustomerTO retObj = null;
            var criteria      = Mapper.Map<CustomerCriteriaTO>(model);
            var domain        = DefaultDAO.Search(criteria);

            if (domain.Any())
            {
                var domainCustomer = domain.First();
                var permissions    = GetPermissions(domainCustomer.RoleId);
                retObj             = Mapper.Map<CustomerTO>(domainCustomer);
                retObj.Permissions = permissions;
            }
            return retObj;
        }

        private IEnumerable<PermissionTO> GetPermissions(long roleId)
        {
            var domain = PermissionDAO.Search(new PermissionCriteriaTO { RoleId = roleId });

            if (!domain.Any())
                throw new AccessViolationException("Error getting user permissions");

            return Mapper.Map<IEnumerable<PermissionTO>>(domain);
        }
    }
}