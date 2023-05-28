namespace ExchangeProject.Models.SysTables
{
    public interface IPg_Am
    {
        int Oid { get; set; }
        string Amname { get; set; }
        char Amtype { get; set; }
    }
}
