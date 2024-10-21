using CleanArch.Domain.Entities;


namespace CleanArch.Application.Abstractions.Services
{
    public interface IBasketEntityService
    {
        public Task<List<BasketItemEntity>> GetBasketItemsAsync();
        public Task AddItemToBasketAsync(ViewModels.BasketEntities.VM_Create_BasketItemEntity basketItem);
        public Task UpdateQuantityAsync(ViewModels.BasketEntities.VM_Update_BasketItemEntity basketItem);
        public Task RemoveBasketItemAsync(string basketItemId);
        public BasketEntity? GetUserActiveBasket { get; }
    }
}