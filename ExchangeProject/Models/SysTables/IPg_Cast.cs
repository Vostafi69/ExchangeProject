namespace ExchangeProject.Models.SysTables
{
    public interface IPg_Cast
    {
        int Oid { get; set; }
        int CastSource { get; set; }
        int CastTarget { get; set; }
        int CastFunc { get; set; }
        char CastContext { get; set; }
        char CastMethod { get; set; }
    }
}
