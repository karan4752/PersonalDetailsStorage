using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.Core;
using MediatR;
using Domain;
using Persistence;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using Microsoft.EntityFrameworkCore;
using Application.BankDetail;

namespace Application.CardDetail
{
    public class Details
    {
        public class Query : IRequest<Result<CardDetailDto>>
        {
            public Guid Id { get; set; }
        }
        public class Handler : IRequestHandler<Query, Result<CardDetailDto>>
        {
            private readonly DataContext _context;
            private readonly IMapper _mapper;
            public Handler(DataContext context, IMapper mapper)
            {
                _mapper = mapper;
                _context = context;
            }

            public async Task<Result<CardDetailDto>> Handle(Query request, CancellationToken cancellationToken)
            {
                var cardDetail = await _context.CardDetail
                .ProjectTo<CardDetailDto>(_mapper.ConfigurationProvider)
                .FirstOrDefaultAsync(x => x.Id == request.Id);
                if (cardDetail == null)
                {
                    return Result<CardDetailDto>.Fail("Card details not found");
                }
                var bankDetails = await _context.BankDetail
                .ProjectTo<BankDetailsDto>(_mapper.ConfigurationProvider)
                .FirstOrDefaultAsync(x => x.Id == cardDetail.BankDetailId);
                if (bankDetails == null)
                {
                    return Result<CardDetailDto>.Fail("Bank details not found");
                }
                return Result<CardDetailDto>.Success(cardDetail);
            }
        }
    }
}