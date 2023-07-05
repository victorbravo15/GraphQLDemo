using GraphQLDemo.API.DTOs;
using GraphQLDemo.API.Services.Instructors;
using GreenDonut;
using HotChocolate.DataLoader;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace GraphQLDemo.API.DataLoaders
{
    public class InstructorDataLoader : BatchDataLoader<Guid, InstructorDto>
    {
        #region Campos
        private readonly InstructorsRepository _instructorsRepository;
        #endregion

        #region Constructor
        public InstructorDataLoader(IBatchScheduler batchScheduler, InstructorsRepository instructorsRepository, DataLoaderOptions<Guid> options = null) : base(batchScheduler, options)
        {
            this._instructorsRepository = instructorsRepository;
        }
        #endregion

        #region Implementation of BatchDataLoader<Guid, InstructorDto>
        protected override async Task<IReadOnlyDictionary<Guid, InstructorDto>> LoadBatchAsync(IReadOnlyList<Guid> keys, CancellationToken cancellationToken)
        {
            IEnumerable<InstructorDto> instructors = await this._instructorsRepository.GetManyInstructorByIds(keys);
            return instructors.ToDictionary(x => x.Id);
        }
        #endregion
    }
}
