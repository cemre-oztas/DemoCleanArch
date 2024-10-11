namespace CleanArch.Application.DTOs.Order;


//Tüm siparişlerin  listelenmesi için

public class ListOrder
{
    public int TotalOrderCount { get; set; }
    public object Orders { get; set; }
}
