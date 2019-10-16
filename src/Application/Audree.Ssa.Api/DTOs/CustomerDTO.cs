
namespace Audree.Ssa.Api.DTOs
{
    public class CustomerDTO
    {
        public int Id { get; set; }

        public string CustomerName { get; set; }
     
        public string CustomerCode { get; set; }
      
        public string CustomerAddress1 { get; set; }
        public string CustomerAddress2 { get; set; }
        public int? Status { get; set; }
    }
}
