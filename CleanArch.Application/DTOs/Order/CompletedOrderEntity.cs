﻿namespace DemoCleanArch.DTOs.Order;


//Tamamlanmış siparişlerin durumu


public class CompletedOrderEntityDTO
{
    public string OrderCode { get; set; }
    public DateTime OrderDate { get; set; }
    public string Username { get; set; }
    public string EMail { get; set; }
}