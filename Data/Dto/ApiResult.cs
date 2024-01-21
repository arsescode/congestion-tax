namespace congestion_tax_calculator_net_core.Data.Dto
{
    public class ApiResult<T>
    {

        public bool Status { get; set; }
        public string Message { get; set; }
        
        public T Data { get; set; }
        public new ApiResult<T> Error(string msg)
        {
            Message = msg;
            Status = false;
            return this;
        }
    }
}
