using ApartmentBooking.Domain.Abstractions;
using MediatR;

namespace ApartmentBooking.Application.Abstractions.Messaging;

public interface IQueryHandler<TQuery, TResponse> : IRequestHandler<TQuery, Result<TResponse>> where TQuery : IQuery<TResponse>
{
}
