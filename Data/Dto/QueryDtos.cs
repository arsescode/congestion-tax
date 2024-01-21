namespace congestion_tax_calculator_net_core.Data.Dto
{
    public abstract class PaginationDto
    {
        public int? ItemsPerPage { get; set; }
        public int? PageNo { get; set; }
    }
}
