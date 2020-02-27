using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using Vidly.Web.Data;
using Vidly.Web.Models;

namespace Vidly.Web.Repositories
{
    public interface IMembershipTypeRepository
    {
        IEnumerable<MembershipType> GetAllMembershipTypes();
        MembershipType GetMembershipType(int membershipTypeId);
    }

    public class SQLMembershipTypeRepository : IMembershipTypeRepository
    {
        private readonly ApplicationDbContext _context;

        public SQLMembershipTypeRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public MembershipType GetMembershipType(int membershipTypeId)
        {
            return _context.MembershipTypes.SingleOrDefault(mt => mt.Id == membershipTypeId);
        }

        public IEnumerable<MembershipType> GetAllMembershipTypes()
        {
            return _context.MembershipTypes.ToList();
        }
    }
}