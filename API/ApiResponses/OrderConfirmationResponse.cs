using System;

namespace API.ApiResponses
{
    public record OrderConfirmationResponse(Guid orderId, string referenceNo, int confirmedQuantity)
    {
    }
}
