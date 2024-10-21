namespace CleanArch.Application.DTOs.Order;


//Tüm siparişlerin  listelenmesi için

public class ListOrderEntity
{
    public int TotalOrderCount { get; set; }
    public object Orders { get; set; }
}
