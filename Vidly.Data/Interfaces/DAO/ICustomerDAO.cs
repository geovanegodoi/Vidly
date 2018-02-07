using Vidly.Domain;
using Vidly.TO;

namespace Vidly.Interfaces.DAO
{
    public interface ICustomerDAO : IDAO<long, Customer, CustomerCriteriaTO>
    {

    }
}
