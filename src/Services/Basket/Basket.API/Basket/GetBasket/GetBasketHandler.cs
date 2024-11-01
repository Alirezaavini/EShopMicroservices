﻿using Basket.API.Data;

namespace Basket.API.Basket.GetBasket
{

    public record GetBasketQuery(string UserName) : IQuery<GetBasketResult>;

    public record GetBasketResult(ShoppingCart cart);


    public class GetBasketHandler(IBasketRepository basketRepository) :
        IQueryHandler<GetBasketQuery, GetBasketResult>
    {
        public async Task<GetBasketResult> Handle(GetBasketQuery request, CancellationToken cancellationToken)
        {
            var basket = await basketRepository.GetBasket(request.UserName);
            return new GetBasketResult(basket);
        }
    }
}
