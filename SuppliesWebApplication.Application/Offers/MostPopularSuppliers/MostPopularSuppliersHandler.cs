﻿using CSharpFunctionalExtensions;

namespace SuppliesWebApplication.Application.Offers
{
    public class MostPopularSuppliersHandler(IOffersRepository offersRepository)
    {
        public async Task<Result<IReadOnlyList<MostPopularSuppliersResponse>, string>> Handle(
            CancellationToken cancellationToken = default)
        {
            return await offersRepository.MostPopularSuppliers(cancellationToken);
        }
    }
}
