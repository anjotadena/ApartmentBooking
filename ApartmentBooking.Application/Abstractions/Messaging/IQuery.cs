using ApartmentBooking.Domain.Abstractions;
using MediatR;

namespace ApartmentBooking.Application.Abstractions.Messaging;

public interface IQuery<TResponse> : IRequest<Result<TResponse>>
{
}
