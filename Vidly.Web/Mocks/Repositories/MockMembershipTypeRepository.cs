using System;
using System.Collections.Generic;
using System.Linq;
using Vidly.Web.Mocks.Enums;
using Vidly.Web.Models;
using Vidly.Web.Repositories;

namespace Vidly.Web.Mocks.Repositories
{
    public class MockMembershipTypeRepository : IMembershipTypeRepository
    {
        public IEnumerable<MembershipType> GetAllMembershipTypes()
        {
            return GetMembershipTypes();
        }

        public MembershipType GetMembershipType(int membershipTypeId)
        {
            return GetMembershipTypes().SingleOrDefault(mt => mt.Id == membershipTypeId);
        }

        private MembershipType CreateMembershipType(MockMemberShipTypes membershipType)
        {
            return new MembershipType
            {
                Id = (byte)membershipType.GetHashCode(),
                Name = membershipType.ToString(),
            };
        }

        private IEnumerable<MembershipType> GetMembershipTypes()
        {
            return new List<MembershipType>
            {
                CreateMembershipType(MockMemberShipTypes.PayAsYouGo),
                CreateMembershipType(MockMemberShipTypes.Monthly),
                CreateMembershipType(MockMemberShipTypes.Quarterly),
                CreateMembershipType(MockMemberShipTypes.Annually),
            };
        }
    }
}