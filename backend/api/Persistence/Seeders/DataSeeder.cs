using api.Models.Entities;
using api.Persistence.Data;
using api.Models.Enums;
using static System.Net.WebRequestMethods;

public class DataSeeder
{
    private readonly AppDbContext _context;

    public DataSeeder(AppDbContext context)
    {
        _context = context;
    }

    public async Task SeedAsync()
    {
        try
        {
            await _context.Database.EnsureCreatedAsync();

            if (!_context.Scalings.Any())
                await SeedScalings();

            if (!_context.Bosses.Any())
                await SeedBosses();

            if (!_context.TricksterWeapons.Any())
                await SeedTricksterWeapons();

            if (!_context.Firearms.Any())
                await SeedFirearms();

            if (!_context.Attacks.Any())
                await SeedAttacks();

            if (!_context.Origins.Any())
                await SeedOrigins();

            if (!_context.EchoesPerLevels.Any())
                await SeedEchoesPerLevel();
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error while seeding database: {ex.Message}");
            throw;
        }
    }

    private async Task SeedScalings()
    {
        var scalings = new List<Scaling>
        {
            new Scaling { Id = 1, Name = "Amygdalan Arm Scaling", StrengthScaling = 0.6m, SkillScaling = 0.15m, BloodtingeScaling = 0m, ArcaneScaling = 0.41m, StrengthStep = 0.03m, SkillStep = 0.01m, BloodtingeStep = 0m, ArcaneStep = 0.02m },
            new Scaling { Id = 2, Name = "Beast Claw Scaling", StrengthScaling = 0.4m, SkillScaling = 0.25m, BloodtingeScaling = 0m, ArcaneScaling = 0.35m, StrengthStep = 0.02m, SkillStep = 0.01m, BloodtingeStep = 0m, ArcaneStep = 0.02m },
            new Scaling { Id = 3, Name = "Beast Cutter Scaling", StrengthScaling = 0.4m, SkillScaling = 0.1m, BloodtingeScaling = 0m, ArcaneScaling = 0.27m, StrengthStep = 0.02m, SkillStep = 0.02m, BloodtingeStep = 0m, ArcaneStep = 0.02m },
            new Scaling { Id = 4, Name = "Beasthunter Saim Scaling", StrengthScaling = 0.2m, SkillScaling = 0.4m, BloodtingeScaling = 0m, ArcaneScaling = 0.33m, StrengthStep = 0.01m, SkillStep = 0.03m, BloodtingeStep = 0m, ArcaneStep = 0.02m },
            new Scaling { Id = 5, Name = "Blade of Mercy Scaling", StrengthScaling = 0m, SkillScaling = 0.6m, BloodtingeScaling = 0m, ArcaneScaling = 0.4m, StrengthStep = 0m, SkillStep = 0.05m, BloodtingeStep = 0m, ArcaneStep = 0.03m },
            new Scaling { Id = 6, Name = "Bloodletter Scaling", StrengthScaling = 0.6m, SkillScaling = 0m, BloodtingeScaling = 0.7m, ArcaneScaling = 0.33m, StrengthStep = 0.04m, SkillStep = 0m, BloodtingeStep = 0.04m, ArcaneStep = 0.02m },
            new Scaling { Id = 7, Name = "Boom Hammer Scaling", StrengthScaling = 0.6m, SkillScaling = 0.15m, BloodtingeScaling = 0m, ArcaneScaling = 0.41m, StrengthStep = 0.03m, SkillStep = 0.01m, BloodtingeStep = 0m, ArcaneStep = 0.02m },
            new Scaling { Id = 8, Name = "Burial Blade Scaling", StrengthScaling = 0.2m, SkillScaling = 0.55m, BloodtingeScaling = 0m, ArcaneScaling = 0.4m, StrengthStep = 0.01m, SkillStep = 0.02m, BloodtingeStep = 0m, ArcaneStep = 0.03m },
            new Scaling { Id = 9, Name = "Chikage Scaling", StrengthScaling = 0.15m, SkillScaling = 0.45m, BloodtingeScaling = 0.6m, ArcaneScaling = 0.33m, StrengthStep = 0.01m, SkillStep = 0.02m, BloodtingeStep = 0.05m, ArcaneStep = 0.015m },
            new Scaling { Id = 10, Name = "Church Pick Scaling", StrengthScaling = 0.2m, SkillScaling = 0.5m, BloodtingeScaling = 0m, ArcaneScaling = 0.38m, StrengthStep = 0.02m, SkillStep = 0.02m, BloodtingeStep = 0m, ArcaneStep = 0.02m },
            new Scaling { Id = 11, Name = "Holy Moonlight Sword Scaling", StrengthScaling = 0.5m, SkillScaling = 0.4m, BloodtingeScaling = 0m, ArcaneScaling = 0.6m, StrengthStep = 0.03m, SkillStep = 0.02m, BloodtingeStep = 0m, ArcaneStep = 0.04m },
            new Scaling { Id = 12, Name = "Hunter Axe Scaling", StrengthScaling = 0.45m, SkillScaling = 0.15m, BloodtingeScaling = 0m, ArcaneScaling = 0.33m, StrengthStep = 0.02m, SkillStep = 0.02m, BloodtingeStep = 0m, ArcaneStep = 0.02m },
            new Scaling { Id = 13, Name = "Kirkhammer Scaling", StrengthScaling = 0.6m, SkillScaling = 0.19m, BloodtingeScaling = 0m, ArcaneScaling = 0.43m, StrengthStep = 0.04m, SkillStep = 0.01m, BloodtingeStep = 0m, ArcaneStep = 0.03m },
            new Scaling { Id = 14, Name = "Kos Parasite Scaling", StrengthScaling = 0m, SkillScaling = 0m, BloodtingeScaling = 0m, ArcaneScaling = 1m, StrengthStep = 0m, SkillStep = 0m, BloodtingeStep = 0m, ArcaneStep = 0.06m },
            new Scaling { Id = 15, Name = "Logarius' Wheel Scaling", StrengthScaling = 0.6m, SkillScaling = 0m, BloodtingeScaling = 0m, ArcaneScaling = 0.33m, StrengthStep = 0.05m, SkillStep = 0m, BloodtingeStep = 0m, ArcaneStep = 0.027m },
            new Scaling { Id = 16, Name = "Ludwig's Holy Blade Scaling", StrengthScaling = 0.5m, SkillScaling = 0.4m, BloodtingeScaling = 0m, ArcaneScaling = 0.49m, StrengthStep = 0.03m, SkillStep = 0.04m, BloodtingeStep = 0m, ArcaneStep = 0.04m },
            new Scaling { Id = 17, Name = "Rakuyo Scaling", StrengthScaling = 0m, SkillScaling = 0.6m, BloodtingeScaling = 0m, ArcaneScaling = 0.33m, StrengthStep = 0m, SkillStep = 0.04m, BloodtingeStep = 0m, ArcaneStep = 0.022m },
            new Scaling { Id = 18, Name = "Reiterpallasch Scaling", StrengthScaling = 0.1m, SkillScaling = 0.6m, BloodtingeScaling = 0.2m, ArcaneScaling = 0.38m, StrengthStep = 0.01m, SkillStep = 0.04m, BloodtingeStep = 0.02m, ArcaneStep = 0.028m },
            new Scaling { Id = 19, Name = "Rifle Spear Scaling", StrengthScaling = 0.2m, SkillScaling = 0.5m, BloodtingeScaling = 0.35m, ArcaneScaling = 0.38m, StrengthStep = 0.01m, SkillStep = 0.02m, BloodtingeStep = 0.03m, ArcaneStep = 0.017m },
            new Scaling { Id = 20, Name = "Saw Cleaver Scaling", StrengthScaling = 0.4m, SkillScaling = 0.2m, BloodtingeScaling = 0m, ArcaneScaling = 0.33m, StrengthStep = 0.02m, SkillStep = 0.02m, BloodtingeStep = 0m, ArcaneStep = 0.022m },
            new Scaling { Id = 21, Name = "Saw Spear Scaling", StrengthScaling = 0.3m, SkillScaling = 0.44m, BloodtingeScaling = 0m, ArcaneScaling = 0.4m, StrengthStep = 0.02m, SkillStep = 0.02m, BloodtingeStep = 0m, ArcaneStep = 0.022m },
            new Scaling { Id = 22, Name = "Simon's Bowblade Scaling", StrengthScaling = 0m, SkillScaling = 0.6m, BloodtingeScaling = 0.6m, ArcaneScaling = 0.33m, StrengthStep = 0m, SkillStep = 0.05m, BloodtingeStep = 0.05m, ArcaneStep = 0.027m },
            new Scaling { Id = 23, Name = "Stake Driver Scaling", StrengthScaling = 0.4m, SkillScaling = 0.35m, BloodtingeScaling = 0m, ArcaneScaling = 0.41m, StrengthStep = 0.02m, SkillStep = 0.02m, BloodtingeStep = 0m, ArcaneStep = 0.022m },
            new Scaling { Id = 24, Name = "Threaded Cane Scaling", StrengthScaling = 0.19m, SkillScaling = 0.6m, BloodtingeScaling = 0m, ArcaneScaling = 0.43m, StrengthStep = 0.01m, SkillStep = 0.03m, BloodtingeStep = 0m, ArcaneStep = 0.022m },
            new Scaling { Id = 25, Name = "Tonitrus Scaling", StrengthScaling = 0.45m, SkillScaling = 0.15m, BloodtingeScaling = 0m, ArcaneScaling = 0.33m, StrengthStep = 0.02m, SkillStep = 0.01m, BloodtingeStep = 0m, ArcaneStep = 0.016m },
            new Scaling { Id = 26, Name = "Whirligig Saw Scaling", StrengthScaling = 0.7m, SkillScaling = 0.2m, BloodtingeScaling = 0m, ArcaneScaling = 0.49m, StrengthStep = 0.04m, SkillStep = 0.01m, BloodtingeStep = 0m, ArcaneStep = 0.028m },
            new Scaling { Id = 27, Name = "Cannon Scaling", StrengthScaling = 0m, SkillScaling = 0m, BloodtingeScaling = 0.1m, ArcaneScaling = 0m, StrengthStep = 0m, SkillStep = 0m, BloodtingeStep = 0.03m, ArcaneStep = 0m },
            new Scaling { Id = 28, Name = "Church Cannon Scaling", StrengthScaling = 0m, SkillScaling = 0m, BloodtingeScaling = 0.2m, ArcaneScaling = 0m, StrengthStep = 0m, SkillStep = 0m, BloodtingeStep = 0.03m, ArcaneStep = 0m },
            new Scaling { Id = 29, Name = "Evelyn Scaling", StrengthScaling = 0m, SkillScaling = 0m, BloodtingeScaling = 0.65m, ArcaneScaling = 0m, StrengthStep = 0m, SkillStep = 0m, BloodtingeStep = 0.07m, ArcaneStep = 0m },
            new Scaling { Id = 30, Name = "Fist of Gratia Scaling", StrengthScaling = 0.5m, SkillScaling = 0m, BloodtingeScaling = 0m, ArcaneScaling = 0m, StrengthStep = 0.05m, SkillStep = 0m, BloodtingeStep = 0m, ArcaneStep = 0m },
            new Scaling { Id = 31, Name = "Flamesprayer Scaling", StrengthScaling = 0m, SkillScaling = 0m, BloodtingeScaling = 0m, ArcaneScaling = 0.3m, StrengthStep = 0m, SkillStep = 0m, BloodtingeStep = 0m, ArcaneStep = 0.04m },
            new Scaling { Id = 32, Name = "Gatling Gun Scaling", StrengthScaling = 0m, SkillScaling = 0m, BloodtingeScaling = 0.1m, ArcaneScaling = 0m, StrengthStep = 0m, SkillStep = 0m, BloodtingeStep = 0.03m, ArcaneStep = 0m },
            new Scaling { Id = 33, Name = "Hunter Blunderbuss Scaling", StrengthScaling = 0m, SkillScaling = 0m, BloodtingeScaling = 0.5m, ArcaneScaling = 0m, StrengthStep = 0m, SkillStep = 0m, BloodtingeStep = 0.05m, ArcaneStep = 0m },
            new Scaling { Id = 34, Name = "Hunter Pistol Scaling", StrengthScaling = 0m, SkillScaling = 0m, BloodtingeScaling = 0.45m, ArcaneScaling = 0m, StrengthStep = 0m, SkillStep = 0m, BloodtingeStep = 0.04m, ArcaneStep = 0m },
            new Scaling { Id = 35, Name = "Ludwig's Rifle Scaling", StrengthScaling = 0m, SkillScaling = 0m, BloodtingeScaling = 0.2m, ArcaneScaling = 0m, StrengthStep = 0m, SkillStep = 0m, BloodtingeStep = 0.03m, ArcaneStep = 0m },
            new Scaling { Id = 36, Name = "Piercing Rifle Scaling", StrengthScaling = 0m, SkillScaling = 0m, BloodtingeScaling = 0.4m, ArcaneScaling = 0m, StrengthStep = 0m, SkillStep = 0m, BloodtingeStep = 0.06m, ArcaneStep = 0m },
            new Scaling { Id = 37, Name = "Repeating Pistol Scaling", StrengthScaling = 0m, SkillScaling = 0m, BloodtingeScaling = 0.5m, ArcaneScaling = 0m, StrengthStep = 0m, SkillStep = 0m, BloodtingeStep = 0.03m, ArcaneStep = 0m },
            new Scaling { Id = 38, Name = "Rosmarinus Scaling", StrengthScaling = 0m, SkillScaling = 0m, BloodtingeScaling = 0m, ArcaneScaling = 0.65m, StrengthStep = 0m, SkillStep = 0m, BloodtingeStep = 0m, ArcaneStep = 0.06m }
        };

        await _context.Scalings.AddRangeAsync(scalings);
        await _context.SaveChangesAsync();
    }

    private async Task SeedBosses()
    {
        var bosses = new List<Boss>
        {
            new Boss
            {
                Id = 1,
                Name = "Cleric Beast",
                Health = 3015,
                BloodEchoes = 4000,
                IsInterruptible = false,
                IsRequired = false,
                IsBeast = true,
                IsKin = false,
                IsWeakToSerrated = true,
                IsWeakToRighteous = false,
                PhysicalDefense = 102,
                BluntDefense = 123,
                ThrustDefense = 102,
                BloodtingeDefense = 102,
                ArcaneDefense = 169,
                FireDefense = 51,
                BoltDefense = 169,
                SlowPoisonResistance = 999,
                RapidPoisonResistance = 999,
                ImageUrl = "https://drive.google.com/thumbnail?id=1LrmqZe09Vm-q2ecpgDpsnvBha2r7I4eD"
            },

            new Boss
            {
                Id = 2,
                Name = "Father Gascoigne",
                Health = 2031,
                BloodEchoes = 3200,
                IsInterruptible = true,
                IsRequired = true,
                IsBeast = false,
                IsKin = false,
                IsWeakToSerrated = false,
                IsWeakToRighteous = false,
                PhysicalDefense = 94,
                BluntDefense = 94,
                ThrustDefense = 94,
                BloodtingeDefense = 94,
                ArcaneDefense = 84,
                FireDefense = 68,
                BoltDefense = 126,
                SlowPoisonResistance = 999,
                RapidPoisonResistance = 999,
                ImageUrl = "https://drive.google.com/thumbnail?id=1cbnDH1lvmRUHtMAkJvVrOPXeQIZ_xbUK"
            },
            
            new Boss
            {
                Id = 3,
                Name = "Father Gascoigne (Beast)",
                Health = 2031,
                BloodEchoes = 3200,
                IsInterruptible = true,
                IsRequired = true,
                IsBeast = true,
                IsKin = false,
                IsWeakToSerrated = true,
                IsWeakToRighteous = false,
                PhysicalDefense = 126,
                BluntDefense = 126,
                ThrustDefense = 126,
                BloodtingeDefense = 126,
                ArcaneDefense = 168,
                FireDefense = 52,
                BoltDefense = 126,
                SlowPoisonResistance = 999,
                RapidPoisonResistance = 999,
                ImageUrl = "https://drive.google.com/thumbnail?id=1766NL4OAq0JUyo3VJ1yddtEpPOeoslpr"
            },

            new Boss
            {
                Id = 4,
                Name = "Blood-starved Beast",
                Health = 3470,
                BloodEchoes = 6600,
                IsInterruptible = true,
                IsRequired = false,
                IsBeast = true,
                IsKin = false,
                IsWeakToSerrated = true,
                IsWeakToRighteous = false,
                PhysicalDefense = 107,
                BluntDefense = 107,
                ThrustDefense = 107,
                BloodtingeDefense = 107,
                ArcaneDefense = 172,
                FireDefense = 59,
                BoltDefense = 172,
                SlowPoisonResistance = 999,
                RapidPoisonResistance = 180,
                ImageUrl = "https://drive.google.com/thumbnail?id=1GfvLfkskm_90bdHJzTI4-o_kouQvBRMv"
            },

            new Boss
            {
                Id = 5,
                Name = "The Witch of Hemwick",
                Health = 2611,
                BloodEchoes = 11800,
                IsInterruptible = false,
                IsRequired = false,
                IsBeast = false,
                IsKin = false,
                IsWeakToSerrated = false,
                IsWeakToRighteous = false,
                PhysicalDefense = 78,
                BluntDefense = 78,
                ThrustDefense = 78,
                BloodtingeDefense = 78,
                ArcaneDefense = 78,
                FireDefense = 82,
                BoltDefense = 101,
                SlowPoisonResistance = 200,
                RapidPoisonResistance = 180,
                ImageUrl = "https://drive.google.com/thumbnail?id=1SFBoO5VSJYqGZYMWZoPdpFVwOONHgmP5"
            },
            
            new Boss
            {
                Id = 6,
                Name = "Darkbeast Paarl",
                Health = 4552,
                BloodEchoes = 21000,
                IsInterruptible = false,
                IsRequired = false,
                IsBeast = true,
                IsKin = false,
                IsWeakToSerrated = true,
                IsWeakToRighteous = false,
                PhysicalDefense = 120,
                BluntDefense = 144,
                ThrustDefense = 120,
                BloodtingeDefense = 120,
                ArcaneDefense = 90,
                FireDefense = 102,
                BoltDefense = 360,
                SlowPoisonResistance = 999,
                RapidPoisonResistance = 999,
                ImageUrl = "https://drive.google.com/thumbnail?id=1KZ9mRLJYjR3KwQ8LYPNboqWoO1I8rZCk"
            },

            new Boss
            {
                Id = 7,
                Name = "Vicar Amelia",
                Health = 5367,
                BloodEchoes = 15000,
                IsInterruptible = false,
                IsRequired = true,
                IsBeast = true,
                IsKin = false,
                IsWeakToSerrated = true,
                IsWeakToRighteous = false,
                PhysicalDefense = 112,
                BluntDefense = 135,
                ThrustDefense = 112,
                BloodtingeDefense = 112,
                ArcaneDefense = 180,
                FireDefense = 61,
                BoltDefense = 180,
                SlowPoisonResistance = 999,
                RapidPoisonResistance = 999,
                ImageUrl = "https://drive.google.com/thumbnail?id=1SBGE02p1MzT3o55pz2n2JJLZdVEIhssL"
            },
            
            new Boss
            {
                Id = 8,
                Name = "Shadow of Yharnam (Sword)",
                Health = 3645,
                BloodEchoes = 18600,
                IsInterruptible = true,
                IsRequired = true,
                IsBeast = false,
                IsKin = false,
                IsWeakToSerrated = false,
                IsWeakToRighteous = false,
                PhysicalDefense = 89,
                BluntDefense = 89,
                ThrustDefense = 89,
                BloodtingeDefense = 89,
                ArcaneDefense = 73,
                FireDefense = 110,
                BoltDefense = 83,
                SlowPoisonResistance = 200,
                RapidPoisonResistance = 180,
                ImageUrl = "https://drive.google.com/thumbnail?id=192rC1l3cNRC18Pe2eWFnKLLz_SpSyo2O"
            },

            new Boss
            {
                Id = 9,
                Name = "Shadow of Yharnam (Candle)",
                Health = 2302,
                BloodEchoes = 18600,
                IsInterruptible = true,
                IsRequired = true,
                IsBeast = false,
                IsKin = false,
                IsWeakToSerrated = false,
                IsWeakToRighteous = false,
                PhysicalDefense = 89,
                BluntDefense = 89,
                ThrustDefense = 89,
                BloodtingeDefense = 89,
                ArcaneDefense = 73,
                FireDefense = 122,
                BoltDefense = 83,
                SlowPoisonResistance = 200,
                RapidPoisonResistance = 180,
                ImageUrl = "https://drive.google.com/thumbnail?id=192rC1l3cNRC18Pe2eWFnKLLz_SpSyo2O"
            },
            
            new Boss
            {
                Id = 10,
                Name = "Shadow of Yharnam (Fireball)",
                Health = 2046,
                BloodEchoes = 18600,
                IsInterruptible = true,
                IsRequired = true,
                IsBeast = false,
                IsKin = false,
                IsWeakToSerrated = false,
                IsWeakToRighteous = false,
                PhysicalDefense = 89,
                BluntDefense = 89,
                ThrustDefense = 89,
                BloodtingeDefense = 89,
                ArcaneDefense = 196,
                FireDefense = 110,
                BoltDefense = 196,
                SlowPoisonResistance = 200,
                RapidPoisonResistance = 180,
                ImageUrl = "https://drive.google.com/thumbnail?id=192rC1l3cNRC18Pe2eWFnKLLz_SpSyo2O"
            },

            new Boss
            {
                Id = 11,
                Name = "Martyr Logarius",
                Health = 9081,
                BloodEchoes = 25600,
                IsInterruptible = true,
                IsRequired = false,
                IsBeast = false,
                IsKin = false,
                IsWeakToSerrated = false,
                IsWeakToRighteous = false,
                PhysicalDefense = 132,
                BluntDefense = 132,
                ThrustDefense = 132,
                BloodtingeDefense = 132,
                ArcaneDefense = 384,
                FireDefense = 212,
                BoltDefense = 238,
                SlowPoisonResistance = 999,
                RapidPoisonResistance = 999,
                ImageUrl = "https://drive.google.com/thumbnail?id=1OPifCD5zmSwCN3T67CSISVBYqHZFeFbK"
            },
            
            new Boss
            {
                Id = 12,
                Name = "Amygdala",
                Health = 6404,
                BloodEchoes = 21000,
                IsInterruptible = false,
                IsRequired = false,
                IsBeast = false,
                IsKin = false,
                IsWeakToSerrated = false,
                IsWeakToRighteous = false,
                PhysicalDefense = 127,
                BluntDefense = 153,
                ThrustDefense = 127,
                BloodtingeDefense = 127,
                ArcaneDefense = 89,
                FireDefense = 89,
                BoltDefense = 89,
                SlowPoisonResistance = 999,
                RapidPoisonResistance = 999,
                ImageUrl = "https://drive.google.com/thumbnail?id=1AhvfwoMLAIrs_-IhYISrbm1FMlE2uK2Q"
            },

            new Boss
            {
                Id = 13,
                Name = "Rom, the Vacuous Spider",
                Health = 4235,
                BloodEchoes = 22600,
                IsInterruptible = false,
                IsRequired = true,
                IsBeast = false,
                IsKin = true,
                IsWeakToSerrated = false,
                IsWeakToRighteous = false,
                PhysicalDefense = 130,
                BluntDefense = 130,
                ThrustDefense = 130,
                BloodtingeDefense = 130,
                ArcaneDefense = 104,
                FireDefense = 93,
                BoltDefense = 58,
                SlowPoisonResistance = 999,
                RapidPoisonResistance = 999,
                ImageUrl = "https://drive.google.com/thumbnail?id=15OnOGBTvkiWzW8Q7Hq22-yHgV6tYNO2q"
            },
            
            new Boss
            {
                Id = 14,
                Name = "The One Reborn",
                Health = 10375,
                BloodEchoes = 33000,
                IsInterruptible = false,
                IsRequired = true,
                IsBeast = false,
                IsKin = false,
                IsWeakToSerrated = false,
                IsWeakToRighteous = false,
                PhysicalDefense = 135,
                BluntDefense = 162,
                ThrustDefense = 135,
                BloodtingeDefense = 135,
                ArcaneDefense = 391,
                FireDefense = 94,
                BoltDefense = 54,
                SlowPoisonResistance = 999,
                RapidPoisonResistance = 999,
                ImageUrl = "https://drive.google.com/thumbnail?id=1ISy4NRkuEHS6adF0UBW9qxBy9tyleJD2"
            },

            new Boss
            {
                Id = 15,
                Name = "Celestial Emissary",
                Health = 2764,
                BloodEchoes = 22400,
                IsInterruptible = false,
                IsRequired = false,
                IsBeast = false,
                IsKin = true,
                IsWeakToSerrated = false,
                IsWeakToRighteous = false,
                PhysicalDefense = 235,
                BluntDefense = 261,
                ThrustDefense = 26,
                BloodtingeDefense = 130,
                ArcaneDefense = 233,
                FireDefense = 82,
                BoltDefense = 61,
                SlowPoisonResistance = 300,
                RapidPoisonResistance = 180,
                ImageUrl = "https://drive.google.com/thumbnail?id=1donm0Rm9VHnZd_0w20VxJhVPsgLJaj7Y"
            },
            
            new Boss
            {
                Id = 16,
                Name = "Ebrietas, Daughter of the Cosmos",
                Health = 12493,
                BloodEchoes = 28800,
                IsInterruptible = false,
                IsRequired = false,
                IsBeast = false,
                IsKin = true,
                IsWeakToSerrated = false,
                IsWeakToRighteous = false,
                PhysicalDefense = 252,
                BluntDefense = 336,
                ThrustDefense = 100,
                BloodtingeDefense = 168,
                ArcaneDefense = 238,
                FireDefense = 84,
                BoltDefense = 63,
                SlowPoisonResistance = 999,
                RapidPoisonResistance = 999,
                ImageUrl = "https://drive.google.com/thumbnail?id=1oAsPg_i-8BTDcdV53EQk32wCYiwASkjW"
            },

            new Boss
            {
                Id = 17,
                Name = "Micolash, Host of the Nightmare",
                Health = 5250,
                BloodEchoes = 48400,
                IsInterruptible = true,
                IsRequired = true,
                IsBeast = false,
                IsKin = false,
                IsWeakToSerrated = false,
                IsWeakToRighteous = false,
                PhysicalDefense = 169,
                BluntDefense = 134,
                ThrustDefense = 125,
                BloodtingeDefense = 179,
                ArcaneDefense = 232,
                FireDefense = 124,
                BoltDefense = 125,
                SlowPoisonResistance = 144,
                RapidPoisonResistance = 132,
                ImageUrl = "https://drive.google.com/thumbnail?id=1gyVGRLkDitmUy3mPLvBF4D3XjQdFZw2P"
            },
            
            new Boss
            {
                Id = 18,
                Name = "Mergo's Wet Nurse",
                Health = 14081,
                BloodEchoes = 72000,
                IsInterruptible = false,
                IsRequired = true,
                IsBeast = false,
                IsKin = false,
                IsWeakToSerrated = false,
                IsWeakToRighteous = false,
                PhysicalDefense = 147,
                BluntDefense = 177,
                ThrustDefense = 147,
                BloodtingeDefense = 147,
                ArcaneDefense = 110,
                FireDefense = 110,
                BoltDefense = 110,
                SlowPoisonResistance = 250,
                RapidPoisonResistance = 180,
                ImageUrl = "https://drive.google.com/thumbnail?id=1nGIgovnj3nYC_0qWbqU9HL8TgrC7UUig"
            },

            new Boss
            {
                Id = 19,
                Name = "Gehrman, The First Hunter",
                Health = 14293,
                BloodEchoes = 128000,
                IsInterruptible = true,
                IsRequired = false,
                IsBeast = false,
                IsKin = false,
                IsWeakToSerrated = false,
                IsWeakToRighteous = false,
                PhysicalDefense = 150,
                BluntDefense = 150,
                ThrustDefense = 150,
                BloodtingeDefense = 150,
                ArcaneDefense = 97,
                FireDefense = 105,
                BoltDefense = 97,
                SlowPoisonResistance = 999,
                RapidPoisonResistance = 999,
                ImageUrl = "https://drive.google.com/thumbnail?id=18FG0GxJyazpxUyFvtbyQvEuMSm2kJjf1"
            },
            
            new Boss
            {
                Id = 20,
                Name = "Moon Presence",
                Health = 8909,
                BloodEchoes = 230000,
                IsInterruptible = false,
                IsRequired = false,
                IsBeast = false,
                IsKin = false,
                IsWeakToSerrated = false,
                IsWeakToRighteous = false,
                PhysicalDefense = 137,
                BluntDefense = 137,
                ThrustDefense = 137,
                BloodtingeDefense = 137,
                ArcaneDefense = 114,
                FireDefense = 114,
                BoltDefense = 114,
                SlowPoisonResistance = 999,
                RapidPoisonResistance = 999,
                ImageUrl = "https://drive.google.com/thumbnail?id=1juUxAuggpeSpBKk9ecAJjFmwa8O3t-LE"
            },

            new Boss
            {
                Id = 21,
                Name = "Ludwig the Accursed",
                Health = 16658,
                BloodEchoes = 34500,
                IsInterruptible = false,
                IsRequired = false,
                IsBeast = true,
                IsKin = false,
                IsWeakToSerrated = true,
                IsWeakToRighteous = false,
                PhysicalDefense = 140,
                BluntDefense = 140,
                ThrustDefense = 140,
                BloodtingeDefense = 140,
                ArcaneDefense = 126,
                FireDefense = 98,
                BoltDefense = 126,
                SlowPoisonResistance = 999,
                RapidPoisonResistance = 999,
                ImageUrl = "https://drive.google.com/thumbnail?id=1nySHThfI5E0zmmIR3TeljarzBIxv2S2U"
            },
            
            new Boss
            {
                Id = 22,
                Name = "Ludwig the Holy Blade",
                Health = 16658,
                BloodEchoes = 34500,
                IsInterruptible = false,
                IsRequired = false,
                IsBeast = false,
                IsKin = false,
                IsWeakToSerrated = true,
                IsWeakToRighteous = false,
                PhysicalDefense = 140,
                BluntDefense = 140,
                ThrustDefense = 140,
                BloodtingeDefense = 140,
                ArcaneDefense = 252,
                FireDefense = 119,
                BoltDefense = 168,
                SlowPoisonResistance = 999,
                RapidPoisonResistance = 999,
                ImageUrl = "https://drive.google.com/thumbnail?id=1yF4l_i8E57rMS0Y6agMcRcY37QLAPc3y"
            },

            new Boss
            {
                Id = 23,
                Name = "Laurence, the First Vicar",
                Health = 21243,
                BloodEchoes = 29500,
                IsInterruptible = false,
                IsRequired = false,
                IsBeast = true,
                IsKin = false,
                IsWeakToSerrated = true,
                IsWeakToRighteous = false,
                PhysicalDefense = 148,
                BluntDefense = 178,
                ThrustDefense = 148,
                BloodtingeDefense = 148,
                ArcaneDefense = 200,
                FireDefense = 744,
                BoltDefense = 200,
                SlowPoisonResistance = 999,
                RapidPoisonResistance = 999,
                ImageUrl = "https://drive.google.com/thumbnail?id=14rboQE5PZdt3fzVIUvDxmKPfjoxKlzhb"
            },
            
            new Boss
            {
                Id = 24,
                Name = "Living Failures",
                Health = 20646,
                BloodEchoes = 22000,
                IsInterruptible = true,
                IsRequired = false,
                IsBeast = false,
                IsKin = true,
                IsWeakToSerrated = false,
                IsWeakToRighteous = false,
                PhysicalDefense = 239,
                BluntDefense = 273,
                ThrustDefense = 102,
                BloodtingeDefense = 171,
                ArcaneDefense = 256,
                FireDefense = 92,
                BoltDefense = 71,
                SlowPoisonResistance = 250,
                RapidPoisonResistance = 180,
                ImageUrl = "https://drive.google.com/thumbnail?id=10kLcXApZ6tT8ymPWUU7KkOom5gL--oCl"
            },

            new Boss
            {
                Id = 25,
                Name = "Lady Maria of the Astral Clocktower",
                Health = 14081,
                BloodEchoes = 39000,
                IsInterruptible = true,
                IsRequired = false,
                IsBeast = false,
                IsKin = false,
                IsWeakToSerrated = false,
                IsWeakToRighteous = false,
                PhysicalDefense = 147,
                BluntDefense = 147,
                ThrustDefense = 147,
                BloodtingeDefense = 147,
                ArcaneDefense = 103,
                FireDefense = 177,
                BoltDefense = 103,
                SlowPoisonResistance = 999,
                RapidPoisonResistance = 999,
                ImageUrl = "https://drive.google.com/thumbnail?id=1974rhMfWnSucGyiiZ0LWdMw0pa724U7n "
            },
            
            new Boss
            {
                Id = 26,
                Name = "Orphan of Kos 1st Phase",
                Health = 19216,
                BloodEchoes = 60000,
                IsInterruptible = true,
                IsRequired = false,
                IsBeast = false,
                IsKin = false,
                IsWeakToSerrated = false,
                IsWeakToRighteous = false,
                PhysicalDefense = 183,
                BluntDefense = 183,
                ThrustDefense = 183,
                BloodtingeDefense = 183,
                ArcaneDefense = 274,
                FireDefense = 205,
                BoltDefense = 228,
                SlowPoisonResistance = 999,
                RapidPoisonResistance = 999,
                ImageUrl = "https://drive.google.com/thumbnail?id=1s-3cR_6orkA6FuwZ42TqV-SKttZdxRg4"
            },

            new Boss
            {
                Id = 27,
                Name = "Orphan of Kos 2nd Phase",
                Health = 19216,
                BloodEchoes = 60000,
                IsInterruptible = true,
                IsRequired = false,
                IsBeast = false,
                IsKin = false,
                IsWeakToSerrated = false,
                IsWeakToRighteous = false,
                PhysicalDefense = 205,
                BluntDefense = 205,
                ThrustDefense = 205,
                BloodtingeDefense = 205,
                ArcaneDefense = 297,
                FireDefense = 205,
                BoltDefense = 251,
                SlowPoisonResistance = 999,
                RapidPoisonResistance = 999,
                ImageUrl = "https://drive.google.com/thumbnail?id=1s-3cR_6orkA6FuwZ42TqV-SKttZdxRg4"
            }
        };
        
        await _context.Bosses.AddRangeAsync(bosses);
        await _context.SaveChangesAsync();
    }

    private async Task SeedTricksterWeapons()
    {
        var tricksterWeapons = new List<TricksterWeapon>
        {
            new TricksterWeapon {
                Id = 1,
                Name = "Amygdalan Arm",
                PhysicalAttack = 80,
                BloodAttack = 0,
                ArcaneAttack = 40,
                FireAttack = 0,
                BoltAttack = 0,
                BulletUse = 0,
                RapidPoison = 0,
                ImprintsNormal = ImprintType.Imprint223,
                ImprintsUncanny = ImprintType.Imprint224,
                ImprintsLost = ImprintType.Imprint234,
                Rally = 40,
                StrengthRequirement = 17,
                SkillRequirement = 19,
                BloodtingeRequirement = 0,
                ArcaneRequirement = 0,
                MaxUpgradeAttack = 160,
                ImageUrl = "https://drive.google.com/thumbnail?id=1aU3QXrIybOSSxpt5e4NhXx0idoPvhvY1",
                ScalingId = 1
            },

            new TricksterWeapon {
                Id = 2,
                Name = "Beast Claw",
                PhysicalAttack = 75,
                BloodAttack = 0,
                ArcaneAttack = 0,
                FireAttack = 0,
                BoltAttack = 0,
                BulletUse = 0,
                RapidPoison = 0,
                ImprintsNormal = ImprintType.Imprint223,
                ImprintsUncanny = ImprintType.Imprint224,
                ImprintsLost = ImprintType.Imprint234,
                Rally = 25,
                StrengthRequirement = 14,
                SkillRequirement = 12,
                BloodtingeRequirement = 0,
                ArcaneRequirement = 0,
                MaxUpgradeAttack = 150,
                ImageUrl = "https://drive.google.com/thumbnail?id=1rEsZyzc2CeHS9ltXfpoc3BzV1Z45H4Yf",
                ScalingId = 2
            },
            
            new TricksterWeapon {
                Id = 3,
                Name = "Beast Cutter",
                PhysicalAttack = 92,
                BloodAttack = 0,
                ArcaneAttack = 0,
                FireAttack = 0,
                BoltAttack = 0,
                BulletUse = 0,
                RapidPoison = 0,
                ImprintsNormal = ImprintType.Imprint223,
                ImprintsUncanny = ImprintType.Imprint224,
                ImprintsLost = ImprintType.Imprint234,
                Rally = 30,
                StrengthRequirement = 11,
                SkillRequirement = 9,
                BloodtingeRequirement = 0,
                ArcaneRequirement = 0,
                MaxUpgradeAttack = 184,
                ImageUrl = "https://drive.google.com/thumbnail?id=1LCL6A6S1zO3eSWTHQl8TLnRNSG3Ime9M",
                ScalingId = 3
            },
            
            new TricksterWeapon {
                Id = 4,
                Name = "Beasthunter Saif",
                PhysicalAttack = 90,
                BloodAttack = 0,
                ArcaneAttack = 0,
                FireAttack = 0,
                BoltAttack = 0,
                BulletUse = 0,
                RapidPoison = 0,
                ImprintsNormal = ImprintType.Imprint224,
                ImprintsUncanny = ImprintType.Imprint223,
                ImprintsLost = ImprintType.Imprint234,
                Rally = 30,
                StrengthRequirement = 9,
                SkillRequirement = 11,
                BloodtingeRequirement = 0,
                ArcaneRequirement = 0,
                MaxUpgradeAttack = 180,
                ImageUrl = "https://drive.google.com/thumbnail?id=1SVeYUlyn7IFLgeUS8Q_qbfYCnhTKwzVd",
                ScalingId = 4
            },
            
            new TricksterWeapon {
                Id = 5,
                Name = "Blade of Mercy",
                PhysicalAttack = 60,
                BloodAttack = 0,
                ArcaneAttack = 30,
                FireAttack = 0,
                BoltAttack = 0,
                BulletUse = 0,
                RapidPoison = 0,
                ImprintsNormal = ImprintType.Imprint223,
                ImprintsUncanny = ImprintType.Imprint224,
                ImprintsLost = ImprintType.Imprint234,
                Rally = 30,
                StrengthRequirement = 7,
                SkillRequirement = 11,
                BloodtingeRequirement = 0,
                ArcaneRequirement = 0,
                MaxUpgradeAttack = 120,
                ImageUrl = "https://drive.google.com/thumbnail?id=1T8apdQz9asMzJdcFzzSZPjQ5HXXJcIvR",
                ScalingId = 5
            },
            
            new TricksterWeapon {
                Id = 6,
                Name = "Bloodletter",
                PhysicalAttack = 90,
                BloodAttack = 90,
                ArcaneAttack = 0,
                FireAttack = 0,
                BoltAttack = 0,
                BulletUse = 0,
                RapidPoison = 0,
                ImprintsNormal = ImprintType.Imprint223,
                ImprintsUncanny = ImprintType.Imprint224,
                ImprintsLost = ImprintType.Imprint234,
                Rally = 40,
                StrengthRequirement = 14,
                SkillRequirement = 6,
                BloodtingeRequirement = 16,
                ArcaneRequirement = 0,
                MaxUpgradeAttack = 180,
                ImageUrl = "https://drive.google.com/thumbnail?id=120KuWjfTgoqvX0KAq8TTox3hI_lDCSF4",
                ScalingId = 6
            },

            new TricksterWeapon {
                Id = 7,
                Name = "Boom Hammer",
                PhysicalAttack = 90,
                BloodAttack = 0,
                ArcaneAttack = 0,
                FireAttack = 60,
                BoltAttack = 0,
                BulletUse = 0,
                RapidPoison = 0,
                ImprintsNormal = ImprintType.Imprint224,
                ImprintsUncanny = ImprintType.Imprint223,
                ImprintsLost = ImprintType.Imprint234,
                Rally = 45,
                StrengthRequirement = 14,
                SkillRequirement = 8,
                BloodtingeRequirement = 0,
                ArcaneRequirement = 0,
                MaxUpgradeAttack = 180,
                ImageUrl = "https://drive.google.com/thumbnail?id=1aSPnNKsLK3ew094RiQNFK8RrUydYEK8a",
                ScalingId = 7
            },
            
            new TricksterWeapon {
                Id = 8,
                Name = "Burial Blade",
                PhysicalAttack = 80,
                BloodAttack = 0,
                ArcaneAttack = 30,
                FireAttack = 0,
                BoltAttack = 0,
                BulletUse = 0,
                RapidPoison = 0,
                ImprintsNormal = ImprintType.Imprint224,
                ImprintsUncanny = ImprintType.Imprint223,
                ImprintsLost = ImprintType.Imprint234,
                Rally = 50,
                StrengthRequirement = 10,
                SkillRequirement = 12,
                BloodtingeRequirement = 0,
                ArcaneRequirement = 0,
                MaxUpgradeAttack = 160,
                ImageUrl = "https://drive.google.com/thumbnail?id=1srNhvh-GFOu1-qbCrprab3IaDZF0eD1G",
                ScalingId = 8
            },
            
            new TricksterWeapon {
                Id = 9,
                Name = "Chikage",
                PhysicalAttack = 92,
                BloodAttack = 92,
                ArcaneAttack = 0,
                FireAttack = 0,
                BoltAttack = 0,
                BulletUse = 0,
                RapidPoison = 30,
                ImprintsNormal = ImprintType.Imprint223,
                ImprintsUncanny = ImprintType.Imprint224,
                ImprintsLost = ImprintType.Imprint221,
                Rally = 40,
                StrengthRequirement = 10,
                SkillRequirement = 14,
                BloodtingeRequirement = 12,
                ArcaneRequirement = 0,
                MaxUpgradeAttack = 184,
                ImageUrl = "https://drive.google.com/thumbnail?id=1zLKFykmz41QlZozSRv69mmrcj5FmvJRD",
                ScalingId = 9
            },
            
            new TricksterWeapon {
                Id = 10,
                Name = "Church Pick",
                PhysicalAttack = 88,
                BloodAttack = 0,
                ArcaneAttack = 0,
                FireAttack = 0,
                BoltAttack = 0,
                BulletUse = 0,
                RapidPoison = 0,
                ImprintsNormal = ImprintType.Imprint223,
                ImprintsUncanny = ImprintType.Imprint224,
                ImprintsLost = ImprintType.Imprint234,
                Rally = 50,
                StrengthRequirement = 9,
                SkillRequirement = 14,
                BloodtingeRequirement = 0,
                ArcaneRequirement = 0,
                MaxUpgradeAttack = 176,
                ImageUrl = "https://drive.google.com/thumbnail?id=1ShYQbYHLJ5x0K9sRO4FQJMpTEQAyR3M2",
                ScalingId = 10
            },
            
            new TricksterWeapon {
                Id = 11,
                Name = "Holy Moonlight Sword",
                PhysicalAttack = 90,
                BloodAttack = 0,
                ArcaneAttack = 50,
                FireAttack = 0,
                BoltAttack = 0,
                BulletUse = 0,
                RapidPoison = 0,
                ImprintsNormal = ImprintType.Imprint223,
                ImprintsUncanny = ImprintType.Imprint224,
                ImprintsLost = ImprintType.Imprint234,
                Rally = 60,
                StrengthRequirement = 16,
                SkillRequirement = 12,
                BloodtingeRequirement = 0,
                ArcaneRequirement = 14,
                MaxUpgradeAttack = 180,
                ImageUrl = "https://drive.google.com/thumbnail?id=12c1cCYOTIZGHAKBDVYCDJqu8_mdim8rh",
                ScalingId = 11
            },
            
            new TricksterWeapon {
                Id = 12,
                Name = "Hunter Axe",
                PhysicalAttack = 98,
                BloodAttack = 0,
                ArcaneAttack = 0,
                FireAttack = 0,
                BoltAttack = 0,
                BulletUse = 0,
                RapidPoison = 0,
                ImprintsNormal = ImprintType.Imprint223,
                ImprintsUncanny = ImprintType.Imprint224,
                ImprintsLost = ImprintType.Imprint234,
                Rally = 75,
                StrengthRequirement = 9,
                SkillRequirement = 8,
                BloodtingeRequirement = 0,
                ArcaneRequirement = 0,
                MaxUpgradeAttack = 196,
                ImageUrl = "https://drive.google.com/thumbnail?id=1WU3leaWzMh1i3nM1hUynngCXxJaxozHp",
                ScalingId = 12
            },
            
            new TricksterWeapon {
                Id = 13,
                Name = "Kirkhammer",
                PhysicalAttack = 105,
                BloodAttack = 0,
                ArcaneAttack = 0,
                FireAttack = 0,
                BoltAttack = 0,
                BulletUse = 0,
                RapidPoison = 0,
                ImprintsNormal = ImprintType.Imprint223,
                ImprintsUncanny = ImprintType.Imprint224,
                ImprintsLost = ImprintType.Imprint234,
                Rally = 60,
                StrengthRequirement = 16,
                SkillRequirement = 10,
                BloodtingeRequirement = 0,
                ArcaneRequirement = 0,
                MaxUpgradeAttack = 210,
                ImageUrl = "https://drive.google.com/thumbnail?id=1lCV-64Vm0D_PqUcqw8JXQCOnEJKAoGPM",
                ScalingId = 13
            },
            
            new TricksterWeapon {
                Id = 14,
                Name = "Kos Parasite",
                PhysicalAttack = 0,
                BloodAttack = 0,
                ArcaneAttack = 30,
                FireAttack = 0,
                BoltAttack = 0,
                BulletUse = 2,
                RapidPoison = 0,
                ImprintsNormal = ImprintType.Imprint224,
                ImprintsUncanny = ImprintType.Imprint223,
                ImprintsLost = ImprintType.Imprint234,
                Rally = 30,
                StrengthRequirement = 0,
                SkillRequirement = 0,
                BloodtingeRequirement = 0,
                ArcaneRequirement = 20,
                MaxUpgradeAttack = 60,
                ImageUrl = "https://drive.google.com/thumbnail?id=16W3O-NhoSF-0R_15SptI3puxrbRRXWGh",
                ScalingId = 14
            },

            new TricksterWeapon {
                Id = 15,
                Name = "Logarius' Wheel",
                PhysicalAttack = 100,
                BloodAttack = 0,
                ArcaneAttack = 25,
                FireAttack = 0,
                BoltAttack = 0,
                BulletUse = 0,
                RapidPoison = 0,
                ImprintsNormal = ImprintType.Imprint224,
                ImprintsUncanny = ImprintType.Imprint223,
                ImprintsLost = ImprintType.Imprint234,
                Rally = 30,
                StrengthRequirement = 20,
                SkillRequirement = 12,
                BloodtingeRequirement = 0,
                ArcaneRequirement = 10,
                MaxUpgradeAttack = 200,
                ImageUrl = "https://drive.google.com/thumbnail?id=1zcnGw9Jf16gyslCcDbkkMKemdzhTtm_p",
                ScalingId = 15
            },
            
            new TricksterWeapon {
                Id = 16,
                Name = "Ludwig's Holy Blade",
                PhysicalAttack = 100,
                BloodAttack = 0,
                ArcaneAttack = 0,
                FireAttack = 0,
                BoltAttack = 0,
                BulletUse = 0,
                RapidPoison = 0,
                ImprintsNormal = ImprintType.Imprint224,
                ImprintsUncanny = ImprintType.Imprint223,
                ImprintsLost = ImprintType.Imprint234,
                Rally = 60,
                StrengthRequirement = 16,
                SkillRequirement = 12,
                BloodtingeRequirement = 0,
                ArcaneRequirement = 0,
                MaxUpgradeAttack = 200,
                ImageUrl = "https://drive.google.com/thumbnail?id=1aliXp7ODrWl7ridFiIt0MzXzHlZIGH8E",
                ScalingId = 16
            },
            
            new TricksterWeapon {
                Id = 17,
                Name = "Rakuyo",
                PhysicalAttack = 82,
                BloodAttack = 0,
                ArcaneAttack = 0,
                FireAttack = 0,
                BoltAttack = 0,
                BulletUse = 0,
                RapidPoison = 0,
                ImprintsNormal = ImprintType.Imprint223,
                ImprintsUncanny = ImprintType.Imprint224,
                ImprintsLost = ImprintType.Imprint234,
                Rally = 40,
                StrengthRequirement = 10,
                SkillRequirement = 20,
                BloodtingeRequirement = 0,
                ArcaneRequirement = 0,
                MaxUpgradeAttack = 164,
                ImageUrl = "https://drive.google.com/thumbnail?id=1Zx0cHUUQNBJUtJo64U0AE3QGcywPn4Wx",
                ScalingId = 17
            },
            
            new TricksterWeapon {
                Id = 18,
                Name = "Reiterpallasch",
                PhysicalAttack = 75,
                BloodAttack = 75,
                ArcaneAttack = 0,
                FireAttack = 0,
                BoltAttack = 0,
                BulletUse = 1,
                RapidPoison = 0,
                ImprintsNormal = ImprintType.Imprint223,
                ImprintsUncanny = ImprintType.Imprint224,
                ImprintsLost = ImprintType.Imprint234,
                Rally = 40,
                StrengthRequirement = 8,
                SkillRequirement = 12,
                BloodtingeRequirement = 10,
                ArcaneRequirement = 0,
                MaxUpgradeAttack = 150,
                ImageUrl = "https://drive.google.com/thumbnail?id=1itvWdRSAjQSeaw93mjMxkfb_yt1IDVuR",
                ScalingId = 18
            },
            
            new TricksterWeapon {
                Id = 19,
                Name = "Rifle Spear",
                PhysicalAttack = 85,
                BloodAttack = 85,
                ArcaneAttack = 0,
                FireAttack = 0,
                BoltAttack = 0,
                BulletUse = 1,
                RapidPoison = 0,
                ImprintsNormal = ImprintType.Imprint223,
                ImprintsUncanny = ImprintType.Imprint224,
                ImprintsLost = ImprintType.Imprint234,
                Rally = 40,
                StrengthRequirement = 10,
                SkillRequirement = 11,
                BloodtingeRequirement = 9,
                ArcaneRequirement = 0,
                MaxUpgradeAttack = 170,
                ImageUrl = "https://drive.google.com/thumbnail?id=16l0dhQIXhgMelPV2ESQ0ZzMuG97NqamP",
                ScalingId = 19
            },
            
            new TricksterWeapon {
                Id = 20,
                Name = "Saw Cleaver",
                PhysicalAttack = 90,
                BloodAttack = 0,
                ArcaneAttack = 0,
                FireAttack = 0,
                BoltAttack = 0,
                BulletUse = 0,
                RapidPoison = 0,
                ImprintsNormal = ImprintType.Imprint224,
                ImprintsUncanny = ImprintType.Imprint223,
                ImprintsLost = ImprintType.Imprint234,
                Rally = 35,
                StrengthRequirement = 8,
                SkillRequirement = 7,
                BloodtingeRequirement = 0,
                ArcaneRequirement = 0,
                MaxUpgradeAttack = 180,
                ImageUrl = "https://drive.google.com/thumbnail?id=15Rz5YvcrKKYzSOdqxVHVw-1Udn_TbIU1",
                ScalingId = 20
            },
            
            new TricksterWeapon {
                Id = 21,
                Name = "Saw Spear",
                PhysicalAttack = 85,
                BloodAttack = 0,
                ArcaneAttack = 0,
                FireAttack = 0,
                BoltAttack = 0,
                BulletUse = 0,
                RapidPoison = 0,
                ImprintsNormal = ImprintType.Imprint223,
                ImprintsUncanny = ImprintType.Imprint224,
                ImprintsLost = ImprintType.Imprint234,
                Rally = 35,
                StrengthRequirement = 7,
                SkillRequirement = 8,
                BloodtingeRequirement = 0,
                ArcaneRequirement = 0,
                MaxUpgradeAttack = 170,
                ImageUrl = "https://drive.google.com/thumbnail?id=1jW750naxJbtPsIg29DL3Xs-X7_S0S10P",
                ScalingId = 21
            },
            
            new TricksterWeapon {
                Id = 22,
                Name = "Simon's Bowblade",
                PhysicalAttack = 80,
                BloodAttack = 80,
                ArcaneAttack = 0,
                FireAttack = 0,
                BoltAttack = 0,
                BulletUse = 1,
                RapidPoison = 0,
                ImprintsNormal = ImprintType.Imprint223,
                ImprintsUncanny = ImprintType.Imprint224,
                ImprintsLost = ImprintType.Imprint234,
                Rally = 35,
                StrengthRequirement = 8,
                SkillRequirement = 15,
                BloodtingeRequirement = 9,
                ArcaneRequirement = 0,
                MaxUpgradeAttack = 160,
                ImageUrl = "https://drive.google.com/thumbnail?id=12yIV1SdxLNEdtwUuvLeKYQQ6rgwriq4t",
                ScalingId = 22
            },
            
            new TricksterWeapon {
                Id = 23,
                Name = "Stake Driver",
                PhysicalAttack = 85,
                BloodAttack = 0,
                ArcaneAttack = 0,
                FireAttack = 0,
                BoltAttack = 0,
                BulletUse = 0,
                RapidPoison = 0,
                ImprintsNormal = ImprintType.Imprint223,
                ImprintsUncanny = ImprintType.Imprint224,
                ImprintsLost = ImprintType.Imprint234,
                Rally = 35,
                StrengthRequirement = 18,
                SkillRequirement = 9,
                BloodtingeRequirement = 0,
                ArcaneRequirement = 0,
                MaxUpgradeAttack = 170,
                ImageUrl = "https://drive.google.com/thumbnail?id=1itvzCoxMbHANtxSaHaM6SbEOgjK7XMz4",
                ScalingId = 23
            },
            
            new TricksterWeapon {
                Id = 24,
                Name = "Threaded Cane",
                PhysicalAttack = 78,
                BloodAttack = 0,
                ArcaneAttack = 0,
                FireAttack = 0,
                BoltAttack = 0,
                BulletUse = 0,
                RapidPoison = 0,
                ImprintsNormal = ImprintType.Imprint223,
                ImprintsUncanny = ImprintType.Imprint224,
                ImprintsLost = ImprintType.Imprint234,
                Rally = 35,
                StrengthRequirement = 7,
                SkillRequirement = 9,
                BloodtingeRequirement = 0,
                ArcaneRequirement = 0,
                MaxUpgradeAttack = 156,
                ImageUrl = "https://drive.google.com/thumbnail?id=1znUsZ0AmIxah1456mE57lEqeWnW2KWUk",
                ScalingId = 24
            },
            
            new TricksterWeapon {
                Id = 25,
                Name = "Tonitrus",
                PhysicalAttack = 80,
                BloodAttack = 0,
                ArcaneAttack = 0,
                FireAttack = 0,
                BoltAttack = 40,
                BulletUse = 0,
                RapidPoison = 0,
                ImprintsNormal = ImprintType.Imprint224,
                ImprintsUncanny = ImprintType.Imprint223,
                ImprintsLost = ImprintType.Imprint234,
                Rally = 45,
                StrengthRequirement = 12,
                SkillRequirement = 8,
                BloodtingeRequirement = 0,
                ArcaneRequirement = 0,
                MaxUpgradeAttack = 160,
                ImageUrl = "https://drive.google.com/thumbnail?id=1B_iNCeYz-vMMB3L0W7GPHzrEJd4Ugs-a",
                ScalingId = 25
            },
            
            new TricksterWeapon {
                Id = 26,
                Name = "Whirligig Saw",
                PhysicalAttack = 95,
                BloodAttack = 0,
                ArcaneAttack = 0,
                FireAttack = 0,
                BoltAttack = 0,
                BulletUse = 0,
                RapidPoison = 0,
                ImprintsNormal = ImprintType.Imprint223,
                ImprintsUncanny = ImprintType.Imprint224,
                ImprintsLost = ImprintType.Imprint234,
                Rally = 60,
                StrengthRequirement = 18,
                SkillRequirement = 12,
                BloodtingeRequirement = 0,
                ArcaneRequirement = 0,
                MaxUpgradeAttack = 190,
                ImageUrl = "https://drive.google.com/thumbnail?id=1Cu5jyE751NVGeAYDkOHTrZ6sGYdoReHw",
                ScalingId = 26
            },
        };

        await _context.TricksterWeapons.AddRangeAsync(tricksterWeapons);
        await _context.SaveChangesAsync();
    }

    private async Task SeedFirearms()
    {
        var firearms = new List<Firearm>
        {
            new Firearm
                {
                    Id = 1,
                    Name = "Cannon",
                    PhysicalAttack = 0,
                    BloodAttack = 200,
                    ArcaneAttack = 0,
                    FireAttack = 0,
                    BoltAttack = 0,
                    BulletUse = 12,
                    Imprints = ImprintType.Imprint0,
                    StrengthRequirement = 30,
                    SkillRequirement = 13,
                    BloodtingeRequirement = 0,
                    ArcaneRequirement = 0,
                    ImageUrl = "https://drive.google.com/thumbnail?id=1phH1lPkrpGd6GH3AoV_UAjBueEB31EhW",
                    ScalingId = 27
                },
                new Firearm
                {
                    Id = 2,
                    Name = "Church Cannon",
                    PhysicalAttack = 0,
                    BloodAttack = 160,
                    ArcaneAttack = 0,
                    FireAttack = 0,
                    BoltAttack = 0,
                    BulletUse = 10,
                    Imprints = ImprintType.Imprint0,
                    StrengthRequirement = 27,
                    SkillRequirement = 0,
                    BloodtingeRequirement = 16,
                    ArcaneRequirement = 0,
                    ImageUrl = "https://drive.google.com/thumbnail?id=154vedngen7dbZgF9kGgdg9bYDotw4bUU",
                    ScalingId = 28
                },
                new Firearm
                {
                    Id = 3,
                    Name = "Evelyn",
                    PhysicalAttack = 0,
                    BloodAttack = 60,
                    ArcaneAttack = 0,
                    FireAttack = 0,
                    BoltAttack = 0,
                    BulletUse = 1,
                    Imprints = ImprintType.Imprint1,
                    StrengthRequirement = 9,
                    SkillRequirement = 11,
                    BloodtingeRequirement = 18,
                    ArcaneRequirement = 0,
                    ImageUrl = "https://drive.google.com/thumbnail?id=1vLeKk248L5w6wUsXQEkh-j2w-llc4W8W",
                    ScalingId = 29
                },
                new Firearm
                {
                    Id = 4,
                    Name = "Fist of Gratia",
                    PhysicalAttack = 60,
                    BloodAttack = 0,
                    ArcaneAttack = 0,
                    FireAttack = 0,
                    BoltAttack = 0,
                    BulletUse = 0,
                    Imprints = ImprintType.Imprint0,
                    StrengthRequirement = 7,
                    SkillRequirement = 9,
                    BloodtingeRequirement = 5,
                    ArcaneRequirement = 0,
                    ImageUrl = "https://drive.google.com/thumbnail?id=1aM88oA5wTOoadO_K0w8bxiG43xcCgSWR",
                    ScalingId = 30
                },
                new Firearm
                {
                    Id = 5,
                    Name = "Flamesprayer",
                    PhysicalAttack = 0,
                    BloodAttack = 0,
                    ArcaneAttack = 0,
                    FireAttack = 45,
                    BoltAttack = 0,
                    BulletUse = 1,
                    Imprints = ImprintType.Imprint0,
                    StrengthRequirement = 0,
                    SkillRequirement = 8,
                    BloodtingeRequirement = 0,
                    ArcaneRequirement = 8,
                    ImageUrl = "https://drive.google.com/thumbnail?id=15k_Ka4NQMRZ1H34tQUqlHI-mQmOu_gC7",
                    ScalingId = 31
                },
                new Firearm
                {
                    Id = 6,
                    Name = "Gatling Gun",
                    PhysicalAttack = 0,
                    BloodAttack = 80,
                    ArcaneAttack = 0,
                    FireAttack = 0,
                    BoltAttack = 0,
                    BulletUse = 1,
                    Imprints = ImprintType.Imprint1,
                    StrengthRequirement = 28,
                    SkillRequirement = 12,
                    BloodtingeRequirement = 0,
                    ArcaneRequirement = 0,
                    ImageUrl = "https://drive.google.com/thumbnail?id=1-QdnbMVbbY4JmgNPInCyVuSMzry5D9yO",
                    ScalingId = 32
                },
                new Firearm
                {
                    Id = 7,
                    Name = "Hunter Blunderbuss",
                    PhysicalAttack = 0,
                    BloodAttack = 20,
                    ArcaneAttack = 0,
                    FireAttack = 0,
                    BoltAttack = 0,
                    BulletUse = 1,
                    Imprints = ImprintType.Imprint1,
                    StrengthRequirement = 7,
                    SkillRequirement = 9,
                    BloodtingeRequirement = 5,
                    ArcaneRequirement = 0,
                    ImageUrl = "https://drive.google.com/thumbnail?id=1fBiy-VyK3RZq2ZBfDbaKo1_SPpj7M46c",
                    ScalingId = 33
                },
                new Firearm
                {
                    Id = 8,
                    Name = "Hunter Pistol",
                    PhysicalAttack = 0,
                    BloodAttack = 70,
                    ArcaneAttack = 0,
                    FireAttack = 0,
                    BoltAttack = 0,
                    BulletUse = 1,
                    Imprints = ImprintType.Imprint1,
                    StrengthRequirement = 7,
                    SkillRequirement = 9,
                    BloodtingeRequirement = 5,
                    ArcaneRequirement = 0,
                    ImageUrl = "https://drive.google.com/thumbnail?id=1TXCHYNKf4Trj66nE4-wKuLEXaCj9gX9H",
                    ScalingId = 34
                },
                new Firearm
                {
                    Id = 9,
                    Name = "Ludwig's Rifle",
                    PhysicalAttack = 0,
                    BloodAttack = 20,
                    ArcaneAttack = 0,
                    FireAttack = 0,
                    BoltAttack = 0,
                    BulletUse = 1,
                    Imprints = ImprintType.Imprint1,
                    StrengthRequirement = 9,
                    SkillRequirement = 10,
                    BloodtingeRequirement = 9,
                    ArcaneRequirement = 0,
                    ImageUrl = "https://drive.google.com/thumbnail?id=149FJ_q_Z6S1Xxl0P2uYe6dXOejd3yiRH",
                    ScalingId = 35
                },
                new Firearm
                {
                    Id = 10,
                    Name = "Piercing Rifle",
                    PhysicalAttack = 0,
                    BloodAttack = 80,
                    ArcaneAttack = 0,
                    FireAttack = 0,
                    BoltAttack = 0,
                    BulletUse = 1,
                    Imprints = ImprintType.Imprint1,
                    StrengthRequirement = 9,
                    SkillRequirement = 10,
                    BloodtingeRequirement = 9,
                    ArcaneRequirement = 0,
                    ImageUrl = "https://drive.google.com/thumbnail?id=1BII4cGgR44f1ub78C7VEywrwgmdCtz8x",
                    ScalingId = 36
                },
                new Firearm
                {
                    Id = 11,
                    Name = "Repeating Pistol",
                    PhysicalAttack = 0,
                    BloodAttack = 90,
                    ArcaneAttack = 0,
                    FireAttack = 0,
                    BoltAttack = 0,
                    BulletUse = 2,
                    Imprints = ImprintType.Imprint1,
                    StrengthRequirement = 10,
                    SkillRequirement = 11,
                    BloodtingeRequirement = 8,
                    ArcaneRequirement = 0,
                    ImageUrl = "https://drive.google.com/thumbnail?id=1ENCHvfhBTPQ5cGQaZm31gGRi1uIhS7h5",
                    ScalingId = 37
                },
                new Firearm
                {
                    Id = 12,
                    Name = "Rosmarinus",
                    PhysicalAttack = 0,
                    BloodAttack = 0,
                    ArcaneAttack = 30,
                    FireAttack = 0,
                    BoltAttack = 0,
                    BulletUse = 1,
                    Imprints = ImprintType.Imprint0,
                    StrengthRequirement = 0,
                    SkillRequirement = 8,
                    BloodtingeRequirement = 0,
                    ArcaneRequirement = 8,
                    ImageUrl = "https://drive.google.com/thumbnail?id=1H_96ZFuSKia9V7ROyItguhxjWI-_aocE",
                    ScalingId = 38
                }
        };

        await _context.Firearms.AddRangeAsync(firearms);
        await _context.SaveChangesAsync();
    }

    private async Task SeedAttacks()
    {
        var attacks = new List<Attack> {
            new Attack {
                Id = 1,
                Name = "R1",
                Damage = 1.0m,
                ExtraDamage = 0.0m,
                ExtraDamageCount = 0,
                AttackType1 = AttackType.Blunt,
                AttackType2 = AttackType.Arcane,
                AttackMode = AttackMode.Normal,
                TricksterWeaponId = 1
            },

            new Attack {
                Id = 2,
                Name = "R1 (2nd)",
                Damage = 1.0m,
                ExtraDamage = 0.0m,
                ExtraDamageCount = 0,
                AttackType1 = AttackType.Blunt,
                AttackType2 = AttackType.Arcane,
                AttackMode = AttackMode.Normal,
                TricksterWeaponId = 1
            },

            new Attack {
                Id = 3,
                Name = "R1 (3rd)",
                Damage = 1.1m,
                ExtraDamage = 0.0m,
                ExtraDamageCount = 0,
                AttackType1 = AttackType.Blunt,
                AttackType2 = AttackType.Arcane,
                AttackMode = AttackMode.Normal,
                TricksterWeaponId = 1
            },
            
            new Attack {
                Id = 4,
                Name = "R1 (4th)",
                Damage = 1.2m,
                ExtraDamage = 0.0m,
                ExtraDamageCount = 0,
                AttackType1 = AttackType.Blunt,
                AttackType2 = AttackType.Arcane,
                AttackMode = AttackMode.Normal,
                TricksterWeaponId = 1
            },
            
            new Attack {
                Id = 5,
                Name = "R1 (backstep)",
                Damage = 0.95m,
                ExtraDamage = 0.0m,
                ExtraDamageCount = 0,
                AttackType1 = AttackType.Blunt,
                AttackType2 = AttackType.Arcane,
                AttackMode = AttackMode.Normal,
                TricksterWeaponId = 1
            },
            
            new Attack {
                Id = 6,
                Name = "R1 (rolling)",
                Damage = 0.95m,
                ExtraDamage = 0.0m,
                ExtraDamageCount = 0,
                AttackType1 = AttackType.Blunt,
                AttackType2 = AttackType.Arcane,
                AttackMode = AttackMode.Normal,
                TricksterWeaponId = 1
            },
            
            new Attack {
                Id = 7,
                Name = "R1 (frontstep)",
                Damage = 0.95m,
                ExtraDamage = 0.0m,
                ExtraDamageCount = 0,
                AttackType1 = AttackType.Blunt,
                AttackType2 = AttackType.Arcane,
                AttackMode = AttackMode.Normal,
                TricksterWeaponId = 1
            },
            
            new Attack {
                Id = 8,
                Name = "R1 (sidestep)",
                Damage = 0.95m,
                ExtraDamage = 0.0m,
                ExtraDamageCount = 0,
                AttackType1 = AttackType.Blunt,
                AttackType2 = AttackType.Arcane,
                AttackMode = AttackMode.Normal,
                TricksterWeaponId = 1
            },
            
            new Attack {
                Id = 9,
                Name = "R1 (dash)",
                Damage = 1.1m,
                ExtraDamage = 0.0m,
                ExtraDamageCount = 0,
                AttackType1 = AttackType.Blunt,
                AttackType2 = AttackType.Arcane,
                AttackMode = AttackMode.Normal,
                TricksterWeaponId = 1
            },
            
            new Attack {
                Id = 10,
                Name = "R2",
                Damage = 1.3m,
                ExtraDamage = 0.0m,
                ExtraDamageCount = 0,
                AttackType1 = AttackType.Blunt,
                AttackType2 = AttackType.Arcane,
                AttackMode = AttackMode.Normal,
                TricksterWeaponId = 1
            },
            
            new Attack {
                Id = 11,
                Name = "R2 (charged)",
                Damage = 1.8m,
                ExtraDamage = 0.0m,
                ExtraDamageCount = 0,
                AttackType1 = AttackType.Blunt,
                AttackType2 = AttackType.Arcane,
                AttackMode = AttackMode.Normal,
                TricksterWeaponId = 1
            },
            
            new Attack {
                Id = 12,
                Name = "R2 (follow-up)",
                Damage = 1.8m,
                ExtraDamage = 0.0m,
                ExtraDamageCount = 0,
                AttackType1 = AttackType.Blunt,
                AttackType2 = AttackType.Arcane,
                AttackMode = AttackMode.Normal,
                TricksterWeaponId = 1
            },
            
            new Attack {
                Id = 13,
                Name = "R2 (backstep)",
                Damage = 1.35m,
                ExtraDamage = 0.0m,
                ExtraDamageCount = 0,
                AttackType1 = AttackType.Blunt,
                AttackType2 = AttackType.Arcane,
                AttackMode = AttackMode.Normal,
                TricksterWeaponId = 1
            },
            
            new Attack {
                Id = 14,
                Name = "R2 (dash)",
                Damage = 1.4m,
                ExtraDamage = 0.0m,
                ExtraDamageCount = 0,
                AttackType1 = AttackType.Blunt,
                AttackType2 = AttackType.Arcane,
                AttackMode = AttackMode.Normal,
                TricksterWeaponId = 1
            },
            
            new Attack {
                Id = 15,
                Name = "R2 (forward leap)",
                Damage = 1.4m,
                ExtraDamage = 0.0m,
                ExtraDamageCount = 0,
                AttackType1 = AttackType.Blunt,
                AttackType2 = AttackType.Arcane,
                AttackMode = AttackMode.Normal,
                TricksterWeaponId = 1
            },
            
            new Attack {
                Id = 16,
                Name = "Transform Attack",
                Damage = 1.15m,
                ExtraDamage = 0.0m,
                ExtraDamageCount = 0,
                AttackType1 = AttackType.Physical,
                AttackType2 = AttackType.Arcane,
                AttackMode = AttackMode.Normal,
                TricksterWeaponId = 1
            },
            
            new Attack {
                Id = 17,
                Name = "Plunge Attack",
                Damage = 1.4m,
                ExtraDamage = 0.0m,
                ExtraDamageCount = 0,
                AttackType1 = AttackType.Blunt,
                AttackType2 = AttackType.Arcane,
                AttackMode = AttackMode.Normal,
                TricksterWeaponId = 1
            },
            
            new Attack {
                Id = 18,
                Name = "Plunge Attack (2nd)",
                Damage = 0.9m,
                ExtraDamage = 0.0m,
                ExtraDamageCount = 0,
                AttackType1 = AttackType.Blunt,
                AttackType2 = AttackType.Arcane,
                AttackMode = AttackMode.Normal,
                TricksterWeaponId = 1
            },
            
            new Attack {
                Id = 19,
                Name = "R1",
                Damage = 0.95m,
                ExtraDamage = 0.0m,
                ExtraDamageCount = 0,
                AttackType1 = AttackType.Physical,
                AttackType2 = AttackType.Arcane,
                AttackMode = AttackMode.Transformed,
                TricksterWeaponId = 1
            },
            
            new Attack {
                Id = 20,
                Name = "R1 (2nd)",
                Damage = 1.0m,
                ExtraDamage = 0.0m,
                ExtraDamageCount = 0,
                AttackType1 = AttackType.Physical,
                AttackType2 = AttackType.Arcane,
                AttackMode = AttackMode.Transformed,
                TricksterWeaponId = 1
            },
            
            new Attack {
                Id = 21,
                Name = "R1 (3rd)",
                Damage = 1.05m,
                ExtraDamage = 0.0m,
                ExtraDamageCount = 0,
                AttackType1 = AttackType.Physical,
                AttackType2 = AttackType.Arcane,
                AttackMode = AttackMode.Transformed,
                TricksterWeaponId = 1
            },
            
            new Attack {
                Id = 22,
                Name = "R1 (4th)",
                Damage = 1.15m,
                ExtraDamage = 0.0m,
                ExtraDamageCount = 0,
                AttackType1 = AttackType.Physical,
                AttackType2 = AttackType.Arcane,
                AttackMode = AttackMode.Transformed,
                TricksterWeaponId = 1
            },
            
            new Attack {
                Id = 23,
                Name = "R1 (backstep)",
                Damage = 0.9m,
                ExtraDamage = 0.0m,
                ExtraDamageCount = 0,
                AttackType1 = AttackType.Physical,
                AttackType2 = AttackType.Arcane,
                AttackMode = AttackMode.Transformed,
                TricksterWeaponId = 1
            },
            
            new Attack {
                Id = 24,
                Name = "R1 (rolling)",
                Damage = 0.9m,
                ExtraDamage = 0.0m,
                ExtraDamageCount = 0,
                AttackType1 = AttackType.Physical,
                AttackType2 = AttackType.Arcane,
                AttackMode = AttackMode.Transformed,
                TricksterWeaponId = 1
            },
            
            new Attack {
                Id = 25,
                Name = "R1 (frontstep)",
                Damage = 0.9m,
                ExtraDamage = 0.0m,
                ExtraDamageCount = 0,
                AttackType1 = AttackType.Physical,
                AttackType2 = AttackType.Arcane,
                AttackMode = AttackMode.Transformed,
                TricksterWeaponId = 1
            },
            
            new Attack {
                Id = 26,
                Name = "R1 (sidestep)",
                Damage = 0.9m,
                ExtraDamage = 0.0m,
                ExtraDamageCount = 0,
                AttackType1 = AttackType.Physical,
                AttackType2 = AttackType.Arcane,
                AttackMode = AttackMode.Transformed,
                TricksterWeaponId = 1
            },
            
            new Attack {
                Id = 27,
                Name = "R1 (dash)",
                Damage = 1.1m,
                ExtraDamage = 0.0m,
                ExtraDamageCount = 0,
                AttackType1 = AttackType.Physical,
                AttackType2 = AttackType.Arcane,
                AttackMode = AttackMode.Transformed,
                TricksterWeaponId = 1
            },
            
            new Attack {
                Id = 28,
                Name = "R2",
                Damage = 1.2m,
                ExtraDamage = 0.0m,
                ExtraDamageCount = 0,
                AttackType1 = AttackType.Thrust,
                AttackType2 = AttackType.Arcane,
                AttackMode = AttackMode.Transformed,
                TricksterWeaponId = 1
            },
            
            new Attack {
                Id = 29,
                Name = "R2 (2nd)",
                Damage = 0.8m,
                ExtraDamage = 0.0m,
                ExtraDamageCount = 0,
                AttackType1 = AttackType.Physical,
                AttackType2 = AttackType.Arcane,
                AttackMode = AttackMode.Transformed,
                TricksterWeaponId = 1
            },
            
            new Attack {
                Id = 30,
                Name = "R2 (charged)",
                Damage = 1.7m,
                ExtraDamage = 0.0m,
                ExtraDamageCount = 0,
                AttackType1 = AttackType.Blunt,
                AttackType2 = AttackType.Arcane,
                AttackMode = AttackMode.Transformed,
                TricksterWeaponId = 1
            },
            
            new Attack {
                Id = 31,
                Name = "R2 (charged) (2nd)",
                Damage = 0.8m,
                ExtraDamage = 0.0m,
                ExtraDamageCount = 0,
                AttackType1 = AttackType.Physical,
                AttackType2 = AttackType.Arcane,
                AttackMode = AttackMode.Transformed,
                TricksterWeaponId = 1
            },
            
            new Attack {
                Id = 32,
                Name = "R2 (charged) (3rd)",
                Damage = 0.85m,
                ExtraDamage = 0.0m,
                ExtraDamageCount = 0,
                AttackType1 = AttackType.Physical,
                AttackType2 = AttackType.Arcane,
                AttackMode = AttackMode.Transformed,
                TricksterWeaponId = 1
            },
            
            new Attack {
                Id = 33,
                Name = "R2 (backstep)",
                Damage = 1.2m,
                ExtraDamage = 0.0m,
                ExtraDamageCount = 0,
                AttackType1 = AttackType.Thrust,
                AttackType2 = AttackType.Arcane,
                AttackMode = AttackMode.Transformed,
                TricksterWeaponId = 1
            },
            
            new Attack {
                Id = 34,
                Name = "R2 (dash)",
                Damage = 1.3m,
                ExtraDamage = 0.0m,
                ExtraDamageCount = 0,
                AttackType1 = AttackType.Physical,
                AttackType2 = AttackType.Arcane,
                AttackMode = AttackMode.Transformed,
                TricksterWeaponId = 1
            },
            
            new Attack {
                Id = 35,
                Name = "R2 (forward leap)",
                Damage = 1.4m,
                ExtraDamage = 0.0m,
                ExtraDamageCount = 0,
                AttackType1 = AttackType.Blunt,
                AttackType2 = AttackType.Arcane,
                AttackMode = AttackMode.Transformed,
                TricksterWeaponId = 1
            },
            
            new Attack {
                Id = 36,
                Name = "Transform Attack",
                Damage = 1.5m,
                ExtraDamage = 0.0m,
                ExtraDamageCount = 0,
                AttackType1 = AttackType.Blunt,
                AttackType2 = AttackType.Arcane,
                AttackMode = AttackMode.Transformed,
                TricksterWeaponId = 1
            },
            
            new Attack {
                Id = 37,
                Name = "Plunge Attack",
                Damage = 1.4m,
                ExtraDamage = 0.0m,
                ExtraDamageCount = 0,
                AttackType1 = AttackType.Physical,
                AttackType2 = AttackType.Arcane,
                AttackMode = AttackMode.Transformed,
                TricksterWeaponId = 1
            },
            
            new Attack {
                Id = 38,
                Name = "Plunge Attack (2nd)",
                Damage = 0.9m,
                ExtraDamage = 0.0m,
                ExtraDamageCount = 0,
                AttackType1 = AttackType.Blunt,
                AttackType2 = AttackType.Arcane,
                AttackMode = AttackMode.Transformed,
                TricksterWeaponId = 1
            },
            
            new Attack {
                Id = 39,
                Name = "R1",
                Damage = 1.0m,
                ExtraDamage = 0.0m,
                ExtraDamageCount = 0,
                AttackType1 = AttackType.Physical,
                AttackType2 = AttackType.None,
                AttackMode = AttackMode.Normal,
                TricksterWeaponId = 2
            },
            
            new Attack {
                Id = 40,
                Name = "R1 (2nd)",
                Damage = 1.02m,
                ExtraDamage = 0.0m,
                ExtraDamageCount = 0,
                AttackType1 = AttackType.Physical,
                AttackType2 = AttackType.None,
                AttackMode = AttackMode.Normal,
                TricksterWeaponId = 2
            },
            
            new Attack {
                Id = 41,
                Name = "R1 (3rd)",
                Damage = 1.04m,
                ExtraDamage = 0.0m,
                ExtraDamageCount = 0,
                AttackType1 = AttackType.Physical,
                AttackType2 = AttackType.None,
                AttackMode = AttackMode.Normal,
                TricksterWeaponId = 2
            },
            
            new Attack {
                Id = 42,
                Name = "R1 (4th)",
                Damage = 1.06m,
                ExtraDamage = 0.0m,
                ExtraDamageCount = 0,
                AttackType1 = AttackType.Physical,
                AttackType2 = AttackType.None,
                AttackMode = AttackMode.Normal,
                TricksterWeaponId = 2
            },
            
            new Attack {
                Id = 43,
                Name = "R1 (5th)",
                Damage = 1.08m,
                ExtraDamage = 0.0m,
                ExtraDamageCount = 0,
                AttackType1 = AttackType.Physical,
                AttackType2 = AttackType.None,
                AttackMode = AttackMode.Normal,
                TricksterWeaponId = 2
            },
            
            new Attack {
                Id = 44,
                Name = "R1 (backstep)",
                Damage = 0.95m,
                ExtraDamage = 0.0m,
                ExtraDamageCount = 0,
                AttackType1 = AttackType.Physical,
                AttackType2 = AttackType.None,
                AttackMode = AttackMode.Normal,
                TricksterWeaponId = 2
            },
            
            new Attack {
                Id = 45,
                Name = "R1 (rolling)",
                Damage = 0.88m,
                ExtraDamage = 0.0m,
                ExtraDamageCount = 0,
                AttackType1 = AttackType.Thrust,
                AttackType2 = AttackType.None,
                AttackMode = AttackMode.Normal,
                TricksterWeaponId = 2
            },
            
            new Attack {
                Id = 46,
                Name = "R1 (frontstep)",
                Damage = 0.88m,
                ExtraDamage = 0.0m,
                ExtraDamageCount = 0,
                AttackType1 = AttackType.Thrust,
                AttackType2 = AttackType.None,
                AttackMode = AttackMode.Normal,
                TricksterWeaponId = 2
            },

            new Attack {
                Id = 47,
                Name = "R1 (sidestep)",
                Damage = 0.95m,
                ExtraDamage = 0.0m,
                ExtraDamageCount = 0,
                AttackType1 = AttackType.Physical,
                AttackType2 = AttackType.None,
                AttackMode = AttackMode.Normal,
                TricksterWeaponId = 2
            },
            
            new Attack {
                Id = 48,
                Name = "R1 (dash)",
                Damage = 1.0m,
                ExtraDamage = 0.0m,
                ExtraDamageCount = 0,
                AttackType1 = AttackType.Physical,
                AttackType2 = AttackType.None,
                AttackMode = AttackMode.Normal,
                TricksterWeaponId = 2
            },
            
            new Attack {
                Id = 49,
                Name = "R2",
                Damage = 1.25m,
                ExtraDamage = 0.0m,
                ExtraDamageCount = 0,
                AttackType1 = AttackType.Physical,
                AttackType2 = AttackType.None,
                AttackMode = AttackMode.Normal,
                TricksterWeaponId = 2
            },
            
            new Attack {
                Id = 50,
                Name = "R2 (charged)",
                Damage = 1.8m,
                ExtraDamage = 0.0m,
                ExtraDamageCount = 0,
                AttackType1 = AttackType.Physical,
                AttackType2 = AttackType.None,
                AttackMode = AttackMode.Normal,
                TricksterWeaponId = 2
            },
            
            new Attack {
                Id = 51,
                Name = "R2 (backstep)",
                Damage = 1.2m,
                ExtraDamage = 0.0m,
                ExtraDamageCount = 0,
                AttackType1 = AttackType.Physical,
                AttackType2 = AttackType.None,
                AttackMode = AttackMode.Normal,
                TricksterWeaponId = 2
            },
            
            new Attack {
                Id = 52,
                Name = "R2 (dash)",
                Damage = 1.25m,
                ExtraDamage = 0.0m,
                ExtraDamageCount = 0,
                AttackType1 = AttackType.Thrust,
                AttackType2 = AttackType.None,
                AttackMode = AttackMode.Normal,
                TricksterWeaponId = 2
            },
            
            new Attack {
                Id = 53,
                Name = "R2 (forward leap)",
                Damage = 1.5m,
                ExtraDamage = 0.0m,
                ExtraDamageCount = 0,
                AttackType1 = AttackType.Physical,
                AttackType2 = AttackType.None,
                AttackMode = AttackMode.Normal,
                TricksterWeaponId = 2
            },
            
            new Attack {
                Id = 54,
                Name = "Plunge Attack",
                Damage = 1.5m,
                ExtraDamage = 0.0m,
                ExtraDamageCount = 0,
                AttackType1 = AttackType.Thrust,
                AttackType2 = AttackType.None,
                AttackMode = AttackMode.Normal,
                TricksterWeaponId = 2
            },
            
            new Attack {
                Id = 55,
                Name = "Plunge Attack (2nd)",
                Damage = 0.9m,
                ExtraDamage = 0.0m,
                ExtraDamageCount = 0,
                AttackType1 = AttackType.Blunt,
                AttackType2 = AttackType.None,
                AttackMode = AttackMode.Normal,
                TricksterWeaponId = 2
            },
            
            new Attack {
                Id = 56,
                Name = "R1",
                Damage = 0.9m,
                ExtraDamage = 0.0m,
                ExtraDamageCount = 0,
                AttackType1 = AttackType.Physical,
                AttackType2 = AttackType.None,
                AttackMode = AttackMode.Transformed,
                TricksterWeaponId = 2
            },
            
            new Attack {
                Id = 57,
                Name = "R1 (2nd)",
                Damage = 1.0m,
                ExtraDamage = 0.0m,
                ExtraDamageCount = 0,
                AttackType1 = AttackType.Physical,
                AttackType2 = AttackType.None,
                AttackMode = AttackMode.Transformed,
                TricksterWeaponId = 2
            },
            
            new Attack {
                Id = 58,
                Name = "R1 (3rd)",
                Damage = 0.9m,
                ExtraDamage = 0.0m,
                ExtraDamageCount = 0,
                AttackType1 = AttackType.Physical,
                AttackType2 = AttackType.None,
                AttackMode = AttackMode.Transformed,
                TricksterWeaponId = 2
            },
            
            new Attack {
                Id = 59,
                Name = "R1 (4th)",
                Damage = 1.0m,
                ExtraDamage = 0.0m,
                ExtraDamageCount = 0,
                AttackType1 = AttackType.Physical,
                AttackType2 = AttackType.None,
                AttackMode = AttackMode.Transformed,
                TricksterWeaponId = 2
            },
            
            new Attack {
                Id = 60,
                Name = "R1 (5th)",
                Damage = 0.9m,
                ExtraDamage = 0.0m,
                ExtraDamageCount = 0,
                AttackType1 = AttackType.Physical,
                AttackType2 = AttackType.None,
                AttackMode = AttackMode.Transformed,
                TricksterWeaponId = 2
            },
            
            new Attack {
                Id = 61,
                Name = "R1 (backstep)",
                Damage = 0.9m,
                ExtraDamage = 0.0m,
                ExtraDamageCount = 0,
                AttackType1 = AttackType.Physical,
                AttackType2 = AttackType.None,
                AttackMode = AttackMode.Transformed,
                TricksterWeaponId = 2
            },
            
            new Attack {
                Id = 62,
                Name = "R1 (rolling)",
                Damage = 0.9m,
                ExtraDamage = 0.0m,
                ExtraDamageCount = 0,
                AttackType1 = AttackType.Physical,
                AttackType2 = AttackType.None,
                AttackMode = AttackMode.Transformed,
                TricksterWeaponId = 2
            },
            
            new Attack {
                Id = 63,
                Name = "R1 (frontstep)",
                Damage = 0.9m,
                ExtraDamage = 0.0m,
                ExtraDamageCount = 0,
                AttackType1 = AttackType.Physical,
                AttackType2 = AttackType.None,
                AttackMode = AttackMode.Transformed,
                TricksterWeaponId = 2
            },
            
            new Attack {
                Id = 64,
                Name = "R1 (sidestep left)",
                Damage = 1.05m,
                ExtraDamage = 0.0m,
                ExtraDamageCount = 0,
                AttackType1 = AttackType.Physical,
                AttackType2 = AttackType.None,
                AttackMode = AttackMode.Transformed,
                TricksterWeaponId = 2
            },
            
            new Attack {
                Id = 65,
                Name = "R1 (sidestep right)",
                Damage = 0.95m,
                ExtraDamage = 0.0m,
                ExtraDamageCount = 0,
                AttackType1 = AttackType.Physical,
                AttackType2 = AttackType.None,
                AttackMode = AttackMode.Transformed,
                TricksterWeaponId = 2
            },
            
            new Attack {
                Id = 66,
                Name = "R1 (dash)",
                Damage = 0.9m,
                ExtraDamage = 0.0m,
                ExtraDamageCount = 0,
                AttackType1 = AttackType.Physical,
                AttackType2 = AttackType.None,
                AttackMode = AttackMode.Transformed,
                TricksterWeaponId = 2
            },
            
            new Attack {
                Id = 67,
                Name = "R2",
                Damage = 1.35m,
                ExtraDamage = 0.0m,
                ExtraDamageCount = 0,
                AttackType1 = AttackType.Physical,
                AttackType2 = AttackType.None,
                AttackMode = AttackMode.Transformed,
                TricksterWeaponId = 2
            },
            
            new Attack {
                Id = 68,
                Name = "R2 (charged)",
                Damage = 1.9m,
                ExtraDamage = 0.0m,
                ExtraDamageCount = 0,
                AttackType1 = AttackType.Physical,
                AttackType2 = AttackType.None,
                AttackMode = AttackMode.Transformed,
                TricksterWeaponId = 2
            },
            
            new Attack {
                Id = 69,
                Name = "R2 (backstep)",
                Damage = 1.15m,
                ExtraDamage = 0.0m,
                ExtraDamageCount = 0,
                AttackType1 = AttackType.Physical,
                AttackType2 = AttackType.None,
                AttackMode = AttackMode.Transformed,
                TricksterWeaponId = 2
            },
            
            new Attack {
                Id = 70,
                Name = "R2 (dash)",
                Damage = 1.1m,
                ExtraDamage = 0.0m,
                ExtraDamageCount = 0,
                AttackType1 = AttackType.Physical,
                AttackType2 = AttackType.None,
                AttackMode = AttackMode.Transformed,
                TricksterWeaponId = 2
            },
            
            new Attack {
                Id = 71,
                Name = "R2(forward leap)",
                Damage = 1.4m,
                ExtraDamage = 0.0m,
                ExtraDamageCount = 0,
                AttackType1 = AttackType.Physical,
                AttackType2 = AttackType.None,
                AttackMode = AttackMode.Transformed,
                TricksterWeaponId = 2
            },
            
            new Attack {
                Id = 72,
                Name = "L2",
                Damage = 1.2m,
                ExtraDamage = 0.0m,
                ExtraDamageCount = 0,
                AttackType1 = AttackType.Physical,
                AttackType2 = AttackType.None,
                AttackMode = AttackMode.Transformed,
                TricksterWeaponId = 2
            },

            new Attack {
                Id = 73,
                Name = "L2 (2nd)",
                Damage = 1.2m,
                ExtraDamage = 0.0m,
                ExtraDamageCount = 0,
                AttackType1 = AttackType.Physical,
                AttackType2 = AttackType.None,
                AttackMode = AttackMode.Transformed,
                TricksterWeaponId = 2
            },
            
            new Attack {
                Id = 74,
                Name = "L2 (3rd)",
                Damage = 1.2m,
                ExtraDamage = 0.0m,
                ExtraDamageCount = 0,
                AttackType1 = AttackType.Physical,
                AttackType2 = AttackType.None,
                AttackMode = AttackMode.Transformed,
                TricksterWeaponId = 2
            },
            
            new Attack {
                Id = 75,
                Name = "Transform Attack",
                Damage = 1.25m,
                ExtraDamage = 0.0m,
                ExtraDamageCount = 0,
                AttackType1 = AttackType.Physical,
                AttackType2 = AttackType.None,
                AttackMode = AttackMode.Transformed,
                TricksterWeaponId = 2
            },
            
            new Attack {
                Id = 76,
                Name = "Plunge Attack",
                Damage = 1.4m,
                ExtraDamage = 0.0m,
                ExtraDamageCount = 0,
                AttackType1 = AttackType.Thrust,
                AttackType2 = AttackType.None,
                AttackMode = AttackMode.Transformed,
                TricksterWeaponId = 2
            },
            
            new Attack {
                Id = 77,
                Name = "Plunge Attack (2nd hit)",
                Damage = 0.9m,
                ExtraDamage = 0.0m,
                ExtraDamageCount = 0,
                AttackType1 = AttackType.Blunt,
                AttackType2 = AttackType.None,
                AttackMode = AttackMode.Transformed,
                TricksterWeaponId = 2
            },
            
            new Attack {
                Id = 78,
                Name = "R1 (Beast's Embrace)",
                Damage = 1.0m,
                ExtraDamage = 0.0m,
                ExtraDamageCount = 0,
                AttackType1 = AttackType.Physical,
                AttackType2 = AttackType.None,
                AttackMode = AttackMode.Normal,
                TricksterWeaponId = 2
            },
            
            new Attack {
                Id = 79,
                Name = "R1 (2nd) (Beast's Embrace)",
                Damage = 1.0m,
                ExtraDamage = 0.0m,
                ExtraDamageCount = 0,
                AttackType1 = AttackType.Physical,
                AttackType2 = AttackType.None,
                AttackMode = AttackMode.Normal,
                TricksterWeaponId = 2
            },
            
            new Attack {
                Id = 80,
                Name = "R1 (3rd) (Beast's Embrace)",
                Damage = 1.0m,
                ExtraDamage = 0.0m,
                ExtraDamageCount = 0,
                AttackType1 = AttackType.Physical,
                AttackType2 = AttackType.None,
                AttackMode = AttackMode.Normal,
                TricksterWeaponId = 2
            },
            
            new Attack {
                Id = 81,
                Name = "R1 (4th) (Beast's Embrace)",
                Damage = 1.1m,
                ExtraDamage = 0.0m,
                ExtraDamageCount = 0,
                AttackType1 = AttackType.Physical,
                AttackType2 = AttackType.None,
                AttackMode = AttackMode.Normal,
                TricksterWeaponId = 2
            },
            
            new Attack {
                Id = 82,
                Name = "R1 (backstep) (Beast's Embrace)",
                Damage = 0.95m,
                ExtraDamage = 0.0m,
                ExtraDamageCount = 0,
                AttackType1 = AttackType.Physical,
                AttackType2 = AttackType.None,
                AttackMode = AttackMode.Normal,
                TricksterWeaponId = 2
            },
            
            new Attack {
                Id = 83,
                Name = "R1 (rolling) (Beast's Embrace)",
                Damage = 0.9m,
                ExtraDamage = 0.0m,
                ExtraDamageCount = 0,
                AttackType1 = AttackType.Physical,
                AttackType2 = AttackType.None,
                AttackMode = AttackMode.Normal,
                TricksterWeaponId = 2
            },
            
            new Attack {
                Id = 84,
                Name = "R1 (frontstep) (Beast's Embrace)",
                Damage = 0.9m,
                ExtraDamage = 0.0m,
                ExtraDamageCount = 0,
                AttackType1 = AttackType.Physical,
                AttackType2 = AttackType.None,
                AttackMode = AttackMode.Normal,
                TricksterWeaponId = 2
            },
            
            new Attack {
                Id = 85,
                Name = "R1 (sidestep) (Beast's Embrace)",
                Damage = 0.9m,
                ExtraDamage = 0.0m,
                ExtraDamageCount = 0,
                AttackType1 = AttackType.Physical,
                AttackType2 = AttackType.None,
                AttackMode = AttackMode.Normal,
                TricksterWeaponId = 2
            },
            
            new Attack {
                Id = 86,
                Name = "R1 (dash) (Beast's Embrace)",
                Damage = 1.05m,
                ExtraDamage = 0.0m,
                ExtraDamageCount = 0,
                AttackType1 = AttackType.Physical,
                AttackType2 = AttackType.None,
                AttackMode = AttackMode.Normal,
                TricksterWeaponId = 2
            },
            
            new Attack {
                Id = 87,
                Name = "R2 (Beast's Embrace)",
                Damage = 1.2m,
                ExtraDamage = 0.0m,
                ExtraDamageCount = 0,
                AttackType1 = AttackType.Physical,
                AttackType2 = AttackType.None,
                AttackMode = AttackMode.Normal,
                TricksterWeaponId = 2
            },
            
            new Attack {
                Id = 88,
                Name = "R2 (charged) (Beast's Embrace)",
                Damage = 1.4m,
                ExtraDamage = 0.0m,
                ExtraDamageCount = 0,
                AttackType1 = AttackType.Physical,
                AttackType2 = AttackType.None,
                AttackMode = AttackMode.Normal,
                TricksterWeaponId = 2
            },
            
            new Attack {
                Id = 89,
                Name = "R2 (backstep) (Beast's Embrace)",
                Damage = 1.15m,
                ExtraDamage = 0.0m,
                ExtraDamageCount = 0,
                AttackType1 = AttackType.Physical,
                AttackType2 = AttackType.None,
                AttackMode = AttackMode.Normal,
                TricksterWeaponId = 2
            },
            
            new Attack {
                Id = 90,
                Name = "R2 (dash) (Beast's Embrace)",
                Damage = 1.25m,
                ExtraDamage = 0.0m,
                ExtraDamageCount = 0,
                AttackType1 = AttackType.Thrust,
                AttackType2 = AttackType.None,
                AttackMode = AttackMode.Normal,
                TricksterWeaponId = 2
            },
            
            new Attack {
                Id = 91,
                Name = "R2 (forward leap) (Beast's Embrace)",
                Damage = 1.3m,
                ExtraDamage = 0.0m,
                ExtraDamageCount = 0,
                AttackType1 = AttackType.Physical,
                AttackType2 = AttackType.None,
                AttackMode = AttackMode.Normal,
                TricksterWeaponId = 2
            },
            
            new Attack {
                Id = 92,
                Name = "Transform Attack (Beast's Embrace)",
                Damage = 0.6m,
                ExtraDamage = 1.2m,
                ExtraDamageCount = 1,
                AttackType1 = AttackType.Physical,
                AttackType2 = AttackType.None,
                AttackMode = AttackMode.Normal,
                TricksterWeaponId = 2
            },
            
            new Attack {
                Id = 93,
                Name = "Plunge Attack (Beast's Embrace)",
                Damage = 1.3m,
                ExtraDamage = 0.0m,
                ExtraDamageCount = 0,
                AttackType1 = AttackType.Thrust,
                AttackType2 = AttackType.None,
                AttackMode = AttackMode.Normal,
                TricksterWeaponId = 2
            },
            
            new Attack {
                Id = 94,
                Name = "Plunge Attack (2nd) (Beast's Embrace)",
                Damage = 0.6m,
                ExtraDamage = 0.0m,
                ExtraDamageCount = 0,
                AttackType1 = AttackType.Blunt,
                AttackType2 = AttackType.None,
                AttackMode = AttackMode.Normal,
                TricksterWeaponId = 2
            },
            
            new Attack {
                Id = 95,
                Name = "R1 (Beast's Embrace)",
                Damage = 1.0m,
                ExtraDamage = 0.0m,
                ExtraDamageCount = 0,
                AttackType1 = AttackType.Physical,
                AttackType2 = AttackType.None,
                AttackMode = AttackMode.Transformed,
                TricksterWeaponId = 2
            },
            
            new Attack {
                Id = 96,
                Name = "R1 (2nd) (Beast's Embrace)",
                Damage = 1.0m,
                ExtraDamage = 0.0m,
                ExtraDamageCount = 0,
                AttackType1 = AttackType.Physical,
                AttackType2 = AttackType.None,
                AttackMode = AttackMode.Transformed,
                TricksterWeaponId = 2
            },
            
            new Attack {
                Id = 97,
                Name = "R1 (3rd) (Beast's Embrace)",
                Damage = 1.0m,
                ExtraDamage = 0.0m,
                ExtraDamageCount = 0,
                AttackType1 = AttackType.Physical,
                AttackType2 = AttackType.None,
                AttackMode = AttackMode.Transformed,
                TricksterWeaponId = 2
            },
            
            new Attack {
                Id = 98,
                Name = "R1 (4th) (Beast's Embrace)",
                Damage = 1.05m,
                ExtraDamage = 0.0m,
                ExtraDamageCount = 0,
                AttackType1 = AttackType.Physical,
                AttackType2 = AttackType.None,
                AttackMode = AttackMode.Transformed,
                TricksterWeaponId = 2
            },
            
            new Attack {
                Id = 99,
                Name = "R1 (5th) (Beast's Embrace)",
                Damage = 1.1m,
                ExtraDamage = 0.0m,
                ExtraDamageCount = 0,
                AttackType1 = AttackType.Physical,
                AttackType2 = AttackType.None,
                AttackMode = AttackMode.Transformed,
                TricksterWeaponId = 2
            },
            
            new Attack {
                Id = 100,
                Name = "R1 (backstep) (Beast's Embrace)",
                Damage = 0.6m,
                ExtraDamage = 0.95m,
                ExtraDamageCount = 1,
                AttackType1 = AttackType.Physical,
                AttackType2 = AttackType.None,
                AttackMode = AttackMode.Transformed,
                TricksterWeaponId = 2
            },

            new Attack {
                Id = 101,
                Name = "R1 (rolling) (Beast's Embrace)",
                Damage = 0.95m,
                ExtraDamage = 0.0m,
                ExtraDamageCount = 0,
                AttackType1 = AttackType.Physical,
                AttackType2 = AttackType.None,
                AttackMode = AttackMode.Transformed,
                TricksterWeaponId = 2
            },
            
            new Attack {
                Id = 102,
                Name = "R1 (frontstep) (Beast's Embrace)",
                Damage = 0.95m,
                ExtraDamage = 0.0m,
                ExtraDamageCount = 0,
                AttackType1 = AttackType.Physical,
                AttackType2 = AttackType.None,
                AttackMode = AttackMode.Transformed,
                TricksterWeaponId = 2
            },
            
            new Attack {
                Id = 103,
                Name = "R1 (sidestep) (Beast's Embrace)",
                Damage = 0.95m,
                ExtraDamage = 0.0m,
                ExtraDamageCount = 0,
                AttackType1 = AttackType.Physical,
                AttackType2 = AttackType.None,
                AttackMode = AttackMode.Transformed,
                TricksterWeaponId = 2
            },
            
            new Attack {
                Id = 104,
                Name = "R1 (dash) (Beast's Embrace)",
                Damage = 0.6m,
                ExtraDamage = 1.05m,
                ExtraDamageCount = 1,
                AttackType1 = AttackType.Physical,
                AttackType2 = AttackType.None,
                AttackMode = AttackMode.Transformed,
                TricksterWeaponId = 2
            },
            
            new Attack {
                Id = 105,
                Name = "R2 (Beast's Embrace)",
                Damage = 1.2m,
                ExtraDamage = 0.0m,
                ExtraDamageCount = 0,
                AttackType1 = AttackType.Physical,
                AttackType2 = AttackType.None,
                AttackMode = AttackMode.Transformed,
                TricksterWeaponId = 2
            },
            
            new Attack {
                Id = 106,
                Name = "R2 (2nd) (Beast's Embrace)",
                Damage = 1.3m,
                ExtraDamage = 0.0m,
                ExtraDamageCount = 0,
                AttackType1 = AttackType.Physical,
                AttackType2 = AttackType.None,
                AttackMode = AttackMode.Transformed,
                TricksterWeaponId = 2
            },
            
            new Attack {
                Id = 107,
                Name = "R2 (3rd) (Beast's Embrace)",
                Damage = 1.4m,
                ExtraDamage = 0.0m,
                ExtraDamageCount = 0,
                AttackType1 = AttackType.Physical,
                AttackType2 = AttackType.None,
                AttackMode = AttackMode.Transformed,
                TricksterWeaponId = 2
            },
            
            new Attack {
                Id = 108,
                Name = "R2 (backstep) (Beast's Embrace)",
                Damage = 1.2m,
                ExtraDamage = 0.0m,
                ExtraDamageCount = 0,
                AttackType1 = AttackType.Physical,
                AttackType2 = AttackType.None,
                AttackMode = AttackMode.Transformed,
                TricksterWeaponId = 2
            },
            
            new Attack {
                Id = 109,
                Name = "R2 (dash) (Beast's Embrace)",
                Damage = 0.6m,
                ExtraDamage = 1.25m,
                ExtraDamageCount = 1,
                AttackType1 = AttackType.Physical,
                AttackType2 = AttackType.None,
                AttackMode = AttackMode.Transformed,
                TricksterWeaponId = 2
            },
            
            new Attack {
                Id = 110,
                Name = "R2 (forward leap) (Beast's Embrace)",
                Damage = 0.6m,
                ExtraDamage = 1.4m,
                ExtraDamageCount = 1,
                AttackType1 = AttackType.Physical,
                AttackType2 = AttackType.None,
                AttackMode = AttackMode.Transformed,
                TricksterWeaponId = 2
            },
            
            new Attack {
                Id = 111,
                Name = "L2 (Beast's Embrace)",
                Damage = 0.3m,
                ExtraDamage = 0.0m,
                ExtraDamageCount = 0,
                AttackType1 = AttackType.Blunt,
                AttackType2 = AttackType.None,
                AttackMode = AttackMode.Transformed,
                TricksterWeaponId = 2
            },
            
            new Attack {
                Id = 112,
                Name = "L2 (AoE) (Beast's Embrace)",
                Damage = 0.1m,
                ExtraDamage = 0.0m,
                ExtraDamageCount = 0,
                AttackType1 = AttackType.Blunt,
                AttackType2 = AttackType.None,
                AttackMode = AttackMode.Transformed,
                TricksterWeaponId = 2
            },
            
            new Attack {
                Id = 113,
                Name = "Transform Attack (Beast's Embrace)",
                Damage = 1.25m,
                ExtraDamage = 0.0m,
                ExtraDamageCount = 0,
                AttackType1 = AttackType.Physical,
                AttackType2 = AttackType.None,
                AttackMode = AttackMode.Transformed,
                TricksterWeaponId = 2
            },
            
            new Attack {
                Id = 114,
                Name = "Plunge Attack (Beast's Embrace)",
                Damage = 1.4m,
                ExtraDamage = 0.0m,
                ExtraDamageCount = 0,
                AttackType1 = AttackType.Physical,
                AttackType2 = AttackType.None,
                AttackMode = AttackMode.Transformed,
                TricksterWeaponId = 2
            },
            
            new Attack {
                Id = 115,
                Name = "Plunge Attack (2nd) (Beast's Embrace)",
                Damage = 0.6m,
                ExtraDamage = 0.0m,
                ExtraDamageCount = 0,
                AttackType1 = AttackType.Blunt,
                AttackType2 = AttackType.None,
                AttackMode = AttackMode.Transformed,
                TricksterWeaponId = 2
            },
            
            new Attack {
                Id = 116,
                Name = "R1",
                Damage = 1.0m,
                ExtraDamage = 0.0m,
                ExtraDamageCount = 0,
                AttackType1 = AttackType.Blunt,
                AttackType2 = AttackType.None,
                AttackMode = AttackMode.Normal,
                TricksterWeaponId = 3
            },
            
            new Attack {
                Id = 117,
                Name = "R1 (2nd)",
                Damage = 1.02m,
                ExtraDamage = 0.0m,
                ExtraDamageCount = 0,
                AttackType1 = AttackType.Blunt,
                AttackType2 = AttackType.None,
                AttackMode = AttackMode.Normal,
                TricksterWeaponId = 3
            },
            
            new Attack {
                Id = 118,
                Name = "R1 (3rd)",
                Damage = 1.04m,
                ExtraDamage = 0.0m,
                ExtraDamageCount = 0,
                AttackType1 = AttackType.Blunt,
                AttackType2 = AttackType.None,
                AttackMode = AttackMode.Normal,
                TricksterWeaponId = 3
            },
            
            new Attack {
                Id = 119,
                Name = "R1 (4th)",
                Damage = 1.06m,
                ExtraDamage = 0.0m,
                ExtraDamageCount = 0,
                AttackType1 = AttackType.Blunt,
                AttackType2 = AttackType.None,
                AttackMode = AttackMode.Normal,
                TricksterWeaponId = 3
            },
            
            new Attack {
                Id = 120,
                Name = "R1 (5th)",
                Damage = 1.08m,
                ExtraDamage = 0.0m,
                ExtraDamageCount = 0,
                AttackType1 = AttackType.Blunt,
                AttackType2 = AttackType.None,
                AttackMode = AttackMode.Normal,
                TricksterWeaponId = 3
            },
            
            new Attack {
                Id = 121,
                Name = "R1 (backstep)",
                Damage = 0.95m,
                ExtraDamage = 0.0m,
                ExtraDamageCount = 0,
                AttackType1 = AttackType.Blunt,
                AttackType2 = AttackType.None,
                AttackMode = AttackMode.Normal,
                TricksterWeaponId = 3
            },
            
            new Attack {
                Id = 122,
                Name = "R1 (rolling)",
                Damage = 0.95m,
                ExtraDamage = 0.0m,
                ExtraDamageCount = 0,
                AttackType1 = AttackType.Blunt,
                AttackType2 = AttackType.None,
                AttackMode = AttackMode.Normal,
                TricksterWeaponId = 3
            },
            
            new Attack {
                Id = 123,
                Name = "R1 (frontstep)",
                Damage = 0.95m,
                ExtraDamage = 0.0m,
                ExtraDamageCount = 0,
                AttackType1 = AttackType.Blunt,
                AttackType2 = AttackType.None,
                AttackMode = AttackMode.Normal,
                TricksterWeaponId = 3
            },
            
            new Attack {
                Id = 124,
                Name = "R1 (sidestep)",
                Damage = 0.95m,
                ExtraDamage = 0.0m,
                ExtraDamageCount = 0,
                AttackType1 = AttackType.Blunt,
                AttackType2 = AttackType.None,
                AttackMode = AttackMode.Normal,
                TricksterWeaponId = 3
            },
            
            new Attack {
                Id = 125,
                Name = "R1 (dash)",
                Damage = 1.1m,
                ExtraDamage = 0.0m,
                ExtraDamageCount = 0,
                AttackType1 = AttackType.Blunt,
                AttackType2 = AttackType.None,
                AttackMode = AttackMode.Normal,
                TricksterWeaponId = 3
            },
            
            new Attack {
                Id = 126,
                Name = "R2",
                Damage = 1.2m,
                ExtraDamage = 0.0m,
                ExtraDamageCount = 0,
                AttackType1 = AttackType.Blunt,
                AttackType2 = AttackType.None,
                AttackMode = AttackMode.Normal,
                TricksterWeaponId = 3
            },
            
            new Attack {
                Id = 127,
                Name = "R2 (charged)",
                Damage = 1.9m,
                ExtraDamage = 0.0m,
                ExtraDamageCount = 0,
                AttackType1 = AttackType.Blunt,
                AttackType2 = AttackType.None,
                AttackMode = AttackMode.Normal,
                TricksterWeaponId = 3
            },
            
            new Attack {
                Id = 128,
                Name = "R2 (backstep)",
                Damage = 1.1m,
                ExtraDamage = 0.0m,
                ExtraDamageCount = 0,
                AttackType1 = AttackType.Blunt,
                AttackType2 = AttackType.None,
                AttackMode = AttackMode.Normal,
                TricksterWeaponId = 3
            },
            
            new Attack {
                Id = 129,
                Name = "R2 (dash)",
                Damage = 1.3m,
                ExtraDamage = 0.0m,
                ExtraDamageCount = 0,
                AttackType1 = AttackType.Blunt,
                AttackType2 = AttackType.None,
                AttackMode = AttackMode.Normal,
                TricksterWeaponId = 3
            },
            
            new Attack {
                Id = 130,
                Name = "R2 (forward leap)",
                Damage = 1.4m,
                ExtraDamage = 0.0m,
                ExtraDamageCount = 0,
                AttackType1 = AttackType.Blunt,
                AttackType2 = AttackType.None,
                AttackMode = AttackMode.Normal,
                TricksterWeaponId = 3
            },
            
            new Attack {
                Id = 131,
                Name = "Transform Attack",
                Damage = 1.4m,
                ExtraDamage = 0.0m,
                ExtraDamageCount = 0,
                AttackType1 = AttackType.Blunt,
                AttackType2 = AttackType.None,
                AttackMode = AttackMode.Normal,
                TricksterWeaponId = 3
            },

            new Attack {
                Id = 132,
                Name = "Plunge Attack",
                Damage = 1.4m,
                ExtraDamage = 0.0m,
                ExtraDamageCount = 0,
                AttackType1 = AttackType.Blunt,
                AttackType2 = AttackType.None,
                AttackMode = AttackMode.Normal,
                TricksterWeaponId = 3
            },
            
            new Attack {
                Id = 133,
                Name = "Plunge Attack (2nd)",
                Damage = 0.9m,
                ExtraDamage = 0.0m,
                ExtraDamageCount = 0,
                AttackType1 = AttackType.Blunt,
                AttackType2 = AttackType.None,
                AttackMode = AttackMode.Normal,
                TricksterWeaponId = 3
            },
            
            new Attack {
                Id = 134,
                Name = "R1",
                Damage = 0.95m,
                ExtraDamage = 0.0m,
                ExtraDamageCount = 0,
                AttackType1 = AttackType.Blunt,
                AttackType2 = AttackType.None,
                AttackMode = AttackMode.Transformed,
                TricksterWeaponId = 3
            },
            
            new Attack {
                Id = 135,
                Name = "R1 (2nd)",
                Damage = 0.98m,
                ExtraDamage = 0.0m,
                ExtraDamageCount = 0,
                AttackType1 = AttackType.Blunt,
                AttackType2 = AttackType.None,
                AttackMode = AttackMode.Transformed,
                TricksterWeaponId = 3
            },
            
            new Attack {
                Id = 136,
                Name = "R1 (3rd)",
                Damage = 1.0m,
                ExtraDamage = 0.0m,
                ExtraDamageCount = 0,
                AttackType1 = AttackType.Blunt,
                AttackType2 = AttackType.None,
                AttackMode = AttackMode.Transformed,
                TricksterWeaponId = 3
            },
            
            new Attack {
                Id = 137,
                Name = "R1 (4th)",
                Damage = 1.0m,
                ExtraDamage = 0.0m,
                ExtraDamageCount = 0,
                AttackType1 = AttackType.Blunt,
                AttackType2 = AttackType.None,
                AttackMode = AttackMode.Transformed,
                TricksterWeaponId = 3
            },
            
            new Attack {
                Id = 138,
                Name = "R1 (backstep)",
                Damage = 0.9m,
                ExtraDamage = 0.0m,
                ExtraDamageCount = 0,
                AttackType1 = AttackType.Blunt,
                AttackType2 = AttackType.None,
                AttackMode = AttackMode.Transformed,
                TricksterWeaponId = 3
            },
            
            new Attack {
                Id = 139,
                Name = "R1 (rolling)",
                Damage = 1.0m,
                ExtraDamage = 0.0m,
                ExtraDamageCount = 0,
                AttackType1 = AttackType.Blunt,
                AttackType2 = AttackType.None,
                AttackMode = AttackMode.Transformed,
                TricksterWeaponId = 3
            },
            
            new Attack {
                Id = 140,
                Name = "R1 (frontstep)",
                Damage = 1.0m,
                ExtraDamage = 0.0m,
                ExtraDamageCount = 0,
                AttackType1 = AttackType.Blunt,
                AttackType2 = AttackType.None,
                AttackMode = AttackMode.Transformed,
                TricksterWeaponId = 3
            },
            
            new Attack {
                Id = 141,
                Name = "R1 (sidestep)",
                Damage = 1.0m,
                ExtraDamage = 0.0m,
                ExtraDamageCount = 0,
                AttackType1 = AttackType.Blunt,
                AttackType2 = AttackType.None,
                AttackMode = AttackMode.Transformed,
                TricksterWeaponId = 3
            },
            
            new Attack {
                Id = 142,
                Name = "R1 (dash)",
                Damage = 1.1m,
                ExtraDamage = 0.0m,
                ExtraDamageCount = 0,
                AttackType1 = AttackType.Blunt,
                AttackType2 = AttackType.None,
                AttackMode = AttackMode.Transformed,
                TricksterWeaponId = 3
            },
            
            new Attack {
                Id = 143,
                Name = "R2",
                Damage = 1.3m,
                ExtraDamage = 0.0m,
                ExtraDamageCount = 0,
                AttackType1 = AttackType.Blunt,
                AttackType2 = AttackType.None,
                AttackMode = AttackMode.Transformed,
                TricksterWeaponId = 3
            },
            
            new Attack {
                Id = 144,
                Name = "R2 (2nd)",
                Damage = 1.5m,
                ExtraDamage = 0.0m,
                ExtraDamageCount = 0,
                AttackType1 = AttackType.Blunt,
                AttackType2 = AttackType.None,
                AttackMode = AttackMode.Transformed,
                TricksterWeaponId = 3
            },
            
            new Attack {
                Id = 145,
                Name = "R2 (backstep)",
                Damage = 1.2m,
                ExtraDamage = 0.0m,
                ExtraDamageCount = 0,
                AttackType1 = AttackType.Blunt,
                AttackType2 = AttackType.None,
                AttackMode = AttackMode.Transformed,
                TricksterWeaponId = 3
            },
            
            new Attack {
                Id = 146,
                Name = "R2 (dash)",
                Damage = 1.35m,
                ExtraDamage = 0.0m,
                ExtraDamageCount = 0,
                AttackType1 = AttackType.Blunt,
                AttackType2 = AttackType.None,
                AttackMode = AttackMode.Transformed,
                TricksterWeaponId = 3
            },
            
            new Attack {
                Id = 147,
                Name = "R2(forward leap)",
                Damage = 1.4m,
                ExtraDamage = 0.0m,
                ExtraDamageCount = 0,
                AttackType1 = AttackType.Blunt,
                AttackType2 = AttackType.None,
                AttackMode = AttackMode.Transformed,
                TricksterWeaponId = 3
            },
            
            new Attack {
                Id = 148,
                Name = "Transform Attack",
                Damage = 1.5m,
                ExtraDamage = 0.0m,
                ExtraDamageCount = 0,
                AttackType1 = AttackType.Blunt,
                AttackType2 = AttackType.None,
                AttackMode = AttackMode.Transformed,
                TricksterWeaponId = 3
            },
            
            new Attack {
                Id = 149,
                Name = "Plunge Attack",
                Damage = 1.4m,
                ExtraDamage = 0.0m,
                ExtraDamageCount = 0,
                AttackType1 = AttackType.Blunt,
                AttackType2 = AttackType.None,
                AttackMode = AttackMode.Transformed,
                TricksterWeaponId = 3
            },
            
            new Attack {
                Id = 150,
                Name = "Plunge Attack (2nd)",
                Damage = 0.9m,
                ExtraDamage = 0.0m,
                ExtraDamageCount = 0,
                AttackType1 = AttackType.Blunt,
                AttackType2 = AttackType.None,
                AttackMode = AttackMode.Transformed,
                TricksterWeaponId = 3
            },
            
            new Attack {
                Id = 151,
                Name = "R1",
                Damage = 1.1m,
                ExtraDamage = 0.0m,
                ExtraDamageCount = 0,
                AttackType1 = AttackType.Physical,
                AttackType2 = AttackType.None,
                AttackMode = AttackMode.Normal,
                TricksterWeaponId = 4
            },
            
            new Attack {
                Id = 152,
                Name = "R1 (2nd)",
                Damage = 1.12m,
                ExtraDamage = 0.0m,
                ExtraDamageCount = 0,
                AttackType1 = AttackType.Physical,
                AttackType2 = AttackType.None,
                AttackMode = AttackMode.Normal,
                TricksterWeaponId = 4
            },
            
            new Attack {
                Id = 153,
                Name = "R1 (3rd)",
                Damage = 1.14m,
                ExtraDamage = 0.0m,
                ExtraDamageCount = 0,
                AttackType1 = AttackType.Physical,
                AttackType2 = AttackType.None,
                AttackMode = AttackMode.Normal,
                TricksterWeaponId = 4
            },
            
            new Attack {
                Id = 154,
                Name = "R1 (4th)",
                Damage = 1.16m,
                ExtraDamage = 0.0m,
                ExtraDamageCount = 0,
                AttackType1 = AttackType.Physical,
                AttackType2 = AttackType.None,
                AttackMode = AttackMode.Normal,
                TricksterWeaponId = 4
            },
            
            new Attack {
                Id = 155,
                Name = "R1 (backstep)",
                Damage = 1.0m,
                ExtraDamage = 0.0m,
                ExtraDamageCount = 0,
                AttackType1 = AttackType.Physical,
                AttackType2 = AttackType.None,
                AttackMode = AttackMode.Normal,
                TricksterWeaponId = 4
            },
            
            new Attack {
                Id = 156,
                Name = "R1 (rolling)",
                Damage = 1.0m,
                ExtraDamage = 0.0m,
                ExtraDamageCount = 0,
                AttackType1 = AttackType.Physical,
                AttackType2 = AttackType.None,
                AttackMode = AttackMode.Normal,
                TricksterWeaponId = 4
            },
            
            new Attack {
                Id = 157,
                Name = "R1 (frontstep)",
                Damage = 1.0m,
                ExtraDamage = 0.0m,
                ExtraDamageCount = 0,
                AttackType1 = AttackType.Physical,
                AttackType2 = AttackType.None,
                AttackMode = AttackMode.Normal,
                TricksterWeaponId = 4
            },
            
            new Attack {
                Id = 158,
                Name = "R1 (sidestep)",
                Damage = 1.0m,
                ExtraDamage = 0.0m,
                ExtraDamageCount = 0,
                AttackType1 = AttackType.Physical,
                AttackType2 = AttackType.None,
                AttackMode = AttackMode.Normal,
                TricksterWeaponId = 4
            },
            
            new Attack {
                Id = 159,
                Name = "R1 (dash)",
                Damage = 1.2m,
                ExtraDamage = 0.0m,
                ExtraDamageCount = 0,
                AttackType1 = AttackType.Physical,
                AttackType2 = AttackType.None,
                AttackMode = AttackMode.Normal,
                TricksterWeaponId = 4
            },
            
            new Attack {
                Id = 160,
                Name = "R2",
                Damage = 1.45m,
                ExtraDamage = 0.0m,
                ExtraDamageCount = 0,
                AttackType1 = AttackType.Physical,
                AttackType2 = AttackType.None,
                AttackMode = AttackMode.Normal,
                TricksterWeaponId = 4
            },
            
            new Attack {
                Id = 161,
                Name = "R2 (charged)",
                Damage = 1.8m,
                ExtraDamage = 0.0m,
                ExtraDamageCount = 0,
                AttackType1 = AttackType.Blunt,
                AttackType2 = AttackType.None,
                AttackMode = AttackMode.Normal,
                TricksterWeaponId = 4
            },
            
            new Attack {
                Id = 162,
                Name = "R2 (backstep)",
                Damage = 1.3m,
                ExtraDamage = 0.0m,
                ExtraDamageCount = 0,
                AttackType1 = AttackType.Blunt,
                AttackType2 = AttackType.None,
                AttackMode = AttackMode.Normal,
                TricksterWeaponId = 4
            },
            
            new Attack {
                Id = 163,
                Name = "R2 (dash)",
                Damage = 1.5m,
                ExtraDamage = 0.0m,
                ExtraDamageCount = 0,
                AttackType1 = AttackType.Physical,
                AttackType2 = AttackType.None,
                AttackMode = AttackMode.Normal,
                TricksterWeaponId = 4
            },
            
            new Attack {
                Id = 164,
                Name = "R2 (forward leap)",
                Damage = 1.5m,
                ExtraDamage = 0.0m,
                ExtraDamageCount = 0,
                AttackType1 = AttackType.Physical,
                AttackType2 = AttackType.None,
                AttackMode = AttackMode.Normal,
                TricksterWeaponId = 4
            },
            
            new Attack {
                Id = 165,
                Name = "Transform Attack",
                Damage = 1.15m,
                ExtraDamage = 0.0m,
                ExtraDamageCount = 0,
                AttackType1 = AttackType.Physical,
                AttackType2 = AttackType.None,
                AttackMode = AttackMode.Normal,
                TricksterWeaponId = 4
            },
            
            new Attack {
                Id = 166,
                Name = "Plunge Attack",
                Damage = 1.4m,
                ExtraDamage = 0.0m,
                ExtraDamageCount = 0,
                AttackType1 = AttackType.Physical,
                AttackType2 = AttackType.None,
                AttackMode = AttackMode.Normal,
                TricksterWeaponId = 4
            },
            
            new Attack {
                Id = 167,
                Name = "Plunge Attack (2nd)",
                Damage = 0.9m,
                ExtraDamage = 0.0m,
                ExtraDamageCount = 0,
                AttackType1 = AttackType.Blunt,
                AttackType2 = AttackType.None,
                AttackMode = AttackMode.Normal,
                TricksterWeaponId = 4
            },
            
            new Attack {
                Id = 168,
                Name = "R1",
                Damage = 0.95m,
                ExtraDamage = 0.0m,
                ExtraDamageCount = 0,
                AttackType1 = AttackType.Physical,
                AttackType2 = AttackType.None,
                AttackMode = AttackMode.Transformed,
                TricksterWeaponId = 4
            },
            
            new Attack {
                Id = 169,
                Name = "R1 (2nd)",
                Damage = 0.98m,
                ExtraDamage = 0.0m,
                ExtraDamageCount = 0,
                AttackType1 = AttackType.Physical,
                AttackType2 = AttackType.None,
                AttackMode = AttackMode.Transformed,
                TricksterWeaponId = 4
            },
            
            new Attack {
                Id = 170,
                Name = "R1 (3rd)",
                Damage = 1.0m,
                ExtraDamage = 0.0m,
                ExtraDamageCount = 0,
                AttackType1 = AttackType.Physical,
                AttackType2 = AttackType.None,
                AttackMode = AttackMode.Transformed,
                TricksterWeaponId = 4
            },
            
            new Attack {
                Id = 171,
                Name = "R1 (4th)",
                Damage = 1.0m,
                ExtraDamage = 0.0m,
                ExtraDamageCount = 0,
                AttackType1 = AttackType.Physical,
                AttackType2 = AttackType.None,
                AttackMode = AttackMode.Transformed,
                TricksterWeaponId = 4
            },
            
            new Attack {
                Id = 172,
                Name = "R1 (backstep)",
                Damage = 1.0m,
                ExtraDamage = 0.0m,
                ExtraDamageCount = 0,
                AttackType1 = AttackType.Thrust,
                AttackType2 = AttackType.None,
                AttackMode = AttackMode.Transformed,
                TricksterWeaponId = 4
            },
            
            new Attack {
                Id = 173,
                Name = "R1 (rolling)",
                Damage = 0.95m,
                ExtraDamage = 0.0m,
                ExtraDamageCount = 0,
                AttackType1 = AttackType.Physical,
                AttackType2 = AttackType.None,
                AttackMode = AttackMode.Transformed,
                TricksterWeaponId = 4
            },
            
            new Attack {
                Id = 174,
                Name = "R1 (frontstep)",
                Damage = 0.95m,
                ExtraDamage = 0.0m,
                ExtraDamageCount = 0,
                AttackType1 = AttackType.Physical,
                AttackType2 = AttackType.None,
                AttackMode = AttackMode.Transformed,
                TricksterWeaponId = 4
            },
            
            new Attack {
                Id = 175,
                Name = "R1 (sidestep)",
                Damage = 0.95m,
                ExtraDamage = 0.0m,
                ExtraDamageCount = 0,
                AttackType1 = AttackType.Physical,
                AttackType2 = AttackType.None,
                AttackMode = AttackMode.Transformed,
                TricksterWeaponId = 4
            },
            
            new Attack {
                Id = 176,
                Name = "R1 (dash)",
                Damage = 1.1m,
                ExtraDamage = 0.0m,
                ExtraDamageCount = 0,
                AttackType1 = AttackType.Physical,
                AttackType2 = AttackType.None,
                AttackMode = AttackMode.Transformed,
                TricksterWeaponId = 4
            },
            
            new Attack {
                Id = 177,
                Name = "R2",
                Damage = 1.3m,
                ExtraDamage = 0.0m,
                ExtraDamageCount = 0,
                AttackType1 = AttackType.Thrust,
                AttackType2 = AttackType.None,
                AttackMode = AttackMode.Transformed,
                TricksterWeaponId = 4
            },
            
            new Attack {
                Id = 178,
                Name = "R2 (charged)",
                Damage = 1.6m,
                ExtraDamage = 0.0m,
                ExtraDamageCount = 0,
                AttackType1 = AttackType.Blunt,
                AttackType2 = AttackType.None,
                AttackMode = AttackMode.Transformed,
                TricksterWeaponId = 4
            },
            
            new Attack {
                Id = 179,
                Name = "R2 (backstep)",
                Damage = 1.25m,
                ExtraDamage = 0.0m,
                ExtraDamageCount = 0,
                AttackType1 = AttackType.Physical,
                AttackType2 = AttackType.None,
                AttackMode = AttackMode.Transformed,
                TricksterWeaponId = 4
            },
            
            new Attack {
                Id = 180,
                Name = "R2 (dash)",
                Damage = 1.4m,
                ExtraDamage = 0.0m,
                ExtraDamageCount = 0,
                AttackType1 = AttackType.Physical,
                AttackType2 = AttackType.None,
                AttackMode = AttackMode.Transformed,
                TricksterWeaponId = 4
            },
            
            new Attack {
                Id = 181,
                Name = "R2 (forward leap)",
                Damage = 1.4m,
                ExtraDamage = 0.0m,
                ExtraDamageCount = 0,
                AttackType1 = AttackType.Blunt,
                AttackType2 = AttackType.None,
                AttackMode = AttackMode.Transformed,
                TricksterWeaponId = 4
            },
            
            new Attack {
                Id = 182,
                Name = "Transform Attack",
                Damage = 1.1m,
                ExtraDamage = 0.0m,
                ExtraDamageCount = 0,
                AttackType1 = AttackType.Physical,
                AttackType2 = AttackType.None,
                AttackMode = AttackMode.Transformed,
                TricksterWeaponId = 4
            },
            
            new Attack {
                Id = 183,
                Name = "Plunge Attack",
                Damage = 1.4m,
                ExtraDamage = 0.0m,
                ExtraDamageCount = 0,
                AttackType1 = AttackType.Physical,
                AttackType2 = AttackType.None,
                AttackMode = AttackMode.Transformed,
                TricksterWeaponId = 4
            },
            
            new Attack {
                Id = 184,
                Name = "Plunge Attack (2nd)",
                Damage = 0.9m,
                ExtraDamage = 0.0m,
                ExtraDamageCount = 0,
                AttackType1 = AttackType.Blunt,
                AttackType2 = AttackType.None,
                AttackMode = AttackMode.Transformed,
                TricksterWeaponId = 4
            },
            
            new Attack {
                Id = 185,
                Name = "R1",
                Damage = 1.0m,
                ExtraDamage = 0.0m,
                ExtraDamageCount = 0,
                AttackType1 = AttackType.Physical,
                AttackType2 = AttackType.Arcane,
                AttackMode = AttackMode.Normal,
                TricksterWeaponId = 5
            },
            
            new Attack {
                Id = 186,
                Name = "R1 (2nd)",
                Damage = 1.02m,
                ExtraDamage = 0.0m,
                ExtraDamageCount = 0,
                AttackType1 = AttackType.Physical,
                AttackType2 = AttackType.Arcane,
                AttackMode = AttackMode.Normal,
                TricksterWeaponId = 5
            },
            
            new Attack {
                Id = 187,
                Name = "R1 (3rd)",
                Damage = 1.04m,
                ExtraDamage = 0.0m,
                ExtraDamageCount = 0,
                AttackType1 = AttackType.Physical,
                AttackType2 = AttackType.Arcane,
                AttackMode = AttackMode.Normal,
                TricksterWeaponId = 5
            },
            
            new Attack {
                Id = 188,
                Name = "R1 (backstep)",
                Damage = 1.5m,
                ExtraDamage = 0.0m,
                ExtraDamageCount = 0,
                AttackType1 = AttackType.Physical,
                AttackType2 = AttackType.Arcane,
                AttackMode = AttackMode.Normal,
                TricksterWeaponId = 5
            },
            
            new Attack {
                Id = 189,
                Name = "R1 (rolling)",
                Damage = 1.5m,
                ExtraDamage = 0.0m,
                ExtraDamageCount = 0,
                AttackType1 = AttackType.Physical,
                AttackType2 = AttackType.Arcane,
                AttackMode = AttackMode.Normal,
                TricksterWeaponId = 5
            },
            
            new Attack {
                Id = 190,
                Name = "R1 (frontstep)",
                Damage = 1.5m,
                ExtraDamage = 0.0m,
                ExtraDamageCount = 0,
                AttackType1 = AttackType.Physical,
                AttackType2 = AttackType.Arcane,
                AttackMode = AttackMode.Normal,
                TricksterWeaponId = 5
            },
            
            new Attack {
                Id = 191,
                Name = "R1 (sidestep)",
                Damage = 1.5m,
                ExtraDamage = 0.0m,
                ExtraDamageCount = 0,
                AttackType1 = AttackType.Physical,
                AttackType2 = AttackType.Arcane,
                AttackMode = AttackMode.Normal,
                TricksterWeaponId = 5
            },
            
            new Attack {
                Id = 192,
                Name = "R1 (dash)",
                Damage = 1.4m,
                ExtraDamage = 0.0m,
                ExtraDamageCount = 0,
                AttackType1 = AttackType.Thrust,
                AttackType2 = AttackType.Arcane,
                AttackMode = AttackMode.Normal,
                TricksterWeaponId = 5
            },
            
            new Attack {
                Id = 193,
                Name = "R2",
                Damage = 1.25m,
                ExtraDamage = 0.0m,
                ExtraDamageCount = 0,
                AttackType1 = AttackType.Physical,
                AttackType2 = AttackType.Arcane,
                AttackMode = AttackMode.Normal,
                TricksterWeaponId = 5
            },
            
            new Attack {
                Id = 194,
                Name = "R2 (charged)",
                Damage = 2.0m,
                ExtraDamage = 0.0m,
                ExtraDamageCount = 0,
                AttackType1 = AttackType.Physical,
                AttackType2 = AttackType.Arcane,
                AttackMode = AttackMode.Normal,
                TricksterWeaponId = 5
            },
            
            new Attack {
                Id = 195,
                Name = "R2 (backstep)",
                Damage = 1.8m,
                ExtraDamage = 0.0m,
                ExtraDamageCount = 0,
                AttackType1 = AttackType.Thrust,
                AttackType2 = AttackType.Arcane,
                AttackMode = AttackMode.Normal,
                TricksterWeaponId = 5
            },
            
            new Attack {
                Id = 196,
                Name = "R2 (dash)",
                Damage = 1.8m,
                ExtraDamage = 0.0m,
                ExtraDamageCount = 0,
                AttackType1 = AttackType.Physical,
                AttackType2 = AttackType.Arcane,
                AttackMode = AttackMode.Normal,
                TricksterWeaponId = 5
            },
            
            new Attack {
                Id = 197,
                Name = "R2 (forward leap)",
                Damage = 1.5m,
                ExtraDamage = 0.0m,
                ExtraDamageCount = 0,
                AttackType1 = AttackType.Physical,
                AttackType2 = AttackType.Arcane,
                AttackMode = AttackMode.Normal,
                TricksterWeaponId = 5
            },
            
            new Attack {
                Id = 198,
                Name = "Transform Attack",
                Damage = 1.2m,
                ExtraDamage = 0.0m,
                ExtraDamageCount = 0,
                AttackType1 = AttackType.Physical,
                AttackType2 = AttackType.Arcane,
                AttackMode = AttackMode.Normal,
                TricksterWeaponId = 5
            },
            
            new Attack {
                Id = 199,
                Name = "Plunge Attack",
                Damage = 1.6m,
                ExtraDamage = 0.0m,
                ExtraDamageCount = 0,
                AttackType1 = AttackType.Thrust,
                AttackType2 = AttackType.Arcane,
                AttackMode = AttackMode.Normal,
                TricksterWeaponId = 5
            },
            
            new Attack {
                Id = 200,
                Name = "Plunge Attack (2nd)",
                Damage = 0.9m,
                ExtraDamage = 0.0m,
                ExtraDamageCount = 0,
                AttackType1 = AttackType.Blunt,
                AttackType2 = AttackType.Arcane,
                AttackMode = AttackMode.Normal,
                TricksterWeaponId = 5
            },
            
            new Attack {
                Id = 201,
                Name = "R1",
                Damage = 0.9m,
                ExtraDamage = 0.0m,
                ExtraDamageCount = 0,
                AttackType1 = AttackType.Physical,
                AttackType2 = AttackType.Arcane,
                AttackMode = AttackMode.Transformed,
                TricksterWeaponId = 5
            },
            
            new Attack {
                Id = 202,
                Name = "R1 (2nd)",
                Damage = 0.9m,
                ExtraDamage = 0.0m,
                ExtraDamageCount = 0,
                AttackType1 = AttackType.Physical,
                AttackType2 = AttackType.Arcane,
                AttackMode = AttackMode.Transformed,
                TricksterWeaponId = 5
            },
            
            new Attack {
                Id = 203,
                Name = "R1 (3rd)",
                Damage = 0.9m,
                ExtraDamage = 0.0m,
                ExtraDamageCount = 0,
                AttackType1 = AttackType.Physical,
                AttackType2 = AttackType.Arcane,
                AttackMode = AttackMode.Transformed,
                TricksterWeaponId = 5
            },
            
            new Attack {
                Id = 204,
                Name = "R1 (4th)",
                Damage = 1.25m,
                ExtraDamage = 0.0m,
                ExtraDamageCount = 0,
                AttackType1 = AttackType.Physical,
                AttackType2 = AttackType.Arcane,
                AttackMode = AttackMode.Transformed,
                TricksterWeaponId = 5
            },
            
            new Attack {
                Id = 205,
                Name = "R1 (5th)",
                Damage = 1.1m,
                ExtraDamage = 0.0m,
                ExtraDamageCount = 0,
                AttackType1 = AttackType.Thrust,
                AttackType2 = AttackType.Arcane,
                AttackMode = AttackMode.Transformed,
                TricksterWeaponId = 5
            },
            
            new Attack {
                Id = 206,
                Name = "R1 (6th)",
                Damage = 1.12m,
                ExtraDamage = 0.0m,
                ExtraDamageCount = 0,
                AttackType1 = AttackType.Physical,
                AttackType2 = AttackType.Arcane,
                AttackMode = AttackMode.Transformed,
                TricksterWeaponId = 5
            },
            
            new Attack {
                Id = 207,
                Name = "R1 (7th)",
                Damage = 1.18m,
                ExtraDamage = 0.0m,
                ExtraDamageCount = 0,
                AttackType1 = AttackType.Physical,
                AttackType2 = AttackType.Arcane,
                AttackMode = AttackMode.Transformed,
                TricksterWeaponId = 5
            },
            
            new Attack {
                Id = 208,
                Name = "R1 (8th)",
                Damage = 1.18m,
                ExtraDamage = 0.0m,
                ExtraDamageCount = 0,
                AttackType1 = AttackType.Thrust,
                AttackType2 = AttackType.Arcane,
                AttackMode = AttackMode.Transformed,
                TricksterWeaponId = 5
            },
            
            new Attack {
                Id = 209,
                Name = "R1 (backstep)",
                Damage = 1.4m,
                ExtraDamage = 0.0m,
                ExtraDamageCount = 0,
                AttackType1 = AttackType.Physical,
                AttackType2 = AttackType.Arcane,
                AttackMode = AttackMode.Transformed,
                TricksterWeaponId = 5
            },
            
            new Attack {
                Id = 210,
                Name = "R1 (rolling)",
                Damage = 1.4m,
                ExtraDamage = 0.0m,
                ExtraDamageCount = 0,
                AttackType1 = AttackType.Thrust,
                AttackType2 = AttackType.Arcane,
                AttackMode = AttackMode.Transformed,
                TricksterWeaponId = 5
            },
            
            new Attack {
                Id = 211,
                Name = "R1 (frontstep)",
                Damage = 1.4m,
                ExtraDamage = 0.0m,
                ExtraDamageCount = 0,
                AttackType1 = AttackType.Thrust,
                AttackType2 = AttackType.Arcane,
                AttackMode = AttackMode.Transformed,
                TricksterWeaponId = 5
            },
            
            new Attack {
                Id = 212,
                Name = "R1 (sidestep)",
                Damage = 1.4m,
                ExtraDamage = 0.0m,
                ExtraDamageCount = 0,
                AttackType1 = AttackType.Physical,
                AttackType2 = AttackType.Arcane,
                AttackMode = AttackMode.Transformed,
                TricksterWeaponId = 5
            },
            
            new Attack {
                Id = 213,
                Name = "R1 (dash)",
                Damage = 1.4m,
                ExtraDamage = 0.0m,
                ExtraDamageCount = 0,
                AttackType1 = AttackType.Thrust,
                AttackType2 = AttackType.Arcane,
                AttackMode = AttackMode.Transformed,
                TricksterWeaponId = 5
            },
            
            new Attack {
                Id = 214,
                Name = "R2",
                Damage = 1.5m,
                ExtraDamage = 0.0m,
                ExtraDamageCount = 0,
                AttackType1 = AttackType.Physical,
                AttackType2 = AttackType.Arcane,
                AttackMode = AttackMode.Transformed,
                TricksterWeaponId = 5
            },
            
            new Attack {
                Id = 215,
                Name = "R2 (2nd)",
                Damage = 1.6m,
                ExtraDamage = 0.0m,
                ExtraDamageCount = 0,
                AttackType1 = AttackType.Physical,
                AttackType2 = AttackType.Arcane,
                AttackMode = AttackMode.Transformed,
                TricksterWeaponId = 5
            },
            
            new Attack {
                Id = 216,
                Name = "R2 (backstep)",
                Damage = 1.7m,
                ExtraDamage = 0.0m,
                ExtraDamageCount = 0,
                AttackType1 = AttackType.Physical,
                AttackType2 = AttackType.Arcane,
                AttackMode = AttackMode.Transformed,
                TricksterWeaponId = 5
            },
            
            new Attack {
                Id = 217,
                Name = "R2 (dash)",
                Damage = 1.7m,
                ExtraDamage = 0.0m,
                ExtraDamageCount = 0,
                AttackType1 = AttackType.Physical,
                AttackType2 = AttackType.Arcane,
                AttackMode = AttackMode.Transformed,
                TricksterWeaponId = 5
            },
            
            new Attack {
                Id = 218,
                Name = "R2 (forward leap)",
                Damage = 1.5m,
                ExtraDamage = 0.0m,
                ExtraDamageCount = 0,
                AttackType1 = AttackType.Thrust,
                AttackType2 = AttackType.Arcane,
                AttackMode = AttackMode.Transformed,
                TricksterWeaponId = 5
            },
            
            new Attack {
                Id = 219,
                Name = "L2",
                Damage = 1.5m,
                ExtraDamage = 0.0m,
                ExtraDamageCount = 0,
                AttackType1 = AttackType.Physical,
                AttackType2 = AttackType.Arcane,
                AttackMode = AttackMode.Transformed,
                TricksterWeaponId = 5
            },
            
            new Attack {
                Id = 220,
                Name = "Transform Attack",
                Damage = 1.3m,
                ExtraDamage = 0.0m,
                ExtraDamageCount = 0,
                AttackType1 = AttackType.Physical,
                AttackType2 = AttackType.Arcane,
                AttackMode = AttackMode.Transformed,
                TricksterWeaponId = 5
            },
            
            new Attack {
                Id = 221,
                Name = "Plunge Attack",
                Damage = 1.6m,
                ExtraDamage = 0.0m,
                ExtraDamageCount = 0,
                AttackType1 = AttackType.Physical,
                AttackType2 = AttackType.Arcane,
                AttackMode = AttackMode.Transformed,
                TricksterWeaponId = 5
            },
            
            new Attack {
                Id = 222,
                Name = "Plunge Attack (2nd)",
                Damage = 0.9m,
                ExtraDamage = 0.0m,
                ExtraDamageCount = 0,
                AttackType1 = AttackType.Blunt,
                AttackType2 = AttackType.Arcane,
                AttackMode = AttackMode.Transformed,
                TricksterWeaponId = 5
            },
            
            new Attack {
                Id = 223,
                Name = "R1",
                Damage = 1.0m,
                ExtraDamage = 0.0m,
                ExtraDamageCount = 0,
                AttackType1 = AttackType.Blunt,
                AttackType2 = AttackType.None,
                AttackMode = AttackMode.Normal,
                TricksterWeaponId = 6
            },
            
            new Attack {
                Id = 224,
                Name = "R1 (2nd)",
                Damage = 1.0m,
                ExtraDamage = 0.0m,
                ExtraDamageCount = 0,
                AttackType1 = AttackType.Blunt,
                AttackType2 = AttackType.None,
                AttackMode = AttackMode.Normal,
                TricksterWeaponId = 6
            },
            
            new Attack {
                Id = 225,
                Name = "R1 (3rd)",
                Damage = 1.0m,
                ExtraDamage = 0.0m,
                ExtraDamageCount = 0,
                AttackType1 = AttackType.Blunt,
                AttackType2 = AttackType.None,
                AttackMode = AttackMode.Normal,
                TricksterWeaponId = 6
            },
            
            new Attack {
                Id = 226,
                Name = "R1 (4th)",
                Damage = 1.1m,
                ExtraDamage = 0.0m,
                ExtraDamageCount = 0,
                AttackType1 = AttackType.Thrust,
                AttackType2 = AttackType.None,
                AttackMode = AttackMode.Normal,
                TricksterWeaponId = 6
            },
            
            new Attack {
                Id = 227,
                Name = "R1 (backstep)",
                Damage = 0.95m,
                ExtraDamage = 0.0m,
                ExtraDamageCount = 0,
                AttackType1 = AttackType.Blunt,
                AttackType2 = AttackType.None,
                AttackMode = AttackMode.Normal,
                TricksterWeaponId = 6
            },
            
            new Attack {
                Id = 228,
                Name = "R1 (rolling)",
                Damage = 0.95m,
                ExtraDamage = 0.0m,
                ExtraDamageCount = 0,
                AttackType1 = AttackType.Blunt,
                AttackType2 = AttackType.None,
                AttackMode = AttackMode.Normal,
                TricksterWeaponId = 6
            },
            
            new Attack {
                Id = 229,
                Name = "R1 (frontstep)",
                Damage = 0.95m,
                ExtraDamage = 0.0m,
                ExtraDamageCount = 0,
                AttackType1 = AttackType.Blunt,
                AttackType2 = AttackType.None,
                AttackMode = AttackMode.Normal,
                TricksterWeaponId = 6
            },
            
            new Attack {
                Id = 230,
                Name = "R1 (sidestep)",
                Damage = 0.95m,
                ExtraDamage = 0.0m,
                ExtraDamageCount = 0,
                AttackType1 = AttackType.Blunt,
                AttackType2 = AttackType.None,
                AttackMode = AttackMode.Normal,
                TricksterWeaponId = 6
            },
            
            new Attack {
                Id = 231,
                Name = "R1 (dash)",
                Damage = 1.1m,
                ExtraDamage = 0.0m,
                ExtraDamageCount = 0,
                AttackType1 = AttackType.Thrust,
                AttackType2 = AttackType.None,
                AttackMode = AttackMode.Normal,
                TricksterWeaponId = 6
            },
            
            new Attack {
                Id = 232,
                Name = "R2",
                Damage = 1.5m,
                ExtraDamage = 0.0m,
                ExtraDamageCount = 0,
                AttackType1 = AttackType.Thrust,
                AttackType2 = AttackType.None,
                AttackMode = AttackMode.Normal,
                TricksterWeaponId = 6
            },
            
            new Attack {
                Id = 233,
                Name = "R2 (charged)",
                Damage = 1.9m,
                ExtraDamage = 0.0m,
                ExtraDamageCount = 0,
                AttackType1 = AttackType.Blunt,
                AttackType2 = AttackType.None,
                AttackMode = AttackMode.Normal,
                TricksterWeaponId = 6
            },
            
            new Attack {
                Id = 234,
                Name = "R2 (backstep)",
                Damage = 1.4m,
                ExtraDamage = 0.0m,
                ExtraDamageCount = 0,
                AttackType1 = AttackType.Blunt,
                AttackType2 = AttackType.None,
                AttackMode = AttackMode.Normal,
                TricksterWeaponId = 6
            },
            
            new Attack {
                Id = 235,
                Name = "R2 (dash)",
                Damage = 1.5m,
                ExtraDamage = 0.0m,
                ExtraDamageCount = 0,
                AttackType1 = AttackType.Blunt,
                AttackType2 = AttackType.None,
                AttackMode = AttackMode.Normal,
                TricksterWeaponId = 6
            },
            
            new Attack {
                Id = 236,
                Name = "R2 (forward leap)",
                Damage = 1.4m,
                ExtraDamage = 0.0m,
                ExtraDamageCount = 0,
                AttackType1 = AttackType.Blunt,
                AttackType2 = AttackType.None,
                AttackMode = AttackMode.Normal,
                TricksterWeaponId = 6
            },
            
            new Attack {
                Id = 237,
                Name = "Transform Attack",
                Damage = 1.3m,
                ExtraDamage = 0.0m,
                ExtraDamageCount = 0,
                AttackType1 = AttackType.Blood,
                AttackType2 = AttackType.None,
                AttackMode = AttackMode.Normal,
                TricksterWeaponId = 6
            },
            
            new Attack {
                Id = 238,
                Name = "Plunge Attack",
                Damage = 1.4m,
                ExtraDamage = 0.0m,
                ExtraDamageCount = 0,
                AttackType1 = AttackType.Blunt,
                AttackType2 = AttackType.None,
                AttackMode = AttackMode.Normal,
                TricksterWeaponId = 6
            },
            
            new Attack {
                Id = 239,
                Name = "Plunge Attack (2nd)",
                Damage = 0.9m,
                ExtraDamage = 0.0m,
                ExtraDamageCount = 0,
                AttackType1 = AttackType.Blunt,
                AttackType2 = AttackType.None,
                AttackMode = AttackMode.Normal,
                TricksterWeaponId = 6
            },
            
            new Attack {
                Id = 240,
                Name = "R1",
                Damage = 1.05m,
                ExtraDamage = 0.0m,
                ExtraDamageCount = 0,
                AttackType1 = AttackType.Blood,
                AttackType2 = AttackType.None,
                AttackMode = AttackMode.Transformed,
                TricksterWeaponId = 6
            },
            
            new Attack {
                Id = 241,
                Name = "R1 (2nd)",
                Damage = 1.05m,
                ExtraDamage = 0.0m,
                ExtraDamageCount = 0,
                AttackType1 = AttackType.Blood,
                AttackType2 = AttackType.None,
                AttackMode = AttackMode.Transformed,
                TricksterWeaponId = 6
            },
            
            new Attack {
                Id = 242,
                Name = "R1 (3rd)",
                Damage = 1.05m,
                ExtraDamage = 0.0m,
                ExtraDamageCount = 0,
                AttackType1 = AttackType.Blood,
                AttackType2 = AttackType.None,
                AttackMode = AttackMode.Transformed,
                TricksterWeaponId = 6
            },
            
            new Attack {
                Id = 243,
                Name = "R1 (4th)",
                Damage = 1.1m,
                ExtraDamage = 0.0m,
                ExtraDamageCount = 0,
                AttackType1 = AttackType.Blood,
                AttackType2 = AttackType.None,
                AttackMode = AttackMode.Transformed,
                TricksterWeaponId = 6
            },
            
            new Attack {
                Id = 244,
                Name = "R1 (5th)",
                Damage = 1.1m,
                ExtraDamage = 0.0m,
                ExtraDamageCount = 0,
                AttackType1 = AttackType.Blood,
                AttackType2 = AttackType.None,
                AttackMode = AttackMode.Transformed,
                TricksterWeaponId = 6
            },
            
            new Attack {
                Id = 245,
                Name = "R1 (backstep)",
                Damage = 1.0m,
                ExtraDamage = 0.0m,
                ExtraDamageCount = 0,
                AttackType1 = AttackType.Blood,
                AttackType2 = AttackType.None,
                AttackMode = AttackMode.Transformed,
                TricksterWeaponId = 6
            },
            
            new Attack {
                Id = 246,
                Name = "R1 (rolling)",
                Damage = 1.0m,
                ExtraDamage = 0.0m,
                ExtraDamageCount = 0,
                AttackType1 = AttackType.Blood,
                AttackType2 = AttackType.None,
                AttackMode = AttackMode.Transformed,
                TricksterWeaponId = 6
            },
            
            new Attack {
                Id = 247,
                Name = "R1 (frontstep)",
                Damage = 1.0m,
                ExtraDamage = 0.0m,
                ExtraDamageCount = 0,
                AttackType1 = AttackType.Blood,
                AttackType2 = AttackType.None,
                AttackMode = AttackMode.Transformed,
                TricksterWeaponId = 6
            },

            new Attack {
                Id = 248,
                Name = "R1 (sidestep)",
                Damage = 1.0m,
                ExtraDamage = 0.0m,
                ExtraDamageCount = 0,
                AttackType1 = AttackType.Blood,
                AttackType2 = AttackType.None,
                AttackMode = AttackMode.Transformed,
                TricksterWeaponId = 6
            },
            
            new Attack {
                Id = 249,
                Name = "R1 (dash)",
                Damage = 1.15m,
                ExtraDamage = 0.0m,
                ExtraDamageCount = 0,
                AttackType1 = AttackType.Blood,
                AttackType2 = AttackType.None,
                AttackMode = AttackMode.Transformed,
                TricksterWeaponId = 6
            },
            
            new Attack {
                Id = 250,
                Name = "R2",
                Damage = 1.5m,
                ExtraDamage = 0.0m,
                ExtraDamageCount = 0,
                AttackType1 = AttackType.Blood,
                AttackType2 = AttackType.None,
                AttackMode = AttackMode.Transformed,
                TricksterWeaponId = 6
            },
            
            new Attack {
                Id = 251,
                Name = "R2 (charged)",
                Damage = 2.0m,
                ExtraDamage = 0.0m,
                ExtraDamageCount = 0,
                AttackType1 = AttackType.Blood,
                AttackType2 = AttackType.None,
                AttackMode = AttackMode.Transformed,
                TricksterWeaponId = 6
            },
            
            new Attack {
                Id = 252,
                Name = "R2 (backstep)",
                Damage = 1.4m,
                ExtraDamage = 0.0m,
                ExtraDamageCount = 0,
                AttackType1 = AttackType.Blood,
                AttackType2 = AttackType.None,
                AttackMode = AttackMode.Transformed,
                TricksterWeaponId = 6
            },
            
            new Attack {
                Id = 253,
                Name = "R2 (dash)",
                Damage = 1.4m,
                ExtraDamage = 0.0m,
                ExtraDamageCount = 0,
                AttackType1 = AttackType.Blood,
                AttackType2 = AttackType.None,
                AttackMode = AttackMode.Transformed,
                TricksterWeaponId = 6
            },
            
            new Attack {
                Id = 254,
                Name = "R2 (forward leap)",
                Damage = 1.4m,
                ExtraDamage = 0.0m,
                ExtraDamageCount = 0,
                AttackType1 = AttackType.Blood,
                AttackType2 = AttackType.None,
                AttackMode = AttackMode.Transformed,
                TricksterWeaponId = 6
            },
            
            new Attack {
                Id = 255,
                Name = "L2",
                Damage = 2.0m,
                ExtraDamage = 0.0m,
                ExtraDamageCount = 0,
                AttackType1 = AttackType.Blood,
                AttackType2 = AttackType.None,
                AttackMode = AttackMode.Transformed,
                TricksterWeaponId = 6
            },
            
            new Attack {
                Id = 256,
                Name = "Transform Attack",
                Damage = 1.2m,
                ExtraDamage = 0.0m,
                ExtraDamageCount = 0,
                AttackType1 = AttackType.Blood,
                AttackType2 = AttackType.None,
                AttackMode = AttackMode.Transformed,
                TricksterWeaponId = 6
            },
            
            new Attack {
                Id = 257,
                Name = "Plunge Attack",
                Damage = 1.4m,
                ExtraDamage = 0.0m,
                ExtraDamageCount = 0,
                AttackType1 = AttackType.Blood,
                AttackType2 = AttackType.None,
                AttackMode = AttackMode.Transformed,
                TricksterWeaponId = 6
            },
            
            new Attack {
                Id = 258,
                Name = "Plunge Attack (2nd)",
                Damage = 0.9m,
                ExtraDamage = 0.0m,
                ExtraDamageCount = 0,
                AttackType1 = AttackType.Blunt,
                AttackType2 = AttackType.None,
                AttackMode = AttackMode.Transformed,
                TricksterWeaponId = 6
            },
            
            new Attack {
                Id = 259,
                Name = "R1",
                Damage = 1.0m,
                ExtraDamage = 0.0m,
                ExtraDamageCount = 0,
                AttackType1 = AttackType.Blunt,
                AttackType2 = AttackType.None,
                AttackMode = AttackMode.Normal,
                TricksterWeaponId = 7
            },
            
            new Attack {
                Id = 260,
                Name = "R1 (2nd)",
                Damage = 1.02m,
                ExtraDamage = 0.0m,
                ExtraDamageCount = 0,
                AttackType1 = AttackType.Blunt,
                AttackType2 = AttackType.None,
                AttackMode = AttackMode.Normal,
                TricksterWeaponId = 7
            },
            
            new Attack {
                Id = 261,
                Name = "R1 (3rd)",
                Damage = 1.04m,
                ExtraDamage = 0.0m,
                ExtraDamageCount = 0,
                AttackType1 = AttackType.Blunt,
                AttackType2 = AttackType.None,
                AttackMode = AttackMode.Normal,
                TricksterWeaponId = 7
            },
            
            new Attack {
                Id = 262,
                Name = "R1 (backstep)",
                Damage = 0.9m,
                ExtraDamage = 0.0m,
                ExtraDamageCount = 0,
                AttackType1 = AttackType.Blunt,
                AttackType2 = AttackType.None,
                AttackMode = AttackMode.Normal,
                TricksterWeaponId = 7
            },
            
            new Attack {
                Id = 263,
                Name = "R1 (rolling)",
                Damage = 0.9m,
                ExtraDamage = 0.0m,
                ExtraDamageCount = 0,
                AttackType1 = AttackType.Blunt,
                AttackType2 = AttackType.None,
                AttackMode = AttackMode.Normal,
                TricksterWeaponId = 7
            },
            
            new Attack {
                Id = 264,
                Name = "R1 (frontstep)",
                Damage = 0.9m,
                ExtraDamage = 0.0m,
                ExtraDamageCount = 0,
                AttackType1 = AttackType.Blunt,
                AttackType2 = AttackType.None,
                AttackMode = AttackMode.Normal,
                TricksterWeaponId = 7
            },
            
            new Attack {
                Id = 265,
                Name = "R1 (sidestep)",
                Damage = 0.9m,
                ExtraDamage = 0.0m,
                ExtraDamageCount = 0,
                AttackType1 = AttackType.Blunt,
                AttackType2 = AttackType.None,
                AttackMode = AttackMode.Normal,
                TricksterWeaponId = 7
            },
            
            new Attack {
                Id = 266,
                Name = "R1 (dash)",
                Damage = 1.1m,
                ExtraDamage = 0.0m,
                ExtraDamageCount = 0,
                AttackType1 = AttackType.Blunt,
                AttackType2 = AttackType.None,
                AttackMode = AttackMode.Normal,
                TricksterWeaponId = 7
            },
            
            new Attack {
                Id = 267,
                Name = "R2",
                Damage = 1.35m,
                ExtraDamage = 0.0m,
                ExtraDamageCount = 0,
                AttackType1 = AttackType.Blunt,
                AttackType2 = AttackType.None,
                AttackMode = AttackMode.Normal,
                TricksterWeaponId = 7
            },
            
            new Attack {
                Id = 268,
                Name = "R2 (charged)",
                Damage = 1.9m,
                ExtraDamage = 0.0m,
                ExtraDamageCount = 0,
                AttackType1 = AttackType.Blunt,
                AttackType2 = AttackType.None,
                AttackMode = AttackMode.Normal,
                TricksterWeaponId = 7
            },
            
            new Attack {
                Id = 269,
                Name = "R2 (backstep)",
                Damage = 1.2m,
                ExtraDamage = 0.0m,
                ExtraDamageCount = 0,
                AttackType1 = AttackType.Blunt,
                AttackType2 = AttackType.None,
                AttackMode = AttackMode.Normal,
                TricksterWeaponId = 7
            },
            
            new Attack {
                Id = 270,
                Name = "R2 (dash)",
                Damage = 1.45m,
                ExtraDamage = 0.0m,
                ExtraDamageCount = 0,
                AttackType1 = AttackType.Blunt,
                AttackType2 = AttackType.None,
                AttackMode = AttackMode.Normal,
                TricksterWeaponId = 7
            },
            
            new Attack {
                Id = 271,
                Name = "R2 (forward leap)",
                Damage = 1.5m,
                ExtraDamage = 0.0m,
                ExtraDamageCount = 0,
                AttackType1 = AttackType.Blunt,
                AttackType2 = AttackType.None,
                AttackMode = AttackMode.Normal,
                TricksterWeaponId = 7
            },
            
            new Attack {
                Id = 272,
                Name = "Transform Attack",
                Damage = 0.8m,
                ExtraDamage = 0.0m,
                ExtraDamageCount = 0,
                AttackType1 = AttackType.Blunt,
                AttackType2 = AttackType.None,
                AttackMode = AttackMode.Normal,
                TricksterWeaponId = 7
            },
            
            new Attack {
                Id = 273,
                Name = "Plunge Attack",
                Damage = 1.5m,
                ExtraDamage = 0.0m,
                ExtraDamageCount = 0,
                AttackType1 = AttackType.Blunt,
                AttackType2 = AttackType.None,
                AttackMode = AttackMode.Normal,
                TricksterWeaponId = 7
            },
            
            new Attack {
                Id = 274,
                Name = "Plunge Attack (2nd)",
                Damage = 0.9m,
                ExtraDamage = 0.0m,
                ExtraDamageCount = 0,
                AttackType1 = AttackType.Blunt,
                AttackType2 = AttackType.None,
                AttackMode = AttackMode.Normal,
                TricksterWeaponId = 7
            },
            
            new Attack {
                Id = 275,
                Name = "R1",
                Damage = 1.0m,
                ExtraDamage = 0.8m,
                ExtraDamageCount = 1,
                AttackType1 = AttackType.Blunt,
                AttackType2 = AttackType.Fire,
                AttackMode = AttackMode.Transformed,
                TricksterWeaponId = 7
            },
            
            new Attack {
                Id = 276,
                Name = "R1 (2nd)",
                Damage = 1.02m,
                ExtraDamage = 0.8m,
                ExtraDamageCount = 1,
                AttackType1 = AttackType.Blunt,
                AttackType2 = AttackType.Fire,
                AttackMode = AttackMode.Transformed,
                TricksterWeaponId = 7
            },
            
            new Attack {
                Id = 277,
                Name = "R1 (3rd)",
                Damage = 1.04m,
                ExtraDamage = 0.8m,
                ExtraDamageCount = 1,
                AttackType1 = AttackType.Blunt,
                AttackType2 = AttackType.Fire,
                AttackMode = AttackMode.Transformed,
                TricksterWeaponId = 7
            },
            
            new Attack {
                Id = 278,
                Name = "R1 (backstep)",
                Damage = 0.9m,
                ExtraDamage = 0.8m,
                ExtraDamageCount = 1,
                AttackType1 = AttackType.Blunt,
                AttackType2 = AttackType.Fire,
                AttackMode = AttackMode.Transformed,
                TricksterWeaponId = 7
            },
            
            new Attack {
                Id = 279,
                Name = "R1 (rolling)",
                Damage = 0.9m,
                ExtraDamage = 0.8m,
                ExtraDamageCount = 1,
                AttackType1 = AttackType.Blunt,
                AttackType2 = AttackType.Fire,
                AttackMode = AttackMode.Transformed,
                TricksterWeaponId = 7
            },
            
            new Attack {
                Id = 280,
                Name = "R1 (frontstep)",
                Damage = 0.9m,
                ExtraDamage = 0.8m,
                ExtraDamageCount = 1,
                AttackType1 = AttackType.Blunt,
                AttackType2 = AttackType.Fire,
                AttackMode = AttackMode.Transformed,
                TricksterWeaponId = 7
            },
            
            new Attack {
                Id = 281,
                Name = "R1 (sidestep)",
                Damage = 0.9m,
                ExtraDamage = 0.8m,
                ExtraDamageCount = 1,
                AttackType1 = AttackType.Blunt,
                AttackType2 = AttackType.Fire,
                AttackMode = AttackMode.Transformed,
                TricksterWeaponId = 7
            },
            
            new Attack {
                Id = 282,
                Name = "R1 (dash)",
                Damage = 1.1m,
                ExtraDamage = 0.8m,
                ExtraDamageCount = 1,
                AttackType1 = AttackType.Blunt,
                AttackType2 = AttackType.Fire,
                AttackMode = AttackMode.Transformed,
                TricksterWeaponId = 7
            },
            
            new Attack {
                Id = 283,
                Name = "R2",
                Damage = 1.35m,
                ExtraDamage = 0.8m,
                ExtraDamageCount = 1,
                AttackType1 = AttackType.Blunt,
                AttackType2 = AttackType.Fire,
                AttackMode = AttackMode.Transformed,
                TricksterWeaponId = 7
            },
            
            new Attack {
                Id = 284,
                Name = "R2 (charged)",
                Damage = 1.9m,
                ExtraDamage = 0.8m,
                ExtraDamageCount = 1,
                AttackType1 = AttackType.Blunt,
                AttackType2 = AttackType.Fire,
                AttackMode = AttackMode.Transformed,
                TricksterWeaponId = 7
            },
            
            new Attack {
                Id = 285,
                Name = "R2 (backstep)",
                Damage = 1.2m,
                ExtraDamage = 0.8m,
                ExtraDamageCount = 1,
                AttackType1 = AttackType.Blunt,
                AttackType2 = AttackType.Fire,
                AttackMode = AttackMode.Transformed,
                TricksterWeaponId = 7
            },
            
            new Attack {
                Id = 286,
                Name = "R2 (dash)",
                Damage = 1.45m,
                ExtraDamage = 0.8m,
                ExtraDamageCount = 1,
                AttackType1 = AttackType.Blunt,
                AttackType2 = AttackType.Fire,
                AttackMode = AttackMode.Transformed,
                TricksterWeaponId = 7
            },
            
            new Attack {
                Id = 287,
                Name = "R2 (forward leap)",
                Damage = 1.5m,
                ExtraDamage = 0.8m,
                ExtraDamageCount = 1,
                AttackType1 = AttackType.Blunt,
                AttackType2 = AttackType.Fire,
                AttackMode = AttackMode.Transformed,
                TricksterWeaponId = 7
            },
            
            new Attack {
                Id = 288,
                Name = "Transform Attack",
                Damage = 0.8m,
                ExtraDamage = 0.8m,
                ExtraDamageCount = 1,
                AttackType1 = AttackType.Blunt,
                AttackType2 = AttackType.Fire,
                AttackMode = AttackMode.Transformed,
                TricksterWeaponId = 7
            },
            
            new Attack {
                Id = 289,
                Name = "Plunge Attack",
                Damage = 1.5m,
                ExtraDamage = 0.8m,
                ExtraDamageCount = 1,
                AttackType1 = AttackType.Blunt,
                AttackType2 = AttackType.Fire,
                AttackMode = AttackMode.Transformed,
                TricksterWeaponId = 7
            },
            
            new Attack {
                Id = 290,
                Name = "Plunge Attack (2nd)",
                Damage = 0.9m,
                ExtraDamage = 0.8m,
                ExtraDamageCount = 1,
                AttackType1 = AttackType.Blunt,
                AttackType2 = AttackType.Fire,
                AttackMode = AttackMode.Transformed,
                TricksterWeaponId = 7
            },
            
            new Attack {
                Id = 291,
                Name = "R1",
                Damage = 1.0m,
                ExtraDamage = 0.0m,
                ExtraDamageCount = 0,
                AttackType1 = AttackType.Physical,
                AttackType2 = AttackType.Arcane,
                AttackMode = AttackMode.Normal,
                TricksterWeaponId = 8
            },
            
            new Attack {
                Id = 292,
                Name = "R1 (2nd)",
                Damage = 1.02m,
                ExtraDamage = 0.0m,
                ExtraDamageCount = 0,
                AttackType1 = AttackType.Physical,
                AttackType2 = AttackType.Arcane,
                AttackMode = AttackMode.Normal,
                TricksterWeaponId = 8
            },
            
            new Attack {
                Id = 293,
                Name = "R1 (3rd)",
                Damage = 1.05m,
                ExtraDamage = 0.0m,
                ExtraDamageCount = 0,
                AttackType1 = AttackType.Physical,
                AttackType2 = AttackType.Arcane,
                AttackMode = AttackMode.Normal,
                TricksterWeaponId = 8
            },
            
            new Attack {
                Id = 294,
                Name = "R1 (4th)",
                Damage = 1.05m,
                ExtraDamage = 0.0m,
                ExtraDamageCount = 0,
                AttackType1 = AttackType.Physical,
                AttackType2 = AttackType.Arcane,
                AttackMode = AttackMode.Normal,
                TricksterWeaponId = 8
            },
            
            new Attack {
                Id = 295,
                Name = "R1 (5th)",
                Damage = 1.05m,
                ExtraDamage = 0.0m,
                ExtraDamageCount = 0,
                AttackType1 = AttackType.Physical,
                AttackType2 = AttackType.Arcane,
                AttackMode = AttackMode.Normal,
                TricksterWeaponId = 8
            },
            
            new Attack {
                Id = 296,
                Name = "R1 (backstep)",
                Damage = 1.05m,
                ExtraDamage = 0.0m,
                ExtraDamageCount = 0,
                AttackType1 = AttackType.Thrust,
                AttackType2 = AttackType.Arcane,
                AttackMode = AttackMode.Normal,
                TricksterWeaponId = 8
            },
            
            new Attack {
                Id = 297,
                Name = "R1 (rolling)",
                Damage = 1.15m,
                ExtraDamage = 0.0m,
                ExtraDamageCount = 0,
                AttackType1 = AttackType.Physical,
                AttackType2 = AttackType.Arcane,
                AttackMode = AttackMode.Normal,
                TricksterWeaponId = 8
            },
            
            new Attack {
                Id = 298,
                Name = "R1 (frontstep)",
                Damage = 1.15m,
                ExtraDamage = 0.0m,
                ExtraDamageCount = 0,
                AttackType1 = AttackType.Physical,
                AttackType2 = AttackType.Arcane,
                AttackMode = AttackMode.Normal,
                TricksterWeaponId = 8
            },
            
            new Attack {
                Id = 299,
                Name = "R1 (sidestep)",
                Damage = 1.1m,
                ExtraDamage = 0.0m,
                ExtraDamageCount = 0,
                AttackType1 = AttackType.Physical,
                AttackType2 = AttackType.Arcane,
                AttackMode = AttackMode.Normal,
                TricksterWeaponId = 8
            },
            
            new Attack {
                Id = 300,
                Name = "R1 (dash)",
                Damage = 1.2m,
                ExtraDamage = 0.0m,
                ExtraDamageCount = 0,
                AttackType1 = AttackType.Physical,
                AttackType2 = AttackType.Arcane,
                AttackMode = AttackMode.Normal,
                TricksterWeaponId = 8
            },
            
            new Attack {
                Id = 301,
                Name = "R2",
                Damage = 1.22m,
                ExtraDamage = 0.0m,
                ExtraDamageCount = 0,
                AttackType1 = AttackType.Physical,
                AttackType2 = AttackType.Arcane,
                AttackMode = AttackMode.Normal,
                TricksterWeaponId = 8
            },
            
            new Attack {
                Id = 302,
                Name = "R2 (charged)",
                Damage = 1.7m,
                ExtraDamage = 0.0m,
                ExtraDamageCount = 0,
                AttackType1 = AttackType.Physical,
                AttackType2 = AttackType.Arcane,
                AttackMode = AttackMode.Normal,
                TricksterWeaponId = 8
            },
            
            new Attack {
                Id = 303,
                Name = "R2 (backstep)",
                Damage = 1.28m,
                ExtraDamage = 0.0m,
                ExtraDamageCount = 0,
                AttackType1 = AttackType.Physical,
                AttackType2 = AttackType.Arcane,
                AttackMode = AttackMode.Normal,
                TricksterWeaponId = 8
            },
            
            new Attack {
                Id = 304,
                Name = "R2 (dash)",
                Damage = 1.32m,
                ExtraDamage = 0.0m,
                ExtraDamageCount = 0,
                AttackType1 = AttackType.Physical,
                AttackType2 = AttackType.Arcane,
                AttackMode = AttackMode.Normal,
                TricksterWeaponId = 8
            },
            
            new Attack {
                Id = 305,
                Name = "R2 (forward leap)",
                Damage = 1.4m,
                ExtraDamage = 0.0m,
                ExtraDamageCount = 0,
                AttackType1 = AttackType.Physical,
                AttackType2 = AttackType.Arcane,
                AttackMode = AttackMode.Normal,
                TricksterWeaponId = 8
            },
            
            new Attack {
                Id = 306,
                Name = "Transform Attack",
                Damage = 1.6m,
                ExtraDamage = 0.0m,
                ExtraDamageCount = 0,
                AttackType1 = AttackType.Physical,
                AttackType2 = AttackType.Arcane,
                AttackMode = AttackMode.Normal,
                TricksterWeaponId = 8
            },
            
            new Attack {
                Id = 307,
                Name = "Plunge Attack",
                Damage = 1.4m,
                ExtraDamage = 0.0m,
                ExtraDamageCount = 0,
                AttackType1 = AttackType.Physical,
                AttackType2 = AttackType.Arcane,
                AttackMode = AttackMode.Normal,
                TricksterWeaponId = 8
            },
            
            new Attack {
                Id = 308,
                Name = "Plunge Attack (2nd)",
                Damage = 1.4m,
                ExtraDamage = 0.0m,
                ExtraDamageCount = 0,
                AttackType1 = AttackType.Blunt,
                AttackType2 = AttackType.Arcane,
                AttackMode = AttackMode.Normal,
                TricksterWeaponId = 8
            },
            
            new Attack {
                Id = 309,
                Name = "R1",
                Damage = 1.1m,
                ExtraDamage = 0.0m,
                ExtraDamageCount = 0,
                AttackType1 = AttackType.Physical,
                AttackType2 = AttackType.Arcane,
                AttackMode = AttackMode.Transformed,
                TricksterWeaponId = 8
            },
            
            new Attack {
                Id = 310,
                Name = "R1 (2nd)",
                Damage = 1.1m,
                ExtraDamage = 0.0m,
                ExtraDamageCount = 0,
                AttackType1 = AttackType.Physical,
                AttackType2 = AttackType.Arcane,
                AttackMode = AttackMode.Transformed,
                TricksterWeaponId = 8
            },
            
            new Attack {
                Id = 311,
                Name = "R1 (3rd)",
                Damage = 1.12m,
                ExtraDamage = 0.0m,
                ExtraDamageCount = 0,
                AttackType1 = AttackType.Physical,
                AttackType2 = AttackType.Arcane,
                AttackMode = AttackMode.Transformed,
                TricksterWeaponId = 8
            },
            
            new Attack {
                Id = 312,
                Name = "R1 (4th)",
                Damage = 1.15m,
                ExtraDamage = 0.0m,
                ExtraDamageCount = 0,
                AttackType1 = AttackType.Physical,
                AttackType2 = AttackType.Arcane,
                AttackMode = AttackMode.Transformed,
                TricksterWeaponId = 8
            },
            
            new Attack {
                Id = 313,
                Name = "R1 (backstep)",
                Damage = 1.15m,
                ExtraDamage = 0.0m,
                ExtraDamageCount = 0,
                AttackType1 = AttackType.Physical,
                AttackType2 = AttackType.Arcane,
                AttackMode = AttackMode.Transformed,
                TricksterWeaponId = 8
            },
            
            new Attack {
                Id = 314,
                Name = "R1 (rolling)",
                Damage = 1.2m,
                ExtraDamage = 0.0m,
                ExtraDamageCount = 0,
                AttackType1 = AttackType.Physical,
                AttackType2 = AttackType.Arcane,
                AttackMode = AttackMode.Transformed,
                TricksterWeaponId = 8
            },
            
            new Attack {
                Id = 315,
                Name = "R1 (frontstep)",
                Damage = 1.2m,
                ExtraDamage = 0.0m,
                ExtraDamageCount = 0,
                AttackType1 = AttackType.Physical,
                AttackType2 = AttackType.Arcane,
                AttackMode = AttackMode.Transformed,
                TricksterWeaponId = 8
            },
            
            new Attack {
                Id = 316,
                Name = "R1 (sidestep)",
                Damage = 1.2m,
                ExtraDamage = 0.0m,
                ExtraDamageCount = 0,
                AttackType1 = AttackType.Physical,
                AttackType2 = AttackType.Arcane,
                AttackMode = AttackMode.Transformed,
                TricksterWeaponId = 8
            },
            
            new Attack {
                Id = 317,
                Name = "R1 (dash)",
                Damage = 1.27m,
                ExtraDamage = 0.0m,
                ExtraDamageCount = 0,
                AttackType1 = AttackType.Physical,
                AttackType2 = AttackType.Arcane,
                AttackMode = AttackMode.Transformed,
                TricksterWeaponId = 8
            },
            
            new Attack {
                Id = 318,
                Name = "R2",
                Damage = 1.45m,
                ExtraDamage = 0.0m,
                ExtraDamageCount = 0,
                AttackType1 = AttackType.Physical,
                AttackType2 = AttackType.Arcane,
                AttackMode = AttackMode.Transformed,
                TricksterWeaponId = 8
            },
            
            new Attack {
                Id = 319,
                Name = "R2 (charged)",
                Damage = 1.9m,
                ExtraDamage = 0.0m,
                ExtraDamageCount = 0,
                AttackType1 = AttackType.Physical,
                AttackType2 = AttackType.Arcane,
                AttackMode = AttackMode.Transformed,
                TricksterWeaponId = 8
            },
            
            new Attack {
                Id = 320,
                Name = "R2 (backstep)",
                Damage = 1.45m,
                ExtraDamage = 0.0m,
                ExtraDamageCount = 0,
                AttackType1 = AttackType.Physical,
                AttackType2 = AttackType.Arcane,
                AttackMode = AttackMode.Transformed,
                TricksterWeaponId = 8
            },
            
            new Attack {
                Id = 321,
                Name = "R2 (dash)",
                Damage = 1.5m,
                ExtraDamage = 0.0m,
                ExtraDamageCount = 0,
                AttackType1 = AttackType.Physical,
                AttackType2 = AttackType.Arcane,
                AttackMode = AttackMode.Transformed,
                TricksterWeaponId = 8
            },
            
            new Attack {
                Id = 322,
                Name = "R2(forward leap)",
                Damage = 1.45m,
                ExtraDamage = 0.0m,
                ExtraDamageCount = 0,
                AttackType1 = AttackType.Physical,
                AttackType2 = AttackType.Arcane,
                AttackMode = AttackMode.Transformed,
                TricksterWeaponId = 8
            },
            
            new Attack {
                Id = 323,
                Name = "L2",
                Damage = 1.4m,
                ExtraDamage = 0.0m,
                ExtraDamageCount = 0,
                AttackType1 = AttackType.Physical,
                AttackType2 = AttackType.Arcane,
                AttackMode = AttackMode.Transformed,
                TricksterWeaponId = 8
            },
            
            new Attack {
                Id = 324,
                Name = "L2 (2nd)",
                Damage = 1.25m,
                ExtraDamage = 0.0m,
                ExtraDamageCount = 0,
                AttackType1 = AttackType.Physical,
                AttackType2 = AttackType.Arcane,
                AttackMode = AttackMode.Transformed,
                TricksterWeaponId = 8
            },
            
            new Attack {
                Id = 325,
                Name = "L2 (3rd)",
                Damage = 1.5m,
                ExtraDamage = 0.0m,
                ExtraDamageCount = 0,
                AttackType1 = AttackType.Physical,
                AttackType2 = AttackType.Arcane,
                AttackMode = AttackMode.Transformed,
                TricksterWeaponId = 8
            },
            
            new Attack {
                Id = 326,
                Name = "L2 (4th)",
                Damage = 1.5m,
                ExtraDamage = 0.0m,
                ExtraDamageCount = 0,
                AttackType1 = AttackType.Physical,
                AttackType2 = AttackType.Arcane,
                AttackMode = AttackMode.Transformed,
                TricksterWeaponId = 8
            },
            
            new Attack {
                Id = 327,
                Name = "Transform Attack",
                Damage = 1.1m,
                ExtraDamage = 0.0m,
                ExtraDamageCount = 0,
                AttackType1 = AttackType.Physical,
                AttackType2 = AttackType.Arcane,
                AttackMode = AttackMode.Transformed,
                TricksterWeaponId = 8
            },
            
            new Attack {
                Id = 328,
                Name = "Plunge Attack",
                Damage = 1.5m,
                ExtraDamage = 0.0m,
                ExtraDamageCount = 0,
                AttackType1 = AttackType.Physical,
                AttackType2 = AttackType.Arcane,
                AttackMode = AttackMode.Transformed,
                TricksterWeaponId = 8
            },
            
            new Attack {
                Id = 329,
                Name = "Plunge Attack (2nd)",
                Damage = 0.95m,
                ExtraDamage = 0.0m,
                ExtraDamageCount = 0,
                AttackType1 = AttackType.Blunt ,
                AttackType2 = AttackType.Arcane,
                AttackMode = AttackMode.Transformed,
                TricksterWeaponId = 8
            },
            
            new Attack {
                Id = 330,
                Name = "R1",
                Damage = 1.0m,
                ExtraDamage = 0.0m,
                ExtraDamageCount = 0,
                AttackType1 = AttackType.Physical,
                AttackType2 = AttackType.None,
                AttackMode = AttackMode.Normal,
                TricksterWeaponId = 9
            },
            
            new Attack {
                Id = 331,
                Name = "R1 (2nd)",
                Damage = 1.0m,
                ExtraDamage = 0.0m,
                ExtraDamageCount = 0,
                AttackType1 = AttackType.Physical,
                AttackType2 = AttackType.None,
                AttackMode = AttackMode.Normal,
                TricksterWeaponId = 9
            },
            
            new Attack {
                Id = 332,
                Name = "R1 (3rd)",
                Damage = 1.05m,
                ExtraDamage = 0.0m,
                ExtraDamageCount = 0,
                AttackType1 = AttackType.Physical,
                AttackType2 = AttackType.None,
                AttackMode = AttackMode.Normal,
                TricksterWeaponId = 9
            },
            
            new Attack {
                Id = 333,
                Name = "R1 (4th)",
                Damage = 1.1m,
                ExtraDamage = 0.0m,
                ExtraDamageCount = 0,
                AttackType1 = AttackType.Physical,
                AttackType2 = AttackType.None,
                AttackMode = AttackMode.Normal,
                TricksterWeaponId = 9
            },
            
            new Attack {
                Id = 334,
                Name = "R1 (5th)",
                Damage = 1.1m,
                ExtraDamage = 0.0m,
                ExtraDamageCount = 0,
                AttackType1 = AttackType.Physical,
                AttackType2 = AttackType.None,
                AttackMode = AttackMode.Normal,
                TricksterWeaponId = 9
            },
            
            new Attack {
                Id = 335,
                Name = "R1 (backstep)",
                Damage = 1.0m,
                ExtraDamage = 0.0m,
                ExtraDamageCount = 0,
                AttackType1 = AttackType.Physical,
                AttackType2 = AttackType.None,
                AttackMode = AttackMode.Normal,
                TricksterWeaponId = 9
            },
            
            new Attack {
                Id = 336,
                Name = "R1 (rolling)",
                Damage = 1.05m,
                ExtraDamage = 0.0m,
                ExtraDamageCount = 0,
                AttackType1 = AttackType.Physical,
                AttackType2 = AttackType.None,
                AttackMode = AttackMode.Normal,
                TricksterWeaponId = 9
            },
            
            new Attack {
                Id = 337,
                Name = "R1 (frontstep)",
                Damage = 1.05m,
                ExtraDamage = 0.0m,
                ExtraDamageCount = 0,
                AttackType1 = AttackType.Physical,
                AttackType2 = AttackType.None,
                AttackMode = AttackMode.Normal,
                TricksterWeaponId = 9
            },
            
            new Attack {
                Id = 338,
                Name = "R1 (sidestep)",
                Damage = 1.1m,
                ExtraDamage = 0.0m,
                ExtraDamageCount = 0,
                AttackType1 = AttackType.Physical,
                AttackType2 = AttackType.None,
                AttackMode = AttackMode.Normal,
                TricksterWeaponId = 9
            },
            
            new Attack {
                Id = 339,
                Name = "R1 (dash)",
                Damage = 1.1m,
                ExtraDamage = 0.0m,
                ExtraDamageCount = 0,
                AttackType1 = AttackType.Physical,
                AttackType2 = AttackType.None,
                AttackMode = AttackMode.Normal,
                TricksterWeaponId = 9
            },
            
            new Attack {
                Id = 340,
                Name = "R2",
                Damage = 1.27m,
                ExtraDamage = 0.0m,
                ExtraDamageCount = 0,
                AttackType1 = AttackType.Thrust,
                AttackType2 = AttackType.None,
                AttackMode = AttackMode.Normal,
                TricksterWeaponId = 9
            },
            
            new Attack {
                Id = 341,
                Name = "R2 (charged)",
                Damage = 1.85m,
                ExtraDamage = 0.0m,
                ExtraDamageCount = 0,
                AttackType1 = AttackType.Thrust,
                AttackType2 = AttackType.None,
                AttackMode = AttackMode.Normal,
                TricksterWeaponId = 9
            },
            
            new Attack {
                Id = 342,
                Name = "R2 (backstep)",
                Damage = 1.25m,
                ExtraDamage = 0.0m,
                ExtraDamageCount = 0,
                AttackType1 = AttackType.Physical,
                AttackType2 = AttackType.None,
                AttackMode = AttackMode.Normal,
                TricksterWeaponId = 9
            },
            
            new Attack {
                Id = 343,
                Name = "R2 (dash)",
                Damage = 1.17m,
                ExtraDamage = 0.0m,
                ExtraDamageCount = 0,
                AttackType1 = AttackType.Thrust,
                AttackType2 = AttackType.None,
                AttackMode = AttackMode.Normal,
                TricksterWeaponId = 9
            },
            
            new Attack {
                Id = 344,
                Name = "R2 (forward leap)",
                Damage = 1.45m,
                ExtraDamage = 0.0m,
                ExtraDamageCount = 0,
                AttackType1 = AttackType.Physical,
                AttackType2 = AttackType.None,
                AttackMode = AttackMode.Normal,
                TricksterWeaponId = 9
            },
            
            new Attack {
                Id = 345,
                Name = "Transform Attack",
                Damage = 1.42m,
                ExtraDamage = 0.0m,
                ExtraDamageCount = 0,
                AttackType1 = AttackType.Physical,
                AttackType2 = AttackType.None,
                AttackMode = AttackMode.Normal,
                TricksterWeaponId = 9
            },
            
            new Attack {
                Id = 346,
                Name = "L1 R1",
                Damage = 1.32m,
                ExtraDamage = 0.0m,
                ExtraDamageCount = 0,
                AttackType1 = AttackType.Blood,
                AttackType2 = AttackType.None,
                AttackMode = AttackMode.Normal,
                TricksterWeaponId = 9
            },
            
            new Attack {
                Id = 347,
                Name = "Plunge Attack",
                Damage = 1.45m,
                ExtraDamage = 0.0m,
                ExtraDamageCount = 0,
                AttackType1 = AttackType.Physical,
                AttackType2 = AttackType.None,
                AttackMode = AttackMode.Normal,
                TricksterWeaponId = 9
            },
            
            new Attack {
                Id = 348,
                Name = "Plunge Attack (2nd)",
                Damage = 1.45m,
                ExtraDamage = 0.0m,
                ExtraDamageCount = 0,
                AttackType1 = AttackType.Blunt,
                AttackType2 = AttackType.None,
                AttackMode = AttackMode.Normal,
                TricksterWeaponId = 9
            },
            
            new Attack {
                Id = 349,
                Name = "R1",
                Damage = 0.95m,
                ExtraDamage = 0.0m,
                ExtraDamageCount = 0,
                AttackType1 = AttackType.Blood,
                AttackType2 = AttackType.None,
                AttackMode = AttackMode.Transformed,
                TricksterWeaponId = 9
            },
            
            new Attack {
                Id = 350,
                Name = "R1 (2nd)",
                Damage = 0.98m,
                ExtraDamage = 0.0m,
                ExtraDamageCount = 0,
                AttackType1 = AttackType.Blood,
                AttackType2 = AttackType.None,
                AttackMode = AttackMode.Transformed,
                TricksterWeaponId = 9
            },
            
            new Attack {
                Id = 351,
                Name = "R1 (3rd)",
                Damage = 1.0m,
                ExtraDamage = 0.0m,
                ExtraDamageCount = 0,
                AttackType1 = AttackType.Blood,
                AttackType2 = AttackType.None,
                AttackMode = AttackMode.Transformed,
                TricksterWeaponId = 9
            },
            
            new Attack {
                Id = 352,
                Name = "R1 (4th)",
                Damage = 1.02m,
                ExtraDamage = 0.0m,
                ExtraDamageCount = 0,
                AttackType1 = AttackType.Blood,
                AttackType2 = AttackType.None,
                AttackMode = AttackMode.Transformed,
                TricksterWeaponId = 9
            },
            
            new Attack {
                Id = 353,
                Name = "R1 (5th)",
                Damage = 1.07m,
                ExtraDamage = 0.0m,
                ExtraDamageCount = 0,
                AttackType1 = AttackType.Blood,
                AttackType2 = AttackType.None,
                AttackMode = AttackMode.Transformed,
                TricksterWeaponId = 9
            },
            
            new Attack {
                Id = 354,
                Name = "R1 (backstep)",
                Damage = 1.02m,
                ExtraDamage = 0.0m,
                ExtraDamageCount = 0,
                AttackType1 = AttackType.Blood,
                AttackType2 = AttackType.None,
                AttackMode = AttackMode.Transformed,
                TricksterWeaponId = 9
            },
            
            new Attack {
                Id = 355,
                Name = "R1 (rolling)",
                Damage = 1.0m,
                ExtraDamage = 0.0m,
                ExtraDamageCount = 0,
                AttackType1 = AttackType.Blood,
                AttackType2 = AttackType.None,
                AttackMode = AttackMode.Transformed,
                TricksterWeaponId = 9
            },
            
            new Attack {
                Id = 356,
                Name = "R1 (frontstep)",
                Damage = 1.0m,
                ExtraDamage = 0.0m,
                ExtraDamageCount = 0,
                AttackType1 = AttackType.Blood,
                AttackType2 = AttackType.None,
                AttackMode = AttackMode.Transformed,
                TricksterWeaponId = 9
            },
            
            new Attack {
                Id = 357,
                Name = "R1 (sidestep)",
                Damage = 1.04m,
                ExtraDamage = 0.0m,
                ExtraDamageCount = 0,
                AttackType1 = AttackType.Blood,
                AttackType2 = AttackType.None,
                AttackMode = AttackMode.Transformed,
                TricksterWeaponId = 9
            },
            
            new Attack {
                Id = 358,
                Name = "R1 (dash)",
                Damage = 1.17m,
                ExtraDamage = 0.0m,
                ExtraDamageCount = 0,
                AttackType1 = AttackType.Blood,
                AttackType2 = AttackType.None,
                AttackMode = AttackMode.Transformed,
                TricksterWeaponId = 9
            },
            
            new Attack {
                Id = 359,
                Name = "R2",
                Damage = 1.5m,
                ExtraDamage = 0.0m,
                ExtraDamageCount = 0,
                AttackType1 = AttackType.Blood,
                AttackType2 = AttackType.None,
                AttackMode = AttackMode.Transformed,
                TricksterWeaponId = 9
            },

            new Attack {
                Id = 360,
                Name = "R2 (charged)",
                Damage = 2.25m,
                ExtraDamage = 0.0m,
                ExtraDamageCount = 0,
                AttackType1 = AttackType.Blood,
                AttackType2 = AttackType.None,
                AttackMode = AttackMode.Transformed,
                TricksterWeaponId = 9
            },
            
            new Attack {
                Id = 361,
                Name = "R2 (charged follow-up)",
                Damage = 1.92m,
                ExtraDamage = 0.0m,
                ExtraDamageCount = 0,
                AttackType1 = AttackType.Blood,
                AttackType2 = AttackType.None,
                AttackMode = AttackMode.Transformed,
                TricksterWeaponId = 9
            },
            
            new Attack {
                Id = 362,
                Name = "R2 (backstep)",
                Damage = 1.29m,
                ExtraDamage = 0.0m,
                ExtraDamageCount = 0,
                AttackType1 = AttackType.Blood,
                AttackType2 = AttackType.None,
                AttackMode = AttackMode.Transformed,
                TricksterWeaponId = 9
            },
            
            new Attack {
                Id = 363,
                Name = "R2 (dash)",
                Damage = 1.27m,
                ExtraDamage = 0.0m,
                ExtraDamageCount = 0,
                AttackType1 = AttackType.Thrust,
                AttackType2 = AttackType.None,
                AttackMode = AttackMode.Transformed,
                TricksterWeaponId = 9
            },
            
            new Attack {
                Id = 364,
                Name = "R2(forward leap)",
                Damage = 1.47m,
                ExtraDamage = 0.0m,
                ExtraDamageCount = 0,
                AttackType1 = AttackType.Blood,
                AttackType2 = AttackType.None,
                AttackMode = AttackMode.Transformed,
                TricksterWeaponId = 9
            },
            
            new Attack {
                Id = 365,
                Name = "L2",
                Damage = 1.27m,
                ExtraDamage = 0.0m,
                ExtraDamageCount = 0,
                AttackType1 = AttackType.Thrust,
                AttackType2 = AttackType.None,
                AttackMode = AttackMode.Transformed,
                TricksterWeaponId = 9
            },
            
            new Attack {
                Id = 366,
                Name = "L2 (2nd)",
                Damage = 1.27m,
                ExtraDamage = 0.0m,
                ExtraDamageCount = 0,
                AttackType1 = AttackType.Blood,
                AttackType2 = AttackType.None,
                AttackMode = AttackMode.Transformed,
                TricksterWeaponId = 9
            },
            
            new Attack {
                Id = 367,
                Name = "Transform Attack",
                Damage = 0.95m,
                ExtraDamage = 0.0m,
                ExtraDamageCount = 0,
                AttackType1 = AttackType.Blood,
                AttackType2 = AttackType.None,
                AttackMode = AttackMode.Transformed,
                TricksterWeaponId = 9
            },
            
            new Attack {
                Id = 368,
                Name = "Plunge Attack",
                Damage = 1.42m,
                ExtraDamage = 0.0m,
                ExtraDamageCount = 0,
                AttackType1 = AttackType.Blood,
                AttackType2 = AttackType.None,
                AttackMode = AttackMode.Transformed,
                TricksterWeaponId = 9
            },
            
            new Attack {
                Id = 369,
                Name = "Plunge Attack (2nd)",
                Damage = 1.42m,
                ExtraDamage = 0.0m,
                ExtraDamageCount = 0,
                AttackType1 = AttackType.Blunt,
                AttackType2 = AttackType.None,
                AttackMode = AttackMode.Transformed,
                TricksterWeaponId = 9
            },
            
            new Attack {
                Id = 370,
                Name = "R1",
                Damage = 0.95m,
                ExtraDamage = 0.0m,
                ExtraDamageCount = 0,
                AttackType1 = AttackType.Thrust,
                AttackType2 = AttackType.None,
                AttackMode = AttackMode.Normal,
                TricksterWeaponId = 10
            },
            
            new Attack {
                Id = 371,
                Name = "R1 (2nd)",
                Damage = 0.98m,
                ExtraDamage = 0.0m,
                ExtraDamageCount = 0,
                AttackType1 = AttackType.Physical,
                AttackType2 = AttackType.None,
                AttackMode = AttackMode.Normal,
                TricksterWeaponId = 10
            },
            
            new Attack {
                Id = 372,
                Name = "R1 (3rd)",
                Damage = 1.02m,
                ExtraDamage = 0.0m,
                ExtraDamageCount = 0,
                AttackType1 = AttackType.Physical,
                AttackType2 = AttackType.None,
                AttackMode = AttackMode.Normal,
                TricksterWeaponId = 10
            },
            
            new Attack {
                Id = 373,
                Name = "R1 (4th)",
                Damage = 1.06m,
                ExtraDamage = 0.0m,
                ExtraDamageCount = 0,
                AttackType1 = AttackType.Thrust,
                AttackType2 = AttackType.None,
                AttackMode = AttackMode.Normal,
                TricksterWeaponId = 10
            },
            
            new Attack {
                Id = 374,
                Name = "R1 (backstep)",
                Damage = 0.95m,
                ExtraDamage = 0.0m,
                ExtraDamageCount = 0,
                AttackType1 = AttackType.Physical,
                AttackType2 = AttackType.None,
                AttackMode = AttackMode.Normal,
                TricksterWeaponId = 10
            },
            
            new Attack {
                Id = 375,
                Name = "R1 (rolling)",
                Damage = 0.95m,
                ExtraDamage = 0.0m,
                ExtraDamageCount = 0,
                AttackType1 = AttackType.Thrust,
                AttackType2 = AttackType.None,
                AttackMode = AttackMode.Normal,
                TricksterWeaponId = 10
            },
            
            new Attack {
                Id = 376,
                Name = "R1 (frontstep)",
                Damage = 0.95m,
                ExtraDamage = 0.0m,
                ExtraDamageCount = 0,
                AttackType1 = AttackType.Thrust,
                AttackType2 = AttackType.None,
                AttackMode = AttackMode.Normal,
                TricksterWeaponId = 10
            },
            
            new Attack {
                Id = 377,
                Name = "R1 (sidestep)",
                Damage = 0.95m,
                ExtraDamage = 0.0m,
                ExtraDamageCount = 0,
                AttackType1 = AttackType.Thrust,
                AttackType2 = AttackType.None,
                AttackMode = AttackMode.Normal,
                TricksterWeaponId = 10
            },
            
            new Attack {
                Id = 378,
                Name = "R1 (dash)",
                Damage = 1.05m,
                ExtraDamage = 0.0m,
                ExtraDamageCount = 0,
                AttackType1 = AttackType.Physical,
                AttackType2 = AttackType.None,
                AttackMode = AttackMode.Normal,
                TricksterWeaponId = 10
            },
            
            new Attack {
                Id = 379,
                Name = "R2",
                Damage = 1.3m,
                ExtraDamage = 0.0m,
                ExtraDamageCount = 0,
                AttackType1 = AttackType.Thrust,
                AttackType2 = AttackType.None,
                AttackMode = AttackMode.Normal,
                TricksterWeaponId = 10
            },
            
            new Attack {
                Id = 380,
                Name = "R2 (charged)",
                Damage = 1.7m,
                ExtraDamage = 0.0m,
                ExtraDamageCount = 0,
                AttackType1 = AttackType.Physical,
                AttackType2 = AttackType.None,
                AttackMode = AttackMode.Normal,
                TricksterWeaponId = 10
            },
            
            new Attack {
                Id = 381,
                Name = "R2 (backstep)",
                Damage = 1.25m,
                ExtraDamage = 0.0m,
                ExtraDamageCount = 0,
                AttackType1 = AttackType.Physical,
                AttackType2 = AttackType.None,
                AttackMode = AttackMode.Normal,
                TricksterWeaponId = 10
            },
            
            new Attack {
                Id = 382,
                Name = "R2 (dash)",
                Damage = 1.4m,
                ExtraDamage = 0.0m,
                ExtraDamageCount = 0,
                AttackType1 = AttackType.Physical,
                AttackType2 = AttackType.None,
                AttackMode = AttackMode.Normal,
                TricksterWeaponId = 10
            },
            
            new Attack {
                Id = 383,
                Name = "R2 (forward leap)",
                Damage = 1.45m,
                ExtraDamage = 0.0m,
                ExtraDamageCount = 0,
                AttackType1 = AttackType.Physical,
                AttackType2 = AttackType.None,
                AttackMode = AttackMode.Normal,
                TricksterWeaponId = 10
            },
            
            new Attack {
                Id = 384,
                Name = "Transform Attack",
                Damage = 1.2m,
                ExtraDamage = 0.0m,
                ExtraDamageCount = 0,
                AttackType1 = AttackType.Thrust,
                AttackType2 = AttackType.None,
                AttackMode = AttackMode.Normal,
                TricksterWeaponId = 10
            },
            
            new Attack {
                Id = 385,
                Name = "Plunge Attack",
                Damage = 1.45m,
                ExtraDamage = 0.0m,
                ExtraDamageCount = 0,
                AttackType1 = AttackType.Physical,
                AttackType2 = AttackType.None,
                AttackMode = AttackMode.Normal,
                TricksterWeaponId = 10
            },
            
            new Attack {
                Id = 386,
                Name = "Plunge Attack (2nd)",
                Damage = 0.9m,
                ExtraDamage = 0.0m,
                ExtraDamageCount = 0,
                AttackType1 = AttackType.Blunt,
                AttackType2 = AttackType.None,
                AttackMode = AttackMode.Normal,
                TricksterWeaponId = 10
            },
            
            new Attack {
                Id = 387,
                Name = "R1",
                Damage = 1.05m,
                ExtraDamage = 0.0m,
                ExtraDamageCount = 0,
                AttackType1 = AttackType.Thrust,
                AttackType2 = AttackType.None,
                AttackMode = AttackMode.Transformed,
                TricksterWeaponId = 10
            },
            
            new Attack {
                Id = 388,
                Name = "R1 (2nd)",
                Damage = 1.0m,
                ExtraDamage = 0.0m,
                ExtraDamageCount = 0,
                AttackType1 = AttackType.Thrust,
                AttackType2 = AttackType.None,
                AttackMode = AttackMode.Transformed,
                TricksterWeaponId = 10
            },
            
            new Attack {
                Id = 389,
                Name = "R1 (3rd)",
                Damage = 1.0m,
                ExtraDamage = 0.0m,
                ExtraDamageCount = 0,
                AttackType1 = AttackType.Thrust,
                AttackType2 = AttackType.None,
                AttackMode = AttackMode.Transformed,
                TricksterWeaponId = 10
            },
            
            new Attack {
                Id = 390,
                Name = "R1 (4th)",
                Damage = 1.2m,
                ExtraDamage = 0.0m,
                ExtraDamageCount = 0,
                AttackType1 = AttackType.Thrust,
                AttackType2 = AttackType.None,
                AttackMode = AttackMode.Transformed,
                TricksterWeaponId = 10
            },
            
            new Attack {
                Id = 391,
                Name = "R1 (backstep)",
                Damage = 0.95m,
                ExtraDamage = 0.0m,
                ExtraDamageCount = 0,
                AttackType1 = AttackType.Thrust,
                AttackType2 = AttackType.None,
                AttackMode = AttackMode.Transformed,
                TricksterWeaponId = 10
            },
            
            new Attack {
                Id = 392,
                Name = "R1 (rolling)",
                Damage = 1.0m,
                ExtraDamage = 0.0m,
                ExtraDamageCount = 0,
                AttackType1 = AttackType.Thrust,
                AttackType2 = AttackType.None,
                AttackMode = AttackMode.Transformed,
                TricksterWeaponId = 10
            },
            
            new Attack {
                Id = 393,
                Name = "R1 (frontstep)",
                Damage = 1.0m,
                ExtraDamage = 0.0m,
                ExtraDamageCount = 0,
                AttackType1 = AttackType.Thrust,
                AttackType2 = AttackType.None,
                AttackMode = AttackMode.Transformed,
                TricksterWeaponId = 10
            },
            
            new Attack {
                Id = 394,
                Name = "R1 (sidestep)",
                Damage = 1.0m,
                ExtraDamage = 0.0m,
                ExtraDamageCount = 0,
                AttackType1 = AttackType.Thrust,
                AttackType2 = AttackType.None,
                AttackMode = AttackMode.Transformed,
                TricksterWeaponId = 10
            },
            
            new Attack {
                Id = 395,
                Name = "R1 (dash)",
                Damage = 1.0m,
                ExtraDamage = 0.0m,
                ExtraDamageCount = 0,
                AttackType1 = AttackType.Thrust,
                AttackType2 = AttackType.None,
                AttackMode = AttackMode.Transformed,
                TricksterWeaponId = 10
            },
            
            new Attack {
                Id = 396,
                Name = "R2",
                Damage = 1.4m,
                ExtraDamage = 0.0m,
                ExtraDamageCount = 0,
                AttackType1 = AttackType.Thrust,
                AttackType2 = AttackType.None,
                AttackMode = AttackMode.Transformed,
                TricksterWeaponId = 10
            },
            
            new Attack {
                Id = 397,
                Name = "R2 (charged)",
                Damage = 1.9m,
                ExtraDamage = 0.0m,
                ExtraDamageCount = 0,
                AttackType1 = AttackType.Thrust,
                AttackType2 = AttackType.None,
                AttackMode = AttackMode.Transformed,
                TricksterWeaponId = 10
            },
            
            new Attack {
                Id = 398,
                Name = "R2 (charged follow-up)",
                Damage = 2.1m,
                ExtraDamage = 0.0m,
                ExtraDamageCount = 0,
                AttackType1 = AttackType.Thrust,
                AttackType2 = AttackType.None,
                AttackMode = AttackMode.Transformed,
                TricksterWeaponId = 10
            },
            
            new Attack {
                Id = 399,
                Name = "R2 (backstep)",
                Damage = 1.3m,
                ExtraDamage = 0.0m,
                ExtraDamageCount = 0,
                AttackType1 = AttackType.Thrust,
                AttackType2 = AttackType.None,
                AttackMode = AttackMode.Transformed,
                TricksterWeaponId = 10
            },
            
            new Attack {
                Id = 400,
                Name = "R2 (dash)",
                Damage = 1.4m,
                ExtraDamage = 0.0m,
                ExtraDamageCount = 0,
                AttackType1 = AttackType.Thrust,
                AttackType2 = AttackType.None,
                AttackMode = AttackMode.Transformed,
                TricksterWeaponId = 10
            },
            
            new Attack {
                Id = 401,
                Name = "R2 (forward leap)",
                Damage = 1.5m,
                ExtraDamage = 0.0m,
                ExtraDamageCount = 0,
                AttackType1 = AttackType.Thrust,
                AttackType2 = AttackType.None,
                AttackMode = AttackMode.Transformed,
                TricksterWeaponId = 10
            },
            
            new Attack {
                Id = 402,
                Name = "L2",
                Damage = 0.5m,
                ExtraDamage = 0.0m,
                ExtraDamageCount = 0,
                AttackType1 = AttackType.Thrust,
                AttackType2 = AttackType.None,
                AttackMode = AttackMode.Transformed,
                TricksterWeaponId = 10
            },
            
            new Attack {
                Id = 403,
                Name = "Transform Attack",
                Damage = 1.35m,
                ExtraDamage = 0.0m,
                ExtraDamageCount = 0,
                AttackType1 = AttackType.Thrust,
                AttackType2 = AttackType.None,
                AttackMode = AttackMode.Transformed,
                TricksterWeaponId = 10
            },
            
            new Attack {
                Id = 404,
                Name = "Plunge Attack",
                Damage = 1.5m,
                ExtraDamage = 0.0m,
                ExtraDamageCount = 0,
                AttackType1 = AttackType.Thrust,
                AttackType2 = AttackType.None,
                AttackMode = AttackMode.Transformed,
                TricksterWeaponId = 10
            },
            
            new Attack {
                Id = 405,
                Name = "Plunge Attack (2nd)",
                Damage = 0.9m,
                ExtraDamage = 0.0m,
                ExtraDamageCount = 0,
                AttackType1 = AttackType.Blunt,
                AttackType2 = AttackType.None,
                AttackMode = AttackMode.Transformed,
                TricksterWeaponId = 10
            },
            
            new Attack {
                Id = 406,
                Name = "R1",
                Damage = 1.0m,
                ExtraDamage = 0.5m,
                ExtraDamageCount = 1,
                AttackType1 = AttackType.Blunt,
                AttackType2 = AttackType.Arcane,
                AttackMode = AttackMode.Normal,
                TricksterWeaponId = 11
            },
            
            new Attack {
                Id = 407,
                Name = "R1 (2nd)",
                Damage = 1.02m,
                ExtraDamage = 0.51m,
                ExtraDamageCount = 1,
                AttackType1 = AttackType.Blunt,
                AttackType2 = AttackType.Arcane,
                AttackMode = AttackMode.Normal,
                TricksterWeaponId = 11
            },
            
            new Attack {
                Id = 408,
                Name = "R1 (3rd)",
                Damage = 1.06m,
                ExtraDamage = 0.53m,
                ExtraDamageCount = 1,
                AttackType1 = AttackType.Blunt,
                AttackType2 = AttackType.Arcane,
                AttackMode = AttackMode.Normal,
                TricksterWeaponId = 11
            },
            
            new Attack {
                Id = 409,
                Name = "R1 (4th)",
                Damage = 1.06m,
                ExtraDamage = 0.53m,
                ExtraDamageCount = 1,
                AttackType1 = AttackType.Blunt,
                AttackType2 = AttackType.Arcane,
                AttackMode = AttackMode.Normal,
                TricksterWeaponId = 11
            },
            
            new Attack {
                Id = 410,
                Name = "R1 (backstep)",
                Damage = 0.9m,
                ExtraDamage = 0.45m,
                ExtraDamageCount = 1,
                AttackType1 = AttackType.Blunt,
                AttackType2 = AttackType.Arcane,
                AttackMode = AttackMode.Normal,
                TricksterWeaponId = 11
            },
            
            new Attack {
                Id = 411,
                Name = "R1 (rolling)",
                Damage = 0.9m,
                ExtraDamage = 0.45m,
                ExtraDamageCount = 1,
                AttackType1 = AttackType.Blunt,
                AttackType2 = AttackType.Arcane,
                AttackMode = AttackMode.Normal,
                TricksterWeaponId = 11
            },
            
            new Attack {
                Id = 412,
                Name = "R1 (frontstep)",
                Damage = 0.9m,
                ExtraDamage = 0.45m,
                ExtraDamageCount = 1,
                AttackType1 = AttackType.Blunt,
                AttackType2 = AttackType.Arcane,
                AttackMode = AttackMode.Normal,
                TricksterWeaponId = 11
            },
            
            new Attack {
                Id = 413,
                Name = "R1 (sidestep)",
                Damage = 0.9m,
                ExtraDamage = 0.45m,
                ExtraDamageCount = 1,
                AttackType1 = AttackType.Blunt,
                AttackType2 = AttackType.Arcane,
                AttackMode = AttackMode.Normal,
                TricksterWeaponId = 11
            },
            
            new Attack {
                Id = 414,
                Name = "R1 (dash)",
                Damage = 1.1m,
                ExtraDamage = 0.55m,
                ExtraDamageCount = 1,
                AttackType1 = AttackType.Blunt,
                AttackType2 = AttackType.Arcane,
                AttackMode = AttackMode.Normal,
                TricksterWeaponId = 11
            },
            
            new Attack {
                Id = 415,
                Name = "R2",
                Damage = 1.3m,
                ExtraDamage = 0.65m,
                ExtraDamageCount = 1,
                AttackType1 = AttackType.Thrust,
                AttackType2 = AttackType.Arcane,
                AttackMode = AttackMode.Normal,
                TricksterWeaponId = 11
            },
            
            new Attack {
                Id = 416,
                Name = "R2 (charged)",
                Damage = 1.8m,
                ExtraDamage = 0.9m,
                ExtraDamageCount = 1,
                AttackType1 = AttackType.Thrust,
                AttackType2 = AttackType.Arcane,
                AttackMode = AttackMode.Normal,
                TricksterWeaponId = 11
            },
            
            new Attack {
                Id = 417,
                Name = "R2 (charged follow-up)",
                Damage = 2.0m,
                ExtraDamage = 1.0m,
                ExtraDamageCount = 1,
                AttackType1 = AttackType.Blunt,
                AttackType2 = AttackType.Arcane,
                AttackMode = AttackMode.Normal,
                TricksterWeaponId = 11
            },
            
            new Attack {
                Id = 418,
                Name = "R2 (backstep)",
                Damage = 1.2m,
                ExtraDamage = 0.6m,
                ExtraDamageCount = 1,
                AttackType1 = AttackType.Blunt,
                AttackType2 = AttackType.Arcane,
                AttackMode = AttackMode.Normal,
                TricksterWeaponId = 11
            },
            
            new Attack {
                Id = 419,
                Name = "R2 (dash)",
                Damage = 1.4m,
                ExtraDamage = 0.7m,
                ExtraDamageCount = 1,
                AttackType1 = AttackType.Thrust,
                AttackType2 = AttackType.Arcane,
                AttackMode = AttackMode.Normal,
                TricksterWeaponId = 11
            },
            
            new Attack {
                Id = 420,
                Name = "R2 (forward leap)",
                Damage = 1.3m,
                ExtraDamage = 0.65m,
                ExtraDamageCount = 1,
                AttackType1 = AttackType.Blunt,
                AttackType2 = AttackType.Arcane,
                AttackMode = AttackMode.Normal,
                TricksterWeaponId = 11
            },
            
            new Attack {
                Id = 421,
                Name = "Transform Attack",
                Damage = 1.2m,
                ExtraDamage = 1.0m,
                ExtraDamageCount = 1,
                AttackType1 = AttackType.Blunt,
                AttackType2 = AttackType.Arcane,
                AttackMode = AttackMode.Normal,
                TricksterWeaponId = 11
            },
            
            new Attack {
                Id = 422,
                Name = "Plunge Attack",
                Damage = 1.3m,
                ExtraDamage = 0.65m,
                ExtraDamageCount = 1,
                AttackType1 = AttackType.Blunt,
                AttackType2 = AttackType.Arcane,
                AttackMode = AttackMode.Normal,
                TricksterWeaponId = 11
            },
            
            new Attack {
                Id = 423,
                Name = "Plunge Attack (2nd)",
                Damage = 0.8m,
                ExtraDamage = 0.0m,
                ExtraDamageCount = 1,
                AttackType1 = AttackType.Blunt,
                AttackType2 = AttackType.None,
                AttackMode = AttackMode.Normal,
                TricksterWeaponId = 11
            },
            
            new Attack {
                Id = 424,
                Name = "R1",
                Damage = 1.0m,
                ExtraDamage = 0.7m,
                ExtraDamageCount = 1,
                AttackType1 = AttackType.Blunt,
                AttackType2 = AttackType.Arcane,
                AttackMode = AttackMode.Transformed,
                TricksterWeaponId = 11
            },
            
            new Attack {
                Id = 425,
                Name = "R1 (2nd)",
                Damage = 1.02m,
                ExtraDamage = 0.72m,
                ExtraDamageCount = 1,
                AttackType1 = AttackType.Blunt,
                AttackType2 = AttackType.Arcane,
                AttackMode = AttackMode.Transformed,
                TricksterWeaponId = 11
            },
            
            new Attack {
                Id = 426,
                Name = "R1 (3rd)",
                Damage = 1.06m,
                ExtraDamage = 0.75m,
                ExtraDamageCount = 1,
                AttackType1 = AttackType.Blunt,
                AttackType2 = AttackType.Arcane,
                AttackMode = AttackMode.Transformed,
                TricksterWeaponId = 11
            },
            
            new Attack {
                Id = 427,
                Name = "R1 (4th)",
                Damage = 1.06m,
                ExtraDamage = 0.75m,
                ExtraDamageCount = 1,
                AttackType1 = AttackType.Blunt,
                AttackType2 = AttackType.Arcane,
                AttackMode = AttackMode.Transformed,
                TricksterWeaponId = 11
            },
            
            new Attack {
                Id = 428,
                Name = "R1 (backstep)",
                Damage = 0.9m,
                ExtraDamage = 0.63m,
                ExtraDamageCount = 1,
                AttackType1 = AttackType.Blunt,
                AttackType2 = AttackType.Arcane,
                AttackMode = AttackMode.Transformed,
                TricksterWeaponId = 11
            },
            
            new Attack {
                Id = 429,
                Name = "R1 (rolling)",
                Damage = 0.9m,
                ExtraDamage = 0.63m,
                ExtraDamageCount = 1,
                AttackType1 = AttackType.Blunt,
                AttackType2 = AttackType.Arcane,
                AttackMode = AttackMode.Transformed,
                TricksterWeaponId = 11
            },
            
            new Attack {
                Id = 430,
                Name = "R1 (frontstep)",
                Damage = 0.9m,
                ExtraDamage = 0.63m,
                ExtraDamageCount = 1,
                AttackType1 = AttackType.Blunt,
                AttackType2 = AttackType.Arcane,
                AttackMode = AttackMode.Transformed,
                TricksterWeaponId = 11
            },
            
            new Attack {
                Id = 431,
                Name = "R1 (sidestep)",
                Damage = 0.9m,
                ExtraDamage = 0.63m,
                ExtraDamageCount = 1,
                AttackType1 = AttackType.Blunt,
                AttackType2 = AttackType.Arcane,
                AttackMode = AttackMode.Transformed,
                TricksterWeaponId = 11
            },
            
            new Attack {
                Id = 432,
                Name = "R1 (dash)",
                Damage = 1.1m,
                ExtraDamage = 0.77m,
                ExtraDamageCount = 1,
                AttackType1 = AttackType.Blunt,
                AttackType2 = AttackType.Arcane,
                AttackMode = AttackMode.Transformed,
                TricksterWeaponId = 11
            },
            
            new Attack {
                Id = 433,
                Name = "R2",
                Damage = 1.2m,
                ExtraDamage = 2.0m,
                ExtraDamageCount = 1,
                AttackType1 = AttackType.Blunt,
                AttackType2 = AttackType.Arcane,
                AttackMode = AttackMode.Transformed,
                TricksterWeaponId = 11
            },
            
            new Attack {
                Id = 434,
                Name = "R2 (charged)",
                Damage = 1.4m,
                ExtraDamage = 2.8m,
                ExtraDamageCount = 1,
                AttackType1 = AttackType.Blunt,
                AttackType2 = AttackType.Arcane,
                AttackMode = AttackMode.Transformed,
                TricksterWeaponId = 11
            },
            
            new Attack {
                Id = 435,
                Name = "R2 (charged follow-up)",
                Damage = 1.4m,
                ExtraDamage = 2.8m,
                ExtraDamageCount = 1,
                AttackType1 = AttackType.Blunt,
                AttackType2 = AttackType.Arcane,
                AttackMode = AttackMode.Transformed,
                TricksterWeaponId = 11
            },
            
            new Attack {
                Id = 436,
                Name = "R2 (backstep)",
                Damage = 1.2m,
                ExtraDamage = 1.8m,
                ExtraDamageCount = 1,
                AttackType1 = AttackType.Blunt,
                AttackType2 = AttackType.Arcane,
                AttackMode = AttackMode.Transformed,
                TricksterWeaponId = 11
            },
            
            new Attack {
                Id = 437,
                Name = "R2 (dash)",
                Damage = 1.2m,
                ExtraDamage = 2.2m,
                ExtraDamageCount = 1,
                AttackType1 = AttackType.Blunt,
                AttackType2 = AttackType.Arcane,
                AttackMode = AttackMode.Transformed,
                TricksterWeaponId = 11
            },
            
            new Attack {
                Id = 438,
                Name = "R2 (forward leap)",
                Damage = 1.3m,
                ExtraDamage = 2.4m,
                ExtraDamageCount = 1,
                AttackType1 = AttackType.Blunt,
                AttackType2 = AttackType.Arcane,
                AttackMode = AttackMode.Transformed,
                TricksterWeaponId = 11
            },
            
            new Attack {
                Id = 439,
                Name = "L2",
                Damage = 1.5m,
                ExtraDamage = 1.5m,
                ExtraDamageCount = 1,
                AttackType1 = AttackType.Thrust,
                AttackType2 = AttackType.Arcane,
                AttackMode = AttackMode.Transformed,
                TricksterWeaponId = 11
            },
            
            new Attack {
                Id = 440,
                Name = "Transform Attack",
                Damage = 1.3m,
                ExtraDamage = 1.3m,
                ExtraDamageCount = 1,
                AttackType1 = AttackType.Blunt,
                AttackType2 = AttackType.Arcane,
                AttackMode = AttackMode.Transformed,
                TricksterWeaponId = 11
            },
            
            new Attack {
                Id = 441,
                Name = "Plunge Attack",
                Damage = 1.3m,
                ExtraDamage = 0.91m,
                ExtraDamageCount = 1,
                AttackType1 = AttackType.Blunt,
                AttackType2 = AttackType.Arcane,
                AttackMode = AttackMode.Transformed,
                TricksterWeaponId = 11
            },
            
            new Attack {
                Id = 442,
                Name = "Plunge Attack (2nd)",
                Damage = 0.8m,
                ExtraDamage = 0.0m,
                ExtraDamageCount = 0,
                AttackType1 = AttackType.Blunt,
                AttackType2 = AttackType.None,
                AttackMode = AttackMode.Transformed,
                TricksterWeaponId = 11
            },
            
            new Attack {
                Id = 443,
                Name = "R2 no bullet",
                Damage = 1.2m,
                ExtraDamage = 0.84m,
                ExtraDamageCount = 1,
                AttackType1 = AttackType.Blunt,
                AttackType2 = AttackType.Arcane,
                AttackMode = AttackMode.Transformed,
                TricksterWeaponId = 11
            },
            
            new Attack {
                Id = 444,
                Name = "R2 (charged) no bullet",
                Damage = 1.4m,
                ExtraDamage = 0.98m,
                ExtraDamageCount = 1,
                AttackType1 = AttackType.Blunt,
                AttackType2 = AttackType.Arcane,
                AttackMode = AttackMode.Transformed,
                TricksterWeaponId = 11
            },
            
            new Attack {
                Id = 445,
                Name = "R2 (charged follow-up) no bullet",
                Damage = 1.4m,
                ExtraDamage = 0.98m,
                ExtraDamageCount = 1,
                AttackType1 = AttackType.Blunt,
                AttackType2 = AttackType.Arcane,
                AttackMode = AttackMode.Transformed,
                TricksterWeaponId = 11
            },
            
            new Attack {
                Id = 446,
                Name = "R2 (backstep) no bullet",
                Damage = 1.2m,
                ExtraDamage = 0.84m,
                ExtraDamageCount = 1,
                AttackType1 = AttackType.Blunt,
                AttackType2 = AttackType.Arcane,
                AttackMode = AttackMode.Transformed,
                TricksterWeaponId = 11
            },
            
            new Attack {
                Id = 447,
                Name = "R2 (dash) no bullet",
                Damage = 1.2m,
                ExtraDamage = 0.84m,
                ExtraDamageCount = 1,
                AttackType1 = AttackType.Blunt,
                AttackType2 = AttackType.Arcane,
                AttackMode = AttackMode.Transformed,
                TricksterWeaponId = 11
            },
            
            new Attack {
                Id = 448,
                Name = "R2 (forward leap) no bullet",
                Damage = 1.3m,
                ExtraDamage = 0.91m,
                ExtraDamageCount = 1,
                AttackType1 = AttackType.Blunt,
                AttackType2 = AttackType.Arcane,
                AttackMode = AttackMode.Transformed,
                TricksterWeaponId = 11
            },
            
            new Attack {
                Id = 449,
                Name = "L2 no bullet",
                Damage = 1.5m,
                ExtraDamage = 1.05m,
                ExtraDamageCount = 1,
                AttackType1 = AttackType.Thrust,
                AttackType2 = AttackType.Arcane,
                AttackMode = AttackMode.Transformed,
                TricksterWeaponId = 11
            },
            
            new Attack {
                Id = 450,
                Name = "R1",
                Damage = 1.0m,
                ExtraDamage = 0.0m,
                ExtraDamageCount = 0,
                AttackType1 = AttackType.Physical,
                AttackType2 = AttackType.None,
                AttackMode = AttackMode.Normal,
                TricksterWeaponId = 12
            },
            
            new Attack {
                Id = 451,
                Name = "R1 (2nd)",
                Damage = 1.0m,
                ExtraDamage = 0.0m,
                ExtraDamageCount = 0,
                AttackType1 = AttackType.Physical,
                AttackType2 = AttackType.None,
                AttackMode = AttackMode.Normal,
                TricksterWeaponId = 12
            },
            
            new Attack {
                Id = 452,
                Name = "R1 (3rd)",
                Damage = 1.1m,
                ExtraDamage = 0.0m,
                ExtraDamageCount = 0,
                AttackType1 = AttackType.Physical,
                AttackType2 = AttackType.None,
                AttackMode = AttackMode.Normal,
                TricksterWeaponId = 12
            },

            new Attack {
                Id = 453,
                Name = "R1 (4th)",
                Damage = 1.2m,
                ExtraDamage = 0.0m,
                ExtraDamageCount = 0,
                AttackType1 = AttackType.Blunt,
                AttackType2 = AttackType.None,
                AttackMode = AttackMode.Normal,
                TricksterWeaponId = 12
            },
            
            new Attack {
                Id = 454,
                Name = "R1 (backstep)",
                Damage = 0.95m,
                ExtraDamage = 0.0m,
                ExtraDamageCount = 0,
                AttackType1 = AttackType.Physical,
                AttackType2 = AttackType.None,
                AttackMode = AttackMode.Normal,
                TricksterWeaponId = 12
            },
            
            new Attack {
                Id = 455,
                Name = "R1 (rolling)",
                Damage = 0.95m,
                ExtraDamage = 0.0m,
                ExtraDamageCount = 0,
                AttackType1 = AttackType.Physical,
                AttackType2 = AttackType.None,
                AttackMode = AttackMode.Normal,
                TricksterWeaponId = 12
            },
            
            new Attack {
                Id = 456,
                Name = "R1 (frontstep)",
                Damage = 0.95m,
                ExtraDamage = 0.0m,
                ExtraDamageCount = 0,
                AttackType1 = AttackType.Physical,
                AttackType2 = AttackType.None,
                AttackMode = AttackMode.Normal,
                TricksterWeaponId = 12
            },
            
            new Attack {
                Id = 457,
                Name = "R1 (sidestep)",
                Damage = 0.95m,
                ExtraDamage = 0.0m,
                ExtraDamageCount = 0,
                AttackType1 = AttackType.Physical,
                AttackType2 = AttackType.None,
                AttackMode = AttackMode.Normal,
                TricksterWeaponId = 12
            },
            
            new Attack {
                Id = 458,
                Name = "R1 (dash)",
                Damage = 1.1m,
                ExtraDamage = 0.0m,
                ExtraDamageCount = 0,
                AttackType1 = AttackType.Physical,
                AttackType2 = AttackType.None,
                AttackMode = AttackMode.Normal,
                TricksterWeaponId = 12
            },
            
            new Attack {
                Id = 459,
                Name = "R2",
                Damage = 1.35m,
                ExtraDamage = 0.0m,
                ExtraDamageCount = 0,
                AttackType1 = AttackType.Blunt,
                AttackType2 = AttackType.None,
                AttackMode = AttackMode.Normal,
                TricksterWeaponId = 12
            },
            
            new Attack {
                Id = 460,
                Name = "R2 (charged)",
                Damage = 2.0m,
                ExtraDamage = 0.0m,
                ExtraDamageCount = 0,
                AttackType1 = AttackType.Blunt,
                AttackType2 = AttackType.None,
                AttackMode = AttackMode.Normal,
                TricksterWeaponId = 12
            },
            
            new Attack {
                Id = 461,
                Name = "R2 (backstep)",
                Damage = 1.3m,
                ExtraDamage = 0.0m,
                ExtraDamageCount = 0,
                AttackType1 = AttackType.Blunt,
                AttackType2 = AttackType.None,
                AttackMode = AttackMode.Normal,
                TricksterWeaponId = 12
            },
            
            new Attack {
                Id = 462,
                Name = "R2 (dash)",
                Damage = 1.45m,
                ExtraDamage = 0.0m,
                ExtraDamageCount = 0,
                AttackType1 = AttackType.Physical,
                AttackType2 = AttackType.None,
                AttackMode = AttackMode.Normal,
                TricksterWeaponId = 12
            },
            
            new Attack {
                Id = 463,
                Name = "R2 (forward leap)",
                Damage = 1.4m,
                ExtraDamage = 0.0m,
                ExtraDamageCount = 0,
                AttackType1 = AttackType.Blunt,
                AttackType2 = AttackType.None,
                AttackMode = AttackMode.Normal,
                TricksterWeaponId = 12
            },
            
            new Attack {
                Id = 464,
                Name = "Transform Attack",
                Damage = 1.1m,
                ExtraDamage = 0.0m,
                ExtraDamageCount = 0,
                AttackType1 = AttackType.Physical,
                AttackType2 = AttackType.None,
                AttackMode = AttackMode.Normal,
                TricksterWeaponId = 12
            },
            
            new Attack {
                Id = 465,
                Name = "Plunge Attack",
                Damage = 1.4m,
                ExtraDamage = 0.0m,
                ExtraDamageCount = 0,
                AttackType1 = AttackType.Blunt,
                AttackType2 = AttackType.None,
                AttackMode = AttackMode.Normal,
                TricksterWeaponId = 12
            },
            
            new Attack {
                Id = 466,
                Name = "Plunge Attack (2nd)",
                Damage = 0.9m,
                ExtraDamage = 0.0m,
                ExtraDamageCount = 0,
                AttackType1 = AttackType.Blunt,
                AttackType2 = AttackType.None,
                AttackMode = AttackMode.Normal,
                TricksterWeaponId = 12
            },
            
            new Attack {
                Id = 467,
                Name = "R1",
                Damage = 1.05m,
                ExtraDamage = 0.0m,
                ExtraDamageCount = 0,
                AttackType1 = AttackType.Blunt,
                AttackType2 = AttackType.None,
                AttackMode = AttackMode.Transformed,
                TricksterWeaponId = 12
            },
            
            new Attack {
                Id = 468,
                Name = "R1 (2nd)",
                Damage = 1.15m,
                ExtraDamage = 0.0m,
                ExtraDamageCount = 0,
                AttackType1 = AttackType.Blunt,
                AttackType2 = AttackType.None,
                AttackMode = AttackMode.Transformed,
                TricksterWeaponId = 12
            },
            
            new Attack {
                Id = 469,
                Name = "R1 (3rd)",
                Damage = 1.05m,
                ExtraDamage = 0.0m,
                ExtraDamageCount = 0,
                AttackType1 = AttackType.Physical,
                AttackType2 = AttackType.None,
                AttackMode = AttackMode.Transformed,
                TricksterWeaponId = 12
            },
            
            new Attack {
                Id = 470,
                Name = "R1 (4th)",
                Damage = 1.15m,
                ExtraDamage = 0.0m,
                ExtraDamageCount = 0,
                AttackType1 = AttackType.Blunt,
                AttackType2 = AttackType.None,
                AttackMode = AttackMode.Transformed,
                TricksterWeaponId = 12
            },
            
            new Attack {
                Id = 471,
                Name = "R1 (5th)",
                Damage = 1.2m,
                ExtraDamage = 0.0m,
                ExtraDamageCount = 0,
                AttackType1 = AttackType.Blunt,
                AttackType2 = AttackType.None,
                AttackMode = AttackMode.Transformed,
                TricksterWeaponId = 12
            },
            
            new Attack {
                Id = 472,
                Name = "R1 (backstep)",
                Damage = 1.0m,
                ExtraDamage = 0.0m,
                ExtraDamageCount = 0,
                AttackType1 = AttackType.Physical,
                AttackType2 = AttackType.None,
                AttackMode = AttackMode.Transformed,
                TricksterWeaponId = 12
            },
            
            new Attack {
                Id = 473,
                Name = "R1 (rolling)",
                Damage = 0.65m,
                ExtraDamage = 0.0m,
                ExtraDamageCount = 0,
                AttackType1 = AttackType.Physical,
                AttackType2 = AttackType.None,
                AttackMode = AttackMode.Transformed,
                TricksterWeaponId = 12
            },
            
            new Attack {
                Id = 474,
                Name = "R1 (frontstep)",
                Damage = 0.65m,
                ExtraDamage = 0.0m,
                ExtraDamageCount = 0,
                AttackType1 = AttackType.Physical,
                AttackType2 = AttackType.None,
                AttackMode = AttackMode.Transformed,
                TricksterWeaponId = 12
            },
            
            new Attack {
                Id = 475,
                Name = "R1 (sidestep)",
                Damage = 0.95m,
                ExtraDamage = 0.0m,
                ExtraDamageCount = 0,
                AttackType1 = AttackType.Physical,
                AttackType2 = AttackType.None,
                AttackMode = AttackMode.Transformed,
                TricksterWeaponId = 12
            },
            
            new Attack {
                Id = 476,
                Name = "R1 (dash)",
                Damage = 1.15m,
                ExtraDamage = 0.0m,
                ExtraDamageCount = 0,
                AttackType1 = AttackType.Physical,
                AttackType2 = AttackType.None,
                AttackMode = AttackMode.Transformed,
                TricksterWeaponId = 12
            },
            
            new Attack {
                Id = 477,
                Name = "R2",
                Damage = 1.37m,
                ExtraDamage = 0.0m,
                ExtraDamageCount = 0,
                AttackType1 = AttackType.Blunt,
                AttackType2 = AttackType.None,
                AttackMode = AttackMode.Transformed,
                TricksterWeaponId = 12
            },
            
            new Attack {
                Id = 478,
                Name = "R2 (charged)",
                Damage = 1.5m,
                ExtraDamage = 1.3m,
                ExtraDamageCount = 1,
                AttackType1 = AttackType.Blunt,
                AttackType2 = AttackType.None,
                AttackMode = AttackMode.Transformed,
                TricksterWeaponId = 12
            },
            
            new Attack {
                Id = 479,
                Name = "R2 (backstep)",
                Damage = 1.1m,
                ExtraDamage = 0.0m,
                ExtraDamageCount = 0,
                AttackType1 = AttackType.Blunt,
                AttackType2 = AttackType.None,
                AttackMode = AttackMode.Transformed,
                TricksterWeaponId = 12
            },
            
            new Attack {
                Id = 480,
                Name = "R2 (dash)",
                Damage = 1.5m,
                ExtraDamage = 0.0m,
                ExtraDamageCount = 0,
                AttackType1 = AttackType.Blunt,
                AttackType2 = AttackType.None,
                AttackMode = AttackMode.Transformed,
                TricksterWeaponId = 12
            },
            
            new Attack {
                Id = 481,
                Name = "R2(forward leap)",
                Damage = 1.45m,
                ExtraDamage = 0.0m,
                ExtraDamageCount = 0,
                AttackType1 = AttackType.Blunt,
                AttackType2 = AttackType.None,
                AttackMode = AttackMode.Transformed,
                TricksterWeaponId = 12
            },
            
            new Attack {
                Id = 482,
                Name = "L2",
                Damage = 1.25m,
                ExtraDamage = 0.0m,
                ExtraDamageCount = 0,
                AttackType1 = AttackType.Blunt,
                AttackType2 = AttackType.None,
                AttackMode = AttackMode.Transformed,
                TricksterWeaponId = 12
            },
            
            new Attack {
                Id = 483,
                Name = "L2 (2nd)",
                Damage = 1.25m,
                ExtraDamage = 0.0m,
                ExtraDamageCount = 0,
                AttackType1 = AttackType.Blunt,
                AttackType2 = AttackType.None,
                AttackMode = AttackMode.Transformed,
                TricksterWeaponId = 12
            },
            
            new Attack {
                Id = 484,
                Name = "L2 (3rd)",
                Damage = 1.35m,
                ExtraDamage = 0.0m,
                ExtraDamageCount = 0,
                AttackType1 = AttackType.Blunt,
                AttackType2 = AttackType.None,
                AttackMode = AttackMode.Transformed,
                TricksterWeaponId = 12
            },
            
            new Attack {
                Id = 485,
                Name = "Transform Attack",
                Damage = 1.2m,
                ExtraDamage = 0.0m,
                ExtraDamageCount = 0,
                AttackType1 = AttackType.Blunt,
                AttackType2 = AttackType.None,
                AttackMode = AttackMode.Transformed,
                TricksterWeaponId = 12
            },
            
            new Attack {
                Id = 486,
                Name = "Plunge Attack",
                Damage = 1.4m,
                ExtraDamage = 0.0m,
                ExtraDamageCount = 0,
                AttackType1 = AttackType.Blunt,
                AttackType2 = AttackType.None,
                AttackMode = AttackMode.Transformed,
                TricksterWeaponId = 12
            },
            
            new Attack {
                Id = 487,
                Name = "Plunge Attack (2nd)",
                Damage = 0.9m,
                ExtraDamage = 0.0m,
                ExtraDamageCount = 0,
                AttackType1 = AttackType.Blunt,
                AttackType2 = AttackType.None,
                AttackMode = AttackMode.Transformed,
                TricksterWeaponId = 12
            },
            
            new Attack {
                Id = 488,
                Name = "R1",
                Damage = 0.7m,
                ExtraDamage = 0.0m,
                ExtraDamageCount = 0,
                AttackType1 = AttackType.Physical,
                AttackType2 = AttackType.None,
                AttackMode = AttackMode.Normal,
                TricksterWeaponId = 13
            },
            
            new Attack {
                Id = 489,
                Name = "R1 (2nd)",
                Damage = 0.71m,
                ExtraDamage = 0.0m,
                ExtraDamageCount = 0,
                AttackType1 = AttackType.Physical,
                AttackType2 = AttackType.None,
                AttackMode = AttackMode.Normal,
                TricksterWeaponId = 13
            },
            
            new Attack {
                Id = 490,
                Name = "R1 (3rd)",
                Damage = 0.72m,
                ExtraDamage = 0.0m,
                ExtraDamageCount = 0,
                AttackType1 = AttackType.Physical,
                AttackType2 = AttackType.None,
                AttackMode = AttackMode.Normal,
                TricksterWeaponId = 13
            },
            
            new Attack {
                Id = 491,
                Name = "R1 (4th)",
                Damage = 0.74m,
                ExtraDamage = 0.0m,
                ExtraDamageCount = 0,
                AttackType1 = AttackType.Thrust,
                AttackType2 = AttackType.None,
                AttackMode = AttackMode.Normal,
                TricksterWeaponId = 13
            },
            
            new Attack {
                Id = 492,
                Name = "R1 (5th)",
                Damage = 0.76m,
                ExtraDamage = 0.0m,
                ExtraDamageCount = 0,
                AttackType1 = AttackType.Physical,
                AttackType2 = AttackType.None,
                AttackMode = AttackMode.Normal,
                TricksterWeaponId = 13
            },
            
            new Attack {
                Id = 493,
                Name = "R1 (backstep)",
                Damage = 0.67m,
                ExtraDamage = 0.0m,
                ExtraDamageCount = 0,
                AttackType1 = AttackType.Physical,
                AttackType2 = AttackType.None,
                AttackMode = AttackMode.Normal,
                TricksterWeaponId = 13
            },
            
            new Attack {
                Id = 494,
                Name = "R1 (rolling)",
                Damage = 0.67m,
                ExtraDamage = 0.0m,
                ExtraDamageCount = 0,
                AttackType1 = AttackType.Physical,
                AttackType2 = AttackType.None,
                AttackMode = AttackMode.Normal,
                TricksterWeaponId = 13
            },
            
            new Attack {
                Id = 495,
                Name = "R1 (frontstep)",
                Damage = 0.67m,
                ExtraDamage = 0.0m,
                ExtraDamageCount = 0,
                AttackType1 = AttackType.Physical,
                AttackType2 = AttackType.None,
                AttackMode = AttackMode.Normal,
                TricksterWeaponId = 13
            },
            
            new Attack {
                Id = 496,
                Name = "R1 (sidestep)",
                Damage = 0.67m,
                ExtraDamage = 0.0m,
                ExtraDamageCount = 0,
                AttackType1 = AttackType.Physical,
                AttackType2 = AttackType.None,
                AttackMode = AttackMode.Normal,
                TricksterWeaponId = 13
            },
            
            new Attack {
                Id = 497,
                Name = "R1 (dash)",
                Damage = 0.8m,
                ExtraDamage = 0.0m,
                ExtraDamageCount = 0,
                AttackType1 = AttackType.Physical,
                AttackType2 = AttackType.None,
                AttackMode = AttackMode.Normal,
                TricksterWeaponId = 13
            },
            
            new Attack {
                Id = 498,
                Name = "R2",
                Damage = 1.0m,
                ExtraDamage = 0.0m,
                ExtraDamageCount = 0,
                AttackType1 = AttackType.Thrust,
                AttackType2 = AttackType.None,
                AttackMode = AttackMode.Normal,
                TricksterWeaponId = 13
            },
            
            new Attack {
                Id = 499,
                Name = "R2 (charged)",
                Damage = 1.2m,
                ExtraDamage = 0.0m,
                ExtraDamageCount = 0,
                AttackType1 = AttackType.Thrust,
                AttackType2 = AttackType.None,
                AttackMode = AttackMode.Normal,
                TricksterWeaponId = 13
            },
            
            new Attack {
                Id = 500,
                Name = "R2 (backstep)",
                Damage = 0.85m,
                ExtraDamage = 0.0m,
                ExtraDamageCount = 0,
                AttackType1 = AttackType.Thrust,
                AttackType2 = AttackType.None,
                AttackMode = AttackMode.Normal,
                TricksterWeaponId = 13
            },
            
            new Attack {
                Id = 501,
                Name = "R2 (dash)",
                Damage = 0.95m,
                ExtraDamage = 0.0m,
                ExtraDamageCount = 0,
                AttackType1 = AttackType.Thrust,
                AttackType2 = AttackType.None,
                AttackMode = AttackMode.Normal,
                TricksterWeaponId = 13
            },
            
            new Attack {
                Id = 502,
                Name = "R2 (forward leap)",
                Damage = 1.2m,
                ExtraDamage = 0.0m,
                ExtraDamageCount = 0,
                AttackType1 = AttackType.Thrust,
                AttackType2 = AttackType.None,
                AttackMode = AttackMode.Normal,
                TricksterWeaponId = 13
            },
            
            new Attack {
                Id = 503,
                Name = "Transform Attack",
                Damage = 1.05m,
                ExtraDamage = 0.0m,
                ExtraDamageCount = 0,
                AttackType1 = AttackType.Blunt,
                AttackType2 = AttackType.None,
                AttackMode = AttackMode.Normal,
                TricksterWeaponId = 13
            },
            
            new Attack {
                Id = 504,
                Name = "Transform Attack to R1",
                Damage = 0.85m,
                ExtraDamage = 0.0m,
                ExtraDamageCount = 0,
                AttackType1 = AttackType.Physical,
                AttackType2 = AttackType.None,
                AttackMode = AttackMode.Normal,
                TricksterWeaponId = 13
            },
            
            new Attack {
                Id = 505,
                Name = "Plunge Attack",
                Damage = 1.25m,
                ExtraDamage = 0.0m,
                ExtraDamageCount = 0,
                AttackType1 = AttackType.Thrust,
                AttackType2 = AttackType.None,
                AttackMode = AttackMode.Normal,
                TricksterWeaponId = 13
            },
            
            new Attack {
                Id = 506,
                Name = "Plunge Attack (2nd)",
                Damage = 0.6m,
                ExtraDamage = 0.0m,
                ExtraDamageCount = 0,
                AttackType1 = AttackType.Blunt,
                AttackType2 = AttackType.None,
                AttackMode = AttackMode.Normal,
                TricksterWeaponId = 13
            },
            
            new Attack {
                Id = 507,
                Name = "R1",
                Damage = 1.0m,
                ExtraDamage = 0.0m,
                ExtraDamageCount = 0,
                AttackType1 = AttackType.Blunt,
                AttackType2 = AttackType.None,
                AttackMode = AttackMode.Transformed,
                TricksterWeaponId = 13
            },
            
            new Attack {
                Id = 508,
                Name = "R1 (2nd)",
                Damage = 1.0m,
                ExtraDamage = 0.0m,
                ExtraDamageCount = 0,
                AttackType1 = AttackType.Blunt,
                AttackType2 = AttackType.None,
                AttackMode = AttackMode.Transformed,
                TricksterWeaponId = 13
            },
            
            new Attack {
                Id = 509,
                Name = "R1 (3rd)",
                Damage = 1.0m,
                ExtraDamage = 0.0m,
                ExtraDamageCount = 0,
                AttackType1 = AttackType.Blunt,
                AttackType2 = AttackType.None,
                AttackMode = AttackMode.Transformed,
                TricksterWeaponId = 13
            },
            
            new Attack {
                Id = 510,
                Name = "R1 (4th)",
                Damage = 1.0m,
                ExtraDamage = 0.0m,
                ExtraDamageCount = 0,
                AttackType1 = AttackType.Blunt,
                AttackType2 = AttackType.None,
                AttackMode = AttackMode.Transformed,
                TricksterWeaponId = 13
            },
            
            new Attack {
                Id = 511,
                Name = "R1 (backstep)",
                Damage = 0.45m,
                ExtraDamage = 0.0m,
                ExtraDamageCount = 0,
                AttackType1 = AttackType.Blunt,
                AttackType2 = AttackType.None,
                AttackMode = AttackMode.Transformed,
                TricksterWeaponId = 13
            },
            
            new Attack {
                Id = 512,
                Name = "R1 (rolling)",
                Damage = 0.85m,
                ExtraDamage = 0.0m,
                ExtraDamageCount = 0,
                AttackType1 = AttackType.Blunt,
                AttackType2 = AttackType.None,
                AttackMode = AttackMode.Transformed,
                TricksterWeaponId = 13
            },
            
            new Attack {
                Id = 513,
                Name = "R1 (frontstep)",
                Damage = 0.85m,
                ExtraDamage = 0.0m,
                ExtraDamageCount = 0,
                AttackType1 = AttackType.Blunt,
                AttackType2 = AttackType.None,
                AttackMode = AttackMode.Transformed,
                TricksterWeaponId = 13
            },
            
            new Attack {
                Id = 514,
                Name = "R1 (sidestep)",
                Damage = 0.85m,
                ExtraDamage = 0.0m,
                ExtraDamageCount = 0,
                AttackType1 = AttackType.Blunt,
                AttackType2 = AttackType.None,
                AttackMode = AttackMode.Transformed,
                TricksterWeaponId = 13
            },
            
            new Attack {
                Id = 515,
                Name = "R1 (dash)",
                Damage = 0.55m,
                ExtraDamage = 0.0m,
                ExtraDamageCount = 0,
                AttackType1 = AttackType.Blunt,
                AttackType2 = AttackType.None,
                AttackMode = AttackMode.Transformed,
                TricksterWeaponId = 13
            },
            
            new Attack {
                Id = 516,
                Name = "R2",
                Damage = 1.25m,
                ExtraDamage = 0.0m,
                ExtraDamageCount = 0,
                AttackType1 = AttackType.Blunt,
                AttackType2 = AttackType.None,
                AttackMode = AttackMode.Transformed,
                TricksterWeaponId = 13
            },
            
            new Attack {
                Id = 517,
                Name = "R2 (charged)",
                Damage = 2.3m,
                ExtraDamage = 0.0m,
                ExtraDamageCount = 0,
                AttackType1 = AttackType.Blunt,
                AttackType2 = AttackType.None,
                AttackMode = AttackMode.Transformed,
                TricksterWeaponId = 13
            },
            
            new Attack {
                Id = 518,
                Name = "R2 (charged follow-up)",
                Damage = 1.4m,
                ExtraDamage = 0.0m,
                ExtraDamageCount = 0,
                AttackType1 = AttackType.Blunt,
                AttackType2 = AttackType.None,
                AttackMode = AttackMode.Transformed,
                TricksterWeaponId = 13
            },
            
            new Attack {
                Id = 519,
                Name = "R2 (backstep)",
                Damage = 1.0m,
                ExtraDamage = 0.0m,
                ExtraDamageCount = 0,
                AttackType1 = AttackType.Blunt,
                AttackType2 = AttackType.None,
                AttackMode = AttackMode.Transformed,
                TricksterWeaponId = 13
            },
            
            new Attack {
                Id = 520,
                Name = "R2 (dash)",
                Damage = 1.05m,
                ExtraDamage = 0.0m,
                ExtraDamageCount = 0,
                AttackType1 = AttackType.Blunt,
                AttackType2 = AttackType.None,
                AttackMode = AttackMode.Transformed,
                TricksterWeaponId = 13
            },
            
            new Attack {
                Id = 521,
                Name = "R2 (forward leap)",
                Damage = 1.2m,
                ExtraDamage = 0.0m,
                ExtraDamageCount = 0,
                AttackType1 = AttackType.Blunt,
                AttackType2 = AttackType.None,
                AttackMode = AttackMode.Transformed,
                TricksterWeaponId = 13
            },
            
            new Attack {
                Id = 522,
                Name = "L2",
                Damage = 1.15m,
                ExtraDamage = 0.0m,
                ExtraDamageCount = 0,
                AttackType1 = AttackType.Blunt,
                AttackType2 = AttackType.None,
                AttackMode = AttackMode.Transformed,
                TricksterWeaponId = 13
            },
            
            new Attack {
                Id = 523,
                Name = "L2 (2nd)",
                Damage = 1.05m,
                ExtraDamage = 0.0m,
                ExtraDamageCount = 0,
                AttackType1 = AttackType.Blunt,
                AttackType2 = AttackType.None,
                AttackMode = AttackMode.Transformed,
                TricksterWeaponId = 13
            },
            
            new Attack {
                Id = 524,
                Name = "L2 (3rd)",
                Damage = 1.45m,
                ExtraDamage = 0.0m,
                ExtraDamageCount = 0,
                AttackType1 = AttackType.Blunt,
                AttackType2 = AttackType.None,
                AttackMode = AttackMode.Transformed,
                TricksterWeaponId = 13
            },
            
            new Attack {
                Id = 525,
                Name = "Transform Attack",
                Damage = 1.05m,
                ExtraDamage = 0.0m,
                ExtraDamageCount = 0,
                AttackType1 = AttackType.Blunt,
                AttackType2 = AttackType.None,
                AttackMode = AttackMode.Transformed,
                TricksterWeaponId = 13
            },
            
            new Attack {
                Id = 526,
                Name = "Transform Attack to R1",
                Damage = 0.95m,
                ExtraDamage = 0.0m,
                ExtraDamageCount = 0,
                AttackType1 = AttackType.Blunt,
                AttackType2 = AttackType.None,
                AttackMode = AttackMode.Transformed,
                TricksterWeaponId = 13
            },
            
            new Attack {
                Id = 527,
                Name = "Plunge Attack",
                Damage = 1.55m,
                ExtraDamage = 0.0m,
                ExtraDamageCount = 0,
                AttackType1 = AttackType.Blunt,
                AttackType2 = AttackType.None,
                AttackMode = AttackMode.Transformed,
                TricksterWeaponId = 13
            },
            
            new Attack {
                Id = 528,
                Name = "Plunge Attack (2nd)",
                Damage = 0.45m,
                ExtraDamage = 0.0m,
                ExtraDamageCount = 0,
                AttackType1 = AttackType.Blunt,
                AttackType2 = AttackType.None,
                AttackMode = AttackMode.Transformed,
                TricksterWeaponId = 13
            },
            
            new Attack {
                Id = 529,
                Name = "R1 (Milkweed Rune)",
                Damage = 2.0m,
                ExtraDamage = 0.0m,
                ExtraDamageCount = 0,
                AttackType1 = AttackType.Arcane,
                AttackType2 = AttackType.None,
                AttackMode = AttackMode.Normal,
                TricksterWeaponId = 14
            },
            
            new Attack {
                Id = 530,
                Name = "R1 (2nd) (Milkweed Rune)",
                Damage = 2.1m,
                ExtraDamage = 0.0m,
                ExtraDamageCount = 0,
                AttackType1 = AttackType.Arcane,
                AttackType2 = AttackType.None,
                AttackMode = AttackMode.Normal,
                TricksterWeaponId = 14
            },
            
            new Attack {
                Id = 531,
                Name = "R1 (3rd) (Milkweed Rune)",
                Damage = 2.2m,
                ExtraDamage = 0.0m,
                ExtraDamageCount = 0,
                AttackType1 = AttackType.Arcane,
                AttackType2 = AttackType.None,
                AttackMode = AttackMode.Normal,
                TricksterWeaponId = 14
            },
            
            new Attack {
                Id = 532,
                Name = "R1 (backstep) (Milkweed Rune)",
                Damage = 1.5m,
                ExtraDamage = 0.0m,
                ExtraDamageCount = 0,
                AttackType1 = AttackType.Arcane,
                AttackType2 = AttackType.None,
                AttackMode = AttackMode.Normal,
                TricksterWeaponId = 14
            },
            
            new Attack {
                Id = 533,
                Name = "R1 (rolling) (Milkweed Rune)",
                Damage = 1.0m,
                ExtraDamage = 1.7m,
                ExtraDamageCount = 1,
                AttackType1 = AttackType.Arcane,
                AttackType2 = AttackType.None,
                AttackMode = AttackMode.Normal,
                TricksterWeaponId = 14
            },
            
            new Attack {
                Id = 534,
                Name = "R1 (frontstep) (Milkweed Rune)",
                Damage = 1.0m,
                ExtraDamage = 1.7m,
                ExtraDamageCount = 1,
                AttackType1 = AttackType.Arcane,
                AttackType2 = AttackType.None,
                AttackMode = AttackMode.Normal,
                TricksterWeaponId = 14
            },
            
            new Attack {
                Id = 535,
                Name = "R1 (sidestep) (Milkweed Rune)",
                Damage = 1.0m,
                ExtraDamage = 1.7m,
                ExtraDamageCount = 1,
                AttackType1 = AttackType.Arcane,
                AttackType2 = AttackType.None,
                AttackMode = AttackMode.Normal,
                TricksterWeaponId = 14
            },
            
            new Attack {
                Id = 536,
                Name = "R1 (dash) (Milkweed Rune)",
                Damage = 2.1m,
                ExtraDamage = 0.0m,
                ExtraDamageCount = 0,
                AttackType1 = AttackType.Arcane,
                AttackType2 = AttackType.None,
                AttackMode = AttackMode.Normal,
                TricksterWeaponId = 14
            },
            
            new Attack {
                Id = 537,
                Name = "R2 (Milkweed Rune)",
                Damage = 2.35m,
                ExtraDamage = 0.0m,
                ExtraDamageCount = 0,
                AttackType1 = AttackType.Arcane,
                AttackType2 = AttackType.None,
                AttackMode = AttackMode.Normal,
                TricksterWeaponId = 14
            },
            
            new Attack {
                Id = 538,
                Name = "R2 (charged) (Milkweed Rune)",
                Damage = 1.0m,
                ExtraDamage = 2.7m,
                ExtraDamageCount = 1,
                AttackType1 = AttackType.Arcane,
                AttackType2 = AttackType.None,
                AttackMode = AttackMode.Normal,
                TricksterWeaponId = 14
            },
            
            new Attack {
                Id = 539,
                Name = "R2 (backstep) (Milkweed Rune)",
                Damage = 2.2m,
                ExtraDamage = 0.0m,
                ExtraDamageCount = 0,
                AttackType1 = AttackType.Arcane,
                AttackType2 = AttackType.None,
                AttackMode = AttackMode.Normal,
                TricksterWeaponId = 14
            },
            
            new Attack {
                Id = 540,
                Name = "R2 (dash) (Milkweed Rune)",
                Damage = 1.0m,
                ExtraDamage = 2.35m,
                ExtraDamageCount = 1,
                AttackType1 = AttackType.Arcane,
                AttackType2 = AttackType.None,
                AttackMode = AttackMode.Normal,
                TricksterWeaponId = 14
            },
            
            new Attack {
                Id = 541,
                Name = "R2 (forward leap) (Milkweed Rune)",
                Damage = 2.45m,
                ExtraDamage = 0.0m,
                ExtraDamageCount = 0,
                AttackType1 = AttackType.Arcane,
                AttackType2 = AttackType.None,
                AttackMode = AttackMode.Normal,
                TricksterWeaponId = 14
            },
            
            new Attack {
                Id = 542,
                Name = "Transform Attack (Milkweed Rune)",
                Damage = 2.2m,
                ExtraDamage = 0.0m,
                ExtraDamageCount = 0,
                AttackType1 = AttackType.Arcane,
                AttackType2 = AttackType.None,
                AttackMode = AttackMode.Normal,
                TricksterWeaponId = 14
            },
            
            new Attack {
                Id = 543,
                Name = "Plunge Attack (Milkweed Rune)",
                Damage = 2.45m,
                ExtraDamage = 0.0m,
                ExtraDamageCount = 0,
                AttackType1 = AttackType.Arcane,
                AttackType2 = AttackType.None,
                AttackMode = AttackMode.Normal,
                TricksterWeaponId = 14
            },
            
            new Attack {
                Id = 544,
                Name = "Plunge Attack (2nd) (Milkweed Rune)",
                Damage = 1.6m,
                ExtraDamage = 0.0m,
                ExtraDamageCount = 0,
                AttackType1 = AttackType.Blunt,
                AttackType2 = AttackType.Arcane,
                AttackMode = AttackMode.Normal,
                TricksterWeaponId = 14
            },
            
            new Attack {
                Id = 545,
                Name = "R1 (Milkweed Rune)",
                Damage = 2.1m,
                ExtraDamage = 0.0m,
                ExtraDamageCount = 0,
                AttackType1 = AttackType.Arcane,
                AttackType2 = AttackType.None,
                AttackMode = AttackMode.Transformed,
                TricksterWeaponId = 14
            },
            
            new Attack {
                Id = 546,
                Name = "R1 (2nd) (Milkweed Rune)",
                Damage = 2.1m,
                ExtraDamage = 0.0m,
                ExtraDamageCount = 0,
                AttackType1 = AttackType.Arcane,
                AttackType2 = AttackType.None,
                AttackMode = AttackMode.Transformed,
                TricksterWeaponId = 14
            },
            
            new Attack {
                Id = 547,
                Name = "R1 (3rd) (Milkweed Rune)",
                Damage = 2.35m,
                ExtraDamage = 0.0m,
                ExtraDamageCount = 0,
                AttackType1 = AttackType.Arcane,
                AttackType2 = AttackType.None,
                AttackMode = AttackMode.Transformed,
                TricksterWeaponId = 14
            },
            
            new Attack {
                Id = 548,
                Name = "R1 (backstep) (Milkweed Rune)",
                Damage = 1.5m,
                ExtraDamage = 0.0m,
                ExtraDamageCount = 0,
                AttackType1 = AttackType.Arcane,
                AttackType2 = AttackType.None,
                AttackMode = AttackMode.Transformed,
                TricksterWeaponId = 14
            },
            
            new Attack {
                Id = 549,
                Name = "R1 (rolling) (Milkweed Rune)",
                Damage = 2.05m,
                ExtraDamage = 0.0m,
                ExtraDamageCount = 0,
                AttackType1 = AttackType.Arcane,
                AttackType2 = AttackType.None,
                AttackMode = AttackMode.Transformed,
                TricksterWeaponId = 14
            },
            
            new Attack {
                Id = 550,
                Name = "R1 (frontstep) (Milkweed Rune)",
                Damage = 2.05m,
                ExtraDamage = 0.0m,
                ExtraDamageCount = 0,
                AttackType1 = AttackType.Arcane,
                AttackType2 = AttackType.None,
                AttackMode = AttackMode.Transformed,
                TricksterWeaponId = 14
            },
            
            new Attack {
                Id = 551,
                Name = "R1 (sidestep) (Milkweed Rune)",
                Damage = 2.05m,
                ExtraDamage = 0.0m,
                ExtraDamageCount = 0,
                AttackType1 = AttackType.Arcane,
                AttackType2 = AttackType.None,
                AttackMode = AttackMode.Transformed,
                TricksterWeaponId = 14
            },
            
            new Attack {
                Id = 552,
                Name = "R1 (dash) (Milkweed Rune)",
                Damage = 2.2m,
                ExtraDamage = 0.0m,
                ExtraDamageCount = 0,
                AttackType1 = AttackType.Arcane,
                AttackType2 = AttackType.None,
                AttackMode = AttackMode.Transformed,
                TricksterWeaponId = 14
            },
            
            new Attack {
                Id = 553,
                Name = "R2 (Milkweed Rune)",
                Damage = 2.5m,
                ExtraDamage = 0.0m,
                ExtraDamageCount = 0,
                AttackType1 = AttackType.Arcane,
                AttackType2 = AttackType.None,
                AttackMode = AttackMode.Transformed,
                TricksterWeaponId = 14
            },
            
            new Attack {
                Id = 554,
                Name = "R2 (2nd hit) (Milkweed Rune)",
                Damage = 2.9m,
                ExtraDamage = 0.0m,
                ExtraDamageCount = 0,
                AttackType1 = AttackType.Arcane,
                AttackType2 = AttackType.None,
                AttackMode = AttackMode.Transformed,
                TricksterWeaponId = 14
            },
            
            new Attack {
                Id = 555,
                Name = "R2 (backstep) (Milkweed Rune)",
                Damage = 2.4m,
                ExtraDamage = 0.0m,
                ExtraDamageCount = 0,
                AttackType1 = AttackType.Arcane,
                AttackType2 = AttackType.None,
                AttackMode = AttackMode.Transformed,
                TricksterWeaponId = 14
            },
            
            new Attack {
                Id = 556,
                Name = "R2 (dash) (Milkweed Rune)",
                Damage = 1.1m,
                ExtraDamage = 2.5m,
                ExtraDamageCount = 1,
                AttackType1 = AttackType.Arcane,
                AttackType2 = AttackType.None,
                AttackMode = AttackMode.Transformed,
                TricksterWeaponId = 14
            },
            
            new Attack {
                Id = 557,
                Name = "R2 (forward leap) (Milkweed Rune)",
                Damage = 2.5m,
                ExtraDamage = 0.0m,
                ExtraDamageCount = 0,
                AttackType1 = AttackType.Arcane,
                AttackType2 = AttackType.None,
                AttackMode = AttackMode.Transformed,
                TricksterWeaponId = 14
            },
            
            new Attack {
                Id = 558,
                Name = "L2 (Milkweed Rune)",
                Damage = 0.9m,
                ExtraDamage = 0.0m,
                ExtraDamageCount = 0,
                AttackType1 = AttackType.Arcane,
                AttackType2 = AttackType.None,
                AttackMode = AttackMode.Transformed,
                TricksterWeaponId = 14
            },
            
            new Attack {
                Id = 559,
                Name = "L2 (2nd hit) (Milkweed Rune)",
                Damage = 1.1m,
                ExtraDamage = 0.0m,
                ExtraDamageCount = 0,
                AttackType1 = AttackType.Arcane,
                AttackType2 = AttackType.None,
                AttackMode = AttackMode.Transformed,
                TricksterWeaponId = 14
            },
            
            new Attack {
                Id = 560,
                Name = "L2 (3rd hit) (Milkweed Rune)",
                Damage = 1.1m,
                ExtraDamage = 0.0m,
                ExtraDamageCount = 0,
                AttackType1 = AttackType.Arcane,
                AttackType2 = AttackType.None,
                AttackMode = AttackMode.Transformed,
                TricksterWeaponId = 14
            },
            
            new Attack {
                Id = 561,
                Name = "L2 (4th hit) (Milkweed Rune)",
                Damage = 3.2m,
                ExtraDamage = 0.0m,
                ExtraDamageCount = 0,
                AttackType1 = AttackType.Arcane,
                AttackType2 = AttackType.None,
                AttackMode = AttackMode.Transformed,
                TricksterWeaponId = 14
            },
            
            new Attack {
                Id = 562,
                Name = "Transform Attack (Milkweed Rune)",
                Damage = 2.0m,
                ExtraDamage = 0.0m,
                ExtraDamageCount = 0,
                AttackType1 = AttackType.Arcane,
                AttackType2 = AttackType.None,
                AttackMode = AttackMode.Transformed,
                TricksterWeaponId = 14
            },
            
            new Attack {
                Id = 563,
                Name = "Plunge Attack (Milkweed Rune)",
                Damage = 1.45m,
                ExtraDamage = 0.0m,
                ExtraDamageCount = 0,
                AttackType1 = AttackType.Arcane,
                AttackType2 = AttackType.None,
                AttackMode = AttackMode.Transformed,
                TricksterWeaponId = 14
            },
            
            new Attack {
                Id = 564,
                Name = "Plunge Attack (2nd) (Milkweed Rune)",
                Damage = 1.6m,
                ExtraDamage = 0.0m,
                ExtraDamageCount = 0,
                AttackType1 = AttackType.Blunt,
                AttackType2 = AttackType.Arcane,
                AttackMode = AttackMode.Transformed,
                TricksterWeaponId = 14
            },

            new Attack {
                Id = 565,
                Name = "R1",
                Damage = 1.0m,
                ExtraDamage = 0.0m,
                ExtraDamageCount = 0,
                AttackType1 = AttackType.Arcane,
                AttackType2 = AttackType.None,
                AttackMode = AttackMode.Normal,
                TricksterWeaponId = 14
            },
            
            new Attack {
                Id = 566,
                Name = "R1 (2nd)",
                Damage = 1.02m,
                ExtraDamage = 0.0m,
                ExtraDamageCount = 0,
                AttackType1 = AttackType.Arcane,
                AttackType2 = AttackType.None,
                AttackMode = AttackMode.Normal,
                TricksterWeaponId = 14
            },
            
            new Attack {
                Id = 567,
                Name = "R1 (3rd)",
                Damage = 1.05m,
                ExtraDamage = 0.0m,
                ExtraDamageCount = 0,
                AttackType1 = AttackType.Arcane,
                AttackType2 = AttackType.None,
                AttackMode = AttackMode.Normal,
                TricksterWeaponId = 14
            },
            
            new Attack {
                Id = 568,
                Name = "R1 (4th)",
                Damage = 1.07m,
                ExtraDamage = 0.0m,
                ExtraDamageCount = 0,
                AttackType1 = AttackType.Arcane,
                AttackType2 = AttackType.None,
                AttackMode = AttackMode.Normal,
                TricksterWeaponId = 14
            },
            
            new Attack {
                Id = 569,
                Name = "R1 (5th)",
                Damage = 1.1m,
                ExtraDamage = 0.0m,
                ExtraDamageCount = 0,
                AttackType1 = AttackType.Arcane,
                AttackType2 = AttackType.None,
                AttackMode = AttackMode.Normal,
                TricksterWeaponId = 14
            },
            
            new Attack {
                Id = 570,
                Name = "R1 (backstep)",
                Damage = 0.95m,
                ExtraDamage = 0.0m,
                ExtraDamageCount = 0,
                AttackType1 = AttackType.Arcane,
                AttackType2 = AttackType.None,
                AttackMode = AttackMode.Normal,
                TricksterWeaponId = 14
            },
            
            new Attack {
                Id = 571,
                Name = "R1 (rolling)",
                Damage = 0.95m,
                ExtraDamage = 0.0m,
                ExtraDamageCount = 0,
                AttackType1 = AttackType.Arcane,
                AttackType2 = AttackType.None,
                AttackMode = AttackMode.Normal,
                TricksterWeaponId = 14
            },
            
            new Attack {
                Id = 572,
                Name = "R1 (frontstep)",
                Damage = 0.95m,
                ExtraDamage = 0.0m,
                ExtraDamageCount = 0,
                AttackType1 = AttackType.Arcane,
                AttackType2 = AttackType.None,
                AttackMode = AttackMode.Normal,
                TricksterWeaponId = 14
            },
            
            new Attack {
                Id = 573,
                Name = "R1 (sidestep)",
                Damage = 0.95m,
                ExtraDamage = 0.0m,
                ExtraDamageCount = 0,
                AttackType1 = AttackType.Arcane,
                AttackType2 = AttackType.None,
                AttackMode = AttackMode.Normal,
                TricksterWeaponId = 14
            },
            
            new Attack {
                Id = 574,
                Name = "R1 (dash)",
                Damage = 1.1m,
                ExtraDamage = 0.0m,
                ExtraDamageCount = 0,
                AttackType1 = AttackType.Arcane,
                AttackType2 = AttackType.None,
                AttackMode = AttackMode.Normal,
                TricksterWeaponId = 14
            },
            
            new Attack {
                Id = 575,
                Name = "R2",
                Damage = 1.25m,
                ExtraDamage = 0.0m,
                ExtraDamageCount = 0,
                AttackType1 = AttackType.Arcane,
                AttackType2 = AttackType.None,
                AttackMode = AttackMode.Normal,
                TricksterWeaponId = 14
            },
            
            new Attack {
                Id = 576,
                Name = "R2 (charged)",
                Damage = 1.45m,
                ExtraDamage = 0.0m,
                ExtraDamageCount = 0,
                AttackType1 = AttackType.Arcane,
                AttackType2 = AttackType.None,
                AttackMode = AttackMode.Normal,
                TricksterWeaponId = 14
            },
            
            new Attack {
                Id = 577,
                Name = "R2 (backstep)",
                Damage = 1.2m,
                ExtraDamage = 0.0m,
                ExtraDamageCount = 0,
                AttackType1 = AttackType.Arcane,
                AttackType2 = AttackType.None,
                AttackMode = AttackMode.Normal,
                TricksterWeaponId = 14
            },
            
            new Attack {
                Id = 578,
                Name = "R2 (dash)",
                Damage = 1.3m,
                ExtraDamage = 0.0m,
                ExtraDamageCount = 0,
                AttackType1 = AttackType.Arcane,
                AttackType2 = AttackType.None,
                AttackMode = AttackMode.Normal,
                TricksterWeaponId = 14
            },
            
            new Attack {
                Id = 579,
                Name = "R2 (forward leap)",
                Damage = 1.4m,
                ExtraDamage = 0.0m,
                ExtraDamageCount = 0,
                AttackType1 = AttackType.Arcane,
                AttackType2 = AttackType.None,
                AttackMode = AttackMode.Normal,
                TricksterWeaponId = 14
            },
            
            new Attack {
                Id = 580,
                Name = "Transform Attack",
                Damage = 1.2m,
                ExtraDamage = 0.0m,
                ExtraDamageCount = 0,
                AttackType1 = AttackType.Arcane,
                AttackType2 = AttackType.None,
                AttackMode = AttackMode.Normal,
                TricksterWeaponId = 14
            },
            
            new Attack {
                Id = 581,
                Name = "Plunge Attack",
                Damage = 1.45m,
                ExtraDamage = 0.0m,
                ExtraDamageCount = 0,
                AttackType1 = AttackType.Arcane,
                AttackType2 = AttackType.None,
                AttackMode = AttackMode.Normal,
                TricksterWeaponId = 14
            },
            
            new Attack {
                Id = 582,
                Name = "Plunge Attack (2nd)",
                Damage = 1.45m,
                ExtraDamage = 0.0m,
                ExtraDamageCount = 0,
                AttackType1 = AttackType.Arcane,
                AttackType2 = AttackType.None,
                AttackMode = AttackMode.Normal,
                TricksterWeaponId = 14
            },
            
            new Attack {
                Id = 583,
                Name = "R1",
                Damage = 1.2m,
                ExtraDamage = 0.0m,
                ExtraDamageCount = 0,
                AttackType1 = AttackType.Arcane,
                AttackType2 = AttackType.None,
                AttackMode = AttackMode.Transformed,
                TricksterWeaponId = 14
            },
            
            new Attack {
                Id = 584,
                Name = "R1 (2nd)",
                Damage = 1.22m,
                ExtraDamage = 0.0m,
                ExtraDamageCount = 0,
                AttackType1 = AttackType.Arcane,
                AttackType2 = AttackType.None,
                AttackMode = AttackMode.Transformed,
                TricksterWeaponId = 14
            },
            
            new Attack {
                Id = 585,
                Name = "R1 (3rd)",
                Damage = 1.25m,
                ExtraDamage = 0.0m,
                ExtraDamageCount = 0,
                AttackType1 = AttackType.Arcane,
                AttackType2 = AttackType.None,
                AttackMode = AttackMode.Transformed,
                TricksterWeaponId = 14
            },
            
            new Attack {
                Id = 586,
                Name = "R1 (4th)",
                Damage = 1.27m,
                ExtraDamage = 0.0m,
                ExtraDamageCount = 0,
                AttackType1 = AttackType.Arcane,
                AttackType2 = AttackType.None,
                AttackMode = AttackMode.Transformed,
                TricksterWeaponId = 14
            },
            
            new Attack {
                Id = 587,
                Name = "R1 (5th)",
                Damage = 1.3m,
                ExtraDamage = 0.0m,
                ExtraDamageCount = 0,
                AttackType1 = AttackType.Arcane,
                AttackType2 = AttackType.None,
                AttackMode = AttackMode.Transformed,
                TricksterWeaponId = 14
            },
            
            new Attack {
                Id = 588,
                Name = "R1 (backstep)",
                Damage = 1.15m,
                ExtraDamage = 0.0m,
                ExtraDamageCount = 0,
                AttackType1 = AttackType.Arcane,
                AttackType2 = AttackType.None,
                AttackMode = AttackMode.Transformed,
                TricksterWeaponId = 14
            },
            
            new Attack {
                Id = 589,
                Name = "R1 (rolling)",
                Damage = 1.15m,
                ExtraDamage = 0.0m,
                ExtraDamageCount = 0,
                AttackType1 = AttackType.Arcane,
                AttackType2 = AttackType.None,
                AttackMode = AttackMode.Transformed,
                TricksterWeaponId = 14
            },
            
            new Attack {
                Id = 590,
                Name = "R1 (frontstep)",
                Damage = 1.15m,
                ExtraDamage = 0.0m,
                ExtraDamageCount = 0,
                AttackType1 = AttackType.Arcane,
                AttackType2 = AttackType.None,
                AttackMode = AttackMode.Transformed,
                TricksterWeaponId = 14
            },
            
            new Attack {
                Id = 591,
                Name = "R1 (sidestep)",
                Damage = 1.15m,
                ExtraDamage = 0.0m,
                ExtraDamageCount = 0,
                AttackType1 = AttackType.Arcane,
                AttackType2 = AttackType.None,
                AttackMode = AttackMode.Transformed,
                TricksterWeaponId = 14
            },
            
            new Attack {
                Id = 592,
                Name = "R1 (dash)",
                Damage = 1.25m,
                ExtraDamage = 0.0m,
                ExtraDamageCount = 0,
                AttackType1 = AttackType.Arcane,
                AttackType2 = AttackType.None,
                AttackMode = AttackMode.Transformed,
                TricksterWeaponId = 14
            },
            
            new Attack {
                Id = 593,
                Name = "R2",
                Damage = 1.42m,
                ExtraDamage = 0.0m,
                ExtraDamageCount = 0,
                AttackType1 = AttackType.Arcane,
                AttackType2 = AttackType.None,
                AttackMode = AttackMode.Transformed,
                TricksterWeaponId = 14
            },
            
            new Attack {
                Id = 594,
                Name = "R2 (charged)",
                Damage = 2.0m,
                ExtraDamage = 0.0m,
                ExtraDamageCount = 0,
                AttackType1 = AttackType.Arcane,
                AttackType2 = AttackType.None,
                AttackMode = AttackMode.Transformed,
                TricksterWeaponId = 14
            },
            
            new Attack {
                Id = 595,
                Name = "R2 (backstep)",
                Damage = 1.35m,
                ExtraDamage = 0.0m,
                ExtraDamageCount = 0,
                AttackType1 = AttackType.Arcane,
                AttackType2 = AttackType.None,
                AttackMode = AttackMode.Transformed,
                TricksterWeaponId = 14
            },
            
            new Attack {
                Id = 596,
                Name = "R2 (dash)",
                Damage = 1.45m,
                ExtraDamage = 0.0m,
                ExtraDamageCount = 0,
                AttackType1 = AttackType.Arcane,
                AttackType2 = AttackType.None,
                AttackMode = AttackMode.Transformed,
                TricksterWeaponId = 14
            },
            
            new Attack {
                Id = 597,
                Name = "R2 (forward leap)",
                Damage = 1.5m,
                ExtraDamage = 0.0m,
                ExtraDamageCount = 0,
                AttackType1 = AttackType.Arcane,
                AttackType2 = AttackType.None,
                AttackMode = AttackMode.Transformed,
                TricksterWeaponId = 14
            },
            
            new Attack {
                Id = 598,
                Name = "L2",
                Damage = 1.4m,
                ExtraDamage = 0.0m,
                ExtraDamageCount = 0,
                AttackType1 = AttackType.Arcane,
                AttackType2 = AttackType.None,
                AttackMode = AttackMode.Transformed,
                TricksterWeaponId = 14
            },
            
            new Attack {
                Id = 599,
                Name = "L2 (2nd)",
                Damage = 1.42m,
                ExtraDamage = 0.0m,
                ExtraDamageCount = 0,
                AttackType1 = AttackType.Arcane,
                AttackType2 = AttackType.None,
                AttackMode = AttackMode.Transformed,
                TricksterWeaponId = 14
            },
            
            new Attack {
                Id = 600,
                Name = "L2 (3rd)",
                Damage = 1.45m,
                ExtraDamage = 0.0m,
                ExtraDamageCount = 0,
                AttackType1 = AttackType.Arcane,
                AttackType2 = AttackType.None,
                AttackMode = AttackMode.Transformed,
                TricksterWeaponId = 14
            },
            
            new Attack {
                Id = 601,
                Name = "Transform Attack",
                Damage = 1.0m,
                ExtraDamage = 0.0m,
                ExtraDamageCount = 0,
                AttackType1 = AttackType.Arcane,
                AttackType2 = AttackType.None,
                AttackMode = AttackMode.Transformed,
                TricksterWeaponId = 14
            },
            
            new Attack {
                Id = 602,
                Name = "Plunge Attack",
                Damage = 1.45m,
                ExtraDamage = 0.0m,
                ExtraDamageCount = 0,
                AttackType1 = AttackType.Arcane,
                AttackType2 = AttackType.None,
                AttackMode = AttackMode.Transformed,
                TricksterWeaponId = 14
            },
            
            new Attack {
                Id = 603,
                Name = "Plunge Attack (2nd)",
                Damage = 1.45m,
                ExtraDamage = 0.0m,
                ExtraDamageCount = 0,
                AttackType1 = AttackType.Arcane,
                AttackType2 = AttackType.None,
                AttackMode = AttackMode.Transformed,
                TricksterWeaponId = 14
            },
            
            new Attack {
                Id = 604,
                Name = "R1",
                Damage = 1.0m,
                ExtraDamage = 0.0m,
                ExtraDamageCount = 0,
                AttackType1 = AttackType.Blunt,
                AttackType2 = AttackType.Arcane,
                AttackMode = AttackMode.Normal,
                TricksterWeaponId = 15
            },
            
            new Attack {
                Id = 605,
                Name = "R1 (2nd)",
                Damage = 1.0m,
                ExtraDamage = 0.0m,
                ExtraDamageCount = 0,
                AttackType1 = AttackType.Blunt,
                AttackType2 = AttackType.Arcane,
                AttackMode = AttackMode.Normal,
                TricksterWeaponId = 15
            },
            
            new Attack {
                Id = 606,
                Name = "R1 (3rd)",
                Damage = 1.0m,
                ExtraDamage = 0.0m,
                ExtraDamageCount = 0,
                AttackType1 = AttackType.Blunt,
                AttackType2 = AttackType.Arcane,
                AttackMode = AttackMode.Normal,
                TricksterWeaponId = 15
            },
            
            new Attack {
                Id = 607,
                Name = "R1 (backstep)",
                Damage = 0.8m,
                ExtraDamage = 0.0m,
                ExtraDamageCount = 0,
                AttackType1 = AttackType.Blunt,
                AttackType2 = AttackType.Arcane,
                AttackMode = AttackMode.Normal,
                TricksterWeaponId = 15
            },
            
            new Attack {
                Id = 608,
                Name = "R1 (rolling)",
                Damage = 0.8m,
                ExtraDamage = 0.0m,
                ExtraDamageCount = 0,
                AttackType1 = AttackType.Blunt,
                AttackType2 = AttackType.Arcane,
                AttackMode = AttackMode.Normal,
                TricksterWeaponId = 15
            },
            
            new Attack {
                Id = 609,
                Name = "R1 (frontstep)",
                Damage = 0.8m,
                ExtraDamage = 0.0m,
                ExtraDamageCount = 0,
                AttackType1 = AttackType.Blunt,
                AttackType2 = AttackType.Arcane,
                AttackMode = AttackMode.Normal,
                TricksterWeaponId = 15
            },
            
            new Attack {
                Id = 610,
                Name = "R1 (sidestep)",
                Damage = 0.85m,
                ExtraDamage = 0.0m,
                ExtraDamageCount = 0,
                AttackType1 = AttackType.Blunt,
                AttackType2 = AttackType.Arcane,
                AttackMode = AttackMode.Normal,
                TricksterWeaponId = 15
            },
            
            new Attack {
                Id = 611,
                Name = "R1 (dash)",
                Damage = 1.05m,
                ExtraDamage = 0.0m,
                ExtraDamageCount = 0,
                AttackType1 = AttackType.Blunt,
                AttackType2 = AttackType.Arcane,
                AttackMode = AttackMode.Normal,
                TricksterWeaponId = 15
            },
            
            new Attack {
                Id = 612,
                Name = "R2",
                Damage = 1.15m,
                ExtraDamage = 0.0m,
                ExtraDamageCount = 0,
                AttackType1 = AttackType.Blunt,
                AttackType2 = AttackType.Arcane,
                AttackMode = AttackMode.Normal,
                TricksterWeaponId = 15
            },
            
            new Attack {
                Id = 613,
                Name = "R2 (charged)",
                Damage = 1.6m,
                ExtraDamage = 0.0m,
                ExtraDamageCount = 0,
                AttackType1 = AttackType.Blunt,
                AttackType2 = AttackType.Arcane,
                AttackMode = AttackMode.Normal,
                TricksterWeaponId = 15
            },
            
            new Attack {
                Id = 614,
                Name = "R2 (backstep)",
                Damage = 1.05m,
                ExtraDamage = 0.0m,
                ExtraDamageCount = 0,
                AttackType1 = AttackType.Blunt,
                AttackType2 = AttackType.Arcane,
                AttackMode = AttackMode.Normal,
                TricksterWeaponId = 15
            },
            
            new Attack {
                Id = 615,
                Name = "R2 (dash)",
                Damage = 1.15m,
                ExtraDamage = 0.0m,
                ExtraDamageCount = 0,
                AttackType1 = AttackType.Blunt,
                AttackType2 = AttackType.Arcane,
                AttackMode = AttackMode.Normal,
                TricksterWeaponId = 15
            },
            
            new Attack {
                Id = 616,
                Name = "R2 (forward leap)",
                Damage = 1.3m,
                ExtraDamage = 0.0m,
                ExtraDamageCount = 0,
                AttackType1 = AttackType.Blunt,
                AttackType2 = AttackType.Arcane,
                AttackMode = AttackMode.Normal,
                TricksterWeaponId = 15
            },
            
            new Attack {
                Id = 617,
                Name = "Transform Attack",
                Damage = 0.93m,
                ExtraDamage = 0.1m,
                ExtraDamageCount = 3,
                AttackType1 = AttackType.Blunt,
                AttackType2 = AttackType.Arcane,
                AttackMode = AttackMode.Normal,
                TricksterWeaponId = 15
            },
            
            new Attack {
                Id = 618,
                Name = "Plunge Attack",
                Damage = 1.3m,
                ExtraDamage = 0.0m,
                ExtraDamageCount = 0,
                AttackType1 = AttackType.Blunt,
                AttackType2 = AttackType.Arcane,
                AttackMode = AttackMode.Normal,
                TricksterWeaponId = 15
            },
            
            new Attack {
                Id = 619,
                Name = "Plunge Attack (2nd)",
                Damage = 0.9m,
                ExtraDamage = 0.0m,
                ExtraDamageCount = 0,
                AttackType1 = AttackType.Blunt,
                AttackType2 = AttackType.Arcane,
                AttackMode = AttackMode.Normal,
                TricksterWeaponId = 15
            },
            
            new Attack {
                Id = 620,
                Name = "R1",
                Damage = 1.02m,
                ExtraDamage = 0.0m,
                ExtraDamageCount = 0,
                AttackType1 = AttackType.Blunt,
                AttackType2 = AttackType.Arcane,
                AttackMode = AttackMode.Transformed,
                TricksterWeaponId = 15
            },
            
            new Attack {
                Id = 621,
                Name = "R1 (2nd)",
                Damage = 1.02m,
                ExtraDamage = 0.0m,
                ExtraDamageCount = 0,
                AttackType1 = AttackType.Blunt,
                AttackType2 = AttackType.Arcane,
                AttackMode = AttackMode.Transformed,
                TricksterWeaponId = 15
            },
            
            new Attack {
                Id = 622,
                Name = "R1 (3rd)",
                Damage = 1.17m,
                ExtraDamage = 0.15m,
                ExtraDamageCount = 2,
                AttackType1 = AttackType.Blunt,
                AttackType2 = AttackType.Arcane,
                AttackMode = AttackMode.Transformed,
                TricksterWeaponId = 15
            },
            
            new Attack {
                Id = 623,
                Name = "R1 (4th)",
                Damage = 1.17m,
                ExtraDamage = 0.15m,
                ExtraDamageCount = 2,
                AttackType1 = AttackType.Blunt,
                AttackType2 = AttackType.Arcane,
                AttackMode = AttackMode.Transformed,
                TricksterWeaponId = 15
            },
            
            new Attack {
                Id = 624,
                Name = "R1 (5th)",
                Damage = 1.1m,
                ExtraDamage = 0.0m,
                ExtraDamageCount = 0,
                AttackType1 = AttackType.Blunt,
                AttackType2 = AttackType.Arcane,
                AttackMode = AttackMode.Transformed,
                TricksterWeaponId = 15
            },
            
            new Attack {
                Id = 625,
                Name = "R1 (backstep)",
                Damage = 0.95m,
                ExtraDamage = 0.0m,
                ExtraDamageCount = 0,
                AttackType1 = AttackType.Blunt,
                AttackType2 = AttackType.Arcane,
                AttackMode = AttackMode.Transformed,
                TricksterWeaponId = 15
            },
            
            new Attack {
                Id = 626,
                Name = "R1 (rolling)",
                Damage = 0.93m,
                ExtraDamage = 0.15m,
                ExtraDamageCount = 2,
                AttackType1 = AttackType.Blunt,
                AttackType2 = AttackType.Arcane,
                AttackMode = AttackMode.Transformed,
                TricksterWeaponId = 15
            },
            
            new Attack {
                Id = 627,
                Name = "R1 (frontstep)",
                Damage = 0.93m,
                ExtraDamage = 0.15m,
                ExtraDamageCount = 2,
                AttackType1 = AttackType.Blunt,
                AttackType2 = AttackType.Arcane,
                AttackMode = AttackMode.Transformed,
                TricksterWeaponId = 15
            },
            
            new Attack {
                Id = 628,
                Name = "R1 (sidestep)",
                Damage = 0.93m,
                ExtraDamage = 0.15m,
                ExtraDamageCount = 2,
                AttackType1 = AttackType.Blunt,
                AttackType2 = AttackType.Arcane,
                AttackMode = AttackMode.Transformed,
                TricksterWeaponId = 15
            },
            
            new Attack {
                Id = 629,
                Name = "R1 (dash)",
                Damage = 0.93m,
                ExtraDamage = 0.15m,
                ExtraDamageCount = 2,
                AttackType1 = AttackType.Blunt,
                AttackType2 = AttackType.Arcane,
                AttackMode = AttackMode.Transformed,
                TricksterWeaponId = 15
            },
            
            new Attack {
                Id = 630,
                Name = "R2",
                Damage = 1.17m,
                ExtraDamage = 0.15m,
                ExtraDamageCount = 2,
                AttackType1 = AttackType.Blunt,
                AttackType2 = AttackType.Arcane,
                AttackMode = AttackMode.Transformed,
                TricksterWeaponId = 15
            },
            
            new Attack {
                Id = 631,
                Name = "R2 (2nd)",
                Damage = 1.3m,
                ExtraDamage = 0.15m,
                ExtraDamageCount = 2,
                AttackType1 = AttackType.Blunt,
                AttackType2 = AttackType.Arcane,
                AttackMode = AttackMode.Transformed,
                TricksterWeaponId = 15
            },
            
            new Attack {
                Id = 632,
                Name = "R2 (3rd)",
                Damage = 1.44m,
                ExtraDamage = 0.15m,
                ExtraDamageCount = 2,
                AttackType1 = AttackType.Blunt,
                AttackType2 = AttackType.Arcane,
                AttackMode = AttackMode.Transformed,
                TricksterWeaponId = 15
            },
            
            new Attack {
                Id = 633,
                Name = "R2 (backstep)",
                Damage = 1.11m,
                ExtraDamage = 0.15m,
                ExtraDamageCount = 3,
                AttackType1 = AttackType.Blunt,
                AttackType2 = AttackType.Arcane,
                AttackMode = AttackMode.Transformed,
                TricksterWeaponId = 15
            },
            
            new Attack {
                Id = 634,
                Name = "R2 (dash)",
                Damage = 1.1m,
                ExtraDamage = 0.0m,
                ExtraDamageCount = 0,
                AttackType1 = AttackType.Blunt,
                AttackType2 = AttackType.Arcane,
                AttackMode = AttackMode.Transformed,
                TricksterWeaponId = 15
            },
            
            new Attack {
                Id = 635,
                Name = "R2 (forward leap)",
                Damage = 1.35m,
                ExtraDamage = 0.0m,
                ExtraDamageCount = 0,
                AttackType1 = AttackType.Blunt,
                AttackType2 = AttackType.Arcane,
                AttackMode = AttackMode.Transformed,
                TricksterWeaponId = 15
            },
            
            new Attack {
                Id = 636,
                Name = "Transform Attack",
                Damage = 0.4m,
                ExtraDamage = 0.0m,
                ExtraDamageCount = 0,
                AttackType1 = AttackType.Blunt,
                AttackType2 = AttackType.Arcane,
                AttackMode = AttackMode.Transformed,
                TricksterWeaponId = 15
            },
            
            new Attack {
                Id = 637,
                Name = "Plunge Attack",
                Damage = 1.35m,
                ExtraDamage = 0.0m,
                ExtraDamageCount = 0,
                AttackType1 = AttackType.Blunt,
                AttackType2 = AttackType.Arcane,
                AttackMode = AttackMode.Transformed,
                TricksterWeaponId = 15
            },
            
            new Attack {
                Id = 638,
                Name = "Plunge Attack (2nd)",
                Damage = 0.9m,
                ExtraDamage = 0.0m,
                ExtraDamageCount = 0,
                AttackType1 = AttackType.Blunt,
                AttackType2 = AttackType.Arcane,
                AttackMode = AttackMode.Transformed,
                TricksterWeaponId = 15
            },
            
            new Attack {
                Id = 639,
                Name = "R1",
                Damage = 0.7m,
                ExtraDamage = 0.0m,
                ExtraDamageCount = 0,
                AttackType1 = AttackType.Physical,
                AttackType2 = AttackType.None,
                AttackMode = AttackMode.Normal,
                TricksterWeaponId = 16
            },
            
            new Attack {
                Id = 640,
                Name = "R1 (2nd)",
                Damage = 0.71m,
                ExtraDamage = 0.0m,
                ExtraDamageCount = 0,
                AttackType1 = AttackType.Physical,
                AttackType2 = AttackType.None,
                AttackMode = AttackMode.Normal,
                TricksterWeaponId = 16
            },
            
            new Attack {
                Id = 641,
                Name = "R1 (3rd)",
                Damage = 0.72m,
                ExtraDamage = 0.0m,
                ExtraDamageCount = 0,
                AttackType1 = AttackType.Physical,
                AttackType2 = AttackType.None,
                AttackMode = AttackMode.Normal,
                TricksterWeaponId = 16
            },
            
            new Attack {
                Id = 642,
                Name = "R1 (4th)",
                Damage = 0.74m,
                ExtraDamage = 0.0m,
                ExtraDamageCount = 0,
                AttackType1 = AttackType.Thrust,
                AttackType2 = AttackType.None,
                AttackMode = AttackMode.Normal,
                TricksterWeaponId = 16
            },
            
            new Attack {
                Id = 643,
                Name = "R1 (5th)",
                Damage = 0.76m,
                ExtraDamage = 0.0m,
                ExtraDamageCount = 0,
                AttackType1 = AttackType.Physical,
                AttackType2 = AttackType.None,
                AttackMode = AttackMode.Normal,
                TricksterWeaponId = 16
            },
            
            new Attack {
                Id = 644,
                Name = "R1 (backstep)",
                Damage = 0.67m,
                ExtraDamage = 0.0m,
                ExtraDamageCount = 0,
                AttackType1 = AttackType.Physical,
                AttackType2 = AttackType.None,
                AttackMode = AttackMode.Normal,
                TricksterWeaponId = 16
            },
            
            new Attack {
                Id = 645,
                Name = "R1 (rolling)",
                Damage = 0.67m,
                ExtraDamage = 0.0m,
                ExtraDamageCount = 0,
                AttackType1 = AttackType.Physical,
                AttackType2 = AttackType.None,
                AttackMode = AttackMode.Normal,
                TricksterWeaponId = 16
            },
            
            new Attack {
                Id = 646,
                Name = "R1 (frontstep)",
                Damage = 0.67m,
                ExtraDamage = 0.0m,
                ExtraDamageCount = 0,
                AttackType1 = AttackType.Physical,
                AttackType2 = AttackType.None,
                AttackMode = AttackMode.Normal,
                TricksterWeaponId = 16
            },
            
            new Attack {
                Id = 647,
                Name = "R1 (sidestep)",
                Damage = 0.67m,
                ExtraDamage = 0.0m,
                ExtraDamageCount = 0,
                AttackType1 = AttackType.Physical,
                AttackType2 = AttackType.None,
                AttackMode = AttackMode.Normal,
                TricksterWeaponId = 16
            },
            
            new Attack {
                Id = 648,
                Name = "R1 (dash)",
                Damage = 0.8m,
                ExtraDamage = 0.0m,
                ExtraDamageCount = 0,
                AttackType1 = AttackType.Physical,
                AttackType2 = AttackType.None,
                AttackMode = AttackMode.Normal,
                TricksterWeaponId = 16
            },
            
            new Attack {
                Id = 649,
                Name = "R2",
                Damage = 1.0m,
                ExtraDamage = 0.0m,
                ExtraDamageCount = 0,
                AttackType1 = AttackType.Thrust,
                AttackType2 = AttackType.None,
                AttackMode = AttackMode.Normal,
                TricksterWeaponId = 16
            },
            
            new Attack {
                Id = 650,
                Name = "R2 (charged)",
                Damage = 1.2m,
                ExtraDamage = 0.0m,
                ExtraDamageCount = 0,
                AttackType1 = AttackType.Thrust,
                AttackType2 = AttackType.None,
                AttackMode = AttackMode.Normal,
                TricksterWeaponId = 16
            },
            
            new Attack {
                Id = 651,
                Name = "R2 (backstep)",
                Damage = 0.85m,
                ExtraDamage = 0.0m,
                ExtraDamageCount = 0,
                AttackType1 = AttackType.Thrust,
                AttackType2 = AttackType.None,
                AttackMode = AttackMode.Normal,
                TricksterWeaponId = 16
            },
            
            new Attack {
                Id = 652,
                Name = "R2 (dash)",
                Damage = 0.95m,
                ExtraDamage = 0.0m,
                ExtraDamageCount = 0,
                AttackType1 = AttackType.Thrust,
                AttackType2 = AttackType.None,
                AttackMode = AttackMode.Normal,
                TricksterWeaponId = 16
            },
            
            new Attack {
                Id = 653,
                Name = "R2 (forward leap)",
                Damage = 1.2m,
                ExtraDamage = 0.0m,
                ExtraDamageCount = 0,
                AttackType1 = AttackType.Thrust,
                AttackType2 = AttackType.None,
                AttackMode = AttackMode.Normal,
                TricksterWeaponId = 16
            },
            
            new Attack {
                Id = 654,
                Name = "Transform Attack",
                Damage = 1.05m,
                ExtraDamage = 0.0m,
                ExtraDamageCount = 0,
                AttackType1 = AttackType.Blunt,
                AttackType2 = AttackType.None,
                AttackMode = AttackMode.Normal,
                TricksterWeaponId = 16
            },
            
            new Attack {
                Id = 655,
                Name = "Transform Attack to R1",
                Damage = 0.85m,
                ExtraDamage = 0.0m,
                ExtraDamageCount = 0,
                AttackType1 = AttackType.Physical,
                AttackType2 = AttackType.None,
                AttackMode = AttackMode.Normal,
                TricksterWeaponId = 16
            },
            
            new Attack {
                Id = 656,
                Name = "Plunge Attack",
                Damage = 1.25m,
                ExtraDamage = 0.0m,
                ExtraDamageCount = 0,
                AttackType1 = AttackType.Thrust,
                AttackType2 = AttackType.None,
                AttackMode = AttackMode.Normal,
                TricksterWeaponId = 16
            },
            
            new Attack {
                Id = 657,
                Name = "Plunge Attack (2nd)",
                Damage = 0.6m,
                ExtraDamage = 0.0m,
                ExtraDamageCount = 0,
                AttackType1 = AttackType.Blunt,
                AttackType2 = AttackType.None,
                AttackMode = AttackMode.Normal,
                TricksterWeaponId = 16
            },
            
            new Attack {
                Id = 658,
                Name = "R1",
                Damage = 1.0m,
                ExtraDamage = 0.0m,
                ExtraDamageCount = 0,
                AttackType1 = AttackType.Blunt,
                AttackType2 = AttackType.None,
                AttackMode = AttackMode.Transformed,
                TricksterWeaponId = 16
            },
            
            new Attack {
                Id = 659,
                Name = "R1 (2nd)",
                Damage = 1.0m,
                ExtraDamage = 0.0m,
                ExtraDamageCount = 0,
                AttackType1 = AttackType.Blunt,
                AttackType2 = AttackType.None,
                AttackMode = AttackMode.Transformed,
                TricksterWeaponId = 16
            },
            
            new Attack {
                Id = 660,
                Name = "R1 (3rd)",
                Damage = 1.06m,
                ExtraDamage = 0.0m,
                ExtraDamageCount = 0,
                AttackType1 = AttackType.Blunt,
                AttackType2 = AttackType.None,
                AttackMode = AttackMode.Transformed,
                TricksterWeaponId = 16
            },
            
            new Attack {
                Id = 661,
                Name = "R1 (4th)",
                Damage = 1.0m,
                ExtraDamage = 0.0m,
                ExtraDamageCount = 0,
                AttackType1 = AttackType.Blunt,
                AttackType2 = AttackType.None,
                AttackMode = AttackMode.Transformed,
                TricksterWeaponId = 16
            },
            
            new Attack {
                Id = 662,
                Name = "R1 (backstep)",
                Damage = 0.56m,
                ExtraDamage = 0.0m,
                ExtraDamageCount = 0,
                AttackType1 = AttackType.Blunt,
                AttackType2 = AttackType.None,
                AttackMode = AttackMode.Transformed,
                TricksterWeaponId = 16
            },
            
            new Attack {
                Id = 663,
                Name = "R1 (rolling)",
                Damage = 0.9m,
                ExtraDamage = 0.0m,
                ExtraDamageCount = 0,
                AttackType1 = AttackType.Blunt,
                AttackType2 = AttackType.None,
                AttackMode = AttackMode.Transformed,
                TricksterWeaponId = 16
            },
            
            new Attack {
                Id = 664,
                Name = "R1 (frontstep)",
                Damage = 0.9m,
                ExtraDamage = 0.0m,
                ExtraDamageCount = 0,
                AttackType1 = AttackType.Blunt,
                AttackType2 = AttackType.None,
                AttackMode = AttackMode.Transformed,
                TricksterWeaponId = 16
            },
            
            new Attack {
                Id = 665,
                Name = "R1 (sidestep)",
                Damage = 0.9m,
                ExtraDamage = 0.0m,
                ExtraDamageCount = 0,
                AttackType1 = AttackType.Blunt,
                AttackType2 = AttackType.None,
                AttackMode = AttackMode.Transformed,
                TricksterWeaponId = 16
            },
            
            new Attack {
                Id = 666,
                Name = "R1 (dash)",
                Damage = 1.01m,
                ExtraDamage = 0.0m,
                ExtraDamageCount = 0,
                AttackType1 = AttackType.Blunt,
                AttackType2 = AttackType.None,
                AttackMode = AttackMode.Transformed,
                TricksterWeaponId = 16
            },
            
            new Attack {
                Id = 667,
                Name = "R2",
                Damage = 1.25m,
                ExtraDamage = 0.0m,
                ExtraDamageCount = 0,
                AttackType1 = AttackType.Thrust,
                AttackType2 = AttackType.None,
                AttackMode = AttackMode.Transformed,
                TricksterWeaponId = 16
            },
            
            new Attack {
                Id = 668,
                Name = "R2 (charged)",
                Damage = 2.2m,
                ExtraDamage = 0.0m,
                ExtraDamageCount = 0,
                AttackType1 = AttackType.Thrust,
                AttackType2 = AttackType.None,
                AttackMode = AttackMode.Transformed,
                TricksterWeaponId = 16
            },
            
            new Attack {
                Id = 669,
                Name = "R2 (charged follow-up)",
                Damage = 1.56m,
                ExtraDamage = 0.0m,
                ExtraDamageCount = 0,
                AttackType1 = AttackType.Blunt,
                AttackType2 = AttackType.None,
                AttackMode = AttackMode.Transformed,
                TricksterWeaponId = 16
            },
            
            new Attack {
                Id = 670,
                Name = "R2 (backstep)",
                Damage = 1.06m,
                ExtraDamage = 0.0m,
                ExtraDamageCount = 0,
                AttackType1 = AttackType.Blunt,
                AttackType2 = AttackType.None,
                AttackMode = AttackMode.Transformed,
                TricksterWeaponId = 16
            },
            
            new Attack {
                Id = 671,
                Name = "R2 (dash)",
                Damage = 1.14m,
                ExtraDamage = 0.0m,
                ExtraDamageCount = 0,
                AttackType1 = AttackType.Blunt,
                AttackType2 = AttackType.None,
                AttackMode = AttackMode.Transformed,
                TricksterWeaponId = 16
            },
            
            new Attack {
                Id = 672,
                Name = "R2(forward leap)",
                Damage = 1.2m,
                ExtraDamage = 0.0m,
                ExtraDamageCount = 0,
                AttackType1 = AttackType.Blunt,
                AttackType2 = AttackType.None,
                AttackMode = AttackMode.Transformed,
                TricksterWeaponId = 16
            },
            
            new Attack {
                Id = 673,
                Name = "L2",
                Damage = 1.15m,
                ExtraDamage = 0.0m,
                ExtraDamageCount = 0,
                AttackType1 = AttackType.Blunt,
                AttackType2 = AttackType.None,
                AttackMode = AttackMode.Transformed,
                TricksterWeaponId = 16
            },
            
            new Attack {
                Id = 674,
                Name = "L2 (2nd)",
                Damage = 1.15m,
                ExtraDamage = 0.0m,
                ExtraDamageCount = 0,
                AttackType1 = AttackType.Blunt,
                AttackType2 = AttackType.None,
                AttackMode = AttackMode.Transformed,
                TricksterWeaponId = 16
            },
            
            new Attack {
                Id = 675,
                Name = "L2 (3rd)",
                Damage = 1.18m,
                ExtraDamage = 0.0m,
                ExtraDamageCount = 0,
                AttackType1 = AttackType.Blunt,
                AttackType2 = AttackType.None,
                AttackMode = AttackMode.Transformed,
                TricksterWeaponId = 16
            },
            
            new Attack {
                Id = 676,
                Name = "L2 (4th)",
                Damage = 1.13m,
                ExtraDamage = 0.0m,
                ExtraDamageCount = 0,
                AttackType1 = AttackType.Thrust,
                AttackType2 = AttackType.None,
                AttackMode = AttackMode.Transformed,
                TricksterWeaponId = 16
            },
            
            new Attack {
                Id = 677,
                Name = "Transform Attack",
                Damage = 1.26m,
                ExtraDamage = 0.0m,
                ExtraDamageCount = 0,
                AttackType1 = AttackType.Blunt,
                AttackType2 = AttackType.None,
                AttackMode = AttackMode.Transformed,
                TricksterWeaponId = 16
            },
            
            new Attack {
                Id = 678,
                Name = "Transform Attack to R1",
                Damage = 0.96m,
                ExtraDamage = 0.0m,
                ExtraDamageCount = 0,
                AttackType1 = AttackType.Blunt,
                AttackType2 = AttackType.None,
                AttackMode = AttackMode.Transformed,
                TricksterWeaponId = 16
            },
            
            new Attack {
                Id = 679,
                Name = "Plunge Attack",
                Damage = 1.66m,
                ExtraDamage = 0.0m,
                ExtraDamageCount = 0,
                AttackType1 = AttackType.Blunt,
                AttackType2 = AttackType.None,
                AttackMode = AttackMode.Transformed,
                TricksterWeaponId = 16
            },
            
            new Attack {
                Id = 680,
                Name = "Plunge Attack (2nd)",
                Damage = 0.56m,
                ExtraDamage = 0.0m,
                ExtraDamageCount = 0,
                AttackType1 = AttackType.Blunt,
                AttackType2 = AttackType.None,
                AttackMode = AttackMode.Transformed,
                TricksterWeaponId = 16
            },
            
            new Attack {
                Id = 681,
                Name = "R1",
                Damage = 1.0m,
                ExtraDamage = 0.0m,
                ExtraDamageCount = 0,
                AttackType1 = AttackType.Physical,
                AttackType2 = AttackType.None,
                AttackMode = AttackMode.Normal,
                TricksterWeaponId = 17
            },
            
            new Attack {
                Id = 682,
                Name = "R1 (2nd)",
                Damage = 0.9m,
                ExtraDamage = 0.0m,
                ExtraDamageCount = 0,
                AttackType1 = AttackType.Thrust,
                AttackType2 = AttackType.None,
                AttackMode = AttackMode.Normal,
                TricksterWeaponId = 17
            },
            
            new Attack {
                Id = 683,
                Name = "R1 (3rd)",
                Damage = 1.0m,
                ExtraDamage = 0.0m,
                ExtraDamageCount = 0,
                AttackType1 = AttackType.Physical,
                AttackType2 = AttackType.None,
                AttackMode = AttackMode.Normal,
                TricksterWeaponId = 17
            },
            
            new Attack {
                Id = 684,
                Name = "R1 (4th)",
                Damage = 1.15m,
                ExtraDamage = 0.0m,
                ExtraDamageCount = 0,
                AttackType1 = AttackType.Thrust,
                AttackType2 = AttackType.None,
                AttackMode = AttackMode.Normal,
                TricksterWeaponId = 17
            },
            
            new Attack {
                Id = 685,
                Name = "R1 (backstep)",
                Damage = 0.9m,
                ExtraDamage = 0.0m,
                ExtraDamageCount = 0,
                AttackType1 = AttackType.Physical,
                AttackType2 = AttackType.None,
                AttackMode = AttackMode.Normal,
                TricksterWeaponId = 17
            },
            
            new Attack {
                Id = 686,
                Name = "R1 (rolling)",
                Damage = 0.9m,
                ExtraDamage = 0.0m,
                ExtraDamageCount = 0,
                AttackType1 = AttackType.Physical,
                AttackType2 = AttackType.None,
                AttackMode = AttackMode.Normal,
                TricksterWeaponId = 17
            },
            
            new Attack {
                Id = 687,
                Name = "R1 (frontstep)",
                Damage = 0.9m,
                ExtraDamage = 0.0m,
                ExtraDamageCount = 0,
                AttackType1 = AttackType.Physical,
                AttackType2 = AttackType.None,
                AttackMode = AttackMode.Normal,
                TricksterWeaponId = 17
            },
            
            new Attack {
                Id = 688,
                Name = "R1 (sidestep)",
                Damage = 0.9m,
                ExtraDamage = 0.0m,
                ExtraDamageCount = 0,
                AttackType1 = AttackType.Physical,
                AttackType2 = AttackType.None,
                AttackMode = AttackMode.Normal,
                TricksterWeaponId = 17
            },
            
            new Attack {
                Id = 689,
                Name = "R1 (dash)",
                Damage = 1.1m,
                ExtraDamage = 0.0m,
                ExtraDamageCount = 0,
                AttackType1 = AttackType.Physical,
                AttackType2 = AttackType.None,
                AttackMode = AttackMode.Normal,
                TricksterWeaponId = 17
            },
            
            new Attack {
                Id = 690,
                Name = "R2",
                Damage = 1.35m,
                ExtraDamage = 0.0m,
                ExtraDamageCount = 0,
                AttackType1 = AttackType.Physical,
                AttackType2 = AttackType.None,
                AttackMode = AttackMode.Normal,
                TricksterWeaponId = 17
            },
            
            new Attack {
                Id = 691,
                Name = "R2 (charged)",
                Damage = 1.7m,
                ExtraDamage = 0.0m,
                ExtraDamageCount = 0,
                AttackType1 = AttackType.Thrust,
                AttackType2 = AttackType.None,
                AttackMode = AttackMode.Normal,
                TricksterWeaponId = 17
            },
            
            new Attack {
                Id = 692,
                Name = "R2 (backstep)",
                Damage = 1.25m,
                ExtraDamage = 0.0m,
                ExtraDamageCount = 0,
                AttackType1 = AttackType.Thrust,
                AttackType2 = AttackType.None,
                AttackMode = AttackMode.Normal,
                TricksterWeaponId = 17
            },
            
            new Attack {
                Id = 693,
                Name = "R2 (dash)",
                Damage = 1.4m,
                ExtraDamage = 0.0m,
                ExtraDamageCount = 0,
                AttackType1 = AttackType.Thrust,
                AttackType2 = AttackType.None,
                AttackMode = AttackMode.Normal,
                TricksterWeaponId = 17
            },
            
            new Attack {
                Id = 694,
                Name = "R2 (forward leap)",
                Damage = 1.4m,
                ExtraDamage = 0.0m,
                ExtraDamageCount = 0,
                AttackType1 = AttackType.Physical,
                AttackType2 = AttackType.None,
                AttackMode = AttackMode.Normal,
                TricksterWeaponId = 17
            },
            
            new Attack {
                Id = 695,
                Name = "Transform Attack",
                Damage = 1.3m,
                ExtraDamage = 0.0m,
                ExtraDamageCount = 0,
                AttackType1 = AttackType.Physical,
                AttackType2 = AttackType.None,
                AttackMode = AttackMode.Normal,
                TricksterWeaponId = 17
            },
            
            new Attack {
                Id = 696,
                Name = "Plunge Attack",
                Damage = 1.4m,
                ExtraDamage = 0.0m,
                ExtraDamageCount = 0,
                AttackType1 = AttackType.Physical,
                AttackType2 = AttackType.None,
                AttackMode = AttackMode.Normal,
                TricksterWeaponId = 17
            },
            
            new Attack {
                Id = 697,
                Name = "Plunge Attack (2nd)",
                Damage = 0.9m,
                ExtraDamage = 0.0m,
                ExtraDamageCount = 0,
                AttackType1 = AttackType.Blunt,
                AttackType2 = AttackType.None,
                AttackMode = AttackMode.Normal,
                TricksterWeaponId = 17
            },
            
            new Attack {
                Id = 698,
                Name = "R1",
                Damage = 1.0m,
                ExtraDamage = 0.0m,
                ExtraDamageCount = 0,
                AttackType1 = AttackType.Physical,
                AttackType2 = AttackType.None,
                AttackMode = AttackMode.Transformed,
                TricksterWeaponId = 17
            },
            
            new Attack {
                Id = 699,
                Name = "R1 (2nd)",
                Damage = 1.0m,
                ExtraDamage = 0.0m,
                ExtraDamageCount = 0,
                AttackType1 = AttackType.Physical,
                AttackType2 = AttackType.None,
                AttackMode = AttackMode.Transformed,
                TricksterWeaponId = 17
            },
            
            new Attack {
                Id = 700,
                Name = "R1 (3rd)",
                Damage = 1.2m,
                ExtraDamage = 0.0m,
                ExtraDamageCount = 0,
                AttackType1 = AttackType.Physical,
                AttackType2 = AttackType.None,
                AttackMode = AttackMode.Transformed,
                TricksterWeaponId = 17
            },
            
            new Attack {
                Id = 701,
                Name = "R1 (4th)",
                Damage = 1.1m,
                ExtraDamage = 0.0m,
                ExtraDamageCount = 0,
                AttackType1 = AttackType.Physical,
                AttackType2 = AttackType.None,
                AttackMode = AttackMode.Transformed,
                TricksterWeaponId = 17
            },
            
            new Attack {
                Id = 702,
                Name = "R1 to L2",
                Damage = 1.6m,
                ExtraDamage = 0.0m,
                ExtraDamageCount = 0,
                AttackType1 = AttackType.Physical,
                AttackType2 = AttackType.None,
                AttackMode = AttackMode.Transformed,
                TricksterWeaponId = 17
            },
            
            new Attack {
                Id = 703,
                Name = "R1 (backstep)",
                Damage = 0.9m,
                ExtraDamage = 0.0m,
                ExtraDamageCount = 0,
                AttackType1 = AttackType.Physical,
                AttackType2 = AttackType.None,
                AttackMode = AttackMode.Transformed,
                TricksterWeaponId = 17
            },
            
            new Attack {
                Id = 704,
                Name = "R1 (rolling)",
                Damage = 0.9m,
                ExtraDamage = 0.0m,
                ExtraDamageCount = 0,
                AttackType1 = AttackType.Physical,
                AttackType2 = AttackType.None,
                AttackMode = AttackMode.Transformed,
                TricksterWeaponId = 17
            },
            
            new Attack {
                Id = 705,
                Name = "R1 (frontstep)",
                Damage = 0.9m,
                ExtraDamage = 0.0m,
                ExtraDamageCount = 0,
                AttackType1 = AttackType.Physical,
                AttackType2 = AttackType.None,
                AttackMode = AttackMode.Transformed,
                TricksterWeaponId = 17
            },
            
            new Attack {
                Id = 706,
                Name = "R1 (sidestep)",
                Damage = 0.9m,
                ExtraDamage = 0.0m,
                ExtraDamageCount = 0,
                AttackType1 = AttackType.Physical,
                AttackType2 = AttackType.None,
                AttackMode = AttackMode.Transformed,
                TricksterWeaponId = 17
            },
            
            new Attack {
                Id = 707,
                Name = "R1 (dash)",
                Damage = 1.1m,
                ExtraDamage = 0.0m,
                ExtraDamageCount = 0,
                AttackType1 = AttackType.Physical,
                AttackType2 = AttackType.None,
                AttackMode = AttackMode.Transformed,
                TricksterWeaponId = 17
            },
            
            new Attack {
                Id = 708,
                Name = "R2",
                Damage = 0.9m,
                ExtraDamage = 0.0m,
                ExtraDamageCount = 0,
                AttackType1 = AttackType.Thrust,
                AttackType2 = AttackType.None,
                AttackMode = AttackMode.Transformed,
                TricksterWeaponId = 17
            },
            
            new Attack {
                Id = 709,
                Name = "R2 (2nd)",
                Damage = 0.95m,
                ExtraDamage = 0.0m,
                ExtraDamageCount = 0,
                AttackType1 = AttackType.Thrust,
                AttackType2 = AttackType.None,
                AttackMode = AttackMode.Transformed,
                TricksterWeaponId = 17
            },
            
            new Attack {
                Id = 710,
                Name = "R2 to L2",
                Damage = 1.2m,
                ExtraDamage = 0.0m,
                ExtraDamageCount = 0,
                AttackType1 = AttackType.Thrust,
                AttackType2 = AttackType.None,
                AttackMode = AttackMode.Transformed,
                TricksterWeaponId = 17
            },
            
            new Attack {
                Id = 711,
                Name = "R2 (backstep)",
                Damage = 1.25m,
                ExtraDamage = 0.0m,
                ExtraDamageCount = 0,
                AttackType1 = AttackType.Thrust,
                AttackType2 = AttackType.None,
                AttackMode = AttackMode.Transformed,
                TricksterWeaponId = 17
            },
            
            new Attack {
                Id = 712,
                Name = "R2 (dash)",
                Damage = 1.4m,
                ExtraDamage = 0.0m,
                ExtraDamageCount = 0,
                AttackType1 = AttackType.Thrust,
                AttackType2 = AttackType.None,
                AttackMode = AttackMode.Transformed,
                TricksterWeaponId = 17
            },
            
            new Attack {
                Id = 713,
                Name = "R2 (forward leap)",
                Damage = 1.4m,
                ExtraDamage = 0.0m,
                ExtraDamageCount = 0,
                AttackType1 = AttackType.Physical,
                AttackType2 = AttackType.None,
                AttackMode = AttackMode.Transformed,
                TricksterWeaponId = 17
            },
            
            new Attack {
                Id = 714,
                Name = "L2",
                Damage = 0.95m,
                ExtraDamage = 1.0m,
                ExtraDamageCount = 1,
                AttackType1 = AttackType.Physical,
                AttackType2 = AttackType.None,
                AttackMode = AttackMode.Transformed,
                TricksterWeaponId = 17
            },
            
            new Attack {
                Id = 715,
                Name = "L2 (2nd)",
                Damage = 1.05m,
                ExtraDamage = 1.1m,
                ExtraDamageCount = 1,
                AttackType1 = AttackType.Physical,
                AttackType2 = AttackType.None,
                AttackMode = AttackMode.Transformed,
                TricksterWeaponId = 17
            },
            
            new Attack {
                Id = 716,
                Name = "Transform Attack",
                Damage = 1.5m,
                ExtraDamage = 0.0m,
                ExtraDamageCount = 0,
                AttackType1 = AttackType.Thrust,
                AttackType2 = AttackType.None,
                AttackMode = AttackMode.Transformed,
                TricksterWeaponId = 17
            },
            
            new Attack {
                Id = 717,
                Name = "Plunge Attack",
                Damage = 1.4m,
                ExtraDamage = 0.0m,
                ExtraDamageCount = 0,
                AttackType1 = AttackType.Physical,
                AttackType2 = AttackType.None,
                AttackMode = AttackMode.Transformed,
                TricksterWeaponId = 17
            },
            
            new Attack {
                Id = 718,
                Name = "Plunge Attack (2nd)",
                Damage = 0.9m,
                ExtraDamage = 0.0m,
                ExtraDamageCount = 0,
                AttackType1 = AttackType.Blunt,
                AttackType2 = AttackType.None,
                AttackMode = AttackMode.Transformed,
                TricksterWeaponId = 17
            },
            
            new Attack {
                Id = 719,
                Name = "R1",
                Damage = 1.0m,
                ExtraDamage = 0.0m,
                ExtraDamageCount = 0,
                AttackType1 = AttackType.Thrust,
                AttackType2 = AttackType.None,
                AttackMode = AttackMode.Normal,
                TricksterWeaponId = 18
            },
            
            new Attack {
                Id = 720,
                Name = "R1 (2nd)",
                Damage = 1.05m,
                ExtraDamage = 0.0m,
                ExtraDamageCount = 0,
                AttackType1 = AttackType.Physical,
                AttackType2 = AttackType.None,
                AttackMode = AttackMode.Normal,
                TricksterWeaponId = 18
            },
            
            new Attack {
                Id = 721,
                Name = "R1 (3rd)",
                Damage = 1.02m,
                ExtraDamage = 0.0m,
                ExtraDamageCount = 0,
                AttackType1 = AttackType.Thrust,
                AttackType2 = AttackType.None,
                AttackMode = AttackMode.Normal,
                TricksterWeaponId = 18
            },
            
            new Attack {
                Id = 722,
                Name = "R1 (4th)",
                Damage = 1.07m,
                ExtraDamage = 0.0m,
                ExtraDamageCount = 0,
                AttackType1 = AttackType.Physical,
                AttackType2 = AttackType.None,
                AttackMode = AttackMode.Normal,
                TricksterWeaponId = 18
            },
            
            new Attack {
                Id = 723,
                Name = "R1 (backstep)",
                Damage = 0.95m,
                ExtraDamage = 0.0m,
                ExtraDamageCount = 0,
                AttackType1 = AttackType.Physical,
                AttackType2 = AttackType.None,
                AttackMode = AttackMode.Normal,
                TricksterWeaponId = 18
            },

            new Attack {
                Id = 724,
                Name = "R1 (rolling)",
                Damage = 0.95m,
                ExtraDamage = 0.0m,
                ExtraDamageCount = 0,
                AttackType1 = AttackType.Physical,
                AttackType2 = AttackType.None,
                AttackMode = AttackMode.Normal,
                TricksterWeaponId = 18
            },
            
            new Attack {
                Id = 725,
                Name = "R1 (frontstep)",
                Damage = 0.95m,
                ExtraDamage = 0.0m,
                ExtraDamageCount = 0,
                AttackType1 = AttackType.Physical,
                AttackType2 = AttackType.None,
                AttackMode = AttackMode.Normal,
                TricksterWeaponId = 18
            },
            
            new Attack {
                Id = 726,
                Name = "R1 (sidestep)",
                Damage = 0.95m,
                ExtraDamage = 0.0m,
                ExtraDamageCount = 0,
                AttackType1 = AttackType.Physical,
                AttackType2 = AttackType.None,
                AttackMode = AttackMode.Normal,
                TricksterWeaponId = 18
            },
            
            new Attack {
                Id = 727,
                Name = "R1 (dash)",
                Damage = 1.1m,
                ExtraDamage = 0.0m,
                ExtraDamageCount = 0,
                AttackType1 = AttackType.Physical,
                AttackType2 = AttackType.None,
                AttackMode = AttackMode.Normal,
                TricksterWeaponId = 18
            },
            
            new Attack {
                Id = 728,
                Name = "R2",
                Damage = 1.25m,
                ExtraDamage = 0.0m,
                ExtraDamageCount = 0,
                AttackType1 = AttackType.Physical,
                AttackType2 = AttackType.None,
                AttackMode = AttackMode.Normal,
                TricksterWeaponId = 18
            },
            
            new Attack {
                Id = 729,
                Name = "R2 (charged)",
                Damage = 1.9m,
                ExtraDamage = 0.0m,
                ExtraDamageCount = 0,
                AttackType1 = AttackType.Thrust,
                AttackType2 = AttackType.None,
                AttackMode = AttackMode.Normal,
                TricksterWeaponId = 18
            },
            
            new Attack {
                Id = 730,
                Name = "R2 (backstep)",
                Damage = 1.15m,
                ExtraDamage = 0.0m,
                ExtraDamageCount = 0,
                AttackType1 = AttackType.Thrust,
                AttackType2 = AttackType.None,
                AttackMode = AttackMode.Normal,
                TricksterWeaponId = 18
            },
            
            new Attack {
                Id = 731,
                Name = "R2 (dash)",
                Damage = 1.2m,
                ExtraDamage = 0.0m,
                ExtraDamageCount = 0,
                AttackType1 = AttackType.Thrust,
                AttackType2 = AttackType.None,
                AttackMode = AttackMode.Normal,
                TricksterWeaponId = 18
            },
            
            new Attack {
                Id = 732,
                Name = "R2 (forward leap)",
                Damage = 1.5m,
                ExtraDamage = 0.0m,
                ExtraDamageCount = 0,
                AttackType1 = AttackType.Thrust,
                AttackType2 = AttackType.None,
                AttackMode = AttackMode.Normal,
                TricksterWeaponId = 18
            },
            
            new Attack {
                Id = 733,
                Name = "Transform Attack",
                Damage = 1.0m,
                ExtraDamage = 0.0m,
                ExtraDamageCount = 0,
                AttackType1 = AttackType.Blood,
                AttackType2 = AttackType.None,
                AttackMode = AttackMode.Normal,
                TricksterWeaponId = 18
            },
            
            new Attack {
                Id = 734,
                Name = "Plunge Attack",
                Damage = 1.5m,
                ExtraDamage = 0.0m,
                ExtraDamageCount = 0,
                AttackType1 = AttackType.Physical,
                AttackType2 = AttackType.None,
                AttackMode = AttackMode.Normal,
                TricksterWeaponId = 18
            },
            
            new Attack {
                Id = 735,
                Name = "Plunge Attack (2nd)",
                Damage = 0.9m,
                ExtraDamage = 0.0m,
                ExtraDamageCount = 0,
                AttackType1 = AttackType.Blunt,
                AttackType2 = AttackType.None,
                AttackMode = AttackMode.Normal,
                TricksterWeaponId = 18
            },
            
            new Attack {
                Id = 736,
                Name = "R1",
                Damage = 0.75m,
                ExtraDamage = 0.0m,
                ExtraDamageCount = 0,
                AttackType1 = AttackType.Physical,
                AttackType2 = AttackType.None,
                AttackMode = AttackMode.Transformed,
                TricksterWeaponId = 18
            },
            
            new Attack {
                Id = 737,
                Name = "R1 (2nd)",
                Damage = 0.9m,
                ExtraDamage = 0.0m,
                ExtraDamageCount = 0,
                AttackType1 = AttackType.Physical,
                AttackType2 = AttackType.None,
                AttackMode = AttackMode.Transformed,
                TricksterWeaponId = 18
            },
            
            new Attack {
                Id = 738,
                Name = "R1 (3rd)",
                Damage = 0.95m,
                ExtraDamage = 0.0m,
                ExtraDamageCount = 0,
                AttackType1 = AttackType.Physical,
                AttackType2 = AttackType.None,
                AttackMode = AttackMode.Transformed,
                TricksterWeaponId = 18
            },
            
            new Attack {
                Id = 739,
                Name = "R1 (backstep)",
                Damage = 0.95m,
                ExtraDamage = 0.0m,
                ExtraDamageCount = 0,
                AttackType1 = AttackType.Physical,
                AttackType2 = AttackType.None,
                AttackMode = AttackMode.Transformed,
                TricksterWeaponId = 18
            },
            
            new Attack {
                Id = 740,
                Name = "R1 (rolling)",
                Damage = 0.95m,
                ExtraDamage = 0.0m,
                ExtraDamageCount = 0,
                AttackType1 = AttackType.Thrust,
                AttackType2 = AttackType.None,
                AttackMode = AttackMode.Transformed,
                TricksterWeaponId = 18
            },
            
            new Attack {
                Id = 741,
                Name = "R1 (frontstep)",
                Damage = 0.95m,
                ExtraDamage = 0.0m,
                ExtraDamageCount = 0,
                AttackType1 = AttackType.Thrust,
                AttackType2 = AttackType.None,
                AttackMode = AttackMode.Transformed,
                TricksterWeaponId = 18
            },
            
            new Attack {
                Id = 742,
                Name = "R1 (sidestep)",
                Damage = 0.95m,
                ExtraDamage = 0.0m,
                ExtraDamageCount = 0,
                AttackType1 = AttackType.Thrust,
                AttackType2 = AttackType.None,
                AttackMode = AttackMode.Transformed,
                TricksterWeaponId = 18
            },
            
            new Attack {
                Id = 743,
                Name = "R1 (dash)",
                Damage = 1.15m,
                ExtraDamage = 0.0m,
                ExtraDamageCount = 0,
                AttackType1 = AttackType.Physical,
                AttackType2 = AttackType.None,
                AttackMode = AttackMode.Transformed,
                TricksterWeaponId = 18
            },
            
            new Attack {
                Id = 744,
                Name = "R2",
                Damage = 1.0m,
                ExtraDamage = 0.0m,
                ExtraDamageCount = 0,
                AttackType1 = AttackType.Blood,
                AttackType2 = AttackType.None,
                AttackMode = AttackMode.Transformed,
                TricksterWeaponId = 18
            },
            
            new Attack {
                Id = 745,
                Name = "R2 (forward leap)",
                Damage = 1.4m,
                ExtraDamage = 0.0m,
                ExtraDamageCount = 0,
                AttackType1 = AttackType.Physical,
                AttackType2 = AttackType.None,
                AttackMode = AttackMode.Transformed,
                TricksterWeaponId = 18
            },
            
            new Attack {
                Id = 746,
                Name = "Transform Attack",
                Damage = 1.1m,
                ExtraDamage = 0.0m,
                ExtraDamageCount = 0,
                AttackType1 = AttackType.Thrust,
                AttackType2 = AttackType.None,
                AttackMode = AttackMode.Transformed,
                TricksterWeaponId = 18
            },
            
            new Attack {
                Id = 747,
                Name = "Plunge Attack",
                Damage = 1.4m,
                ExtraDamage = 0.0m,
                ExtraDamageCount = 0,
                AttackType1 = AttackType.Physical,
                AttackType2 = AttackType.None,
                AttackMode = AttackMode.Transformed,
                TricksterWeaponId = 18
            },
            
            new Attack {
                Id = 748,
                Name = "Plunge Attack (2nd)",
                Damage = 0.9m,
                ExtraDamage = 0.0m,
                ExtraDamageCount = 0,
                AttackType1 = AttackType.Blunt,
                AttackType2 = AttackType.None,
                AttackMode = AttackMode.Transformed,
                TricksterWeaponId = 18
            },
            
            new Attack {
                Id = 749,
                Name = "R1",
                Damage = 0.95m,
                ExtraDamage = 0.0m,
                ExtraDamageCount = 0,
                AttackType1 = AttackType.Thrust,
                AttackType2 = AttackType.None,
                AttackMode = AttackMode.Normal,
                TricksterWeaponId = 19
            },
            
            new Attack {
                Id = 750,
                Name = "R1 (2nd)",
                Damage = 1.0m,
                ExtraDamage = 0.0m,
                ExtraDamageCount = 0,
                AttackType1 = AttackType.Thrust,
                AttackType2 = AttackType.None,
                AttackMode = AttackMode.Normal,
                TricksterWeaponId = 19
            },
            
            new Attack {
                Id = 751,
                Name = "R1 (3rd)",
                Damage = 1.05m,
                ExtraDamage = 0.0m,
                ExtraDamageCount = 0,
                AttackType1 = AttackType.Thrust,
                AttackType2 = AttackType.None,
                AttackMode = AttackMode.Normal,
                TricksterWeaponId = 19
            },
            
            new Attack {
                Id = 752,
                Name = "R1 (4th)",
                Damage = 1.1m,
                ExtraDamage = 0.0m,
                ExtraDamageCount = 0,
                AttackType1 = AttackType.Thrust,
                AttackType2 = AttackType.None,
                AttackMode = AttackMode.Normal,
                TricksterWeaponId = 19
            },
            
            new Attack {
                Id = 753,
                Name = "R1 (backstep)",
                Damage = 0.9m,
                ExtraDamage = 0.0m,
                ExtraDamageCount = 0,
                AttackType1 = AttackType.Thrust,
                AttackType2 = AttackType.None,
                AttackMode = AttackMode.Normal,
                TricksterWeaponId = 19
            },
            
            new Attack {
                Id = 754,
                Name = "R1 (rolling)",
                Damage = 0.85m,
                ExtraDamage = 0.0m,
                ExtraDamageCount = 0,
                AttackType1 = AttackType.Physical,
                AttackType2 = AttackType.None,
                AttackMode = AttackMode.Normal,
                TricksterWeaponId = 19
            },
            
            new Attack {
                Id = 755,
                Name = "R1 (frontstep)",
                Damage = 0.85m,
                ExtraDamage = 0.0m,
                ExtraDamageCount = 0,
                AttackType1 = AttackType.Physical,
                AttackType2 = AttackType.None,
                AttackMode = AttackMode.Normal,
                TricksterWeaponId = 19
            },
            
            new Attack {
                Id = 756,
                Name = "R1 (sidestep)",
                Damage = 0.85m,
                ExtraDamage = 0.0m,
                ExtraDamageCount = 0,
                AttackType1 = AttackType.Physical,
                AttackType2 = AttackType.None,
                AttackMode = AttackMode.Normal,
                TricksterWeaponId = 19
            },
            
            new Attack {
                Id = 757,
                Name = "R1 (dash)",
                Damage = 0.85m,
                ExtraDamage = 0.0m,
                ExtraDamageCount = 0,
                AttackType1 = AttackType.Thrust,
                AttackType2 = AttackType.None,
                AttackMode = AttackMode.Normal,
                TricksterWeaponId = 19
            },
            
            new Attack {
                Id = 758,
                Name = "R2",
                Damage = 1.35m,
                ExtraDamage = 0.0m,
                ExtraDamageCount = 0,
                AttackType1 = AttackType.Thrust,
                AttackType2 = AttackType.None,
                AttackMode = AttackMode.Normal,
                TricksterWeaponId = 19
            },
            
            new Attack {
                Id = 759,
                Name = "R2 (charged)",
                Damage = 1.95m,
                ExtraDamage = 0.0m,
                ExtraDamageCount = 0,
                AttackType1 = AttackType.Thrust,
                AttackType2 = AttackType.None,
                AttackMode = AttackMode.Normal,
                TricksterWeaponId = 19
            },
            
            new Attack {
                Id = 760,
                Name = "R2 (backstep)",
                Damage = 1.2m,
                ExtraDamage = 0.0m,
                ExtraDamageCount = 0,
                AttackType1 = AttackType.Physical,
                AttackType2 = AttackType.None,
                AttackMode = AttackMode.Normal,
                TricksterWeaponId = 19
            },
            
            new Attack {
                Id = 761,
                Name = "R2 (dash)",
                Damage = 1.15m,
                ExtraDamage = 0.0m,
                ExtraDamageCount = 0,
                AttackType1 = AttackType.Physical,
                AttackType2 = AttackType.None,
                AttackMode = AttackMode.Normal,
                TricksterWeaponId = 19
            },
            
            new Attack {
                Id = 762,
                Name = "R2 (forward leap)",
                Damage = 1.6m,
                ExtraDamage = 0.0m,
                ExtraDamageCount = 0,
                AttackType1 = AttackType.Thrust,
                AttackType2 = AttackType.None,
                AttackMode = AttackMode.Normal,
                TricksterWeaponId = 19
            },
            
            new Attack {
                Id = 763,
                Name = "Transform Attack",
                Damage = 0.08m,
                ExtraDamage = 0.0m,
                ExtraDamageCount = 0,
                AttackType1 = AttackType.Blood,
                AttackType2 = AttackType.None,
                AttackMode = AttackMode.Normal,
                TricksterWeaponId = 19
            },
            
            new Attack {
                Id = 764,
                Name = "Plunge Attack",
                Damage = 1.5m,
                ExtraDamage = 0.0m,
                ExtraDamageCount = 0,
                AttackType1 = AttackType.Thrust,
                AttackType2 = AttackType.None,
                AttackMode = AttackMode.Normal,
                TricksterWeaponId = 19
            },
            
            new Attack {
                Id = 765,
                Name = "Plunge Attack (2nd)",
                Damage = 0.9m,
                ExtraDamage = 0.0m,
                ExtraDamageCount = 0,
                AttackType1 = AttackType.Blunt,
                AttackType2 = AttackType.None,
                AttackMode = AttackMode.Normal,
                TricksterWeaponId = 19
            },
            
            new Attack {
                Id = 766,
                Name = "R1",
                Damage = 0.95m,
                ExtraDamage = 0.0m,
                ExtraDamageCount = 0,
                AttackType1 = AttackType.Physical,
                AttackType2 = AttackType.None,
                AttackMode = AttackMode.Transformed,
                TricksterWeaponId = 19
            },
            
            new Attack {
                Id = 767,
                Name = "R1 (2nd)",
                Damage = 1.0m,
                ExtraDamage = 0.0m,
                ExtraDamageCount = 0,
                AttackType1 = AttackType.Physical,
                AttackType2 = AttackType.None,
                AttackMode = AttackMode.Transformed,
                TricksterWeaponId = 19
            },
            
            new Attack {
                Id = 768,
                Name = "R1 (3rd)",
                Damage = 1.05m,
                ExtraDamage = 0.0m,
                ExtraDamageCount = 0,
                AttackType1 = AttackType.Physical,
                AttackType2 = AttackType.None,
                AttackMode = AttackMode.Transformed,
                TricksterWeaponId = 19
            },
            
            new Attack {
                Id = 769,
                Name = "R1 (4th)",
                Damage = 1.1m,
                ExtraDamage = 0.0m,
                ExtraDamageCount = 0,
                AttackType1 = AttackType.Physical,
                AttackType2 = AttackType.None,
                AttackMode = AttackMode.Transformed,
                TricksterWeaponId = 19
            },
            
            new Attack {
                Id = 770,
                Name = "R1 (backstep)",
                Damage = 0.9m,
                ExtraDamage = 0.0m,
                ExtraDamageCount = 0,
                AttackType1 = AttackType.Thrust,
                AttackType2 = AttackType.None,
                AttackMode = AttackMode.Transformed,
                TricksterWeaponId = 19
            },
            
            new Attack {
                Id = 771,
                Name = "R1 (rolling)",
                Damage = 0.9m,
                ExtraDamage = 0.0m,
                ExtraDamageCount = 0,
                AttackType1 = AttackType.Thrust,
                AttackType2 = AttackType.None,
                AttackMode = AttackMode.Transformed,
                TricksterWeaponId = 19
            },
            
            new Attack {
                Id = 772,
                Name = "R1 (frontstep)",
                Damage = 0.9m,
                ExtraDamage = 0.0m,
                ExtraDamageCount = 0,
                AttackType1 = AttackType.Thrust,
                AttackType2 = AttackType.None,
                AttackMode = AttackMode.Transformed,
                TricksterWeaponId = 19
            },
            
            new Attack {
                Id = 773,
                Name = "R1 (sidestep)",
                Damage = 0.9m,
                ExtraDamage = 0.0m,
                ExtraDamageCount = 0,
                AttackType1 = AttackType.Thrust,
                AttackType2 = AttackType.None,
                AttackMode = AttackMode.Transformed,
                TricksterWeaponId = 19
            },
            
            new Attack {
                Id = 774,
                Name = "R1 (dash)",
                Damage = 0.9m,
                ExtraDamage = 0.0m,
                ExtraDamageCount = 0,
                AttackType1 = AttackType.Thrust,
                AttackType2 = AttackType.None,
                AttackMode = AttackMode.Transformed,
                TricksterWeaponId = 19
            },
            
            new Attack {
                Id = 775,
                Name = "R2",
                Damage = 1.45m,
                ExtraDamage = 0.0m,
                ExtraDamageCount = 0,
                AttackType1 = AttackType.Thrust,
                AttackType2 = AttackType.None,
                AttackMode = AttackMode.Transformed,
                TricksterWeaponId = 19
            },
            
            new Attack {
                Id = 776,
                Name = "R2 (charged)",
                Damage = 2.45m,
                ExtraDamage = 0.0m,
                ExtraDamageCount = 0,
                AttackType1 = AttackType.Thrust,
                AttackType2 = AttackType.None,
                AttackMode = AttackMode.Transformed,
                TricksterWeaponId = 19
            },
            
            new Attack {
                Id = 777,
                Name = "R2 (backstep)",
                Damage = 1.35m,
                ExtraDamage = 0.0m,
                ExtraDamageCount = 0,
                AttackType1 = AttackType.Physical,
                AttackType2 = AttackType.None,
                AttackMode = AttackMode.Transformed,
                TricksterWeaponId = 19
            },
            
            new Attack {
                Id = 778,
                Name = "R2 (dash)",
                Damage = 1.35m,
                ExtraDamage = 0.0m,
                ExtraDamageCount = 0,
                AttackType1 = AttackType.Physical,
                AttackType2 = AttackType.None,
                AttackMode = AttackMode.Transformed,
                TricksterWeaponId = 19
            },
            
            new Attack {
                Id = 779,
                Name = "R2 (forward leap)",
                Damage = 1.6m,
                ExtraDamage = 0.0m,
                ExtraDamageCount = 0,
                AttackType1 = AttackType.Physical,
                AttackType2 = AttackType.None,
                AttackMode = AttackMode.Transformed,
                TricksterWeaponId = 19
            },
            
            new Attack {
                Id = 780,
                Name = "L2",
                Damage = 0.08m,
                ExtraDamage = 0.0m,
                ExtraDamageCount = 0,
                AttackType1 = AttackType.Blood,
                AttackType2 = AttackType.None,
                AttackMode = AttackMode.Transformed,
                TricksterWeaponId = 19
            },
            
            new Attack {
                Id = 781,
                Name = "Transform Attack",
                Damage = 1.3m,
                ExtraDamage = 0.0m,
                ExtraDamageCount = 0,
                AttackType1 = AttackType.Physical,
                AttackType2 = AttackType.None,
                AttackMode = AttackMode.Transformed,
                TricksterWeaponId = 19
            },
            
            new Attack {
                Id = 782,
                Name = "Plunge Attack",
                Damage = 1.5m,
                ExtraDamage = 0.0m,
                ExtraDamageCount = 0,
                AttackType1 = AttackType.Thrust,
                AttackType2 = AttackType.None,
                AttackMode = AttackMode.Transformed,
                TricksterWeaponId = 19
            },
            
            new Attack {
                Id = 783,
                Name = "Plunge Attack (2nd)",
                Damage = 0.9m,
                ExtraDamage = 0.0m,
                ExtraDamageCount = 0,
                AttackType1 = AttackType.Blunt,
                AttackType2 = AttackType.None,
                AttackMode = AttackMode.Transformed,
                TricksterWeaponId = 19
            },
            
            new Attack {
                Id = 784,
                Name = "R1",
                Damage = 1.0m,
                ExtraDamage = 0.0m,
                ExtraDamageCount = 0,
                AttackType1 = AttackType.Physical,
                AttackType2 = AttackType.None,
                AttackMode = AttackMode.Normal,
                TricksterWeaponId = 20
            },
            
            new Attack {
                Id = 785,
                Name = "R1 (2nd)",
                Damage = 1.02m,
                ExtraDamage = 0.0m,
                ExtraDamageCount = 0,
                AttackType1 = AttackType.Physical,
                AttackType2 = AttackType.None,
                AttackMode = AttackMode.Normal,
                TricksterWeaponId = 20
            },
            
            new Attack {
                Id = 786,
                Name = "R1 (3rd)",
                Damage = 1.04m,
                ExtraDamage = 0.0m,
                ExtraDamageCount = 0,
                AttackType1 = AttackType.Physical,
                AttackType2 = AttackType.None,
                AttackMode = AttackMode.Normal,
                TricksterWeaponId = 20
            },
            
            new Attack {
                Id = 787,
                Name = "R1 (4th)",
                Damage = 1.06m,
                ExtraDamage = 0.0m,
                ExtraDamageCount = 0,
                AttackType1 = AttackType.Physical,
                AttackType2 = AttackType.None,
                AttackMode = AttackMode.Normal,
                TricksterWeaponId = 20
            },
            
            new Attack {
                Id = 788,
                Name = "R1 (5th)",
                Damage = 1.09m,
                ExtraDamage = 0.0m,
                ExtraDamageCount = 0,
                AttackType1 = AttackType.Physical,
                AttackType2 = AttackType.None,
                AttackMode = AttackMode.Normal,
                TricksterWeaponId = 20
            },
            
            new Attack {
                Id = 789,
                Name = "R1 (backstep)",
                Damage = 0.95m,
                ExtraDamage = 0.0m,
                ExtraDamageCount = 0,
                AttackType1 = AttackType.Physical,
                AttackType2 = AttackType.None,
                AttackMode = AttackMode.Normal,
                TricksterWeaponId = 20
            },
            
            new Attack {
                Id = 790,
                Name = "R1 (rolling)",
                Damage = 0.95m,
                ExtraDamage = 0.0m,
                ExtraDamageCount = 0,
                AttackType1 = AttackType.Physical,
                AttackType2 = AttackType.None,
                AttackMode = AttackMode.Normal,
                TricksterWeaponId = 20
            },
            
            new Attack {
                Id = 791,
                Name = "R1 (frontstep)",
                Damage = 0.95m,
                ExtraDamage = 0.0m,
                ExtraDamageCount = 0,
                AttackType1 = AttackType.Physical,
                AttackType2 = AttackType.None,
                AttackMode = AttackMode.Normal,
                TricksterWeaponId = 20
            },
            
            new Attack {
                Id = 792,
                Name = "R1 (sidestep)",
                Damage = 1.0m,
                ExtraDamage = 0.0m,
                ExtraDamageCount = 0,
                AttackType1 = AttackType.Physical,
                AttackType2 = AttackType.None,
                AttackMode = AttackMode.Normal,
                TricksterWeaponId = 20
            },
            
            new Attack {
                Id = 793,
                Name = "R1 (dash)",
                Damage = 1.09m,
                ExtraDamage = 0.0m,
                ExtraDamageCount = 0,
                AttackType1 = AttackType.Physical,
                AttackType2 = AttackType.None,
                AttackMode = AttackMode.Normal,
                TricksterWeaponId = 20
            },
            
            new Attack {
                Id = 794,
                Name = "R2",
                Damage = 1.2m,
                ExtraDamage = 0.0m,
                ExtraDamageCount = 0,
                AttackType1 = AttackType.Physical,
                AttackType2 = AttackType.None,
                AttackMode = AttackMode.Normal,
                TricksterWeaponId = 20
            },
            
            new Attack {
                Id = 795,
                Name = "R2 (charged)",
                Damage = 1.9m,
                ExtraDamage = 0.0m,
                ExtraDamageCount = 0,
                AttackType1 = AttackType.Physical,
                AttackType2 = AttackType.None,
                AttackMode = AttackMode.Normal,
                TricksterWeaponId = 20
            },
            
            new Attack {
                Id = 796,
                Name = "R2 (backstep)",
                Damage = 1.1m,
                ExtraDamage = 0.0m,
                ExtraDamageCount = 0,
                AttackType1 = AttackType.Physical,
                AttackType2 = AttackType.None,
                AttackMode = AttackMode.Normal,
                TricksterWeaponId = 20
            },
            
            new Attack {
                Id = 797,
                Name = "R2 (dash)",
                Damage = 1.25m,
                ExtraDamage = 0.0m,
                ExtraDamageCount = 0,
                AttackType1 = AttackType.Physical,
                AttackType2 = AttackType.None,
                AttackMode = AttackMode.Normal,
                TricksterWeaponId = 20
            },
            
            new Attack {
                Id = 798,
                Name = "R2 (forward leap)",
                Damage = 1.4m,
                ExtraDamage = 0.0m,
                ExtraDamageCount = 0,
                AttackType1 = AttackType.Physical,
                AttackType2 = AttackType.None,
                AttackMode = AttackMode.Normal,
                TricksterWeaponId = 20
            },
            
            new Attack {
                Id = 799,
                Name = "Transform Attack",
                Damage = 1.3m,
                ExtraDamage = 0.0m,
                ExtraDamageCount = 0,
                AttackType1 = AttackType.Physical,
                AttackType2 = AttackType.None,
                AttackMode = AttackMode.Normal,
                TricksterWeaponId = 20
            },
            
            new Attack {
                Id = 800,
                Name = "Plunge Attack",
                Damage = 1.4m,
                ExtraDamage = 0.0m,
                ExtraDamageCount = 0,
                AttackType1 = AttackType.Physical,
                AttackType2 = AttackType.None,
                AttackMode = AttackMode.Normal,
                TricksterWeaponId = 20
            },
            
            new Attack {
                Id = 801,
                Name = "Plunge Attack (2nd)",
                Damage = 0.9m,
                ExtraDamage = 0.0m,
                ExtraDamageCount = 0,
                AttackType1 = AttackType.Blunt,
                AttackType2 = AttackType.None,
                AttackMode = AttackMode.Normal,
                TricksterWeaponId = 20
            },
            
            new Attack {
                Id = 802,
                Name = "R1",
                Damage = 0.97m,
                ExtraDamage = 0.0m,
                ExtraDamageCount = 0,
                AttackType1 = AttackType.Physical,
                AttackType2 = AttackType.None,
                AttackMode = AttackMode.Transformed,
                TricksterWeaponId = 20
            },
            
            new Attack {
                Id = 803,
                Name = "R1 (2nd)",
                Damage = 1.0m,
                ExtraDamage = 0.0m,
                ExtraDamageCount = 0,
                AttackType1 = AttackType.Physical,
                AttackType2 = AttackType.None,
                AttackMode = AttackMode.Transformed,
                TricksterWeaponId = 20
            },
            
            new Attack {
                Id = 804,
                Name = "R1 (3rd)",
                Damage = 1.02m,
                ExtraDamage = 0.0m,
                ExtraDamageCount = 0,
                AttackType1 = AttackType.Physical,
                AttackType2 = AttackType.None,
                AttackMode = AttackMode.Transformed,
                TricksterWeaponId = 20
            },
            
            new Attack {
                Id = 805,
                Name = "R1 (backstep)",
                Damage = 0.95m,
                ExtraDamage = 0.0m,
                ExtraDamageCount = 0,
                AttackType1 = AttackType.Physical,
                AttackType2 = AttackType.None,
                AttackMode = AttackMode.Transformed,
                TricksterWeaponId = 20
            },
            
            new Attack {
                Id = 806,
                Name = "R1 (rolling)",
                Damage = 0.95m,
                ExtraDamage = 0.0m,
                ExtraDamageCount = 0,
                AttackType1 = AttackType.Physical,
                AttackType2 = AttackType.None,
                AttackMode = AttackMode.Transformed,
                TricksterWeaponId = 20
            },
            
            new Attack {
                Id = 807,
                Name = "R1 (frontstep)",
                Damage = 0.95m,
                ExtraDamage = 0.0m,
                ExtraDamageCount = 0,
                AttackType1 = AttackType.Physical,
                AttackType2 = AttackType.None,
                AttackMode = AttackMode.Transformed,
                TricksterWeaponId = 20
            },
            
            new Attack {
                Id = 808,
                Name = "R1 (sidestep)",
                Damage = 1.0m,
                ExtraDamage = 0.0m,
                ExtraDamageCount = 0,
                AttackType1 = AttackType.Physical,
                AttackType2 = AttackType.None,
                AttackMode = AttackMode.Transformed,
                TricksterWeaponId = 20
            },
            
            new Attack {
                Id = 809,
                Name = "R1 (dash)",
                Damage = 1.15m,
                ExtraDamage = 0.0m,
                ExtraDamageCount = 0,
                AttackType1 = AttackType.Physical,
                AttackType2 = AttackType.None,
                AttackMode = AttackMode.Transformed,
                TricksterWeaponId = 20
            },
            
            new Attack {
                Id = 810,
                Name = "R2",
                Damage = 1.25m,
                ExtraDamage = 0.0m,
                ExtraDamageCount = 0,
                AttackType1 = AttackType.Physical,
                AttackType2 = AttackType.None,
                AttackMode = AttackMode.Transformed,
                TricksterWeaponId = 20
            },
            
            new Attack {
                Id = 811,
                Name = "R2 (2nd)",
                Damage = 1.27m,
                ExtraDamage = 0.0m,
                ExtraDamageCount = 0,
                AttackType1 = AttackType.Physical,
                AttackType2 = AttackType.None,
                AttackMode = AttackMode.Transformed,
                TricksterWeaponId = 20
            },
            
            new Attack {
                Id = 812,
                Name = "R2 (charged)",
                Damage = 1.7m,
                ExtraDamage = 0.0m,
                ExtraDamageCount = 0,
                AttackType1 = AttackType.Physical,
                AttackType2 = AttackType.None,
                AttackMode = AttackMode.Transformed,
                TricksterWeaponId = 20
            },
            
            new Attack {
                Id = 813,
                Name = "R2 (charged followup)",
                Damage = 1.27m,
                ExtraDamage = 0.0m,
                ExtraDamageCount = 0,
                AttackType1 = AttackType.Physical,
                AttackType2 = AttackType.None,
                AttackMode = AttackMode.Transformed,
                TricksterWeaponId = 20
            },
            
            new Attack {
                Id = 814,
                Name = "R2 (backstep)",
                Damage = 1.1m,
                ExtraDamage = 0.0m,
                ExtraDamageCount = 0,
                AttackType1 = AttackType.Physical,
                AttackType2 = AttackType.None,
                AttackMode = AttackMode.Transformed,
                TricksterWeaponId = 20
            },
            
            new Attack {
                Id = 815,
                Name = "R2 (dash)",
                Damage = 1.2m,
                ExtraDamage = 0.0m,
                ExtraDamageCount = 0,
                AttackType1 = AttackType.Physical,
                AttackType2 = AttackType.None,
                AttackMode = AttackMode.Transformed,
                TricksterWeaponId = 20
            },
            
            new Attack {
                Id = 816,
                Name = "R2(forward leap)",
                Damage = 1.3m,
                ExtraDamage = 0.0m,
                ExtraDamageCount = 0,
                AttackType1 = AttackType.Physical,
                AttackType2 = AttackType.None,
                AttackMode = AttackMode.Transformed,
                TricksterWeaponId = 20
            },
            
            new Attack {
                Id = 817,
                Name = "Transform Attack",
                Damage = 1.3m,
                ExtraDamage = 0.0m,
                ExtraDamageCount = 0,
                AttackType1 = AttackType.Physical,
                AttackType2 = AttackType.None,
                AttackMode = AttackMode.Transformed,
                TricksterWeaponId = 20
            },
            
            new Attack {
                Id = 818,
                Name = "Plunge Attack",
                Damage = 1.4m,
                ExtraDamage = 0.0m,
                ExtraDamageCount = 0,
                AttackType1 = AttackType.Physical,
                AttackType2 = AttackType.None,
                AttackMode = AttackMode.Transformed,
                TricksterWeaponId = 20
            },
            
            new Attack {
                Id = 819,
                Name = "Plunge Attack (2nd)",
                Damage = 0.9m,
                ExtraDamage = 0.0m,
                ExtraDamageCount = 0,
                AttackType1 = AttackType.Blunt,
                AttackType2 = AttackType.None,
                AttackMode = AttackMode.Transformed,
                TricksterWeaponId = 20
            },
            
            new Attack {
                Id = 820,
                Name = "R1",
                Damage = 1.0m,
                ExtraDamage = 0.0m,
                ExtraDamageCount = 0,
                AttackType1 = AttackType.Physical,
                AttackType2 = AttackType.None,
                AttackMode = AttackMode.Normal,
                TricksterWeaponId = 21
            },
            
            new Attack {
                Id = 821,
                Name = "R1 (2nd)",
                Damage = 1.02m,
                ExtraDamage = 0.0m,
                ExtraDamageCount = 0,
                AttackType1 = AttackType.Physical,
                AttackType2 = AttackType.None,
                AttackMode = AttackMode.Normal,
                TricksterWeaponId = 21
            },
            
            new Attack {
                Id = 822,
                Name = "R1 (3rd)",
                Damage = 1.04m,
                ExtraDamage = 0.0m,
                ExtraDamageCount = 0,
                AttackType1 = AttackType.Physical,
                AttackType2 = AttackType.None,
                AttackMode = AttackMode.Normal,
                TricksterWeaponId = 21
            },
            
            new Attack {
                Id = 823,
                Name = "R1 (4th)",
                Damage = 1.06m,
                ExtraDamage = 0.0m,
                ExtraDamageCount = 0,
                AttackType1 = AttackType.Physical,
                AttackType2 = AttackType.None,
                AttackMode = AttackMode.Normal,
                TricksterWeaponId = 21
            },
            
            new Attack {
                Id = 824,
                Name = "R1 (5th)",
                Damage = 1.09m,
                ExtraDamage = 0.0m,
                ExtraDamageCount = 0,
                AttackType1 = AttackType.Physical,
                AttackType2 = AttackType.None,
                AttackMode = AttackMode.Normal,
                TricksterWeaponId = 21
            },
            
            new Attack {
                Id = 825,
                Name = "R1 (backstep)",
                Damage = 0.95m,
                ExtraDamage = 0.0m,
                ExtraDamageCount = 0,
                AttackType1 = AttackType.Physical,
                AttackType2 = AttackType.None,
                AttackMode = AttackMode.Normal,
                TricksterWeaponId = 21
            },
            
            new Attack {
                Id = 826,
                Name = "R1 (rolling)",
                Damage = 0.95m,
                ExtraDamage = 0.0m,
                ExtraDamageCount = 0,
                AttackType1 = AttackType.Physical,
                AttackType2 = AttackType.None,
                AttackMode = AttackMode.Normal,
                TricksterWeaponId = 21
            },
            
            new Attack {
                Id = 827,
                Name = "R1 (frontstep)",
                Damage = 0.95m,
                ExtraDamage = 0.0m,
                ExtraDamageCount = 0,
                AttackType1 = AttackType.Physical,
                AttackType2 = AttackType.None,
                AttackMode = AttackMode.Normal,
                TricksterWeaponId = 21
            },
            
            new Attack {
                Id = 828,
                Name = "R1 (sidestep)",
                Damage = 1.0m,
                ExtraDamage = 0.0m,
                ExtraDamageCount = 0,
                AttackType1 = AttackType.Physical,
                AttackType2 = AttackType.None,
                AttackMode = AttackMode.Normal,
                TricksterWeaponId = 21
            },
            
            new Attack {
                Id = 829,
                Name = "R1 (dash)",
                Damage = 1.09m,
                ExtraDamage = 0.0m,
                ExtraDamageCount = 0,
                AttackType1 = AttackType.Physical,
                AttackType2 = AttackType.None,
                AttackMode = AttackMode.Normal,
                TricksterWeaponId = 21
            },
            
            new Attack {
                Id = 830,
                Name = "R2",
                Damage = 1.2m,
                ExtraDamage = 0.0m,
                ExtraDamageCount = 0,
                AttackType1 = AttackType.Physical,
                AttackType2 = AttackType.None,
                AttackMode = AttackMode.Normal,
                TricksterWeaponId = 21
            },
            
            new Attack {
                Id = 831,
                Name = "R2 (charged)",
                Damage = 1.9m,
                ExtraDamage = 0.0m,
                ExtraDamageCount = 0,
                AttackType1 = AttackType.Physical,
                AttackType2 = AttackType.None,
                AttackMode = AttackMode.Normal,
                TricksterWeaponId = 21
            },
            
            new Attack {
                Id = 832,
                Name = "R2 (backstep)",
                Damage = 1.1m,
                ExtraDamage = 0.0m,
                ExtraDamageCount = 0,
                AttackType1 = AttackType.Physical,
                AttackType2 = AttackType.None,
                AttackMode = AttackMode.Normal,
                TricksterWeaponId = 21
            },
            
            new Attack {
                Id = 833,
                Name = "R2 (dash)",
                Damage = 1.25m,
                ExtraDamage = 0.0m,
                ExtraDamageCount = 0,
                AttackType1 = AttackType.Physical,
                AttackType2 = AttackType.None,
                AttackMode = AttackMode.Normal,
                TricksterWeaponId = 21
            },
            
            new Attack {
                Id = 834,
                Name = "R2 (forward leap)",
                Damage = 1.4m,
                ExtraDamage = 0.0m,
                ExtraDamageCount = 0,
                AttackType1 = AttackType.Physical,
                AttackType2 = AttackType.None,
                AttackMode = AttackMode.Normal,
                TricksterWeaponId = 21
            },
            
            new Attack {
                Id = 835,
                Name = "Transform Attack",
                Damage = 1.3m,
                ExtraDamage = 0.0m,
                ExtraDamageCount = 0,
                AttackType1 = AttackType.Physical,
                AttackType2 = AttackType.None,
                AttackMode = AttackMode.Normal,
                TricksterWeaponId = 21
            },
            
            new Attack {
                Id = 836,
                Name = "Plunge Attack",
                Damage = 1.4m,
                ExtraDamage = 0.0m,
                ExtraDamageCount = 0,
                AttackType1 = AttackType.Physical,
                AttackType2 = AttackType.None,
                AttackMode = AttackMode.Normal,
                TricksterWeaponId = 21
            },
            
            new Attack {
                Id = 837,
                Name = "Plunge Attack (2nd)",
                Damage = 0.9m,
                ExtraDamage = 0.0m,
                ExtraDamageCount = 0,
                AttackType1 = AttackType.Blunt,
                AttackType2 = AttackType.None,
                AttackMode = AttackMode.Normal,
                TricksterWeaponId = 21
            },
            
            new Attack {
                Id = 838,
                Name = "R1",
                Damage = 1.08m,
                ExtraDamage = 0.0m,
                ExtraDamageCount = 0,
                AttackType1 = AttackType.Physical,
                AttackType2 = AttackType.None,
                AttackMode = AttackMode.Transformed,
                TricksterWeaponId = 21
            },
            
            new Attack {
                Id = 839,
                Name = "R1 (2nd)",
                Damage = 1.1m,
                ExtraDamage = 0.0m,
                ExtraDamageCount = 0,
                AttackType1 = AttackType.Physical,
                AttackType2 = AttackType.None,
                AttackMode = AttackMode.Transformed,
                TricksterWeaponId = 21
            },
            
            new Attack {
                Id = 840,
                Name = "R1 (3rd)",
                Damage = 1.08m,
                ExtraDamage = 0.0m,
                ExtraDamageCount = 0,
                AttackType1 = AttackType.Physical,
                AttackType2 = AttackType.None,
                AttackMode = AttackMode.Transformed,
                TricksterWeaponId = 21
            },
            
            new Attack {
                Id = 841,
                Name = "R1 (4th)",
                Damage = 1.1m,
                ExtraDamage = 0.0m,
                ExtraDamageCount = 0,
                AttackType1 = AttackType.Physical,
                AttackType2 = AttackType.None,
                AttackMode = AttackMode.Transformed,
                TricksterWeaponId = 21
            },
            
            new Attack {
                Id = 842,
                Name = "R1 (backstep)",
                Damage = 0.91m,
                ExtraDamage = 0.0m,
                ExtraDamageCount = 0,
                AttackType1 = AttackType.Thrust,
                AttackType2 = AttackType.None,
                AttackMode = AttackMode.Transformed,
                TricksterWeaponId = 21
            },
            
            new Attack {
                Id = 843,
                Name = "R1 (rolling)",
                Damage = 1.08m,
                ExtraDamage = 0.0m,
                ExtraDamageCount = 0,
                AttackType1 = AttackType.Physical,
                AttackType2 = AttackType.None,
                AttackMode = AttackMode.Transformed,
                TricksterWeaponId = 21
            },
            
            new Attack {
                Id = 844,
                Name = "R1 (frontstep)",
                Damage = 1.08m,
                ExtraDamage = 0.0m,
                ExtraDamageCount = 0,
                AttackType1 = AttackType.Physical,
                AttackType2 = AttackType.None,
                AttackMode = AttackMode.Transformed,
                TricksterWeaponId = 21
            },
            
            new Attack {
                Id = 845,
                Name = "R1 (sidestep)",
                Damage = 1.08m,
                ExtraDamage = 0.0m,
                ExtraDamageCount = 0,
                AttackType1 = AttackType.Physical,
                AttackType2 = AttackType.None,
                AttackMode = AttackMode.Transformed,
                TricksterWeaponId = 21
            },
            
            new Attack {
                Id = 846,
                Name = "R1 (dash)",
                Damage = 0.88m,
                ExtraDamage = 0.0m,
                ExtraDamageCount = 0,
                AttackType1 = AttackType.Thrust,
                AttackType2 = AttackType.None,
                AttackMode = AttackMode.Transformed,
                TricksterWeaponId = 21
            },
            
            new Attack {
                Id = 847,
                Name = "R2",
                Damage = 1.33m,
                ExtraDamage = 0.0m,
                ExtraDamageCount = 0,
                AttackType1 = AttackType.Thrust,
                AttackType2 = AttackType.None,
                AttackMode = AttackMode.Transformed,
                TricksterWeaponId = 21
            },
            
            new Attack {
                Id = 848,
                Name = "R2 (charged)",
                Damage = 1.73m,
                ExtraDamage = 0.0m,
                ExtraDamageCount = 0,
                AttackType1 = AttackType.Thrust,
                AttackType2 = AttackType.None,
                AttackMode = AttackMode.Transformed,
                TricksterWeaponId = 21
            },
            
            new Attack {
                Id = 849,
                Name = "R2 (charged follow-up)",
                Damage = 1.53m,
                ExtraDamage = 0.0m,
                ExtraDamageCount = 0,
                AttackType1 = AttackType.Physical,
                AttackType2 = AttackType.None,
                AttackMode = AttackMode.Transformed,
                TricksterWeaponId = 21
            },
            
            new Attack {
                Id = 850,
                Name = "R2 (backstep)",
                Damage = 1.18m,
                ExtraDamage = 0.0m,
                ExtraDamageCount = 0,
                AttackType1 = AttackType.Physical,
                AttackType2 = AttackType.None,
                AttackMode = AttackMode.Transformed,
                TricksterWeaponId = 21
            },
            
            new Attack {
                Id = 851,
                Name = "R2 (dash)",
                Damage = 1.18m,
                ExtraDamage = 0.0m,
                ExtraDamageCount = 0,
                AttackType1 = AttackType.Physical,
                AttackType2 = AttackType.None,
                AttackMode = AttackMode.Transformed,
                TricksterWeaponId = 21
            },
            
            new Attack {
                Id = 852,
                Name = "R2(forward leap)",
                Damage = 1.33m,
                ExtraDamage = 0.0m,
                ExtraDamageCount = 0,
                AttackType1 = AttackType.Thrust,
                AttackType2 = AttackType.None,
                AttackMode = AttackMode.Transformed,
                TricksterWeaponId = 21
            },
            
            new Attack {
                Id = 853,
                Name = "Transform Attack",
                Damage = 1.23m,
                ExtraDamage = 0.0m,
                ExtraDamageCount = 0,
                AttackType1 = AttackType.Physical,
                AttackType2 = AttackType.None,
                AttackMode = AttackMode.Transformed,
                TricksterWeaponId = 21
            },
            
            new Attack {
                Id = 854,
                Name = "Plunge Attack",
                Damage = 1.43m,
                ExtraDamage = 0.0m,
                ExtraDamageCount = 0,
                AttackType1 = AttackType.Thrust,
                AttackType2 = AttackType.None,
                AttackMode = AttackMode.Transformed,
                TricksterWeaponId = 21
            },
            
            new Attack {
                Id = 855,
                Name = "Plunge Attack (2nd)",
                Damage = 0.83m,
                ExtraDamage = 0.0m,
                ExtraDamageCount = 0,
                AttackType1 = AttackType.Blunt,
                AttackType2 = AttackType.None,
                AttackMode = AttackMode.Transformed,
                TricksterWeaponId = 21
            },
            
            new Attack {
                Id = 856,
                Name = "R1",
                Damage = 1.0m,
                ExtraDamage = 0.0m,
                ExtraDamageCount = 0,
                AttackType1 = AttackType.Physical,
                AttackType2 = AttackType.None,
                AttackMode = AttackMode.Normal,
                TricksterWeaponId = 22
            },
            
            new Attack {
                Id = 857,
                Name = "R1 (2nd)",
                Damage = 1.02m,
                ExtraDamage = 0.0m,
                ExtraDamageCount = 0,
                AttackType1 = AttackType.Physical,
                AttackType2 = AttackType.None,
                AttackMode = AttackMode.Normal,
                TricksterWeaponId = 22
            },
            
            new Attack {
                Id = 858,
                Name = "R1 (3rd)",
                Damage = 1.04m,
                ExtraDamage = 0.0m,
                ExtraDamageCount = 0,
                AttackType1 = AttackType.Physical,
                AttackType2 = AttackType.None,
                AttackMode = AttackMode.Normal,
                TricksterWeaponId = 22
            },

            new Attack {
                Id = 859,
                Name = "R1 (4th)",
                Damage = 1.08m,
                ExtraDamage = 0.0m,
                ExtraDamageCount = 0,
                AttackType1 = AttackType.Thrust,
                AttackType2 = AttackType.None,
                AttackMode = AttackMode.Normal,
                TricksterWeaponId = 22
            },
            
            new Attack {
                Id = 860,
                Name = "R1 (backstep)",
                Damage = 1.05m,
                ExtraDamage = 0.0m,
                ExtraDamageCount = 0,
                AttackType1 = AttackType.Thrust,
                AttackType2 = AttackType.None,
                AttackMode = AttackMode.Normal,
                TricksterWeaponId = 22
            },
            
            new Attack {
                Id = 861,
                Name = "R1 (rolling)",
                Damage = 1.05m,
                ExtraDamage = 0.0m,
                ExtraDamageCount = 0,
                AttackType1 = AttackType.Physical,
                AttackType2 = AttackType.None,
                AttackMode = AttackMode.Normal,
                TricksterWeaponId = 22
            },
            
            new Attack {
                Id = 862,
                Name = "R1 (frontstep)",
                Damage = 1.05m,
                ExtraDamage = 0.0m,
                ExtraDamageCount = 0,
                AttackType1 = AttackType.Physical,
                AttackType2 = AttackType.None,
                AttackMode = AttackMode.Normal,
                TricksterWeaponId = 22
            },
            
            new Attack {
                Id = 863,
                Name = "R1 (sidestep)",
                Damage = 1.05m,
                ExtraDamage = 0.0m,
                ExtraDamageCount = 0,
                AttackType1 = AttackType.Physical,
                AttackType2 = AttackType.None,
                AttackMode = AttackMode.Normal,
                TricksterWeaponId = 22
            },
            
            new Attack {
                Id = 864,
                Name = "R1 (dash)",
                Damage = 1.1m,
                ExtraDamage = 0.0m,
                ExtraDamageCount = 0,
                AttackType1 = AttackType.Physical,
                AttackType2 = AttackType.None,
                AttackMode = AttackMode.Normal,
                TricksterWeaponId = 22
            },
            
            new Attack {
                Id = 865,
                Name = "R2",
                Damage = 1.3m,
                ExtraDamage = 0.0m,
                ExtraDamageCount = 0,
                AttackType1 = AttackType.Physical,
                AttackType2 = AttackType.None,
                AttackMode = AttackMode.Normal,
                TricksterWeaponId = 22
            },
            
            new Attack {
                Id = 866,
                Name = "R2 (charged)",
                Damage = 0.8m,
                ExtraDamage = 1.7m,
                ExtraDamageCount = 1,
                AttackType1 = AttackType.Physical,
                AttackType2 = AttackType.None,
                AttackMode = AttackMode.Normal,
                TricksterWeaponId = 22
            },
            
            new Attack {
                Id = 867,
                Name = "R2 (backstep)",
                Damage = 1.35m,
                ExtraDamage = 0.0m,
                ExtraDamageCount = 0,
                AttackType1 = AttackType.Physical,
                AttackType2 = AttackType.None,
                AttackMode = AttackMode.Normal,
                TricksterWeaponId = 22
            },
            
            new Attack {
                Id = 868,
                Name = "R2 (dash)",
                Damage = 1.3m,
                ExtraDamage = 0.0m,
                ExtraDamageCount = 0,
                AttackType1 = AttackType.Physical,
                AttackType2 = AttackType.None,
                AttackMode = AttackMode.Normal,
                TricksterWeaponId = 22
            },
            
            new Attack {
                Id = 869,
                Name = "R2 (forward leap)",
                Damage = 1.2m,
                ExtraDamage = 0.0m,
                ExtraDamageCount = 0,
                AttackType1 = AttackType.Physical,
                AttackType2 = AttackType.None,
                AttackMode = AttackMode.Normal,
                TricksterWeaponId = 22
            },
            
            new Attack {
                Id = 870,
                Name = "Transform Attack",
                Damage = 0.85m,
                ExtraDamage = 0.0m,
                ExtraDamageCount = 0,
                AttackType1 = AttackType.Blood,
                AttackType2 = AttackType.None,
                AttackMode = AttackMode.Normal,
                TricksterWeaponId = 22
            },
            
            new Attack {
                Id = 871,
                Name = "Plunge Attack",
                Damage = 1.5m,
                ExtraDamage = 0.0m,
                ExtraDamageCount = 0,
                AttackType1 = AttackType.Physical,
                AttackType2 = AttackType.None,
                AttackMode = AttackMode.Normal,
                TricksterWeaponId = 22
            },
            
            new Attack {
                Id = 872,
                Name = "Plunge Attack (2nd)",
                Damage = 0.9m,
                ExtraDamage = 0.0m,
                ExtraDamageCount = 0,
                AttackType1 = AttackType.Blunt,
                AttackType2 = AttackType.None,
                AttackMode = AttackMode.Normal,
                TricksterWeaponId = 22
            },
            
            new Attack {
                Id = 873,
                Name = "R1",
                Damage = 0.85m,
                ExtraDamage = 0.0m,
                ExtraDamageCount = 0,
                AttackType1 = AttackType.Blood,
                AttackType2 = AttackType.None,
                AttackMode = AttackMode.Transformed,
                TricksterWeaponId = 22
            },
            
            new Attack {
                Id = 874,
                Name = "R1 (backstep)",
                Damage = 0.85m,
                ExtraDamage = 0.0m,
                ExtraDamageCount = 0,
                AttackType1 = AttackType.Blood,
                AttackType2 = AttackType.None,
                AttackMode = AttackMode.Transformed,
                TricksterWeaponId = 22
            },
            
            new Attack {
                Id = 875,
                Name = "R2",
                Damage = 1.05m,
                ExtraDamage = 0.0m,
                ExtraDamageCount = 0,
                AttackType1 = AttackType.Blood,
                AttackType2 = AttackType.None,
                AttackMode = AttackMode.Transformed,
                TricksterWeaponId = 22
            },
            
            new Attack {
                Id = 876,
                Name = "R2 (charged)",
                Damage = 1.4m,
                ExtraDamage = 0.0m,
                ExtraDamageCount = 0,
                AttackType1 = AttackType.Blood,
                AttackType2 = AttackType.None,
                AttackMode = AttackMode.Transformed,
                TricksterWeaponId = 22
            },
            
            new Attack {
                Id = 877,
                Name = "R2 (forward leap)",
                Damage = 1.2m,
                ExtraDamage = 0.0m,
                ExtraDamageCount = 0,
                AttackType1 = AttackType.Physical,
                AttackType2 = AttackType.None,
                AttackMode = AttackMode.Transformed,
                TricksterWeaponId = 22
            },
            
            new Attack {
                Id = 878,
                Name = "L2",
                Damage = 0.7m,
                ExtraDamage = 0.0m,
                ExtraDamageCount = 0,
                AttackType1 = AttackType.Physical,
                AttackType2 = AttackType.None,
                AttackMode = AttackMode.Transformed,
                TricksterWeaponId = 22
            },
            
            new Attack {
                Id = 879,
                Name = "Transform Attack",
                Damage = 1.35m,
                ExtraDamage = 0.0m,
                ExtraDamageCount = 0,
                AttackType1 = AttackType.Thrust,
                AttackType2 = AttackType.None,
                AttackMode = AttackMode.Transformed,
                TricksterWeaponId = 22
            },
            
            new Attack {
                Id = 880,
                Name = "Plunge Attack",
                Damage = 1.4m,
                ExtraDamage = 0.0m,
                ExtraDamageCount = 0,
                AttackType1 = AttackType.Physical,
                AttackType2 = AttackType.None,
                AttackMode = AttackMode.Transformed,
                TricksterWeaponId = 22
            },
            
            new Attack {
                Id = 881,
                Name = "Plunge Attack (2nd)",
                Damage = 0.8m,
                ExtraDamage = 0.0m,
                ExtraDamageCount = 0,
                AttackType1 = AttackType.Blunt,
                AttackType2 = AttackType.None,
                AttackMode = AttackMode.Transformed,
                TricksterWeaponId = 22
            },
            
            new Attack {
                Id = 882,
                Name = "R1",
                Damage = 1.0m,
                ExtraDamage = 0.0m,
                ExtraDamageCount = 0,
                AttackType1 = AttackType.Physical,
                AttackType2 = AttackType.None,
                AttackMode = AttackMode.Normal,
                TricksterWeaponId = 23
            },
            
            new Attack {
                Id = 883,
                Name = "R1 (2nd)",
                Damage = 1.02m,
                ExtraDamage = 0.0m,
                ExtraDamageCount = 0,
                AttackType1 = AttackType.Physical,
                AttackType2 = AttackType.None,
                AttackMode = AttackMode.Normal,
                TricksterWeaponId = 23
            },
            
            new Attack {
                Id = 884,
                Name = "R1 (3rd)",
                Damage = 1.04m,
                ExtraDamage = 0.0m,
                ExtraDamageCount = 0,
                AttackType1 = AttackType.Physical,
                AttackType2 = AttackType.None,
                AttackMode = AttackMode.Normal,
                TricksterWeaponId = 23
            },
            
            new Attack {
                Id = 885,
                Name = "R1 (4th)",
                Damage = 1.07m,
                ExtraDamage = 0.0m,
                ExtraDamageCount = 0,
                AttackType1 = AttackType.Thrust,
                AttackType2 = AttackType.None,
                AttackMode = AttackMode.Normal,
                TricksterWeaponId = 23
            },
            
            new Attack {
                Id = 886,
                Name = "R1 (5th)",
                Damage = 1.1m,
                ExtraDamage = 0.0m,
                ExtraDamageCount = 0,
                AttackType1 = AttackType.Physical,
                AttackType2 = AttackType.None,
                AttackMode = AttackMode.Normal,
                TricksterWeaponId = 23
            },
            
            new Attack {
                Id = 887,
                Name = "R1 (backstep)",
                Damage = 0.95m,
                ExtraDamage = 0.0m,
                ExtraDamageCount = 0,
                AttackType1 = AttackType.Thrust,
                AttackType2 = AttackType.None,
                AttackMode = AttackMode.Normal,
                TricksterWeaponId = 23
            },
            
            new Attack {
                Id = 888,
                Name = "R1 (rolling)",
                Damage = 0.95m,
                ExtraDamage = 0.0m,
                ExtraDamageCount = 0,
                AttackType1 = AttackType.Physical,
                AttackType2 = AttackType.None,
                AttackMode = AttackMode.Normal,
                TricksterWeaponId = 23
            },
            
            new Attack {
                Id = 889,
                Name = "R1 (frontstep)",
                Damage = 0.95m,
                ExtraDamage = 0.0m,
                ExtraDamageCount = 0,
                AttackType1 = AttackType.Physical,
                AttackType2 = AttackType.None,
                AttackMode = AttackMode.Normal,
                TricksterWeaponId = 23
            },
            
            new Attack {
                Id = 890,
                Name = "R1 (sidestep)",
                Damage = 1.05m,
                ExtraDamage = 0.0m,
                ExtraDamageCount = 0,
                AttackType1 = AttackType.Physical,
                AttackType2 = AttackType.None,
                AttackMode = AttackMode.Normal,
                TricksterWeaponId = 23
            },
            
            new Attack {
                Id = 891,
                Name = "R1 (dash)",
                Damage = 1.1m,
                ExtraDamage = 0.0m,
                ExtraDamageCount = 0,
                AttackType1 = AttackType.Physical,
                AttackType2 = AttackType.None,
                AttackMode = AttackMode.Normal,
                TricksterWeaponId = 23
            },
            
            new Attack {
                Id = 892,
                Name = "R2",
                Damage = 1.35m,
                ExtraDamage = 0.0m,
                ExtraDamageCount = 0,
                AttackType1 = AttackType.Physical,
                AttackType2 = AttackType.None,
                AttackMode = AttackMode.Normal,
                TricksterWeaponId = 23
            },
            
            new Attack {
                Id = 893,
                Name = "R2 (charged)",
                Damage = 1.9m,
                ExtraDamage = 0.0m,
                ExtraDamageCount = 0,
                AttackType1 = AttackType.Physical,
                AttackType2 = AttackType.None,
                AttackMode = AttackMode.Normal,
                TricksterWeaponId = 23
            },
            
            new Attack {
                Id = 894,
                Name = "R2 (backstep)",
                Damage = 1.25m,
                ExtraDamage = 0.0m,
                ExtraDamageCount = 0,
                AttackType1 = AttackType.Physical,
                AttackType2 = AttackType.None,
                AttackMode = AttackMode.Normal,
                TricksterWeaponId = 23
            },
            
            new Attack {
                Id = 895,
                Name = "R2 (dash)",
                Damage = 1.25m,
                ExtraDamage = 0.0m,
                ExtraDamageCount = 0,
                AttackType1 = AttackType.Physical,
                AttackType2 = AttackType.None,
                AttackMode = AttackMode.Normal,
                TricksterWeaponId = 23
            },
            
            new Attack {
                Id = 896,
                Name = "R2 (forward leap)",
                Damage = 1.5m,
                ExtraDamage = 0.0m,
                ExtraDamageCount = 0,
                AttackType1 = AttackType.Thrust,
                AttackType2 = AttackType.None,
                AttackMode = AttackMode.Normal,
                TricksterWeaponId = 23
            },
            
            new Attack {
                Id = 897,
                Name = "Transform Attack",
                Damage = 1.1m,
                ExtraDamage = 0.0m,
                ExtraDamageCount = 0,
                AttackType1 = AttackType.Physical,
                AttackType2 = AttackType.None,
                AttackMode = AttackMode.Normal,
                TricksterWeaponId = 23
            },
            
            new Attack {
                Id = 898,
                Name = "Plunge Attack",
                Damage = 1.5m,
                ExtraDamage = 0.0m,
                ExtraDamageCount = 0,
                AttackType1 = AttackType.Thrust,
                AttackType2 = AttackType.None,
                AttackMode = AttackMode.Normal,
                TricksterWeaponId = 23
            },
            
            new Attack {
                Id = 899,
                Name = "Plunge Attack (2nd)",
                Damage = 0.9m,
                ExtraDamage = 0.0m,
                ExtraDamageCount = 0,
                AttackType1 = AttackType.Blunt,
                AttackType2 = AttackType.None,
                AttackMode = AttackMode.Normal,
                TricksterWeaponId = 23
            },
            
            new Attack {
                Id = 900,
                Name = "R1",
                Damage = 0.97m,
                ExtraDamage = 0.0m,
                ExtraDamageCount = 0,
                AttackType1 = AttackType.Physical,
                AttackType2 = AttackType.None,
                AttackMode = AttackMode.Transformed,
                TricksterWeaponId = 23
            },
            
            new Attack {
                Id = 901,
                Name = "R1 (2nd)",
                Damage = 1.0m,
                ExtraDamage = 0.0m,
                ExtraDamageCount = 0,
                AttackType1 = AttackType.Physical,
                AttackType2 = AttackType.None,
                AttackMode = AttackMode.Transformed,
                TricksterWeaponId = 23
            },
            
            new Attack {
                Id = 902,
                Name = "R1 (3rd)",
                Damage = 1.02m,
                ExtraDamage = 0.0m,
                ExtraDamageCount = 0,
                AttackType1 = AttackType.Physical,
                AttackType2 = AttackType.None,
                AttackMode = AttackMode.Transformed,
                TricksterWeaponId = 23
            },
            
            new Attack {
                Id = 903,
                Name = "R1 (4th)",
                Damage = 1.04m,
                ExtraDamage = 0.0m,
                ExtraDamageCount = 0,
                AttackType1 = AttackType.Physical,
                AttackType2 = AttackType.None,
                AttackMode = AttackMode.Transformed,
                TricksterWeaponId = 23
            },
            
            new Attack {
                Id = 904,
                Name = "R1 (backstep)",
                Damage = 0.9m,
                ExtraDamage = 0.0m,
                ExtraDamageCount = 0,
                AttackType1 = AttackType.Physical,
                AttackType2 = AttackType.None,
                AttackMode = AttackMode.Transformed,
                TricksterWeaponId = 23
            },
            
            new Attack {
                Id = 905,
                Name = "R1 (rolling)",
                Damage = 0.9m,
                ExtraDamage = 0.0m,
                ExtraDamageCount = 0,
                AttackType1 = AttackType.Physical,
                AttackType2 = AttackType.None,
                AttackMode = AttackMode.Transformed,
                TricksterWeaponId = 23
            },
            
            new Attack {
                Id = 906,
                Name = "R1 (frontstep)",
                Damage = 0.9m,
                ExtraDamage = 0.0m,
                ExtraDamageCount = 0,
                AttackType1 = AttackType.Physical,
                AttackType2 = AttackType.None,
                AttackMode = AttackMode.Transformed,
                TricksterWeaponId = 23
            },
            
            new Attack {
                Id = 907,
                Name = "R1 (sidestep)",
                Damage = 1.0m,
                ExtraDamage = 0.0m,
                ExtraDamageCount = 0,
                AttackType1 = AttackType.Physical,
                AttackType2 = AttackType.None,
                AttackMode = AttackMode.Transformed,
                TricksterWeaponId = 23
            },
            
            new Attack {
                Id = 908,
                Name = "R1 (dash)",
                Damage = 1.1m,
                ExtraDamage = 0.0m,
                ExtraDamageCount = 0,
                AttackType1 = AttackType.Physical,
                AttackType2 = AttackType.None,
                AttackMode = AttackMode.Transformed,
                TricksterWeaponId = 23
            },
            
            new Attack {
                Id = 909,
                Name = "R2",
                Damage = 1.37m,
                ExtraDamage = 0.0m,
                ExtraDamageCount = 0,
                AttackType1 = AttackType.Blunt,
                AttackType2 = AttackType.None,
                AttackMode = AttackMode.Transformed,
                TricksterWeaponId = 23
            },
            
            new Attack {
                Id = 910,
                Name = "R2 (charged)",
                Damage = 3.55m,
                ExtraDamage = 0.0m,
                ExtraDamageCount = 0,
                AttackType1 = AttackType.Blunt,
                AttackType2 = AttackType.None,
                AttackMode = AttackMode.Transformed,
                TricksterWeaponId = 23
            },
            
            new Attack {
                Id = 911,
                Name = "R2(forward leap)",
                Damage = 1.3m,
                ExtraDamage = 0.0m,
                ExtraDamageCount = 0,
                AttackType1 = AttackType.Blunt,
                AttackType2 = AttackType.None,
                AttackMode = AttackMode.Transformed,
                TricksterWeaponId = 23
            },
            
            new Attack {
                Id = 912,
                Name = "Transform Attack",
                Damage = 1.0m,
                ExtraDamage = 0.0m,
                ExtraDamageCount = 0,
                AttackType1 = AttackType.Physical,
                AttackType2 = AttackType.None,
                AttackMode = AttackMode.Transformed,
                TricksterWeaponId = 23
            },
            
            new Attack {
                Id = 913,
                Name = "Plunge Attack",
                Damage = 1.4m,
                ExtraDamage = 0.0m,
                ExtraDamageCount = 0,
                AttackType1 = AttackType.Physical,
                AttackType2 = AttackType.None,
                AttackMode = AttackMode.Transformed,
                TricksterWeaponId = 23
            },
            
            new Attack {
                Id = 914,
                Name = "Plunge Attack (2nd)",
                Damage = 0.9m,
                ExtraDamage = 0.0m,
                ExtraDamageCount = 0,
                AttackType1 = AttackType.Blunt,
                AttackType2 = AttackType.None,
                AttackMode = AttackMode.Transformed,
                TricksterWeaponId = 23
            },
            
            new Attack {
                Id = 915,
                Name = "R1",
                Damage = 1.0m,
                ExtraDamage = 0.0m,
                ExtraDamageCount = 0,
                AttackType1 = AttackType.Physical,
                AttackType2 = AttackType.None,
                AttackMode = AttackMode.Normal,
                TricksterWeaponId = 24
            },
            
            new Attack {
                Id = 916,
                Name = "R1 (2nd)",
                Damage = 1.02m,
                ExtraDamage = 0.0m,
                ExtraDamageCount = 0,
                AttackType1 = AttackType.Physical,
                AttackType2 = AttackType.None,
                AttackMode = AttackMode.Normal,
                TricksterWeaponId = 24
            },
            
            new Attack {
                Id = 917,
                Name = "R1 (3rd)",
                Damage = 1.04m,
                ExtraDamage = 0.0m,
                ExtraDamageCount = 0,
                AttackType1 = AttackType.Physical,
                AttackType2 = AttackType.None,
                AttackMode = AttackMode.Normal,
                TricksterWeaponId = 24
            },
            
            new Attack {
                Id = 918,
                Name = "R1 (backstep)",
                Damage = 1.05m,
                ExtraDamage = 0.0m,
                ExtraDamageCount = 0,
                AttackType1 = AttackType.Physical,
                AttackType2 = AttackType.None,
                AttackMode = AttackMode.Normal,
                TricksterWeaponId = 24
            },
            
            new Attack {
                Id = 919,
                Name = "R1 (rolling)",
                Damage = 1.05m,
                ExtraDamage = 0.0m,
                ExtraDamageCount = 0,
                AttackType1 = AttackType.Physical,
                AttackType2 = AttackType.None,
                AttackMode = AttackMode.Normal,
                TricksterWeaponId = 24
            },
            
            new Attack {
                Id = 920,
                Name = "R1 (frontstep)",
                Damage = 1.05m,
                ExtraDamage = 0.0m,
                ExtraDamageCount = 0,
                AttackType1 = AttackType.Physical,
                AttackType2 = AttackType.None,
                AttackMode = AttackMode.Normal,
                TricksterWeaponId = 24
            },
            
            new Attack {
                Id = 921,
                Name = "R1 (sidestep)",
                Damage = 1.05m,
                ExtraDamage = 0.0m,
                ExtraDamageCount = 0,
                AttackType1 = AttackType.Physical,
                AttackType2 = AttackType.None,
                AttackMode = AttackMode.Normal,
                TricksterWeaponId = 24
            },
            
            new Attack {
                Id = 922,
                Name = "R1 (dash)",
                Damage = 1.2m,
                ExtraDamage = 0.0m,
                ExtraDamageCount = 0,
                AttackType1 = AttackType.Physical,
                AttackType2 = AttackType.None,
                AttackMode = AttackMode.Normal,
                TricksterWeaponId = 24
            },
            
            new Attack {
                Id = 923,
                Name = "R2",
                Damage = 1.35m,
                ExtraDamage = 0.0m,
                ExtraDamageCount = 0,
                AttackType1 = AttackType.Thrust,
                AttackType2 = AttackType.None,
                AttackMode = AttackMode.Normal,
                TricksterWeaponId = 24
            },
            
            new Attack {
                Id = 924,
                Name = "R2 (charged)",
                Damage = 1.9m,
                ExtraDamage = 0.0m,
                ExtraDamageCount = 0,
                AttackType1 = AttackType.Thrust,
                AttackType2 = AttackType.None,
                AttackMode = AttackMode.Normal,
                TricksterWeaponId = 24
            },
            
            new Attack {
                Id = 925,
                Name = "R2 (backstep)",
                Damage = 1.2m,
                ExtraDamage = 0.0m,
                ExtraDamageCount = 0,
                AttackType1 = AttackType.Thrust,
                AttackType2 = AttackType.None,
                AttackMode = AttackMode.Normal,
                TricksterWeaponId = 24
            },
            
            new Attack {
                Id = 926,
                Name = "R2 (dash)",
                Damage = 1.45m,
                ExtraDamage = 0.0m,
                ExtraDamageCount = 0,
                AttackType1 = AttackType.Thrust,
                AttackType2 = AttackType.None,
                AttackMode = AttackMode.Normal,
                TricksterWeaponId = 24
            },
            
            new Attack {
                Id = 927,
                Name = "R2 (forward leap)",
                Damage = 1.4m,
                ExtraDamage = 0.0m,
                ExtraDamageCount = 0,
                AttackType1 = AttackType.Thrust,
                AttackType2 = AttackType.None,
                AttackMode = AttackMode.Normal,
                TricksterWeaponId = 24
            },
            
            new Attack {
                Id = 928,
                Name = "Transform Attack",
                Damage = 1.2m,
                ExtraDamage = 0.0m,
                ExtraDamageCount = 0,
                AttackType1 = AttackType.Physical,
                AttackType2 = AttackType.None,
                AttackMode = AttackMode.Normal,
                TricksterWeaponId = 24
            },
            
            new Attack {
                Id = 929,
                Name = "Plunge Attack",
                Damage = 1.4m,
                ExtraDamage = 0.0m,
                ExtraDamageCount = 0,
                AttackType1 = AttackType.Physical,
                AttackType2 = AttackType.None,
                AttackMode = AttackMode.Normal,
                TricksterWeaponId = 24
            },
            
            new Attack {
                Id = 930,
                Name = "Plunge Attack (2nd)",
                Damage = 0.9m,
                ExtraDamage = 0.0m,
                ExtraDamageCount = 0,
                AttackType1 = AttackType.Blunt,
                AttackType2 = AttackType.None,
                AttackMode = AttackMode.Normal,
                TricksterWeaponId = 24
            },
            
            new Attack {
                Id = 931,
                Name = "R1",
                Damage = 0.95m,
                ExtraDamage = 0.0m,
                ExtraDamageCount = 0,
                AttackType1 = AttackType.Physical,
                AttackType2 = AttackType.None,
                AttackMode = AttackMode.Transformed,
                TricksterWeaponId = 24
            },
            
            new Attack {
                Id = 932,
                Name = "R1 (2nd)",
                Damage = 0.98m,
                ExtraDamage = 0.0m,
                ExtraDamageCount = 0,
                AttackType1 = AttackType.Physical,
                AttackType2 = AttackType.None,
                AttackMode = AttackMode.Transformed,
                TricksterWeaponId = 24
            },
            
            new Attack {
                Id = 933,
                Name = "R1 (3rd)",
                Damage = 1.0m,
                ExtraDamage = 0.0m,
                ExtraDamageCount = 0,
                AttackType1 = AttackType.Physical,
                AttackType2 = AttackType.None,
                AttackMode = AttackMode.Transformed,
                TricksterWeaponId = 24
            },
            
            new Attack {
                Id = 934,
                Name = "R1 (backstep)",
                Damage = 1.0m,
                ExtraDamage = 0.0m,
                ExtraDamageCount = 0,
                AttackType1 = AttackType.Thrust,
                AttackType2 = AttackType.None,
                AttackMode = AttackMode.Transformed,
                TricksterWeaponId = 24
            },
            
            new Attack {
                Id = 935,
                Name = "R1 (rolling)",
                Damage = 0.9m,
                ExtraDamage = 0.0m,
                ExtraDamageCount = 0,
                AttackType1 = AttackType.Physical,
                AttackType2 = AttackType.None,
                AttackMode = AttackMode.Transformed,
                TricksterWeaponId = 24
            },
            
            new Attack {
                Id = 936,
                Name = "R1 (frontstep)",
                Damage = 0.9m,
                ExtraDamage = 0.0m,
                ExtraDamageCount = 0,
                AttackType1 = AttackType.Physical,
                AttackType2 = AttackType.None,
                AttackMode = AttackMode.Transformed,
                TricksterWeaponId = 24
            },
            
            new Attack {
                Id = 937,
                Name = "R1 (sidestep)",
                Damage = 0.9m,
                ExtraDamage = 0.0m,
                ExtraDamageCount = 0,
                AttackType1 = AttackType.Physical,
                AttackType2 = AttackType.None,
                AttackMode = AttackMode.Transformed,
                TricksterWeaponId = 24
            },
            
            new Attack {
                Id = 938,
                Name = "R1 (dash)",
                Damage = 1.1m,
                ExtraDamage = 0.0m,
                ExtraDamageCount = 0,
                AttackType1 = AttackType.Physical,
                AttackType2 = AttackType.None,
                AttackMode = AttackMode.Transformed,
                TricksterWeaponId = 24
            },
            
            new Attack {
                Id = 939,
                Name = "R2",
                Damage = 1.25m,
                ExtraDamage = 0.0m,
                ExtraDamageCount = 0,
                AttackType1 = AttackType.Physical,
                AttackType2 = AttackType.None,
                AttackMode = AttackMode.Transformed,
                TricksterWeaponId = 24
            },
            
            new Attack {
                Id = 940,
                Name = "R2 (2nd)",
                Damage = 1.25m,
                ExtraDamage = 0.0m,
                ExtraDamageCount = 0,
                AttackType1 = AttackType.Physical,
                AttackType2 = AttackType.None,
                AttackMode = AttackMode.Transformed,
                TricksterWeaponId = 24
            },
            
            new Attack {
                Id = 941,
                Name = "R2 (backstep)",
                Damage = 1.2m,
                ExtraDamage = 0.0m,
                ExtraDamageCount = 0,
                AttackType1 = AttackType.Thrust,
                AttackType2 = AttackType.None,
                AttackMode = AttackMode.Transformed,
                TricksterWeaponId = 24
            },
            
            new Attack {
                Id = 942,
                Name = "R2 (dash)",
                Damage = 1.3m,
                ExtraDamage = 0.0m,
                ExtraDamageCount = 0,
                AttackType1 = AttackType.Physical,
                AttackType2 = AttackType.None,
                AttackMode = AttackMode.Transformed,
                TricksterWeaponId = 24
            },
            
            new Attack {
                Id = 943,
                Name = "R2(forward leap)",
                Damage = 1.3m,
                ExtraDamage = 0.0m,
                ExtraDamageCount = 0,
                AttackType1 = AttackType.Physical,
                AttackType2 = AttackType.None,
                AttackMode = AttackMode.Transformed,
                TricksterWeaponId = 24
            },
            
            new Attack {
                Id = 944,
                Name = "Transform Attack",
                Damage = 1.2m,
                ExtraDamage = 0.0m,
                ExtraDamageCount = 0,
                AttackType1 = AttackType.Thrust,
                AttackType2 = AttackType.None,
                AttackMode = AttackMode.Transformed,
                TricksterWeaponId = 24
            },
            
            new Attack {
                Id = 945,
                Name = "Plunge Attack",
                Damage = 1.4m,
                ExtraDamage = 0.0m,
                ExtraDamageCount = 0,
                AttackType1 = AttackType.Physical,
                AttackType2 = AttackType.None,
                AttackMode = AttackMode.Transformed,
                TricksterWeaponId = 24
            },
            
            new Attack {
                Id = 946,
                Name = "Plunge Attack (2nd)",
                Damage = 0.9m,
                ExtraDamage = 0.0m,
                ExtraDamageCount = 0,
                AttackType1 = AttackType.Blunt,
                AttackType2 = AttackType.None,
                AttackMode = AttackMode.Transformed,
                TricksterWeaponId = 24
            },
            
            new Attack {
                Id = 947,
                Name = "R1",
                Damage = 1.0m,
                ExtraDamage = 0.0m,
                ExtraDamageCount = 0,
                AttackType1 = AttackType.Blunt,
                AttackType2 = AttackType.Bolt,
                AttackMode = AttackMode.Normal,
                TricksterWeaponId = 25
            },
            
            new Attack {
                Id = 948,
                Name = "R1 (2nd)",
                Damage = 1.02m,
                ExtraDamage = 0.0m,
                ExtraDamageCount = 0,
                AttackType1 = AttackType.Blunt,
                AttackType2 = AttackType.Bolt,
                AttackMode = AttackMode.Normal,
                TricksterWeaponId = 25
            },

            new Attack {
                Id = 949,
                Name = "R1 (3rd)",
                Damage = 1.04m,
                ExtraDamage = 0.0m,
                ExtraDamageCount = 0,
                AttackType1 = AttackType.Blunt,
                AttackType2 = AttackType.Bolt,
                AttackMode = AttackMode.Normal,
                TricksterWeaponId = 25
            },
            
            new Attack {
                Id = 950,
                Name = "R1 (4th)",
                Damage = 1.06m,
                ExtraDamage = 0.0m,
                ExtraDamageCount = 0,
                AttackType1 = AttackType.Blunt,
                AttackType2 = AttackType.Bolt,
                AttackMode = AttackMode.Normal,
                TricksterWeaponId = 25
            },
            
            new Attack {
                Id = 951,
                Name = "R1 (5th)",
                Damage = 1.08m,
                ExtraDamage = 0.0m,
                ExtraDamageCount = 0,
                AttackType1 = AttackType.Blunt,
                AttackType2 = AttackType.Bolt,
                AttackMode = AttackMode.Normal,
                TricksterWeaponId = 25
            },
            
            new Attack {
                Id = 952,
                Name = "R1 (backstep)",
                Damage = 0.95m,
                ExtraDamage = 0.0m,
                ExtraDamageCount = 0,
                AttackType1 = AttackType.Blunt,
                AttackType2 = AttackType.Bolt,
                AttackMode = AttackMode.Normal,
                TricksterWeaponId = 25
            },
            
            new Attack {
                Id = 953,
                Name = "R1 (rolling)",
                Damage = 0.9m,
                ExtraDamage = 0.0m,
                ExtraDamageCount = 0,
                AttackType1 = AttackType.Blunt,
                AttackType2 = AttackType.Bolt,
                AttackMode = AttackMode.Normal,
                TricksterWeaponId = 25
            },
            
            new Attack {
                Id = 954,
                Name = "R1 (frontstep)",
                Damage = 0.9m,
                ExtraDamage = 0.0m,
                ExtraDamageCount = 0,
                AttackType1 = AttackType.Blunt,
                AttackType2 = AttackType.Bolt,
                AttackMode = AttackMode.Normal,
                TricksterWeaponId = 25
            },
            
            new Attack {
                Id = 955,
                Name = "R1 (sidestep)",
                Damage = 0.9m,
                ExtraDamage = 0.0m,
                ExtraDamageCount = 0,
                AttackType1 = AttackType.Blunt,
                AttackType2 = AttackType.Bolt,
                AttackMode = AttackMode.Normal,
                TricksterWeaponId = 25
            },
            
            new Attack {
                Id = 956,
                Name = "R1 (dash)",
                Damage = 1.05m,
                ExtraDamage = 0.0m,
                ExtraDamageCount = 0,
                AttackType1 = AttackType.Blunt,
                AttackType2 = AttackType.Bolt,
                AttackMode = AttackMode.Normal,
                TricksterWeaponId = 25
            },
            
            new Attack {
                Id = 957,
                Name = "R2",
                Damage = 1.2m,
                ExtraDamage = 0.0m,
                ExtraDamageCount = 0,
                AttackType1 = AttackType.Blunt,
                AttackType2 = AttackType.Bolt,
                AttackMode = AttackMode.Normal,
                TricksterWeaponId = 25
            },
            
            new Attack {
                Id = 958,
                Name = "R2 (charged)",
                Damage = 1.9m,
                ExtraDamage = 0.0m,
                ExtraDamageCount = 0,
                AttackType1 = AttackType.Blunt,
                AttackType2 = AttackType.Bolt,
                AttackMode = AttackMode.Normal,
                TricksterWeaponId = 25
            },
            
            new Attack {
                Id = 959,
                Name = "R2 (backstep)",
                Damage = 1.2m,
                ExtraDamage = 0.0m,
                ExtraDamageCount = 0,
                AttackType1 = AttackType.Blunt,
                AttackType2 = AttackType.Bolt,
                AttackMode = AttackMode.Normal,
                TricksterWeaponId = 25
            },
            
            new Attack {
                Id = 960,
                Name = "R2 (dash)",
                Damage = 1.15m,
                ExtraDamage = 0.0m,
                ExtraDamageCount = 0,
                AttackType1 = AttackType.Blunt,
                AttackType2 = AttackType.Bolt,
                AttackMode = AttackMode.Normal,
                TricksterWeaponId = 25
            },
            
            new Attack {
                Id = 961,
                Name = "R2 (forward leap)",
                Damage = 1.5m,
                ExtraDamage = 0.0m,
                ExtraDamageCount = 0,
                AttackType1 = AttackType.Blunt,
                AttackType2 = AttackType.Bolt,
                AttackMode = AttackMode.Normal,
                TricksterWeaponId = 25
            },
            
            new Attack {
                Id = 962,
                Name = "Transform Attack",
                Damage = 1.2m,
                ExtraDamage = 0.0m,
                ExtraDamageCount = 0,
                AttackType1 = AttackType.Blunt,
                AttackType2 = AttackType.Bolt,
                AttackMode = AttackMode.Normal,
                TricksterWeaponId = 25
            },
            
            new Attack {
                Id = 963,
                Name = "Plunge Attack",
                Damage = 1.5m,
                ExtraDamage = 0.0m,
                ExtraDamageCount = 0,
                AttackType1 = AttackType.Blunt,
                AttackType2 = AttackType.Bolt,
                AttackMode = AttackMode.Normal,
                TricksterWeaponId = 25
            },
            
            new Attack {
                Id = 964,
                Name = "Plunge Attack (2nd)",
                Damage = 0.9m,
                ExtraDamage = 0.0m,
                ExtraDamageCount = 0,
                AttackType1 = AttackType.Blunt,
                AttackType2 = AttackType.Bolt,
                AttackMode = AttackMode.Normal,
                TricksterWeaponId = 25
            },
            
            new Attack {
                Id = 965,
                Name = "R1",
                Damage = 0.75m,
                ExtraDamage = 0.0m,
                ExtraDamageCount = 0,
                AttackType1 = AttackType.Blunt,
                AttackType2 = AttackType.None,
                AttackMode = AttackMode.Normal,
                TricksterWeaponId = 26
            },
            
            new Attack {
                Id = 966,
                Name = "R1 (2nd)",
                Damage = 0.78m,
                ExtraDamage = 0.0m,
                ExtraDamageCount = 0,
                AttackType1 = AttackType.Blunt,
                AttackType2 = AttackType.None,
                AttackMode = AttackMode.Normal,
                TricksterWeaponId = 26
            },
            
            new Attack {
                Id = 967,
                Name = "R1 (3rd)",
                Damage = 0.81m,
                ExtraDamage = 0.0m,
                ExtraDamageCount = 0,
                AttackType1 = AttackType.Blunt,
                AttackType2 = AttackType.None,
                AttackMode = AttackMode.Normal,
                TricksterWeaponId = 26
            },
            
            new Attack {
                Id = 968,
                Name = "R1 (4th)",
                Damage = 0.85m,
                ExtraDamage = 0.0m,
                ExtraDamageCount = 0,
                AttackType1 = AttackType.Thrust,
                AttackType2 = AttackType.None,
                AttackMode = AttackMode.Normal,
                TricksterWeaponId = 26
            },
            
            new Attack {
                Id = 969,
                Name = "R1 (backstep)",
                Damage = 0.7m,
                ExtraDamage = 0.0m,
                ExtraDamageCount = 0,
                AttackType1 = AttackType.Thrust,
                AttackType2 = AttackType.None,
                AttackMode = AttackMode.Normal,
                TricksterWeaponId = 26
            },
            
            new Attack {
                Id = 970,
                Name = "R1 (rolling)",
                Damage = 0.7m,
                ExtraDamage = 0.0m,
                ExtraDamageCount = 0,
                AttackType1 = AttackType.Blunt,
                AttackType2 = AttackType.None,
                AttackMode = AttackMode.Normal,
                TricksterWeaponId = 26
            },
            
            new Attack {
                Id = 971,
                Name = "R1 (frontstep)",
                Damage = 0.7m,
                ExtraDamage = 0.0m,
                ExtraDamageCount = 0,
                AttackType1 = AttackType.Blunt,
                AttackType2 = AttackType.None,
                AttackMode = AttackMode.Normal,
                TricksterWeaponId = 26
            },
            
            new Attack {
                Id = 972,
                Name = "R1 (sidestep)",
                Damage = 0.7m,
                ExtraDamage = 0.0m,
                ExtraDamageCount = 0,
                AttackType1 = AttackType.Blunt,
                AttackType2 = AttackType.None,
                AttackMode = AttackMode.Normal,
                TricksterWeaponId = 26
            },
            
            new Attack {
                Id = 973,
                Name = "R1 (dash)",
                Damage = 0.85m,
                ExtraDamage = 0.0m,
                ExtraDamageCount = 0,
                AttackType1 = AttackType.Thrust,
                AttackType2 = AttackType.None,
                AttackMode = AttackMode.Normal,
                TricksterWeaponId = 26
            },
            
            new Attack {
                Id = 974,
                Name = "R2",
                Damage = 1.05m,
                ExtraDamage = 0.0m,
                ExtraDamageCount = 0,
                AttackType1 = AttackType.Blunt,
                AttackType2 = AttackType.None,
                AttackMode = AttackMode.Normal,
                TricksterWeaponId = 26
            },
            
            new Attack {
                Id = 975,
                Name = "R2 (charged)",
                Damage = 1.3m,
                ExtraDamage = 0.0m,
                ExtraDamageCount = 0,
                AttackType1 = AttackType.Blunt,
                AttackType2 = AttackType.None,
                AttackMode = AttackMode.Normal,
                TricksterWeaponId = 26
            },
            
            new Attack {
                Id = 976,
                Name = "R2 (backstep)",
                Damage = 1.0m,
                ExtraDamage = 0.0m,
                ExtraDamageCount = 0,
                AttackType1 = AttackType.Blunt,
                AttackType2 = AttackType.None,
                AttackMode = AttackMode.Normal,
                TricksterWeaponId = 26
            },
            
            new Attack {
                Id = 977,
                Name = "R2 (dash)",
                Damage = 1.15m,
                ExtraDamage = 0.0m,
                ExtraDamageCount = 0,
                AttackType1 = AttackType.Blunt,
                AttackType2 = AttackType.None,
                AttackMode = AttackMode.Normal,
                TricksterWeaponId = 26
            },
            
            new Attack {
                Id = 978,
                Name = "R2 (forward leap)",
                Damage = 1.2m,
                ExtraDamage = 0.0m,
                ExtraDamageCount = 0,
                AttackType1 = AttackType.Blunt,
                AttackType2 = AttackType.None,
                AttackMode = AttackMode.Normal,
                TricksterWeaponId = 26
            },
            
            new Attack {
                Id = 979,
                Name = "Transform Attack",
                Damage = 1.15m,
                ExtraDamage = 0.0m,
                ExtraDamageCount = 0,
                AttackType1 = AttackType.Physical,
                AttackType2 = AttackType.None,
                AttackMode = AttackMode.Normal,
                TricksterWeaponId = 26
            },
            
            new Attack {
                Id = 980,
                Name = "Plunge Attack",
                Damage = 1.2m,
                ExtraDamage = 0.0m,
                ExtraDamageCount = 0,
                AttackType1 = AttackType.Blunt,
                AttackType2 = AttackType.None,
                AttackMode = AttackMode.Normal,
                TricksterWeaponId = 26
            },
            
            new Attack {
                Id = 981,
                Name = "Plunge Attack (2nd)",
                Damage = 0.6m,
                ExtraDamage = 0.0m,
                ExtraDamageCount = 0,
                AttackType1 = AttackType.Blunt,
                AttackType2 = AttackType.None,
                AttackMode = AttackMode.Normal,
                TricksterWeaponId = 26
            },
            
            new Attack {
                Id = 982,
                Name = "R1",
                Damage = 1.0m,
                ExtraDamage = 0.0m,
                ExtraDamageCount = 0,
                AttackType1 = AttackType.Physical,
                AttackType2 = AttackType.None,
                AttackMode = AttackMode.Transformed,
                TricksterWeaponId = 26
            },
            
            new Attack {
                Id = 983,
                Name = "R1 (2nd)",
                Damage = 1.03m,
                ExtraDamage = 0.0m,
                ExtraDamageCount = 0,
                AttackType1 = AttackType.Physical,
                AttackType2 = AttackType.None,
                AttackMode = AttackMode.Transformed,
                TricksterWeaponId = 26
            },
            
            new Attack {
                Id = 984,
                Name = "R1 (3rd)",
                Damage = 1.12m,
                ExtraDamage = 0.0m,
                ExtraDamageCount = 0,
                AttackType1 = AttackType.Physical,
                AttackType2 = AttackType.None,
                AttackMode = AttackMode.Transformed,
                TricksterWeaponId = 26
            },
            
            new Attack {
                Id = 985,
                Name = "R1 (4th)",
                Damage = 1.15m,
                ExtraDamage = 0.3m,
                ExtraDamageCount = 2,
                AttackType1 = AttackType.Physical,
                AttackType2 = AttackType.None,
                AttackMode = AttackMode.Transformed,
                TricksterWeaponId = 26
            },
            
            new Attack {
                Id = 986,
                Name = "R1 (backstep)",
                Damage = 1.0m,
                ExtraDamage = 0.0m,
                ExtraDamageCount = 0,
                AttackType1 = AttackType.Physical,
                AttackType2 = AttackType.None,
                AttackMode = AttackMode.Transformed,
                TricksterWeaponId = 26
            },
            
            new Attack {
                Id = 987,
                Name = "R1 (rolling)",
                Damage = 0.95m,
                ExtraDamage = 0.0m,
                ExtraDamageCount = 0,
                AttackType1 = AttackType.Physical,
                AttackType2 = AttackType.None,
                AttackMode = AttackMode.Transformed,
                TricksterWeaponId = 26
            },
            
            new Attack {
                Id = 988,
                Name = "R1 (frontstep)",
                Damage = 0.95m,
                ExtraDamage = 0.0m,
                ExtraDamageCount = 0,
                AttackType1 = AttackType.Physical,
                AttackType2 = AttackType.None,
                AttackMode = AttackMode.Transformed,
                TricksterWeaponId = 26
            },
            
            new Attack {
                Id = 989,
                Name = "R1 (sidestep)",
                Damage = 0.95m,
                ExtraDamage = 0.0m,
                ExtraDamageCount = 0,
                AttackType1 = AttackType.Physical,
                AttackType2 = AttackType.None,
                AttackMode = AttackMode.Transformed,
                TricksterWeaponId = 26
            },
            
            new Attack {
                Id = 990,
                Name = "R1 (dash)",
                Damage = 1.08m,
                ExtraDamage = 0.0m,
                ExtraDamageCount = 0,
                AttackType1 = AttackType.Physical,
                AttackType2 = AttackType.None,
                AttackMode = AttackMode.Transformed,
                TricksterWeaponId = 26
            },
            
            new Attack {
                Id = 991,
                Name = "R2",
                Damage = 1.3m,
                ExtraDamage = 0.0m,
                ExtraDamageCount = 0,
                AttackType1 = AttackType.Physical,
                AttackType2 = AttackType.None,
                AttackMode = AttackMode.Transformed,
                TricksterWeaponId = 26
            },
            
            new Attack {
                Id = 992,
                Name = "R2 (charged)",
                Damage = 1.8m,
                ExtraDamage = 0.3m,
                ExtraDamageCount = 3,
                AttackType1 = AttackType.Blunt,
                AttackType2 = AttackType.None,
                AttackMode = AttackMode.Transformed,
                TricksterWeaponId = 26
            },
            
            new Attack {
                Id = 993,
                Name = "R2 (backstep)",
                Damage = 1.2m,
                ExtraDamage = 0.3m,
                ExtraDamageCount = 2,
                AttackType1 = AttackType.Blunt,
                AttackType2 = AttackType.None,
                AttackMode = AttackMode.Transformed,
                TricksterWeaponId = 26
            },
            
            new Attack {
                Id = 994,
                Name = "R2 (dash)",
                Damage = 1.4m,
                ExtraDamage = 0.0m,
                ExtraDamageCount = 0,
                AttackType1 = AttackType.Physical,
                AttackType2 = AttackType.None,
                AttackMode = AttackMode.Transformed,
                TricksterWeaponId = 26
            },
            
            new Attack {
                Id = 995,
                Name = "R2 (forward leap)",
                Damage = 1.5m,
                ExtraDamage = 0.3m,
                ExtraDamageCount = 2,
                AttackType1 = AttackType.Blunt,
                AttackType2 = AttackType.None,
                AttackMode = AttackMode.Transformed,
                TricksterWeaponId = 26
            },
            
            new Attack {
                Id = 996,
                Name = "L2",
                Damage = 0.8m,
                ExtraDamage = 0.0m,
                ExtraDamageCount = 0,
                AttackType1 = AttackType.Physical,
                AttackType2 = AttackType.None,
                AttackMode = AttackMode.Transformed,
                TricksterWeaponId = 26
            },
            
            new Attack {
                Id = 997,
                Name = "L2 (held 1)",
                Damage = 0.6m,
                ExtraDamage = 0.0m,
                ExtraDamageCount = 0,
                AttackType1 = AttackType.Physical,
                AttackType2 = AttackType.None,
                AttackMode = AttackMode.Transformed,
                TricksterWeaponId = 26
            },
            
            new Attack {
                Id = 998,
                Name = "L2 (held 2)",
                Damage = 0.3m,
                ExtraDamage = 0.0m,
                ExtraDamageCount = 0,
                AttackType1 = AttackType.Physical,
                AttackType2 = AttackType.None,
                AttackMode = AttackMode.Transformed,
                TricksterWeaponId = 26
            },
            
            new Attack {
                Id = 999,
                Name = "L2 (held 3)",
                Damage = 0.6m,
                ExtraDamage = 0.0m,
                ExtraDamageCount = 0,
                AttackType1 = AttackType.Physical,
                AttackType2 = AttackType.None,
                AttackMode = AttackMode.Transformed,
                TricksterWeaponId = 26
            },
            
            new Attack {
                Id = 1000,
                Name = "Transform Attack",
                Damage = 1.05m,
                ExtraDamage = 0.0m,
                ExtraDamageCount = 0,
                AttackType1 = AttackType.Blunt,
                AttackType2 = AttackType.None,
                AttackMode = AttackMode.Transformed,
                TricksterWeaponId = 26
            },
            
            new Attack {
                Id = 1001,
                Name = "Plunge Attack",
                Damage = 1.5m,
                ExtraDamage = 0.0m,
                ExtraDamageCount = 0,
                AttackType1 = AttackType.Physical,
                AttackType2 = AttackType.None,
                AttackMode = AttackMode.Transformed,
                TricksterWeaponId = 26
            },
            
            new Attack {
                Id = 1002,
                Name = "Plunge Attack (2nd)",
                Damage = 0.6m,
                ExtraDamage = 0.0m,
                ExtraDamageCount = 0,
                AttackType1 = AttackType.Blunt,
                AttackType2 = AttackType.None,
                AttackMode = AttackMode.Transformed,
                TricksterWeaponId = 26
            }
        };

        await _context.Attacks.AddRangeAsync(attacks);
        await _context.SaveChangesAsync();
    }

    private async Task SeedEchoesPerLevel()
    {
        var echoesPerLevel = new List<EchoesPerLevel>
        {
            new EchoesPerLevel
            {
                Id = 1,
                Level = 5,
                RequiredBloodEchoes = 724
            },

            new EchoesPerLevel
            {
                Id = 2,
                Level = 6,
                RequiredBloodEchoes = 741
            },
            
            new EchoesPerLevel
            {
                Id = 3,
                Level = 7,
                RequiredBloodEchoes = 758
            },
            
            new EchoesPerLevel
            {
                Id = 4,
                Level = 8,
                RequiredBloodEchoes = 775
            },
            
            new EchoesPerLevel
            {
                Id = 5,
                Level = 9,
                RequiredBloodEchoes = 793
            },
            
            new EchoesPerLevel
            {
                Id = 6,
                Level = 10,
                RequiredBloodEchoes = 811
            },
            
            new EchoesPerLevel
            {
                Id = 7,
                Level = 11,
                RequiredBloodEchoes = 829
            },
            
            new EchoesPerLevel
            {
                Id = 8,
                Level = 12,
                RequiredBloodEchoes = 847
            },
            
            new EchoesPerLevel
            {
                Id = 9,
                Level = 13,
                RequiredBloodEchoes = 1039
            },
            
            new EchoesPerLevel
            {
                Id = 10,
                Level = 14,
                RequiredBloodEchoes = 1238
            },
            
            new EchoesPerLevel
            {
                Id = 11,
                Level = 15,
                RequiredBloodEchoes = 1445
            },
            
            new EchoesPerLevel
            {
                Id = 12,
                Level = 16,
                RequiredBloodEchoes = 1660
            },
            
            new EchoesPerLevel
            {
                Id = 13,
                Level = 17,
                RequiredBloodEchoes = 1883
            },
            
            new EchoesPerLevel
            {
                Id = 14,
                Level = 18,
                RequiredBloodEchoes = 2114
            },
            
            new EchoesPerLevel
            {
                Id = 15,
                Level = 19,
                RequiredBloodEchoes = 2353
            },
            
            new EchoesPerLevel
            {
                Id = 16,
                Level = 20,
                RequiredBloodEchoes = 2601
            },
            
            new EchoesPerLevel
            {
                Id = 17,
                Level = 21,
                RequiredBloodEchoes = 2857
            },
            
            new EchoesPerLevel
            {
                Id = 18,
                Level = 22,
                RequiredBloodEchoes = 3122
            },
            
            new EchoesPerLevel
            {
                Id = 19,
                Level = 23,
                RequiredBloodEchoes = 3396
            },
            
            new EchoesPerLevel
            {
                Id = 20,
                Level = 24,
                RequiredBloodEchoes = 3678
            },
            
            new EchoesPerLevel
            {
                Id = 21,
                Level = 25,
                RequiredBloodEchoes = 3970
            },
            
            new EchoesPerLevel
            {
                Id = 22,
                Level = 26,
                RequiredBloodEchoes = 4271
            },
            
            new EchoesPerLevel
            {
                Id = 23,
                Level = 27,
                RequiredBloodEchoes = 4581
            },
            
            new EchoesPerLevel
            {
                Id = 24,
                Level = 28,
                RequiredBloodEchoes = 4900
            },
            
            new EchoesPerLevel
            {
                Id = 25,
                Level = 29,
                RequiredBloodEchoes = 5229
            },
            
            new EchoesPerLevel
            {
                Id = 26,
                Level = 30,
                RequiredBloodEchoes = 5567
            },
            
            new EchoesPerLevel
            {
                Id = 27,
                Level = 31,
                RequiredBloodEchoes = 5915
            },
            
            new EchoesPerLevel
            {
                Id = 28,
                Level = 32,
                RequiredBloodEchoes = 6273
            },
            
            new EchoesPerLevel
            {
                Id = 29,
                Level = 33,
                RequiredBloodEchoes = 6641
            },
            
            new EchoesPerLevel
            {
                Id = 30,
                Level = 34,
                RequiredBloodEchoes = 7019
            },
            
            new EchoesPerLevel
            {
                Id = 31,
                Level = 35,
                RequiredBloodEchoes = 7407
            },
            
            new EchoesPerLevel
            {
                Id = 32,
                Level = 36,
                RequiredBloodEchoes = 7805
            },
            
            new EchoesPerLevel
            {
                Id = 33,
                Level = 37,
                RequiredBloodEchoes = 8214
            },
            
            new EchoesPerLevel
            {
                Id = 34,
                Level = 38,
                RequiredBloodEchoes = 8634
            },
            
            new EchoesPerLevel
            {
                Id = 35,
                Level = 39,
                RequiredBloodEchoes = 9064
            },
            
            new EchoesPerLevel
            {
                Id = 36,
                Level = 40,
                RequiredBloodEchoes = 9505
            },
            
            new EchoesPerLevel
            {
                Id = 37,
                Level = 41,
                RequiredBloodEchoes = 9957
            },
            
            new EchoesPerLevel
            {
                Id = 38,
                Level = 42,
                RequiredBloodEchoes = 10420
            },
            
            new EchoesPerLevel
            {
                Id = 39,
                Level = 43,
                RequiredBloodEchoes = 10894
            },
            
            new EchoesPerLevel
            {
                Id = 40,
                Level = 44,
                RequiredBloodEchoes = 11379
            },
            
            new EchoesPerLevel
            {
                Id = 41,
                Level = 45,
                RequiredBloodEchoes = 11876
            },
            
            new EchoesPerLevel
            {
                Id = 42,
                Level = 46,
                RequiredBloodEchoes = 12384
            },
            
            new EchoesPerLevel
            {
                Id = 43,
                Level = 47,
                RequiredBloodEchoes = 12904
            },
            
            new EchoesPerLevel
            {
                Id = 44,
                Level = 48,
                RequiredBloodEchoes = 13436
            },
            
            new EchoesPerLevel
            {
                Id = 45,
                Level = 49,
                RequiredBloodEchoes = 13979
            },
            
            new EchoesPerLevel
            {
                Id = 46,
                Level = 50,
                RequiredBloodEchoes = 14535
            },
            
            new EchoesPerLevel
            {
                Id = 47,
                Level = 51,
                RequiredBloodEchoes = 15103
            },
            
            new EchoesPerLevel
            {
                Id = 48,
                Level = 52,
                RequiredBloodEchoes = 15683
            },
            
            new EchoesPerLevel
            {
                Id = 49,
                Level = 53,
                RequiredBloodEchoes = 16275
            },
            
            new EchoesPerLevel
            {
                Id = 50,
                Level = 54,
                RequiredBloodEchoes = 16880
            },
            
            new EchoesPerLevel
            {
                Id = 51,
                Level = 55,
                RequiredBloodEchoes = 17497
            },
            
            new EchoesPerLevel
            {
                Id = 52,
                Level = 56,
                RequiredBloodEchoes = 18127
            },
            
            new EchoesPerLevel
            {
                Id = 53,
                Level = 57,
                RequiredBloodEchoes = 18770
            },
            
            new EchoesPerLevel
            {
                Id = 54,
                Level = 58,
                RequiredBloodEchoes = 19426
            },
            
            new EchoesPerLevel
            {
                Id = 55,
                Level = 59,
                RequiredBloodEchoes = 20095
            },
            
            new EchoesPerLevel
            {
                Id = 56,
                Level = 60,
                RequiredBloodEchoes = 20777
            },
            
            new EchoesPerLevel
            {
                Id = 57,
                Level = 61,
                RequiredBloodEchoes = 21472
            },
            
            new EchoesPerLevel
            {
                Id = 58,
                Level = 62,
                RequiredBloodEchoes = 22181
            },
            
            new EchoesPerLevel
            {
                Id = 59,
                Level = 63,
                RequiredBloodEchoes = 22904
            },
            
            new EchoesPerLevel
            {
                Id = 60,
                Level = 64,
                RequiredBloodEchoes = 23640
            },
            
            new EchoesPerLevel
            {
                Id = 61,
                Level = 65,
                RequiredBloodEchoes = 24390
            },
            
            new EchoesPerLevel
            {
                Id = 62,
                Level = 66,
                RequiredBloodEchoes = 25154
            },
            
            new EchoesPerLevel
            {
                Id = 63,
                Level = 67,
                RequiredBloodEchoes = 25932
            },
            
            new EchoesPerLevel
            {
                Id = 64,
                Level = 68,
                RequiredBloodEchoes = 26724
            },
            
            new EchoesPerLevel
            {
                Id = 65,
                Level = 69,
                RequiredBloodEchoes = 27530
            },
            
            new EchoesPerLevel
            {
                Id = 66,
                Level = 70,
                RequiredBloodEchoes = 28351
            },

            new EchoesPerLevel
            {
                Id = 67,
                Level = 71,
                RequiredBloodEchoes = 29186
            },
            
            new EchoesPerLevel
            {
                Id = 68,
                Level = 72,
                RequiredBloodEchoes = 30036
            },
            
            new EchoesPerLevel
            {
                Id = 69,
                Level = 73,
                RequiredBloodEchoes = 30901
            },
            
            new EchoesPerLevel
            {
                Id = 70,
                Level = 74,
                RequiredBloodEchoes = 31780
            },
            
            new EchoesPerLevel
            {
                Id = 71,
                Level = 75,
                RequiredBloodEchoes = 32675
            },
            
            new EchoesPerLevel
            {
                Id = 72,
                Level = 76,
                RequiredBloodEchoes = 33585
            },
            
            new EchoesPerLevel
            {
                Id = 73,
                Level = 77,
                RequiredBloodEchoes = 34510
            },
            
            new EchoesPerLevel
            {
                Id = 74,
                Level = 78,
                RequiredBloodEchoes = 35450
            },
            
            new EchoesPerLevel
            {
                Id = 75,
                Level = 79,
                RequiredBloodEchoes = 36406
            },
            
            new EchoesPerLevel
            {
                Id = 76,
                Level = 80,
                RequiredBloodEchoes = 37377
            },
            
            new EchoesPerLevel
            {
                Id = 77,
                Level = 81,
                RequiredBloodEchoes = 38364
            },
            
            new EchoesPerLevel
            {
                Id = 78,
                Level = 82,
                RequiredBloodEchoes = 39367
            },
            
            new EchoesPerLevel
            {
                Id = 79,
                Level = 83,
                RequiredBloodEchoes = 40386
            },
            
            new EchoesPerLevel
            {
                Id = 80,
                Level = 84,
                RequiredBloodEchoes = 41421
            },
            
            new EchoesPerLevel
            {
                Id = 81,
                Level = 85,
                RequiredBloodEchoes = 42472
            },
            
            new EchoesPerLevel
            {
                Id = 82,
                Level = 86,
                RequiredBloodEchoes = 43539
            },
            
            new EchoesPerLevel
            {
                Id = 83,
                Level = 87,
                RequiredBloodEchoes = 44623
            },
            
            new EchoesPerLevel
            {
                Id = 84,
                Level = 88,
                RequiredBloodEchoes = 45724
            },
            
            new EchoesPerLevel
            {
                Id = 85,
                Level = 89,
                RequiredBloodEchoes = 46841
            },
            
            new EchoesPerLevel
            {
                Id = 86,
                Level = 90,
                RequiredBloodEchoes = 47975
            },
            
            new EchoesPerLevel
            {
                Id = 87,
                Level = 91,
                RequiredBloodEchoes = 49126
            },
            
            new EchoesPerLevel
            {
                Id = 88,
                Level = 92,
                RequiredBloodEchoes = 50294
            },
            
            new EchoesPerLevel
            {
                Id = 89,
                Level = 93,
                RequiredBloodEchoes = 51479
            },
            
            new EchoesPerLevel
            {
                Id = 90,
                Level = 94,
                RequiredBloodEchoes = 52681
            },
            
            new EchoesPerLevel
            {
                Id = 91,
                Level = 95,
                RequiredBloodEchoes = 53901
            },
            
            new EchoesPerLevel
            {
                Id = 92,
                Level = 96,
                RequiredBloodEchoes = 55138
            },
            
            new EchoesPerLevel
            {
                Id = 93,
                Level = 97,
                RequiredBloodEchoes = 56393
            },
            
            new EchoesPerLevel
            {
                Id = 94,
                Level = 98,
                RequiredBloodEchoes = 57666
            },
            
            new EchoesPerLevel
            {
                Id = 95,
                Level = 99,
                RequiredBloodEchoes = 58956
            },
            
            new EchoesPerLevel
            {
                Id = 96,
                Level = 100,
                RequiredBloodEchoes = 60265
            },
            
            new EchoesPerLevel
            {
                Id = 97,
                Level = 101,
                RequiredBloodEchoes = 61592
            },
            
            new EchoesPerLevel
            {
                Id = 98,
                Level = 102,
                RequiredBloodEchoes = 62937
            },
            
            new EchoesPerLevel
            {
                Id = 99,
                Level = 103,
                RequiredBloodEchoes = 64300
            },
            
            new EchoesPerLevel
            {
                Id = 100,
                Level = 104,
                RequiredBloodEchoes = 65682
            },
            
            new EchoesPerLevel
            {
                Id = 101,
                Level = 105,
                RequiredBloodEchoes = 67082
            },
            
            new EchoesPerLevel
            {
                Id = 102,
                Level = 106,
                RequiredBloodEchoes = 68501
            },
            
            new EchoesPerLevel
            {
                Id = 103,
                Level = 107,
                RequiredBloodEchoes = 69939
            },
            
            new EchoesPerLevel
            {
                Id = 104,
                Level = 108,
                RequiredBloodEchoes = 71396
            },
            
            new EchoesPerLevel
            {
                Id = 105,
                Level = 109,
                RequiredBloodEchoes = 72872
            },
            
            new EchoesPerLevel
            {
                Id = 106,
                Level = 110,
                RequiredBloodEchoes = 74367
            },
            
            new EchoesPerLevel
            {
                Id = 107,
                Level = 111,
                RequiredBloodEchoes = 75881
            },
            
            new EchoesPerLevel
            {
                Id = 108,
                Level = 112,
                RequiredBloodEchoes = 77415
            },
            
            new EchoesPerLevel
            {
                Id = 109,
                Level = 113,
                RequiredBloodEchoes = 78969
            },
            
            new EchoesPerLevel
            {
                Id = 110,
                Level = 114,
                RequiredBloodEchoes = 80542
            },

            new EchoesPerLevel
            {
                Id = 111,
                Level = 115,
                RequiredBloodEchoes = 82135
            },
            
            new EchoesPerLevel
            {
                Id = 112,
                Level = 116,
                RequiredBloodEchoes = 83748
            },
            
            new EchoesPerLevel
            {
                Id = 113,
                Level = 117,
                RequiredBloodEchoes = 85381
            },
            
            new EchoesPerLevel
            {
                Id = 114,
                Level = 118,
                RequiredBloodEchoes = 87034
            },
            
            new EchoesPerLevel
            {
                Id = 115,
                Level = 119,
                RequiredBloodEchoes = 88707
            },
            
            new EchoesPerLevel
            {
                Id = 116,
                Level = 120,
                RequiredBloodEchoes = 90401
            },
            
            new EchoesPerLevel
            {
                Id = 117,
                Level = 121,
                RequiredBloodEchoes = 92115
            },
            
            new EchoesPerLevel
            {
                Id = 118,
                Level = 122,
                RequiredBloodEchoes = 93850
            },
            
            new EchoesPerLevel
            {
                Id = 119,
                Level = 123,
                RequiredBloodEchoes = 95606
            },
            
            new EchoesPerLevel
            {
                Id = 120,
                Level = 124,
                RequiredBloodEchoes = 97382
            },
            
            new EchoesPerLevel
            {
                Id = 121,
                Level = 125,
                RequiredBloodEchoes = 99180
            },
            
            new EchoesPerLevel
            {
                Id = 122,
                Level = 126,
                RequiredBloodEchoes = 100999
            },
            
            new EchoesPerLevel
            {
                Id = 123,
                Level = 127,
                RequiredBloodEchoes = 102839
            },
            
            new EchoesPerLevel
            {
                Id = 124,
                Level = 128,
                RequiredBloodEchoes = 104700
            },
            
            new EchoesPerLevel
            {
                Id = 125,
                Level = 129,
                RequiredBloodEchoes = 106583
            },
            
            new EchoesPerLevel
            {
                Id = 126,
                Level = 130,
                RequiredBloodEchoes = 108487
            },
            
            new EchoesPerLevel
            {
                Id = 127,
                Level = 131,
                RequiredBloodEchoes = 110413
            },
            
            new EchoesPerLevel
            {
                Id = 128,
                Level = 132,
                RequiredBloodEchoes = 112361
            },
            
            new EchoesPerLevel
            {
                Id = 129,
                Level = 133,
                RequiredBloodEchoes = 114331
            },
            
            new EchoesPerLevel
            {
                Id = 130,
                Level = 134,
                RequiredBloodEchoes = 116323
            },
            
            new EchoesPerLevel
            {
                Id = 131,
                Level = 135,
                RequiredBloodEchoes = 118337
            },
            
            new EchoesPerLevel
            {
                Id = 132,
                Level = 136,
                RequiredBloodEchoes = 120373
            },
            
            new EchoesPerLevel
            {
                Id = 133,
                Level = 137,
                RequiredBloodEchoes = 122432
            },
            
            new EchoesPerLevel
            {
                Id = 134,
                Level = 138,
                RequiredBloodEchoes = 124514
            },
            
            new EchoesPerLevel
            {
                Id = 135,
                Level = 139,
                RequiredBloodEchoes = 126618
            },
            
            new EchoesPerLevel
            {
                Id = 136,
                Level = 140,
                RequiredBloodEchoes = 128745
            },
            
            new EchoesPerLevel
            {
                Id = 137,
                Level = 141,
                RequiredBloodEchoes = 130895
            },
            
            new EchoesPerLevel
            {
                Id = 138,
                Level = 142,
                RequiredBloodEchoes = 133068
            },
            
            new EchoesPerLevel
            {
                Id = 139,
                Level = 143,
                RequiredBloodEchoes = 135264
            },
            
            new EchoesPerLevel
            {
                Id = 140,
                Level = 144,
                RequiredBloodEchoes = 137483
            },
            
            new EchoesPerLevel
            {
                Id = 141,
                Level = 145,
                RequiredBloodEchoes = 139726
            },
            
            new EchoesPerLevel
            {
                Id = 142,
                Level = 146,
                RequiredBloodEchoes = 141992
            },
            
            new EchoesPerLevel
            {
                Id = 143,
                Level = 147,
                RequiredBloodEchoes = 144282
            },
            
            new EchoesPerLevel
            {
                Id = 144,
                Level = 148,
                RequiredBloodEchoes = 146596
            },
            
            new EchoesPerLevel
            {
                Id = 145,
                Level = 149,
                RequiredBloodEchoes = 148933
            },
            
            new EchoesPerLevel
            {
                Id = 146,
                Level = 150,
                RequiredBloodEchoes = 151295
            },
            
            new EchoesPerLevel
            {
                Id = 147,
                Level = 151,
                RequiredBloodEchoes = 153681
            },
            
            new EchoesPerLevel
            {
                Id = 148,
                Level = 152,
                RequiredBloodEchoes = 156091
            },
            
            new EchoesPerLevel
            {
                Id = 149,
                Level = 153,
                RequiredBloodEchoes = 158525
            },
            
            new EchoesPerLevel
            {
                Id = 150,
                Level = 154,
                RequiredBloodEchoes = 160984
            },
            
            new EchoesPerLevel
            {
                Id = 151,
                Level = 155,
                RequiredBloodEchoes = 163467
            },
            
            new EchoesPerLevel
            {
                Id = 152,
                Level = 156,
                RequiredBloodEchoes = 165975
            },
            
            new EchoesPerLevel
            {
                Id = 153,
                Level = 157,
                RequiredBloodEchoes = 168508
            },
            
            new EchoesPerLevel
            {
                Id = 154,
                Level = 158,
                RequiredBloodEchoes = 171066
            },
            
            new EchoesPerLevel
            {
                Id = 155,
                Level = 159,
                RequiredBloodEchoes = 173649
            },
            
            new EchoesPerLevel
            {
                Id = 156,
                Level = 160,
                RequiredBloodEchoes = 176257
            },
            
            new EchoesPerLevel
            {
                Id = 157,
                Level = 161,
                RequiredBloodEchoes = 178890
            },
            
            new EchoesPerLevel
            {
                Id = 158,
                Level = 162,
                RequiredBloodEchoes = 181549
            },
            
            new EchoesPerLevel
            {
                Id = 159,
                Level = 163,
                RequiredBloodEchoes = 184234
            },
            
            new EchoesPerLevel
            {
                Id = 160,
                Level = 164,
                RequiredBloodEchoes = 186944
            },
            
            new EchoesPerLevel
            {
                Id = 161,
                Level = 165,
                RequiredBloodEchoes = 189680
            },
            
            new EchoesPerLevel
            {
                Id = 162,
                Level = 166,
                RequiredBloodEchoes = 192442
            },
            
            new EchoesPerLevel
            {
                Id = 163,
                Level = 167,
                RequiredBloodEchoes = 195230
            },
            
            new EchoesPerLevel
            {
                Id = 164,
                Level = 168,
                RequiredBloodEchoes = 198044
            },
            
            new EchoesPerLevel
            {
                Id = 165,
                Level = 169,
                RequiredBloodEchoes = 200884
            },

            new EchoesPerLevel
            {
                Id = 166,
                Level = 170,
                RequiredBloodEchoes = 203751
            },
            
            new EchoesPerLevel
            {
                Id = 167,
                Level = 171,
                RequiredBloodEchoes = 206644
            },
            
            new EchoesPerLevel
            {
                Id = 168,
                Level = 172,
                RequiredBloodEchoes = 209564
            },
            
            new EchoesPerLevel
            {
                Id = 169,
                Level = 173,
                RequiredBloodEchoes = 212511
            },
            
            new EchoesPerLevel
            {
                Id = 170,
                Level = 174,
                RequiredBloodEchoes = 215484
            },
            
            new EchoesPerLevel
            {
                Id = 171,
                Level = 175,
                RequiredBloodEchoes = 218485
            },
            
            new EchoesPerLevel
            {
                Id = 172,
                Level = 176,
                RequiredBloodEchoes = 221513
            },
            
            new EchoesPerLevel
            {
                Id = 173,
                Level = 177,
                RequiredBloodEchoes = 224568
            },
            
            new EchoesPerLevel
            {
                Id = 174,
                Level = 178,
                RequiredBloodEchoes = 227650
            },
            
            new EchoesPerLevel
            {
                Id = 175,
                Level = 179,
                RequiredBloodEchoes = 230760
            },
            
            new EchoesPerLevel
            {
                Id = 176,
                Level = 180,
                RequiredBloodEchoes = 233897
            },
            
            new EchoesPerLevel
            {
                Id = 177,
                Level = 181,
                RequiredBloodEchoes = 237062
            },
            
            new EchoesPerLevel
            {
                Id = 178,
                Level = 182,
                RequiredBloodEchoes = 240255
            },
            
            new EchoesPerLevel
            {
                Id = 179,
                Level = 183,
                RequiredBloodEchoes = 243476
            },
            
            new EchoesPerLevel
            {
                Id = 180,
                Level = 184,
                RequiredBloodEchoes = 246725
            },
            
            new EchoesPerLevel
            {
                Id = 181,
                Level = 185,
                RequiredBloodEchoes = 250002
            },
            
            new EchoesPerLevel
            {
                Id = 182,
                Level = 186,
                RequiredBloodEchoes = 253307
            },
            
            new EchoesPerLevel
            {
                Id = 183,
                Level = 187,
                RequiredBloodEchoes = 256641
            },
            
            new EchoesPerLevel
            {
                Id = 184,
                Level = 188,
                RequiredBloodEchoes = 260004
            },
            
            new EchoesPerLevel
            {
                Id = 185,
                Level = 189,
                RequiredBloodEchoes = 263395
            },
            
            new EchoesPerLevel
            {
                Id = 186,
                Level = 190,
                RequiredBloodEchoes = 266815
            },
            
            new EchoesPerLevel
            {
                Id = 187,
                Level = 191,
                RequiredBloodEchoes = 270264
            },
            
            new EchoesPerLevel
            {
                Id = 188,
                Level = 192,
                RequiredBloodEchoes = 273742
            },
            
            new EchoesPerLevel
            {
                Id = 189,
                Level = 193,
                RequiredBloodEchoes = 277249
            },
            
            new EchoesPerLevel
            {
                Id = 190,
                Level = 194,
                RequiredBloodEchoes = 280785
            },
            
            new EchoesPerLevel
            {
                Id = 191,
                Level = 195,
                RequiredBloodEchoes = 284351
            },
            
            new EchoesPerLevel
            {
                Id = 192,
                Level = 196,
                RequiredBloodEchoes = 287946
            },
            
            new EchoesPerLevel
            {
                Id = 193,
                Level = 197,
                RequiredBloodEchoes = 291571
            },
            
            new EchoesPerLevel
            {
                Id = 194,
                Level = 198,
                RequiredBloodEchoes = 295226
            },
            
            new EchoesPerLevel
            {
                Id = 195,
                Level = 199,
                RequiredBloodEchoes = 298910
            },
            
            new EchoesPerLevel
            {
                Id = 196,
                Level = 200,
                RequiredBloodEchoes = 302625
            },
            
            new EchoesPerLevel
            {
                Id = 197,
                Level = 201,
                RequiredBloodEchoes = 306370
            },
            
            new EchoesPerLevel
            {
                Id = 198,
                Level = 202,
                RequiredBloodEchoes = 310145
            },
            
            new EchoesPerLevel
            {
                Id = 199,
                Level = 203,
                RequiredBloodEchoes = 313950
            },
            
            new EchoesPerLevel
            {
                Id = 200,
                Level = 204,
                RequiredBloodEchoes = 317786
            },
            
            new EchoesPerLevel
            {
                Id = 201,
                Level = 205,
                RequiredBloodEchoes = 321652
            },
            
            new EchoesPerLevel
            {
                Id = 202,
                Level = 206,
                RequiredBloodEchoes = 325549
            },
            
            new EchoesPerLevel
            {
                Id = 203,
                Level = 207,
                RequiredBloodEchoes = 329477
            },
            
            new EchoesPerLevel
            {
                Id = 204,
                Level = 208,
                RequiredBloodEchoes = 333436
            },
            
            new EchoesPerLevel
            {
                Id = 205,
                Level = 209,
                RequiredBloodEchoes = 337426
            },
            
            new EchoesPerLevel
            {
                Id = 206,
                Level = 210,
                RequiredBloodEchoes = 341447
            },
            
            new EchoesPerLevel
            {
                Id = 207,
                Level = 211,
                RequiredBloodEchoes = 345499
            },
            
            new EchoesPerLevel
            {
                Id = 208,
                Level = 212,
                RequiredBloodEchoes = 349583
            },
            
            new EchoesPerLevel
            {
                Id = 209,
                Level = 213,
                RequiredBloodEchoes = 353699
            },

            new EchoesPerLevel
            {
                Id = 210,
                Level = 214,
                RequiredBloodEchoes = 357846
            },
            
            new EchoesPerLevel
            {
                Id = 211,
                Level = 215,
                RequiredBloodEchoes = 362025
            },
            
            new EchoesPerLevel
            {
                Id = 212,
                Level = 216,
                RequiredBloodEchoes = 366236
            },
            
            new EchoesPerLevel
            {
                Id = 213,
                Level = 217,
                RequiredBloodEchoes = 370479
            },
            
            new EchoesPerLevel
            {
                Id = 214,
                Level = 218,
                RequiredBloodEchoes = 374754
            },
            
            new EchoesPerLevel
            {
                Id = 215,
                Level = 219,
                RequiredBloodEchoes = 379061
            },
            
            new EchoesPerLevel
            {
                Id = 216,
                Level = 220,
                RequiredBloodEchoes = 383401
            },
            
            new EchoesPerLevel
            {
                Id = 217,
                Level = 221,
                RequiredBloodEchoes = 387773
            },
            
            new EchoesPerLevel
            {
                Id = 218,
                Level = 222,
                RequiredBloodEchoes = 392178
            },
            
            new EchoesPerLevel
            {
                Id = 219,
                Level = 223,
                RequiredBloodEchoes = 396616
            },
            
            new EchoesPerLevel
            {
                Id = 220,
                Level = 224,
                RequiredBloodEchoes = 401086
            },
            
            new EchoesPerLevel
            {
                Id = 221,
                Level = 225,
                RequiredBloodEchoes = 405590
            },
            
            new EchoesPerLevel
            {
                Id = 222,
                Level = 226,
                RequiredBloodEchoes = 410127
            },
            
            new EchoesPerLevel
            {
                Id = 223,
                Level = 227,
                RequiredBloodEchoes = 414697
            },
            
            new EchoesPerLevel
            {
                Id = 224,
                Level = 228,
                RequiredBloodEchoes = 419300
            },
            
            new EchoesPerLevel
            {
                Id = 225,
                Level = 229,
                RequiredBloodEchoes = 423937
            },
            
            new EchoesPerLevel
            {
                Id = 226,
                Level = 230,
                RequiredBloodEchoes = 428607
            },
            
            new EchoesPerLevel
            {
                Id = 227,
                Level = 231,
                RequiredBloodEchoes = 433311
            },
            
            new EchoesPerLevel
            {
                Id = 228,
                Level = 232,
                RequiredBloodEchoes = 438049
            },
            
            new EchoesPerLevel
            {
                Id = 229,
                Level = 233,
                RequiredBloodEchoes = 442821
            },
            
            new EchoesPerLevel
            {
                Id = 230,
                Level = 234,
                RequiredBloodEchoes = 447627
            },
            
            new EchoesPerLevel
            {
                Id = 231,
                Level = 236,
                RequiredBloodEchoes = 457341
            },
            
            new EchoesPerLevel
            {
                Id = 232,
                Level = 237,
                RequiredBloodEchoes = 462250
            },
            
            new EchoesPerLevel
            {
                Id = 233,
                Level = 238,
                RequiredBloodEchoes = 467194
            },
            
            new EchoesPerLevel
            {
                Id = 234,
                Level = 239,
                RequiredBloodEchoes = 472172
            },
            
            new EchoesPerLevel
            {
                Id = 235,
                Level = 240,
                RequiredBloodEchoes = 477185
            },
            
            new EchoesPerLevel
            {
                Id = 236,
                Level = 241,
                RequiredBloodEchoes = 482233
            },
            
            new EchoesPerLevel
            {
                Id = 237,
                Level = 242,
                RequiredBloodEchoes = 487316
            },
            
            new EchoesPerLevel
            {
                Id = 238,
                Level = 243,
                RequiredBloodEchoes = 492434
            },
            
            new EchoesPerLevel
            {
                Id = 239,
                Level = 244,
                RequiredBloodEchoes = 497587
            },
            
            new EchoesPerLevel
            {
                Id = 240,
                Level = 245,
                RequiredBloodEchoes = 502776
            },
            
            new EchoesPerLevel
            {
                Id = 241,
                Level = 246,
                RequiredBloodEchoes = 508000
            },
            
            new EchoesPerLevel
            {
                Id = 242,
                Level = 247,
                RequiredBloodEchoes = 513260
            },
            
            new EchoesPerLevel
            {
                Id = 243,
                Level = 248,
                RequiredBloodEchoes = 518556
            },
            
            new EchoesPerLevel
            {
                Id = 244,
                Level = 249,
                RequiredBloodEchoes = 523887
            },
            
            new EchoesPerLevel
            {
                Id = 245,
                Level = 250,
                RequiredBloodEchoes = 529255
            },
            
            new EchoesPerLevel
            {
                Id = 246,
                Level = 251,
                RequiredBloodEchoes = 534659
            },
            
            new EchoesPerLevel
            {
                Id = 247,
                Level = 252,
                RequiredBloodEchoes = 540099
            },
            
            new EchoesPerLevel
            {
                Id = 248,
                Level = 253,
                RequiredBloodEchoes = 545575
            },
            
            new EchoesPerLevel
            {
                Id = 249,
                Level = 254,
                RequiredBloodEchoes = 551088
            },
            
            new EchoesPerLevel
            {
                Id = 250,
                Level = 255,
                RequiredBloodEchoes = 556637
            },
            
            new EchoesPerLevel
            {
                Id = 251,
                Level = 256,
                RequiredBloodEchoes = 562223
            },
            
            new EchoesPerLevel
            {
                Id = 252,
                Level = 257,
                RequiredBloodEchoes = 567846
            },
            
            new EchoesPerLevel
            {
                Id = 253,
                Level = 258,
                RequiredBloodEchoes = 573506
            },
            
            new EchoesPerLevel
            {
                Id = 254,
                Level = 259,
                RequiredBloodEchoes = 579203
            },
            
            new EchoesPerLevel
            {
                Id = 255,
                Level = 260,
                RequiredBloodEchoes = 584937
            },
            
            new EchoesPerLevel
            {
                Id = 256,
                Level = 261,
                RequiredBloodEchoes = 590709
            },
            
            new EchoesPerLevel
            {
                Id = 257,
                Level = 262,
                RequiredBloodEchoes = 596517
            },
            
            new EchoesPerLevel
            {
                Id = 258,
                Level = 263,
                RequiredBloodEchoes = 602364
            },
            
            new EchoesPerLevel
            {
                Id = 259,
                Level = 264,
                RequiredBloodEchoes = 608248
            },
            
            new EchoesPerLevel
            {
                Id = 260,
                Level = 265,
                RequiredBloodEchoes = 614170
            },
            
            new EchoesPerLevel
            {
                Id = 261,
                Level = 266,
                RequiredBloodEchoes = 620130
            },
            
            new EchoesPerLevel
            {
                Id = 262,
                Level = 267,
                RequiredBloodEchoes = 626128
            },
            
            new EchoesPerLevel
            {
                Id = 263,
                Level = 268,
                RequiredBloodEchoes = 632164
            },
            
            new EchoesPerLevel
            {
                Id = 264,
                Level = 269,
                RequiredBloodEchoes = 638238
            },
            
            new EchoesPerLevel
            {
                Id = 265,
                Level = 270,
                RequiredBloodEchoes = 644351
            },
            
            new EchoesPerLevel
            {
                Id = 266,
                Level = 271,
                RequiredBloodEchoes = 650502
            },
            
            new EchoesPerLevel
            {
                Id = 267,
                Level = 272,
                RequiredBloodEchoes = 656692
            },
            
            new EchoesPerLevel
            {
                Id = 268,
                Level = 273,
                RequiredBloodEchoes = 662921
            },
            
            new EchoesPerLevel
            {
                Id = 269,
                Level = 274,
                RequiredBloodEchoes = 669188
            },
            
            new EchoesPerLevel
            {
                Id = 270,
                Level = 275,
                RequiredBloodEchoes = 675495
            },
            
            new EchoesPerLevel
            {
                Id = 271,
                Level = 276,
                RequiredBloodEchoes = 681841
            },
            
            new EchoesPerLevel
            {
                Id = 272,
                Level = 277,
                RequiredBloodEchoes = 688226
            },
            
            new EchoesPerLevel
            {
                Id = 273,
                Level = 278,
                RequiredBloodEchoes = 694650
            },
            
            new EchoesPerLevel
            {
                Id = 274,
                Level = 279,
                RequiredBloodEchoes = 701114
            },
            
            new EchoesPerLevel
            {
                Id = 275,
                Level = 280,
                RequiredBloodEchoes = 707617
            },
            
            new EchoesPerLevel
            {
                Id = 276,
                Level = 281,
                RequiredBloodEchoes = 714160
            },
            
            new EchoesPerLevel
            {
                Id = 277,
                Level = 282,
                RequiredBloodEchoes = 720743
            },
            
            new EchoesPerLevel
            {
                Id = 278,
                Level = 283,
                RequiredBloodEchoes = 727366
            },
            
            new EchoesPerLevel
            {
                Id = 279,
                Level = 284,
                RequiredBloodEchoes = 734029
            },
            
            new EchoesPerLevel
            {
                Id = 280,
                Level = 285,
                RequiredBloodEchoes = 740732
            },
            
            new EchoesPerLevel
            {
                Id = 281,
                Level = 286,
                RequiredBloodEchoes = 747476
            },
            
            new EchoesPerLevel
            {
                Id = 282,
                Level = 287,
                RequiredBloodEchoes = 754259
            },
            
            new EchoesPerLevel
            {
                Id = 283,
                Level = 288,
                RequiredBloodEchoes = 761084
            },
            
            new EchoesPerLevel
            {
                Id = 284,
                Level = 289,
                RequiredBloodEchoes = 767949
            },
            
            new EchoesPerLevel
            {
                Id = 285,
                Level = 290,
                RequiredBloodEchoes = 774855
            },
            
            new EchoesPerLevel
            {
                Id = 286,
                Level = 291,
                RequiredBloodEchoes = 781802
            },
            
            new EchoesPerLevel
            {
                Id = 287,
                Level = 292,
                RequiredBloodEchoes = 788790
            },
            
            new EchoesPerLevel
            {
                Id = 288,
                Level = 293,
                RequiredBloodEchoes = 795819
            },

            new EchoesPerLevel
            {
                Id = 289,
                Level = 294,
                RequiredBloodEchoes = 802889
            },
            
            new EchoesPerLevel
            {
                Id = 290,
                Level = 295,
                RequiredBloodEchoes = 810001
            },
            
            new EchoesPerLevel
            {
                Id = 291,
                Level = 296,
                RequiredBloodEchoes = 817154
            },
            
            new EchoesPerLevel
            {
                Id = 292,
                Level = 297,
                RequiredBloodEchoes = 824349
            },
            
            new EchoesPerLevel
            {
                Id = 293,
                Level = 298,
                RequiredBloodEchoes = 831586
            },
            
            new EchoesPerLevel
            {
                Id = 294,
                Level = 299,
                RequiredBloodEchoes = 838864
            },
            
            new EchoesPerLevel
            {
                Id = 295,
                Level = 300,
                RequiredBloodEchoes = 846185
            },
            
            new EchoesPerLevel
            {
                Id = 296,
                Level = 301,
                RequiredBloodEchoes = 853548
            },
            
            new EchoesPerLevel
            {
                Id = 297,
                Level = 302,
                RequiredBloodEchoes = 860953
            },
            
            new EchoesPerLevel
            {
                Id = 298,
                Level = 303,
                RequiredBloodEchoes = 868400
            },
            
            new EchoesPerLevel
            {
                Id = 299,
                Level = 304,
                RequiredBloodEchoes = 875890
            },
            
            new EchoesPerLevel
            {
                Id = 300,
                Level = 305,
                RequiredBloodEchoes = 883422
            },
            
            new EchoesPerLevel
            {
                Id = 301,
                Level = 306,
                RequiredBloodEchoes = 890997
            },
            
            new EchoesPerLevel
            {
                Id = 302,
                Level = 307,
                RequiredBloodEchoes = 898615
            },
            
            new EchoesPerLevel
            {
                Id = 303,
                Level = 308,
                RequiredBloodEchoes = 906276
            },
            
            new EchoesPerLevel
            {
                Id = 304,
                Level = 309,
                RequiredBloodEchoes = 913980
            },
            
            new EchoesPerLevel
            {
                Id = 305,
                Level = 310,
                RequiredBloodEchoes = 921727
            },
            
            new EchoesPerLevel
            {
                Id = 306,
                Level = 311,
                RequiredBloodEchoes = 929517
            },
            
            new EchoesPerLevel
            {
                Id = 307,
                Level = 312,
                RequiredBloodEchoes = 937351
            },
            
            new EchoesPerLevel
            {
                Id = 308,
                Level = 313,
                RequiredBloodEchoes = 945229
            },
            
            new EchoesPerLevel
            {
                Id = 309,
                Level = 314,
                RequiredBloodEchoes = 953150
            },
            
            new EchoesPerLevel
            {
                Id = 310,
                Level = 315,
                RequiredBloodEchoes = 961115
            },
            
            new EchoesPerLevel
            {
                Id = 311,
                Level = 316,
                RequiredBloodEchoes = 969124
            },
            
            new EchoesPerLevel
            {
                Id = 312,
                Level = 317,
                RequiredBloodEchoes = 977177
            },
            
            new EchoesPerLevel
            {
                Id = 313,
                Level = 318,
                RequiredBloodEchoes = 985274
            },
            
            new EchoesPerLevel
            {
                Id = 314,
                Level = 319,
                RequiredBloodEchoes = 993415
            },
            
            new EchoesPerLevel
            {
                Id = 315,
                Level = 320,
                RequiredBloodEchoes = 1001601
            },
            
            new EchoesPerLevel
            {
                Id = 316,
                Level = 321,
                RequiredBloodEchoes = 1009831
            },
            
            new EchoesPerLevel
            {
                Id = 317,
                Level = 322,
                RequiredBloodEchoes = 1018106
            },
            
            new EchoesPerLevel
            {
                Id = 318,
                Level = 323,
                RequiredBloodEchoes = 1026426
            },
            
            new EchoesPerLevel
            {
                Id = 319,
                Level = 324,
                RequiredBloodEchoes = 1034790
            },
            
            new EchoesPerLevel
            {
                Id = 320,
                Level = 325,
                RequiredBloodEchoes = 1043200
            },
            
            new EchoesPerLevel
            {
                Id = 321,
                Level = 326,
                RequiredBloodEchoes = 1051655
            },
            
            new EchoesPerLevel
            {
                Id = 322,
                Level = 327,
                RequiredBloodEchoes = 1060155
            },
            
            new EchoesPerLevel
            {
                Id = 323,
                Level = 328,
                RequiredBloodEchoes = 1068700
            },
            
            new EchoesPerLevel
            {
                Id = 324,
                Level = 329,
                RequiredBloodEchoes = 1077291
            },
            
            new EchoesPerLevel
            {
                Id = 325,
                Level = 330,
                RequiredBloodEchoes = 1085927
            },
            
            new EchoesPerLevel
            {
                Id = 326,
                Level = 331,
                RequiredBloodEchoes = 1094609
            },
            
            new EchoesPerLevel
            {
                Id = 327,
                Level = 332,
                RequiredBloodEchoes = 1103337
            },
            
            new EchoesPerLevel
            {
                Id = 328,
                Level = 333,
                RequiredBloodEchoes = 1112111
            },
            
            new EchoesPerLevel
            {
                Id = 329,
                Level = 334,
                RequiredBloodEchoes = 1120931
            },
            
            new EchoesPerLevel
            {
                Id = 330,
                Level = 335,
                RequiredBloodEchoes = 1129797
            },
            
            new EchoesPerLevel
            {
                Id = 331,
                Level = 336,
                RequiredBloodEchoes = 1138710
            },
            
            new EchoesPerLevel
            {
                Id = 332,
                Level = 337,
                RequiredBloodEchoes = 1147668
            },

            new EchoesPerLevel
            {
                Id = 333,
                Level = 338,
                RequiredBloodEchoes = 1156674
            },
            
            new EchoesPerLevel
            {
                Id = 334,
                Level = 339,
                RequiredBloodEchoes = 1165726
            },
            
            new EchoesPerLevel
            {
                Id = 335,
                Level = 340,
                RequiredBloodEchoes = 1174825
            },
            
            new EchoesPerLevel
            {
                Id = 336,
                Level = 341,
                RequiredBloodEchoes = 1183971
            },
            
            new EchoesPerLevel
            {
                Id = 337,
                Level = 342,
                RequiredBloodEchoes = 1193164
            },
            
            new EchoesPerLevel
            {
                Id = 338,
                Level = 343,
                RequiredBloodEchoes = 1202404
            },
            
            new EchoesPerLevel
            {
                Id = 339,
                Level = 344,
                RequiredBloodEchoes = 1211691
            },
            
            new EchoesPerLevel
            {
                Id = 340,
                Level = 345,
                RequiredBloodEchoes = 1221026
            },
            
            new EchoesPerLevel
            {
                Id = 341,
                Level = 346,
                RequiredBloodEchoes = 1230408
            },
            
            new EchoesPerLevel
            {
                Id = 342,
                Level = 347,
                RequiredBloodEchoes = 1239838
            },
            
            new EchoesPerLevel
            {
                Id = 343,
                Level = 348,
                RequiredBloodEchoes = 1249316
            },
            
            new EchoesPerLevel
            {
                Id = 344,
                Level = 349,
                RequiredBloodEchoes = 1258841
            },
            
            new EchoesPerLevel
            {
                Id = 345,
                Level = 350,
                RequiredBloodEchoes = 1268415
            },
            
            new EchoesPerLevel
            {
                Id = 346,
                Level = 351,
                RequiredBloodEchoes = 1278037
            },
            
            new EchoesPerLevel
            {
                Id = 347,
                Level = 352,
                RequiredBloodEchoes = 1287707
            },
            
            new EchoesPerLevel
            {
                Id = 348,
                Level = 353,
                RequiredBloodEchoes = 1297425
            },
            
            new EchoesPerLevel
            {
                Id = 349,
                Level = 354,
                RequiredBloodEchoes = 1307192
            },
            
            new EchoesPerLevel
            {
                Id = 350,
                Level = 355,
                RequiredBloodEchoes = 1317007
            },
            
            new EchoesPerLevel
            {
                Id = 351,
                Level = 356,
                RequiredBloodEchoes = 1326871
            },
            
            new EchoesPerLevel
            {
                Id = 352,
                Level = 357,
                RequiredBloodEchoes = 1336784
            },
            
            new EchoesPerLevel
            {
                Id = 353,
                Level = 358,
                RequiredBloodEchoes = 1346746
            },
            
            new EchoesPerLevel
            {
                Id = 354,
                Level = 359,
                RequiredBloodEchoes = 1356757
            },
            
            new EchoesPerLevel
            {
                Id = 355,
                Level = 360,
                RequiredBloodEchoes = 1366817
            },
            
            new EchoesPerLevel
            {
                Id = 356,
                Level = 361,
                RequiredBloodEchoes = 1376927
            },
            
            new EchoesPerLevel
            {
                Id = 357,
                Level = 362,
                RequiredBloodEchoes = 1387085
            },
            
            new EchoesPerLevel
            {
                Id = 358,
                Level = 363,
                RequiredBloodEchoes = 1397294
            },
            
            new EchoesPerLevel
            {
                Id = 359,
                Level = 364,
                RequiredBloodEchoes = 1407552
            },
            
            new EchoesPerLevel
            {
                Id = 360,
                Level = 365,
                RequiredBloodEchoes = 1417860
            },
            
            new EchoesPerLevel
            {
                Id = 361,
                Level = 366,
                RequiredBloodEchoes = 1428218
            },
            
            new EchoesPerLevel
            {
                Id = 362,
                Level = 367,
                RequiredBloodEchoes = 1438626
            },
            
            new EchoesPerLevel
            {
                Id = 363,
                Level = 368,
                RequiredBloodEchoes = 1449084
            },
            
            new EchoesPerLevel
            {
                Id = 364,
                Level = 369,
                RequiredBloodEchoes = 1459592
            },
            
            new EchoesPerLevel
            {
                Id = 365,
                Level = 370,
                RequiredBloodEchoes = 1470151
            },
            
            new EchoesPerLevel
            {
                Id = 366,
                Level = 371,
                RequiredBloodEchoes = 1480760
            },
            
            new EchoesPerLevel
            {
                Id = 367,
                Level = 372,
                RequiredBloodEchoes = 1491420
            },
            
            new EchoesPerLevel
            {
                Id = 368,
                Level = 373,
                RequiredBloodEchoes = 1502131
            },
            
            new EchoesPerLevel
            {
                Id = 369,
                Level = 374,
                RequiredBloodEchoes = 1512892
            },
            
            new EchoesPerLevel
            {
                Id = 370,
                Level = 375,
                RequiredBloodEchoes = 1523705
            },
            
            new EchoesPerLevel
            {
                Id = 371,
                Level = 376,
                RequiredBloodEchoes = 1534569
            },
            
            new EchoesPerLevel
            {
                Id = 372,
                Level = 377,
                RequiredBloodEchoes = 1545484
            },
            
            new EchoesPerLevel
            {
                Id = 373,
                Level = 378,
                RequiredBloodEchoes = 1556450
            },
            
            new EchoesPerLevel
            {
                Id = 374,
                Level = 379,
                RequiredBloodEchoes = 1567468
            },

            new EchoesPerLevel
            {
                Id = 375,
                Level = 380,
                RequiredBloodEchoes = 1578537
            },
            
            new EchoesPerLevel
            {
                Id = 376,
                Level = 381,
                RequiredBloodEchoes = 1589658
            },
            
            new EchoesPerLevel
            {
                Id = 377,
                Level = 382,
                RequiredBloodEchoes = 1600831
            },
            
            new EchoesPerLevel
            {
                Id = 378,
                Level = 383,
                RequiredBloodEchoes = 1612056
            },
            
            new EchoesPerLevel
            {
                Id = 379,
                Level = 384,
                RequiredBloodEchoes = 1623333
            },
            
            new EchoesPerLevel
            {
                Id = 380,
                Level = 385,
                RequiredBloodEchoes = 1634662
            },
            
            new EchoesPerLevel
            {
                Id = 381,
                Level = 386,
                RequiredBloodEchoes = 1646043
            },
            
            new EchoesPerLevel
            {
                Id = 382,
                Level = 387,
                RequiredBloodEchoes = 1657477
            },
            
            new EchoesPerLevel
            {
                Id = 383,
                Level = 388,
                RequiredBloodEchoes = 1668964
            },
            
            new EchoesPerLevel
            {
                Id = 384,
                Level = 389,
                RequiredBloodEchoes = 1680503
            },
            
            new EchoesPerLevel
            {
                Id = 385,
                Level = 390,
                RequiredBloodEchoes = 1692095
            },
            
            new EchoesPerLevel
            {
                Id = 386,
                Level = 391,
                RequiredBloodEchoes = 1703740
            },
            
            new EchoesPerLevel
            {
                Id = 387,
                Level = 392,
                RequiredBloodEchoes = 1715438
            },
            
            new EchoesPerLevel
            {
                Id = 388,
                Level = 393,
                RequiredBloodEchoes = 1727189
            },
            
            new EchoesPerLevel
            {
                Id = 389,
                Level = 394,
                RequiredBloodEchoes = 1738993
            },
            
            new EchoesPerLevel
            {
                Id = 390,
                Level = 395,
                RequiredBloodEchoes = 1750851
            },
            
            new EchoesPerLevel
            {
                Id = 391,
                Level = 396,
                RequiredBloodEchoes = 1762762
            },
            
            new EchoesPerLevel
            {
                Id = 392,
                Level = 397,
                RequiredBloodEchoes = 1774727
            },
            
            new EchoesPerLevel
            {
                Id = 393,
                Level = 398,
                RequiredBloodEchoes = 1786746
            },
            
            new EchoesPerLevel
            {
                Id = 394,
                Level = 399,
                RequiredBloodEchoes = 1798818
            },
            
            new EchoesPerLevel
            {
                Id = 395,
                Level = 400,
                RequiredBloodEchoes = 1810945
            },
            
            new EchoesPerLevel
            {
                Id = 396,
                Level = 401,
                RequiredBloodEchoes = 1823126
            },
            
            new EchoesPerLevel
            {
                Id = 397,
                Level = 402,
                RequiredBloodEchoes = 1835361
            },
            
            new EchoesPerLevel
            {
                Id = 398,
                Level = 403,
                RequiredBloodEchoes = 1847650
            },
            
            new EchoesPerLevel
            {
                Id = 399,
                Level = 404,
                RequiredBloodEchoes = 1859994
            },
            
            new EchoesPerLevel
            {
                Id = 400,
                Level = 405,
                RequiredBloodEchoes = 1872392
            },
            
            new EchoesPerLevel
            {
                Id = 401,
                Level = 406,
                RequiredBloodEchoes = 1884845
            },
            
            new EchoesPerLevel
            {
                Id = 402,
                Level = 407,
                RequiredBloodEchoes = 1897353
            },
            
            new EchoesPerLevel
            {
                Id = 403,
                Level = 408,
                RequiredBloodEchoes = 1909916
            },
            
            new EchoesPerLevel
            {
                Id = 404,
                Level = 409,
                RequiredBloodEchoes = 1922534
            },
            
            new EchoesPerLevel
            {
                Id = 405,
                Level = 410,
                RequiredBloodEchoes = 1935207
            },
            
            new EchoesPerLevel
            {
                Id = 406,
                Level = 411,
                RequiredBloodEchoes = 1947935
            },
            
            new EchoesPerLevel
            {
                Id = 407,
                Level = 412,
                RequiredBloodEchoes = 1960719
            },
            
            new EchoesPerLevel
            {
                Id = 408,
                Level = 413,
                RequiredBloodEchoes = 1973559
            },
            
            new EchoesPerLevel
            {
                Id = 409,
                Level = 414,
                RequiredBloodEchoes = 1986454
            },
            
            new EchoesPerLevel
            {
                Id = 410,
                Level = 415,
                RequiredBloodEchoes = 1999405
            },
            
            new EchoesPerLevel
            {
                Id = 411,
                Level = 416,
                RequiredBloodEchoes = 2012412
            },
            
            new EchoesPerLevel
            {
                Id = 412,
                Level = 417,
                RequiredBloodEchoes = 2025475
            },
            
            new EchoesPerLevel
            {
                Id = 413,
                Level = 418,
                RequiredBloodEchoes = 2038594
            },
            
            new EchoesPerLevel
            {
                Id = 414,
                Level = 419,
                RequiredBloodEchoes = 2051769
            },
            
            new EchoesPerLevel
            {
                Id = 415,
                Level = 420,
                RequiredBloodEchoes = 2065001
            },
            
            new EchoesPerLevel
            {
                Id = 416,
                Level = 421,
                RequiredBloodEchoes = 2078289
            },
            
            new EchoesPerLevel
            {
                Id = 417,
                Level = 422,
                RequiredBloodEchoes = 2091634
            },
            
            new EchoesPerLevel
            {
                Id = 418,
                Level = 423,
                RequiredBloodEchoes = 2105036
            },
            
            new EchoesPerLevel
            {
                Id = 419,
                Level = 424,
                RequiredBloodEchoes = 2118494
            },
            
            new EchoesPerLevel
            {
                Id = 420,
                Level = 425,
                RequiredBloodEchoes = 2132010
            },
            
            new EchoesPerLevel
            {
                Id = 421,
                Level = 426,
                RequiredBloodEchoes = 2145583
            },
            
            new EchoesPerLevel
            {
                Id = 422,
                Level = 427,
                RequiredBloodEchoes = 2159213
            },
            
            new EchoesPerLevel
            {
                Id = 423,
                Level = 428,
                RequiredBloodEchoes = 2172900
            },
            
            new EchoesPerLevel
            {
                Id = 424,
                Level = 429,
                RequiredBloodEchoes = 2186645
            },
            
            new EchoesPerLevel
            {
                Id = 425,
                Level = 430,
                RequiredBloodEchoes = 2200447
            },
            
            new EchoesPerLevel
            {
                Id = 426,
                Level = 431,
                RequiredBloodEchoes = 2214307
            },

            new EchoesPerLevel
            {
                Id = 427,
                Level = 432,
                RequiredBloodEchoes = 2228225
            },
            
            new EchoesPerLevel
            {
                Id = 428,
                Level = 433,
                RequiredBloodEchoes = 2242201
            },
            
            new EchoesPerLevel
            {
                Id = 429,
                Level = 434,
                RequiredBloodEchoes = 2256235
            },
            
            new EchoesPerLevel
            {
                Id = 430,
                Level = 435,
                RequiredBloodEchoes = 2270327
            },
            
            new EchoesPerLevel
            {
                Id = 431,
                Level = 436,
                RequiredBloodEchoes = 2284477
            },
            
            new EchoesPerLevel
            {
                Id = 432,
                Level = 437,
                RequiredBloodEchoes = 2298686
            },
            
            new EchoesPerLevel
            {
                Id = 433,
                Level = 438,
                RequiredBloodEchoes = 2312954
            },
            
            new EchoesPerLevel
            {
                Id = 434,
                Level = 439,
                RequiredBloodEchoes = 2327280
            },
            
            new EchoesPerLevel
            {
                Id = 435,
                Level = 440,
                RequiredBloodEchoes = 2341665
            },
            
            new EchoesPerLevel
            {
                Id = 436,
                Level = 441,
                RequiredBloodEchoes = 2356109
            },
            
            new EchoesPerLevel
            {
                Id = 437,
                Level = 442,
                RequiredBloodEchoes = 2370612
            },
            
            new EchoesPerLevel
            {
                Id = 438,
                Level = 443,
                RequiredBloodEchoes = 2385174
            },
            
            new EchoesPerLevel
            {
                Id = 439,
                Level = 444,
                RequiredBloodEchoes = 2399795
            },
            
            new EchoesPerLevel
            {
                Id = 440,
                Level = 445,
                RequiredBloodEchoes = 2414476
            },
            
            new EchoesPerLevel
            {
                Id = 441,
                Level = 446,
                RequiredBloodEchoes = 2429216
            },
            
            new EchoesPerLevel
            {
                Id = 442,
                Level = 447,
                RequiredBloodEchoes = 2444016
            },
            
            new EchoesPerLevel
            {
                Id = 443,
                Level = 448,
                RequiredBloodEchoes = 2458876
            },
            
            new EchoesPerLevel
            {
                Id = 444,
                Level = 449,
                RequiredBloodEchoes = 2473795
            },
            
            new EchoesPerLevel
            {
                Id = 445,
                Level = 450,
                RequiredBloodEchoes = 2488775
            },
            
            new EchoesPerLevel
            {
                Id = 446,
                Level = 451,
                RequiredBloodEchoes = 2503815
            },
            
            new EchoesPerLevel
            {
                Id = 447,
                Level = 452,
                RequiredBloodEchoes = 2518915
            },
            
            new EchoesPerLevel
            {
                Id = 448,
                Level = 453,
                RequiredBloodEchoes = 2534075
            },
            
            new EchoesPerLevel
            {
                Id = 449,
                Level = 454,
                RequiredBloodEchoes = 2549296
            },
            
            new EchoesPerLevel
            {
                Id = 450,
                Level = 455,
                RequiredBloodEchoes = 2564577
            },
            
            new EchoesPerLevel
            {
                Id = 451,
                Level = 456,
                RequiredBloodEchoes = 2579919
            },
            
            new EchoesPerLevel
            {
                Id = 452,
                Level = 457,
                RequiredBloodEchoes = 2595322
            },
            
            new EchoesPerLevel
            {
                Id = 453,
                Level = 458,
                RequiredBloodEchoes = 2610786
            },
            
            new EchoesPerLevel
            {
                Id = 454,
                Level = 459,
                RequiredBloodEchoes = 2626311
            },
            
            new EchoesPerLevel
            {
                Id = 455,
                Level = 460,
                RequiredBloodEchoes = 2641897
            },
            
            new EchoesPerLevel
            {
                Id = 456,
                Level = 461,
                RequiredBloodEchoes = 2657544
            },
            
            new EchoesPerLevel
            {
                Id = 457,
                Level = 462,
                RequiredBloodEchoes = 2673253
            },
            
            new EchoesPerLevel
            {
                Id = 458,
                Level = 463,
                RequiredBloodEchoes = 2689024
            },
            
            new EchoesPerLevel
            {
                Id = 459,
                Level = 464,
                RequiredBloodEchoes = 2704856
            },
            
            new EchoesPerLevel
            {
                Id = 460,
                Level = 465,
                RequiredBloodEchoes = 2720750
            },
            
            new EchoesPerLevel
            {
                Id = 461,
                Level = 466,
                RequiredBloodEchoes = 2736706
            },
            
            new EchoesPerLevel
            {
                Id = 462,
                Level = 467,
                RequiredBloodEchoes = 2752724
            },
            
            new EchoesPerLevel
            {
                Id = 463,
                Level = 468,
                RequiredBloodEchoes = 2768804
            },
            
            new EchoesPerLevel
            {
                Id = 464,
                Level = 469,
                RequiredBloodEchoes = 2784946
            },
            
            new EchoesPerLevel
            {
                Id = 465,
                Level = 470,
                RequiredBloodEchoes = 2801151
            },
            
            new EchoesPerLevel
            {
                Id = 466,
                Level = 471,
                RequiredBloodEchoes = 2817418
            },
            
            new EchoesPerLevel
            {
                Id = 467,
                Level = 472,
                RequiredBloodEchoes = 2833748
            },
            
            new EchoesPerLevel
            {
                Id = 468,
                Level = 473,
                RequiredBloodEchoes = 2850141
            },
            
            new EchoesPerLevel
            {
                Id = 469,
                Level = 474,
                RequiredBloodEchoes = 2866596
            },
            
            new EchoesPerLevel
            {
                Id = 470,
                Level = 475,
                RequiredBloodEchoes = 2883115
            },
            
            new EchoesPerLevel
            {
                Id = 471,
                Level = 476,
                RequiredBloodEchoes = 2899697
            },

            new EchoesPerLevel
            {
                Id = 472,
                Level = 477,
                RequiredBloodEchoes = 2916342
            },
            
            new EchoesPerLevel
            {
                Id = 473,
                Level = 478,
                RequiredBloodEchoes = 2933050
            },
            
            new EchoesPerLevel
            {
                Id = 474,
                Level = 479,
                RequiredBloodEchoes = 2949822
            },
            
            new EchoesPerLevel
            {
                Id = 475,
                Level = 480,
                RequiredBloodEchoes = 2966657
            },
            
            new EchoesPerLevel
            {
                Id = 476,
                Level = 481,
                RequiredBloodEchoes = 2983556
            },
            
            new EchoesPerLevel
            {
                Id = 477,
                Level = 482,
                RequiredBloodEchoes = 3000519
            },
            
            new EchoesPerLevel
            {
                Id = 478,
                Level = 483,
                RequiredBloodEchoes = 3017546
            },
            
            new EchoesPerLevel
            {
                Id = 479,
                Level = 484,
                RequiredBloodEchoes = 3034637
            },
            
            new EchoesPerLevel
            {
                Id = 480,
                Level = 485,
                RequiredBloodEchoes = 3051792
            },
            
            new EchoesPerLevel
            {
                Id = 481,
                Level = 486,
                RequiredBloodEchoes = 3069011
            },
            
            new EchoesPerLevel
            {
                Id = 482,
                Level = 487,
                RequiredBloodEchoes = 3086295
            },
            
            new EchoesPerLevel
            {
                Id = 483,
                Level = 488,
                RequiredBloodEchoes = 3103644
            },
            
            new EchoesPerLevel
            {
                Id = 484,
                Level = 489,
                RequiredBloodEchoes = 3121057
            },
            
            new EchoesPerLevel
            {
                Id = 485,
                Level = 490,
                RequiredBloodEchoes = 3138535
            },
            
            new EchoesPerLevel
            {
                Id = 486,
                Level = 491,
                RequiredBloodEchoes = 3156078
            },
            
            new EchoesPerLevel
            {
                Id = 487,
                Level = 492,
                RequiredBloodEchoes = 3173686
            },
            
            new EchoesPerLevel
            {
                Id = 488,
                Level = 493,
                RequiredBloodEchoes = 3191359
            },
            
            new EchoesPerLevel
            {
                Id = 489,
                Level = 494,
                RequiredBloodEchoes = 3209097
            },
            
            new EchoesPerLevel
            {
                Id = 490,
                Level = 495,
                RequiredBloodEchoes = 3226901
            },
            
            new EchoesPerLevel
            {
                Id = 491,
                Level = 496,
                RequiredBloodEchoes = 3244770
            },
            
            new EchoesPerLevel
            {
                Id = 492,
                Level = 497,
                RequiredBloodEchoes = 3262705
            },
            
            new EchoesPerLevel
            {
                Id = 493,
                Level = 498,
                RequiredBloodEchoes = 3280706
            },
            
            new EchoesPerLevel
            {
                Id = 494,
                Level = 499,
                RequiredBloodEchoes = 3298772
            },
            
            new EchoesPerLevel
            {
                Id = 495,
                Level = 500,
                RequiredBloodEchoes = 3316905
            },
            
            new EchoesPerLevel
            {
                Id = 496,
                Level = 501,
                RequiredBloodEchoes = 3335104
            },
            
            new EchoesPerLevel
            {
                Id = 497,
                Level = 502,
                RequiredBloodEchoes = 3353369
            },
            
            new EchoesPerLevel
            {
                Id = 498,
                Level = 503,
                RequiredBloodEchoes = 3371700
            },
            
            new EchoesPerLevel
            {
                Id = 499,
                Level = 504,
                RequiredBloodEchoes = 3390098
            },
            
            new EchoesPerLevel
            {
                Id = 500,
                Level = 505,
                RequiredBloodEchoes = 3408562
            },
            
            new EchoesPerLevel
            {
                Id = 501,
                Level = 506,
                RequiredBloodEchoes = 3427093
            },
            
            new EchoesPerLevel
            {
                Id = 502,
                Level = 507,
                RequiredBloodEchoes = 3445691
            },
            
            new EchoesPerLevel
            {
                Id = 503,
                Level = 508,
                RequiredBloodEchoes = 3464356
            },
            
            new EchoesPerLevel
            {
                Id = 504,
                Level = 509,
                RequiredBloodEchoes = 3483088
            },
            
            new EchoesPerLevel
            {
                Id = 505,
                Level = 510,
                RequiredBloodEchoes = 3501887
            },
            
            new EchoesPerLevel
            {
                Id = 506,
                Level = 511,
                RequiredBloodEchoes = 3520753
            },
            
            new EchoesPerLevel
            {
                Id = 507,
                Level = 512,
                RequiredBloodEchoes = 3539687
            },
            
            new EchoesPerLevel
            {
                Id = 508,
                Level = 513,
                RequiredBloodEchoes = 3558689
            },
            
            new EchoesPerLevel
            {
                Id = 509,
                Level = 514,
                RequiredBloodEchoes = 3577758
            },
            
            new EchoesPerLevel
            {
                Id = 510,
                Level = 515,
                RequiredBloodEchoes = 3596895
            },
            
            new EchoesPerLevel
            {
                Id = 511,
                Level = 516,
                RequiredBloodEchoes = 3616100
            },

            new EchoesPerLevel
            {
                Id = 512,
                Level = 517,
                RequiredBloodEchoes = 3635373
            },
            
            new EchoesPerLevel
            {
                Id = 513,
                Level = 518,
                RequiredBloodEchoes = 3654714
            },
            
            new EchoesPerLevel
            {
                Id = 514,
                Level = 519,
                RequiredBloodEchoes = 3674123
            },
            
            new EchoesPerLevel
            {
                Id = 515,
                Level = 520,
                RequiredBloodEchoes = 3693601
            },
            
            new EchoesPerLevel
            {
                Id = 516,
                Level = 521,
                RequiredBloodEchoes = 3713147
            },
            
            new EchoesPerLevel
            {
                Id = 517,
                Level = 522,
                RequiredBloodEchoes = 3732762
            },
            
            new EchoesPerLevel
            {
                Id = 518,
                Level = 523,
                RequiredBloodEchoes = 3752446
            },
            
            new EchoesPerLevel
            {
                Id = 519,
                Level = 524,
                RequiredBloodEchoes = 3772198
            },
            
            new EchoesPerLevel
            {
                Id = 520,
                Level = 525,
                RequiredBloodEchoes = 3792020
            },
            
            new EchoesPerLevel
            {
                Id = 521,
                Level = 526,
                RequiredBloodEchoes = 3811911
            },
            
            new EchoesPerLevel
            {
                Id = 522,
                Level = 527,
                RequiredBloodEchoes = 3831871
            },
            
            new EchoesPerLevel
            {
                Id = 523,
                Level = 528,
                RequiredBloodEchoes = 3851900
            },
            
            new EchoesPerLevel
            {
                Id = 524,
                Level = 529,
                RequiredBloodEchoes = 3871999
            },
            
            new EchoesPerLevel
            {
                Id = 525,
                Level = 530,
                RequiredBloodEchoes = 3892167
            },
            
            new EchoesPerLevel
            {
                Id = 526,
                Level = 531,
                RequiredBloodEchoes = 3912405
            },
            
            new EchoesPerLevel
            {
                Id = 527,
                Level = 532,
                RequiredBloodEchoes = 3932713
            },
            
            new EchoesPerLevel
            {
                Id = 528,
                Level = 533,
                RequiredBloodEchoes = 3953091
            },
            
            new EchoesPerLevel
            {
                Id = 529,
                Level = 534,
                RequiredBloodEchoes = 3973539
            },
            
            new EchoesPerLevel
            {
                Id = 530,
                Level = 535,
                RequiredBloodEchoes = 3994057
            },
            
            new EchoesPerLevel
            {
                Id = 531,
                Level = 536,
                RequiredBloodEchoes = 4014645
            },
            
            new EchoesPerLevel
            {
                Id = 532,
                Level = 537,
                RequiredBloodEchoes = 4035304
            },
            
            new EchoesPerLevel
            {
                Id = 533,
                Level = 538,
                RequiredBloodEchoes = 4056034
            },
            
            new EchoesPerLevel
            {
                Id = 534,
                Level = 539,
                RequiredBloodEchoes = 4076834
            },
            
            new EchoesPerLevel
            {
                Id = 535,
                Level = 540,
                RequiredBloodEchoes = 4097705
            },
            
            new EchoesPerLevel
            {
                Id = 536,
                Level = 541,
                RequiredBloodEchoes = 4118647
            },
            
            new EchoesPerLevel
            {
                Id = 537,
                Level = 542,
                RequiredBloodEchoes = 4139660
            },
            
            new EchoesPerLevel
            {
                Id = 538,
                Level = 543,
                RequiredBloodEchoes = 4160744
            },
            
            new EchoesPerLevel
            {
                Id = 539,
                Level = 544,
                RequiredBloodEchoes = 4181899
            }
        };

        await _context.EchoesPerLevels.AddRangeAsync(echoesPerLevel);
        await _context.SaveChangesAsync();
    }

    private async Task SeedOrigins()
    {
        var origins = new List<Origin>
        {
            new Origin
            {
                Name = "Milquetoast",
                Level = 10,
                BloodEchoes = 300,
                Discovery = 100,
                Vitality = 11,
                Endurance = 10,
                Strength = 12,
                Skill = 10,
                Bloodtinge = 9,
                Arcane = 8
            },

            new Origin
            {
                Name = "Lone Survivor",
                Level = 10,
                BloodEchoes = 420,
                Discovery = 100,
                Vitality = 14,
                Endurance = 11,
                Strength = 11,
                Skill = 10,
                Bloodtinge = 7,
                Arcane = 7
            },
            
            new Origin
            {
                Name = "Troubled Childhood",
                Level = 10,
                BloodEchoes = 360,
                Discovery = 103,
                Vitality = 9,
                Endurance = 14,
                Strength = 9,
                Skill = 13,
                Bloodtinge = 6,
                Arcane = 9
            },
            
            new Origin
            {
                Name = "Violent Past",
                Level = 10,
                BloodEchoes = 180,
                Discovery = 100,
                Vitality = 12,
                Endurance = 11,
                Strength = 15,
                Skill = 9,
                Bloodtinge = 6,
                Arcane = 7
            },
            
            new Origin
            {
                Name = "Professional",
                Level = 10,
                BloodEchoes = 240,
                Discovery = 100,
                Vitality = 9,
                Endurance = 12,
                Strength = 9,
                Skill = 15,
                Bloodtinge = 7,
                Arcane = 8
            },
            
            new Origin
            {
                Name = "Military Veteran",
                Level = 10,
                BloodEchoes = 320,
                Discovery = 100,
                Vitality = 10,
                Endurance = 10,
                Strength = 14,
                Skill = 13,
                Bloodtinge = 7,
                Arcane = 6
            },
            
            new Origin
            {
                Name = "Noble Scion",
                Level = 10,
                BloodEchoes = 240,
                Discovery = 103,
                Vitality = 7,
                Endurance = 8,
                Strength = 9,
                Skill = 13,
                Bloodtinge = 14,
                Arcane = 9
            },
            
            new Origin
            {
                Name = "Cruel Fate",
                Level = 10,
                BloodEchoes = 500,
                Discovery = 119,
                Vitality = 10,
                Endurance = 12,
                Strength = 10,
                Skill = 9,
                Bloodtinge = 5,
                Arcane = 14
            },
            
            new Origin
            {
                Name = "Waste of Skin",
                Level = 4,
                BloodEchoes = 10,
                Discovery = 103,
                Vitality = 10,
                Endurance = 9,
                Strength = 10,
                Skill = 9,
                Bloodtinge = 7,
                Arcane = 9
            }
        };

        await _context.Origins.AddRangeAsync(origins);
        await _context.SaveChangesAsync();
    }
}