using MockQueryable.Moq;
using Moq;
using NewLMS.UMKM.Common.GenericRespository;
using NewLMS.UMKM.Data.Entities;
using NewLMS.UMKM.Repository.GenericRepository;
using NewLMS.UMKM.Domain.Dwh.Services;

namespace NewLMS.UMKM.Testing.Mocks
{
    public static class MockDwhServiceRepository
    {
        public static Mock<IDWHService> SetupDwhServiceRepository()
        {
            var mockRepo = new Mock<IDWHService>();
            return mockRepo;
        }
    }
}
