using System;
using Application.Core;
using MediatR;
using Persistence;

namespace Application.NetbankingDetails;

public class Delete
{
    public class Command : IRequest<Result<Unit>>
    {
        public Guid Id { get; set; }
    }
    public class Handler : IRequestHandler<Command, Result<Unit>>
    {
        private readonly DataContext _dataContext;
        public Handler(DataContext dataContext)
        {
            _dataContext = dataContext;
        }
        public async Task<Result<Unit>> Handle(Command request, CancellationToken cancellationToken)
        {
            var netbankingDetails = await _dataContext.NetBankingDetail.FindAsync(request.Id);
            if (netbankingDetails == null) return null;

            _dataContext.Remove(netbankingDetails);
            var result = await _dataContext.SaveChangesAsync() > 0;
            if (!result) return Result<Unit>.Fail("Failed to delete Netbanking details");
            return Result<Unit>.Success(Unit.Value);
        }
    }
}
