using Vidly.Core.DAO;
using Vidly.Domain;
using Vidly.TO;

namespace Vidly.Core.BO
{
    public class CustomerBO : BaseBO<long, CustomerTO, CustomerCriteriaTO, Customer>
    {
        public CustomerBO()
        {
            this.DefaultDAO = new CustomerDAO();
        }
    }
}
