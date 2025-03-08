using System;
using Application.Core;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using Domain;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Persistence;

namespace Application.NetbankingDetails;

public class List
{
    public class Query : IRequest<Result<List<NetBankingDetailDto>>>
    {
        public Guid Id { get; set; }
    }
    public class Handler : IRequestHandler<Query, Result<List<NetBankingDetailDto>>>
    {
        private readonly DataContext _context;
        private readonly IMapper _mapper;

        public Handler(DataContext context, IMapper mapper)
        {
            _mapper = mapper;
            _context = context;
        }

        public async Task<Result<List<NetBankingDetailDto>>> Handle(Query request, CancellationToken cancellationToken)
        {
            var netBankingDetails = await _context.NetBankingDetail
                                    .Where(n => n.BankDetailId == request.Id)
                                    .ProjectTo<NetBankingDetailDto>(_mapper.ConfigurationProvider)
                                    .ToListAsync(cancellationToken);
            return Result<List<NetBankingDetailDto>>.Success(netBankingDetails);
        }
    }
}
