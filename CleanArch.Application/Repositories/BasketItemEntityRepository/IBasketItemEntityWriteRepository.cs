using CleanArch.Domain.Entities;

namespace CleanArch.Application.Repositories.BasketItemEntityRepository;


public interface IBasketItemEntityWriteRepository : IWriteRepository<BasketItemEntity>
{
    bool Remove(BasketItemEntity basketItem);

}
