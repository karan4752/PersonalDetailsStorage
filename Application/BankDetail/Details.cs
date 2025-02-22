using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.Core;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using Domain;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Persistence;

namespace Application.BankDetail
{
    public class Details
    {
        public class Query : IRequest<Result<BankDetailsDto>>
        {
            public Guid Id;
        }

        public class Handler : IRequestHandler<Query, Result<BankDetailsDto>>
        {
            private readonly DataContext _context;
            private readonly IMapper _mapper;
            public Handler(DataContext context, IMapper mapper)
            {
                _mapper = mapper;
                _context = context;
            }
            public async Task<Result<BankDetailsDto>> Handle(Query request, CancellationToken cancellationToken)
            {
                var bankDetails = await _context.BankDetail
                                .ProjectTo<BankDetailsDto>(_mapper.ConfigurationProvider)
                                .FirstOrDefaultAsync(x => x.Id == request.Id);
                return Result<BankDetailsDto>.Success(bankDetails);
            }
        }
    }
}