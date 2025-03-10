using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.Core;
using Application.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Persistence;

namespace Application.Photos
{
    public class SetMain
    {
        public class Command : IRequest<Result<Unit>>
        {
            public string Id { get; set; }
        }
        public class Handler : IRequestHandler<Command, Result<Unit>>
        {
            private readonly DataContext _context;
            private readonly IUserAccessor userAccessor;
            private readonly IPhotoAccesor photoAccessor;
            public Handler(DataContext context, IUserAccessor userAccessor, IPhotoAccesor photoAccessor)
            {
                this.photoAccessor = photoAccessor;
                this.userAccessor = userAccessor;
                _context = context;
            }
            

            public async Task<Result<Unit>> Handle(Command request, CancellationToken cancellationToken)
            {
                var user = await _context.Users.Include(x => x.Photos).FirstOrDefaultAsync(x => x.UserName == userAccessor.GetUsername());
                if (user == null) return null;

                var photo = user.Photos.FirstOrDefault(x => x.Id == request.Id);
                if (photo == null) return null;

                var currentMain = user.Photos.FirstOrDefault(x => x.IsMain);
                if (currentMain != null) currentMain.IsMain = false;
                photo.IsMain = true;

                var success = await _context.SaveChangesAsync() > 0;
                if (success) return Result<Unit>.Success(Unit.Value);
                return Result<Unit>.Fail("Problem setting main photo");
            }
        }
    }
}