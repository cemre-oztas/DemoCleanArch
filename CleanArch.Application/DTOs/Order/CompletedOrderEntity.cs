namespace CleanArch.DTOs.Order;


//Tamamlanmış siparişlerin durumu


public class CompletedOrderEntityDTO
{
    public string OrderEntityCode { get; set; }
    public DateTime OrderDate { get; set; }
    public string Username { get; set; }
    public string EMail { get; set; }
}