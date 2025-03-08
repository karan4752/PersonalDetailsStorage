using System;
using Application.Core;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Persistence;

namespace Application.CardDetail;

public class List
{
    public class Query : IRequest<Result<List<CardDetailDto>>>
    {
        public Guid BankId { get; set; }
    }
    public class Handler : IRequestHandler<Query, Result<List<CardDetailDto>>>
    {
        private readonly DataContext _context;
        private readonly IMapper _mapper;
        public Handler(DataContext context, IMapper mapper)
        {
            _mapper = mapper;
            _context = context;

        }
        public async Task<Result<List<CardDetailDto>>> Handle(Query request, CancellationToken cancellationToken)
        {
            var CardDetails = await _context.CardDetail
            .Where(x => x.BankDetailId == request.BankId)
            .ProjectTo<CardDetailDto>(_mapper.ConfigurationProvider)
            .ToListAsync(cancellationToken);
            if (CardDetails == null) return Result<List<CardDetailDto>>.Fail("No Card Details Found");
            return Result<List<CardDetailDto>>.Success(CardDetails);
        }
    }
}
