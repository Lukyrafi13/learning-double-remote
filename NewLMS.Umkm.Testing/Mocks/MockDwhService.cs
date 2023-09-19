using MockQueryable.Moq;
using Moq;
using NewLMS.Umkm.Common.GenericRespository;
using NewLMS.Umkm.Data.Entities;
using NewLMS.Umkm.Repository.GenericRepository;
using NewLMS.Umkm.Domain.Dwh.Services;

namespace NewLMS.Umkm.Testing.Mocks
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
