namespace CleanArch.Application.DTOs.Order;


//Yeni bir sipariş oluşturmak için gerekli alan

public class CreateOrderEntity
{
    public string? BasketId { get; set; }
    public string? Description { get; set; }
    public string? Address { get; set; }
}