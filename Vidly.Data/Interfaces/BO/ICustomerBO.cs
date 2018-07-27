using Vidly.TO;
using Vidly.ViewModel;

namespace Vidly.Interfaces.BO
{
    public interface ICustomerBO : IBO<long, CustomerTO, CustomerViewModel, CustomerCriteriaTO>
    {
        CustomerTO ValidateCustomer(CustomerTO model);
    }
}
