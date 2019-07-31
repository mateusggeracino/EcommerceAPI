using System.ComponentModel.DataAnnotations.Schema;

namespace Ecommerce.Domain.Models
{
    [Table("Transactions.vw_PaymentOrder", Schema = "Transactions")]
    public class vw_PaymentOrder : Entity
    {
        public string OrderTotalValue { get; set; }

        public string EndPointName { get; set; }
    }
}
