using api.Interfaces;
using api.Mapping;
using api.Models.DTOs.Boss;
using api.Models.Entities;
using api.Persistence.Data;
using api.Services;
using AutoMapper;
using CoreEx;
using Microsoft.EntityFrameworkCore;

namespace api.Tests.Services.BossTests
{
    public class BossServiceTests
    {
        private readonly DbContextOptions<AppDbContext> _dbOptions;
        private readonly IMapper _mapper;

        public BossServiceTests()
        {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile<MappingProfile>();
            });

            _mapper = config.CreateMapper();

            _dbOptions = new DbContextOptionsBuilder<AppDbContext>()
                .UseInMemoryDatabase(databaseName: $"TestDatabase{Guid.NewGuid().ToString()}")
            .Options;
        }

        [Fact]
        public async Task GetBossByIdAsync_BossExists_ReturnsDto()
        {
            using var context = new AppDbContext(_dbOptions);
            context.Bosses.Add(new Boss { Id = 1, Name = "Father Gascoigne" });
            await context.SaveChangesAsync();

            var service = new BossService(context, _mapper);

            var result = await service.GetBossByIdAsync(1);

            Assert.NotNull(result);
            Assert.Equal("Father Gascoigne", result.Name);
        }

        [Fact]
        public async Task GetBossByIdAsync_BossDoesNotExist_ReturnsNotFoundException()
        {
            using var context = new AppDbContext(_dbOptions);
            var service = new BossService(context, _mapper);

            await Assert.ThrowsAsync<NotFoundException>(() => service.GetBossByIdAsync(99));
        }

        [Fact]
        public async Task GetAllBossesAsync_ReturnsAllBosses()
        {
            using var context = new AppDbContext(_dbOptions);
            context.Bosses.Add(new Boss { Id = 1, Name = "Father Gascoigne" });
            context.Bosses.Add(new Boss { Id = 2, Name = "Vicar Amelia" });
            await context.SaveChangesAsync();

            var service = new BossService(context, _mapper);

            var result = await service.GetAllBossesAsync();

            Assert.NotEmpty(result);
            Assert.Equal(2, result.Count());
        }

        [Fact]
        public async Task CreateBossAsync_ValidDto_CreatesBoss()
        {
            using var context = new AppDbContext(_dbOptions);
            var createDto = new CreateBossDto { Name = "Father Gascoigne" };
            var service = new BossService(context, _mapper);

            var result = await service.CreateBossAsync(createDto);

            var boss = await context.Bosses.FirstOrDefaultAsync(b => b.Name == "Father Gascoigne");
            Assert.NotNull(boss);
            Assert.Equal("Father Gascoigne", boss.Name);
        }

        [Fact]
        public async Task DeleteBossAsync_BossExists_DeletesBoss()
        {
            using var context = new AppDbContext(_dbOptions);
            var boss = new Boss { Id = 1, Name = "Father Gascoigne" };
            context.Bosses.Add(boss);
            await context.SaveChangesAsync();

            var service = new BossService(context, _mapper);

            var result = await service.DeleteBossAsync(1);

            Assert.True(result);
            var deletedBoss = await context.Bosses.FirstOrDefaultAsync(b => b.Id == 1);
            Assert.Null(deletedBoss);
        }

        [Fact]
        public async Task DeleteBossAsync_BossDoesNotExist_ReturnsFalse()
        {
            using var context = new AppDbContext(_dbOptions);
            var service = new BossService(context, _mapper);

            var result = await service.DeleteBossAsync(99);

            Assert.False(result);
        }
    }
}
