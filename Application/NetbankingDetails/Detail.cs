using System;
using Application.Core;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using Domain;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Persistence;

namespace Application.NetbankingDetails;

public class Detail
{
    public class Query : IRequest<Result<NetBankingDetailDto>>
    {
        public Guid Id { get; set; }
    }
    public class Handler : IRequestHandler<Query, Result<NetBankingDetailDto>>
    {
        private readonly DataContext _context;
        private readonly IMapper _mapper;
        public Handler(DataContext context, IMapper mapper)
        {
            _mapper = mapper;
            _context = context;
        }

        public async Task<Result<NetBankingDetailDto>> Handle(Query request, CancellationToken cancellationToken)
        {
            var netBankingDetail = await _context.NetBankingDetail
                                .ProjectTo<NetBankingDetailDto>(_mapper.ConfigurationProvider)
                                .FirstOrDefaultAsync(x => x.Id == request.Id);
            if (netBankingDetail == null)
                return Result<NetBankingDetailDto>.Fail("Netbank Detail not found");
            return Result<NetBankingDetailDto>.Success(netBankingDetail);


        }
    }
}
