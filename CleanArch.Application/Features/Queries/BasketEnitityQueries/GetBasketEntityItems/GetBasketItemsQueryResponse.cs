namespace CleanArch.Application.Features.Queries.BasketEnitityQueries.GetBasketEntityItems;

public class GetBasketItemsQueryResponse
{
    public string BasketItemId { get; set; }
    public string Name { get; set; }
    public float Price { get; set; }
    public int Quantity { get; set; }
}
