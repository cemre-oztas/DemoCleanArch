using CleanArch.Application.Abstractions.Services;
using CleanArch.Application.Repositories.BasketItem;
using CleanArch.Application.Repositories.BasketRepository;
using CleanArch.Application.Repositories.Order;
using CleanArch.Domain.Entities;
using CleanArch.Domain.Entities.Identity;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace CleanArch.Persistence.Services

{
    public class BasketEntityService : IBasketEntityService
    {
        readonly UserManager<AppUser> _userManager;
        readonly IOrderEntityReadRepository _orderReadRepository;
        readonly IBasketEntityWriteRepository _basketWriteRepository;
        readonly IBasketEntityReadRepository _basketReadRepository;
        readonly IBasketItemEntityWriteRepository _basketItemWriteRepository;
        readonly IBasketItemEntityReadRepository _basketItemReadRepository;

        private readonly string username;
        public BasketEntityService(
            UserManager<AppUser> userManager,
            IOrderEntityReadRepository orderReadRepository, IBasketEntityWriteRepository basketWriteRepository,
            IBasketItemEntityWriteRepository basketItemWriteRepository,
            IBasketItemEntityReadRepository basketItemReadRepository,
            IBasketEntityReadRepository basketReadRepository)
        {
            _userManager = userManager;
            _orderReadRepository = orderReadRepository;
            _basketWriteRepository = basketWriteRepository;
            _basketItemWriteRepository = basketItemWriteRepository;
            _basketItemReadRepository = basketItemReadRepository;
            _basketReadRepository = basketReadRepository;
            this.username = username;
        }


        private async Task<BasketEntity?> ContextUser(string username)
        {
            if (!string.IsNullOrEmpty(username))
            {
                AppUser? user = await _userManager.Users
                         .Include(u => u.Baskets)
                         .FirstOrDefaultAsync(u => u.NameSurname == username);

                var _basket = from basket in user.Baskets
                              join order in _orderReadRepository.Table
                              on basket.Id equals order.Id into BasketOrders
                              from order in BasketOrders.DefaultIfEmpty()
                              select new
                              {
                                  Basket = basket,
                                  Order = order
                              };

                BasketEntity? targetBasket = null;
                if (_basket.Any(b => b.Order is null))
                    targetBasket = _basket.FirstOrDefault(b => b.Order is null)?.Basket;
                else
                {
                    targetBasket = new();
                    user.Baskets.Add(targetBasket);
                }

                await _basketWriteRepository.SaveAsync();
                return targetBasket;
            }
            throw new Exception("Beklenmeyen bir hatayla karşılaşıldı...");
        }

        public async Task AddItemToBasketAsync(Application.ViewModels.BasketEntities.VM_Create_BasketItemEntity basketItem)
        {
            string username =;
            BasketEntity? basket = await ContextUser(username);

            if (basket != null)
            {
                BasketItemEntity _basketItem = await _basketItemReadRepository.GetSingleAsync(bi => bi.BasketId == basket.Id && bi.ProductId == Guid.Parse(basketItem.BasketId));
                if (_basketItem != null)
                {
                     _basketItem.Quantity++;
                }
                else
                { 
                    var newBasketItem = new BasketItemEntity
                    {
                        BasketId = basket.Id,
                        ProductId = Guid.Parse(basketItem.BasketId),
                        Quantity = basketItem.Quantity
                    };
                }
                await _basketItemWriteRepository.AddAsync(newBasketItemEntity);
            }
             await _basketItemWriteRepository.SaveAsync();
        }

        public async Task<List<BasketItemEntity>> GetBasketItemsAsync()
        {
            BasketEntity? basket = await ContextUser();
            BasketEntity? result = await _basketReadRepository.Table
                 .Include(b => b.BasketItems)
                 .ThenInclude(bi => bi.Product)
                 .FirstOrDefaultAsync(b => b.Id == basket.Id);

            return result.BasketItems
                .ToList();
        }

        public async Task RemoveBasketItemAsync(string basketItemId)
        {
            BasketItemEntity? basketItem = await _basketItemReadRepository.GetByIdAsync(basketItemId);
            if (basketItem != null)
            {
                _basketItemWriteRepository.Remove(basketItem);
                await _basketItemWriteRepository.SaveAsync();
            }
        }

        public async Task UpdateQuantityAsync(Application.ViewModels.BasketEntities.VM_Update_BasketItemEntity basketItem)
        {
            BasketItemEntity? _basketItem = await _basketItemReadRepository.GetByIdAsync(basketItem.BasketItemId);
            if (_basketItem != null)
            {
                _basketItem.Quantity = basketItem.Quantity;
                await _basketItemWriteRepository.SaveAsync();
            }
        }

        public BasketEntity? GetUserActiveBasket
        {
            get
            {
                BasketEntity? basket = ContextUser(a).Result;
                return basket;
            }
        }
    }
}

