using Application.Comments;
using Application.Core;
using Application.Interfaces;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Identity.Client;
using Persistence;

namespace Application.Activities;

public class List
{
    public class Query : IRequest<Result<PageList<ActivityDto>>>
    {
        public PagingParams Params { get; set; }
    }

    public class Handler : IRequestHandler<Query, Result<PageList<ActivityDto>>>
    {
        private readonly DataContext _context;
        private readonly IMapper _mapper;
        private readonly IUserAccessor _userAccessor;

        public Handler(DataContext context, IMapper mapper, IUserAccessor userAccessor)
        {
            _context = context;
            _mapper = mapper;
            _userAccessor = userAccessor;
        }

        public async Task<Result<PageList<ActivityDto>>> Handle(Query request, CancellationToken cancellationToken)
        {
            var query =  _context.Activities
                .OrderBy(x=> x.Date)
                .ProjectTo<ActivityDto>(_mapper.ConfigurationProvider, new {currentUsername = _userAccessor.GetUserName()})
                .AsQueryable();

            return Result<PageList<ActivityDto>>.Success(
                await PageList<ActivityDto>.CreateAsync(query, request.Params.PageNumber, request.Params.PageSize));
        }
    }
}