using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CodeChallenge0.DataLayer.Services;

namespace CodeChallenge0.DataLayer.Queries
{
    /// <summary>
    /// Base Query Handler
    /// </summary>
    public abstract class BaseQueryHandler
    {
        protected readonly IDbService _DbService;
        protected readonly IMapper _mapper;

        public BaseQueryHandler(IDbService geocentricDbService, IMapper mapper)
        {
            _DbService = geocentricDbService;
            _mapper = mapper;
        }
    }
}
