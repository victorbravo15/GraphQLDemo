using GraphQLDemo.API.DTOs;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;
using System;
using System.Collections.Generic;

namespace GraphQLDemo.API.Services.Instructors
{
    public class InstructorsRepository
    {
        #region Campos
        private readonly IDbContextFactory<SchoolDbContext> _contextFactory;
        #endregion

        #region Constructor
        public InstructorsRepository(IDbContextFactory<SchoolDbContext> contextFactory)
        {
            this._contextFactory = contextFactory;
        }
        #endregion

        #region Métodos
        public async Task<InstructorDto> GetInstructorById(Guid id)
        {
            using (SchoolDbContext context = this._contextFactory.CreateDbContext())
            {
                return await context.Instructors.Where(x => x.Id == id).FirstOrDefaultAsync();
            }
        }

        internal async Task<IEnumerable<InstructorDto>> GetManyInstructorByIds(IReadOnlyList<Guid> instructorsIds)
        {
            using (SchoolDbContext context = this._contextFactory.CreateDbContext())
            {
                return await context.Instructors.Where(x => instructorsIds.Contains(x.Id)).ToListAsync();
            }
        }
        internal async Task<IEnumerable<InstructorDto>> GetInstructors()
        {
            using (SchoolDbContext context = this._contextFactory.CreateDbContext())
            {
                return await context.Instructors.ToListAsync();
            }
        }
        #endregion
    }
}
