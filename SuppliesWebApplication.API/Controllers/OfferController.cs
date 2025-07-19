using Microsoft.AspNetCore.Mvc;
using SuppliesWebApplication.Application.Offers;
using SuppliesWebApplication.Domain.Entities;

namespace SuppliesWebApplication.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class OfferController : ControllerBase
    {
        private readonly ILogger<OfferController> _logger;

        public OfferController(ILogger<OfferController> logger)
        {
            _logger = logger;
        }

        [HttpPost("createoffer")]
        public async Task<ActionResult<string>> CreateOffer(
            [FromServices] CreateOfferHandler handler,
            [FromBody] CreateOfferRequest request,
            CancellationToken cancellationToken = default)
        {
            var result = await handler.Handle(request, cancellationToken);

            if (result.IsFailure)
                return BadRequest(result.Error);

            return Ok(result.Value);
        }

        [HttpGet("findoffers")]
        public async Task<ActionResult<IReadOnlyList<Offer>>> FindOffers(
            [FromServices] FindOffersHandler handler,
            [FromQuery] FindOffersRequest request,
            CancellationToken cancellationToken = default)
        {
            var result = await handler.Handle(request, cancellationToken);

            if (result.IsFailure)
                return BadRequest(result.Error);

            return Ok(result.Value);
        }

        [HttpGet("mostpopularsuppliers")]
        public async Task<ActionResult<IReadOnlyList<MostPopularSuppliersResponse>>> MostPopularSuppliers(
            [FromServices] MostPopularSuppliersHandler handler,
            CancellationToken cancellationToken = default)
        {
            var result = await handler.Handle(cancellationToken);

            if (result.IsFailure)
                return BadRequest(result.Error);

            return Ok(result.Value);
        }
    }
}
