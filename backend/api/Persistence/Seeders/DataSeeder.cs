using api.Models.Entities;
using api.Persistence.Data;
using api.Models.Enums;

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
            new Scaling { Id = 5, Name = "Blade om Mercy Scaling", StrengthScaling = 0m, SkillScaling = 0.6m, BloodtingeScaling = 0m, ArcaneScaling = 0.4m, StrengthStep = 0m, SkillStep = 0.05m, BloodtingeStep = 0m, ArcaneStep = 0.03m },
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
            new Scaling { Id = 19, Name = "Rimle Spear Scaling", StrengthScaling = 0.2m, SkillScaling = 0.5m, BloodtingeScaling = 0.35m, ArcaneScaling = 0.38m, StrengthStep = 0.01m, SkillStep = 0.02m, BloodtingeStep = 0.03m, ArcaneStep = 0.017m },
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
            new Scaling { Id = 30, Name = "mist om Gratia Scaling", StrengthScaling = 0.5m, SkillScaling = 0m, BloodtingeScaling = 0m, ArcaneScaling = 0m, StrengthStep = 0.05m, SkillStep = 0m, BloodtingeStep = 0m, ArcaneStep = 0m },
            new Scaling { Id = 31, Name = "mlamesprayer Scaling", StrengthScaling = 0m, SkillScaling = 0m, BloodtingeScaling = 0m, ArcaneScaling = 0.3m, StrengthStep = 0m, SkillStep = 0m, BloodtingeStep = 0m, ArcaneStep = 0.04m },
            new Scaling { Id = 32, Name = "Gatling Gun Scaling", StrengthScaling = 0m, SkillScaling = 0m, BloodtingeScaling = 0.1m, ArcaneScaling = 0m, StrengthStep = 0m, SkillStep = 0m, BloodtingeStep = 0.03m, ArcaneStep = 0m },
            new Scaling { Id = 33, Name = "Hunter Blunderbuss Scaling", StrengthScaling = 0m, SkillScaling = 0m, BloodtingeScaling = 0.5m, ArcaneScaling = 0m, StrengthStep = 0m, SkillStep = 0m, BloodtingeStep = 0.05m, ArcaneStep = 0m },
            new Scaling { Id = 34, Name = "Hunter Pistol Scaling", StrengthScaling = 0m, SkillScaling = 0m, BloodtingeScaling = 0.45m, ArcaneScaling = 0m, StrengthStep = 0m, SkillStep = 0m, BloodtingeStep = 0.04m, ArcaneStep = 0m },
            new Scaling { Id = 35, Name = "Ludwig's Rimle Scaling", StrengthScaling = 0m, SkillScaling = 0m, BloodtingeScaling = 0.2m, ArcaneScaling = 0m, StrengthStep = 0m, SkillStep = 0m, BloodtingeStep = 0.03m, ArcaneStep = 0m },
            new Scaling { Id = 36, Name = "Piercing Rimle Scaling", StrengthScaling = 0m, SkillScaling = 0m, BloodtingeScaling = 0.4m, ArcaneScaling = 0m, StrengthStep = 0m, SkillStep = 0m, BloodtingeStep = 0.06m, ArcaneStep = 0m },
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
            new Boss { Id = 1, Name = "Cleric Beast", Health = 3015, BloodEchoes = 4000, IsInterruptible = false, IsRequired = false },
            new Boss { Id = 2, Name = "Father Gascoigne", Health = 2031, BloodEchoes = 3200, IsInterruptible = true, IsRequired = true },
            new Boss { Id = 3, Name = "Blood-starved Beast", Health = 3470, BloodEchoes = 6600, IsInterruptible = true, IsRequired = false },
            new Boss { Id = 4, Name = "The Witch of Hemwick", Health = 2611, BloodEchoes = 11800, IsInterruptible = false, IsRequired = false },
            new Boss { Id = 5, Name = "Darkbeast Paarl", Health = 4552, BloodEchoes = 21000, IsInterruptible = false, IsRequired = false },
            new Boss { Id = 6, Name = "Vicar Amelia", Health = 5367, BloodEchoes = 15000, IsInterruptible = false, IsRequired = true },
            new Boss { Id = 7, Name = "Shadow of Yharnam", Health = 7993, BloodEchoes = 18600, IsInterruptible = true, IsRequired = true },
            new Boss { Id = 8, Name = "Martyr Logarius", Health = 9081, BloodEchoes = 25600, IsInterruptible = true, IsRequired = false },
            new Boss { Id = 9, Name = "Amygdala", Health = 6404, BloodEchoes = 21000, IsInterruptible = false, IsRequired = false },
            new Boss { Id = 10, Name = "Rom, the Vacuous Spider", Health = 4235, BloodEchoes = 22600, IsInterruptible = false, IsRequired = true },
            new Boss { Id = 11, Name = "The One Reborn", Health = 10375, BloodEchoes = 33000, IsInterruptible = false, IsRequired = true },
            new Boss { Id = 12, Name = "Celestial Emissary", Health = 2764, BloodEchoes = 22400, IsInterruptible = false, IsRequired = false },
            new Boss { Id = 13, Name = "Ebrietas, Daughter of the Cosmos", Health = 12493, BloodEchoes = 28800, IsInterruptible = false, IsRequired = false },
            new Boss { Id = 14, Name = "Micolash, Host of the Nightmare", Health = 5250, BloodEchoes = 48400, IsInterruptible = true, IsRequired = true },
            new Boss { Id = 15, Name = "Mergo's Wet Nurse", Health = 14081, BloodEchoes = 72000, IsInterruptible = false, IsRequired = true },
            new Boss { Id = 16, Name = "Gehrman, The First Hunter", Health = 14293, BloodEchoes = 128000, IsInterruptible = true, IsRequired = false },
            new Boss { Id = 17, Name = "Moon Presence", Health = 8909, BloodEchoes = 230000, IsInterruptible = false, IsRequired = false },
            new Boss { Id = 18, Name = "Ludwig the Accursed / Holy Blade", Health = 16658, BloodEchoes = 34500, IsInterruptible = false, IsRequired = false },
            new Boss { Id = 19, Name = "Laurence, the First Vicar", Health = 21243, BloodEchoes = 29500, IsInterruptible = false, IsRequired = false },
            new Boss { Id = 20, Name = "Living Failures", Health = 20646, BloodEchoes = 22000, IsInterruptible = true, IsRequired = false },
            new Boss { Id = 21, Name = "Lady Maria of the Astral Clocktower", Health = 14081, BloodEchoes = 39000, IsInterruptible = true, IsRequired = false },
            new Boss { Id = 22, Name = "Orphan of Kos", Health = 19216, BloodEchoes = 60000, IsInterruptible = true, IsRequired = false }
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
                PhysicalAttack = 190,
                BloodAttack = 0,
                ArcaneAttack = 0,
                FireAttack = 0,
                BoltAttack = 0,
                BulletUse = 0,
                RapidPoison = 0,
                ImprintsNormal = ImprintType.Imprint223,
                ImprintsUncanny = ImprintType.Imprint224,
                ImprintsLost = ImprintType.Imprint234,
                Rally = 120,
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
        var attacks = new List<Attack>
        {
            new Attack {
                Id = 1,
                Name = "R1",
                Damage = 1,
                ExtraDamage = 0,
                ExtraDamageCount = 0,
                AttackType1 = AttackType.Blunt,
                AttackType2 = AttackType.Arcane,
                AttackMode = AttackMode.Normal,
                TricksterWeaponId = 1
            },
            
            new Attack {
                Id = 2,
                Name = "R1 (2nd)",
                Damage = 1,
                ExtraDamage = 0,
                ExtraDamageCount = 0,
                AttackType1 = AttackType.Blunt,
                AttackType2 = AttackType.Arcane,
                AttackMode = AttackMode.Normal,
                TricksterWeaponId = 1
            },
            
            new Attack {
                Id = 3,
                Name = "R1 (3rd)",
                Damage = 1,
                ExtraDamage = 0,
                ExtraDamageCount = 0,
                AttackType1 = AttackType.Blunt,
                AttackType2 = AttackType.Arcane,
                AttackMode = AttackMode.Normal,
                TricksterWeaponId = 1
            },
            
            new Attack {
                Id = 4,
                Name = "R1 (4th)",
                Damage = 1,
                ExtraDamage = 0,
                ExtraDamageCount = 0,
                AttackType1 = AttackType.Blunt,
                AttackType2 = AttackType.Arcane,
                AttackMode = AttackMode.Normal,
                TricksterWeaponId = 1
            },
            
            new Attack {
                Id = 5,
                Name = "R1 (backstep)",
                Damage = 0,
                ExtraDamage = 0,
                ExtraDamageCount = 0,
                AttackType1 = AttackType.Blunt,
                AttackType2 = AttackType.Arcane,
                AttackMode = AttackMode.Normal,
                TricksterWeaponId = 1
            },
            
            new Attack {
                Id = 6,
                Name = "R1 (rolling)",
                Damage = 0,
                ExtraDamage = 0,
                ExtraDamageCount = 0,
                AttackType1 = AttackType.Blunt,
                AttackType2 = AttackType.Arcane,
                AttackMode = AttackMode.Normal,
                TricksterWeaponId = 1
            },
            
            new Attack {
                Id = 7,
                Name = "R1 (frontstep)",
                Damage = 0,
                ExtraDamage = 0,
                ExtraDamageCount = 0,
                AttackType1 = AttackType.Blunt,
                AttackType2 = AttackType.Arcane,
                AttackMode = AttackMode.Normal,
                TricksterWeaponId = 1
            },
            
            new Attack {
                Id = 8,
                Name = "R1 (sidestep)",
                Damage = 0,
                ExtraDamage = 0,
                ExtraDamageCount = 0,
                AttackType1 = AttackType.Blunt,
                AttackType2 = AttackType.Arcane,
                AttackMode = AttackMode.Normal,
                TricksterWeaponId = 1
            },
            
            new Attack {
                Id = 9,
                Name = "R1 (dash)",
                Damage = 1,
                ExtraDamage = 0,
                ExtraDamageCount = 0,
                AttackType1 = AttackType.Blunt,
                AttackType2 = AttackType.Arcane,
                AttackMode = AttackMode.Normal,
                TricksterWeaponId = 1
            },
            
            new Attack {
                Id = 10,
                Name = "R2",
                Damage = 1,
                ExtraDamage = 0,
                ExtraDamageCount = 0,
                AttackType1 = AttackType.Blunt,
                AttackType2 = AttackType.Arcane,
                AttackMode = AttackMode.Normal,
                TricksterWeaponId = 1
            },
            
            new Attack {
                Id = 11,
                Name = "R2 (charged)",
                Damage = 1,
                ExtraDamage = 0,
                ExtraDamageCount = 0,
                AttackType1 = AttackType.Blunt,
                AttackType2 = AttackType.Arcane,
                AttackMode = AttackMode.Normal,
                TricksterWeaponId = 1
            },
            
            new Attack {
                Id = 12,
                Name = "R2 (follow-up)",
                Damage = 1,
                ExtraDamage = 0,
                ExtraDamageCount = 0,
                AttackType1 = AttackType.Blunt,
                AttackType2 = AttackType.Arcane,
                AttackMode = AttackMode.Normal,
                TricksterWeaponId = 1
            },
            
            new Attack {
                Id = 13,
                Name = "R2 (backstep)",
                Damage = 1,
                ExtraDamage = 0,
                ExtraDamageCount = 0,
                AttackType1 = AttackType.Blunt,
                AttackType2 = AttackType.Arcane,
                AttackMode = AttackMode.Normal,
                TricksterWeaponId = 1
            },
            
            new Attack {
                Id = 14,
                Name = "R2 (dash)",
                Damage = 1,
                ExtraDamage = 0,
                ExtraDamageCount = 0,
                AttackType1 = AttackType.Blunt,
                AttackType2 = AttackType.Arcane,
                AttackMode = AttackMode.Normal,
                TricksterWeaponId = 1
            },
            
            new Attack {
                Id = 15,
                Name = "R2 (forward leap)",
                Damage = 1,
                ExtraDamage = 0,
                ExtraDamageCount = 0,
                AttackType1 = AttackType.Blunt,
                AttackType2 = AttackType.Arcane,
                AttackMode = AttackMode.Normal,
                TricksterWeaponId = 1
            },
            
            new Attack {
                Id = 16,
                Name = "Transform Attack",
                Damage = 1,
                ExtraDamage = 0,
                ExtraDamageCount = 0,
                AttackType1 = AttackType.Physical,
                AttackType2 = AttackType.Arcane,
                AttackMode = AttackMode.Normal,
                TricksterWeaponId = 1
            },
            
            new Attack {
                Id = 17,
                Name = "Plunge Attack",
                Damage = 1,
                ExtraDamage = 0,
                ExtraDamageCount = 0,
                AttackType1 = AttackType.Blunt,
                AttackType2 = AttackType.Arcane,
                AttackMode = AttackMode.Normal,
                TricksterWeaponId = 1
            },
            
            new Attack {
                Id = 18,
                Name = "Plunge Attack (2nd)",
                Damage = 0,
                ExtraDamage = 0,
                ExtraDamageCount = 0,
                AttackType1 = AttackType.Blunt,
                AttackType2 = AttackType.Arcane,
                AttackMode = AttackMode.Normal,
                TricksterWeaponId = 1
            },

            new Attack {
                Id = 19,
                Name = "R1",
                Damage = 0,
                ExtraDamage = 0,
                ExtraDamageCount = 0,
                AttackType1 = AttackType.Physical,
                AttackType2 = AttackType.Arcane,
                AttackMode = AttackMode.Transformed,
                TricksterWeaponId = 1
            },
            
            new Attack {
                Id = 20,
                Name = "R1 (2nd)",
                Damage = 1,
                ExtraDamage = 0,
                ExtraDamageCount = 0,
                AttackType1 = AttackType.Physical,
                AttackType2 = AttackType.Arcane,
                AttackMode = AttackMode.Transformed,
                TricksterWeaponId = 1
            },
            
            new Attack {
                Id = 21,
                Name = "R1 (3rd)",
                Damage = 1,
                ExtraDamage = 0,
                ExtraDamageCount = 0,
                AttackType1 = AttackType.Physical,
                AttackType2 = AttackType.Arcane,
                AttackMode = AttackMode.Transformed,
                TricksterWeaponId = 1
            },
            
            new Attack {
                Id = 22,
                Name = "R1 (4th)",
                Damage = 1,
                ExtraDamage = 0,
                ExtraDamageCount = 0,
                AttackType1 = AttackType.Physical,
                AttackType2 = AttackType.Arcane,
                AttackMode = AttackMode.Transformed,
                TricksterWeaponId = 1
            },
            
            new Attack {
                Id = 23,
                Name = "R1 (backstep)",
                Damage = 0,
                ExtraDamage = 0,
                ExtraDamageCount = 0,
                AttackType1 = AttackType.Physical,
                AttackType2 = AttackType.Arcane,
                AttackMode = AttackMode.Transformed,
                TricksterWeaponId = 1
            },
            
            new Attack {
                Id = 24,
                Name = "R1 (rolling)",
                Damage = 0,
                ExtraDamage = 0,
                ExtraDamageCount = 0,
                AttackType1 = AttackType.Physical,
                AttackType2 = AttackType.Arcane,
                AttackMode = AttackMode.Transformed,
                TricksterWeaponId = 1
            },
            
            new Attack {
                Id = 25,
                Name = "R1 (frontstep)",
                Damage = 0,
                ExtraDamage = 0,
                ExtraDamageCount = 0,
                AttackType1 = AttackType.Physical,
                AttackType2 = AttackType.Arcane,
                AttackMode = AttackMode.Transformed,
                TricksterWeaponId = 1
            },
            
            new Attack {
                Id = 26,
                Name = "R1 (sidestep)",
                Damage = 0,
                ExtraDamage = 0,
                ExtraDamageCount = 0,
                AttackType1 = AttackType.Physical,
                AttackType2 = AttackType.Arcane,
                AttackMode = AttackMode.Transformed,
                TricksterWeaponId = 1
            },
            
            new Attack {
                Id = 27,
                Name = "R1 (dash)",
                Damage = 1,
                ExtraDamage = 0,
                ExtraDamageCount = 0,
                AttackType1 = AttackType.Physical,
                AttackType2 = AttackType.Arcane,
                AttackMode = AttackMode.Transformed,
                TricksterWeaponId = 1
            },
            
            new Attack {
                Id = 28,
                Name = "R2",
                Damage = 1,
                ExtraDamage = 0,
                ExtraDamageCount = 0,
                AttackType1 = AttackType.Thrust,
                AttackType2 = AttackType.Arcane,
                AttackMode = AttackMode.Transformed,
                TricksterWeaponId = 1
            },
            
            new Attack {
                Id = 29,
                Name = "R2 (2nd)",
                Damage = 0,
                ExtraDamage = 0,
                ExtraDamageCount = 0,
                AttackType1 = AttackType.Physical,
                AttackType2 = AttackType.Arcane,
                AttackMode = AttackMode.Transformed,
                TricksterWeaponId = 1
            },
            
            new Attack {
                Id = 30,
                Name = "R2 (charged)",
                Damage = 1,
                ExtraDamage = 0,
                ExtraDamageCount = 0,
                AttackType1 = AttackType.Blunt,
                AttackType2 = AttackType.Arcane,
                AttackMode = AttackMode.Transformed,
                TricksterWeaponId = 1
            },
            
            new Attack {
                Id = 31,
                Name = "R2 (charged) (2nd)",
                Damage = 0,
                ExtraDamage = 0,
                ExtraDamageCount = 0,
                AttackType1 = AttackType.Physical,
                AttackType2 = AttackType.Arcane,
                AttackMode = AttackMode.Transformed,
                TricksterWeaponId = 1
            },
            
            new Attack {
                Id = 32,
                Name = "R2 (charged) (3rd)",
                Damage = 0,
                ExtraDamage = 0,
                ExtraDamageCount = 0,
                AttackType1 = AttackType.Physical,
                AttackType2 = AttackType.Arcane,
                AttackMode = AttackMode.Transformed,
                TricksterWeaponId = 1
            },
            
            new Attack {
                Id = 33,
                Name = "R2 (backstep)",
                Damage = 1,
                ExtraDamage = 0,
                ExtraDamageCount = 0,
                AttackType1 = AttackType.Thrust,
                AttackType2 = AttackType.Arcane,
                AttackMode = AttackMode.Transformed,
                TricksterWeaponId = 1
            },
            
            new Attack {
                Id = 34,
                Name = "R2 (dash)",
                Damage = 1,
                ExtraDamage = 0,
                ExtraDamageCount = 0,
                AttackType1 = AttackType.Physical,
                AttackType2 = AttackType.Arcane,
                AttackMode = AttackMode.Transformed,
                TricksterWeaponId = 1
            },
            
            new Attack {
                Id = 35,
                Name = "R2 (forward leap)",
                Damage = 1,
                ExtraDamage = 0,
                ExtraDamageCount = 0,
                AttackType1 = AttackType.Blunt,
                AttackType2 = AttackType.Arcane,
                AttackMode = AttackMode.Transformed,
                TricksterWeaponId = 1
            },
            
            new Attack {
                Id = 36,
                Name = "Transform Attack",
                Damage = 1,
                ExtraDamage = 0,
                ExtraDamageCount = 0,
                AttackType1 = AttackType.Blunt,
                AttackType2 = AttackType.Arcane,
                AttackMode = AttackMode.Transformed,
                TricksterWeaponId = 1
            },
            
            new Attack {
                Id = 37,
                Name = "Plunge Attack",
                Damage = 1,
                ExtraDamage = 0,
                ExtraDamageCount = 0,
                AttackType1 = AttackType.Physical,
                AttackType2 = AttackType.Arcane,
                AttackMode = AttackMode.Transformed,
                TricksterWeaponId = 1
            },
            
            new Attack {
                Id = 38,
                Name = "Plunge Attack (2nd)",
                Damage = 0,
                ExtraDamage = 0,
                ExtraDamageCount = 0,
                AttackType1 = AttackType.Blunt,
                AttackType2 = AttackType.Arcane,
                AttackMode = AttackMode.Transformed,
                TricksterWeaponId = 1
            },
            
            new Attack {
                Id = 39,
                Name = "R1",
                Damage = 1,
                ExtraDamage = 0,
                ExtraDamageCount = 0,
                AttackType1 = AttackType.Physical,
                AttackType2 = AttackType.None,
                AttackMode = AttackMode.Normal,
                TricksterWeaponId = 2
            },
            
            new Attack {
                Id = 40,
                Name = "R1 (2nd)",
                Damage = 1,
                ExtraDamage = 0,
                ExtraDamageCount = 0,
                AttackType1 = AttackType.Physical,
                AttackType2 = AttackType.None,
                AttackMode = AttackMode.Normal,
                TricksterWeaponId = 2
            },
            
            new Attack {
                Id = 41,
                Name = "R1 (3rd)",
                Damage = 1,
                ExtraDamage = 0,
                ExtraDamageCount = 0,
                AttackType1 = AttackType.Physical,
                AttackType2 = AttackType.None,
                AttackMode = AttackMode.Normal,
                TricksterWeaponId = 2
            },
            
            new Attack {
                Id = 42,
                Name = "R1 (4th)",
                Damage = 1,
                ExtraDamage = 0,
                ExtraDamageCount = 0,
                AttackType1 = AttackType.Physical,
                AttackType2 = AttackType.None,
                AttackMode = AttackMode.Normal,
                TricksterWeaponId = 2
            },
            
            new Attack {
                Id = 43,
                Name = "R1 (5th)",
                Damage = 1,
                ExtraDamage = 0,
                ExtraDamageCount = 0,
                AttackType1 = AttackType.Physical,
                AttackType2 = AttackType.None,
                AttackMode = AttackMode.Normal,
                TricksterWeaponId = 2
            },
            
            new Attack {
                Id = 44,
                Name = "R1 (backstep)",
                Damage = 0,
                ExtraDamage = 0,
                ExtraDamageCount = 0,
                AttackType1 = AttackType.Physical,
                AttackType2 = AttackType.None,
                AttackMode = AttackMode.Normal,
                TricksterWeaponId = 2
            },
            
            new Attack {
                Id = 45,
                Name = "R1 (rolling)",
                Damage = 0,
                ExtraDamage = 0,
                ExtraDamageCount = 0,
                AttackType1 = AttackType.Thrust,
                AttackType2 = AttackType.None,
                AttackMode = AttackMode.Normal,
                TricksterWeaponId = 2
            },
            
            new Attack {
                Id = 46,
                Name = "R1 (frontstep)",
                Damage = 0,
                ExtraDamage = 0,
                ExtraDamageCount = 0,
                AttackType1 = AttackType.Thrust,
                AttackType2 = AttackType.None,
                AttackMode = AttackMode.Normal,
                TricksterWeaponId = 2
            },
            
            new Attack {
                Id = 47,
                Name = "R1 (sidestep)",
                Damage = 0,
                ExtraDamage = 0,
                ExtraDamageCount = 0,
                AttackType1 = AttackType.Physical,
                AttackType2 = AttackType.None,
                AttackMode = AttackMode.Normal,
                TricksterWeaponId = 2
            },
            
            new Attack {
                Id = 48,
                Name = "R1 (dash)",
                Damage = 1,
                ExtraDamage = 0,
                ExtraDamageCount = 0,
                AttackType1 = AttackType.Physical,
                AttackType2 = AttackType.None,
                AttackMode = AttackMode.Normal,
                TricksterWeaponId = 2
            },
            
            new Attack {
                Id = 49,
                Name = "R2",
                Damage = 1,
                ExtraDamage = 0,
                ExtraDamageCount = 0,
                AttackType1 = AttackType.Physical,
                AttackType2 = AttackType.None,
                AttackMode = AttackMode.Normal,
                TricksterWeaponId = 2
            },
            
            new Attack {
                Id = 50,
                Name = "R2 (charged)",
                Damage = 1,
                ExtraDamage = 0,
                ExtraDamageCount = 0,
                AttackType1 = AttackType.Physical,
                AttackType2 = AttackType.None,
                AttackMode = AttackMode.Normal,
                TricksterWeaponId = 2
            },
            
            new Attack {
                Id = 51,
                Name = "R2 (backstep)",
                Damage = 1,
                ExtraDamage = 0,
                ExtraDamageCount = 0,
                AttackType1 = AttackType.Physical,
                AttackType2 = AttackType.None,
                AttackMode = AttackMode.Normal,
                TricksterWeaponId = 2
            },
            
            new Attack {
                Id = 52,
                Name = "R2 (dash)",
                Damage = 1,
                ExtraDamage = 0,
                ExtraDamageCount = 0,
                AttackType1 = AttackType.Thrust,
                AttackType2 = AttackType.None,
                AttackMode = AttackMode.Normal,
                TricksterWeaponId = 2
            },
            
            new Attack {
                Id = 53,
                Name = "R2 (forward leap)",
                Damage = 1,
                ExtraDamage = 0,
                ExtraDamageCount = 0,
                AttackType1 = AttackType.Physical,
                AttackType2 = AttackType.None,
                AttackMode = AttackMode.Normal,
                TricksterWeaponId = 2
            },
            
            new Attack {
                Id = 54,
                Name = "Plunge Attack",
                Damage = 1,
                ExtraDamage = 0,
                ExtraDamageCount = 0,
                AttackType1 = AttackType.Thrust,
                AttackType2 = AttackType.None,
                AttackMode = AttackMode.Normal,
                TricksterWeaponId = 2
            },
            
            new Attack {
                Id = 55,
                Name = "Plunge Attack (2nd)",
                Damage = 0,
                ExtraDamage = 0,
                ExtraDamageCount = 0,
                AttackType1 = AttackType.Blunt,
                AttackType2 = AttackType.None,
                AttackMode = AttackMode.Normal,
                TricksterWeaponId = 2
            },
            
            new Attack {
                Id = 56,
                Name = "R1",
                Damage = 0,
                ExtraDamage = 0,
                ExtraDamageCount = 0,
                AttackType1 = AttackType.Physical,
                AttackType2 = AttackType.None,
                AttackMode = AttackMode.Transformed,
                TricksterWeaponId = 2
            },
            
            new Attack {
                Id = 57,
                Name = "R1 (2nd)",
                Damage = 1,
                ExtraDamage = 0,
                ExtraDamageCount = 0,
                AttackType1 = AttackType.Physical,
                AttackType2 = AttackType.None,
                AttackMode = AttackMode.Transformed,
                TricksterWeaponId = 2
            },
            
            new Attack {
                Id = 58,
                Name = "R1 (3rd)",
                Damage = 0,
                ExtraDamage = 0,
                ExtraDamageCount = 0,
                AttackType1 = AttackType.Physical,
                AttackType2 = AttackType.None,
                AttackMode = AttackMode.Transformed,
                TricksterWeaponId = 2
            },
            
            new Attack {
                Id = 59,
                Name = "R1 (4th)",
                Damage = 1,
                ExtraDamage = 0,
                ExtraDamageCount = 0,
                AttackType1 = AttackType.Physical,
                AttackType2 = AttackType.None,
                AttackMode = AttackMode.Transformed,
                TricksterWeaponId = 2
            },
            
            new Attack {
                Id = 60,
                Name = "R1 (5th)",
                Damage = 0,
                ExtraDamage = 0,
                ExtraDamageCount = 0,
                AttackType1 = AttackType.Physical,
                AttackType2 = AttackType.None,
                AttackMode = AttackMode.Transformed,
                TricksterWeaponId = 2
            },
            
            new Attack {
                Id = 61,
                Name = "R1 (backstep)",
                Damage = 0,
                ExtraDamage = 0,
                ExtraDamageCount = 0,
                AttackType1 = AttackType.Physical,
                AttackType2 = AttackType.None,
                AttackMode = AttackMode.Transformed,
                TricksterWeaponId = 2
            },
            
            new Attack {
                Id = 62,
                Name = "R1 (rolling)",
                Damage = 0,
                ExtraDamage = 0,
                ExtraDamageCount = 0,
                AttackType1 = AttackType.Physical,
                AttackType2 = AttackType.None,
                AttackMode = AttackMode.Transformed,
                TricksterWeaponId = 2
            },
            
            new Attack {
                Id = 63,
                Name = "R1 (frontstep)",
                Damage = 0,
                ExtraDamage = 0,
                ExtraDamageCount = 0,
                AttackType1 = AttackType.Physical,
                AttackType2 = AttackType.None,
                AttackMode = AttackMode.Transformed,
                TricksterWeaponId = 2
            },
            
            new Attack {
                Id = 64,
                Name = "R1 (sidestep left)",
                Damage = 1,
                ExtraDamage = 0,
                ExtraDamageCount = 0,
                AttackType1 = AttackType.Physical,
                AttackType2 = AttackType.None,
                AttackMode = AttackMode.Transformed,
                TricksterWeaponId = 2
            },
            
            new Attack {
                Id = 65,
                Name = "R1 (sidestep right)",
                Damage = 0,
                ExtraDamage = 0,
                ExtraDamageCount = 0,
                AttackType1 = AttackType.Physical,
                AttackType2 = AttackType.None,
                AttackMode = AttackMode.Transformed,
                TricksterWeaponId = 2
            },
            
            new Attack {
                Id = 66,
                Name = "R1 (dash)",
                Damage = 0,
                ExtraDamage = 0,
                ExtraDamageCount = 0,
                AttackType1 = AttackType.Physical,
                AttackType2 = AttackType.None,
                AttackMode = AttackMode.Transformed,
                TricksterWeaponId = 2
            },
            
            new Attack {
                Id = 67,
                Name = "R2",
                Damage = 1,
                ExtraDamage = 0,
                ExtraDamageCount = 0,
                AttackType1 = AttackType.Physical,
                AttackType2 = AttackType.None,
                AttackMode = AttackMode.Transformed,
                TricksterWeaponId = 2
            },
            
            new Attack {
                Id = 68,
                Name = "R2 (charged)",
                Damage = 1,
                ExtraDamage = 0,
                ExtraDamageCount = 0,
                AttackType1 = AttackType.Physical,
                AttackType2 = AttackType.None,
                AttackMode = AttackMode.Transformed,
                TricksterWeaponId = 2
            },
            
            new Attack {
                Id = 69,
                Name = "R2 (backstep)",
                Damage = 1,
                ExtraDamage = 0,
                ExtraDamageCount = 0,
                AttackType1 = AttackType.Physical,
                AttackType2 = AttackType.None,
                AttackMode = AttackMode.Transformed,
                TricksterWeaponId = 2
            },
            
            new Attack {
                Id = 70,
                Name = "R2 (dash)",
                Damage = 1,
                ExtraDamage = 0,
                ExtraDamageCount = 0,
                AttackType1 = AttackType.Physical,
                AttackType2 = AttackType.None,
                AttackMode = AttackMode.Transformed,
                TricksterWeaponId = 2
            },
            
            new Attack {
                Id = 71,
                Name = "R2(forward leap)",
                Damage = 1,
                ExtraDamage = 0,
                ExtraDamageCount = 0,
                AttackType1 = AttackType.Physical,
                AttackType2 = AttackType.None,
                AttackMode = AttackMode.Transformed,
                TricksterWeaponId = 2
            },
            
            new Attack {
                Id = 72,
                Name = "L2",
                Damage = 1,
                ExtraDamage = 0,
                ExtraDamageCount = 0,
                AttackType1 = AttackType.Physical,
                AttackType2 = AttackType.None,
                AttackMode = AttackMode.Transformed,
                TricksterWeaponId = 2
            },
            
            new Attack {
                Id = 73,
                Name = "L2 (2nd)",
                Damage = 1,
                ExtraDamage = 0,
                ExtraDamageCount = 0,
                AttackType1 = AttackType.Physical,
                AttackType2 = AttackType.None,
                AttackMode = AttackMode.Transformed,
                TricksterWeaponId = 2
            },
            
            new Attack {
                Id = 74,
                Name = "L2 (3rd)",
                Damage = 1,
                ExtraDamage = 0,
                ExtraDamageCount = 0,
                AttackType1 = AttackType.Physical,
                AttackType2 = AttackType.None,
                AttackMode = AttackMode.Transformed,
                TricksterWeaponId = 2
            },
            
            new Attack {
                Id = 75,
                Name = "Transform Attack",
                Damage = 1,
                ExtraDamage = 0,
                ExtraDamageCount = 0,
                AttackType1 = AttackType.Physical,
                AttackType2 = AttackType.None,
                AttackMode = AttackMode.Transformed,
                TricksterWeaponId = 2
            },
            
            new Attack {
                Id = 76,
                Name = "Plunge Attack",
                Damage = 1,
                ExtraDamage = 0,
                ExtraDamageCount = 0,
                AttackType1 = AttackType.Thrust,
                AttackType2 = AttackType.None,
                AttackMode = AttackMode.Transformed,
                TricksterWeaponId = 2
            },
            
            new Attack {
                Id = 77,
                Name = "Plunge Attack (2nd hit)",
                Damage = 0,
                ExtraDamage = 0,
                ExtraDamageCount = 0,
                AttackType1 = AttackType.Blunt,
                AttackType2 = AttackType.None,
                AttackMode = AttackMode.Transformed,
                TricksterWeaponId = 2
            },
            
            new Attack {
                Id = 78,
                Name = "R1 (Beast's Embrace)",
                Damage = 1,
                ExtraDamage = 0,
                ExtraDamageCount = 0,
                AttackType1 = AttackType.Physical,
                AttackType2 = AttackType.None,
                AttackMode = AttackMode.Normal,
                TricksterWeaponId = 2
            },
            
            new Attack {
                Id = 79,
                Name = "R1 (2nd) (Beast's Embrace)",
                Damage = 1,
                ExtraDamage = 0,
                ExtraDamageCount = 0,
                AttackType1 = AttackType.Physical,
                AttackType2 = AttackType.None,
                AttackMode = AttackMode.Normal,
                TricksterWeaponId = 2
            },
            
            new Attack {
                Id = 80,
                Name = "R1 (3rd) (Beast's Embrace)",
                Damage = 1,
                ExtraDamage = 0,
                ExtraDamageCount = 0,
                AttackType1 = AttackType.Physical,
                AttackType2 = AttackType.None,
                AttackMode = AttackMode.Normal,
                TricksterWeaponId = 2
            },
            
            new Attack {
                Id = 81,
                Name = "R1 (4th) (Beast's Embrace)",
                Damage = 1,
                ExtraDamage = 0,
                ExtraDamageCount = 0,
                AttackType1 = AttackType.Physical,
                AttackType2 = AttackType.None,
                AttackMode = AttackMode.Normal,
                TricksterWeaponId = 2
            },
            
            new Attack {
                Id = 82,
                Name = "R1 (backstep) (Beast's Embrace)",
                Damage = 0,
                ExtraDamage = 0,
                ExtraDamageCount = 0,
                AttackType1 = AttackType.Physical,
                AttackType2 = AttackType.None,
                AttackMode = AttackMode.Normal,
                TricksterWeaponId = 2
            },
            
            new Attack {
                Id = 83,
                Name = "R1 (rolling) (Beast's Embrace)",
                Damage = 0,
                ExtraDamage = 0,
                ExtraDamageCount = 0,
                AttackType1 = AttackType.Physical,
                AttackType2 = AttackType.None,
                AttackMode = AttackMode.Normal,
                TricksterWeaponId = 2
            },
            
            new Attack {
                Id = 84,
                Name = "R1 (frontstep) (Beast's Embrace)",
                Damage = 0,
                ExtraDamage = 0,
                ExtraDamageCount = 0,
                AttackType1 = AttackType.Physical,
                AttackType2 = AttackType.None,
                AttackMode = AttackMode.Normal,
                TricksterWeaponId = 2
            },
            
            new Attack {
                Id = 85,
                Name = "R1 (sidestep) (Beast's Embrace)",
                Damage = 0,
                ExtraDamage = 0,
                ExtraDamageCount = 0,
                AttackType1 = AttackType.Physical,
                AttackType2 = AttackType.None,
                AttackMode = AttackMode.Normal,
                TricksterWeaponId = 2
            },
            
            new Attack {
                Id = 86,
                Name = "R1 (dash) (Beast's Embrace)",
                Damage = 1,
                ExtraDamage = 0,
                ExtraDamageCount = 0,
                AttackType1 = AttackType.Physical,
                AttackType2 = AttackType.None,
                AttackMode = AttackMode.Normal,
                TricksterWeaponId = 2
            },
            
            new Attack {
                Id = 87,
                Name = "R2 (Beast's Embrace)",
                Damage = 1,
                ExtraDamage = 0,
                ExtraDamageCount = 0,
                AttackType1 = AttackType.Physical,
                AttackType2 = AttackType.None,
                AttackMode = AttackMode.Normal,
                TricksterWeaponId = 2
            },
            
            new Attack {
                Id = 88,
                Name = "R2 (charged) (Beast's Embrace)",
                Damage = 1,
                ExtraDamage = 0,
                ExtraDamageCount = 0,
                AttackType1 = AttackType.Physical,
                AttackType2 = AttackType.None,
                AttackMode = AttackMode.Normal,
                TricksterWeaponId = 2
            },
            
            new Attack {
                Id = 89,
                Name = "R2 (backstep) (Beast's Embrace)",
                Damage = 1,
                ExtraDamage = 0,
                ExtraDamageCount = 0,
                AttackType1 = AttackType.Physical,
                AttackType2 = AttackType.None,
                AttackMode = AttackMode.Normal,
                TricksterWeaponId = 2
            },

            new Attack {
                Id = 90,
                Name = "R2 (dash) (Beast's Embrace)",
                Damage = 1,
                ExtraDamage = 0,
                ExtraDamageCount = 0,
                AttackType1 = AttackType.Thrust,
                AttackType2 = AttackType.None,
                AttackMode = AttackMode.Normal,
                TricksterWeaponId = 2
            },
            
            new Attack {
                Id = 91,
                Name = "R2 (forward leap) (Beast's Embrace)",
                Damage = 1,
                ExtraDamage = 0,
                ExtraDamageCount = 0,
                AttackType1 = AttackType.Physical,
                AttackType2 = AttackType.None,
                AttackMode = AttackMode.Normal,
                TricksterWeaponId = 2
            },
            
            new Attack {
                Id = 92,
                Name = "Transform Attack (Beast's Embrace)",
                Damage = 0,
                ExtraDamage = 1,
                ExtraDamageCount = 1,
                AttackType1 = AttackType.Physical,
                AttackType2 = AttackType.None,
                AttackMode = AttackMode.Normal,
                TricksterWeaponId = 2
            },
            
            new Attack {
                Id = 93,
                Name = "Plunge Attack (Beast's Embrace)",
                Damage = 1,
                ExtraDamage = 0,
                ExtraDamageCount = 0,
                AttackType1 = AttackType.Thrust,
                AttackType2 = AttackType.None,
                AttackMode = AttackMode.Normal,
                TricksterWeaponId = 2
            },
            
            new Attack {
                Id = 94,
                Name = "Plunge Attack (2nd) (Beast's Embrace)",
                Damage = 0,
                ExtraDamage = 0,
                ExtraDamageCount = 0,
                AttackType1 = AttackType.Blunt,
                AttackType2 = AttackType.None,
                AttackMode = AttackMode.Normal,
                TricksterWeaponId = 2
            },
            
            new Attack {
                Id = 95,
                Name = "R1 (Beast's Embrace)",
                Damage = 1,
                ExtraDamage = 0,
                ExtraDamageCount = 0,
                AttackType1 = AttackType.Physical,
                AttackType2 = AttackType.None,
                AttackMode = AttackMode.Transformed,
                TricksterWeaponId = 2
            },
            
            new Attack {
                Id = 96,
                Name = "R1 (2nd) (Beast's Embrace)",
                Damage = 1,
                ExtraDamage = 0,
                ExtraDamageCount = 0,
                AttackType1 = AttackType.Physical,
                AttackType2 = AttackType.None,
                AttackMode = AttackMode.Transformed,
                TricksterWeaponId = 2
            },
            
            new Attack {
                Id = 97,
                Name = "R1 (3rd) (Beast's Embrace)",
                Damage = 1,
                ExtraDamage = 0,
                ExtraDamageCount = 0,
                AttackType1 = AttackType.Physical,
                AttackType2 = AttackType.None,
                AttackMode = AttackMode.Transformed,
                TricksterWeaponId = 2
            },
            
            new Attack {
                Id = 98,
                Name = "R1 (4th) (Beast's Embrace)",
                Damage = 1,
                ExtraDamage = 0,
                ExtraDamageCount = 0,
                AttackType1 = AttackType.Physical,
                AttackType2 = AttackType.None,
                AttackMode = AttackMode.Transformed,
                TricksterWeaponId = 2
            },
            
            new Attack {
                Id = 99,
                Name = "R1 (5th) (Beast's Embrace)",
                Damage = 1,
                ExtraDamage = 0,
                ExtraDamageCount = 0,
                AttackType1 = AttackType.Physical,
                AttackType2 = AttackType.None,
                AttackMode = AttackMode.Transformed,
                TricksterWeaponId = 2
            },
            
            new Attack {
                Id = 100,
                Name = "R1 (backstep) (Beast's Embrace)",
                Damage = 0,
                ExtraDamage = 0,
                ExtraDamageCount = 1,
                AttackType1 = AttackType.Physical,
                AttackType2 = AttackType.None,
                AttackMode = AttackMode.Transformed,
                TricksterWeaponId = 2
            },
            
            new Attack {
                Id = 101,
                Name = "R1 (rolling) (Beast's Embrace)",
                Damage = 0,
                ExtraDamage = 0,
                ExtraDamageCount = 0,
                AttackType1 = AttackType.Physical,
                AttackType2 = AttackType.None,
                AttackMode = AttackMode.Transformed,
                TricksterWeaponId = 2
            },
            
            new Attack {
                Id = 102,
                Name = "R1 (frontstep) (Beast's Embrace)",
                Damage = 0,
                ExtraDamage = 0,
                ExtraDamageCount = 0,
                AttackType1 = AttackType.Physical,
                AttackType2 = AttackType.None,
                AttackMode = AttackMode.Transformed,
                TricksterWeaponId = 2
            },
            
            new Attack {
                Id = 103,
                Name = "R1 (sidestep) (Beast's Embrace)",
                Damage = 0,
                ExtraDamage = 0,
                ExtraDamageCount = 0,
                AttackType1 = AttackType.Physical,
                AttackType2 = AttackType.None,
                AttackMode = AttackMode.Transformed,
                TricksterWeaponId = 2
            },
            
            new Attack {
                Id = 104,
                Name = "R1 (dash) (Beast's Embrace)",
                Damage = 0,
                ExtraDamage = 1,
                ExtraDamageCount = 1,
                AttackType1 = AttackType.Physical,
                AttackType2 = AttackType.None,
                AttackMode = AttackMode.Transformed,
                TricksterWeaponId = 2
            },
            
            new Attack {
                Id = 105,
                Name = "R2 (Beast's Embrace)",
                Damage = 1,
                ExtraDamage = 0,
                ExtraDamageCount = 0,
                AttackType1 = AttackType.Physical,
                AttackType2 = AttackType.None,
                AttackMode = AttackMode.Transformed,
                TricksterWeaponId = 2
            },
            
            new Attack {
                Id = 106,
                Name = "R2 (2nd) (Beast's Embrace)",
                Damage = 1,
                ExtraDamage = 0,
                ExtraDamageCount = 0,
                AttackType1 = AttackType.Physical,
                AttackType2 = AttackType.None,
                AttackMode = AttackMode.Transformed,
                TricksterWeaponId = 2
            },
            
            new Attack {
                Id = 107,
                Name = "R2 (3rd) (Beast's Embrace)",
                Damage = 1,
                ExtraDamage = 0,
                ExtraDamageCount = 0,
                AttackType1 = AttackType.Physical,
                AttackType2 = AttackType.None,
                AttackMode = AttackMode.Transformed,
                TricksterWeaponId = 2
            },
            
            new Attack {
                Id = 108,
                Name = "R2 (backstep) (Beast's Embrace)",
                Damage = 1,
                ExtraDamage = 0,
                ExtraDamageCount = 0,
                AttackType1 = AttackType.Physical,
                AttackType2 = AttackType.None,
                AttackMode = AttackMode.Transformed,
                TricksterWeaponId = 2
            },
            
            new Attack {
                Id = 109,
                Name = "R2 (dash) (Beast's Embrace)",
                Damage = 0,
                ExtraDamage = 1,
                ExtraDamageCount = 1,
                AttackType1 = AttackType.Physical,
                AttackType2 = AttackType.None,
                AttackMode = AttackMode.Transformed,
                TricksterWeaponId = 2
            },
            
            new Attack {
                Id = 110,
                Name = "R2 (forward leap) (Beast's Embrace)",
                Damage = 0,
                ExtraDamage = 1,
                ExtraDamageCount = 1,
                AttackType1 = AttackType.Physical,
                AttackType2 = AttackType.None,
                AttackMode = AttackMode.Transformed,
                TricksterWeaponId = 2
            },
            
            new Attack {
                Id = 111,
                Name = "L2 (Beast's Embrace)",
                Damage = 0,
                ExtraDamage = 0,
                ExtraDamageCount = 0,
                AttackType1 = AttackType.Blunt,
                AttackType2 = AttackType.None,
                AttackMode = AttackMode.Transformed,
                TricksterWeaponId = 2
            },
            
            new Attack {
                Id = 112,
                Name = "L2 (AoE) (Beast's Embrace)",
                Damage = 0,
                ExtraDamage = 0,
                ExtraDamageCount = 0,
                AttackType1 = AttackType.Blunt,
                AttackType2 = AttackType.None,
                AttackMode = AttackMode.Transformed,
                TricksterWeaponId = 2
            },
            
            new Attack {
                Id = 113,
                Name = "Transform Attack (Beast's Embrace)",
                Damage = 1,
                ExtraDamage = 0,
                ExtraDamageCount = 0,
                AttackType1 = AttackType.Physical,
                AttackType2 = AttackType.None,
                AttackMode = AttackMode.Transformed,
                TricksterWeaponId = 2
            },
            
            new Attack {
                Id = 114,
                Name = "Plunge Attack (Beast's Embrace)",
                Damage = 1,
                ExtraDamage = 0,
                ExtraDamageCount = 0,
                AttackType1 = AttackType.Physical,
                AttackType2 = AttackType.None,
                AttackMode = AttackMode.Transformed,
                TricksterWeaponId = 2
            },
            
            new Attack {
                Id = 115,
                Name = "Plunge Attack (2nd) (Beast's Embrace)",
                Damage = 0,
                ExtraDamage = 0,
                ExtraDamageCount = 0,
                AttackType1 = AttackType.Blunt,
                AttackType2 = AttackType.None,
                AttackMode = AttackMode.Transformed,
                TricksterWeaponId = 2
            },
            
            new Attack {
                Id = 116,
                Name = "R1",
                Damage = 1,
                ExtraDamage = 0,
                ExtraDamageCount = 0,
                AttackType1 = AttackType.Blunt,
                AttackType2 = AttackType.None,
                AttackMode = AttackMode.Normal,
                TricksterWeaponId = 3
            },
            
            new Attack {
                Id = 117,
                Name = "R1 (2nd)",
                Damage = 1,
                ExtraDamage = 0,
                ExtraDamageCount = 0,
                AttackType1 = AttackType.Blunt,
                AttackType2 = AttackType.None,
                AttackMode = AttackMode.Normal,
                TricksterWeaponId = 3
            },
            
            new Attack {
                Id = 118,
                Name = "R1 (3rd)",
                Damage = 1,
                ExtraDamage = 0,
                ExtraDamageCount = 0,
                AttackType1 = AttackType.Blunt,
                AttackType2 = AttackType.None,
                AttackMode = AttackMode.Normal,
                TricksterWeaponId = 3
            },
            
            new Attack {
                Id = 119,
                Name = "R1 (4th)",
                Damage = 1,
                ExtraDamage = 0,
                ExtraDamageCount = 0,
                AttackType1 = AttackType.Blunt,
                AttackType2 = AttackType.None,
                AttackMode = AttackMode.Normal,
                TricksterWeaponId = 3
            },
            
            new Attack {
                Id = 120,
                Name = "R1 (5th)",
                Damage = 1,
                ExtraDamage = 0,
                ExtraDamageCount = 0,
                AttackType1 = AttackType.Blunt,
                AttackType2 = AttackType.None,
                AttackMode = AttackMode.Normal,
                TricksterWeaponId = 3
            },
            
            new Attack {
                Id = 121,
                Name = "R1 (backstep)",
                Damage = 0,
                ExtraDamage = 0,
                ExtraDamageCount = 0,
                AttackType1 = AttackType.Blunt,
                AttackType2 = AttackType.None,
                AttackMode = AttackMode.Normal,
                TricksterWeaponId = 3
            },
            
            new Attack {
                Id = 122,
                Name = "R1 (rolling)",
                Damage = 0,
                ExtraDamage = 0,
                ExtraDamageCount = 0,
                AttackType1 = AttackType.Blunt,
                AttackType2 = AttackType.None,
                AttackMode = AttackMode.Normal,
                TricksterWeaponId = 3
            },
            
            new Attack {
                Id = 123,
                Name = "R1 (frontstep)",
                Damage = 0,
                ExtraDamage = 0,
                ExtraDamageCount = 0,
                AttackType1 = AttackType.Blunt,
                AttackType2 = AttackType.None,
                AttackMode = AttackMode.Normal,
                TricksterWeaponId = 3
            },
            
            new Attack {
                Id = 124,
                Name = "R1 (sidestep)",
                Damage = 0,
                ExtraDamage = 0,
                ExtraDamageCount = 0,
                AttackType1 = AttackType.Blunt,
                AttackType2 = AttackType.None,
                AttackMode = AttackMode.Normal,
                TricksterWeaponId = 3
            },
            
            new Attack {
                Id = 125,
                Name = "R1 (dash)",
                Damage = 1,
                ExtraDamage = 0,
                ExtraDamageCount = 0,
                AttackType1 = AttackType.Blunt,
                AttackType2 = AttackType.None,
                AttackMode = AttackMode.Normal,
                TricksterWeaponId = 3
            },
            
            new Attack {
                Id = 126,
                Name = "R2",
                Damage = 1,
                ExtraDamage = 0,
                ExtraDamageCount = 0,
                AttackType1 = AttackType.Blunt,
                AttackType2 = AttackType.None,
                AttackMode = AttackMode.Normal,
                TricksterWeaponId = 3
            },
            
            new Attack {
                Id = 127,
                Name = "R2 (charged)",
                Damage = 1,
                ExtraDamage = 0,
                ExtraDamageCount = 0,
                AttackType1 = AttackType.Blunt,
                AttackType2 = AttackType.None,
                AttackMode = AttackMode.Normal,
                TricksterWeaponId = 3
            },
            
            new Attack {
                Id = 128,
                Name = "R2 (backstep)",
                Damage = 1,
                ExtraDamage = 0,
                ExtraDamageCount = 0,
                AttackType1 = AttackType.Blunt,
                AttackType2 = AttackType.None,
                AttackMode = AttackMode.Normal,
                TricksterWeaponId = 3
            },
            
            new Attack {
                Id = 129,
                Name = "R2 (dash)",
                Damage = 1,
                ExtraDamage = 0,
                ExtraDamageCount = 0,
                AttackType1 = AttackType.Blunt,
                AttackType2 = AttackType.None,
                AttackMode = AttackMode.Normal,
                TricksterWeaponId = 3
            },
            
            new Attack {
                Id = 130,
                Name = "R2 (forward leap)",
                Damage = 1,
                ExtraDamage = 0,
                ExtraDamageCount = 0,
                AttackType1 = AttackType.Blunt,
                AttackType2 = AttackType.None,
                AttackMode = AttackMode.Normal,
                TricksterWeaponId = 3
            },
            
            new Attack {
                Id = 131,
                Name = "Transform Attack",
                Damage = 1,
                ExtraDamage = 0,
                ExtraDamageCount = 0,
                AttackType1 = AttackType.Blunt,
                AttackType2 = AttackType.None,
                AttackMode = AttackMode.Normal,
                TricksterWeaponId = 3
            },
            
            new Attack {
                Id = 132,
                Name = "Plunge Attack",
                Damage = 1,
                ExtraDamage = 0,
                ExtraDamageCount = 0,
                AttackType1 = AttackType.Blunt,
                AttackType2 = AttackType.None,
                AttackMode = AttackMode.Normal,
                TricksterWeaponId = 3
            },
            
            new Attack {
                Id = 133,
                Name = "Plunge Attack (2nd)",
                Damage = 0,
                ExtraDamage = 0,
                ExtraDamageCount = 0,
                AttackType1 = AttackType.Blunt,
                AttackType2 = AttackType.None,
                AttackMode = AttackMode.Normal,
                TricksterWeaponId = 3
            },
            
            new Attack {
                Id = 134,
                Name = "R1",
                Damage = 0,
                ExtraDamage = 0,
                ExtraDamageCount = 0,
                AttackType1 = AttackType.Blunt,
                AttackType2 = AttackType.None,
                AttackMode = AttackMode.Transformed,
                TricksterWeaponId = 3
            },
            
            new Attack {
                Id = 135,
                Name = "R1 (2nd)",
                Damage = 0,
                ExtraDamage = 0,
                ExtraDamageCount = 0,
                AttackType1 = AttackType.Blunt,
                AttackType2 = AttackType.None,
                AttackMode = AttackMode.Transformed,
                TricksterWeaponId = 3
            },
            
            new Attack {
                Id = 136,
                Name = "R1 (3rd)",
                Damage = 1,
                ExtraDamage = 0,
                ExtraDamageCount = 0,
                AttackType1 = AttackType.Blunt,
                AttackType2 = AttackType.None,
                AttackMode = AttackMode.Transformed,
                TricksterWeaponId = 3
            },
            
            new Attack {
                Id = 137,
                Name = "R1 (4th)",
                Damage = 1,
                ExtraDamage = 0,
                ExtraDamageCount = 0,
                AttackType1 = AttackType.Blunt,
                AttackType2 = AttackType.None,
                AttackMode = AttackMode.Transformed,
                TricksterWeaponId = 3
            },
            
            new Attack {
                Id = 138,
                Name = "R1 (backstep)",
                Damage = 0,
                ExtraDamage = 0,
                ExtraDamageCount = 0,
                AttackType1 = AttackType.Blunt,
                AttackType2 = AttackType.None,
                AttackMode = AttackMode.Transformed,
                TricksterWeaponId = 3
            },
            
            new Attack {
                Id = 139,
                Name = "R1 (rolling)",
                Damage = 1,
                ExtraDamage = 0,
                ExtraDamageCount = 0,
                AttackType1 = AttackType.Blunt,
                AttackType2 = AttackType.None,
                AttackMode = AttackMode.Transformed,
                TricksterWeaponId = 3
            },
            
            new Attack {
                Id = 140,
                Name = "R1 (frontstep)",
                Damage = 1,
                ExtraDamage = 0,
                ExtraDamageCount = 0,
                AttackType1 = AttackType.Blunt,
                AttackType2 = AttackType.None,
                AttackMode = AttackMode.Transformed,
                TricksterWeaponId = 3
            },
            
            new Attack {
                Id = 141,
                Name = "R1 (sidestep)",
                Damage = 1,
                ExtraDamage = 0,
                ExtraDamageCount = 0,
                AttackType1 = AttackType.Blunt,
                AttackType2 = AttackType.None,
                AttackMode = AttackMode.Transformed,
                TricksterWeaponId = 3
            },
            
            new Attack {
                Id = 142,
                Name = "R1 (dash)",
                Damage = 1,
                ExtraDamage = 0,
                ExtraDamageCount = 0,
                AttackType1 = AttackType.Blunt,
                AttackType2 = AttackType.None,
                AttackMode = AttackMode.Transformed,
                TricksterWeaponId = 3
            },
            
            new Attack {
                Id = 143,
                Name = "R2",
                Damage = 1,
                ExtraDamage = 0,
                ExtraDamageCount = 0,
                AttackType1 = AttackType.Blunt,
                AttackType2 = AttackType.None,
                AttackMode = AttackMode.Transformed,
                TricksterWeaponId = 3
            },
            
            new Attack {
                Id = 144,
                Name = "R2 (2nd)",
                Damage = 1,
                ExtraDamage = 0,
                ExtraDamageCount = 0,
                AttackType1 = AttackType.Blunt,
                AttackType2 = AttackType.None,
                AttackMode = AttackMode.Transformed,
                TricksterWeaponId = 3
            },
            
            new Attack {
                Id = 145,
                Name = "R2 (backstep)",
                Damage = 1,
                ExtraDamage = 0,
                ExtraDamageCount = 0,
                AttackType1 = AttackType.Blunt,
                AttackType2 = AttackType.None,
                AttackMode = AttackMode.Transformed,
                TricksterWeaponId = 3
            },
            
            new Attack {
                Id = 146,
                Name = "R2 (dash)",
                Damage = 1,
                ExtraDamage = 0,
                ExtraDamageCount = 0,
                AttackType1 = AttackType.Blunt,
                AttackType2 = AttackType.None,
                AttackMode = AttackMode.Transformed,
                TricksterWeaponId = 3
            },
            
            new Attack {
                Id = 147,
                Name = "R2(forward leap)",
                Damage = 1,
                ExtraDamage = 0,
                ExtraDamageCount = 0,
                AttackType1 = AttackType.Blunt,
                AttackType2 = AttackType.None,
                AttackMode = AttackMode.Transformed,
                TricksterWeaponId = 3
            },
            
            new Attack {
                Id = 148,
                Name = "Transform Attack",
                Damage = 1,
                ExtraDamage = 0,
                ExtraDamageCount = 0,
                AttackType1 = AttackType.Blunt,
                AttackType2 = AttackType.None,
                AttackMode = AttackMode.Transformed,
                TricksterWeaponId = 3
            },
            
            new Attack {
                Id = 149,
                Name = "Plunge Attack",
                Damage = 1,
                ExtraDamage = 0,
                ExtraDamageCount = 0,
                AttackType1 = AttackType.Blunt,
                AttackType2 = AttackType.None,
                AttackMode = AttackMode.Transformed,
                TricksterWeaponId = 3
            },
            
            new Attack {
                Id = 150,
                Name = "Plunge Attack (2nd)",
                Damage = 0,
                ExtraDamage = 0,
                ExtraDamageCount = 0,
                AttackType1 = AttackType.Blunt,
                AttackType2 = AttackType.None,
                AttackMode = AttackMode.Transformed,
                TricksterWeaponId = 3
            },
            
            new Attack {
                Id = 151,
                Name = "R1",
                Damage = 1,
                ExtraDamage = 0,
                ExtraDamageCount = 0,
                AttackType1 = AttackType.Physical,
                AttackType2 = AttackType.None,
                AttackMode = AttackMode.Normal,
                TricksterWeaponId = 4
            },
            
            new Attack {
                Id = 152,
                Name = "R1 (2nd)",
                Damage = 1,
                ExtraDamage = 0,
                ExtraDamageCount = 0,
                AttackType1 = AttackType.Physical,
                AttackType2 = AttackType.None,
                AttackMode = AttackMode.Normal,
                TricksterWeaponId = 4
            },
            
            new Attack {
                Id = 153,
                Name = "R1 (3rd)",
                Damage = 1,
                ExtraDamage = 0,
                ExtraDamageCount = 0,
                AttackType1 = AttackType.Physical,
                AttackType2 = AttackType.None,
                AttackMode = AttackMode.Normal,
                TricksterWeaponId = 4
            },
            
            new Attack {
                Id = 154,
                Name = "R1 (4th)",
                Damage = 1,
                ExtraDamage = 0,
                ExtraDamageCount = 0,
                AttackType1 = AttackType.Physical,
                AttackType2 = AttackType.None,
                AttackMode = AttackMode.Normal,
                TricksterWeaponId = 4
            },
            
            new Attack {
                Id = 155,
                Name = "R1 (backstep)",
                Damage = 1,
                ExtraDamage = 0,
                ExtraDamageCount = 0,
                AttackType1 = AttackType.Physical,
                AttackType2 = AttackType.None,
                AttackMode = AttackMode.Normal,
                TricksterWeaponId = 4
            },
            
            new Attack {
                Id = 156,
                Name = "R1 (rolling)",
                Damage = 1,
                ExtraDamage = 0,
                ExtraDamageCount = 0,
                AttackType1 = AttackType.Physical,
                AttackType2 = AttackType.None,
                AttackMode = AttackMode.Normal,
                TricksterWeaponId = 4
            },

            new Attack {
                Id = 157,
                Name = "R1 (frontstep)",
                Damage = 1,
                ExtraDamage = 0,
                ExtraDamageCount = 0,
                AttackType1 = AttackType.Physical,
                AttackType2 = AttackType.None,
                AttackMode = AttackMode.Normal,
                TricksterWeaponId = 4
            },
            
            new Attack {
                Id = 158,
                Name = "R1 (sidestep)",
                Damage = 1,
                ExtraDamage = 0,
                ExtraDamageCount = 0,
                AttackType1 = AttackType.Physical,
                AttackType2 = AttackType.None,
                AttackMode = AttackMode.Normal,
                TricksterWeaponId = 4
            },
            
            new Attack {
                Id = 159,
                Name = "R1 (dash)",
                Damage = 1,
                ExtraDamage = 0,
                ExtraDamageCount = 0,
                AttackType1 = AttackType.Physical,
                AttackType2 = AttackType.None,
                AttackMode = AttackMode.Normal,
                TricksterWeaponId = 4
            },
            
            new Attack {
                Id = 160,
                Name = "R2",
                Damage = 1,
                ExtraDamage = 0,
                ExtraDamageCount = 0,
                AttackType1 = AttackType.Physical,
                AttackType2 = AttackType.None,
                AttackMode = AttackMode.Normal,
                TricksterWeaponId = 4
            },
            
            new Attack {
                Id = 161,
                Name = "R2 (charged)",
                Damage = 1,
                ExtraDamage = 0,
                ExtraDamageCount = 0,
                AttackType1 = AttackType.Blunt,
                AttackType2 = AttackType.None,
                AttackMode = AttackMode.Normal,
                TricksterWeaponId = 4
            },
            
            new Attack {
                Id = 162,
                Name = "R2 (backstep)",
                Damage = 1,
                ExtraDamage = 0,
                ExtraDamageCount = 0,
                AttackType1 = AttackType.Blunt,
                AttackType2 = AttackType.None,
                AttackMode = AttackMode.Normal,
                TricksterWeaponId = 4
            },
            
            new Attack {
                Id = 163,
                Name = "R2 (dash)",
                Damage = 1,
                ExtraDamage = 0,
                ExtraDamageCount = 0,
                AttackType1 = AttackType.Physical,
                AttackType2 = AttackType.None,
                AttackMode = AttackMode.Normal,
                TricksterWeaponId = 4
            },
            
            new Attack {
                Id = 164,
                Name = "R2 (forward leap)",
                Damage = 1,
                ExtraDamage = 0,
                ExtraDamageCount = 0,
                AttackType1 = AttackType.Physical,
                AttackType2 = AttackType.None,
                AttackMode = AttackMode.Normal,
                TricksterWeaponId = 4
            },
            
            new Attack {
                Id = 165,
                Name = "Transform Attack",
                Damage = 1,
                ExtraDamage = 0,
                ExtraDamageCount = 0,
                AttackType1 = AttackType.Physical,
                AttackType2 = AttackType.None,
                AttackMode = AttackMode.Normal,
                TricksterWeaponId = 4
            },
            
            new Attack {
                Id = 166,
                Name = "Plunge Attack",
                Damage = 1,
                ExtraDamage = 0,
                ExtraDamageCount = 0,
                AttackType1 = AttackType.Physical,
                AttackType2 = AttackType.None,
                AttackMode = AttackMode.Normal,
                TricksterWeaponId = 4
            },
            
            new Attack {
                Id = 167,
                Name = "Plunge Attack (2nd)",
                Damage = 0,
                ExtraDamage = 0,
                ExtraDamageCount = 0,
                AttackType1 = AttackType.Blunt,
                AttackType2 = AttackType.None,
                AttackMode = AttackMode.Normal,
                TricksterWeaponId = 4
            },
            
            new Attack {
                Id = 168,
                Name = "R1",
                Damage = 0,
                ExtraDamage = 0,
                ExtraDamageCount = 0,
                AttackType1 = AttackType.Physical,
                AttackType2 = AttackType.None,
                AttackMode = AttackMode.Transformed,
                TricksterWeaponId = 4
            },
            
            new Attack {
                Id = 169,
                Name = "R1 (2nd)",
                Damage = 0,
                ExtraDamage = 0,
                ExtraDamageCount = 0,
                AttackType1 = AttackType.Physical,
                AttackType2 = AttackType.None,
                AttackMode = AttackMode.Transformed,
                TricksterWeaponId = 4
            },
            
            new Attack {
                Id = 170,
                Name = "R1 (3rd)",
                Damage = 1,
                ExtraDamage = 0,
                ExtraDamageCount = 0,
                AttackType1 = AttackType.Physical,
                AttackType2 = AttackType.None,
                AttackMode = AttackMode.Transformed,
                TricksterWeaponId = 4
            },
            
            new Attack {
                Id = 171,
                Name = "R1 (4th)",
                Damage = 1,
                ExtraDamage = 0,
                ExtraDamageCount = 0,
                AttackType1 = AttackType.Physical,
                AttackType2 = AttackType.None,
                AttackMode = AttackMode.Transformed,
                TricksterWeaponId = 4
            },
            
            new Attack {
                Id = 172,
                Name = "R1 (backstep)",
                Damage = 1,
                ExtraDamage = 0,
                ExtraDamageCount = 0,
                AttackType1 = AttackType.Thrust,
                AttackType2 = AttackType.None,
                AttackMode = AttackMode.Transformed,
                TricksterWeaponId = 4
            },
            
            new Attack {
                Id = 173,
                Name = "R1 (rolling)",
                Damage = 0,
                ExtraDamage = 0,
                ExtraDamageCount = 0,
                AttackType1 = AttackType.Physical,
                AttackType2 = AttackType.None,
                AttackMode = AttackMode.Transformed,
                TricksterWeaponId = 4
            },
            
            new Attack {
                Id = 174,
                Name = "R1 (frontstep)",
                Damage = 0,
                ExtraDamage = 0,
                ExtraDamageCount = 0,
                AttackType1 = AttackType.Physical,
                AttackType2 = AttackType.None,
                AttackMode = AttackMode.Transformed,
                TricksterWeaponId = 4
            },
            
            new Attack {
                Id = 175,
                Name = "R1 (sidestep)",
                Damage = 0,
                ExtraDamage = 0,
                ExtraDamageCount = 0,
                AttackType1 = AttackType.Physical,
                AttackType2 = AttackType.None,
                AttackMode = AttackMode.Transformed,
                TricksterWeaponId = 4
            },
            
            new Attack {
                Id = 176,
                Name = "R1 (dash)",
                Damage = 1,
                ExtraDamage = 0,
                ExtraDamageCount = 0,
                AttackType1 = AttackType.Physical,
                AttackType2 = AttackType.None,
                AttackMode = AttackMode.Transformed,
                TricksterWeaponId = 4
            },
            
            new Attack {
                Id = 177,
                Name = "R2",
                Damage = 1,
                ExtraDamage = 0,
                ExtraDamageCount = 0,
                AttackType1 = AttackType.Thrust,
                AttackType2 = AttackType.None,
                AttackMode = AttackMode.Transformed,
                TricksterWeaponId = 4
            },
            
            new Attack {
                Id = 178,
                Name = "R2 (charged)",
                Damage = 1,
                ExtraDamage = 0,
                ExtraDamageCount = 0,
                AttackType1 = AttackType.Blunt,
                AttackType2 = AttackType.None,
                AttackMode = AttackMode.Transformed,
                TricksterWeaponId = 4
            },
            
            new Attack {
                Id = 179,
                Name = "R2 (backstep)",
                Damage = 1,
                ExtraDamage = 0,
                ExtraDamageCount = 0,
                AttackType1 = AttackType.Physical,
                AttackType2 = AttackType.None,
                AttackMode = AttackMode.Transformed,
                TricksterWeaponId = 4
            },
            
            new Attack {
                Id = 180,
                Name = "R2 (dash)",
                Damage = 1,
                ExtraDamage = 0,
                ExtraDamageCount = 0,
                AttackType1 = AttackType.Physical,
                AttackType2 = AttackType.None,
                AttackMode = AttackMode.Transformed,
                TricksterWeaponId = 4
            },
            
            new Attack {
                Id = 181,
                Name = "R2 (forward leap)",
                Damage = 1,
                ExtraDamage = 0,
                ExtraDamageCount = 0,
                AttackType1 = AttackType.Blunt,
                AttackType2 = AttackType.None,
                AttackMode = AttackMode.Transformed,
                TricksterWeaponId = 4
            },
            
            new Attack {
                Id = 182,
                Name = "Transform Attack",
                Damage = 1,
                ExtraDamage = 0,
                ExtraDamageCount = 0,
                AttackType1 = AttackType.Physical,
                AttackType2 = AttackType.None,
                AttackMode = AttackMode.Transformed,
                TricksterWeaponId = 4
            },
            
            new Attack {
                Id = 183,
                Name = "Plunge Attack",
                Damage = 1,
                ExtraDamage = 0,
                ExtraDamageCount = 0,
                AttackType1 = AttackType.Physical,
                AttackType2 = AttackType.None,
                AttackMode = AttackMode.Transformed,
                TricksterWeaponId = 4
            },
            
            new Attack {
                Id = 184,
                Name = "Plunge Attack (2nd)",
                Damage = 0,
                ExtraDamage = 0,
                ExtraDamageCount = 0,
                AttackType1 = AttackType.Blunt,
                AttackType2 = AttackType.None,
                AttackMode = AttackMode.Transformed,
                TricksterWeaponId = 4
            },
            
            new Attack {
                Id = 185,
                Name = "R1",
                Damage = 1,
                ExtraDamage = 0,
                ExtraDamageCount = 0,
                AttackType1 = AttackType.Physical,
                AttackType2 = AttackType.Arcane,
                AttackMode = AttackMode.Normal,
                TricksterWeaponId = 5
            },
            
            new Attack {
                Id = 186,
                Name = "R1 (2nd)",
                Damage = 1,
                ExtraDamage = 0,
                ExtraDamageCount = 0,
                AttackType1 = AttackType.Physical,
                AttackType2 = AttackType.Arcane,
                AttackMode = AttackMode.Normal,
                TricksterWeaponId = 5
            },
            
            new Attack {
                Id = 187,
                Name = "R1 (3rd)",
                Damage = 1,
                ExtraDamage = 0,
                ExtraDamageCount = 0,
                AttackType1 = AttackType.Physical,
                AttackType2 = AttackType.Arcane,
                AttackMode = AttackMode.Normal,
                TricksterWeaponId = 5
            },
            
            new Attack {
                Id = 188,
                Name = "R1 (backstep)",
                Damage = 1,
                ExtraDamage = 0,
                ExtraDamageCount = 0,
                AttackType1 = AttackType.Physical,
                AttackType2 = AttackType.Arcane,
                AttackMode = AttackMode.Normal,
                TricksterWeaponId = 5
            },
            
            new Attack {
                Id = 189,
                Name = "R1 (rolling)",
                Damage = 1,
                ExtraDamage = 0,
                ExtraDamageCount = 0,
                AttackType1 = AttackType.Physical,
                AttackType2 = AttackType.Arcane,
                AttackMode = AttackMode.Normal,
                TricksterWeaponId = 5
            },
            
            new Attack {
                Id = 190,
                Name = "R1 (frontstep)",
                Damage = 1,
                ExtraDamage = 0,
                ExtraDamageCount = 0,
                AttackType1 = AttackType.Physical,
                AttackType2 = AttackType.Arcane,
                AttackMode = AttackMode.Normal,
                TricksterWeaponId = 5
            },
            
            new Attack {
                Id = 191,
                Name = "R1 (sidestep)",
                Damage = 1,
                ExtraDamage = 0,
                ExtraDamageCount = 0,
                AttackType1 = AttackType.Physical,
                AttackType2 = AttackType.Arcane,
                AttackMode = AttackMode.Normal,
                TricksterWeaponId = 5
            },
            
            new Attack {
                Id = 192,
                Name = "R1 (dash)",
                Damage = 1,
                ExtraDamage = 0,
                ExtraDamageCount = 0,
                AttackType1 = AttackType.Thrust,
                AttackType2 = AttackType.Arcane,
                AttackMode = AttackMode.Normal,
                TricksterWeaponId = 5
            },
            
            new Attack {
                Id = 193,
                Name = "R2",
                Damage = 1,
                ExtraDamage = 0,
                ExtraDamageCount = 0,
                AttackType1 = AttackType.Physical,
                AttackType2 = AttackType.Arcane,
                AttackMode = AttackMode.Normal,
                TricksterWeaponId = 5
            },
            
            new Attack {
                Id = 194,
                Name = "R2 (charged)",
                Damage = 2,
                ExtraDamage = 0,
                ExtraDamageCount = 0,
                AttackType1 = AttackType.Physical,
                AttackType2 = AttackType.Arcane,
                AttackMode = AttackMode.Normal,
                TricksterWeaponId = 5
            },
            
            new Attack {
                Id = 195,
                Name = "R2 (backstep)",
                Damage = 1,
                ExtraDamage = 0,
                ExtraDamageCount = 0,
                AttackType1 = AttackType.Thrust,
                AttackType2 = AttackType.Arcane,
                AttackMode = AttackMode.Normal,
                TricksterWeaponId = 5
            },
            
            new Attack {
                Id = 196,
                Name = "R2 (dash)",
                Damage = 1,
                ExtraDamage = 0,
                ExtraDamageCount = 0,
                AttackType1 = AttackType.Physical,
                AttackType2 = AttackType.Arcane,
                AttackMode = AttackMode.Normal,
                TricksterWeaponId = 5
            },
            
            new Attack {
                Id = 197,
                Name = "R2 (forward leap)",
                Damage = 1,
                ExtraDamage = 0,
                ExtraDamageCount = 0,
                AttackType1 = AttackType.Physical,
                AttackType2 = AttackType.Arcane,
                AttackMode = AttackMode.Normal,
                TricksterWeaponId = 5
            },
            
            new Attack {
                Id = 198,
                Name = "Transform Attack",
                Damage = 1,
                ExtraDamage = 0,
                ExtraDamageCount = 0,
                AttackType1 = AttackType.Physical,
                AttackType2 = AttackType.Arcane,
                AttackMode = AttackMode.Normal,
                TricksterWeaponId = 5
            },
            
            new Attack {
                Id = 199,
                Name = "Plunge Attack",
                Damage = 1,
                ExtraDamage = 0,
                ExtraDamageCount = 0,
                AttackType1 = AttackType.Thrust,
                AttackType2 = AttackType.Arcane,
                AttackMode = AttackMode.Normal,
                TricksterWeaponId = 5
            },
            
            new Attack {
                Id = 200,
                Name = "Plunge Attack (2nd)",
                Damage = 0,
                ExtraDamage = 0,
                ExtraDamageCount = 0,
                AttackType1 = AttackType.Blunt,
                AttackType2 = AttackType.Arcane,
                AttackMode = AttackMode.Normal,
                TricksterWeaponId = 5
            },
            
            new Attack {
                Id = 201,
                Name = "R1",
                Damage = 0,
                ExtraDamage = 0,
                ExtraDamageCount = 0,
                AttackType1 = AttackType.Physical,
                AttackType2 = AttackType.Arcane,
                AttackMode = AttackMode.Transformed,
                TricksterWeaponId = 5
            },
            
            new Attack {
                Id = 202,
                Name = "R1 (2nd)",
                Damage = 0,
                ExtraDamage = 0,
                ExtraDamageCount = 0,
                AttackType1 = AttackType.Physical,
                AttackType2 = AttackType.Arcane,
                AttackMode = AttackMode.Transformed,
                TricksterWeaponId = 5
            },
            
            new Attack {
                Id = 203,
                Name = "R1 (3rd)",
                Damage = 0,
                ExtraDamage = 0,
                ExtraDamageCount = 0,
                AttackType1 = AttackType.Physical,
                AttackType2 = AttackType.Arcane,
                AttackMode = AttackMode.Transformed,
                TricksterWeaponId = 5
            },
            
            new Attack {
                Id = 204,
                Name = "R1 (4th)",
                Damage = 1,
                ExtraDamage = 0,
                ExtraDamageCount = 0,
                AttackType1 = AttackType.Physical,
                AttackType2 = AttackType.Arcane,
                AttackMode = AttackMode.Transformed,
                TricksterWeaponId = 5
            },
            
            new Attack {
                Id = 205,
                Name = "R1 (5th)",
                Damage = 1,
                ExtraDamage = 0,
                ExtraDamageCount = 0,
                AttackType1 = AttackType.Thrust,
                AttackType2 = AttackType.Arcane,
                AttackMode = AttackMode.Transformed,
                TricksterWeaponId = 5
            },
            
            new Attack {
                Id = 206,
                Name = "R1 (6th)",
                Damage = 1,
                ExtraDamage = 0,
                ExtraDamageCount = 0,
                AttackType1 = AttackType.Physical,
                AttackType2 = AttackType.Arcane,
                AttackMode = AttackMode.Transformed,
                TricksterWeaponId = 5
            },
            
            new Attack {
                Id = 207,
                Name = "R1 (7th)",
                Damage = 1,
                ExtraDamage = 0,
                ExtraDamageCount = 0,
                AttackType1 = AttackType.Physical,
                AttackType2 = AttackType.Arcane,
                AttackMode = AttackMode.Transformed,
                TricksterWeaponId = 5
            },
            
            new Attack {
                Id = 208,
                Name = "R1 (8th)",
                Damage = 1,
                ExtraDamage = 0,
                ExtraDamageCount = 0,
                AttackType1 = AttackType.Thrust,
                AttackType2 = AttackType.Arcane,
                AttackMode = AttackMode.Transformed,
                TricksterWeaponId = 5
            },
            
            new Attack {
                Id = 209,
                Name = "R1 (backstep)",
                Damage = 1,
                ExtraDamage = 0,
                ExtraDamageCount = 0,
                AttackType1 = AttackType.Physical,
                AttackType2 = AttackType.Arcane,
                AttackMode = AttackMode.Transformed,
                TricksterWeaponId = 5
            },
            
            new Attack {
                Id = 210,
                Name = "R1 (rolling)",
                Damage = 1,
                ExtraDamage = 0,
                ExtraDamageCount = 0,
                AttackType1 = AttackType.Thrust,
                AttackType2 = AttackType.Arcane,
                AttackMode = AttackMode.Transformed,
                TricksterWeaponId = 5
            },
            
            new Attack {
                Id = 211,
                Name = "R1 (frontstep)",
                Damage = 1,
                ExtraDamage = 0,
                ExtraDamageCount = 0,
                AttackType1 = AttackType.Thrust,
                AttackType2 = AttackType.Arcane,
                AttackMode = AttackMode.Transformed,
                TricksterWeaponId = 5
            },
            
            new Attack {
                Id = 212,
                Name = "R1 (sidestep)",
                Damage = 1,
                ExtraDamage = 0,
                ExtraDamageCount = 0,
                AttackType1 = AttackType.Physical,
                AttackType2 = AttackType.Arcane,
                AttackMode = AttackMode.Transformed,
                TricksterWeaponId = 5
            },
            
            new Attack {
                Id = 213,
                Name = "R1 (dash)",
                Damage = 1,
                ExtraDamage = 0,
                ExtraDamageCount = 0,
                AttackType1 = AttackType.Thrust,
                AttackType2 = AttackType.Arcane,
                AttackMode = AttackMode.Transformed,
                TricksterWeaponId = 5
            },
            
            new Attack {
                Id = 214,
                Name = "R2",
                Damage = 1,
                ExtraDamage = 0,
                ExtraDamageCount = 0,
                AttackType1 = AttackType.Physical,
                AttackType2 = AttackType.Arcane,
                AttackMode = AttackMode.Transformed,
                TricksterWeaponId = 5
            },
            
            new Attack {
                Id = 215,
                Name = "R2 (2nd)",
                Damage = 1,
                ExtraDamage = 0,
                ExtraDamageCount = 0,
                AttackType1 = AttackType.Physical,
                AttackType2 = AttackType.Arcane,
                AttackMode = AttackMode.Transformed,
                TricksterWeaponId = 5
            },
            
            new Attack {
                Id = 216,
                Name = "R2 (backstep)",
                Damage = 1,
                ExtraDamage = 0,
                ExtraDamageCount = 0,
                AttackType1 = AttackType.Physical,
                AttackType2 = AttackType.Arcane,
                AttackMode = AttackMode.Transformed,
                TricksterWeaponId = 5
            },
            
            new Attack {
                Id = 217,
                Name = "R2 (dash)",
                Damage = 1,
                ExtraDamage = 0,
                ExtraDamageCount = 0,
                AttackType1 = AttackType.Physical,
                AttackType2 = AttackType.Arcane,
                AttackMode = AttackMode.Transformed,
                TricksterWeaponId = 5
            },
            
            new Attack {
                Id = 218,
                Name = "R2 (forward leap)",
                Damage = 1,
                ExtraDamage = 0,
                ExtraDamageCount = 0,
                AttackType1 = AttackType.Thrust,
                AttackType2 = AttackType.Arcane,
                AttackMode = AttackMode.Transformed,
                TricksterWeaponId = 5
            },
            
            new Attack {
                Id = 219,
                Name = "L2",
                Damage = 1,
                ExtraDamage = 0,
                ExtraDamageCount = 0,
                AttackType1 = AttackType.Physical,
                AttackType2 = AttackType.Arcane,
                AttackMode = AttackMode.Transformed,
                TricksterWeaponId = 5
            },
            
            new Attack {
                Id = 220,
                Name = "Transform Attack",
                Damage = 1,
                ExtraDamage = 0,
                ExtraDamageCount = 0,
                AttackType1 = AttackType.Physical,
                AttackType2 = AttackType.Arcane,
                AttackMode = AttackMode.Transformed,
                TricksterWeaponId = 5
            },
            
            new Attack {
                Id = 221,
                Name = "Plunge Attack",
                Damage = 1,
                ExtraDamage = 0,
                ExtraDamageCount = 0,
                AttackType1 = AttackType.Physical,
                AttackType2 = AttackType.Arcane,
                AttackMode = AttackMode.Transformed,
                TricksterWeaponId = 5
            },
            
            new Attack {
                Id = 222,
                Name = "Plunge Attack (2nd)",
                Damage = 0,
                ExtraDamage = 0,
                ExtraDamageCount = 0,
                AttackType1 = AttackType.Blunt,
                AttackType2 = AttackType.Arcane,
                AttackMode = AttackMode.Transformed,
                TricksterWeaponId = 5
            },
            
            new Attack {
                Id = 223,
                Name = "R1",
                Damage = 1,
                ExtraDamage = 0,
                ExtraDamageCount = 0,
                AttackType1 = AttackType.Blunt,
                AttackType2 = AttackType.None,
                AttackMode = AttackMode.Normal,
                TricksterWeaponId = 6
            },
            
            new Attack {
                Id = 224,
                Name = "R1 (2nd)",
                Damage = 1,
                ExtraDamage = 0,
                ExtraDamageCount = 0,
                AttackType1 = AttackType.Blunt,
                AttackType2 = AttackType.None,
                AttackMode = AttackMode.Normal,
                TricksterWeaponId = 6
            },
            
            new Attack {
                Id = 225,
                Name = "R1 (3rd)",
                Damage = 1,
                ExtraDamage = 0,
                ExtraDamageCount = 0,
                AttackType1 = AttackType.Blunt,
                AttackType2 = AttackType.None,
                AttackMode = AttackMode.Normal,
                TricksterWeaponId = 6
            },
            
            new Attack {
                Id = 226,
                Name = "R1 (4th)",
                Damage = 1,
                ExtraDamage = 0,
                ExtraDamageCount = 0,
                AttackType1 = AttackType.Thrust,
                AttackType2 = AttackType.None,
                AttackMode = AttackMode.Normal,
                TricksterWeaponId = 6
            },
            
            new Attack {
                Id = 227,
                Name = "R1 (backstep)",
                Damage = 0,
                ExtraDamage = 0,
                ExtraDamageCount = 0,
                AttackType1 = AttackType.Blunt,
                AttackType2 = AttackType.None,
                AttackMode = AttackMode.Normal,
                TricksterWeaponId = 6
            },
            
            new Attack {
                Id = 228,
                Name = "R1 (rolling)",
                Damage = 0,
                ExtraDamage = 0,
                ExtraDamageCount = 0,
                AttackType1 = AttackType.Blunt,
                AttackType2 = AttackType.None,
                AttackMode = AttackMode.Normal,
                TricksterWeaponId = 6
            },

            new Attack {
                Id = 229,
                Name = "R1 (frontstep)",
                Damage = 0,
                ExtraDamage = 0,
                ExtraDamageCount = 0,
                AttackType1 = AttackType.Blunt,
                AttackType2 = AttackType.None,
                AttackMode = AttackMode.Normal,
                TricksterWeaponId = 6
            },
            
            new Attack {
                Id = 230,
                Name = "R1 (sidestep)",
                Damage = 0,
                ExtraDamage = 0,
                ExtraDamageCount = 0,
                AttackType1 = AttackType.Blunt,
                AttackType2 = AttackType.None,
                AttackMode = AttackMode.Normal,
                TricksterWeaponId = 6
            },
            
            new Attack {
                Id = 231,
                Name = "R1 (dash)",
                Damage = 1,
                ExtraDamage = 0,
                ExtraDamageCount = 0,
                AttackType1 = AttackType.Thrust,
                AttackType2 = AttackType.None,
                AttackMode = AttackMode.Normal,
                TricksterWeaponId = 6
            },
            
            new Attack {
                Id = 232,
                Name = "R2",
                Damage = 1,
                ExtraDamage = 0,
                ExtraDamageCount = 0,
                AttackType1 = AttackType.Thrust,
                AttackType2 = AttackType.None,
                AttackMode = AttackMode.Normal,
                TricksterWeaponId = 6
            },
            
            new Attack {
                Id = 233,
                Name = "R2 (charged)",
                Damage = 1,
                ExtraDamage = 0,
                ExtraDamageCount = 0,
                AttackType1 = AttackType.Blunt,
                AttackType2 = AttackType.None,
                AttackMode = AttackMode.Normal,
                TricksterWeaponId = 6
            },
            
            new Attack {
                Id = 234,
                Name = "R2 (backstep)",
                Damage = 1,
                ExtraDamage = 0,
                ExtraDamageCount = 0,
                AttackType1 = AttackType.Blunt,
                AttackType2 = AttackType.None,
                AttackMode = AttackMode.Normal,
                TricksterWeaponId = 6
            },
            
            new Attack {
                Id = 235,
                Name = "R2 (dash)",
                Damage = 1,
                ExtraDamage = 0,
                ExtraDamageCount = 0,
                AttackType1 = AttackType.Blunt,
                AttackType2 = AttackType.None,
                AttackMode = AttackMode.Normal,
                TricksterWeaponId = 6
            },
            
            new Attack {
                Id = 236,
                Name = "R2 (forward leap)",
                Damage = 1,
                ExtraDamage = 0,
                ExtraDamageCount = 0,
                AttackType1 = AttackType.Blunt,
                AttackType2 = AttackType.None,
                AttackMode = AttackMode.Normal,
                TricksterWeaponId = 6
            },
            
            new Attack {
                Id = 237,
                Name = "Transform Attack",
                Damage = 1,
                ExtraDamage = 0,
                ExtraDamageCount = 0,
                AttackType1 = AttackType.Blood,
                AttackType2 = AttackType.None,
                AttackMode = AttackMode.Normal,
                TricksterWeaponId = 6
            },
            
            new Attack {
                Id = 238,
                Name = "Plunge Attack",
                Damage = 1,
                ExtraDamage = 0,
                ExtraDamageCount = 0,
                AttackType1 = AttackType.Blunt,
                AttackType2 = AttackType.None,
                AttackMode = AttackMode.Normal,
                TricksterWeaponId = 6
            },
            
            new Attack {
                Id = 239,
                Name = "Plunge Attack (2nd)",
                Damage = 0,
                ExtraDamage = 0,
                ExtraDamageCount = 0,
                AttackType1 = AttackType.Blunt,
                AttackType2 = AttackType.None,
                AttackMode = AttackMode.Normal,
                TricksterWeaponId = 6
            },
            
            new Attack {
                Id = 240,
                Name = "R1",
                Damage = 1,
                ExtraDamage = 0,
                ExtraDamageCount = 0,
                AttackType1 = AttackType.Blood,
                AttackType2 = AttackType.None,
                AttackMode = AttackMode.Transformed,
                TricksterWeaponId = 6
            },
            
            new Attack {
                Id = 241,
                Name = "R1 (2nd)",
                Damage = 1,
                ExtraDamage = 0,
                ExtraDamageCount = 0,
                AttackType1 = AttackType.Blood,
                AttackType2 = AttackType.None,
                AttackMode = AttackMode.Transformed,
                TricksterWeaponId = 6
            },
            
            new Attack {
                Id = 242,
                Name = "R1 (3rd)",
                Damage = 1,
                ExtraDamage = 0,
                ExtraDamageCount = 0,
                AttackType1 = AttackType.Blood,
                AttackType2 = AttackType.None,
                AttackMode = AttackMode.Transformed,
                TricksterWeaponId = 6
            },
            
            new Attack {
                Id = 243,
                Name = "R1 (4th)",
                Damage = 1,
                ExtraDamage = 0,
                ExtraDamageCount = 0,
                AttackType1 = AttackType.Blood,
                AttackType2 = AttackType.None,
                AttackMode = AttackMode.Transformed,
                TricksterWeaponId = 6
            },
            
            new Attack {
                Id = 244,
                Name = "R1 (5th)",
                Damage = 1,
                ExtraDamage = 0,
                ExtraDamageCount = 0,
                AttackType1 = AttackType.Blood,
                AttackType2 = AttackType.None,
                AttackMode = AttackMode.Transformed,
                TricksterWeaponId = 6
            },
            
            new Attack {
                Id = 245,
                Name = "R1 (backstep)",
                Damage = 1,
                ExtraDamage = 0,
                ExtraDamageCount = 0,
                AttackType1 = AttackType.Blood,
                AttackType2 = AttackType.None,
                AttackMode = AttackMode.Transformed,
                TricksterWeaponId = 6
            },
            
            new Attack {
                Id = 246,
                Name = "R1 (rolling)",
                Damage = 1,
                ExtraDamage = 0,
                ExtraDamageCount = 0,
                AttackType1 = AttackType.Blood,
                AttackType2 = AttackType.None,
                AttackMode = AttackMode.Transformed,
                TricksterWeaponId = 6
            },
            
            new Attack {
                Id = 247,
                Name = "R1 (frontstep)",
                Damage = 1,
                ExtraDamage = 0,
                ExtraDamageCount = 0,
                AttackType1 = AttackType.Blood,
                AttackType2 = AttackType.None,
                AttackMode = AttackMode.Transformed,
                TricksterWeaponId = 6
            },
            
            new Attack {
                Id = 248,
                Name = "R1 (sidestep)",
                Damage = 1,
                ExtraDamage = 0,
                ExtraDamageCount = 0,
                AttackType1 = AttackType.Blood,
                AttackType2 = AttackType.None,
                AttackMode = AttackMode.Transformed,
                TricksterWeaponId = 6
            },
            
            new Attack {
                Id = 249,
                Name = "R1 (dash)",
                Damage = 1,
                ExtraDamage = 0,
                ExtraDamageCount = 0,
                AttackType1 = AttackType.Blood,
                AttackType2 = AttackType.None,
                AttackMode = AttackMode.Transformed,
                TricksterWeaponId = 6
            },
            
            new Attack {
                Id = 250,
                Name = "R2",
                Damage = 1,
                ExtraDamage = 0,
                ExtraDamageCount = 0,
                AttackType1 = AttackType.Blood,
                AttackType2 = AttackType.None,
                AttackMode = AttackMode.Transformed,
                TricksterWeaponId = 6
            },
            
            new Attack {
                Id = 251,
                Name = "R2 (charged)",
                Damage = 2,
                ExtraDamage = 0,
                ExtraDamageCount = 0,
                AttackType1 = AttackType.Blood,
                AttackType2 = AttackType.None,
                AttackMode = AttackMode.Transformed,
                TricksterWeaponId = 6
            },
            
            new Attack {
                Id = 252,
                Name = "R2 (backstep)",
                Damage = 1,
                ExtraDamage = 0,
                ExtraDamageCount = 0,
                AttackType1 = AttackType.Blood,
                AttackType2 = AttackType.None,
                AttackMode = AttackMode.Transformed,
                TricksterWeaponId = 6
            },
            
            new Attack {
                Id = 253,
                Name = "R2 (dash)",
                Damage = 1,
                ExtraDamage = 0,
                ExtraDamageCount = 0,
                AttackType1 = AttackType.Blood,
                AttackType2 = AttackType.None,
                AttackMode = AttackMode.Transformed,
                TricksterWeaponId = 6
            },
            
            new Attack {
                Id = 254,
                Name = "R2 (forward leap)",
                Damage = 1,
                ExtraDamage = 0,
                ExtraDamageCount = 0,
                AttackType1 = AttackType.Blood,
                AttackType2 = AttackType.None,
                AttackMode = AttackMode.Transformed,
                TricksterWeaponId = 6
            },
            
            new Attack {
                Id = 255,
                Name = "L2",
                Damage = 2,
                ExtraDamage = 0,
                ExtraDamageCount = 0,
                AttackType1 = AttackType.Blood,
                AttackType2 = AttackType.None,
                AttackMode = AttackMode.Transformed,
                TricksterWeaponId = 6
            },
            
            new Attack {
                Id = 256,
                Name = "Transform Attack",
                Damage = 1,
                ExtraDamage = 0,
                ExtraDamageCount = 0,
                AttackType1 = AttackType.Blood,
                AttackType2 = AttackType.None,
                AttackMode = AttackMode.Transformed,
                TricksterWeaponId = 6
            },
            
            new Attack {
                Id = 257,
                Name = "Plunge Attack",
                Damage = 1,
                ExtraDamage = 0,
                ExtraDamageCount = 0,
                AttackType1 = AttackType.Blood,
                AttackType2 = AttackType.None,
                AttackMode = AttackMode.Transformed,
                TricksterWeaponId = 6
            },
            
            new Attack {
                Id = 258,
                Name = "Plunge Attack (2nd)",
                Damage = 0,
                ExtraDamage = 0,
                ExtraDamageCount = 0,
                AttackType1 = AttackType.Blunt,
                AttackType2 = AttackType.None,
                AttackMode = AttackMode.Transformed,
                TricksterWeaponId = 6
            },
            
            new Attack {
                Id = 259,
                Name = "R1",
                Damage = 1,
                ExtraDamage = 0,
                ExtraDamageCount = 0,
                AttackType1 = AttackType.Blunt,
                AttackType2 = AttackType.None,
                AttackMode = AttackMode.Normal,
                TricksterWeaponId = 7
            },
            
            new Attack {
                Id = 260,
                Name = "R1 (2nd)",
                Damage = 1,
                ExtraDamage = 0,
                ExtraDamageCount = 0,
                AttackType1 = AttackType.Blunt,
                AttackType2 = AttackType.None,
                AttackMode = AttackMode.Normal,
                TricksterWeaponId = 7
            },
            
            new Attack {
                Id = 261,
                Name = "R1 (3rd)",
                Damage = 1,
                ExtraDamage = 0,
                ExtraDamageCount = 0,
                AttackType1 = AttackType.Blunt,
                AttackType2 = AttackType.None,
                AttackMode = AttackMode.Normal,
                TricksterWeaponId = 7
            },
            
            new Attack {
                Id = 262,
                Name = "R1 (backstep)",
                Damage = 0,
                ExtraDamage = 0,
                ExtraDamageCount = 0,
                AttackType1 = AttackType.Blunt,
                AttackType2 = AttackType.None,
                AttackMode = AttackMode.Normal,
                TricksterWeaponId = 7
            },
            
            new Attack {
                Id = 263,
                Name = "R1 (rolling)",
                Damage = 0,
                ExtraDamage = 0,
                ExtraDamageCount = 0,
                AttackType1 = AttackType.Blunt,
                AttackType2 = AttackType.None,
                AttackMode = AttackMode.Normal,
                TricksterWeaponId = 7
            },
            
            new Attack {
                Id = 264,
                Name = "R1 (frontstep)",
                Damage = 0,
                ExtraDamage = 0,
                ExtraDamageCount = 0,
                AttackType1 = AttackType.Blunt,
                AttackType2 = AttackType.None,
                AttackMode = AttackMode.Normal,
                TricksterWeaponId = 7
            },
            
            new Attack {
                Id = 265,
                Name = "R1 (sidestep)",
                Damage = 0,
                ExtraDamage = 0,
                ExtraDamageCount = 0,
                AttackType1 = AttackType.Blunt,
                AttackType2 = AttackType.None,
                AttackMode = AttackMode.Normal,
                TricksterWeaponId = 7
            },
            
            new Attack {
                Id = 266,
                Name = "R1 (dash)",
                Damage = 1,
                ExtraDamage = 0,
                ExtraDamageCount = 0,
                AttackType1 = AttackType.Blunt,
                AttackType2 = AttackType.None,
                AttackMode = AttackMode.Normal,
                TricksterWeaponId = 7
            },
            
            new Attack {
                Id = 267,
                Name = "R2",
                Damage = 1,
                ExtraDamage = 0,
                ExtraDamageCount = 0,
                AttackType1 = AttackType.Blunt,
                AttackType2 = AttackType.None,
                AttackMode = AttackMode.Normal,
                TricksterWeaponId = 7
            },
            
            new Attack {
                Id = 268,
                Name = "R2 (charged)",
                Damage = 1,
                ExtraDamage = 0,
                ExtraDamageCount = 0,
                AttackType1 = AttackType.Blunt,
                AttackType2 = AttackType.None,
                AttackMode = AttackMode.Normal,
                TricksterWeaponId = 7
            },
            
            new Attack {
                Id = 269,
                Name = "R2 (backstep)",
                Damage = 1,
                ExtraDamage = 0,
                ExtraDamageCount = 0,
                AttackType1 = AttackType.Blunt,
                AttackType2 = AttackType.None,
                AttackMode = AttackMode.Normal,
                TricksterWeaponId = 7
            },
            
            new Attack {
                Id = 270,
                Name = "R2 (dash)",
                Damage = 1,
                ExtraDamage = 0,
                ExtraDamageCount = 0,
                AttackType1 = AttackType.Blunt,
                AttackType2 = AttackType.None,
                AttackMode = AttackMode.Normal,
                TricksterWeaponId = 7
            },
            
            new Attack {
                Id = 271,
                Name = "R2 (forward leap)",
                Damage = 1,
                ExtraDamage = 0,
                ExtraDamageCount = 0,
                AttackType1 = AttackType.Blunt,
                AttackType2 = AttackType.None,
                AttackMode = AttackMode.Normal,
                TricksterWeaponId = 7
            },
            
            new Attack {
                Id = 272,
                Name = "Transform Attack",
                Damage = 0,
                ExtraDamage = 0,
                ExtraDamageCount = 0,
                AttackType1 = AttackType.Blunt,
                AttackType2 = AttackType.None,
                AttackMode = AttackMode.Normal,
                TricksterWeaponId = 7
            },
            
            new Attack {
                Id = 273,
                Name = "Plunge Attack",
                Damage = 1,
                ExtraDamage = 0,
                ExtraDamageCount = 0,
                AttackType1 = AttackType.Blunt,
                AttackType2 = AttackType.None,
                AttackMode = AttackMode.Normal,
                TricksterWeaponId = 7
            },
            
            new Attack {
                Id = 274,
                Name = "Plunge Attack (2nd)",
                Damage = 0,
                ExtraDamage = 0,
                ExtraDamageCount = 0,
                AttackType1 = AttackType.Blunt,
                AttackType2 = AttackType.None,
                AttackMode = AttackMode.Normal,
                TricksterWeaponId = 7
            },
            
            new Attack {
                Id = 275,
                Name = "R1",
                Damage = 1,
                ExtraDamage = 0,
                ExtraDamageCount = 1,
                AttackType1 = AttackType.Blunt,
                AttackType2 = AttackType.Fire,
                AttackMode = AttackMode.Transformed,
                TricksterWeaponId = 7
            },
            
            new Attack {
                Id = 276,
                Name = "R1 (2nd)",
                Damage = 1,
                ExtraDamage = 0,
                ExtraDamageCount = 1,
                AttackType1 = AttackType.Blunt,
                AttackType2 = AttackType.Fire,
                AttackMode = AttackMode.Transformed,
                TricksterWeaponId = 7
            },
            
            new Attack {
                Id = 277,
                Name = "R1 (3rd)",
                Damage = 1,
                ExtraDamage = 0,
                ExtraDamageCount = 1,
                AttackType1 = AttackType.Blunt,
                AttackType2 = AttackType.Fire,
                AttackMode = AttackMode.Transformed,
                TricksterWeaponId = 7
            },
            
            new Attack {
                Id = 278,
                Name = "R1 (backstep)",
                Damage = 0,
                ExtraDamage = 0,
                ExtraDamageCount = 1,
                AttackType1 = AttackType.Blunt,
                AttackType2 = AttackType.Fire,
                AttackMode = AttackMode.Transformed,
                TricksterWeaponId = 7
            },
            
            new Attack {
                Id = 279,
                Name = "R1 (rolling)",
                Damage = 0,
                ExtraDamage = 0,
                ExtraDamageCount = 1,
                AttackType1 = AttackType.Blunt,
                AttackType2 = AttackType.Fire,
                AttackMode = AttackMode.Transformed,
                TricksterWeaponId = 7
            },
            
            new Attack {
                Id = 280,
                Name = "R1 (frontstep)",
                Damage = 0,
                ExtraDamage = 0,
                ExtraDamageCount = 1,
                AttackType1 = AttackType.Blunt,
                AttackType2 = AttackType.Fire,
                AttackMode = AttackMode.Transformed,
                TricksterWeaponId = 7
            },
            
            new Attack {
                Id = 281,
                Name = "R1 (sidestep)",
                Damage = 0,
                ExtraDamage = 0,
                ExtraDamageCount = 1,
                AttackType1 = AttackType.Blunt,
                AttackType2 = AttackType.Fire,
                AttackMode = AttackMode.Transformed,
                TricksterWeaponId = 7
            },
            
            new Attack {
                Id = 282,
                Name = "R1 (dash)",
                Damage = 1,
                ExtraDamage = 0,
                ExtraDamageCount = 1,
                AttackType1 = AttackType.Blunt,
                AttackType2 = AttackType.Fire,
                AttackMode = AttackMode.Transformed,
                TricksterWeaponId = 7
            },
            
            new Attack {
                Id = 283,
                Name = "R2",
                Damage = 1,
                ExtraDamage = 0,
                ExtraDamageCount = 1,
                AttackType1 = AttackType.Blunt,
                AttackType2 = AttackType.Fire,
                AttackMode = AttackMode.Transformed,
                TricksterWeaponId = 7
            },
            
            new Attack {
                Id = 284,
                Name = "R2 (charged)",
                Damage = 1,
                ExtraDamage = 0,
                ExtraDamageCount = 1,
                AttackType1 = AttackType.Blunt,
                AttackType2 = AttackType.Fire,
                AttackMode = AttackMode.Transformed,
                TricksterWeaponId = 7
            },
            
            new Attack {
                Id = 285,
                Name = "R2 (backstep)",
                Damage = 1,
                ExtraDamage = 0,
                ExtraDamageCount = 1,
                AttackType1 = AttackType.Blunt,
                AttackType2 = AttackType.Fire,
                AttackMode = AttackMode.Transformed,
                TricksterWeaponId = 7
            },
            
            new Attack {
                Id = 286,
                Name = "R2 (dash)",
                Damage = 1,
                ExtraDamage = 0,
                ExtraDamageCount = 1,
                AttackType1 = AttackType.Blunt,
                AttackType2 = AttackType.Fire,
                AttackMode = AttackMode.Transformed,
                TricksterWeaponId = 7
            },
            
            new Attack {
                Id = 287,
                Name = "R2 (forward leap)",
                Damage = 1,
                ExtraDamage = 0,
                ExtraDamageCount = 1,
                AttackType1 = AttackType.Blunt,
                AttackType2 = AttackType.Fire,
                AttackMode = AttackMode.Transformed,
                TricksterWeaponId = 7
            },
            
            new Attack {
                Id = 288,
                Name = "Transform Attack",
                Damage = 0,
                ExtraDamage = 0,
                ExtraDamageCount = 1,
                AttackType1 = AttackType.Blunt,
                AttackType2 = AttackType.Fire,
                AttackMode = AttackMode.Transformed,
                TricksterWeaponId = 7
            },
            
            new Attack {
                Id = 289,
                Name = "Plunge Attack",
                Damage = 1,
                ExtraDamage = 0,
                ExtraDamageCount = 1,
                AttackType1 = AttackType.Blunt,
                AttackType2 = AttackType.Fire,
                AttackMode = AttackMode.Transformed,
                TricksterWeaponId = 7
            },
            
            new Attack {
                Id = 290,
                Name = "Plunge Attack (2nd)",
                Damage = 0,
                ExtraDamage = 0,
                ExtraDamageCount = 1,
                AttackType1 = AttackType.Blunt,
                AttackType2 = AttackType.Fire,
                AttackMode = AttackMode.Transformed,
                TricksterWeaponId = 7
            },
            
            new Attack {
                Id = 291,
                Name = "R1",
                Damage = 1,
                ExtraDamage = 0,
                ExtraDamageCount = 0,
                AttackType1 = AttackType.Physical,
                AttackType2 = AttackType.Arcane,
                AttackMode = AttackMode.Normal,
                TricksterWeaponId = 8
            },
            
            new Attack {
                Id = 292,
                Name = "R1 (2nd)",
                Damage = 1,
                ExtraDamage = 0,
                ExtraDamageCount = 0,
                AttackType1 = AttackType.Physical,
                AttackType2 = AttackType.Arcane,
                AttackMode = AttackMode.Normal,
                TricksterWeaponId = 8
            },
            
            new Attack {
                Id = 293,
                Name = "R1 (3rd)",
                Damage = 1,
                ExtraDamage = 0,
                ExtraDamageCount = 0,
                AttackType1 = AttackType.Physical,
                AttackType2 = AttackType.Arcane,
                AttackMode = AttackMode.Normal,
                TricksterWeaponId = 8
            },
            
            new Attack {
                Id = 294,
                Name = "R1 (4th)",
                Damage = 1,
                ExtraDamage = 0,
                ExtraDamageCount = 0,
                AttackType1 = AttackType.Physical,
                AttackType2 = AttackType.Arcane,
                AttackMode = AttackMode.Normal,
                TricksterWeaponId = 8
            },
            
            new Attack {
                Id = 295,
                Name = "R1 (5th)",
                Damage = 1,
                ExtraDamage = 0,
                ExtraDamageCount = 0,
                AttackType1 = AttackType.Physical,
                AttackType2 = AttackType.Arcane,
                AttackMode = AttackMode.Normal,
                TricksterWeaponId = 8
            },
            
            new Attack {
                Id = 296,
                Name = "R1 (backstep)",
                Damage = 1,
                ExtraDamage = 0,
                ExtraDamageCount = 0,
                AttackType1 = AttackType.Thrust,
                AttackType2 = AttackType.Arcane,
                AttackMode = AttackMode.Normal,
                TricksterWeaponId = 8
            },
            
            new Attack {
                Id = 297,
                Name = "R1 (rolling)",
                Damage = 1,
                ExtraDamage = 0,
                ExtraDamageCount = 0,
                AttackType1 = AttackType.Physical,
                AttackType2 = AttackType.Arcane,
                AttackMode = AttackMode.Normal,
                TricksterWeaponId = 8
            },
            
            new Attack {
                Id = 298,
                Name = "R1 (frontstep)",
                Damage = 1,
                ExtraDamage = 0,
                ExtraDamageCount = 0,
                AttackType1 = AttackType.Physical,
                AttackType2 = AttackType.Arcane,
                AttackMode = AttackMode.Normal,
                TricksterWeaponId = 8
            },
            
            new Attack {
                Id = 299,
                Name = "R1 (sidestep)",
                Damage = 1,
                ExtraDamage = 0,
                ExtraDamageCount = 0,
                AttackType1 = AttackType.Physical,
                AttackType2 = AttackType.Arcane,
                AttackMode = AttackMode.Normal,
                TricksterWeaponId = 8
            },
            
            new Attack {
                Id = 300,
                Name = "R1 (dash)",
                Damage = 1,
                ExtraDamage = 0,
                ExtraDamageCount = 0,
                AttackType1 = AttackType.Physical,
                AttackType2 = AttackType.Arcane,
                AttackMode = AttackMode.Normal,
                TricksterWeaponId = 8
            },
            
            new Attack {
                Id = 301,
                Name = "R2",
                Damage = 1,
                ExtraDamage = 0,
                ExtraDamageCount = 0,
                AttackType1 = AttackType.Physical,
                AttackType2 = AttackType.Arcane,
                AttackMode = AttackMode.Normal,
                TricksterWeaponId = 8
            },
            
            new Attack {
                Id = 302,
                Name = "R2 (charged)",
                Damage = 1,
                ExtraDamage = 0,
                ExtraDamageCount = 0,
                AttackType1 = AttackType.Physical,
                AttackType2 = AttackType.Arcane,
                AttackMode = AttackMode.Normal,
                TricksterWeaponId = 8
            },
            
            new Attack {
                Id = 303,
                Name = "R2 (backstep)",
                Damage = 1,
                ExtraDamage = 0,
                ExtraDamageCount = 0,
                AttackType1 = AttackType.Physical,
                AttackType2 = AttackType.Arcane,
                AttackMode = AttackMode.Normal,
                TricksterWeaponId = 8
            },
            
            new Attack {
                Id = 304,
                Name = "R2 (dash)",
                Damage = 1,
                ExtraDamage = 0,
                ExtraDamageCount = 0,
                AttackType1 = AttackType.Physical,
                AttackType2 = AttackType.Arcane,
                AttackMode = AttackMode.Normal,
                TricksterWeaponId = 8
            },
            
            new Attack {
                Id = 305,
                Name = "R2 (forward leap)",
                Damage = 1,
                ExtraDamage = 0,
                ExtraDamageCount = 0,
                AttackType1 = AttackType.Physical,
                AttackType2 = AttackType.Arcane,
                AttackMode = AttackMode.Normal,
                TricksterWeaponId = 8
            },
            
            new Attack {
                Id = 306,
                Name = "Transform Attack",
                Damage = 1,
                ExtraDamage = 0,
                ExtraDamageCount = 0,
                AttackType1 = AttackType.Physical,
                AttackType2 = AttackType.Arcane,
                AttackMode = AttackMode.Normal,
                TricksterWeaponId = 8
            },
            
            new Attack {
                Id = 307,
                Name = "Plunge Attack",
                Damage = 1,
                ExtraDamage = 0,
                ExtraDamageCount = 0,
                AttackType1 = AttackType.Physical,
                AttackType2 = AttackType.Arcane,
                AttackMode = AttackMode.Normal,
                TricksterWeaponId = 8
            },
            
            new Attack {
                Id = 308,
                Name = "Plunge Attack (2nd)",
                Damage = 1,
                ExtraDamage = 0,
                ExtraDamageCount = 0,
                AttackType1 = AttackType.Blunt,
                AttackType2 = AttackType.Arcane,
                AttackMode = AttackMode.Normal,
                TricksterWeaponId = 8
            },
            
            new Attack {
                Id = 309,
                Name = "R1",
                Damage = 1,
                ExtraDamage = 0,
                ExtraDamageCount = 0,
                AttackType1 = AttackType.Physical,
                AttackType2 = AttackType.Arcane,
                AttackMode = AttackMode.Transformed,
                TricksterWeaponId = 8
            },
            
            new Attack {
                Id = 310,
                Name = "R1 (2nd)",
                Damage = 1,
                ExtraDamage = 0,
                ExtraDamageCount = 0,
                AttackType1 = AttackType.Physical,
                AttackType2 = AttackType.Arcane,
                AttackMode = AttackMode.Transformed,
                TricksterWeaponId = 8
            },
            
            new Attack {
                Id = 311,
                Name = "R1 (3rd)",
                Damage = 1,
                ExtraDamage = 0,
                ExtraDamageCount = 0,
                AttackType1 = AttackType.Physical,
                AttackType2 = AttackType.Arcane,
                AttackMode = AttackMode.Transformed,
                TricksterWeaponId = 8
            },
            
            new Attack {
                Id = 312,
                Name = "R1 (4th)",
                Damage = 1,
                ExtraDamage = 0,
                ExtraDamageCount = 0,
                AttackType1 = AttackType.Physical,
                AttackType2 = AttackType.Arcane,
                AttackMode = AttackMode.Transformed,
                TricksterWeaponId = 8
            },
            
            new Attack {
                Id = 313,
                Name = "R1 (backstep)",
                Damage = 1,
                ExtraDamage = 0,
                ExtraDamageCount = 0,
                AttackType1 = AttackType.Physical,
                AttackType2 = AttackType.Arcane,
                AttackMode = AttackMode.Transformed,
                TricksterWeaponId = 8
            },
            
            new Attack {
                Id = 314,
                Name = "R1 (rolling)",
                Damage = 1,
                ExtraDamage = 0,
                ExtraDamageCount = 0,
                AttackType1 = AttackType.Physical,
                AttackType2 = AttackType.Arcane,
                AttackMode = AttackMode.Transformed,
                TricksterWeaponId = 8
            },
            
            new Attack {
                Id = 315,
                Name = "R1 (frontstep)",
                Damage = 1,
                ExtraDamage = 0,
                ExtraDamageCount = 0,
                AttackType1 = AttackType.Physical,
                AttackType2 = AttackType.Arcane,
                AttackMode = AttackMode.Transformed,
                TricksterWeaponId = 8
            },
            
            new Attack {
                Id = 316,
                Name = "R1 (sidestep)",
                Damage = 1,
                ExtraDamage = 0,
                ExtraDamageCount = 0,
                AttackType1 = AttackType.Physical,
                AttackType2 = AttackType.Arcane,
                AttackMode = AttackMode.Transformed,
                TricksterWeaponId = 8
            },
            
            new Attack {
                Id = 317,
                Name = "R1 (dash)",
                Damage = 1,
                ExtraDamage = 0,
                ExtraDamageCount = 0,
                AttackType1 = AttackType.Physical,
                AttackType2 = AttackType.Arcane,
                AttackMode = AttackMode.Transformed,
                TricksterWeaponId = 8
            },
            
            new Attack {
                Id = 318,
                Name = "R2",
                Damage = 1,
                ExtraDamage = 0,
                ExtraDamageCount = 0,
                AttackType1 = AttackType.Physical,
                AttackType2 = AttackType.Arcane,
                AttackMode = AttackMode.Transformed,
                TricksterWeaponId = 8
            },
            
            new Attack {
                Id = 319,
                Name = "R2 (charged)",
                Damage = 1,
                ExtraDamage = 0,
                ExtraDamageCount = 0,
                AttackType1 = AttackType.Physical,
                AttackType2 = AttackType.Arcane,
                AttackMode = AttackMode.Transformed,
                TricksterWeaponId = 8
            },
            
            new Attack {
                Id = 320,
                Name = "R2 (backstep)",
                Damage = 1,
                ExtraDamage = 0,
                ExtraDamageCount = 0,
                AttackType1 = AttackType.Physical,
                AttackType2 = AttackType.Arcane,
                AttackMode = AttackMode.Transformed,
                TricksterWeaponId = 8
            },
            
            new Attack {
                Id = 321,
                Name = "R2 (dash)",
                Damage = 1,
                ExtraDamage = 0,
                ExtraDamageCount = 0,
                AttackType1 = AttackType.Physical,
                AttackType2 = AttackType.Arcane,
                AttackMode = AttackMode.Transformed,
                TricksterWeaponId = 8
            },
            
            new Attack {
                Id = 322,
                Name = "R2(forward leap)",
                Damage = 1,
                ExtraDamage = 0,
                ExtraDamageCount = 0,
                AttackType1 = AttackType.Physical,
                AttackType2 = AttackType.Arcane,
                AttackMode = AttackMode.Transformed,
                TricksterWeaponId = 8
            },
            
            new Attack {
                Id = 323,
                Name = "L2",
                Damage = 1,
                ExtraDamage = 0,
                ExtraDamageCount = 0,
                AttackType1 = AttackType.Physical,
                AttackType2 = AttackType.Arcane,
                AttackMode = AttackMode.Transformed,
                TricksterWeaponId = 8
            },
            
            new Attack {
                Id = 324,
                Name = "L2 (2nd)",
                Damage = 1,
                ExtraDamage = 0,
                ExtraDamageCount = 0,
                AttackType1 = AttackType.Physical,
                AttackType2 = AttackType.Arcane,
                AttackMode = AttackMode.Transformed,
                TricksterWeaponId = 8
            },
            
            new Attack {
                Id = 325,
                Name = "L2 (3rd)",
                Damage = 1,
                ExtraDamage = 0,
                ExtraDamageCount = 0,
                AttackType1 = AttackType.Physical,
                AttackType2 = AttackType.Arcane,
                AttackMode = AttackMode.Transformed,
                TricksterWeaponId = 8
            },
            
            new Attack {
                Id = 326,
                Name = "L2 (4th)",
                Damage = 1,
                ExtraDamage = 0,
                ExtraDamageCount = 0,
                AttackType1 = AttackType.Physical,
                AttackType2 = AttackType.Arcane,
                AttackMode = AttackMode.Transformed,
                TricksterWeaponId = 8
            },
            
            new Attack {
                Id = 327,
                Name = "Transform Attack",
                Damage = 1,
                ExtraDamage = 0,
                ExtraDamageCount = 0,
                AttackType1 = AttackType.Physical,
                AttackType2 = AttackType.Arcane,
                AttackMode = AttackMode.Transformed,
                TricksterWeaponId = 8
            },
            
            new Attack {
                Id = 328,
                Name = "Plunge Attack",
                Damage = 1,
                ExtraDamage = 0,
                ExtraDamageCount = 0,
                AttackType1 = AttackType.Physical,
                AttackType2 = AttackType.Arcane,
                AttackMode = AttackMode.Transformed,
                TricksterWeaponId = 8
            },
            
            new Attack {
                Id = 329,
                Name = "Plunge Attack (2nd)",
                Damage = 0,
                ExtraDamage = 0,
                ExtraDamageCount = 0,
                AttackType1 = AttackType.Blunt ,
                AttackType2 = AttackType.Arcane,
                AttackMode = AttackMode.Transformed,
                TricksterWeaponId = 8
            },
            
            new Attack {
                Id = 330,
                Name = "R1",
                Damage = 1,
                ExtraDamage = 0,
                ExtraDamageCount = 0,
                AttackType1 = AttackType.Physical,
                AttackType2 = AttackType.None,
                AttackMode = AttackMode.Normal,
                TricksterWeaponId = 9
            },
            
            new Attack {
                Id = 331,
                Name = "R1 (2nd)",
                Damage = 1,
                ExtraDamage = 0,
                ExtraDamageCount = 0,
                AttackType1 = AttackType.Physical,
                AttackType2 = AttackType.None,
                AttackMode = AttackMode.Normal,
                TricksterWeaponId = 9
            },
            
            new Attack {
                Id = 332,
                Name = "R1 (3rd)",
                Damage = 1,
                ExtraDamage = 0,
                ExtraDamageCount = 0,
                AttackType1 = AttackType.Physical,
                AttackType2 = AttackType.None,
                AttackMode = AttackMode.Normal,
                TricksterWeaponId = 9
            },
            
            new Attack {
                Id = 333,
                Name = "R1 (4th)",
                Damage = 1,
                ExtraDamage = 0,
                ExtraDamageCount = 0,
                AttackType1 = AttackType.Physical,
                AttackType2 = AttackType.None,
                AttackMode = AttackMode.Normal,
                TricksterWeaponId = 9
            },
            
            new Attack {
                Id = 334,
                Name = "R1 (5th)",
                Damage = 1,
                ExtraDamage = 0,
                ExtraDamageCount = 0,
                AttackType1 = AttackType.Physical,
                AttackType2 = AttackType.None,
                AttackMode = AttackMode.Normal,
                TricksterWeaponId = 9
            },
            
            new Attack {
                Id = 335,
                Name = "R1 (backstep)",
                Damage = 1,
                ExtraDamage = 0,
                ExtraDamageCount = 0,
                AttackType1 = AttackType.Physical,
                AttackType2 = AttackType.None,
                AttackMode = AttackMode.Normal,
                TricksterWeaponId = 9
            },
            
            new Attack {
                Id = 336,
                Name = "R1 (rolling)",
                Damage = 1,
                ExtraDamage = 0,
                ExtraDamageCount = 0,
                AttackType1 = AttackType.Physical,
                AttackType2 = AttackType.None,
                AttackMode = AttackMode.Normal,
                TricksterWeaponId = 9
            },
            
            new Attack {
                Id = 337,
                Name = "R1 (frontstep)",
                Damage = 1,
                ExtraDamage = 0,
                ExtraDamageCount = 0,
                AttackType1 = AttackType.Physical,
                AttackType2 = AttackType.None,
                AttackMode = AttackMode.Normal,
                TricksterWeaponId = 9
            },
            
            new Attack {
                Id = 338,
                Name = "R1 (sidestep)",
                Damage = 1,
                ExtraDamage = 0,
                ExtraDamageCount = 0,
                AttackType1 = AttackType.Physical,
                AttackType2 = AttackType.None,
                AttackMode = AttackMode.Normal,
                TricksterWeaponId = 9
            },

            new Attack {
                Id = 339,
                Name = "R1 (dash)",
                Damage = 1,
                ExtraDamage = 0,
                ExtraDamageCount = 0,
                AttackType1 = AttackType.Physical,
                AttackType2 = AttackType.None,
                AttackMode = AttackMode.Normal,
                TricksterWeaponId = 9
            },
            
            new Attack {
                Id = 340,
                Name = "R2",
                Damage = 1,
                ExtraDamage = 0,
                ExtraDamageCount = 0,
                AttackType1 = AttackType.Thrust,
                AttackType2 = AttackType.None,
                AttackMode = AttackMode.Normal,
                TricksterWeaponId = 9
            },
            
            new Attack {
                Id = 341,
                Name = "R2 (charged)",
                Damage = 1,
                ExtraDamage = 0,
                ExtraDamageCount = 0,
                AttackType1 = AttackType.Thrust,
                AttackType2 = AttackType.None,
                AttackMode = AttackMode.Normal,
                TricksterWeaponId = 9
            },
            
            new Attack {
                Id = 342,
                Name = "R2 (backstep)",
                Damage = 1,
                ExtraDamage = 0,
                ExtraDamageCount = 0,
                AttackType1 = AttackType.Physical,
                AttackType2 = AttackType.None,
                AttackMode = AttackMode.Normal,
                TricksterWeaponId = 9
            },
            
            new Attack {
                Id = 343,
                Name = "R2 (dash)",
                Damage = 1,
                ExtraDamage = 0,
                ExtraDamageCount = 0,
                AttackType1 = AttackType.Thrust,
                AttackType2 = AttackType.None,
                AttackMode = AttackMode.Normal,
                TricksterWeaponId = 9
            },
            
            new Attack {
                Id = 344,
                Name = "R2 (forward leap)",
                Damage = 1,
                ExtraDamage = 0,
                ExtraDamageCount = 0,
                AttackType1 = AttackType.Physical,
                AttackType2 = AttackType.None,
                AttackMode = AttackMode.Normal,
                TricksterWeaponId = 9
            },
            
            new Attack {
                Id = 345,
                Name = "Transform Attack",
                Damage = 1,
                ExtraDamage = 0,
                ExtraDamageCount = 0,
                AttackType1 = AttackType.Physical,
                AttackType2 = AttackType.None,
                AttackMode = AttackMode.Normal,
                TricksterWeaponId = 9
            },
            
            new Attack {
                Id = 346,
                Name = "L1 R1",
                Damage = 1,
                ExtraDamage = 0,
                ExtraDamageCount = 0,
                AttackType1 = AttackType.Blood,
                AttackType2 = AttackType.None,
                AttackMode = AttackMode.Normal,
                TricksterWeaponId = 9
            },
            
            new Attack {
                Id = 347,
                Name = "Plunge Attack",
                Damage = 1,
                ExtraDamage = 0,
                ExtraDamageCount = 0,
                AttackType1 = AttackType.Physical,
                AttackType2 = AttackType.None,
                AttackMode = AttackMode.Normal,
                TricksterWeaponId = 9
            },
            
            new Attack {
                Id = 348,
                Name = "Plunge Attack (2nd)",
                Damage = 1,
                ExtraDamage = 0,
                ExtraDamageCount = 0,
                AttackType1 = AttackType.Blunt,
                AttackType2 = AttackType.None,
                AttackMode = AttackMode.Normal,
                TricksterWeaponId = 9
            },
            
            new Attack {
                Id = 349,
                Name = "R1",
                Damage = 0,
                ExtraDamage = 0,
                ExtraDamageCount = 0,
                AttackType1 = AttackType.Blood,
                AttackType2 = AttackType.None,
                AttackMode = AttackMode.Transformed,
                TricksterWeaponId = 9
            },
            
            new Attack {
                Id = 350,
                Name = "R1 (2nd)",
                Damage = 0,
                ExtraDamage = 0,
                ExtraDamageCount = 0,
                AttackType1 = AttackType.Blood,
                AttackType2 = AttackType.None,
                AttackMode = AttackMode.Transformed,
                TricksterWeaponId = 9
            },
            
            new Attack {
                Id = 351,
                Name = "R1 (3rd)",
                Damage = 1,
                ExtraDamage = 0,
                ExtraDamageCount = 0,
                AttackType1 = AttackType.Blood,
                AttackType2 = AttackType.None,
                AttackMode = AttackMode.Transformed,
                TricksterWeaponId = 9
            },
            
            new Attack {
                Id = 352,
                Name = "R1 (4th)",
                Damage = 1,
                ExtraDamage = 0,
                ExtraDamageCount = 0,
                AttackType1 = AttackType.Blood,
                AttackType2 = AttackType.None,
                AttackMode = AttackMode.Transformed,
                TricksterWeaponId = 9
            },
            
            new Attack {
                Id = 353,
                Name = "R1 (5th)",
                Damage = 1,
                ExtraDamage = 0,
                ExtraDamageCount = 0,
                AttackType1 = AttackType.Blood,
                AttackType2 = AttackType.None,
                AttackMode = AttackMode.Transformed,
                TricksterWeaponId = 9
            },
            
            new Attack {
                Id = 354,
                Name = "R1 (backstep)",
                Damage = 1,
                ExtraDamage = 0,
                ExtraDamageCount = 0,
                AttackType1 = AttackType.Blood,
                AttackType2 = AttackType.None,
                AttackMode = AttackMode.Transformed,
                TricksterWeaponId = 9
            },
            
            new Attack {
                Id = 355,
                Name = "R1 (rolling)",
                Damage = 1,
                ExtraDamage = 0,
                ExtraDamageCount = 0,
                AttackType1 = AttackType.Blood,
                AttackType2 = AttackType.None,
                AttackMode = AttackMode.Transformed,
                TricksterWeaponId = 9
            },
            
            new Attack {
                Id = 356,
                Name = "R1 (frontstep)",
                Damage = 1,
                ExtraDamage = 0,
                ExtraDamageCount = 0,
                AttackType1 = AttackType.Blood,
                AttackType2 = AttackType.None,
                AttackMode = AttackMode.Transformed,
                TricksterWeaponId = 9
            },
            
            new Attack {
                Id = 357,
                Name = "R1 (sidestep)",
                Damage = 1,
                ExtraDamage = 0,
                ExtraDamageCount = 0,
                AttackType1 = AttackType.Blood,
                AttackType2 = AttackType.None,
                AttackMode = AttackMode.Transformed,
                TricksterWeaponId = 9
            },
            
            new Attack {
                Id = 358,
                Name = "R1 (dash)",
                Damage = 1,
                ExtraDamage = 0,
                ExtraDamageCount = 0,
                AttackType1 = AttackType.Blood,
                AttackType2 = AttackType.None,
                AttackMode = AttackMode.Transformed,
                TricksterWeaponId = 9
            },
            
            new Attack {
                Id = 359,
                Name = "R2",
                Damage = 1,
                ExtraDamage = 0,
                ExtraDamageCount = 0,
                AttackType1 = AttackType.Blood,
                AttackType2 = AttackType.None,
                AttackMode = AttackMode.Transformed,
                TricksterWeaponId = 9
            },
            
            new Attack {
                Id = 360,
                Name = "R2 (charged)",
                Damage = 2,
                ExtraDamage = 0,
                ExtraDamageCount = 0,
                AttackType1 = AttackType.Blood,
                AttackType2 = AttackType.None,
                AttackMode = AttackMode.Transformed,
                TricksterWeaponId = 9
            },
            
            new Attack {
                Id = 361,
                Name = "R2 (charged follow-up)",
                Damage = 1,
                ExtraDamage = 0,
                ExtraDamageCount = 0,
                AttackType1 = AttackType.Blood,
                AttackType2 = AttackType.None,
                AttackMode = AttackMode.Transformed,
                TricksterWeaponId = 9
            },
            
            new Attack {
                Id = 362,
                Name = "R2 (backstep)",
                Damage = 1,
                ExtraDamage = 0,
                ExtraDamageCount = 0,
                AttackType1 = AttackType.Blood,
                AttackType2 = AttackType.None,
                AttackMode = AttackMode.Transformed,
                TricksterWeaponId = 9
            },
            
            new Attack {
                Id = 363,
                Name = "R2 (dash)",
                Damage = 1,
                ExtraDamage = 0,
                ExtraDamageCount = 0,
                AttackType1 = AttackType.Thrust,
                AttackType2 = AttackType.None,
                AttackMode = AttackMode.Transformed,
                TricksterWeaponId = 9
            },
            
            new Attack {
                Id = 364,
                Name = "R2(forward leap)",
                Damage = 1,
                ExtraDamage = 0,
                ExtraDamageCount = 0,
                AttackType1 = AttackType.Blood,
                AttackType2 = AttackType.None,
                AttackMode = AttackMode.Transformed,
                TricksterWeaponId = 9
            },
            
            new Attack {
                Id = 365,
                Name = "L2",
                Damage = 1,
                ExtraDamage = 0,
                ExtraDamageCount = 0,
                AttackType1 = AttackType.Thrust,
                AttackType2 = AttackType.None,
                AttackMode = AttackMode.Transformed,
                TricksterWeaponId = 9
            },
            
            new Attack {
                Id = 366,
                Name = "L2 (2nd)",
                Damage = 1,
                ExtraDamage = 0,
                ExtraDamageCount = 0,
                AttackType1 = AttackType.Blood,
                AttackType2 = AttackType.None,
                AttackMode = AttackMode.Transformed,
                TricksterWeaponId = 9
            },
            
            new Attack {
                Id = 367,
                Name = "Transform Attack",
                Damage = 0,
                ExtraDamage = 0,
                ExtraDamageCount = 0,
                AttackType1 = AttackType.Blood,
                AttackType2 = AttackType.None,
                AttackMode = AttackMode.Transformed,
                TricksterWeaponId = 9
            },
            
            new Attack {
                Id = 368,
                Name = "Plunge Attack",
                Damage = 1,
                ExtraDamage = 0,
                ExtraDamageCount = 0,
                AttackType1 = AttackType.Blood,
                AttackType2 = AttackType.None,
                AttackMode = AttackMode.Transformed,
                TricksterWeaponId = 9
            },
            
            new Attack {
                Id = 369,
                Name = "Plunge Attack (2nd)",
                Damage = 1,
                ExtraDamage = 0,
                ExtraDamageCount = 0,
                AttackType1 = AttackType.Blunt,
                AttackType2 = AttackType.None,
                AttackMode = AttackMode.Transformed,
                TricksterWeaponId = 9
            },
            
            new Attack {
                Id = 370,
                Name = "R1",
                Damage = 0,
                ExtraDamage = 0,
                ExtraDamageCount = 0,
                AttackType1 = AttackType.Thrust,
                AttackType2 = AttackType.None,
                AttackMode = AttackMode.Normal,
                TricksterWeaponId = 10
            },
            
            new Attack {
                Id = 371,
                Name = "R1 (2nd)",
                Damage = 0,
                ExtraDamage = 0,
                ExtraDamageCount = 0,
                AttackType1 = AttackType.Physical,
                AttackType2 = AttackType.None,
                AttackMode = AttackMode.Normal,
                TricksterWeaponId = 10
            },
            
            new Attack {
                Id = 372,
                Name = "R1 (3rd)",
                Damage = 1,
                ExtraDamage = 0,
                ExtraDamageCount = 0,
                AttackType1 = AttackType.Physical,
                AttackType2 = AttackType.None,
                AttackMode = AttackMode.Normal,
                TricksterWeaponId = 10
            },
            
            new Attack {
                Id = 373,
                Name = "R1 (4th)",
                Damage = 1,
                ExtraDamage = 0,
                ExtraDamageCount = 0,
                AttackType1 = AttackType.Thrust,
                AttackType2 = AttackType.None,
                AttackMode = AttackMode.Normal,
                TricksterWeaponId = 10
            },
            
            new Attack {
                Id = 374,
                Name = "R1 (backstep)",
                Damage = 0,
                ExtraDamage = 0,
                ExtraDamageCount = 0,
                AttackType1 = AttackType.Physical,
                AttackType2 = AttackType.None,
                AttackMode = AttackMode.Normal,
                TricksterWeaponId = 10
            },
            
            new Attack {
                Id = 375,
                Name = "R1 (rolling)",
                Damage = 0,
                ExtraDamage = 0,
                ExtraDamageCount = 0,
                AttackType1 = AttackType.Thrust,
                AttackType2 = AttackType.None,
                AttackMode = AttackMode.Normal,
                TricksterWeaponId = 10
            },
            
            new Attack {
                Id = 376,
                Name = "R1 (frontstep)",
                Damage = 0,
                ExtraDamage = 0,
                ExtraDamageCount = 0,
                AttackType1 = AttackType.Thrust,
                AttackType2 = AttackType.None,
                AttackMode = AttackMode.Normal,
                TricksterWeaponId = 10
            },
            
            new Attack {
                Id = 377,
                Name = "R1 (sidestep)",
                Damage = 0,
                ExtraDamage = 0,
                ExtraDamageCount = 0,
                AttackType1 = AttackType.Thrust,
                AttackType2 = AttackType.None,
                AttackMode = AttackMode.Normal,
                TricksterWeaponId = 10
            },
            
            new Attack {
                Id = 378,
                Name = "R1 (dash)",
                Damage = 1,
                ExtraDamage = 0,
                ExtraDamageCount = 0,
                AttackType1 = AttackType.Physical,
                AttackType2 = AttackType.None,
                AttackMode = AttackMode.Normal,
                TricksterWeaponId = 10
            },
            
            new Attack {
                Id = 379,
                Name = "R2",
                Damage = 1,
                ExtraDamage = 0,
                ExtraDamageCount = 0,
                AttackType1 = AttackType.Thrust,
                AttackType2 = AttackType.None,
                AttackMode = AttackMode.Normal,
                TricksterWeaponId = 10
            },
            
            new Attack {
                Id = 380,
                Name = "R2 (charged)",
                Damage = 1,
                ExtraDamage = 0,
                ExtraDamageCount = 0,
                AttackType1 = AttackType.Physical,
                AttackType2 = AttackType.None,
                AttackMode = AttackMode.Normal,
                TricksterWeaponId = 10
            },
            
            new Attack {
                Id = 381,
                Name = "R2 (backstep)",
                Damage = 1,
                ExtraDamage = 0,
                ExtraDamageCount = 0,
                AttackType1 = AttackType.Physical,
                AttackType2 = AttackType.None,
                AttackMode = AttackMode.Normal,
                TricksterWeaponId = 10
            },
            
            new Attack {
                Id = 382,
                Name = "R2 (dash)",
                Damage = 1,
                ExtraDamage = 0,
                ExtraDamageCount = 0,
                AttackType1 = AttackType.Physical,
                AttackType2 = AttackType.None,
                AttackMode = AttackMode.Normal,
                TricksterWeaponId = 10
            },
            
            new Attack {
                Id = 383,
                Name = "R2 (forward leap)",
                Damage = 1,
                ExtraDamage = 0,
                ExtraDamageCount = 0,
                AttackType1 = AttackType.Physical,
                AttackType2 = AttackType.None,
                AttackMode = AttackMode.Normal,
                TricksterWeaponId = 10
            },

            new Attack {
                Id = 384,
                Name = "Transform Attack",
                Damage = 1,
                ExtraDamage = 0,
                ExtraDamageCount = 0,
                AttackType1 = AttackType.Thrust,
                AttackType2 = AttackType.None,
                AttackMode = AttackMode.Normal,
                TricksterWeaponId = 10
            },
            
            new Attack {
                Id = 385,
                Name = "Plunge Attack",
                Damage = 1,
                ExtraDamage = 0,
                ExtraDamageCount = 0,
                AttackType1 = AttackType.Physical,
                AttackType2 = AttackType.None,
                AttackMode = AttackMode.Normal,
                TricksterWeaponId = 10
            },
            
            new Attack {
                Id = 386,
                Name = "Plunge Attack (2nd)",
                Damage = 0,
                ExtraDamage = 0,
                ExtraDamageCount = 0,
                AttackType1 = AttackType.Blunt,
                AttackType2 = AttackType.None,
                AttackMode = AttackMode.Normal,
                TricksterWeaponId = 10
            },
            
            new Attack {
                Id = 387,
                Name = "R1",
                Damage = 1,
                ExtraDamage = 0,
                ExtraDamageCount = 0,
                AttackType1 = AttackType.Thrust,
                AttackType2 = AttackType.None,
                AttackMode = AttackMode.Transformed,
                TricksterWeaponId = 10
            },
            
            new Attack {
                Id = 388,
                Name = "R1 (2nd)",
                Damage = 1,
                ExtraDamage = 0,
                ExtraDamageCount = 0,
                AttackType1 = AttackType.Thrust,
                AttackType2 = AttackType.None,
                AttackMode = AttackMode.Transformed,
                TricksterWeaponId = 10
            },
            
            new Attack {
                Id = 389,
                Name = "R1 (3rd)",
                Damage = 1,
                ExtraDamage = 0,
                ExtraDamageCount = 0,
                AttackType1 = AttackType.Thrust,
                AttackType2 = AttackType.None,
                AttackMode = AttackMode.Transformed,
                TricksterWeaponId = 10
            },
            
            new Attack {
                Id = 390,
                Name = "R1 (4th)",
                Damage = 1,
                ExtraDamage = 0,
                ExtraDamageCount = 0,
                AttackType1 = AttackType.Thrust,
                AttackType2 = AttackType.None,
                AttackMode = AttackMode.Transformed,
                TricksterWeaponId = 10
            },
            
            new Attack {
                Id = 391,
                Name = "R1 (backstep)",
                Damage = 0,
                ExtraDamage = 0,
                ExtraDamageCount = 0,
                AttackType1 = AttackType.Thrust,
                AttackType2 = AttackType.None,
                AttackMode = AttackMode.Transformed,
                TricksterWeaponId = 10
            },
            
            new Attack {
                Id = 392,
                Name = "R1 (rolling)",
                Damage = 1,
                ExtraDamage = 0,
                ExtraDamageCount = 0,
                AttackType1 = AttackType.Thrust,
                AttackType2 = AttackType.None,
                AttackMode = AttackMode.Transformed,
                TricksterWeaponId = 10
            },
            
            new Attack {
                Id = 393,
                Name = "R1 (frontstep)",
                Damage = 1,
                ExtraDamage = 0,
                ExtraDamageCount = 0,
                AttackType1 = AttackType.Thrust,
                AttackType2 = AttackType.None,
                AttackMode = AttackMode.Transformed,
                TricksterWeaponId = 10
            },
            
            new Attack {
                Id = 394,
                Name = "R1 (sidestep)",
                Damage = 1,
                ExtraDamage = 0,
                ExtraDamageCount = 0,
                AttackType1 = AttackType.Thrust,
                AttackType2 = AttackType.None,
                AttackMode = AttackMode.Transformed,
                TricksterWeaponId = 10
            },
            
            new Attack {
                Id = 395,
                Name = "R1 (dash)",
                Damage = 1,
                ExtraDamage = 0,
                ExtraDamageCount = 0,
                AttackType1 = AttackType.Thrust,
                AttackType2 = AttackType.None,
                AttackMode = AttackMode.Transformed,
                TricksterWeaponId = 10
            },
            
            new Attack {
                Id = 396,
                Name = "R2",
                Damage = 1,
                ExtraDamage = 0,
                ExtraDamageCount = 0,
                AttackType1 = AttackType.Thrust,
                AttackType2 = AttackType.None,
                AttackMode = AttackMode.Transformed,
                TricksterWeaponId = 10
            },
            
            new Attack {
                Id = 397,
                Name = "R2 (charged)",
                Damage = 1,
                ExtraDamage = 0,
                ExtraDamageCount = 0,
                AttackType1 = AttackType.Thrust,
                AttackType2 = AttackType.None,
                AttackMode = AttackMode.Transformed,
                TricksterWeaponId = 10
            },
            
            new Attack {
                Id = 398,
                Name = "R2 (charged follow-up)",
                Damage = 2,
                ExtraDamage = 0,
                ExtraDamageCount = 0,
                AttackType1 = AttackType.Thrust,
                AttackType2 = AttackType.None,
                AttackMode = AttackMode.Transformed,
                TricksterWeaponId = 10
            },
            
            new Attack {
                Id = 399,
                Name = "R2 (backstep)",
                Damage = 1,
                ExtraDamage = 0,
                ExtraDamageCount = 0,
                AttackType1 = AttackType.Thrust,
                AttackType2 = AttackType.None,
                AttackMode = AttackMode.Transformed,
                TricksterWeaponId = 10
            },
            
            new Attack {
                Id = 400,
                Name = "R2 (dash)",
                Damage = 1,
                ExtraDamage = 0,
                ExtraDamageCount = 0,
                AttackType1 = AttackType.Thrust,
                AttackType2 = AttackType.None,
                AttackMode = AttackMode.Transformed,
                TricksterWeaponId = 10
            },
            
            new Attack {
                Id = 401,
                Name = "R2 (forward leap)",
                Damage = 1,
                ExtraDamage = 0,
                ExtraDamageCount = 0,
                AttackType1 = AttackType.Thrust,
                AttackType2 = AttackType.None,
                AttackMode = AttackMode.Transformed,
                TricksterWeaponId = 10
            },
            
            new Attack {
                Id = 402,
                Name = "L2",
                Damage = 0,
                ExtraDamage = 0,
                ExtraDamageCount = 0,
                AttackType1 = AttackType.Thrust,
                AttackType2 = AttackType.None,
                AttackMode = AttackMode.Transformed,
                TricksterWeaponId = 10
            },
            
            new Attack {
                Id = 403,
                Name = "Transform Attack",
                Damage = 1,
                ExtraDamage = 0,
                ExtraDamageCount = 0,
                AttackType1 = AttackType.Thrust,
                AttackType2 = AttackType.None,
                AttackMode = AttackMode.Transformed,
                TricksterWeaponId = 10
            },
            
            new Attack {
                Id = 404,
                Name = "Plunge Attack",
                Damage = 1,
                ExtraDamage = 0,
                ExtraDamageCount = 0,
                AttackType1 = AttackType.Thrust,
                AttackType2 = AttackType.None,
                AttackMode = AttackMode.Transformed,
                TricksterWeaponId = 10
            },
            
            new Attack {
                Id = 405,
                Name = "Plunge Attack (2nd)",
                Damage = 0,
                ExtraDamage = 0,
                ExtraDamageCount = 0,
                AttackType1 = AttackType.Blunt,
                AttackType2 = AttackType.None,
                AttackMode = AttackMode.Transformed,
                TricksterWeaponId = 10
            },
            
            new Attack {
                Id = 406,
                Name = "R1",
                Damage = 1,
                ExtraDamage = 0,
                ExtraDamageCount = 1,
                AttackType1 = AttackType.Blunt,
                AttackType2 = AttackType.Arcane,
                AttackMode = AttackMode.Normal,
                TricksterWeaponId = 11
            },
            
            new Attack {
                Id = 407,
                Name = "R1 (2nd)",
                Damage = 1,
                ExtraDamage = 0,
                ExtraDamageCount = 1,
                AttackType1 = AttackType.Blunt,
                AttackType2 = AttackType.Arcane,
                AttackMode = AttackMode.Normal,
                TricksterWeaponId = 11
            },
            
            new Attack {
                Id = 408,
                Name = "R1 (3rd)",
                Damage = 1,
                ExtraDamage = 0,
                ExtraDamageCount = 1,
                AttackType1 = AttackType.Blunt,
                AttackType2 = AttackType.Arcane,
                AttackMode = AttackMode.Normal,
                TricksterWeaponId = 11
            },
            
            new Attack {
                Id = 409,
                Name = "R1 (4th)",
                Damage = 1,
                ExtraDamage = 0,
                ExtraDamageCount = 1,
                AttackType1 = AttackType.Blunt,
                AttackType2 = AttackType.Arcane,
                AttackMode = AttackMode.Normal,
                TricksterWeaponId = 11
            },
            
            new Attack {
                Id = 410,
                Name = "R1 (backstep)",
                Damage = 0,
                ExtraDamage = 0,
                ExtraDamageCount = 1,
                AttackType1 = AttackType.Blunt,
                AttackType2 = AttackType.Arcane,
                AttackMode = AttackMode.Normal,
                TricksterWeaponId = 11
            },
            
            new Attack {
                Id = 411,
                Name = "R1 (rolling)",
                Damage = 0,
                ExtraDamage = 0,
                ExtraDamageCount = 1,
                AttackType1 = AttackType.Blunt,
                AttackType2 = AttackType.Arcane,
                AttackMode = AttackMode.Normal,
                TricksterWeaponId = 11
            },
            
            new Attack {
                Id = 412,
                Name = "R1 (frontstep)",
                Damage = 0,
                ExtraDamage = 0,
                ExtraDamageCount = 1,
                AttackType1 = AttackType.Blunt,
                AttackType2 = AttackType.Arcane,
                AttackMode = AttackMode.Normal,
                TricksterWeaponId = 11
            },
            
            new Attack {
                Id = 413,
                Name = "R1 (sidestep)",
                Damage = 0,
                ExtraDamage = 0,
                ExtraDamageCount = 1,
                AttackType1 = AttackType.Blunt,
                AttackType2 = AttackType.Arcane,
                AttackMode = AttackMode.Normal,
                TricksterWeaponId = 11
            },
            
            new Attack {
                Id = 414,
                Name = "R1 (dash)",
                Damage = 1,
                ExtraDamage = 0,
                ExtraDamageCount = 1,
                AttackType1 = AttackType.Blunt,
                AttackType2 = AttackType.Arcane,
                AttackMode = AttackMode.Normal,
                TricksterWeaponId = 11
            },
            
            new Attack {
                Id = 415,
                Name = "R2",
                Damage = 1,
                ExtraDamage = 0,
                ExtraDamageCount = 1,
                AttackType1 = AttackType.Thrust,
                AttackType2 = AttackType.Arcane,
                AttackMode = AttackMode.Normal,
                TricksterWeaponId = 11
            },
            
            new Attack {
                Id = 416,
                Name = "R2 (charged)",
                Damage = 1,
                ExtraDamage = 0,
                ExtraDamageCount = 1,
                AttackType1 = AttackType.Thrust,
                AttackType2 = AttackType.Arcane,
                AttackMode = AttackMode.Normal,
                TricksterWeaponId = 11
            },
            
            new Attack {
                Id = 417,
                Name = "R2 (charged follow-up)",
                Damage = 2,
                ExtraDamage = 1,
                ExtraDamageCount = 1,
                AttackType1 = AttackType.Blunt,
                AttackType2 = AttackType.Arcane,
                AttackMode = AttackMode.Normal,
                TricksterWeaponId = 11
            },
            
            new Attack {
                Id = 418,
                Name = "R2 (backstep)",
                Damage = 1,
                ExtraDamage = 0,
                ExtraDamageCount = 1,
                AttackType1 = AttackType.Blunt,
                AttackType2 = AttackType.Arcane,
                AttackMode = AttackMode.Normal,
                TricksterWeaponId = 11
            },
            
            new Attack {
                Id = 419,
                Name = "R2 (dash)",
                Damage = 1,
                ExtraDamage = 0,
                ExtraDamageCount = 1,
                AttackType1 = AttackType.Thrust,
                AttackType2 = AttackType.Arcane,
                AttackMode = AttackMode.Normal,
                TricksterWeaponId = 11
            },
            
            new Attack {
                Id = 420,
                Name = "R2 (forward leap)",
                Damage = 1,
                ExtraDamage = 0,
                ExtraDamageCount = 1,
                AttackType1 = AttackType.Blunt,
                AttackType2 = AttackType.Arcane,
                AttackMode = AttackMode.Normal,
                TricksterWeaponId = 11
            },
            
            new Attack {
                Id = 421,
                Name = "Transform Attack",
                Damage = 1,
                ExtraDamage = 1,
                ExtraDamageCount = 1,
                AttackType1 = AttackType.Blunt,
                AttackType2 = AttackType.Arcane,
                AttackMode = AttackMode.Normal,
                TricksterWeaponId = 11
            },
            
            new Attack {
                Id = 422,
                Name = "Plunge Attack",
                Damage = 1,
                ExtraDamage = 0,
                ExtraDamageCount = 1,
                AttackType1 = AttackType.Blunt,
                AttackType2 = AttackType.Arcane,
                AttackMode = AttackMode.Normal,
                TricksterWeaponId = 11
            },
            
            new Attack {
                Id = 423,
                Name = "Plunge Attack (2nd)",
                Damage = 0,
                ExtraDamage = 0,
                ExtraDamageCount = 1,
                AttackType1 = AttackType.Blunt,
                AttackType2 = AttackType.None,
                AttackMode = AttackMode.Normal,
                TricksterWeaponId = 11
            },
            
            new Attack {
                Id = 424,
                Name = "R1",
                Damage = 1,
                ExtraDamage = 0,
                ExtraDamageCount = 1,
                AttackType1 = AttackType.Blunt,
                AttackType2 = AttackType.Arcane,
                AttackMode = AttackMode.Transformed,
                TricksterWeaponId = 11
            },
            
            new Attack {
                Id = 425,
                Name = "R1 (2nd)",
                Damage = 1,
                ExtraDamage = 0,
                ExtraDamageCount = 1,
                AttackType1 = AttackType.Blunt,
                AttackType2 = AttackType.Arcane,
                AttackMode = AttackMode.Transformed,
                TricksterWeaponId = 11
            },
            
            new Attack {
                Id = 426,
                Name = "R1 (3rd)",
                Damage = 1,
                ExtraDamage = 0,
                ExtraDamageCount = 1,
                AttackType1 = AttackType.Blunt,
                AttackType2 = AttackType.Arcane,
                AttackMode = AttackMode.Transformed,
                TricksterWeaponId = 11
            },
            
            new Attack {
                Id = 427,
                Name = "R1 (4th)",
                Damage = 1,
                ExtraDamage = 0,
                ExtraDamageCount = 1,
                AttackType1 = AttackType.Blunt,
                AttackType2 = AttackType.Arcane,
                AttackMode = AttackMode.Transformed,
                TricksterWeaponId = 11
            },
            
            new Attack {
                Id = 428,
                Name = "R1 (backstep)",
                Damage = 0,
                ExtraDamage = 0,
                ExtraDamageCount = 1,
                AttackType1 = AttackType.Blunt,
                AttackType2 = AttackType.Arcane,
                AttackMode = AttackMode.Transformed,
                TricksterWeaponId = 11
            },
            
            new Attack {
                Id = 429,
                Name = "R1 (rolling)",
                Damage = 0,
                ExtraDamage = 0,
                ExtraDamageCount = 1,
                AttackType1 = AttackType.Blunt,
                AttackType2 = AttackType.Arcane,
                AttackMode = AttackMode.Transformed,
                TricksterWeaponId = 11
            },
            
            new Attack {
                Id = 430,
                Name = "R1 (frontstep)",
                Damage = 0,
                ExtraDamage = 0,
                ExtraDamageCount = 1,
                AttackType1 = AttackType.Blunt,
                AttackType2 = AttackType.Arcane,
                AttackMode = AttackMode.Transformed,
                TricksterWeaponId = 11
            },
            
            new Attack {
                Id = 431,
                Name = "R1 (sidestep)",
                Damage = 0,
                ExtraDamage = 0,
                ExtraDamageCount = 1,
                AttackType1 = AttackType.Blunt,
                AttackType2 = AttackType.Arcane,
                AttackMode = AttackMode.Transformed,
                TricksterWeaponId = 11
            },
            
            new Attack {
                Id = 432,
                Name = "R1 (dash)",
                Damage = 1,
                ExtraDamage = 0,
                ExtraDamageCount = 1,
                AttackType1 = AttackType.Blunt,
                AttackType2 = AttackType.Arcane,
                AttackMode = AttackMode.Transformed,
                TricksterWeaponId = 11
            },
            
            new Attack {
                Id = 433,
                Name = "R2",
                Damage = 1,
                ExtraDamage = 2,
                ExtraDamageCount = 1,
                AttackType1 = AttackType.Blunt,
                AttackType2 = AttackType.Arcane,
                AttackMode = AttackMode.Transformed,
                TricksterWeaponId = 11
            },
            
            new Attack {
                Id = 434,
                Name = "R2 (charged)",
                Damage = 1,
                ExtraDamage = 2,
                ExtraDamageCount = 1,
                AttackType1 = AttackType.Blunt,
                AttackType2 = AttackType.Arcane,
                AttackMode = AttackMode.Transformed,
                TricksterWeaponId = 11
            },
            
            new Attack {
                Id = 435,
                Name = "R2 (charged follow-up)",
                Damage = 1,
                ExtraDamage = 2,
                ExtraDamageCount = 1,
                AttackType1 = AttackType.Blunt,
                AttackType2 = AttackType.Arcane,
                AttackMode = AttackMode.Transformed,
                TricksterWeaponId = 11
            },
            
            new Attack {
                Id = 436,
                Name = "R2 (backstep)",
                Damage = 1,
                ExtraDamage = 1,
                ExtraDamageCount = 1,
                AttackType1 = AttackType.Blunt,
                AttackType2 = AttackType.Arcane,
                AttackMode = AttackMode.Transformed,
                TricksterWeaponId = 11
            },
            
            new Attack {
                Id = 437,
                Name = "R2 (dash)",
                Damage = 1,
                ExtraDamage = 2,
                ExtraDamageCount = 1,
                AttackType1 = AttackType.Blunt,
                AttackType2 = AttackType.Arcane,
                AttackMode = AttackMode.Transformed,
                TricksterWeaponId = 11
            },
            
            new Attack {
                Id = 438,
                Name = "R2 (forward leap)",
                Damage = 1,
                ExtraDamage = 2,
                ExtraDamageCount = 1,
                AttackType1 = AttackType.Blunt,
                AttackType2 = AttackType.Arcane,
                AttackMode = AttackMode.Transformed,
                TricksterWeaponId = 11
            },
            
            new Attack {
                Id = 439,
                Name = "L2",
                Damage = 1,
                ExtraDamage = 1,
                ExtraDamageCount = 1,
                AttackType1 = AttackType.Thrust,
                AttackType2 = AttackType.Arcane,
                AttackMode = AttackMode.Transformed,
                TricksterWeaponId = 11
            },
            
            new Attack {
                Id = 440,
                Name = "Transform Attack",
                Damage = 1,
                ExtraDamage = 1,
                ExtraDamageCount = 1,
                AttackType1 = AttackType.Blunt,
                AttackType2 = AttackType.Arcane,
                AttackMode = AttackMode.Transformed,
                TricksterWeaponId = 11
            },
            
            new Attack {
                Id = 441,
                Name = "Plunge Attack",
                Damage = 1,
                ExtraDamage = 0,
                ExtraDamageCount = 1,
                AttackType1 = AttackType.Blunt,
                AttackType2 = AttackType.Arcane,
                AttackMode = AttackMode.Transformed,
                TricksterWeaponId = 11
            },
            
            new Attack {
                Id = 442,
                Name = "Plunge Attack (2nd)",
                Damage = 0,
                ExtraDamage = 0,
                ExtraDamageCount = 0,
                AttackType1 = AttackType.Blunt,
                AttackType2 = AttackType.None,
                AttackMode = AttackMode.Transformed,
                TricksterWeaponId = 11
            },
            
            new Attack {
                Id = 443,
                Name = "R2 no bullet",
                Damage = 1,
                ExtraDamage = 0,
                ExtraDamageCount = 1,
                AttackType1 = AttackType.Blunt,
                AttackType2 = AttackType.Arcane,
                AttackMode = AttackMode.Transformed,
                TricksterWeaponId = 11
            },
            
            new Attack {
                Id = 444,
                Name = "R2 (charged) no bullet",
                Damage = 1,
                ExtraDamage = 0,
                ExtraDamageCount = 1,
                AttackType1 = AttackType.Blunt,
                AttackType2 = AttackType.Arcane,
                AttackMode = AttackMode.Transformed,
                TricksterWeaponId = 11
            },
            
            new Attack {
                Id = 445,
                Name = "R2 (charged follow-up) no bullet",
                Damage = 1,
                ExtraDamage = 0,
                ExtraDamageCount = 1,
                AttackType1 = AttackType.Blunt,
                AttackType2 = AttackType.Arcane,
                AttackMode = AttackMode.Transformed,
                TricksterWeaponId = 11
            },
            
            new Attack {
                Id = 446,
                Name = "R2 (backstep) no bullet",
                Damage = 1,
                ExtraDamage = 0,
                ExtraDamageCount = 1,
                AttackType1 = AttackType.Blunt,
                AttackType2 = AttackType.Arcane,
                AttackMode = AttackMode.Transformed,
                TricksterWeaponId = 11
            },
            
            new Attack {
                Id = 447,
                Name = "R2 (dash) no bullet",
                Damage = 1,
                ExtraDamage = 0,
                ExtraDamageCount = 1,
                AttackType1 = AttackType.Blunt,
                AttackType2 = AttackType.Arcane,
                AttackMode = AttackMode.Transformed,
                TricksterWeaponId = 11
            },
            
            new Attack {
                Id = 448,
                Name = "R2 (forward leap) no bullet",
                Damage = 1,
                ExtraDamage = 0,
                ExtraDamageCount = 1,
                AttackType1 = AttackType.Blunt,
                AttackType2 = AttackType.Arcane,
                AttackMode = AttackMode.Transformed,
                TricksterWeaponId = 11
            },
            
            new Attack {
                Id = 449,
                Name = "L2 no bullet",
                Damage = 1,
                ExtraDamage = 1,
                ExtraDamageCount = 1,
                AttackType1 = AttackType.Thrust,
                AttackType2 = AttackType.Arcane,
                AttackMode = AttackMode.Transformed,
                TricksterWeaponId = 11
            },
            
            new Attack {
                Id = 450,
                Name = "R1",
                Damage = 1,
                ExtraDamage = 0,
                ExtraDamageCount = 0,
                AttackType1 = AttackType.Physical,
                AttackType2 = AttackType.None,
                AttackMode = AttackMode.Normal,
                TricksterWeaponId = 12
            },
            
            new Attack {
                Id = 451,
                Name = "R1 (2nd)",
                Damage = 1,
                ExtraDamage = 0,
                ExtraDamageCount = 0,
                AttackType1 = AttackType.Physical,
                AttackType2 = AttackType.None,
                AttackMode = AttackMode.Normal,
                TricksterWeaponId = 12
            },
            
            new Attack {
                Id = 452,
                Name = "R1 (3rd)",
                Damage = 1,
                ExtraDamage = 0,
                ExtraDamageCount = 0,
                AttackType1 = AttackType.Physical,
                AttackType2 = AttackType.None,
                AttackMode = AttackMode.Normal,
                TricksterWeaponId = 12
            },
            
            new Attack {
                Id = 453,
                Name = "R1 (4th)",
                Damage = 1,
                ExtraDamage = 0,
                ExtraDamageCount = 0,
                AttackType1 = AttackType.Blunt,
                AttackType2 = AttackType.None,
                AttackMode = AttackMode.Normal,
                TricksterWeaponId = 12
            },
            
            new Attack {
                Id = 454,
                Name = "R1 (backstep)",
                Damage = 0,
                ExtraDamage = 0,
                ExtraDamageCount = 0,
                AttackType1 = AttackType.Physical,
                AttackType2 = AttackType.None,
                AttackMode = AttackMode.Normal,
                TricksterWeaponId = 12
            },
            
            new Attack {
                Id = 455,
                Name = "R1 (rolling)",
                Damage = 0,
                ExtraDamage = 0,
                ExtraDamageCount = 0,
                AttackType1 = AttackType.Physical,
                AttackType2 = AttackType.None,
                AttackMode = AttackMode.Normal,
                TricksterWeaponId = 12
            },
            
            new Attack {
                Id = 456,
                Name = "R1 (frontstep)",
                Damage = 0,
                ExtraDamage = 0,
                ExtraDamageCount = 0,
                AttackType1 = AttackType.Physical,
                AttackType2 = AttackType.None,
                AttackMode = AttackMode.Normal,
                TricksterWeaponId = 12
            },
            
            new Attack {
                Id = 457,
                Name = "R1 (sidestep)",
                Damage = 0,
                ExtraDamage = 0,
                ExtraDamageCount = 0,
                AttackType1 = AttackType.Physical,
                AttackType2 = AttackType.None,
                AttackMode = AttackMode.Normal,
                TricksterWeaponId = 12
            },
            
            new Attack {
                Id = 458,
                Name = "R1 (dash)",
                Damage = 1,
                ExtraDamage = 0,
                ExtraDamageCount = 0,
                AttackType1 = AttackType.Physical,
                AttackType2 = AttackType.None,
                AttackMode = AttackMode.Normal,
                TricksterWeaponId = 12
            },
            
            new Attack {
                Id = 459,
                Name = "R2",
                Damage = 1,
                ExtraDamage = 0,
                ExtraDamageCount = 0,
                AttackType1 = AttackType.Blunt,
                AttackType2 = AttackType.None,
                AttackMode = AttackMode.Normal,
                TricksterWeaponId = 12
            },
            
            new Attack {
                Id = 460,
                Name = "R2 (charged)",
                Damage = 2,
                ExtraDamage = 0,
                ExtraDamageCount = 0,
                AttackType1 = AttackType.Blunt,
                AttackType2 = AttackType.None,
                AttackMode = AttackMode.Normal,
                TricksterWeaponId = 12
            },
            
            new Attack {
                Id = 461,
                Name = "R2 (backstep)",
                Damage = 1,
                ExtraDamage = 0,
                ExtraDamageCount = 0,
                AttackType1 = AttackType.Blunt,
                AttackType2 = AttackType.None,
                AttackMode = AttackMode.Normal,
                TricksterWeaponId = 12
            },
            
            new Attack {
                Id = 462,
                Name = "R2 (dash)",
                Damage = 1,
                ExtraDamage = 0,
                ExtraDamageCount = 0,
                AttackType1 = AttackType.Physical,
                AttackType2 = AttackType.None,
                AttackMode = AttackMode.Normal,
                TricksterWeaponId = 12
            },
            
            new Attack {
                Id = 463,
                Name = "R2 (forward leap)",
                Damage = 1,
                ExtraDamage = 0,
                ExtraDamageCount = 0,
                AttackType1 = AttackType.Blunt,
                AttackType2 = AttackType.None,
                AttackMode = AttackMode.Normal,
                TricksterWeaponId = 12
            },
            
            new Attack {
                Id = 464,
                Name = "Transform Attack",
                Damage = 1,
                ExtraDamage = 0,
                ExtraDamageCount = 0,
                AttackType1 = AttackType.Physical,
                AttackType2 = AttackType.None,
                AttackMode = AttackMode.Normal,
                TricksterWeaponId = 12
            },
            
            new Attack {
                Id = 465,
                Name = "Plunge Attack",
                Damage = 1,
                ExtraDamage = 0,
                ExtraDamageCount = 0,
                AttackType1 = AttackType.Blunt,
                AttackType2 = AttackType.None,
                AttackMode = AttackMode.Normal,
                TricksterWeaponId = 12
            },
            
            new Attack {
                Id = 466,
                Name = "Plunge Attack (2nd)",
                Damage = 0,
                ExtraDamage = 0,
                ExtraDamageCount = 0,
                AttackType1 = AttackType.Blunt,
                AttackType2 = AttackType.None,
                AttackMode = AttackMode.Normal,
                TricksterWeaponId = 12
            },
            
            new Attack {
                Id = 467,
                Name = "R1",
                Damage = 1,
                ExtraDamage = 0,
                ExtraDamageCount = 0,
                AttackType1 = AttackType.Blunt,
                AttackType2 = AttackType.None,
                AttackMode = AttackMode.Transformed,
                TricksterWeaponId = 12
            },
            
            new Attack {
                Id = 468,
                Name = "R1 (2nd)",
                Damage = 1,
                ExtraDamage = 0,
                ExtraDamageCount = 0,
                AttackType1 = AttackType.Blunt,
                AttackType2 = AttackType.None,
                AttackMode = AttackMode.Transformed,
                TricksterWeaponId = 12
            },
            
            new Attack {
                Id = 469,
                Name = "R1 (3rd)",
                Damage = 1,
                ExtraDamage = 0,
                ExtraDamageCount = 0,
                AttackType1 = AttackType.Physical,
                AttackType2 = AttackType.None,
                AttackMode = AttackMode.Transformed,
                TricksterWeaponId = 12
            },

            new Attack {
                Id = 470,
                Name = "R1 (4th)",
                Damage = 1,
                ExtraDamage = 0,
                ExtraDamageCount = 0,
                AttackType1 = AttackType.Blunt,
                AttackType2 = AttackType.None,
                AttackMode = AttackMode.Transformed,
                TricksterWeaponId = 12
            },
            
            new Attack {
                Id = 471,
                Name = "R1 (5th)",
                Damage = 1,
                ExtraDamage = 0,
                ExtraDamageCount = 0,
                AttackType1 = AttackType.Blunt,
                AttackType2 = AttackType.None,
                AttackMode = AttackMode.Transformed,
                TricksterWeaponId = 12
            },
            
            new Attack {
                Id = 472,
                Name = "R1 (backstep)",
                Damage = 1,
                ExtraDamage = 0,
                ExtraDamageCount = 0,
                AttackType1 = AttackType.Physical,
                AttackType2 = AttackType.None,
                AttackMode = AttackMode.Transformed,
                TricksterWeaponId = 12
            },
            
            new Attack {
                Id = 473,
                Name = "R1 (rolling)",
                Damage = 0,
                ExtraDamage = 0,
                ExtraDamageCount = 0,
                AttackType1 = AttackType.Physical,
                AttackType2 = AttackType.None,
                AttackMode = AttackMode.Transformed,
                TricksterWeaponId = 12
            },
            
            new Attack {
                Id = 474,
                Name = "R1 (frontstep)",
                Damage = 0,
                ExtraDamage = 0,
                ExtraDamageCount = 0,
                AttackType1 = AttackType.Physical,
                AttackType2 = AttackType.None,
                AttackMode = AttackMode.Transformed,
                TricksterWeaponId = 12
            },
            
            new Attack {
                Id = 475,
                Name = "R1 (sidestep)",
                Damage = 0,
                ExtraDamage = 0,
                ExtraDamageCount = 0,
                AttackType1 = AttackType.Physical,
                AttackType2 = AttackType.None,
                AttackMode = AttackMode.Transformed,
                TricksterWeaponId = 12
            },
            
            new Attack {
                Id = 476,
                Name = "R1 (dash)",
                Damage = 1,
                ExtraDamage = 0,
                ExtraDamageCount = 0,
                AttackType1 = AttackType.Physical,
                AttackType2 = AttackType.None,
                AttackMode = AttackMode.Transformed,
                TricksterWeaponId = 12
            },
            
            new Attack {
                Id = 477,
                Name = "R2",
                Damage = 1,
                ExtraDamage = 0,
                ExtraDamageCount = 0,
                AttackType1 = AttackType.Blunt,
                AttackType2 = AttackType.None,
                AttackMode = AttackMode.Transformed,
                TricksterWeaponId = 12
            },
            
            new Attack {
                Id = 478,
                Name = "R2 (charged)",
                Damage = 1,
                ExtraDamage = 1,
                ExtraDamageCount = 1,
                AttackType1 = AttackType.Blunt,
                AttackType2 = AttackType.None,
                AttackMode = AttackMode.Transformed,
                TricksterWeaponId = 12
            },
            
            new Attack {
                Id = 479,
                Name = "R2 (backstep)",
                Damage = 1,
                ExtraDamage = 0,
                ExtraDamageCount = 0,
                AttackType1 = AttackType.Blunt,
                AttackType2 = AttackType.None,
                AttackMode = AttackMode.Transformed,
                TricksterWeaponId = 12
            },
            
            new Attack {
                Id = 480,
                Name = "R2 (dash)",
                Damage = 1,
                ExtraDamage = 0,
                ExtraDamageCount = 0,
                AttackType1 = AttackType.Blunt,
                AttackType2 = AttackType.None,
                AttackMode = AttackMode.Transformed,
                TricksterWeaponId = 12
            },
            
            new Attack {
                Id = 481,
                Name = "R2(forward leap)",
                Damage = 1,
                ExtraDamage = 0,
                ExtraDamageCount = 0,
                AttackType1 = AttackType.Blunt,
                AttackType2 = AttackType.None,
                AttackMode = AttackMode.Transformed,
                TricksterWeaponId = 12
            },
            
            new Attack {
                Id = 482,
                Name = "L2",
                Damage = 1,
                ExtraDamage = 0,
                ExtraDamageCount = 0,
                AttackType1 = AttackType.Blunt,
                AttackType2 = AttackType.None,
                AttackMode = AttackMode.Transformed,
                TricksterWeaponId = 12
            },
            
            new Attack {
                Id = 483,
                Name = "L2 (2nd)",
                Damage = 1,
                ExtraDamage = 0,
                ExtraDamageCount = 0,
                AttackType1 = AttackType.Blunt,
                AttackType2 = AttackType.None,
                AttackMode = AttackMode.Transformed,
                TricksterWeaponId = 12
            },
            
            new Attack {
                Id = 484,
                Name = "L2 (3rd)",
                Damage = 1,
                ExtraDamage = 0,
                ExtraDamageCount = 0,
                AttackType1 = AttackType.Blunt,
                AttackType2 = AttackType.None,
                AttackMode = AttackMode.Transformed,
                TricksterWeaponId = 12
            },
            
            new Attack {
                Id = 485,
                Name = "Transform Attack",
                Damage = 1,
                ExtraDamage = 0,
                ExtraDamageCount = 0,
                AttackType1 = AttackType.Blunt,
                AttackType2 = AttackType.None,
                AttackMode = AttackMode.Transformed,
                TricksterWeaponId = 12
            },
            
            new Attack {
                Id = 486,
                Name = "Plunge Attack",
                Damage = 1,
                ExtraDamage = 0,
                ExtraDamageCount = 0,
                AttackType1 = AttackType.Blunt,
                AttackType2 = AttackType.None,
                AttackMode = AttackMode.Transformed,
                TricksterWeaponId = 12
            },
            
            new Attack {
                Id = 487,
                Name = "Plunge Attack (2nd)",
                Damage = 0,
                ExtraDamage = 0,
                ExtraDamageCount = 0,
                AttackType1 = AttackType.Blunt,
                AttackType2 = AttackType.None,
                AttackMode = AttackMode.Transformed,
                TricksterWeaponId = 12
            },
            
            new Attack {
                Id = 488,
                Name = "R1",
                Damage = 0,
                ExtraDamage = 0,
                ExtraDamageCount = 0,
                AttackType1 = AttackType.Physical,
                AttackType2 = AttackType.None,
                AttackMode = AttackMode.Normal,
                TricksterWeaponId = 13
            },
            
            new Attack {
                Id = 489,
                Name = "R1 (2nd)",
                Damage = 0,
                ExtraDamage = 0,
                ExtraDamageCount = 0,
                AttackType1 = AttackType.Physical,
                AttackType2 = AttackType.None,
                AttackMode = AttackMode.Normal,
                TricksterWeaponId = 13
            },
            
            new Attack {
                Id = 490,
                Name = "R1 (3rd)",
                Damage = 0,
                ExtraDamage = 0,
                ExtraDamageCount = 0,
                AttackType1 = AttackType.Physical,
                AttackType2 = AttackType.None,
                AttackMode = AttackMode.Normal,
                TricksterWeaponId = 13
            },
            
            new Attack {
                Id = 491,
                Name = "R1 (4th)",
                Damage = 0,
                ExtraDamage = 0,
                ExtraDamageCount = 0,
                AttackType1 = AttackType.Thrust,
                AttackType2 = AttackType.None,
                AttackMode = AttackMode.Normal,
                TricksterWeaponId = 13
            },
            
            new Attack {
                Id = 492,
                Name = "R1 (5th)",
                Damage = 0,
                ExtraDamage = 0,
                ExtraDamageCount = 0,
                AttackType1 = AttackType.Physical,
                AttackType2 = AttackType.None,
                AttackMode = AttackMode.Normal,
                TricksterWeaponId = 13
            },
            
            new Attack {
                Id = 493,
                Name = "R1 (backstep)",
                Damage = 0,
                ExtraDamage = 0,
                ExtraDamageCount = 0,
                AttackType1 = AttackType.Physical,
                AttackType2 = AttackType.None,
                AttackMode = AttackMode.Normal,
                TricksterWeaponId = 13
            },
            
            new Attack {
                Id = 494,
                Name = "R1 (rolling)",
                Damage = 0,
                ExtraDamage = 0,
                ExtraDamageCount = 0,
                AttackType1 = AttackType.Physical,
                AttackType2 = AttackType.None,
                AttackMode = AttackMode.Normal,
                TricksterWeaponId = 13
            },
            
            new Attack {
                Id = 495,
                Name = "R1 (frontstep)",
                Damage = 0,
                ExtraDamage = 0,
                ExtraDamageCount = 0,
                AttackType1 = AttackType.Physical,
                AttackType2 = AttackType.None,
                AttackMode = AttackMode.Normal,
                TricksterWeaponId = 13
            },
            
            new Attack {
                Id = 496,
                Name = "R1 (sidestep)",
                Damage = 0,
                ExtraDamage = 0,
                ExtraDamageCount = 0,
                AttackType1 = AttackType.Physical,
                AttackType2 = AttackType.None,
                AttackMode = AttackMode.Normal,
                TricksterWeaponId = 13
            },
            
            new Attack {
                Id = 497,
                Name = "R1 (dash)",
                Damage = 0,
                ExtraDamage = 0,
                ExtraDamageCount = 0,
                AttackType1 = AttackType.Physical,
                AttackType2 = AttackType.None,
                AttackMode = AttackMode.Normal,
                TricksterWeaponId = 13
            },
            
            new Attack {
                Id = 498,
                Name = "R2",
                Damage = 1,
                ExtraDamage = 0,
                ExtraDamageCount = 0,
                AttackType1 = AttackType.Thrust,
                AttackType2 = AttackType.None,
                AttackMode = AttackMode.Normal,
                TricksterWeaponId = 13
            },
            
            new Attack {
                Id = 499,
                Name = "R2 (charged)",
                Damage = 1,
                ExtraDamage = 0,
                ExtraDamageCount = 0,
                AttackType1 = AttackType.Thrust,
                AttackType2 = AttackType.None,
                AttackMode = AttackMode.Normal,
                TricksterWeaponId = 13
            },
            
            new Attack {
                Id = 500,
                Name = "R2 (backstep)",
                Damage = 0,
                ExtraDamage = 0,
                ExtraDamageCount = 0,
                AttackType1 = AttackType.Thrust,
                AttackType2 = AttackType.None,
                AttackMode = AttackMode.Normal,
                TricksterWeaponId = 13
            },
            
            new Attack {
                Id = 501,
                Name = "R2 (dash)",
                Damage = 0,
                ExtraDamage = 0,
                ExtraDamageCount = 0,
                AttackType1 = AttackType.Thrust,
                AttackType2 = AttackType.None,
                AttackMode = AttackMode.Normal,
                TricksterWeaponId = 13
            },
            
            new Attack {
                Id = 502,
                Name = "R2 (forward leap)",
                Damage = 1,
                ExtraDamage = 0,
                ExtraDamageCount = 0,
                AttackType1 = AttackType.Thrust,
                AttackType2 = AttackType.None,
                AttackMode = AttackMode.Normal,
                TricksterWeaponId = 13
            },
            
            new Attack {
                Id = 503,
                Name = "Transform Attack",
                Damage = 1,
                ExtraDamage = 0,
                ExtraDamageCount = 0,
                AttackType1 = AttackType.Blunt,
                AttackType2 = AttackType.None,
                AttackMode = AttackMode.Normal,
                TricksterWeaponId = 13
            },
            
            new Attack {
                Id = 504,
                Name = "Transform Attack to R1",
                Damage = 0,
                ExtraDamage = 0,
                ExtraDamageCount = 0,
                AttackType1 = AttackType.Physical,
                AttackType2 = AttackType.None,
                AttackMode = AttackMode.Normal,
                TricksterWeaponId = 13
            },
            
            new Attack {
                Id = 505,
                Name = "Plunge Attack",
                Damage = 1,
                ExtraDamage = 0,
                ExtraDamageCount = 0,
                AttackType1 = AttackType.Thrust,
                AttackType2 = AttackType.None,
                AttackMode = AttackMode.Normal,
                TricksterWeaponId = 13
            },
            
            new Attack {
                Id = 506,
                Name = "Plunge Attack (2nd)",
                Damage = 0,
                ExtraDamage = 0,
                ExtraDamageCount = 0,
                AttackType1 = AttackType.Blunt,
                AttackType2 = AttackType.None,
                AttackMode = AttackMode.Normal,
                TricksterWeaponId = 13
            },
            
            new Attack {
                Id = 507,
                Name = "R1",
                Damage = 1,
                ExtraDamage = 0,
                ExtraDamageCount = 0,
                AttackType1 = AttackType.Blunt,
                AttackType2 = AttackType.None,
                AttackMode = AttackMode.Transformed,
                TricksterWeaponId = 13
            },
            
            new Attack {
                Id = 508,
                Name = "R1 (2nd)",
                Damage = 1,
                ExtraDamage = 0,
                ExtraDamageCount = 0,
                AttackType1 = AttackType.Blunt,
                AttackType2 = AttackType.None,
                AttackMode = AttackMode.Transformed,
                TricksterWeaponId = 13
            },
            
            new Attack {
                Id = 509,
                Name = "R1 (3rd)",
                Damage = 1,
                ExtraDamage = 0,
                ExtraDamageCount = 0,
                AttackType1 = AttackType.Blunt,
                AttackType2 = AttackType.None,
                AttackMode = AttackMode.Transformed,
                TricksterWeaponId = 13
            },
            
            new Attack {
                Id = 510,
                Name = "R1 (4th)",
                Damage = 1,
                ExtraDamage = 0,
                ExtraDamageCount = 0,
                AttackType1 = AttackType.Blunt,
                AttackType2 = AttackType.None,
                AttackMode = AttackMode.Transformed,
                TricksterWeaponId = 13
            },
            
            new Attack {
                Id = 511,
                Name = "R1 (backstep)",
                Damage = 0,
                ExtraDamage = 0,
                ExtraDamageCount = 0,
                AttackType1 = AttackType.Blunt,
                AttackType2 = AttackType.None,
                AttackMode = AttackMode.Transformed,
                TricksterWeaponId = 13
            },
            
            new Attack {
                Id = 512,
                Name = "R1 (rolling)",
                Damage = 0,
                ExtraDamage = 0,
                ExtraDamageCount = 0,
                AttackType1 = AttackType.Blunt,
                AttackType2 = AttackType.None,
                AttackMode = AttackMode.Transformed,
                TricksterWeaponId = 13
            },
            
            new Attack {
                Id = 513,
                Name = "R1 (frontstep)",
                Damage = 0,
                ExtraDamage = 0,
                ExtraDamageCount = 0,
                AttackType1 = AttackType.Blunt,
                AttackType2 = AttackType.None,
                AttackMode = AttackMode.Transformed,
                TricksterWeaponId = 13
            },
            
            new Attack {
                Id = 514,
                Name = "R1 (sidestep)",
                Damage = 0,
                ExtraDamage = 0,
                ExtraDamageCount = 0,
                AttackType1 = AttackType.Blunt,
                AttackType2 = AttackType.None,
                AttackMode = AttackMode.Transformed,
                TricksterWeaponId = 13
            },
            
            new Attack {
                Id = 515,
                Name = "R1 (dash)",
                Damage = 0,
                ExtraDamage = 0,
                ExtraDamageCount = 0,
                AttackType1 = AttackType.Blunt,
                AttackType2 = AttackType.None,
                AttackMode = AttackMode.Transformed,
                TricksterWeaponId = 13
            },
            
            new Attack {
                Id = 516,
                Name = "R2",
                Damage = 1,
                ExtraDamage = 0,
                ExtraDamageCount = 0,
                AttackType1 = AttackType.Blunt,
                AttackType2 = AttackType.None,
                AttackMode = AttackMode.Transformed,
                TricksterWeaponId = 13
            },
            
            new Attack {
                Id = 517,
                Name = "R2 (charged)",
                Damage = 2,
                ExtraDamage = 0,
                ExtraDamageCount = 0,
                AttackType1 = AttackType.Blunt,
                AttackType2 = AttackType.None,
                AttackMode = AttackMode.Transformed,
                TricksterWeaponId = 13
            },
            
            new Attack {
                Id = 518,
                Name = "R2 (charged follow-up)",
                Damage = 1,
                ExtraDamage = 0,
                ExtraDamageCount = 0,
                AttackType1 = AttackType.Blunt,
                AttackType2 = AttackType.None,
                AttackMode = AttackMode.Transformed,
                TricksterWeaponId = 13
            },
            
            new Attack {
                Id = 519,
                Name = "R2 (backstep)",
                Damage = 1,
                ExtraDamage = 0,
                ExtraDamageCount = 0,
                AttackType1 = AttackType.Blunt,
                AttackType2 = AttackType.None,
                AttackMode = AttackMode.Transformed,
                TricksterWeaponId = 13
            },
            
            new Attack {
                Id = 520,
                Name = "R2 (dash)",
                Damage = 1,
                ExtraDamage = 0,
                ExtraDamageCount = 0,
                AttackType1 = AttackType.Blunt,
                AttackType2 = AttackType.None,
                AttackMode = AttackMode.Transformed,
                TricksterWeaponId = 13
            },
            
            new Attack {
                Id = 521,
                Name = "R2 (forward leap)",
                Damage = 1,
                ExtraDamage = 0,
                ExtraDamageCount = 0,
                AttackType1 = AttackType.Blunt,
                AttackType2 = AttackType.None,
                AttackMode = AttackMode.Transformed,
                TricksterWeaponId = 13
            },
            
            new Attack {
                Id = 522,
                Name = "L2",
                Damage = 1,
                ExtraDamage = 0,
                ExtraDamageCount = 0,
                AttackType1 = AttackType.Blunt,
                AttackType2 = AttackType.None,
                AttackMode = AttackMode.Transformed,
                TricksterWeaponId = 13
            },
            
            new Attack {
                Id = 523,
                Name = "L2 (2nd)",
                Damage = 1,
                ExtraDamage = 0,
                ExtraDamageCount = 0,
                AttackType1 = AttackType.Blunt,
                AttackType2 = AttackType.None,
                AttackMode = AttackMode.Transformed,
                TricksterWeaponId = 13
            },
            
            new Attack {
                Id = 524,
                Name = "L2 (3rd)",
                Damage = 1,
                ExtraDamage = 0,
                ExtraDamageCount = 0,
                AttackType1 = AttackType.Blunt,
                AttackType2 = AttackType.None,
                AttackMode = AttackMode.Transformed,
                TricksterWeaponId = 13
            },
            
            new Attack {
                Id = 525,
                Name = "Transform Attack",
                Damage = 1,
                ExtraDamage = 0,
                ExtraDamageCount = 0,
                AttackType1 = AttackType.Blunt,
                AttackType2 = AttackType.None,
                AttackMode = AttackMode.Transformed,
                TricksterWeaponId = 13
            },
            
            new Attack {
                Id = 526,
                Name = "Transform Attack to R1",
                Damage = 0,
                ExtraDamage = 0,
                ExtraDamageCount = 0,
                AttackType1 = AttackType.Blunt,
                AttackType2 = AttackType.None,
                AttackMode = AttackMode.Transformed,
                TricksterWeaponId = 13
            },
            
            new Attack {
                Id = 527,
                Name = "Plunge Attack",
                Damage = 1,
                ExtraDamage = 0,
                ExtraDamageCount = 0,
                AttackType1 = AttackType.Blunt,
                AttackType2 = AttackType.None,
                AttackMode = AttackMode.Transformed,
                TricksterWeaponId = 13
            },
            
            new Attack {
                Id = 528,
                Name = "Plunge Attack (2nd)",
                Damage = 0,
                ExtraDamage = 0,
                ExtraDamageCount = 0,
                AttackType1 = AttackType.Blunt,
                AttackType2 = AttackType.None,
                AttackMode = AttackMode.Transformed,
                TricksterWeaponId = 13
            },
            
            new Attack {
                Id = 529,
                Name = "R1 (Milkweed Rune)",
                Damage = 2,
                ExtraDamage = 0,
                ExtraDamageCount = 0,
                AttackType1 = AttackType.Arcane,
                AttackType2 = AttackType.None,
                AttackMode = AttackMode.Normal,
                TricksterWeaponId = 14
            },
            
            new Attack {
                Id = 530,
                Name = "R1 (2nd) (Milkweed Rune)",
                Damage = 2,
                ExtraDamage = 0,
                ExtraDamageCount = 0,
                AttackType1 = AttackType.Arcane,
                AttackType2 = AttackType.None,
                AttackMode = AttackMode.Normal,
                TricksterWeaponId = 14
            },
            
            new Attack {
                Id = 531,
                Name = "R1 (3rd) (Milkweed Rune)",
                Damage = 2,
                ExtraDamage = 0,
                ExtraDamageCount = 0,
                AttackType1 = AttackType.Arcane,
                AttackType2 = AttackType.None,
                AttackMode = AttackMode.Normal,
                TricksterWeaponId = 14
            },
            
            new Attack {
                Id = 532,
                Name = "R1 (backstep) (Milkweed Rune)",
                Damage = 1,
                ExtraDamage = 0,
                ExtraDamageCount = 0,
                AttackType1 = AttackType.Arcane,
                AttackType2 = AttackType.None,
                AttackMode = AttackMode.Normal,
                TricksterWeaponId = 14
            },
            
            new Attack {
                Id = 533,
                Name = "R1 (rolling) (Milkweed Rune)",
                Damage = 1,
                ExtraDamage = 1,
                ExtraDamageCount = 1,
                AttackType1 = AttackType.Arcane,
                AttackType2 = AttackType.None,
                AttackMode = AttackMode.Normal,
                TricksterWeaponId = 14
            },
            
            new Attack {
                Id = 534,
                Name = "R1 (frontstep) (Milkweed Rune)",
                Damage = 1,
                ExtraDamage = 1,
                ExtraDamageCount = 1,
                AttackType1 = AttackType.Arcane,
                AttackType2 = AttackType.None,
                AttackMode = AttackMode.Normal,
                TricksterWeaponId = 14
            },
            
            new Attack {
                Id = 535,
                Name = "R1 (sidestep) (Milkweed Rune)",
                Damage = 1,
                ExtraDamage = 1,
                ExtraDamageCount = 1,
                AttackType1 = AttackType.Arcane,
                AttackType2 = AttackType.None,
                AttackMode = AttackMode.Normal,
                TricksterWeaponId = 14
            },
            
            new Attack {
                Id = 536,
                Name = "R1 (dash) (Milkweed Rune)",
                Damage = 2,
                ExtraDamage = 0,
                ExtraDamageCount = 0,
                AttackType1 = AttackType.Arcane,
                AttackType2 = AttackType.None,
                AttackMode = AttackMode.Normal,
                TricksterWeaponId = 14
            },
            
            new Attack {
                Id = 537,
                Name = "R2 (Milkweed Rune)",
                Damage = 2,
                ExtraDamage = 0,
                ExtraDamageCount = 0,
                AttackType1 = AttackType.Arcane,
                AttackType2 = AttackType.None,
                AttackMode = AttackMode.Normal,
                TricksterWeaponId = 14
            },
            
            new Attack {
                Id = 538,
                Name = "R2 (charged) (Milkweed Rune)",
                Damage = 1,
                ExtraDamage = 2,
                ExtraDamageCount = 1,
                AttackType1 = AttackType.Arcane,
                AttackType2 = AttackType.None,
                AttackMode = AttackMode.Normal,
                TricksterWeaponId = 14
            },
            
            new Attack {
                Id = 539,
                Name = "R2 (backstep) (Milkweed Rune)",
                Damage = 2,
                ExtraDamage = 0,
                ExtraDamageCount = 0,
                AttackType1 = AttackType.Arcane,
                AttackType2 = AttackType.None,
                AttackMode = AttackMode.Normal,
                TricksterWeaponId = 14
            },
            
            new Attack {
                Id = 540,
                Name = "R2 (dash) (Milkweed Rune)",
                Damage = 1,
                ExtraDamage = 2,
                ExtraDamageCount = 1,
                AttackType1 = AttackType.Arcane,
                AttackType2 = AttackType.None,
                AttackMode = AttackMode.Normal,
                TricksterWeaponId = 14
            },
            
            new Attack {
                Id = 541,
                Name = "R2 (forward leap) (Milkweed Rune)",
                Damage = 2,
                ExtraDamage = 0,
                ExtraDamageCount = 0,
                AttackType1 = AttackType.Arcane,
                AttackType2 = AttackType.None,
                AttackMode = AttackMode.Normal,
                TricksterWeaponId = 14
            },
            
            new Attack {
                Id = 542,
                Name = "Transform Attack (Milkweed Rune)",
                Damage = 2,
                ExtraDamage = 0,
                ExtraDamageCount = 0,
                AttackType1 = AttackType.Arcane,
                AttackType2 = AttackType.None,
                AttackMode = AttackMode.Normal,
                TricksterWeaponId = 14
            },
            
            new Attack {
                Id = 543,
                Name = "Plunge Attack (Milkweed Rune)",
                Damage = 2,
                ExtraDamage = 0,
                ExtraDamageCount = 0,
                AttackType1 = AttackType.Arcane,
                AttackType2 = AttackType.None,
                AttackMode = AttackMode.Normal,
                TricksterWeaponId = 14
            },
            
            new Attack {
                Id = 544,
                Name = "Plunge Attack (2nd) (Milkweed Rune)",
                Damage = 1,
                ExtraDamage = 0,
                ExtraDamageCount = 0,
                AttackType1 = AttackType.Blunt,
                AttackType2 = AttackType.Arcane,
                AttackMode = AttackMode.Normal,
                TricksterWeaponId = 14
            },
            
            new Attack {
                Id = 545,
                Name = "R1 (Milkweed Rune)",
                Damage = 2,
                ExtraDamage = 0,
                ExtraDamageCount = 0,
                AttackType1 = AttackType.Arcane,
                AttackType2 = AttackType.None,
                AttackMode = AttackMode.Transformed,
                TricksterWeaponId = 14
            },
            
            new Attack {
                Id = 546,
                Name = "R1 (2nd) (Milkweed Rune)",
                Damage = 2,
                ExtraDamage = 0,
                ExtraDamageCount = 0,
                AttackType1 = AttackType.Arcane,
                AttackType2 = AttackType.None,
                AttackMode = AttackMode.Transformed,
                TricksterWeaponId = 14
            },
            
            new Attack {
                Id = 547,
                Name = "R1 (3rd) (Milkweed Rune)",
                Damage = 2,
                ExtraDamage = 0,
                ExtraDamageCount = 0,
                AttackType1 = AttackType.Arcane,
                AttackType2 = AttackType.None,
                AttackMode = AttackMode.Transformed,
                TricksterWeaponId = 14
            },
            
            new Attack {
                Id = 548,
                Name = "R1 (backstep) (Milkweed Rune)",
                Damage = 1,
                ExtraDamage = 0,
                ExtraDamageCount = 0,
                AttackType1 = AttackType.Arcane,
                AttackType2 = AttackType.None,
                AttackMode = AttackMode.Transformed,
                TricksterWeaponId = 14
            },
            
            new Attack {
                Id = 549,
                Name = "R1 (rolling) (Milkweed Rune)",
                Damage = 2,
                ExtraDamage = 0,
                ExtraDamageCount = 0,
                AttackType1 = AttackType.Arcane,
                AttackType2 = AttackType.None,
                AttackMode = AttackMode.Transformed,
                TricksterWeaponId = 14
            },
            
            new Attack {
                Id = 550,
                Name = "R1 (frontstep) (Milkweed Rune)",
                Damage = 2,
                ExtraDamage = 0,
                ExtraDamageCount = 0,
                AttackType1 = AttackType.Arcane,
                AttackType2 = AttackType.None,
                AttackMode = AttackMode.Transformed,
                TricksterWeaponId = 14
            },
            
            new Attack {
                Id = 551,
                Name = "R1 (sidestep) (Milkweed Rune)",
                Damage = 2,
                ExtraDamage = 0,
                ExtraDamageCount = 0,
                AttackType1 = AttackType.Arcane,
                AttackType2 = AttackType.None,
                AttackMode = AttackMode.Transformed,
                TricksterWeaponId = 14
            },
            
            new Attack {
                Id = 552,
                Name = "R1 (dash) (Milkweed Rune)",
                Damage = 2,
                ExtraDamage = 0,
                ExtraDamageCount = 0,
                AttackType1 = AttackType.Arcane,
                AttackType2 = AttackType.None,
                AttackMode = AttackMode.Transformed,
                TricksterWeaponId = 14
            },
            
            new Attack {
                Id = 553,
                Name = "R2 (Milkweed Rune)",
                Damage = 2,
                ExtraDamage = 0,
                ExtraDamageCount = 0,
                AttackType1 = AttackType.Arcane,
                AttackType2 = AttackType.None,
                AttackMode = AttackMode.Transformed,
                TricksterWeaponId = 14
            },
            
            new Attack {
                Id = 554,
                Name = "R2 (2nd hit) (Milkweed Rune)",
                Damage = 2,
                ExtraDamage = 0,
                ExtraDamageCount = 0,
                AttackType1 = AttackType.Arcane,
                AttackType2 = AttackType.None,
                AttackMode = AttackMode.Transformed,
                TricksterWeaponId = 14
            },
            
            new Attack {
                Id = 555,
                Name = "R2 (backstep) (Milkweed Rune)",
                Damage = 2,
                ExtraDamage = 0,
                ExtraDamageCount = 0,
                AttackType1 = AttackType.Arcane,
                AttackType2 = AttackType.None,
                AttackMode = AttackMode.Transformed,
                TricksterWeaponId = 14
            },
            
            new Attack {
                Id = 556,
                Name = "R2 (dash) (Milkweed Rune)",
                Damage = 1,
                ExtraDamage = 2,
                ExtraDamageCount = 1,
                AttackType1 = AttackType.Arcane,
                AttackType2 = AttackType.None,
                AttackMode = AttackMode.Transformed,
                TricksterWeaponId = 14
            },
            
            new Attack {
                Id = 557,
                Name = "R2 (forward leap) (Milkweed Rune)",
                Damage = 2,
                ExtraDamage = 0,
                ExtraDamageCount = 0,
                AttackType1 = AttackType.Arcane,
                AttackType2 = AttackType.None,
                AttackMode = AttackMode.Transformed,
                TricksterWeaponId = 14
            },
            
            new Attack {
                Id = 558,
                Name = "L2 (Milkweed Rune)",
                Damage = 0,
                ExtraDamage = 0,
                ExtraDamageCount = 0,
                AttackType1 = AttackType.Arcane,
                AttackType2 = AttackType.None,
                AttackMode = AttackMode.Transformed,
                TricksterWeaponId = 14
            },
            
            new Attack {
                Id = 559,
                Name = "L2 (2nd hit) (Milkweed Rune)",
                Damage = 1,
                ExtraDamage = 0,
                ExtraDamageCount = 0,
                AttackType1 = AttackType.Arcane,
                AttackType2 = AttackType.None,
                AttackMode = AttackMode.Transformed,
                TricksterWeaponId = 14
            },
            
            new Attack {
                Id = 560,
                Name = "L2 (3rd hit) (Milkweed Rune)",
                Damage = 1,
                ExtraDamage = 0,
                ExtraDamageCount = 0,
                AttackType1 = AttackType.Arcane,
                AttackType2 = AttackType.None,
                AttackMode = AttackMode.Transformed,
                TricksterWeaponId = 14
            },
            
            new Attack {
                Id = 561,
                Name = "L2 (4th hit) (Milkweed Rune)",
                Damage = 3,
                ExtraDamage = 0,
                ExtraDamageCount = 0,
                AttackType1 = AttackType.Arcane,
                AttackType2 = AttackType.None,
                AttackMode = AttackMode.Transformed,
                TricksterWeaponId = 14
            },
            
            new Attack {
                Id = 562,
                Name = "Transform Attack (Milkweed Rune)",
                Damage = 2,
                ExtraDamage = 0,
                ExtraDamageCount = 0,
                AttackType1 = AttackType.Arcane,
                AttackType2 = AttackType.None,
                AttackMode = AttackMode.Transformed,
                TricksterWeaponId = 14
            },
            
            new Attack {
                Id = 563,
                Name = "Plunge Attack (Milkweed Rune)",
                Damage = 1,
                ExtraDamage = 0,
                ExtraDamageCount = 0,
                AttackType1 = AttackType.Arcane,
                AttackType2 = AttackType.None,
                AttackMode = AttackMode.Transformed,
                TricksterWeaponId = 14
            },
            
            new Attack {
                Id = 564,
                Name = "Plunge Attack (2nd) (Milkweed Rune)",
                Damage = 1,
                ExtraDamage = 0,
                ExtraDamageCount = 0,
                AttackType1 = AttackType.Blunt,
                AttackType2 = AttackType.Arcane,
                AttackMode = AttackMode.Transformed,
                TricksterWeaponId = 14
            },
            
            new Attack {
                Id = 565,
                Name = "R1",
                Damage = 1,
                ExtraDamage = 0,
                ExtraDamageCount = 0,
                AttackType1 = AttackType.Arcane,
                AttackType2 = AttackType.None,
                AttackMode = AttackMode.Normal,
                TricksterWeaponId = 14
            },
            
            new Attack {
                Id = 566,
                Name = "R1 (2nd)",
                Damage = 1,
                ExtraDamage = 0,
                ExtraDamageCount = 0,
                AttackType1 = AttackType.Arcane,
                AttackType2 = AttackType.None,
                AttackMode = AttackMode.Normal,
                TricksterWeaponId = 14
            },
            
            new Attack {
                Id = 567,
                Name = "R1 (3rd)",
                Damage = 1,
                ExtraDamage = 0,
                ExtraDamageCount = 0,
                AttackType1 = AttackType.Arcane,
                AttackType2 = AttackType.None,
                AttackMode = AttackMode.Normal,
                TricksterWeaponId = 14
            },
            
            new Attack {
                Id = 568,
                Name = "R1 (4th)",
                Damage = 1,
                ExtraDamage = 0,
                ExtraDamageCount = 0,
                AttackType1 = AttackType.Arcane,
                AttackType2 = AttackType.None,
                AttackMode = AttackMode.Normal,
                TricksterWeaponId = 14
            },
            
            new Attack {
                Id = 569,
                Name = "R1 (5th)",
                Damage = 1,
                ExtraDamage = 0,
                ExtraDamageCount = 0,
                AttackType1 = AttackType.Arcane,
                AttackType2 = AttackType.None,
                AttackMode = AttackMode.Normal,
                TricksterWeaponId = 14
            },
            
            new Attack {
                Id = 570,
                Name = "R1 (backstep)",
                Damage = 0,
                ExtraDamage = 0,
                ExtraDamageCount = 0,
                AttackType1 = AttackType.Arcane,
                AttackType2 = AttackType.None,
                AttackMode = AttackMode.Normal,
                TricksterWeaponId = 14
            },
            
            new Attack {
                Id = 571,
                Name = "R1 (rolling)",
                Damage = 0,
                ExtraDamage = 0,
                ExtraDamageCount = 0,
                AttackType1 = AttackType.Arcane,
                AttackType2 = AttackType.None,
                AttackMode = AttackMode.Normal,
                TricksterWeaponId = 14
            },
            
            new Attack {
                Id = 572,
                Name = "R1 (frontstep)",
                Damage = 0,
                ExtraDamage = 0,
                ExtraDamageCount = 0,
                AttackType1 = AttackType.Arcane,
                AttackType2 = AttackType.None,
                AttackMode = AttackMode.Normal,
                TricksterWeaponId = 14
            },
            
            new Attack {
                Id = 573,
                Name = "R1 (sidestep)",
                Damage = 0,
                ExtraDamage = 0,
                ExtraDamageCount = 0,
                AttackType1 = AttackType.Arcane,
                AttackType2 = AttackType.None,
                AttackMode = AttackMode.Normal,
                TricksterWeaponId = 14
            },
            
            new Attack {
                Id = 574,
                Name = "R1 (dash)",
                Damage = 1,
                ExtraDamage = 0,
                ExtraDamageCount = 0,
                AttackType1 = AttackType.Arcane,
                AttackType2 = AttackType.None,
                AttackMode = AttackMode.Normal,
                TricksterWeaponId = 14
            },
            
            new Attack {
                Id = 575,
                Name = "R2",
                Damage = 1,
                ExtraDamage = 0,
                ExtraDamageCount = 0,
                AttackType1 = AttackType.Arcane,
                AttackType2 = AttackType.None,
                AttackMode = AttackMode.Normal,
                TricksterWeaponId = 14
            },
            
            new Attack {
                Id = 576,
                Name = "R2 (charged)",
                Damage = 1,
                ExtraDamage = 0,
                ExtraDamageCount = 0,
                AttackType1 = AttackType.Arcane,
                AttackType2 = AttackType.None,
                AttackMode = AttackMode.Normal,
                TricksterWeaponId = 14
            },
            
            new Attack {
                Id = 577,
                Name = "R2 (backstep)",
                Damage = 1,
                ExtraDamage = 0,
                ExtraDamageCount = 0,
                AttackType1 = AttackType.Arcane,
                AttackType2 = AttackType.None,
                AttackMode = AttackMode.Normal,
                TricksterWeaponId = 14
            },
            
            new Attack {
                Id = 578,
                Name = "R2 (dash)",
                Damage = 1,
                ExtraDamage = 0,
                ExtraDamageCount = 0,
                AttackType1 = AttackType.Arcane,
                AttackType2 = AttackType.None,
                AttackMode = AttackMode.Normal,
                TricksterWeaponId = 14
            },
            
            new Attack {
                Id = 579,
                Name = "R2 (forward leap)",
                Damage = 1,
                ExtraDamage = 0,
                ExtraDamageCount = 0,
                AttackType1 = AttackType.Arcane,
                AttackType2 = AttackType.None,
                AttackMode = AttackMode.Normal,
                TricksterWeaponId = 14
            },
            
            new Attack {
                Id = 580,
                Name = "Transform Attack",
                Damage = 1,
                ExtraDamage = 0,
                ExtraDamageCount = 0,
                AttackType1 = AttackType.Arcane,
                AttackType2 = AttackType.None,
                AttackMode = AttackMode.Normal,
                TricksterWeaponId = 14
            },
            
            new Attack {
                Id = 581,
                Name = "Plunge Attack",
                Damage = 1,
                ExtraDamage = 0,
                ExtraDamageCount = 0,
                AttackType1 = AttackType.Arcane,
                AttackType2 = AttackType.None,
                AttackMode = AttackMode.Normal,
                TricksterWeaponId = 14
            },
            
            new Attack {
                Id = 582,
                Name = "Plunge Attack (2nd)",
                Damage = 1,
                ExtraDamage = 0,
                ExtraDamageCount = 0,
                AttackType1 = AttackType.Arcane,
                AttackType2 = AttackType.None,
                AttackMode = AttackMode.Normal,
                TricksterWeaponId = 14
            },
            
            new Attack {
                Id = 583,
                Name = "R1",
                Damage = 1,
                ExtraDamage = 0,
                ExtraDamageCount = 0,
                AttackType1 = AttackType.Arcane,
                AttackType2 = AttackType.None,
                AttackMode = AttackMode.Transformed,
                TricksterWeaponId = 14
            },
            
            new Attack {
                Id = 584,
                Name = "R1 (2nd)",
                Damage = 1,
                ExtraDamage = 0,
                ExtraDamageCount = 0,
                AttackType1 = AttackType.Arcane,
                AttackType2 = AttackType.None,
                AttackMode = AttackMode.Transformed,
                TricksterWeaponId = 14
            },
            
            new Attack {
                Id = 585,
                Name = "R1 (3rd)",
                Damage = 1,
                ExtraDamage = 0,
                ExtraDamageCount = 0,
                AttackType1 = AttackType.Arcane,
                AttackType2 = AttackType.None,
                AttackMode = AttackMode.Transformed,
                TricksterWeaponId = 14
            },
            
            new Attack {
                Id = 586,
                Name = "R1 (4th)",
                Damage = 1,
                ExtraDamage = 0,
                ExtraDamageCount = 0,
                AttackType1 = AttackType.Arcane,
                AttackType2 = AttackType.None,
                AttackMode = AttackMode.Transformed,
                TricksterWeaponId = 14
            },
            
            new Attack {
                Id = 587,
                Name = "R1 (5th)",
                Damage = 1,
                ExtraDamage = 0,
                ExtraDamageCount = 0,
                AttackType1 = AttackType.Arcane,
                AttackType2 = AttackType.None,
                AttackMode = AttackMode.Transformed,
                TricksterWeaponId = 14
            },
            
            new Attack {
                Id = 588,
                Name = "R1 (backstep)",
                Damage = 1,
                ExtraDamage = 0,
                ExtraDamageCount = 0,
                AttackType1 = AttackType.Arcane,
                AttackType2 = AttackType.None,
                AttackMode = AttackMode.Transformed,
                TricksterWeaponId = 14
            },

            new Attack {
                Id = 589,
                Name = "R1 (rolling)",
                Damage = 1,
                ExtraDamage = 0,
                ExtraDamageCount = 0,
                AttackType1 = AttackType.Arcane,
                AttackType2 = AttackType.None,
                AttackMode = AttackMode.Transformed,
                TricksterWeaponId = 14
            },
            
            new Attack {
                Id = 590,
                Name = "R1 (frontstep)",
                Damage = 1,
                ExtraDamage = 0,
                ExtraDamageCount = 0,
                AttackType1 = AttackType.Arcane,
                AttackType2 = AttackType.None,
                AttackMode = AttackMode.Transformed,
                TricksterWeaponId = 14
            },
            
            new Attack {
                Id = 591,
                Name = "R1 (sidestep)",
                Damage = 1,
                ExtraDamage = 0,
                ExtraDamageCount = 0,
                AttackType1 = AttackType.Arcane,
                AttackType2 = AttackType.None,
                AttackMode = AttackMode.Transformed,
                TricksterWeaponId = 14
            },
            
            new Attack {
                Id = 592,
                Name = "R1 (dash)",
                Damage = 1,
                ExtraDamage = 0,
                ExtraDamageCount = 0,
                AttackType1 = AttackType.Arcane,
                AttackType2 = AttackType.None,
                AttackMode = AttackMode.Transformed,
                TricksterWeaponId = 14
            },
            
            new Attack {
                Id = 593,
                Name = "R2",
                Damage = 1,
                ExtraDamage = 0,
                ExtraDamageCount = 0,
                AttackType1 = AttackType.Arcane,
                AttackType2 = AttackType.None,
                AttackMode = AttackMode.Transformed,
                TricksterWeaponId = 14
            },
            
            new Attack {
                Id = 594,
                Name = "R2 (charged)",
                Damage = 2,
                ExtraDamage = 0,
                ExtraDamageCount = 0,
                AttackType1 = AttackType.Arcane,
                AttackType2 = AttackType.None,
                AttackMode = AttackMode.Transformed,
                TricksterWeaponId = 14
            },
            
            new Attack {
                Id = 595,
                Name = "R2 (backstep)",
                Damage = 1,
                ExtraDamage = 0,
                ExtraDamageCount = 0,
                AttackType1 = AttackType.Arcane,
                AttackType2 = AttackType.None,
                AttackMode = AttackMode.Transformed,
                TricksterWeaponId = 14
            },
            
            new Attack {
                Id = 596,
                Name = "R2 (dash)",
                Damage = 1,
                ExtraDamage = 0,
                ExtraDamageCount = 0,
                AttackType1 = AttackType.Arcane,
                AttackType2 = AttackType.None,
                AttackMode = AttackMode.Transformed,
                TricksterWeaponId = 14
            },
            
            new Attack {
                Id = 597,
                Name = "R2 (forward leap)",
                Damage = 1,
                ExtraDamage = 0,
                ExtraDamageCount = 0,
                AttackType1 = AttackType.Arcane,
                AttackType2 = AttackType.None,
                AttackMode = AttackMode.Transformed,
                TricksterWeaponId = 14
            },
            
            new Attack {
                Id = 598,
                Name = "L2",
                Damage = 1,
                ExtraDamage = 0,
                ExtraDamageCount = 0,
                AttackType1 = AttackType.Arcane,
                AttackType2 = AttackType.None,
                AttackMode = AttackMode.Transformed,
                TricksterWeaponId = 14
            },
            
            new Attack {
                Id = 599,
                Name = "L2 (2nd)",
                Damage = 1,
                ExtraDamage = 0,
                ExtraDamageCount = 0,
                AttackType1 = AttackType.Arcane,
                AttackType2 = AttackType.None,
                AttackMode = AttackMode.Transformed,
                TricksterWeaponId = 14
            },
            
            new Attack {
                Id = 600,
                Name = "L2 (3rd)",
                Damage = 1,
                ExtraDamage = 0,
                ExtraDamageCount = 0,
                AttackType1 = AttackType.Arcane,
                AttackType2 = AttackType.None,
                AttackMode = AttackMode.Transformed,
                TricksterWeaponId = 14
            },
            
            new Attack {
                Id = 601,
                Name = "Transform Attack",
                Damage = 1,
                ExtraDamage = 0,
                ExtraDamageCount = 0,
                AttackType1 = AttackType.Arcane,
                AttackType2 = AttackType.None,
                AttackMode = AttackMode.Transformed,
                TricksterWeaponId = 14
            },
            
            new Attack {
                Id = 602,
                Name = "Plunge Attack",
                Damage = 1,
                ExtraDamage = 0,
                ExtraDamageCount = 0,
                AttackType1 = AttackType.Arcane,
                AttackType2 = AttackType.None,
                AttackMode = AttackMode.Transformed,
                TricksterWeaponId = 14
            },
            
            new Attack {
                Id = 603,
                Name = "Plunge Attack (2nd)",
                Damage = 1,
                ExtraDamage = 0,
                ExtraDamageCount = 0,
                AttackType1 = AttackType.Arcane,
                AttackType2 = AttackType.None,
                AttackMode = AttackMode.Transformed,
                TricksterWeaponId = 14
            },
            
            new Attack {
                Id = 604,
                Name = "R1",
                Damage = 1,
                ExtraDamage = 0,
                ExtraDamageCount = 0,
                AttackType1 = AttackType.Blunt,
                AttackType2 = AttackType.Arcane,
                AttackMode = AttackMode.Normal,
                TricksterWeaponId = 15
            },
            
            new Attack {
                Id = 605,
                Name = "R1 (2nd)",
                Damage = 1,
                ExtraDamage = 0,
                ExtraDamageCount = 0,
                AttackType1 = AttackType.Blunt,
                AttackType2 = AttackType.Arcane,
                AttackMode = AttackMode.Normal,
                TricksterWeaponId = 15
            },
            
            new Attack {
                Id = 606,
                Name = "R1 (3rd)",
                Damage = 1,
                ExtraDamage = 0,
                ExtraDamageCount = 0,
                AttackType1 = AttackType.Blunt,
                AttackType2 = AttackType.Arcane,
                AttackMode = AttackMode.Normal,
                TricksterWeaponId = 15
            },
            
            new Attack {
                Id = 607,
                Name = "R1 (backstep)",
                Damage = 0,
                ExtraDamage = 0,
                ExtraDamageCount = 0,
                AttackType1 = AttackType.Blunt,
                AttackType2 = AttackType.Arcane,
                AttackMode = AttackMode.Normal,
                TricksterWeaponId = 15
            },
            
            new Attack {
                Id = 608,
                Name = "R1 (rolling)",
                Damage = 0,
                ExtraDamage = 0,
                ExtraDamageCount = 0,
                AttackType1 = AttackType.Blunt,
                AttackType2 = AttackType.Arcane,
                AttackMode = AttackMode.Normal,
                TricksterWeaponId = 15
            },
            
            new Attack {
                Id = 609,
                Name = "R1 (frontstep)",
                Damage = 0,
                ExtraDamage = 0,
                ExtraDamageCount = 0,
                AttackType1 = AttackType.Blunt,
                AttackType2 = AttackType.Arcane,
                AttackMode = AttackMode.Normal,
                TricksterWeaponId = 15
            },
            
            new Attack {
                Id = 610,
                Name = "R1 (sidestep)",
                Damage = 0,
                ExtraDamage = 0,
                ExtraDamageCount = 0,
                AttackType1 = AttackType.Blunt,
                AttackType2 = AttackType.Arcane,
                AttackMode = AttackMode.Normal,
                TricksterWeaponId = 15
            },
            
            new Attack {
                Id = 611,
                Name = "R1 (dash)",
                Damage = 1,
                ExtraDamage = 0,
                ExtraDamageCount = 0,
                AttackType1 = AttackType.Blunt,
                AttackType2 = AttackType.Arcane,
                AttackMode = AttackMode.Normal,
                TricksterWeaponId = 15
            },
            
            new Attack {
                Id = 612,
                Name = "R2",
                Damage = 1,
                ExtraDamage = 0,
                ExtraDamageCount = 0,
                AttackType1 = AttackType.Blunt,
                AttackType2 = AttackType.Arcane,
                AttackMode = AttackMode.Normal,
                TricksterWeaponId = 15
            },
            
            new Attack {
                Id = 613,
                Name = "R2 (charged)",
                Damage = 1,
                ExtraDamage = 0,
                ExtraDamageCount = 0,
                AttackType1 = AttackType.Blunt,
                AttackType2 = AttackType.Arcane,
                AttackMode = AttackMode.Normal,
                TricksterWeaponId = 15
            },
            
            new Attack {
                Id = 614,
                Name = "R2 (backstep)",
                Damage = 1,
                ExtraDamage = 0,
                ExtraDamageCount = 0,
                AttackType1 = AttackType.Blunt,
                AttackType2 = AttackType.Arcane,
                AttackMode = AttackMode.Normal,
                TricksterWeaponId = 15
            },
            
            new Attack {
                Id = 615,
                Name = "R2 (dash)",
                Damage = 1,
                ExtraDamage = 0,
                ExtraDamageCount = 0,
                AttackType1 = AttackType.Blunt,
                AttackType2 = AttackType.Arcane,
                AttackMode = AttackMode.Normal,
                TricksterWeaponId = 15
            },
            
            new Attack {
                Id = 616,
                Name = "R2 (forward leap)",
                Damage = 1,
                ExtraDamage = 0,
                ExtraDamageCount = 0,
                AttackType1 = AttackType.Blunt,
                AttackType2 = AttackType.Arcane,
                AttackMode = AttackMode.Normal,
                TricksterWeaponId = 15
            },
            
            new Attack {
                Id = 617,
                Name = "Transform Attack",
                Damage = 0,
                ExtraDamage = 0,
                ExtraDamageCount = 3,
                AttackType1 = AttackType.Blunt,
                AttackType2 = AttackType.Arcane,
                AttackMode = AttackMode.Normal,
                TricksterWeaponId = 15
            },
            
            new Attack {
                Id = 618,
                Name = "Plunge Attack",
                Damage = 1,
                ExtraDamage = 0,
                ExtraDamageCount = 0,
                AttackType1 = AttackType.Blunt,
                AttackType2 = AttackType.Arcane,
                AttackMode = AttackMode.Normal,
                TricksterWeaponId = 15
            },
            
            new Attack {
                Id = 619,
                Name = "Plunge Attack (2nd)",
                Damage = 0,
                ExtraDamage = 0,
                ExtraDamageCount = 0,
                AttackType1 = AttackType.Blunt,
                AttackType2 = AttackType.Arcane,
                AttackMode = AttackMode.Normal,
                TricksterWeaponId = 15
            },
            
            new Attack {
                Id = 620,
                Name = "R1",
                Damage = 1,
                ExtraDamage = 0,
                ExtraDamageCount = 0,
                AttackType1 = AttackType.Blunt,
                AttackType2 = AttackType.Arcane,
                AttackMode = AttackMode.Transformed,
                TricksterWeaponId = 15
            },
            
            new Attack {
                Id = 621,
                Name = "R1 (2nd)",
                Damage = 1,
                ExtraDamage = 0,
                ExtraDamageCount = 0,
                AttackType1 = AttackType.Blunt,
                AttackType2 = AttackType.Arcane,
                AttackMode = AttackMode.Transformed,
                TricksterWeaponId = 15
            },
            
            new Attack {
                Id = 622,
                Name = "R1 (3rd)",
                Damage = 1,
                ExtraDamage = 0,
                ExtraDamageCount = 2,
                AttackType1 = AttackType.Blunt,
                AttackType2 = AttackType.Arcane,
                AttackMode = AttackMode.Transformed,
                TricksterWeaponId = 15
            },
            
            new Attack {
                Id = 623,
                Name = "R1 (4th)",
                Damage = 1,
                ExtraDamage = 0,
                ExtraDamageCount = 2,
                AttackType1 = AttackType.Blunt,
                AttackType2 = AttackType.Arcane,
                AttackMode = AttackMode.Transformed,
                TricksterWeaponId = 15
            },
            
            new Attack {
                Id = 624,
                Name = "R1 (5th)",
                Damage = 1,
                ExtraDamage = 0,
                ExtraDamageCount = 0,
                AttackType1 = AttackType.Blunt,
                AttackType2 = AttackType.Arcane,
                AttackMode = AttackMode.Transformed,
                TricksterWeaponId = 15
            },
            
            new Attack {
                Id = 625,
                Name = "R1 (backstep)",
                Damage = 0,
                ExtraDamage = 0,
                ExtraDamageCount = 0,
                AttackType1 = AttackType.Blunt,
                AttackType2 = AttackType.Arcane,
                AttackMode = AttackMode.Transformed,
                TricksterWeaponId = 15
            },
            
            new Attack {
                Id = 626,
                Name = "R1 (rolling)",
                Damage = 0,
                ExtraDamage = 0,
                ExtraDamageCount = 2,
                AttackType1 = AttackType.Blunt,
                AttackType2 = AttackType.Arcane,
                AttackMode = AttackMode.Transformed,
                TricksterWeaponId = 15
            },
            
            new Attack {
                Id = 627,
                Name = "R1 (frontstep)",
                Damage = 0,
                ExtraDamage = 0,
                ExtraDamageCount = 2,
                AttackType1 = AttackType.Blunt,
                AttackType2 = AttackType.Arcane,
                AttackMode = AttackMode.Transformed,
                TricksterWeaponId = 15
            },
            
            new Attack {
                Id = 628,
                Name = "R1 (sidestep)",
                Damage = 0,
                ExtraDamage = 0,
                ExtraDamageCount = 2,
                AttackType1 = AttackType.Blunt,
                AttackType2 = AttackType.Arcane,
                AttackMode = AttackMode.Transformed,
                TricksterWeaponId = 15
            },
            
            new Attack {
                Id = 629,
                Name = "R1 (dash)",
                Damage = 0,
                ExtraDamage = 0,
                ExtraDamageCount = 2,
                AttackType1 = AttackType.Blunt,
                AttackType2 = AttackType.Arcane,
                AttackMode = AttackMode.Transformed,
                TricksterWeaponId = 15
            },
            
            new Attack {
                Id = 630,
                Name = "R2",
                Damage = 1,
                ExtraDamage = 0,
                ExtraDamageCount = 2,
                AttackType1 = AttackType.Blunt,
                AttackType2 = AttackType.Arcane,
                AttackMode = AttackMode.Transformed,
                TricksterWeaponId = 15
            },
            
            new Attack {
                Id = 631,
                Name = "R2 (2nd)",
                Damage = 1,
                ExtraDamage = 0,
                ExtraDamageCount = 2,
                AttackType1 = AttackType.Blunt,
                AttackType2 = AttackType.Arcane,
                AttackMode = AttackMode.Transformed,
                TricksterWeaponId = 15
            },
            
            new Attack {
                Id = 632,
                Name = "R2 (3rd)",
                Damage = 1,
                ExtraDamage = 0,
                ExtraDamageCount = 2,
                AttackType1 = AttackType.Blunt,
                AttackType2 = AttackType.Arcane,
                AttackMode = AttackMode.Transformed,
                TricksterWeaponId = 15
            },
            
            new Attack {
                Id = 633,
                Name = "R2 (backstep)",
                Damage = 1,
                ExtraDamage = 0,
                ExtraDamageCount = 3,
                AttackType1 = AttackType.Blunt,
                AttackType2 = AttackType.Arcane,
                AttackMode = AttackMode.Transformed,
                TricksterWeaponId = 15
            },
            
            new Attack {
                Id = 634,
                Name = "R2 (dash)",
                Damage = 1,
                ExtraDamage = 0,
                ExtraDamageCount = 0,
                AttackType1 = AttackType.Blunt,
                AttackType2 = AttackType.Arcane,
                AttackMode = AttackMode.Transformed,
                TricksterWeaponId = 15
            },
            
            new Attack {
                Id = 635,
                Name = "R2 (forward leap)",
                Damage = 1,
                ExtraDamage = 0,
                ExtraDamageCount = 0,
                AttackType1 = AttackType.Blunt,
                AttackType2 = AttackType.Arcane,
                AttackMode = AttackMode.Transformed,
                TricksterWeaponId = 15
            },
            
            new Attack {
                Id = 636,
                Name = "Transform Attack",
                Damage = 0,
                ExtraDamage = 0,
                ExtraDamageCount = 0,
                AttackType1 = AttackType.Blunt,
                AttackType2 = AttackType.Arcane,
                AttackMode = AttackMode.Transformed,
                TricksterWeaponId = 15
            },
            
            new Attack {
                Id = 637,
                Name = "Plunge Attack",
                Damage = 1,
                ExtraDamage = 0,
                ExtraDamageCount = 0,
                AttackType1 = AttackType.Blunt,
                AttackType2 = AttackType.Arcane,
                AttackMode = AttackMode.Transformed,
                TricksterWeaponId = 15
            },
            
            new Attack {
                Id = 638,
                Name = "Plunge Attack (2nd)",
                Damage = 0,
                ExtraDamage = 0,
                ExtraDamageCount = 0,
                AttackType1 = AttackType.Blunt,
                AttackType2 = AttackType.Arcane,
                AttackMode = AttackMode.Transformed,
                TricksterWeaponId = 15
            },
            
            new Attack {
                Id = 639,
                Name = "R1",
                Damage = 0,
                ExtraDamage = 0,
                ExtraDamageCount = 0,
                AttackType1 = AttackType.Physical,
                AttackType2 = AttackType.None,
                AttackMode = AttackMode.Normal,
                TricksterWeaponId = 16
            },
            
            new Attack {
                Id = 640,
                Name = "R1 (2nd)",
                Damage = 0,
                ExtraDamage = 0,
                ExtraDamageCount = 0,
                AttackType1 = AttackType.Physical,
                AttackType2 = AttackType.None,
                AttackMode = AttackMode.Normal,
                TricksterWeaponId = 16
            },
            
            new Attack {
                Id = 641,
                Name = "R1 (3rd)",
                Damage = 0,
                ExtraDamage = 0,
                ExtraDamageCount = 0,
                AttackType1 = AttackType.Physical,
                AttackType2 = AttackType.None,
                AttackMode = AttackMode.Normal,
                TricksterWeaponId = 16
            },
            
            new Attack {
                Id = 642,
                Name = "R1 (4th)",
                Damage = 0,
                ExtraDamage = 0,
                ExtraDamageCount = 0,
                AttackType1 = AttackType.Thrust,
                AttackType2 = AttackType.None,
                AttackMode = AttackMode.Normal,
                TricksterWeaponId = 16
            },
            
            new Attack {
                Id = 643,
                Name = "R1 (5th)",
                Damage = 0,
                ExtraDamage = 0,
                ExtraDamageCount = 0,
                AttackType1 = AttackType.Physical,
                AttackType2 = AttackType.None,
                AttackMode = AttackMode.Normal,
                TricksterWeaponId = 16
            },
            
            new Attack {
                Id = 644,
                Name = "R1 (backstep)",
                Damage = 0,
                ExtraDamage = 0,
                ExtraDamageCount = 0,
                AttackType1 = AttackType.Physical,
                AttackType2 = AttackType.None,
                AttackMode = AttackMode.Normal,
                TricksterWeaponId = 16
            },
            
            new Attack {
                Id = 645,
                Name = "R1 (rolling)",
                Damage = 0,
                ExtraDamage = 0,
                ExtraDamageCount = 0,
                AttackType1 = AttackType.Physical,
                AttackType2 = AttackType.None,
                AttackMode = AttackMode.Normal,
                TricksterWeaponId = 16
            },
            
            new Attack {
                Id = 646,
                Name = "R1 (frontstep)",
                Damage = 0,
                ExtraDamage = 0,
                ExtraDamageCount = 0,
                AttackType1 = AttackType.Physical,
                AttackType2 = AttackType.None,
                AttackMode = AttackMode.Normal,
                TricksterWeaponId = 16
            },
            
            new Attack {
                Id = 647,
                Name = "R1 (sidestep)",
                Damage = 0,
                ExtraDamage = 0,
                ExtraDamageCount = 0,
                AttackType1 = AttackType.Physical,
                AttackType2 = AttackType.None,
                AttackMode = AttackMode.Normal,
                TricksterWeaponId = 16
            },
            
            new Attack {
                Id = 648,
                Name = "R1 (dash)",
                Damage = 0,
                ExtraDamage = 0,
                ExtraDamageCount = 0,
                AttackType1 = AttackType.Physical,
                AttackType2 = AttackType.None,
                AttackMode = AttackMode.Normal,
                TricksterWeaponId = 16
            },
            
            new Attack {
                Id = 649,
                Name = "R2",
                Damage = 1,
                ExtraDamage = 0,
                ExtraDamageCount = 0,
                AttackType1 = AttackType.Thrust,
                AttackType2 = AttackType.None,
                AttackMode = AttackMode.Normal,
                TricksterWeaponId = 16
            },
            
            new Attack {
                Id = 650,
                Name = "R2 (charged)",
                Damage = 1,
                ExtraDamage = 0,
                ExtraDamageCount = 0,
                AttackType1 = AttackType.Thrust,
                AttackType2 = AttackType.None,
                AttackMode = AttackMode.Normal,
                TricksterWeaponId = 16
            },
            
            new Attack {
                Id = 651,
                Name = "R2 (backstep)",
                Damage = 0,
                ExtraDamage = 0,
                ExtraDamageCount = 0,
                AttackType1 = AttackType.Thrust,
                AttackType2 = AttackType.None,
                AttackMode = AttackMode.Normal,
                TricksterWeaponId = 16
            },
            
            new Attack {
                Id = 652,
                Name = "R2 (dash)",
                Damage = 0,
                ExtraDamage = 0,
                ExtraDamageCount = 0,
                AttackType1 = AttackType.Thrust,
                AttackType2 = AttackType.None,
                AttackMode = AttackMode.Normal,
                TricksterWeaponId = 16
            },
            
            new Attack {
                Id = 653,
                Name = "R2 (forward leap)",
                Damage = 1,
                ExtraDamage = 0,
                ExtraDamageCount = 0,
                AttackType1 = AttackType.Thrust,
                AttackType2 = AttackType.None,
                AttackMode = AttackMode.Normal,
                TricksterWeaponId = 16
            },
            
            new Attack {
                Id = 654,
                Name = "Transform Attack",
                Damage = 1,
                ExtraDamage = 0,
                ExtraDamageCount = 0,
                AttackType1 = AttackType.Blunt,
                AttackType2 = AttackType.None,
                AttackMode = AttackMode.Normal,
                TricksterWeaponId = 16
            },
            
            new Attack {
                Id = 655,
                Name = "Transform Attack to R1",
                Damage = 0,
                ExtraDamage = 0,
                ExtraDamageCount = 0,
                AttackType1 = AttackType.Physical,
                AttackType2 = AttackType.None,
                AttackMode = AttackMode.Normal,
                TricksterWeaponId = 16
            },
            
            new Attack {
                Id = 656,
                Name = "Plunge Attack",
                Damage = 1,
                ExtraDamage = 0,
                ExtraDamageCount = 0,
                AttackType1 = AttackType.Thrust,
                AttackType2 = AttackType.None,
                AttackMode = AttackMode.Normal,
                TricksterWeaponId = 16
            },
            
            new Attack {
                Id = 657,
                Name = "Plunge Attack (2nd)",
                Damage = 0,
                ExtraDamage = 0,
                ExtraDamageCount = 0,
                AttackType1 = AttackType.Blunt,
                AttackType2 = AttackType.None,
                AttackMode = AttackMode.Normal,
                TricksterWeaponId = 16
            },
            
            new Attack {
                Id = 658,
                Name = "R1",
                Damage = 1,
                ExtraDamage = 0,
                ExtraDamageCount = 0,
                AttackType1 = AttackType.Blunt,
                AttackType2 = AttackType.None,
                AttackMode = AttackMode.Transformed,
                TricksterWeaponId = 16
            },
            
            new Attack {
                Id = 659,
                Name = "R1 (2nd)",
                Damage = 1,
                ExtraDamage = 0,
                ExtraDamageCount = 0,
                AttackType1 = AttackType.Blunt,
                AttackType2 = AttackType.None,
                AttackMode = AttackMode.Transformed,
                TricksterWeaponId = 16
            },
            
            new Attack {
                Id = 660,
                Name = "R1 (3rd)",
                Damage = 1,
                ExtraDamage = 0,
                ExtraDamageCount = 0,
                AttackType1 = AttackType.Blunt,
                AttackType2 = AttackType.None,
                AttackMode = AttackMode.Transformed,
                TricksterWeaponId = 16
            },
            
            new Attack {
                Id = 661,
                Name = "R1 (4th)",
                Damage = 1,
                ExtraDamage = 0,
                ExtraDamageCount = 0,
                AttackType1 = AttackType.Blunt,
                AttackType2 = AttackType.None,
                AttackMode = AttackMode.Transformed,
                TricksterWeaponId = 16
            },
            
            new Attack {
                Id = 662,
                Name = "R1 (backstep)",
                Damage = 0,
                ExtraDamage = 0,
                ExtraDamageCount = 0,
                AttackType1 = AttackType.Blunt,
                AttackType2 = AttackType.None,
                AttackMode = AttackMode.Transformed,
                TricksterWeaponId = 16
            },
            
            new Attack {
                Id = 663,
                Name = "R1 (rolling)",
                Damage = 0,
                ExtraDamage = 0,
                ExtraDamageCount = 0,
                AttackType1 = AttackType.Blunt,
                AttackType2 = AttackType.None,
                AttackMode = AttackMode.Transformed,
                TricksterWeaponId = 16
            },
            
            new Attack {
                Id = 664,
                Name = "R1 (frontstep)",
                Damage = 0,
                ExtraDamage = 0,
                ExtraDamageCount = 0,
                AttackType1 = AttackType.Blunt,
                AttackType2 = AttackType.None,
                AttackMode = AttackMode.Transformed,
                TricksterWeaponId = 16
            },
            
            new Attack {
                Id = 665,
                Name = "R1 (sidestep)",
                Damage = 0,
                ExtraDamage = 0,
                ExtraDamageCount = 0,
                AttackType1 = AttackType.Blunt,
                AttackType2 = AttackType.None,
                AttackMode = AttackMode.Transformed,
                TricksterWeaponId = 16
            },
            
            new Attack {
                Id = 666,
                Name = "R1 (dash)",
                Damage = 1,
                ExtraDamage = 0,
                ExtraDamageCount = 0,
                AttackType1 = AttackType.Blunt,
                AttackType2 = AttackType.None,
                AttackMode = AttackMode.Transformed,
                TricksterWeaponId = 16
            },
            
            new Attack {
                Id = 667,
                Name = "R2",
                Damage = 1,
                ExtraDamage = 0,
                ExtraDamageCount = 0,
                AttackType1 = AttackType.Thrust,
                AttackType2 = AttackType.None,
                AttackMode = AttackMode.Transformed,
                TricksterWeaponId = 16
            },
            
            new Attack {
                Id = 668,
                Name = "R2 (charged)",
                Damage = 2,
                ExtraDamage = 0,
                ExtraDamageCount = 0,
                AttackType1 = AttackType.Thrust,
                AttackType2 = AttackType.None,
                AttackMode = AttackMode.Transformed,
                TricksterWeaponId = 16
            },
            
            new Attack {
                Id = 669,
                Name = "R2 (charged follow-up)",
                Damage = 1,
                ExtraDamage = 0,
                ExtraDamageCount = 0,
                AttackType1 = AttackType.Blunt,
                AttackType2 = AttackType.None,
                AttackMode = AttackMode.Transformed,
                TricksterWeaponId = 16
            },
            
            new Attack {
                Id = 670,
                Name = "R2 (backstep)",
                Damage = 1,
                ExtraDamage = 0,
                ExtraDamageCount = 0,
                AttackType1 = AttackType.Blunt,
                AttackType2 = AttackType.None,
                AttackMode = AttackMode.Transformed,
                TricksterWeaponId = 16
            },
            
            new Attack {
                Id = 671,
                Name = "R2 (dash)",
                Damage = 1,
                ExtraDamage = 0,
                ExtraDamageCount = 0,
                AttackType1 = AttackType.Blunt,
                AttackType2 = AttackType.None,
                AttackMode = AttackMode.Transformed,
                TricksterWeaponId = 16
            },
            
            new Attack {
                Id = 672,
                Name = "R2(forward leap)",
                Damage = 1,
                ExtraDamage = 0,
                ExtraDamageCount = 0,
                AttackType1 = AttackType.Blunt,
                AttackType2 = AttackType.None,
                AttackMode = AttackMode.Transformed,
                TricksterWeaponId = 16
            },

            new Attack {
                Id = 673,
                Name = "L2",
                Damage = 1,
                ExtraDamage = 0,
                ExtraDamageCount = 0,
                AttackType1 = AttackType.Blunt,
                AttackType2 = AttackType.None,
                AttackMode = AttackMode.Transformed,
                TricksterWeaponId = 16
            },
            
            new Attack {
                Id = 674,
                Name = "L2 (2nd)",
                Damage = 1,
                ExtraDamage = 0,
                ExtraDamageCount = 0,
                AttackType1 = AttackType.Blunt,
                AttackType2 = AttackType.None,
                AttackMode = AttackMode.Transformed,
                TricksterWeaponId = 16
            },
            
            new Attack {
                Id = 675,
                Name = "L2 (3rd)",
                Damage = 1,
                ExtraDamage = 0,
                ExtraDamageCount = 0,
                AttackType1 = AttackType.Blunt,
                AttackType2 = AttackType.None,
                AttackMode = AttackMode.Transformed,
                TricksterWeaponId = 16
            },
            
            new Attack {
                Id = 676,
                Name = "L2 (4th)",
                Damage = 1,
                ExtraDamage = 0,
                ExtraDamageCount = 0,
                AttackType1 = AttackType.Thrust,
                AttackType2 = AttackType.None,
                AttackMode = AttackMode.Transformed,
                TricksterWeaponId = 16
            },
            
            new Attack {
                Id = 677,
                Name = "Transform Attack",
                Damage = 1,
                ExtraDamage = 0,
                ExtraDamageCount = 0,
                AttackType1 = AttackType.Blunt,
                AttackType2 = AttackType.None,
                AttackMode = AttackMode.Transformed,
                TricksterWeaponId = 16
            },
            
            new Attack {
                Id = 678,
                Name = "Transform Attack to R1",
                Damage = 0,
                ExtraDamage = 0,
                ExtraDamageCount = 0,
                AttackType1 = AttackType.Blunt,
                AttackType2 = AttackType.None,
                AttackMode = AttackMode.Transformed,
                TricksterWeaponId = 16
            },
            
            new Attack {
                Id = 679,
                Name = "Plunge Attack",
                Damage = 1,
                ExtraDamage = 0,
                ExtraDamageCount = 0,
                AttackType1 = AttackType.Blunt,
                AttackType2 = AttackType.None,
                AttackMode = AttackMode.Transformed,
                TricksterWeaponId = 16
            },
            
            new Attack {
                Id = 680,
                Name = "Plunge Attack (2nd)",
                Damage = 0,
                ExtraDamage = 0,
                ExtraDamageCount = 0,
                AttackType1 = AttackType.Blunt,
                AttackType2 = AttackType.None,
                AttackMode = AttackMode.Transformed,
                TricksterWeaponId = 16
            },
            
            new Attack {
                Id = 681,
                Name = "R1",
                Damage = 1,
                ExtraDamage = 0,
                ExtraDamageCount = 0,
                AttackType1 = AttackType.Physical,
                AttackType2 = AttackType.None,
                AttackMode = AttackMode.Normal,
                TricksterWeaponId = 17
            },
            
            new Attack {
                Id = 682,
                Name = "R1 (2nd)",
                Damage = 0,
                ExtraDamage = 0,
                ExtraDamageCount = 0,
                AttackType1 = AttackType.Thrust,
                AttackType2 = AttackType.None,
                AttackMode = AttackMode.Normal,
                TricksterWeaponId = 17
            },
            
            new Attack {
                Id = 683,
                Name = "R1 (3rd)",
                Damage = 1,
                ExtraDamage = 0,
                ExtraDamageCount = 0,
                AttackType1 = AttackType.Physical,
                AttackType2 = AttackType.None,
                AttackMode = AttackMode.Normal,
                TricksterWeaponId = 17
            },
            
            new Attack {
                Id = 684,
                Name = "R1 (4th)",
                Damage = 1,
                ExtraDamage = 0,
                ExtraDamageCount = 0,
                AttackType1 = AttackType.Thrust,
                AttackType2 = AttackType.None,
                AttackMode = AttackMode.Normal,
                TricksterWeaponId = 17
            },
            
            new Attack {
                Id = 685,
                Name = "R1 (backstep)",
                Damage = 0,
                ExtraDamage = 0,
                ExtraDamageCount = 0,
                AttackType1 = AttackType.Physical,
                AttackType2 = AttackType.None,
                AttackMode = AttackMode.Normal,
                TricksterWeaponId = 17
            },
            
            new Attack {
                Id = 686,
                Name = "R1 (rolling)",
                Damage = 0,
                ExtraDamage = 0,
                ExtraDamageCount = 0,
                AttackType1 = AttackType.Physical,
                AttackType2 = AttackType.None,
                AttackMode = AttackMode.Normal,
                TricksterWeaponId = 17
            },
            
            new Attack {
                Id = 687,
                Name = "R1 (frontstep)",
                Damage = 0,
                ExtraDamage = 0,
                ExtraDamageCount = 0,
                AttackType1 = AttackType.Physical,
                AttackType2 = AttackType.None,
                AttackMode = AttackMode.Normal,
                TricksterWeaponId = 17
            },
            
            new Attack {
                Id = 688,
                Name = "R1 (sidestep)",
                Damage = 0,
                ExtraDamage = 0,
                ExtraDamageCount = 0,
                AttackType1 = AttackType.Physical,
                AttackType2 = AttackType.None,
                AttackMode = AttackMode.Normal,
                TricksterWeaponId = 17
            },
            
            new Attack {
                Id = 689,
                Name = "R1 (dash)",
                Damage = 1,
                ExtraDamage = 0,
                ExtraDamageCount = 0,
                AttackType1 = AttackType.Physical,
                AttackType2 = AttackType.None,
                AttackMode = AttackMode.Normal,
                TricksterWeaponId = 17
            },
            
            new Attack {
                Id = 690,
                Name = "R2",
                Damage = 1,
                ExtraDamage = 0,
                ExtraDamageCount = 0,
                AttackType1 = AttackType.Physical,
                AttackType2 = AttackType.None,
                AttackMode = AttackMode.Normal,
                TricksterWeaponId = 17
            },
            
            new Attack {
                Id = 691,
                Name = "R2 (charged)",
                Damage = 1,
                ExtraDamage = 0,
                ExtraDamageCount = 0,
                AttackType1 = AttackType.Thrust,
                AttackType2 = AttackType.None,
                AttackMode = AttackMode.Normal,
                TricksterWeaponId = 17
            },
            
            new Attack {
                Id = 692,
                Name = "R2 (backstep)",
                Damage = 1,
                ExtraDamage = 0,
                ExtraDamageCount = 0,
                AttackType1 = AttackType.Thrust,
                AttackType2 = AttackType.None,
                AttackMode = AttackMode.Normal,
                TricksterWeaponId = 17
            },
            
            new Attack {
                Id = 693,
                Name = "R2 (dash)",
                Damage = 1,
                ExtraDamage = 0,
                ExtraDamageCount = 0,
                AttackType1 = AttackType.Thrust,
                AttackType2 = AttackType.None,
                AttackMode = AttackMode.Normal,
                TricksterWeaponId = 17
            },
            
            new Attack {
                Id = 694,
                Name = "R2 (forward leap)",
                Damage = 1,
                ExtraDamage = 0,
                ExtraDamageCount = 0,
                AttackType1 = AttackType.Physical,
                AttackType2 = AttackType.None,
                AttackMode = AttackMode.Normal,
                TricksterWeaponId = 17
            },
            
            new Attack {
                Id = 695,
                Name = "Transform Attack",
                Damage = 1,
                ExtraDamage = 0,
                ExtraDamageCount = 0,
                AttackType1 = AttackType.Physical,
                AttackType2 = AttackType.None,
                AttackMode = AttackMode.Normal,
                TricksterWeaponId = 17
            },
            
            new Attack {
                Id = 696,
                Name = "Plunge Attack",
                Damage = 1,
                ExtraDamage = 0,
                ExtraDamageCount = 0,
                AttackType1 = AttackType.Physical,
                AttackType2 = AttackType.None,
                AttackMode = AttackMode.Normal,
                TricksterWeaponId = 17
            },
            
            new Attack {
                Id = 697,
                Name = "Plunge Attack (2nd)",
                Damage = 0,
                ExtraDamage = 0,
                ExtraDamageCount = 0,
                AttackType1 = AttackType.Blunt,
                AttackType2 = AttackType.None,
                AttackMode = AttackMode.Normal,
                TricksterWeaponId = 17
            },
            
            new Attack {
                Id = 698,
                Name = "R1",
                Damage = 1,
                ExtraDamage = 0,
                ExtraDamageCount = 0,
                AttackType1 = AttackType.Physical,
                AttackType2 = AttackType.None,
                AttackMode = AttackMode.Transformed,
                TricksterWeaponId = 17
            },
            
            new Attack {
                Id = 699,
                Name = "R1 (2nd)",
                Damage = 1,
                ExtraDamage = 0,
                ExtraDamageCount = 0,
                AttackType1 = AttackType.Physical,
                AttackType2 = AttackType.None,
                AttackMode = AttackMode.Transformed,
                TricksterWeaponId = 17
            },
            
            new Attack {
                Id = 700,
                Name = "R1 (3rd)",
                Damage = 1,
                ExtraDamage = 0,
                ExtraDamageCount = 0,
                AttackType1 = AttackType.Physical,
                AttackType2 = AttackType.None,
                AttackMode = AttackMode.Transformed,
                TricksterWeaponId = 17
            },
            
            new Attack {
                Id = 701,
                Name = "R1 (4th)",
                Damage = 1,
                ExtraDamage = 0,
                ExtraDamageCount = 0,
                AttackType1 = AttackType.Physical,
                AttackType2 = AttackType.None,
                AttackMode = AttackMode.Transformed,
                TricksterWeaponId = 17
            },
            
            new Attack {
                Id = 702,
                Name = "R1 to L2",
                Damage = 1,
                ExtraDamage = 0,
                ExtraDamageCount = 0,
                AttackType1 = AttackType.Physical,
                AttackType2 = AttackType.None,
                AttackMode = AttackMode.Transformed,
                TricksterWeaponId = 17
            },
            
            new Attack {
                Id = 703,
                Name = "R1 (backstep)",
                Damage = 0,
                ExtraDamage = 0,
                ExtraDamageCount = 0,
                AttackType1 = AttackType.Physical,
                AttackType2 = AttackType.None,
                AttackMode = AttackMode.Transformed,
                TricksterWeaponId = 17
            },
            
            new Attack {
                Id = 704,
                Name = "R1 (rolling)",
                Damage = 0,
                ExtraDamage = 0,
                ExtraDamageCount = 0,
                AttackType1 = AttackType.Physical,
                AttackType2 = AttackType.None,
                AttackMode = AttackMode.Transformed,
                TricksterWeaponId = 17
            },
            
            new Attack {
                Id = 705,
                Name = "R1 (frontstep)",
                Damage = 0,
                ExtraDamage = 0,
                ExtraDamageCount = 0,
                AttackType1 = AttackType.Physical,
                AttackType2 = AttackType.None,
                AttackMode = AttackMode.Transformed,
                TricksterWeaponId = 17
            },
            
            new Attack {
                Id = 706,
                Name = "R1 (sidestep)",
                Damage = 0,
                ExtraDamage = 0,
                ExtraDamageCount = 0,
                AttackType1 = AttackType.Physical,
                AttackType2 = AttackType.None,
                AttackMode = AttackMode.Transformed,
                TricksterWeaponId = 17
            },
            
            new Attack {
                Id = 707,
                Name = "R1 (dash)",
                Damage = 1,
                ExtraDamage = 0,
                ExtraDamageCount = 0,
                AttackType1 = AttackType.Physical,
                AttackType2 = AttackType.None,
                AttackMode = AttackMode.Transformed,
                TricksterWeaponId = 17
            },
            
            new Attack {
                Id = 708,
                Name = "R2",
                Damage = 0,
                ExtraDamage = 0,
                ExtraDamageCount = 0,
                AttackType1 = AttackType.Thrust,
                AttackType2 = AttackType.None,
                AttackMode = AttackMode.Transformed,
                TricksterWeaponId = 17
            },
            
            new Attack {
                Id = 709,
                Name = "R2 (2nd)",
                Damage = 0,
                ExtraDamage = 0,
                ExtraDamageCount = 0,
                AttackType1 = AttackType.Thrust,
                AttackType2 = AttackType.None,
                AttackMode = AttackMode.Transformed,
                TricksterWeaponId = 17
            },
            
            new Attack {
                Id = 710,
                Name = "R2 to L2",
                Damage = 1,
                ExtraDamage = 0,
                ExtraDamageCount = 0,
                AttackType1 = AttackType.Thrust,
                AttackType2 = AttackType.None,
                AttackMode = AttackMode.Transformed,
                TricksterWeaponId = 17
            },
            
            new Attack {
                Id = 711,
                Name = "R2 (backstep)",
                Damage = 1,
                ExtraDamage = 0,
                ExtraDamageCount = 0,
                AttackType1 = AttackType.Thrust,
                AttackType2 = AttackType.None,
                AttackMode = AttackMode.Transformed,
                TricksterWeaponId = 17
            },
            
            new Attack {
                Id = 712,
                Name = "R2 (dash)",
                Damage = 1,
                ExtraDamage = 0,
                ExtraDamageCount = 0,
                AttackType1 = AttackType.Thrust,
                AttackType2 = AttackType.None,
                AttackMode = AttackMode.Transformed,
                TricksterWeaponId = 17
            },
            
            new Attack {
                Id = 713,
                Name = "R2 (forward leap)",
                Damage = 1,
                ExtraDamage = 0,
                ExtraDamageCount = 0,
                AttackType1 = AttackType.Physical,
                AttackType2 = AttackType.None,
                AttackMode = AttackMode.Transformed,
                TricksterWeaponId = 17
            },
            
            new Attack {
                Id = 714,
                Name = "L2",
                Damage = 0,
                ExtraDamage = 1,
                ExtraDamageCount = 1,
                AttackType1 = AttackType.Physical,
                AttackType2 = AttackType.None,
                AttackMode = AttackMode.Transformed,
                TricksterWeaponId = 17
            },
            
            new Attack {
                Id = 715,
                Name = "L2 (2nd)",
                Damage = 1,
                ExtraDamage = 1,
                ExtraDamageCount = 1,
                AttackType1 = AttackType.Physical,
                AttackType2 = AttackType.None,
                AttackMode = AttackMode.Transformed,
                TricksterWeaponId = 17
            },
            
            new Attack {
                Id = 716,
                Name = "Transform Attack",
                Damage = 1,
                ExtraDamage = 0,
                ExtraDamageCount = 0,
                AttackType1 = AttackType.Thrust,
                AttackType2 = AttackType.None,
                AttackMode = AttackMode.Transformed,
                TricksterWeaponId = 17
            },
            
            new Attack {
                Id = 717,
                Name = "Plunge Attack",
                Damage = 1,
                ExtraDamage = 0,
                ExtraDamageCount = 0,
                AttackType1 = AttackType.Physical,
                AttackType2 = AttackType.None,
                AttackMode = AttackMode.Transformed,
                TricksterWeaponId = 17
            },
            
            new Attack {
                Id = 718,
                Name = "Plunge Attack (2nd)",
                Damage = 0,
                ExtraDamage = 0,
                ExtraDamageCount = 0,
                AttackType1 = AttackType.Blunt,
                AttackType2 = AttackType.None,
                AttackMode = AttackMode.Transformed,
                TricksterWeaponId = 17
            },
            
            new Attack {
                Id = 719,
                Name = "R1",
                Damage = 1,
                ExtraDamage = 0,
                ExtraDamageCount = 0,
                AttackType1 = AttackType.Thrust,
                AttackType2 = AttackType.None,
                AttackMode = AttackMode.Normal,
                TricksterWeaponId = 18
            },
            
            new Attack {
                Id = 720,
                Name = "R1 (2nd)",
                Damage = 1,
                ExtraDamage = 0,
                ExtraDamageCount = 0,
                AttackType1 = AttackType.Physical,
                AttackType2 = AttackType.None,
                AttackMode = AttackMode.Normal,
                TricksterWeaponId = 18
            },
            
            new Attack {
                Id = 721,
                Name = "R1 (3rd)",
                Damage = 1,
                ExtraDamage = 0,
                ExtraDamageCount = 0,
                AttackType1 = AttackType.Thrust,
                AttackType2 = AttackType.None,
                AttackMode = AttackMode.Normal,
                TricksterWeaponId = 18
            },
            
            new Attack {
                Id = 722,
                Name = "R1 (4th)",
                Damage = 1,
                ExtraDamage = 0,
                ExtraDamageCount = 0,
                AttackType1 = AttackType.Physical,
                AttackType2 = AttackType.None,
                AttackMode = AttackMode.Normal,
                TricksterWeaponId = 18
            },
            
            new Attack {
                Id = 723,
                Name = "R1 (backstep)",
                Damage = 0,
                ExtraDamage = 0,
                ExtraDamageCount = 0,
                AttackType1 = AttackType.Physical,
                AttackType2 = AttackType.None,
                AttackMode = AttackMode.Normal,
                TricksterWeaponId = 18
            },
            
            new Attack {
                Id = 724,
                Name = "R1 (rolling)",
                Damage = 0,
                ExtraDamage = 0,
                ExtraDamageCount = 0,
                AttackType1 = AttackType.Physical,
                AttackType2 = AttackType.None,
                AttackMode = AttackMode.Normal,
                TricksterWeaponId = 18
            },
            
            new Attack {
                Id = 725,
                Name = "R1 (frontstep)",
                Damage = 0,
                ExtraDamage = 0,
                ExtraDamageCount = 0,
                AttackType1 = AttackType.Physical,
                AttackType2 = AttackType.None,
                AttackMode = AttackMode.Normal,
                TricksterWeaponId = 18
            },
            
            new Attack {
                Id = 726,
                Name = "R1 (sidestep)",
                Damage = 0,
                ExtraDamage = 0,
                ExtraDamageCount = 0,
                AttackType1 = AttackType.Physical,
                AttackType2 = AttackType.None,
                AttackMode = AttackMode.Normal,
                TricksterWeaponId = 18
            },
            
            new Attack {
                Id = 727,
                Name = "R1 (dash)",
                Damage = 1,
                ExtraDamage = 0,
                ExtraDamageCount = 0,
                AttackType1 = AttackType.Physical,
                AttackType2 = AttackType.None,
                AttackMode = AttackMode.Normal,
                TricksterWeaponId = 18
            },
            
            new Attack {
                Id = 728,
                Name = "R2",
                Damage = 1,
                ExtraDamage = 0,
                ExtraDamageCount = 0,
                AttackType1 = AttackType.Physical,
                AttackType2 = AttackType.None,
                AttackMode = AttackMode.Normal,
                TricksterWeaponId = 18
            },
            
            new Attack {
                Id = 729,
                Name = "R2 (charged)",
                Damage = 1,
                ExtraDamage = 0,
                ExtraDamageCount = 0,
                AttackType1 = AttackType.Thrust,
                AttackType2 = AttackType.None,
                AttackMode = AttackMode.Normal,
                TricksterWeaponId = 18
            },
            
            new Attack {
                Id = 730,
                Name = "R2 (backstep)",
                Damage = 1,
                ExtraDamage = 0,
                ExtraDamageCount = 0,
                AttackType1 = AttackType.Thrust,
                AttackType2 = AttackType.None,
                AttackMode = AttackMode.Normal,
                TricksterWeaponId = 18
            },
            
            new Attack {
                Id = 731,
                Name = "R2 (dash)",
                Damage = 1,
                ExtraDamage = 0,
                ExtraDamageCount = 0,
                AttackType1 = AttackType.Thrust,
                AttackType2 = AttackType.None,
                AttackMode = AttackMode.Normal,
                TricksterWeaponId = 18
            },
            
            new Attack {
                Id = 732,
                Name = "R2 (forward leap)",
                Damage = 1,
                ExtraDamage = 0,
                ExtraDamageCount = 0,
                AttackType1 = AttackType.Thrust,
                AttackType2 = AttackType.None,
                AttackMode = AttackMode.Normal,
                TricksterWeaponId = 18
            },
            
            new Attack {
                Id = 733,
                Name = "Transform Attack",
                Damage = 1,
                ExtraDamage = 0,
                ExtraDamageCount = 0,
                AttackType1 = AttackType.Blood,
                AttackType2 = AttackType.None,
                AttackMode = AttackMode.Normal,
                TricksterWeaponId = 18
            },
            
            new Attack {
                Id = 734,
                Name = "Plunge Attack",
                Damage = 1,
                ExtraDamage = 0,
                ExtraDamageCount = 0,
                AttackType1 = AttackType.Physical,
                AttackType2 = AttackType.None,
                AttackMode = AttackMode.Normal,
                TricksterWeaponId = 18
            },
            
            new Attack {
                Id = 735,
                Name = "Plunge Attack (2nd)",
                Damage = 0,
                ExtraDamage = 0,
                ExtraDamageCount = 0,
                AttackType1 = AttackType.Blunt,
                AttackType2 = AttackType.None,
                AttackMode = AttackMode.Normal,
                TricksterWeaponId = 18
            },
            
            new Attack {
                Id = 736,
                Name = "R1",
                Damage = 0,
                ExtraDamage = 0,
                ExtraDamageCount = 0,
                AttackType1 = AttackType.Physical,
                AttackType2 = AttackType.None,
                AttackMode = AttackMode.Transformed,
                TricksterWeaponId = 18
            },
            
            new Attack {
                Id = 737,
                Name = "R1 (2nd)",
                Damage = 0,
                ExtraDamage = 0,
                ExtraDamageCount = 0,
                AttackType1 = AttackType.Physical,
                AttackType2 = AttackType.None,
                AttackMode = AttackMode.Transformed,
                TricksterWeaponId = 18
            },
            
            new Attack {
                Id = 738,
                Name = "R1 (3rd)",
                Damage = 0,
                ExtraDamage = 0,
                ExtraDamageCount = 0,
                AttackType1 = AttackType.Physical,
                AttackType2 = AttackType.None,
                AttackMode = AttackMode.Transformed,
                TricksterWeaponId = 18
            },
            
            new Attack {
                Id = 739,
                Name = "R1 (backstep)",
                Damage = 0,
                ExtraDamage = 0,
                ExtraDamageCount = 0,
                AttackType1 = AttackType.Physical,
                AttackType2 = AttackType.None,
                AttackMode = AttackMode.Transformed,
                TricksterWeaponId = 18
            },
            
            new Attack {
                Id = 740,
                Name = "R1 (rolling)",
                Damage = 0,
                ExtraDamage = 0,
                ExtraDamageCount = 0,
                AttackType1 = AttackType.Thrust,
                AttackType2 = AttackType.None,
                AttackMode = AttackMode.Transformed,
                TricksterWeaponId = 18
            },
            
            new Attack {
                Id = 741,
                Name = "R1 (frontstep)",
                Damage = 0,
                ExtraDamage = 0,
                ExtraDamageCount = 0,
                AttackType1 = AttackType.Thrust,
                AttackType2 = AttackType.None,
                AttackMode = AttackMode.Transformed,
                TricksterWeaponId = 18
            },
            
            new Attack {
                Id = 742,
                Name = "R1 (sidestep)",
                Damage = 0,
                ExtraDamage = 0,
                ExtraDamageCount = 0,
                AttackType1 = AttackType.Thrust,
                AttackType2 = AttackType.None,
                AttackMode = AttackMode.Transformed,
                TricksterWeaponId = 18
            },
            
            new Attack {
                Id = 743,
                Name = "R1 (dash)",
                Damage = 1,
                ExtraDamage = 0,
                ExtraDamageCount = 0,
                AttackType1 = AttackType.Physical,
                AttackType2 = AttackType.None,
                AttackMode = AttackMode.Transformed,
                TricksterWeaponId = 18
            },
            
            new Attack {
                Id = 744,
                Name = "R2",
                Damage = 1,
                ExtraDamage = 0,
                ExtraDamageCount = 0,
                AttackType1 = AttackType.Blood,
                AttackType2 = AttackType.None,
                AttackMode = AttackMode.Transformed,
                TricksterWeaponId = 18
            },
            
            new Attack {
                Id = 745,
                Name = "R2 (forward leap)",
                Damage = 1,
                ExtraDamage = 0,
                ExtraDamageCount = 0,
                AttackType1 = AttackType.Physical,
                AttackType2 = AttackType.None,
                AttackMode = AttackMode.Transformed,
                TricksterWeaponId = 18
            },
            
            new Attack {
                Id = 746,
                Name = "Transform Attack",
                Damage = 1,
                ExtraDamage = 0,
                ExtraDamageCount = 0,
                AttackType1 = AttackType.Thrust,
                AttackType2 = AttackType.None,
                AttackMode = AttackMode.Transformed,
                TricksterWeaponId = 18
            },
            
            new Attack {
                Id = 747,
                Name = "Plunge Attack",
                Damage = 1,
                ExtraDamage = 0,
                ExtraDamageCount = 0,
                AttackType1 = AttackType.Physical,
                AttackType2 = AttackType.None,
                AttackMode = AttackMode.Transformed,
                TricksterWeaponId = 18
            },
            
            new Attack {
                Id = 748,
                Name = "Plunge Attack (2nd)",
                Damage = 0,
                ExtraDamage = 0,
                ExtraDamageCount = 0,
                AttackType1 = AttackType.Blunt,
                AttackType2 = AttackType.None,
                AttackMode = AttackMode.Transformed,
                TricksterWeaponId = 18
            },
            
            new Attack {
                Id = 749,
                Name = "R1",
                Damage = 0,
                ExtraDamage = 0,
                ExtraDamageCount = 0,
                AttackType1 = AttackType.Thrust,
                AttackType2 = AttackType.None,
                AttackMode = AttackMode.Normal,
                TricksterWeaponId = 19
            },
            
            new Attack {
                Id = 750,
                Name = "R1 (2nd)",
                Damage = 1,
                ExtraDamage = 0,
                ExtraDamageCount = 0,
                AttackType1 = AttackType.Thrust,
                AttackType2 = AttackType.None,
                AttackMode = AttackMode.Normal,
                TricksterWeaponId = 19
            },
            
            new Attack {
                Id = 751,
                Name = "R1 (3rd)",
                Damage = 1,
                ExtraDamage = 0,
                ExtraDamageCount = 0,
                AttackType1 = AttackType.Thrust,
                AttackType2 = AttackType.None,
                AttackMode = AttackMode.Normal,
                TricksterWeaponId = 19
            },
            
            new Attack {
                Id = 752,
                Name = "R1 (4th)",
                Damage = 1,
                ExtraDamage = 0,
                ExtraDamageCount = 0,
                AttackType1 = AttackType.Thrust,
                AttackType2 = AttackType.None,
                AttackMode = AttackMode.Normal,
                TricksterWeaponId = 19
            },
            
            new Attack {
                Id = 753,
                Name = "R1 (backstep)",
                Damage = 0,
                ExtraDamage = 0,
                ExtraDamageCount = 0,
                AttackType1 = AttackType.Thrust,
                AttackType2 = AttackType.None,
                AttackMode = AttackMode.Normal,
                TricksterWeaponId = 19
            },

            new Attack {
                Id = 754,
                Name = "R1 (rolling)",
                Damage = 0,
                ExtraDamage = 0,
                ExtraDamageCount = 0,
                AttackType1 = AttackType.Physical,
                AttackType2 = AttackType.None,
                AttackMode = AttackMode.Normal,
                TricksterWeaponId = 19
            },
            
            new Attack {
                Id = 755,
                Name = "R1 (frontstep)",
                Damage = 0,
                ExtraDamage = 0,
                ExtraDamageCount = 0,
                AttackType1 = AttackType.Physical,
                AttackType2 = AttackType.None,
                AttackMode = AttackMode.Normal,
                TricksterWeaponId = 19
            },
            
            new Attack {
                Id = 756,
                Name = "R1 (sidestep)",
                Damage = 0,
                ExtraDamage = 0,
                ExtraDamageCount = 0,
                AttackType1 = AttackType.Physical,
                AttackType2 = AttackType.None,
                AttackMode = AttackMode.Normal,
                TricksterWeaponId = 19
            },
            
            new Attack {
                Id = 757,
                Name = "R1 (dash)",
                Damage = 0,
                ExtraDamage = 0,
                ExtraDamageCount = 0,
                AttackType1 = AttackType.Thrust,
                AttackType2 = AttackType.None,
                AttackMode = AttackMode.Normal,
                TricksterWeaponId = 19
            },
            
            new Attack {
                Id = 758,
                Name = "R2",
                Damage = 1,
                ExtraDamage = 0,
                ExtraDamageCount = 0,
                AttackType1 = AttackType.Thrust,
                AttackType2 = AttackType.None,
                AttackMode = AttackMode.Normal,
                TricksterWeaponId = 19
            },
            
            new Attack {
                Id = 759,
                Name = "R2 (charged)",
                Damage = 1,
                ExtraDamage = 0,
                ExtraDamageCount = 0,
                AttackType1 = AttackType.Thrust,
                AttackType2 = AttackType.None,
                AttackMode = AttackMode.Normal,
                TricksterWeaponId = 19
            },
            
            new Attack {
                Id = 760,
                Name = "R2 (backstep)",
                Damage = 1,
                ExtraDamage = 0,
                ExtraDamageCount = 0,
                AttackType1 = AttackType.Physical,
                AttackType2 = AttackType.None,
                AttackMode = AttackMode.Normal,
                TricksterWeaponId = 19
            },
            
            new Attack {
                Id = 761,
                Name = "R2 (dash)",
                Damage = 1,
                ExtraDamage = 0,
                ExtraDamageCount = 0,
                AttackType1 = AttackType.Physical,
                AttackType2 = AttackType.None,
                AttackMode = AttackMode.Normal,
                TricksterWeaponId = 19
            },
            
            new Attack {
                Id = 762,
                Name = "R2 (forward leap)",
                Damage = 1,
                ExtraDamage = 0,
                ExtraDamageCount = 0,
                AttackType1 = AttackType.Thrust,
                AttackType2 = AttackType.None,
                AttackMode = AttackMode.Normal,
                TricksterWeaponId = 19
            },
            
            new Attack {
                Id = 763,
                Name = "Transform Attack",
                Damage = 0,
                ExtraDamage = 0,
                ExtraDamageCount = 0,
                AttackType1 = AttackType.Blood,
                AttackType2 = AttackType.None,
                AttackMode = AttackMode.Normal,
                TricksterWeaponId = 19
            },
            
            new Attack {
                Id = 764,
                Name = "Plunge Attack",
                Damage = 1,
                ExtraDamage = 0,
                ExtraDamageCount = 0,
                AttackType1 = AttackType.Thrust,
                AttackType2 = AttackType.None,
                AttackMode = AttackMode.Normal,
                TricksterWeaponId = 19
            },
            
            new Attack {
                Id = 765,
                Name = "Plunge Attack (2nd)",
                Damage = 0,
                ExtraDamage = 0,
                ExtraDamageCount = 0,
                AttackType1 = AttackType.Blunt,
                AttackType2 = AttackType.None,
                AttackMode = AttackMode.Normal,
                TricksterWeaponId = 19
            },
            
            new Attack {
                Id = 766,
                Name = "R1",
                Damage = 0,
                ExtraDamage = 0,
                ExtraDamageCount = 0,
                AttackType1 = AttackType.Physical,
                AttackType2 = AttackType.None,
                AttackMode = AttackMode.Transformed,
                TricksterWeaponId = 19
            },
            
            new Attack {
                Id = 767,
                Name = "R1 (2nd)",
                Damage = 1,
                ExtraDamage = 0,
                ExtraDamageCount = 0,
                AttackType1 = AttackType.Physical,
                AttackType2 = AttackType.None,
                AttackMode = AttackMode.Transformed,
                TricksterWeaponId = 19
            },
            
            new Attack {
                Id = 768,
                Name = "R1 (3rd)",
                Damage = 1,
                ExtraDamage = 0,
                ExtraDamageCount = 0,
                AttackType1 = AttackType.Physical,
                AttackType2 = AttackType.None,
                AttackMode = AttackMode.Transformed,
                TricksterWeaponId = 19
            },
            
            new Attack {
                Id = 769,
                Name = "R1 (4th)",
                Damage = 1,
                ExtraDamage = 0,
                ExtraDamageCount = 0,
                AttackType1 = AttackType.Physical,
                AttackType2 = AttackType.None,
                AttackMode = AttackMode.Transformed,
                TricksterWeaponId = 19
            },
            
            new Attack {
                Id = 770,
                Name = "R1 (backstep)",
                Damage = 0,
                ExtraDamage = 0,
                ExtraDamageCount = 0,
                AttackType1 = AttackType.Thrust,
                AttackType2 = AttackType.None,
                AttackMode = AttackMode.Transformed,
                TricksterWeaponId = 19
            },
            
            new Attack {
                Id = 771,
                Name = "R1 (rolling)",
                Damage = 0,
                ExtraDamage = 0,
                ExtraDamageCount = 0,
                AttackType1 = AttackType.Thrust,
                AttackType2 = AttackType.None,
                AttackMode = AttackMode.Transformed,
                TricksterWeaponId = 19
            },
            
            new Attack {
                Id = 772,
                Name = "R1 (frontstep)",
                Damage = 0,
                ExtraDamage = 0,
                ExtraDamageCount = 0,
                AttackType1 = AttackType.Thrust,
                AttackType2 = AttackType.None,
                AttackMode = AttackMode.Transformed,
                TricksterWeaponId = 19
            },
            
            new Attack {
                Id = 773,
                Name = "R1 (sidestep)",
                Damage = 0,
                ExtraDamage = 0,
                ExtraDamageCount = 0,
                AttackType1 = AttackType.Thrust,
                AttackType2 = AttackType.None,
                AttackMode = AttackMode.Transformed,
                TricksterWeaponId = 19
            },
            
            new Attack {
                Id = 774,
                Name = "R1 (dash)",
                Damage = 0,
                ExtraDamage = 0,
                ExtraDamageCount = 0,
                AttackType1 = AttackType.Thrust,
                AttackType2 = AttackType.None,
                AttackMode = AttackMode.Transformed,
                TricksterWeaponId = 19
            },
            
            new Attack {
                Id = 775,
                Name = "R2",
                Damage = 1,
                ExtraDamage = 0,
                ExtraDamageCount = 0,
                AttackType1 = AttackType.Thrust,
                AttackType2 = AttackType.None,
                AttackMode = AttackMode.Transformed,
                TricksterWeaponId = 19
            },
            
            new Attack {
                Id = 776,
                Name = "R2 (charged)",
                Damage = 2,
                ExtraDamage = 0,
                ExtraDamageCount = 0,
                AttackType1 = AttackType.Thrust,
                AttackType2 = AttackType.None,
                AttackMode = AttackMode.Transformed,
                TricksterWeaponId = 19
            },
            
            new Attack {
                Id = 777,
                Name = "R2 (backstep)",
                Damage = 1,
                ExtraDamage = 0,
                ExtraDamageCount = 0,
                AttackType1 = AttackType.Physical,
                AttackType2 = AttackType.None,
                AttackMode = AttackMode.Transformed,
                TricksterWeaponId = 19
            },
            
            new Attack {
                Id = 778,
                Name = "R2 (dash)",
                Damage = 1,
                ExtraDamage = 0,
                ExtraDamageCount = 0,
                AttackType1 = AttackType.Physical,
                AttackType2 = AttackType.None,
                AttackMode = AttackMode.Transformed,
                TricksterWeaponId = 19
            },
            
            new Attack {
                Id = 779,
                Name = "R2 (forward leap)",
                Damage = 1,
                ExtraDamage = 0,
                ExtraDamageCount = 0,
                AttackType1 = AttackType.Physical,
                AttackType2 = AttackType.None,
                AttackMode = AttackMode.Transformed,
                TricksterWeaponId = 19
            },
            
            new Attack {
                Id = 780,
                Name = "L2",
                Damage = 0,
                ExtraDamage = 0,
                ExtraDamageCount = 0,
                AttackType1 = AttackType.Blood,
                AttackType2 = AttackType.None,
                AttackMode = AttackMode.Transformed,
                TricksterWeaponId = 19
            },
            
            new Attack {
                Id = 781,
                Name = "Transform Attack",
                Damage = 1,
                ExtraDamage = 0,
                ExtraDamageCount = 0,
                AttackType1 = AttackType.Physical,
                AttackType2 = AttackType.None,
                AttackMode = AttackMode.Transformed,
                TricksterWeaponId = 19
            },
            
            new Attack {
                Id = 782,
                Name = "Plunge Attack",
                Damage = 1,
                ExtraDamage = 0,
                ExtraDamageCount = 0,
                AttackType1 = AttackType.Thrust,
                AttackType2 = AttackType.None,
                AttackMode = AttackMode.Transformed,
                TricksterWeaponId = 19
            },
            
            new Attack {
                Id = 783,
                Name = "Plunge Attack (2nd)",
                Damage = 0,
                ExtraDamage = 0,
                ExtraDamageCount = 0,
                AttackType1 = AttackType.Blunt,
                AttackType2 = AttackType.None,
                AttackMode = AttackMode.Transformed,
                TricksterWeaponId = 19
            },
            
            new Attack {
                Id = 784,
                Name = "R1",
                Damage = 1,
                ExtraDamage = 0,
                ExtraDamageCount = 0,
                AttackType1 = AttackType.Physical,
                AttackType2 = AttackType.None,
                AttackMode = AttackMode.Normal,
                TricksterWeaponId = 20
            },
            
            new Attack {
                Id = 785,
                Name = "R1 (2nd)",
                Damage = 1,
                ExtraDamage = 0,
                ExtraDamageCount = 0,
                AttackType1 = AttackType.Physical,
                AttackType2 = AttackType.None,
                AttackMode = AttackMode.Normal,
                TricksterWeaponId = 20
            },
            
            new Attack {
                Id = 786,
                Name = "R1 (3rd)",
                Damage = 1,
                ExtraDamage = 0,
                ExtraDamageCount = 0,
                AttackType1 = AttackType.Physical,
                AttackType2 = AttackType.None,
                AttackMode = AttackMode.Normal,
                TricksterWeaponId = 20
            },
            
            new Attack {
                Id = 787,
                Name = "R1 (4th)",
                Damage = 1,
                ExtraDamage = 0,
                ExtraDamageCount = 0,
                AttackType1 = AttackType.Physical,
                AttackType2 = AttackType.None,
                AttackMode = AttackMode.Normal,
                TricksterWeaponId = 20
            },
            
            new Attack {
                Id = 788,
                Name = "R1 (5th)",
                Damage = 1,
                ExtraDamage = 0,
                ExtraDamageCount = 0,
                AttackType1 = AttackType.Physical,
                AttackType2 = AttackType.None,
                AttackMode = AttackMode.Normal,
                TricksterWeaponId = 20
            },
            
            new Attack {
                Id = 789,
                Name = "R1 (backstep)",
                Damage = 0,
                ExtraDamage = 0,
                ExtraDamageCount = 0,
                AttackType1 = AttackType.Physical,
                AttackType2 = AttackType.None,
                AttackMode = AttackMode.Normal,
                TricksterWeaponId = 20
            },
            
            new Attack {
                Id = 790,
                Name = "R1 (rolling)",
                Damage = 0,
                ExtraDamage = 0,
                ExtraDamageCount = 0,
                AttackType1 = AttackType.Physical,
                AttackType2 = AttackType.None,
                AttackMode = AttackMode.Normal,
                TricksterWeaponId = 20
            },
            
            new Attack {
                Id = 791,
                Name = "R1 (frontstep)",
                Damage = 0,
                ExtraDamage = 0,
                ExtraDamageCount = 0,
                AttackType1 = AttackType.Physical,
                AttackType2 = AttackType.None,
                AttackMode = AttackMode.Normal,
                TricksterWeaponId = 20
            },
            
            new Attack {
                Id = 792,
                Name = "R1 (sidestep)",
                Damage = 1,
                ExtraDamage = 0,
                ExtraDamageCount = 0,
                AttackType1 = AttackType.Physical,
                AttackType2 = AttackType.None,
                AttackMode = AttackMode.Normal,
                TricksterWeaponId = 20
            },
            
            new Attack {
                Id = 793,
                Name = "R1 (dash)",
                Damage = 1,
                ExtraDamage = 0,
                ExtraDamageCount = 0,
                AttackType1 = AttackType.Physical,
                AttackType2 = AttackType.None,
                AttackMode = AttackMode.Normal,
                TricksterWeaponId = 20
            },
            
            new Attack {
                Id = 794,
                Name = "R2",
                Damage = 1,
                ExtraDamage = 0,
                ExtraDamageCount = 0,
                AttackType1 = AttackType.Physical,
                AttackType2 = AttackType.None,
                AttackMode = AttackMode.Normal,
                TricksterWeaponId = 20
            },
            
            new Attack {
                Id = 795,
                Name = "R2 (charged)",
                Damage = 1,
                ExtraDamage = 0,
                ExtraDamageCount = 0,
                AttackType1 = AttackType.Physical,
                AttackType2 = AttackType.None,
                AttackMode = AttackMode.Normal,
                TricksterWeaponId = 20
            },
            
            new Attack {
                Id = 796,
                Name = "R2 (backstep)",
                Damage = 1,
                ExtraDamage = 0,
                ExtraDamageCount = 0,
                AttackType1 = AttackType.Physical,
                AttackType2 = AttackType.None,
                AttackMode = AttackMode.Normal,
                TricksterWeaponId = 20
            },
            
            new Attack {
                Id = 797,
                Name = "R2 (dash)",
                Damage = 1,
                ExtraDamage = 0,
                ExtraDamageCount = 0,
                AttackType1 = AttackType.Physical,
                AttackType2 = AttackType.None,
                AttackMode = AttackMode.Normal,
                TricksterWeaponId = 20
            },
            
            new Attack {
                Id = 798,
                Name = "R2 (forward leap)",
                Damage = 1,
                ExtraDamage = 0,
                ExtraDamageCount = 0,
                AttackType1 = AttackType.Physical,
                AttackType2 = AttackType.None,
                AttackMode = AttackMode.Normal,
                TricksterWeaponId = 20
            },
            
            new Attack {
                Id = 799,
                Name = "Transform Attack",
                Damage = 1,
                ExtraDamage = 0,
                ExtraDamageCount = 0,
                AttackType1 = AttackType.Physical,
                AttackType2 = AttackType.None,
                AttackMode = AttackMode.Normal,
                TricksterWeaponId = 20
            },
            
            new Attack {
                Id = 800,
                Name = "Plunge Attack",
                Damage = 1,
                ExtraDamage = 0,
                ExtraDamageCount = 0,
                AttackType1 = AttackType.Physical,
                AttackType2 = AttackType.None,
                AttackMode = AttackMode.Normal,
                TricksterWeaponId = 20
            },
            
            new Attack {
                Id = 801,
                Name = "Plunge Attack (2nd)",
                Damage = 0,
                ExtraDamage = 0,
                ExtraDamageCount = 0,
                AttackType1 = AttackType.Blunt,
                AttackType2 = AttackType.None,
                AttackMode = AttackMode.Normal,
                TricksterWeaponId = 20
            },
            
            new Attack {
                Id = 802,
                Name = "R1",
                Damage = 0,
                ExtraDamage = 0,
                ExtraDamageCount = 0,
                AttackType1 = AttackType.Physical,
                AttackType2 = AttackType.None,
                AttackMode = AttackMode.Transformed,
                TricksterWeaponId = 20
            },
            
            new Attack {
                Id = 803,
                Name = "R1 (2nd)",
                Damage = 1,
                ExtraDamage = 0,
                ExtraDamageCount = 0,
                AttackType1 = AttackType.Physical,
                AttackType2 = AttackType.None,
                AttackMode = AttackMode.Transformed,
                TricksterWeaponId = 20
            },
            
            new Attack {
                Id = 804,
                Name = "R1 (3rd)",
                Damage = 1,
                ExtraDamage = 0,
                ExtraDamageCount = 0,
                AttackType1 = AttackType.Physical,
                AttackType2 = AttackType.None,
                AttackMode = AttackMode.Transformed,
                TricksterWeaponId = 20
            },
            
            new Attack {
                Id = 805,
                Name = "R1 (backstep)",
                Damage = 0,
                ExtraDamage = 0,
                ExtraDamageCount = 0,
                AttackType1 = AttackType.Physical,
                AttackType2 = AttackType.None,
                AttackMode = AttackMode.Transformed,
                TricksterWeaponId = 20
            },
            
            new Attack {
                Id = 806,
                Name = "R1 (rolling)",
                Damage = 0,
                ExtraDamage = 0,
                ExtraDamageCount = 0,
                AttackType1 = AttackType.Physical,
                AttackType2 = AttackType.None,
                AttackMode = AttackMode.Transformed,
                TricksterWeaponId = 20
            },
            
            new Attack {
                Id = 807,
                Name = "R1 (frontstep)",
                Damage = 0,
                ExtraDamage = 0,
                ExtraDamageCount = 0,
                AttackType1 = AttackType.Physical,
                AttackType2 = AttackType.None,
                AttackMode = AttackMode.Transformed,
                TricksterWeaponId = 20
            },
            
            new Attack {
                Id = 808,
                Name = "R1 (sidestep)",
                Damage = 1,
                ExtraDamage = 0,
                ExtraDamageCount = 0,
                AttackType1 = AttackType.Physical,
                AttackType2 = AttackType.None,
                AttackMode = AttackMode.Transformed,
                TricksterWeaponId = 20
            },
            
            new Attack {
                Id = 809,
                Name = "R1 (dash)",
                Damage = 1,
                ExtraDamage = 0,
                ExtraDamageCount = 0,
                AttackType1 = AttackType.Physical,
                AttackType2 = AttackType.None,
                AttackMode = AttackMode.Transformed,
                TricksterWeaponId = 20
            },
            
            new Attack {
                Id = 810,
                Name = "R2",
                Damage = 1,
                ExtraDamage = 0,
                ExtraDamageCount = 0,
                AttackType1 = AttackType.Physical,
                AttackType2 = AttackType.None,
                AttackMode = AttackMode.Transformed,
                TricksterWeaponId = 20
            },
            
            new Attack {
                Id = 811,
                Name = "R2 (2nd)",
                Damage = 1,
                ExtraDamage = 0,
                ExtraDamageCount = 0,
                AttackType1 = AttackType.Physical,
                AttackType2 = AttackType.None,
                AttackMode = AttackMode.Transformed,
                TricksterWeaponId = 20
            },
            
            new Attack {
                Id = 812,
                Name = "R2 (charged)",
                Damage = 1,
                ExtraDamage = 0,
                ExtraDamageCount = 0,
                AttackType1 = AttackType.Physical,
                AttackType2 = AttackType.None,
                AttackMode = AttackMode.Transformed,
                TricksterWeaponId = 20
            },
            
            new Attack {
                Id = 813,
                Name = "R2 (charged followup)",
                Damage = 1,
                ExtraDamage = 0,
                ExtraDamageCount = 0,
                AttackType1 = AttackType.Physical,
                AttackType2 = AttackType.None,
                AttackMode = AttackMode.Transformed,
                TricksterWeaponId = 20
            },
            
            new Attack {
                Id = 814,
                Name = "R2 (backstep)",
                Damage = 1,
                ExtraDamage = 0,
                ExtraDamageCount = 0,
                AttackType1 = AttackType.Physical,
                AttackType2 = AttackType.None,
                AttackMode = AttackMode.Transformed,
                TricksterWeaponId = 20
            },
            
            new Attack {
                Id = 815,
                Name = "R2 (dash)",
                Damage = 1,
                ExtraDamage = 0,
                ExtraDamageCount = 0,
                AttackType1 = AttackType.Physical,
                AttackType2 = AttackType.None,
                AttackMode = AttackMode.Transformed,
                TricksterWeaponId = 20
            },
            
            new Attack {
                Id = 816,
                Name = "R2(forward leap)",
                Damage = 1,
                ExtraDamage = 0,
                ExtraDamageCount = 0,
                AttackType1 = AttackType.Physical,
                AttackType2 = AttackType.None,
                AttackMode = AttackMode.Transformed,
                TricksterWeaponId = 20
            },
            
            new Attack {
                Id = 817,
                Name = "Transform Attack",
                Damage = 1,
                ExtraDamage = 0,
                ExtraDamageCount = 0,
                AttackType1 = AttackType.Physical,
                AttackType2 = AttackType.None,
                AttackMode = AttackMode.Transformed,
                TricksterWeaponId = 20
            },
            
            new Attack {
                Id = 818,
                Name = "Plunge Attack",
                Damage = 1,
                ExtraDamage = 0,
                ExtraDamageCount = 0,
                AttackType1 = AttackType.Physical,
                AttackType2 = AttackType.None,
                AttackMode = AttackMode.Transformed,
                TricksterWeaponId = 20
            },
            
            new Attack {
                Id = 819,
                Name = "Plunge Attack (2nd)",
                Damage = 0,
                ExtraDamage = 0,
                ExtraDamageCount = 0,
                AttackType1 = AttackType.Blunt,
                AttackType2 = AttackType.None,
                AttackMode = AttackMode.Transformed,
                TricksterWeaponId = 20
            },
            
            new Attack {
                Id = 820,
                Name = "R1",
                Damage = 1,
                ExtraDamage = 0,
                ExtraDamageCount = 0,
                AttackType1 = AttackType.Physical,
                AttackType2 = AttackType.None,
                AttackMode = AttackMode.Normal,
                TricksterWeaponId = 21
            },
            
            new Attack {
                Id = 821,
                Name = "R1 (2nd)",
                Damage = 1,
                ExtraDamage = 0,
                ExtraDamageCount = 0,
                AttackType1 = AttackType.Physical,
                AttackType2 = AttackType.None,
                AttackMode = AttackMode.Normal,
                TricksterWeaponId = 21
            },
            
            new Attack {
                Id = 822,
                Name = "R1 (3rd)",
                Damage = 1,
                ExtraDamage = 0,
                ExtraDamageCount = 0,
                AttackType1 = AttackType.Physical,
                AttackType2 = AttackType.None,
                AttackMode = AttackMode.Normal,
                TricksterWeaponId = 21
            },
            
            new Attack {
                Id = 823,
                Name = "R1 (4th)",
                Damage = 1,
                ExtraDamage = 0,
                ExtraDamageCount = 0,
                AttackType1 = AttackType.Physical,
                AttackType2 = AttackType.None,
                AttackMode = AttackMode.Normal,
                TricksterWeaponId = 21
            },
            
            new Attack {
                Id = 824,
                Name = "R1 (5th)",
                Damage = 1,
                ExtraDamage = 0,
                ExtraDamageCount = 0,
                AttackType1 = AttackType.Physical,
                AttackType2 = AttackType.None,
                AttackMode = AttackMode.Normal,
                TricksterWeaponId = 21
            },
            
            new Attack {
                Id = 825,
                Name = "R1 (backstep)",
                Damage = 0,
                ExtraDamage = 0,
                ExtraDamageCount = 0,
                AttackType1 = AttackType.Physical,
                AttackType2 = AttackType.None,
                AttackMode = AttackMode.Normal,
                TricksterWeaponId = 21
            },
            
            new Attack {
                Id = 826,
                Name = "R1 (rolling)",
                Damage = 0,
                ExtraDamage = 0,
                ExtraDamageCount = 0,
                AttackType1 = AttackType.Physical,
                AttackType2 = AttackType.None,
                AttackMode = AttackMode.Normal,
                TricksterWeaponId = 21
            },
            
            new Attack {
                Id = 827,
                Name = "R1 (frontstep)",
                Damage = 0,
                ExtraDamage = 0,
                ExtraDamageCount = 0,
                AttackType1 = AttackType.Physical,
                AttackType2 = AttackType.None,
                AttackMode = AttackMode.Normal,
                TricksterWeaponId = 21
            },
            
            new Attack {
                Id = 828,
                Name = "R1 (sidestep)",
                Damage = 1,
                ExtraDamage = 0,
                ExtraDamageCount = 0,
                AttackType1 = AttackType.Physical,
                AttackType2 = AttackType.None,
                AttackMode = AttackMode.Normal,
                TricksterWeaponId = 21
            },
            
            new Attack {
                Id = 829,
                Name = "R1 (dash)",
                Damage = 1,
                ExtraDamage = 0,
                ExtraDamageCount = 0,
                AttackType1 = AttackType.Physical,
                AttackType2 = AttackType.None,
                AttackMode = AttackMode.Normal,
                TricksterWeaponId = 21
            },
            
            new Attack {
                Id = 830,
                Name = "R2",
                Damage = 1,
                ExtraDamage = 0,
                ExtraDamageCount = 0,
                AttackType1 = AttackType.Physical,
                AttackType2 = AttackType.None,
                AttackMode = AttackMode.Normal,
                TricksterWeaponId = 21
            },
            
            new Attack {
                Id = 831,
                Name = "R2 (charged)",
                Damage = 1,
                ExtraDamage = 0,
                ExtraDamageCount = 0,
                AttackType1 = AttackType.Physical,
                AttackType2 = AttackType.None,
                AttackMode = AttackMode.Normal,
                TricksterWeaponId = 21
            },
            
            new Attack {
                Id = 832,
                Name = "R2 (backstep)",
                Damage = 1,
                ExtraDamage = 0,
                ExtraDamageCount = 0,
                AttackType1 = AttackType.Physical,
                AttackType2 = AttackType.None,
                AttackMode = AttackMode.Normal,
                TricksterWeaponId = 21
            },
            
            new Attack {
                Id = 833,
                Name = "R2 (dash)",
                Damage = 1,
                ExtraDamage = 0,
                ExtraDamageCount = 0,
                AttackType1 = AttackType.Physical,
                AttackType2 = AttackType.None,
                AttackMode = AttackMode.Normal,
                TricksterWeaponId = 21
            },
            
            new Attack {
                Id = 834,
                Name = "R2 (forward leap)",
                Damage = 1,
                ExtraDamage = 0,
                ExtraDamageCount = 0,
                AttackType1 = AttackType.Physical,
                AttackType2 = AttackType.None,
                AttackMode = AttackMode.Normal,
                TricksterWeaponId = 21
            },
            
            new Attack {
                Id = 835,
                Name = "Transform Attack",
                Damage = 1,
                ExtraDamage = 0,
                ExtraDamageCount = 0,
                AttackType1 = AttackType.Physical,
                AttackType2 = AttackType.None,
                AttackMode = AttackMode.Normal,
                TricksterWeaponId = 21
            },
            
            new Attack {
                Id = 836,
                Name = "Plunge Attack",
                Damage = 1,
                ExtraDamage = 0,
                ExtraDamageCount = 0,
                AttackType1 = AttackType.Physical,
                AttackType2 = AttackType.None,
                AttackMode = AttackMode.Normal,
                TricksterWeaponId = 21
            },
            
            new Attack {
                Id = 837,
                Name = "Plunge Attack (2nd)",
                Damage = 0,
                ExtraDamage = 0,
                ExtraDamageCount = 0,
                AttackType1 = AttackType.Blunt,
                AttackType2 = AttackType.None,
                AttackMode = AttackMode.Normal,
                TricksterWeaponId = 21
            },
            
            new Attack {
                Id = 838,
                Name = "R1",
                Damage = 1,
                ExtraDamage = 0,
                ExtraDamageCount = 0,
                AttackType1 = AttackType.Physical,
                AttackType2 = AttackType.None,
                AttackMode = AttackMode.Transformed,
                TricksterWeaponId = 21
            },
            
            new Attack {
                Id = 839,
                Name = "R1 (2nd)",
                Damage = 1,
                ExtraDamage = 0,
                ExtraDamageCount = 0,
                AttackType1 = AttackType.Physical,
                AttackType2 = AttackType.None,
                AttackMode = AttackMode.Transformed,
                TricksterWeaponId = 21
            },
            
            new Attack {
                Id = 840,
                Name = "R1 (3rd)",
                Damage = 1,
                ExtraDamage = 0,
                ExtraDamageCount = 0,
                AttackType1 = AttackType.Physical,
                AttackType2 = AttackType.None,
                AttackMode = AttackMode.Transformed,
                TricksterWeaponId = 21
            },
            
            new Attack {
                Id = 841,
                Name = "R1 (4th)",
                Damage = 1,
                ExtraDamage = 0,
                ExtraDamageCount = 0,
                AttackType1 = AttackType.Physical,
                AttackType2 = AttackType.None,
                AttackMode = AttackMode.Transformed,
                TricksterWeaponId = 21
            },
            
            new Attack {
                Id = 842,
                Name = "R1 (backstep)",
                Damage = 0,
                ExtraDamage = 0,
                ExtraDamageCount = 0,
                AttackType1 = AttackType.Thrust,
                AttackType2 = AttackType.None,
                AttackMode = AttackMode.Transformed,
                TricksterWeaponId = 21
            },

            new Attack {
                Id = 843,
                Name = "R1 (rolling)",
                Damage = 1,
                ExtraDamage = 0,
                ExtraDamageCount = 0,
                AttackType1 = AttackType.Physical,
                AttackType2 = AttackType.None,
                AttackMode = AttackMode.Transformed,
                TricksterWeaponId = 21
            },
            
            new Attack {
                Id = 844,
                Name = "R1 (frontstep)",
                Damage = 1,
                ExtraDamage = 0,
                ExtraDamageCount = 0,
                AttackType1 = AttackType.Physical,
                AttackType2 = AttackType.None,
                AttackMode = AttackMode.Transformed,
                TricksterWeaponId = 21
            },
            
            new Attack {
                Id = 845,
                Name = "R1 (sidestep)",
                Damage = 1,
                ExtraDamage = 0,
                ExtraDamageCount = 0,
                AttackType1 = AttackType.Physical,
                AttackType2 = AttackType.None,
                AttackMode = AttackMode.Transformed,
                TricksterWeaponId = 21
            },
            
            new Attack {
                Id = 846,
                Name = "R1 (dash)",
                Damage = 0,
                ExtraDamage = 0,
                ExtraDamageCount = 0,
                AttackType1 = AttackType.Thrust,
                AttackType2 = AttackType.None,
                AttackMode = AttackMode.Transformed,
                TricksterWeaponId = 21
            },
            
            new Attack {
                Id = 847,
                Name = "R2",
                Damage = 1,
                ExtraDamage = 0,
                ExtraDamageCount = 0,
                AttackType1 = AttackType.Thrust,
                AttackType2 = AttackType.None,
                AttackMode = AttackMode.Transformed,
                TricksterWeaponId = 21
            },
            
            new Attack {
                Id = 848,
                Name = "R2 (charged)",
                Damage = 1,
                ExtraDamage = 0,
                ExtraDamageCount = 0,
                AttackType1 = AttackType.Thrust,
                AttackType2 = AttackType.None,
                AttackMode = AttackMode.Transformed,
                TricksterWeaponId = 21
            },
            
            new Attack {
                Id = 849,
                Name = "R2 (charged follow-up)",
                Damage = 1,
                ExtraDamage = 0,
                ExtraDamageCount = 0,
                AttackType1 = AttackType.Physical,
                AttackType2 = AttackType.None,
                AttackMode = AttackMode.Transformed,
                TricksterWeaponId = 21
            },
            
            new Attack {
                Id = 850,
                Name = "R2 (backstep)",
                Damage = 1,
                ExtraDamage = 0,
                ExtraDamageCount = 0,
                AttackType1 = AttackType.Physical,
                AttackType2 = AttackType.None,
                AttackMode = AttackMode.Transformed,
                TricksterWeaponId = 21
            },
            
            new Attack {
                Id = 851,
                Name = "R2 (dash)",
                Damage = 1,
                ExtraDamage = 0,
                ExtraDamageCount = 0,
                AttackType1 = AttackType.Physical,
                AttackType2 = AttackType.None,
                AttackMode = AttackMode.Transformed,
                TricksterWeaponId = 21
            },
            
            new Attack {
                Id = 852,
                Name = "R2(forward leap)",
                Damage = 1,
                ExtraDamage = 0,
                ExtraDamageCount = 0,
                AttackType1 = AttackType.Thrust,
                AttackType2 = AttackType.None,
                AttackMode = AttackMode.Transformed,
                TricksterWeaponId = 21
            },
            
            new Attack {
                Id = 853,
                Name = "Transform Attack",
                Damage = 1,
                ExtraDamage = 0,
                ExtraDamageCount = 0,
                AttackType1 = AttackType.Physical,
                AttackType2 = AttackType.None,
                AttackMode = AttackMode.Transformed,
                TricksterWeaponId = 21
            },
            
            new Attack {
                Id = 854,
                Name = "Plunge Attack",
                Damage = 1,
                ExtraDamage = 0,
                ExtraDamageCount = 0,
                AttackType1 = AttackType.Thrust,
                AttackType2 = AttackType.None,
                AttackMode = AttackMode.Transformed,
                TricksterWeaponId = 21
            },
            
            new Attack {
                Id = 855,
                Name = "Plunge Attack (2nd)",
                Damage = 0,
                ExtraDamage = 0,
                ExtraDamageCount = 0,
                AttackType1 = AttackType.Blunt,
                AttackType2 = AttackType.None,
                AttackMode = AttackMode.Transformed,
                TricksterWeaponId = 21
            },
            
            new Attack {
                Id = 856,
                Name = "R1",
                Damage = 1,
                ExtraDamage = 0,
                ExtraDamageCount = 0,
                AttackType1 = AttackType.Physical,
                AttackType2 = AttackType.None,
                AttackMode = AttackMode.Normal,
                TricksterWeaponId = 22
            },
            
            new Attack {
                Id = 857,
                Name = "R1 (2nd)",
                Damage = 1,
                ExtraDamage = 0,
                ExtraDamageCount = 0,
                AttackType1 = AttackType.Physical,
                AttackType2 = AttackType.None,
                AttackMode = AttackMode.Normal,
                TricksterWeaponId = 22
            },
            
            new Attack {
                Id = 858,
                Name = "R1 (3rd)",
                Damage = 1,
                ExtraDamage = 0,
                ExtraDamageCount = 0,
                AttackType1 = AttackType.Physical,
                AttackType2 = AttackType.None,
                AttackMode = AttackMode.Normal,
                TricksterWeaponId = 22
            },
            
            new Attack {
                Id = 859,
                Name = "R1 (4th)",
                Damage = 1,
                ExtraDamage = 0,
                ExtraDamageCount = 0,
                AttackType1 = AttackType.Thrust,
                AttackType2 = AttackType.None,
                AttackMode = AttackMode.Normal,
                TricksterWeaponId = 22
            },
            
            new Attack {
                Id = 860,
                Name = "R1 (backstep)",
                Damage = 1,
                ExtraDamage = 0,
                ExtraDamageCount = 0,
                AttackType1 = AttackType.Thrust,
                AttackType2 = AttackType.None,
                AttackMode = AttackMode.Normal,
                TricksterWeaponId = 22
            },
            
            new Attack {
                Id = 861,
                Name = "R1 (rolling)",
                Damage = 1,
                ExtraDamage = 0,
                ExtraDamageCount = 0,
                AttackType1 = AttackType.Physical,
                AttackType2 = AttackType.None,
                AttackMode = AttackMode.Normal,
                TricksterWeaponId = 22
            },
            
            new Attack {
                Id = 862,
                Name = "R1 (frontstep)",
                Damage = 1,
                ExtraDamage = 0,
                ExtraDamageCount = 0,
                AttackType1 = AttackType.Physical,
                AttackType2 = AttackType.None,
                AttackMode = AttackMode.Normal,
                TricksterWeaponId = 22
            },
            
            new Attack {
                Id = 863,
                Name = "R1 (sidestep)",
                Damage = 1,
                ExtraDamage = 0,
                ExtraDamageCount = 0,
                AttackType1 = AttackType.Physical,
                AttackType2 = AttackType.None,
                AttackMode = AttackMode.Normal,
                TricksterWeaponId = 22
            },
            
            new Attack {
                Id = 864,
                Name = "R1 (dash)",
                Damage = 1,
                ExtraDamage = 0,
                ExtraDamageCount = 0,
                AttackType1 = AttackType.Physical,
                AttackType2 = AttackType.None,
                AttackMode = AttackMode.Normal,
                TricksterWeaponId = 22
            },
            
            new Attack {
                Id = 865,
                Name = "R2",
                Damage = 1,
                ExtraDamage = 0,
                ExtraDamageCount = 0,
                AttackType1 = AttackType.Physical,
                AttackType2 = AttackType.None,
                AttackMode = AttackMode.Normal,
                TricksterWeaponId = 22
            },
            
            new Attack {
                Id = 866,
                Name = "R2 (charged)",
                Damage = 0,
                ExtraDamage = 1,
                ExtraDamageCount = 1,
                AttackType1 = AttackType.Physical,
                AttackType2 = AttackType.None,
                AttackMode = AttackMode.Normal,
                TricksterWeaponId = 22
            },
            
            new Attack {
                Id = 867,
                Name = "R2 (backstep)",
                Damage = 1,
                ExtraDamage = 0,
                ExtraDamageCount = 0,
                AttackType1 = AttackType.Physical,
                AttackType2 = AttackType.None,
                AttackMode = AttackMode.Normal,
                TricksterWeaponId = 22
            },
            
            new Attack {
                Id = 868,
                Name = "R2 (dash)",
                Damage = 1,
                ExtraDamage = 0,
                ExtraDamageCount = 0,
                AttackType1 = AttackType.Physical,
                AttackType2 = AttackType.None,
                AttackMode = AttackMode.Normal,
                TricksterWeaponId = 22
            },
            
            new Attack {
                Id = 869,
                Name = "R2 (forward leap)",
                Damage = 1,
                ExtraDamage = 0,
                ExtraDamageCount = 0,
                AttackType1 = AttackType.Physical,
                AttackType2 = AttackType.None,
                AttackMode = AttackMode.Normal,
                TricksterWeaponId = 22
            },
            
            new Attack {
                Id = 870,
                Name = "Transform Attack",
                Damage = 0,
                ExtraDamage = 0,
                ExtraDamageCount = 0,
                AttackType1 = AttackType.Blood,
                AttackType2 = AttackType.None,
                AttackMode = AttackMode.Normal,
                TricksterWeaponId = 22
            },
            
            new Attack {
                Id = 871,
                Name = "Plunge Attack",
                Damage = 1,
                ExtraDamage = 0,
                ExtraDamageCount = 0,
                AttackType1 = AttackType.Physical,
                AttackType2 = AttackType.None,
                AttackMode = AttackMode.Normal,
                TricksterWeaponId = 22
            },
            
            new Attack {
                Id = 872,
                Name = "Plunge Attack (2nd)",
                Damage = 0,
                ExtraDamage = 0,
                ExtraDamageCount = 0,
                AttackType1 = AttackType.Blunt,
                AttackType2 = AttackType.None,
                AttackMode = AttackMode.Normal,
                TricksterWeaponId = 22
            },
            
            new Attack {
                Id = 873,
                Name = "R1",
                Damage = 0,
                ExtraDamage = 0,
                ExtraDamageCount = 0,
                AttackType1 = AttackType.Blood,
                AttackType2 = AttackType.None,
                AttackMode = AttackMode.Transformed,
                TricksterWeaponId = 22
            },
            
            new Attack {
                Id = 874,
                Name = "R1 (backstep)",
                Damage = 0,
                ExtraDamage = 0,
                ExtraDamageCount = 0,
                AttackType1 = AttackType.Blood,
                AttackType2 = AttackType.None,
                AttackMode = AttackMode.Transformed,
                TricksterWeaponId = 22
            },
            
            new Attack {
                Id = 875,
                Name = "R2",
                Damage = 1,
                ExtraDamage = 0,
                ExtraDamageCount = 0,
                AttackType1 = AttackType.Blood,
                AttackType2 = AttackType.None,
                AttackMode = AttackMode.Transformed,
                TricksterWeaponId = 22
            },
            
            new Attack {
                Id = 876,
                Name = "R2 (charged)",
                Damage = 1,
                ExtraDamage = 0,
                ExtraDamageCount = 0,
                AttackType1 = AttackType.Blood,
                AttackType2 = AttackType.None,
                AttackMode = AttackMode.Transformed,
                TricksterWeaponId = 22
            },
            
            new Attack {
                Id = 877,
                Name = "R2 (forward leap)",
                Damage = 1,
                ExtraDamage = 0,
                ExtraDamageCount = 0,
                AttackType1 = AttackType.Physical,
                AttackType2 = AttackType.None,
                AttackMode = AttackMode.Transformed,
                TricksterWeaponId = 22
            },
            
            new Attack {
                Id = 878,
                Name = "L2",
                Damage = 0,
                ExtraDamage = 0,
                ExtraDamageCount = 0,
                AttackType1 = AttackType.Physical,
                AttackType2 = AttackType.None,
                AttackMode = AttackMode.Transformed,
                TricksterWeaponId = 22
            },
            
            new Attack {
                Id = 879,
                Name = "Transform Attack",
                Damage = 1,
                ExtraDamage = 0,
                ExtraDamageCount = 0,
                AttackType1 = AttackType.Thrust,
                AttackType2 = AttackType.None,
                AttackMode = AttackMode.Transformed,
                TricksterWeaponId = 22
            },
            
            new Attack {
                Id = 880,
                Name = "Plunge Attack",
                Damage = 1,
                ExtraDamage = 0,
                ExtraDamageCount = 0,
                AttackType1 = AttackType.Physical,
                AttackType2 = AttackType.None,
                AttackMode = AttackMode.Transformed,
                TricksterWeaponId = 22
            },
            
            new Attack {
                Id = 881,
                Name = "Plunge Attack (2nd)",
                Damage = 0,
                ExtraDamage = 0,
                ExtraDamageCount = 0,
                AttackType1 = AttackType.Blunt,
                AttackType2 = AttackType.None,
                AttackMode = AttackMode.Transformed,
                TricksterWeaponId = 22
            },
            
            new Attack {
                Id = 882,
                Name = "R1",
                Damage = 1,
                ExtraDamage = 0,
                ExtraDamageCount = 0,
                AttackType1 = AttackType.Physical,
                AttackType2 = AttackType.None,
                AttackMode = AttackMode.Normal,
                TricksterWeaponId = 23
            },
            
            new Attack {
                Id = 883,
                Name = "R1 (2nd)",
                Damage = 1,
                ExtraDamage = 0,
                ExtraDamageCount = 0,
                AttackType1 = AttackType.Physical,
                AttackType2 = AttackType.None,
                AttackMode = AttackMode.Normal,
                TricksterWeaponId = 23
            },
            
            new Attack {
                Id = 884,
                Name = "R1 (3rd)",
                Damage = 1,
                ExtraDamage = 0,
                ExtraDamageCount = 0,
                AttackType1 = AttackType.Physical,
                AttackType2 = AttackType.None,
                AttackMode = AttackMode.Normal,
                TricksterWeaponId = 23
            },
            
            new Attack {
                Id = 885,
                Name = "R1 (4th)",
                Damage = 1,
                ExtraDamage = 0,
                ExtraDamageCount = 0,
                AttackType1 = AttackType.Thrust,
                AttackType2 = AttackType.None,
                AttackMode = AttackMode.Normal,
                TricksterWeaponId = 23
            },
            
            new Attack {
                Id = 886,
                Name = "R1 (5th)",
                Damage = 1,
                ExtraDamage = 0,
                ExtraDamageCount = 0,
                AttackType1 = AttackType.Physical,
                AttackType2 = AttackType.None,
                AttackMode = AttackMode.Normal,
                TricksterWeaponId = 23
            },
            
            new Attack {
                Id = 887,
                Name = "R1 (backstep)",
                Damage = 0,
                ExtraDamage = 0,
                ExtraDamageCount = 0,
                AttackType1 = AttackType.Thrust,
                AttackType2 = AttackType.None,
                AttackMode = AttackMode.Normal,
                TricksterWeaponId = 23
            },
            
            new Attack {
                Id = 888,
                Name = "R1 (rolling)",
                Damage = 0,
                ExtraDamage = 0,
                ExtraDamageCount = 0,
                AttackType1 = AttackType.Physical,
                AttackType2 = AttackType.None,
                AttackMode = AttackMode.Normal,
                TricksterWeaponId = 23
            },
            
            new Attack {
                Id = 889,
                Name = "R1 (frontstep)",
                Damage = 0,
                ExtraDamage = 0,
                ExtraDamageCount = 0,
                AttackType1 = AttackType.Physical,
                AttackType2 = AttackType.None,
                AttackMode = AttackMode.Normal,
                TricksterWeaponId = 23
            },
            
            new Attack {
                Id = 890,
                Name = "R1 (sidestep)",
                Damage = 1,
                ExtraDamage = 0,
                ExtraDamageCount = 0,
                AttackType1 = AttackType.Physical,
                AttackType2 = AttackType.None,
                AttackMode = AttackMode.Normal,
                TricksterWeaponId = 23
            },
            
            new Attack {
                Id = 891,
                Name = "R1 (dash)",
                Damage = 1,
                ExtraDamage = 0,
                ExtraDamageCount = 0,
                AttackType1 = AttackType.Physical,
                AttackType2 = AttackType.None,
                AttackMode = AttackMode.Normal,
                TricksterWeaponId = 23
            },
            
            new Attack {
                Id = 892,
                Name = "R2",
                Damage = 1,
                ExtraDamage = 0,
                ExtraDamageCount = 0,
                AttackType1 = AttackType.Physical,
                AttackType2 = AttackType.None,
                AttackMode = AttackMode.Normal,
                TricksterWeaponId = 23
            },
            
            new Attack {
                Id = 893,
                Name = "R2 (charged)",
                Damage = 1,
                ExtraDamage = 0,
                ExtraDamageCount = 0,
                AttackType1 = AttackType.Physical,
                AttackType2 = AttackType.None,
                AttackMode = AttackMode.Normal,
                TricksterWeaponId = 23
            },
            
            new Attack {
                Id = 894,
                Name = "R2 (backstep)",
                Damage = 1,
                ExtraDamage = 0,
                ExtraDamageCount = 0,
                AttackType1 = AttackType.Physical,
                AttackType2 = AttackType.None,
                AttackMode = AttackMode.Normal,
                TricksterWeaponId = 23
            },
            
            new Attack {
                Id = 895,
                Name = "R2 (dash)",
                Damage = 1,
                ExtraDamage = 0,
                ExtraDamageCount = 0,
                AttackType1 = AttackType.Physical,
                AttackType2 = AttackType.None,
                AttackMode = AttackMode.Normal,
                TricksterWeaponId = 23
            },
            
            new Attack {
                Id = 896,
                Name = "R2 (forward leap)",
                Damage = 1,
                ExtraDamage = 0,
                ExtraDamageCount = 0,
                AttackType1 = AttackType.Thrust,
                AttackType2 = AttackType.None,
                AttackMode = AttackMode.Normal,
                TricksterWeaponId = 23
            },
            
            new Attack {
                Id = 897,
                Name = "Transform Attack",
                Damage = 1,
                ExtraDamage = 0,
                ExtraDamageCount = 0,
                AttackType1 = AttackType.Physical,
                AttackType2 = AttackType.None,
                AttackMode = AttackMode.Normal,
                TricksterWeaponId = 23
            },
            
            new Attack {
                Id = 898,
                Name = "Plunge Attack",
                Damage = 1,
                ExtraDamage = 0,
                ExtraDamageCount = 0,
                AttackType1 = AttackType.Thrust,
                AttackType2 = AttackType.None,
                AttackMode = AttackMode.Normal,
                TricksterWeaponId = 23
            },
            
            new Attack {
                Id = 899,
                Name = "Plunge Attack (2nd)",
                Damage = 0,
                ExtraDamage = 0,
                ExtraDamageCount = 0,
                AttackType1 = AttackType.Blunt,
                AttackType2 = AttackType.None,
                AttackMode = AttackMode.Normal,
                TricksterWeaponId = 23
            },
            
            new Attack {
                Id = 900,
                Name = "R1",
                Damage = 0,
                ExtraDamage = 0,
                ExtraDamageCount = 0,
                AttackType1 = AttackType.Physical,
                AttackType2 = AttackType.None,
                AttackMode = AttackMode.Transformed,
                TricksterWeaponId = 23
            },
            
            new Attack {
                Id = 901,
                Name = "R1 (2nd)",
                Damage = 1,
                ExtraDamage = 0,
                ExtraDamageCount = 0,
                AttackType1 = AttackType.Physical,
                AttackType2 = AttackType.None,
                AttackMode = AttackMode.Transformed,
                TricksterWeaponId = 23
            },
            
            new Attack {
                Id = 902,
                Name = "R1 (3rd)",
                Damage = 1,
                ExtraDamage = 0,
                ExtraDamageCount = 0,
                AttackType1 = AttackType.Physical,
                AttackType2 = AttackType.None,
                AttackMode = AttackMode.Transformed,
                TricksterWeaponId = 23
            },
            
            new Attack {
                Id = 903,
                Name = "R1 (4th)",
                Damage = 1,
                ExtraDamage = 0,
                ExtraDamageCount = 0,
                AttackType1 = AttackType.Physical,
                AttackType2 = AttackType.None,
                AttackMode = AttackMode.Transformed,
                TricksterWeaponId = 23
            },
            
            new Attack {
                Id = 904,
                Name = "R1 (backstep)",
                Damage = 0,
                ExtraDamage = 0,
                ExtraDamageCount = 0,
                AttackType1 = AttackType.Physical,
                AttackType2 = AttackType.None,
                AttackMode = AttackMode.Transformed,
                TricksterWeaponId = 23
            },
            
            new Attack {
                Id = 905,
                Name = "R1 (rolling)",
                Damage = 0,
                ExtraDamage = 0,
                ExtraDamageCount = 0,
                AttackType1 = AttackType.Physical,
                AttackType2 = AttackType.None,
                AttackMode = AttackMode.Transformed,
                TricksterWeaponId = 23
            },
            
            new Attack {
                Id = 906,
                Name = "R1 (frontstep)",
                Damage = 0,
                ExtraDamage = 0,
                ExtraDamageCount = 0,
                AttackType1 = AttackType.Physical,
                AttackType2 = AttackType.None,
                AttackMode = AttackMode.Transformed,
                TricksterWeaponId = 23
            },
            
            new Attack {
                Id = 907,
                Name = "R1 (sidestep)",
                Damage = 1,
                ExtraDamage = 0,
                ExtraDamageCount = 0,
                AttackType1 = AttackType.Physical,
                AttackType2 = AttackType.None,
                AttackMode = AttackMode.Transformed,
                TricksterWeaponId = 23
            },
            
            new Attack {
                Id = 908,
                Name = "R1 (dash)",
                Damage = 1,
                ExtraDamage = 0,
                ExtraDamageCount = 0,
                AttackType1 = AttackType.Physical,
                AttackType2 = AttackType.None,
                AttackMode = AttackMode.Transformed,
                TricksterWeaponId = 23
            },
            
            new Attack {
                Id = 909,
                Name = "R2",
                Damage = 1,
                ExtraDamage = 0,
                ExtraDamageCount = 0,
                AttackType1 = AttackType.Blunt,
                AttackType2 = AttackType.None,
                AttackMode = AttackMode.Transformed,
                TricksterWeaponId = 23
            },
            
            new Attack {
                Id = 910,
                Name = "R2 (charged)",
                Damage = 3,
                ExtraDamage = 0,
                ExtraDamageCount = 0,
                AttackType1 = AttackType.Blunt,
                AttackType2 = AttackType.None,
                AttackMode = AttackMode.Transformed,
                TricksterWeaponId = 23
            },

            new Attack {
                Id = 911,
                Name = "R2(forward leap)",
                Damage = 1,
                ExtraDamage = 0,
                ExtraDamageCount = 0,
                AttackType1 = AttackType.Blunt,
                AttackType2 = AttackType.None,
                AttackMode = AttackMode.Transformed,
                TricksterWeaponId = 23
            },
            
            new Attack {
                Id = 912,
                Name = "Transform Attack",
                Damage = 1,
                ExtraDamage = 0,
                ExtraDamageCount = 0,
                AttackType1 = AttackType.Physical,
                AttackType2 = AttackType.None,
                AttackMode = AttackMode.Transformed,
                TricksterWeaponId = 23
            },
            
            new Attack {
                Id = 913,
                Name = "Plunge Attack",
                Damage = 1,
                ExtraDamage = 0,
                ExtraDamageCount = 0,
                AttackType1 = AttackType.Physical,
                AttackType2 = AttackType.None,
                AttackMode = AttackMode.Transformed,
                TricksterWeaponId = 23
            },
            
            new Attack {
                Id = 914,
                Name = "Plunge Attack (2nd)",
                Damage = 0,
                ExtraDamage = 0,
                ExtraDamageCount = 0,
                AttackType1 = AttackType.Blunt,
                AttackType2 = AttackType.None,
                AttackMode = AttackMode.Transformed,
                TricksterWeaponId = 23
            },
            
            new Attack {
                Id = 915,
                Name = "R1",
                Damage = 1,
                ExtraDamage = 0,
                ExtraDamageCount = 0,
                AttackType1 = AttackType.Physical,
                AttackType2 = AttackType.None,
                AttackMode = AttackMode.Normal,
                TricksterWeaponId = 24
            },
            
            new Attack {
                Id = 916,
                Name = "R1 (2nd)",
                Damage = 1,
                ExtraDamage = 0,
                ExtraDamageCount = 0,
                AttackType1 = AttackType.Physical,
                AttackType2 = AttackType.None,
                AttackMode = AttackMode.Normal,
                TricksterWeaponId = 24
            },
            
            new Attack {
                Id = 917,
                Name = "R1 (3rd)",
                Damage = 1,
                ExtraDamage = 0,
                ExtraDamageCount = 0,
                AttackType1 = AttackType.Physical,
                AttackType2 = AttackType.None,
                AttackMode = AttackMode.Normal,
                TricksterWeaponId = 24
            },
            
            new Attack {
                Id = 918,
                Name = "R1 (backstep)",
                Damage = 1,
                ExtraDamage = 0,
                ExtraDamageCount = 0,
                AttackType1 = AttackType.Physical,
                AttackType2 = AttackType.None,
                AttackMode = AttackMode.Normal,
                TricksterWeaponId = 24
            },
            
            new Attack {
                Id = 919,
                Name = "R1 (rolling)",
                Damage = 1,
                ExtraDamage = 0,
                ExtraDamageCount = 0,
                AttackType1 = AttackType.Physical,
                AttackType2 = AttackType.None,
                AttackMode = AttackMode.Normal,
                TricksterWeaponId = 24
            },
            
            new Attack {
                Id = 920,
                Name = "R1 (frontstep)",
                Damage = 1,
                ExtraDamage = 0,
                ExtraDamageCount = 0,
                AttackType1 = AttackType.Physical,
                AttackType2 = AttackType.None,
                AttackMode = AttackMode.Normal,
                TricksterWeaponId = 24
            },
            
            new Attack {
                Id = 921,
                Name = "R1 (sidestep)",
                Damage = 1,
                ExtraDamage = 0,
                ExtraDamageCount = 0,
                AttackType1 = AttackType.Physical,
                AttackType2 = AttackType.None,
                AttackMode = AttackMode.Normal,
                TricksterWeaponId = 24
            },
            
            new Attack {
                Id = 922,
                Name = "R1 (dash)",
                Damage = 1,
                ExtraDamage = 0,
                ExtraDamageCount = 0,
                AttackType1 = AttackType.Physical,
                AttackType2 = AttackType.None,
                AttackMode = AttackMode.Normal,
                TricksterWeaponId = 24
            },
            
            new Attack {
                Id = 923,
                Name = "R2",
                Damage = 1,
                ExtraDamage = 0,
                ExtraDamageCount = 0,
                AttackType1 = AttackType.Thrust,
                AttackType2 = AttackType.None,
                AttackMode = AttackMode.Normal,
                TricksterWeaponId = 24
            },
            
            new Attack {
                Id = 924,
                Name = "R2 (charged)",
                Damage = 1,
                ExtraDamage = 0,
                ExtraDamageCount = 0,
                AttackType1 = AttackType.Thrust,
                AttackType2 = AttackType.None,
                AttackMode = AttackMode.Normal,
                TricksterWeaponId = 24
            },
            
            new Attack {
                Id = 925,
                Name = "R2 (backstep)",
                Damage = 1,
                ExtraDamage = 0,
                ExtraDamageCount = 0,
                AttackType1 = AttackType.Thrust,
                AttackType2 = AttackType.None,
                AttackMode = AttackMode.Normal,
                TricksterWeaponId = 24
            },
            
            new Attack {
                Id = 926,
                Name = "R2 (dash)",
                Damage = 1,
                ExtraDamage = 0,
                ExtraDamageCount = 0,
                AttackType1 = AttackType.Thrust,
                AttackType2 = AttackType.None,
                AttackMode = AttackMode.Normal,
                TricksterWeaponId = 24
            },
            
            new Attack {
                Id = 927,
                Name = "R2 (forward leap)",
                Damage = 1,
                ExtraDamage = 0,
                ExtraDamageCount = 0,
                AttackType1 = AttackType.Thrust,
                AttackType2 = AttackType.None,
                AttackMode = AttackMode.Normal,
                TricksterWeaponId = 24
            },
            
            new Attack {
                Id = 928,
                Name = "Transform Attack",
                Damage = 1,
                ExtraDamage = 0,
                ExtraDamageCount = 0,
                AttackType1 = AttackType.Physical,
                AttackType2 = AttackType.None,
                AttackMode = AttackMode.Normal,
                TricksterWeaponId = 24
            },
            
            new Attack {
                Id = 929,
                Name = "Plunge Attack",
                Damage = 1,
                ExtraDamage = 0,
                ExtraDamageCount = 0,
                AttackType1 = AttackType.Physical,
                AttackType2 = AttackType.None,
                AttackMode = AttackMode.Normal,
                TricksterWeaponId = 24
            },
            
            new Attack {
                Id = 930,
                Name = "Plunge Attack (2nd)",
                Damage = 0,
                ExtraDamage = 0,
                ExtraDamageCount = 0,
                AttackType1 = AttackType.Blunt,
                AttackType2 = AttackType.None,
                AttackMode = AttackMode.Normal,
                TricksterWeaponId = 24
            },
            
            new Attack {
                Id = 931,
                Name = "R1",
                Damage = 0,
                ExtraDamage = 0,
                ExtraDamageCount = 0,
                AttackType1 = AttackType.Physical,
                AttackType2 = AttackType.None,
                AttackMode = AttackMode.Transformed,
                TricksterWeaponId = 24
            },
            
            new Attack {
                Id = 932,
                Name = "R1 (2nd)",
                Damage = 0,
                ExtraDamage = 0,
                ExtraDamageCount = 0,
                AttackType1 = AttackType.Physical,
                AttackType2 = AttackType.None,
                AttackMode = AttackMode.Transformed,
                TricksterWeaponId = 24
            },
            
            new Attack {
                Id = 933,
                Name = "R1 (3rd)",
                Damage = 1,
                ExtraDamage = 0,
                ExtraDamageCount = 0,
                AttackType1 = AttackType.Physical,
                AttackType2 = AttackType.None,
                AttackMode = AttackMode.Transformed,
                TricksterWeaponId = 24
            },
            
            new Attack {
                Id = 934,
                Name = "R1 (backstep)",
                Damage = 1,
                ExtraDamage = 0,
                ExtraDamageCount = 0,
                AttackType1 = AttackType.Thrust,
                AttackType2 = AttackType.None,
                AttackMode = AttackMode.Transformed,
                TricksterWeaponId = 24
            },
            
            new Attack {
                Id = 935,
                Name = "R1 (rolling)",
                Damage = 0,
                ExtraDamage = 0,
                ExtraDamageCount = 0,
                AttackType1 = AttackType.Physical,
                AttackType2 = AttackType.None,
                AttackMode = AttackMode.Transformed,
                TricksterWeaponId = 24
            },
            
            new Attack {
                Id = 936,
                Name = "R1 (frontstep)",
                Damage = 0,
                ExtraDamage = 0,
                ExtraDamageCount = 0,
                AttackType1 = AttackType.Physical,
                AttackType2 = AttackType.None,
                AttackMode = AttackMode.Transformed,
                TricksterWeaponId = 24
            },
            
            new Attack {
                Id = 937,
                Name = "R1 (sidestep)",
                Damage = 0,
                ExtraDamage = 0,
                ExtraDamageCount = 0,
                AttackType1 = AttackType.Physical,
                AttackType2 = AttackType.None,
                AttackMode = AttackMode.Transformed,
                TricksterWeaponId = 24
            },
            
            new Attack {
                Id = 938,
                Name = "R1 (dash)",
                Damage = 1,
                ExtraDamage = 0,
                ExtraDamageCount = 0,
                AttackType1 = AttackType.Physical,
                AttackType2 = AttackType.None,
                AttackMode = AttackMode.Transformed,
                TricksterWeaponId = 24
            },
            
            new Attack {
                Id = 939,
                Name = "R2",
                Damage = 1,
                ExtraDamage = 0,
                ExtraDamageCount = 0,
                AttackType1 = AttackType.Physical,
                AttackType2 = AttackType.None,
                AttackMode = AttackMode.Transformed,
                TricksterWeaponId = 24
            },
            
            new Attack {
                Id = 940,
                Name = "R2 (2nd)",
                Damage = 1,
                ExtraDamage = 0,
                ExtraDamageCount = 0,
                AttackType1 = AttackType.Physical,
                AttackType2 = AttackType.None,
                AttackMode = AttackMode.Transformed,
                TricksterWeaponId = 24
            },
            
            new Attack {
                Id = 941,
                Name = "R2 (backstep)",
                Damage = 1,
                ExtraDamage = 0,
                ExtraDamageCount = 0,
                AttackType1 = AttackType.Thrust,
                AttackType2 = AttackType.None,
                AttackMode = AttackMode.Transformed,
                TricksterWeaponId = 24
            },
            
            new Attack {
                Id = 942,
                Name = "R2 (dash)",
                Damage = 1,
                ExtraDamage = 0,
                ExtraDamageCount = 0,
                AttackType1 = AttackType.Physical,
                AttackType2 = AttackType.None,
                AttackMode = AttackMode.Transformed,
                TricksterWeaponId = 24
            },
            
            new Attack {
                Id = 943,
                Name = "R2(forward leap)",
                Damage = 1,
                ExtraDamage = 0,
                ExtraDamageCount = 0,
                AttackType1 = AttackType.Physical,
                AttackType2 = AttackType.None,
                AttackMode = AttackMode.Transformed,
                TricksterWeaponId = 24
            },
            
            new Attack {
                Id = 944,
                Name = "Transform Attack",
                Damage = 1,
                ExtraDamage = 0,
                ExtraDamageCount = 0,
                AttackType1 = AttackType.Thrust,
                AttackType2 = AttackType.None,
                AttackMode = AttackMode.Transformed,
                TricksterWeaponId = 24
            },
            
            new Attack {
                Id = 945,
                Name = "Plunge Attack",
                Damage = 1,
                ExtraDamage = 0,
                ExtraDamageCount = 0,
                AttackType1 = AttackType.Physical,
                AttackType2 = AttackType.None,
                AttackMode = AttackMode.Transformed,
                TricksterWeaponId = 24
            },
            
            new Attack {
                Id = 946,
                Name = "Plunge Attack (2nd)",
                Damage = 0,
                ExtraDamage = 0,
                ExtraDamageCount = 0,
                AttackType1 = AttackType.Blunt,
                AttackType2 = AttackType.None,
                AttackMode = AttackMode.Transformed,
                TricksterWeaponId = 24
            },
            
            new Attack {
                Id = 947,
                Name = "R1",
                Damage = 1,
                ExtraDamage = 0,
                ExtraDamageCount = 0,
                AttackType1 = AttackType.Blunt,
                AttackType2 = AttackType.Bolt,
                AttackMode = AttackMode.Normal,
                TricksterWeaponId = 25
            },
            
            new Attack {
                Id = 948,
                Name = "R1 (2nd)",
                Damage = 1,
                ExtraDamage = 0,
                ExtraDamageCount = 0,
                AttackType1 = AttackType.Blunt,
                AttackType2 = AttackType.Bolt,
                AttackMode = AttackMode.Normal,
                TricksterWeaponId = 25
            },
            
            new Attack {
                Id = 949,
                Name = "R1 (3rd)",
                Damage = 1,
                ExtraDamage = 0,
                ExtraDamageCount = 0,
                AttackType1 = AttackType.Blunt,
                AttackType2 = AttackType.Bolt,
                AttackMode = AttackMode.Normal,
                TricksterWeaponId = 25
            },
            
            new Attack {
                Id = 950,
                Name = "R1 (4th)",
                Damage = 1,
                ExtraDamage = 0,
                ExtraDamageCount = 0,
                AttackType1 = AttackType.Blunt,
                AttackType2 = AttackType.Bolt,
                AttackMode = AttackMode.Normal,
                TricksterWeaponId = 25
            },
            
            new Attack {
                Id = 951,
                Name = "R1 (5th)",
                Damage = 1,
                ExtraDamage = 0,
                ExtraDamageCount = 0,
                AttackType1 = AttackType.Blunt,
                AttackType2 = AttackType.Bolt,
                AttackMode = AttackMode.Normal,
                TricksterWeaponId = 25
            },
            
            new Attack {
                Id = 952,
                Name = "R1 (backstep)",
                Damage = 0,
                ExtraDamage = 0,
                ExtraDamageCount = 0,
                AttackType1 = AttackType.Blunt,
                AttackType2 = AttackType.Bolt,
                AttackMode = AttackMode.Normal,
                TricksterWeaponId = 25
            },
            
            new Attack {
                Id = 953,
                Name = "R1 (rolling)",
                Damage = 0,
                ExtraDamage = 0,
                ExtraDamageCount = 0,
                AttackType1 = AttackType.Blunt,
                AttackType2 = AttackType.Bolt,
                AttackMode = AttackMode.Normal,
                TricksterWeaponId = 25
            },
            
            new Attack {
                Id = 954,
                Name = "R1 (frontstep)",
                Damage = 0,
                ExtraDamage = 0,
                ExtraDamageCount = 0,
                AttackType1 = AttackType.Blunt,
                AttackType2 = AttackType.Bolt,
                AttackMode = AttackMode.Normal,
                TricksterWeaponId = 25
            },
            
            new Attack {
                Id = 955,
                Name = "R1 (sidestep)",
                Damage = 0,
                ExtraDamage = 0,
                ExtraDamageCount = 0,
                AttackType1 = AttackType.Blunt,
                AttackType2 = AttackType.Bolt,
                AttackMode = AttackMode.Normal,
                TricksterWeaponId = 25
            },
            
            new Attack {
                Id = 956,
                Name = "R1 (dash)",
                Damage = 1,
                ExtraDamage = 0,
                ExtraDamageCount = 0,
                AttackType1 = AttackType.Blunt,
                AttackType2 = AttackType.Bolt,
                AttackMode = AttackMode.Normal,
                TricksterWeaponId = 25
            },
            
            new Attack {
                Id = 957,
                Name = "R2",
                Damage = 1,
                ExtraDamage = 0,
                ExtraDamageCount = 0,
                AttackType1 = AttackType.Blunt,
                AttackType2 = AttackType.Bolt,
                AttackMode = AttackMode.Normal,
                TricksterWeaponId = 25
            },
            
            new Attack {
                Id = 958,
                Name = "R2 (charged)",
                Damage = 1,
                ExtraDamage = 0,
                ExtraDamageCount = 0,
                AttackType1 = AttackType.Blunt,
                AttackType2 = AttackType.Bolt,
                AttackMode = AttackMode.Normal,
                TricksterWeaponId = 25
            },
            
            new Attack {
                Id = 959,
                Name = "R2 (backstep)",
                Damage = 1,
                ExtraDamage = 0,
                ExtraDamageCount = 0,
                AttackType1 = AttackType.Blunt,
                AttackType2 = AttackType.Bolt,
                AttackMode = AttackMode.Normal,
                TricksterWeaponId = 25
            },
            
            new Attack {
                Id = 960,
                Name = "R2 (dash)",
                Damage = 1,
                ExtraDamage = 0,
                ExtraDamageCount = 0,
                AttackType1 = AttackType.Blunt,
                AttackType2 = AttackType.Bolt,
                AttackMode = AttackMode.Normal,
                TricksterWeaponId = 25
            },
            
            new Attack {
                Id = 961,
                Name = "R2 (forward leap)",
                Damage = 1,
                ExtraDamage = 0,
                ExtraDamageCount = 0,
                AttackType1 = AttackType.Blunt,
                AttackType2 = AttackType.Bolt,
                AttackMode = AttackMode.Normal,
                TricksterWeaponId = 25
            },
            
            new Attack {
                Id = 962,
                Name = "Transform Attack",
                Damage = 1,
                ExtraDamage = 0,
                ExtraDamageCount = 0,
                AttackType1 = AttackType.Blunt,
                AttackType2 = AttackType.Bolt,
                AttackMode = AttackMode.Normal,
                TricksterWeaponId = 25
            },
            
            new Attack {
                Id = 963,
                Name = "Plunge Attack",
                Damage = 1,
                ExtraDamage = 0,
                ExtraDamageCount = 0,
                AttackType1 = AttackType.Blunt,
                AttackType2 = AttackType.Bolt,
                AttackMode = AttackMode.Normal,
                TricksterWeaponId = 25
            },
            
            new Attack {
                Id = 964,
                Name = "Plunge Attack (2nd)",
                Damage = 0,
                ExtraDamage = 0,
                ExtraDamageCount = 0,
                AttackType1 = AttackType.Blunt,
                AttackType2 = AttackType.Bolt,
                AttackMode = AttackMode.Normal,
                TricksterWeaponId = 25
            },
            
            new Attack {
                Id = 965,
                Name = "R1",
                Damage = 0,
                ExtraDamage = 0,
                ExtraDamageCount = 0,
                AttackType1 = AttackType.Blunt,
                AttackType2 = AttackType.None,
                AttackMode = AttackMode.Normal,
                TricksterWeaponId = 26
            },
            
            new Attack {
                Id = 966,
                Name = "→ R1 (2nd)",
                Damage = 0,
                ExtraDamage = 0,
                ExtraDamageCount = 0,
                AttackType1 = AttackType.Blunt,
                AttackType2 = AttackType.None,
                AttackMode = AttackMode.Normal,
                TricksterWeaponId = 26
            },
            
            new Attack {
                Id = 967,
                Name = "→ → R1 (3rd)",
                Damage = 0,
                ExtraDamage = 0,
                ExtraDamageCount = 0,
                AttackType1 = AttackType.Blunt,
                AttackType2 = AttackType.None,
                AttackMode = AttackMode.Normal,
                TricksterWeaponId = 26
            },
            
            new Attack {
                Id = 968,
                Name = "→ → → R1 (4th)",
                Damage = 0,
                ExtraDamage = 0,
                ExtraDamageCount = 0,
                AttackType1 = AttackType.Thrust,
                AttackType2 = AttackType.None,
                AttackMode = AttackMode.Normal,
                TricksterWeaponId = 26
            },
            
            new Attack {
                Id = 969,
                Name = "R1 (backstep)",
                Damage = 0,
                ExtraDamage = 0,
                ExtraDamageCount = 0,
                AttackType1 = AttackType.Thrust,
                AttackType2 = AttackType.None,
                AttackMode = AttackMode.Normal,
                TricksterWeaponId = 26
            },
            
            new Attack {
                Id = 970,
                Name = "R1 (rolling)",
                Damage = 0,
                ExtraDamage = 0,
                ExtraDamageCount = 0,
                AttackType1 = AttackType.Blunt,
                AttackType2 = AttackType.None,
                AttackMode = AttackMode.Normal,
                TricksterWeaponId = 26
            },
            
            new Attack {
                Id = 971,
                Name = "R1 (frontstep)",
                Damage = 0,
                ExtraDamage = 0,
                ExtraDamageCount = 0,
                AttackType1 = AttackType.Blunt,
                AttackType2 = AttackType.None,
                AttackMode = AttackMode.Normal,
                TricksterWeaponId = 26
            },
            
            new Attack {
                Id = 972,
                Name = "R1 (sidestep)",
                Damage = 0,
                ExtraDamage = 0,
                ExtraDamageCount = 0,
                AttackType1 = AttackType.Blunt,
                AttackType2 = AttackType.None,
                AttackMode = AttackMode.Normal,
                TricksterWeaponId = 26
            },
            
            new Attack {
                Id = 973,
                Name = "R1 (dash)",
                Damage = 0,
                ExtraDamage = 0,
                ExtraDamageCount = 0,
                AttackType1 = AttackType.Thrust,
                AttackType2 = AttackType.None,
                AttackMode = AttackMode.Normal,
                TricksterWeaponId = 26
            },
            
            new Attack {
                Id = 974,
                Name = "R2",
                Damage = 1,
                ExtraDamage = 0,
                ExtraDamageCount = 0,
                AttackType1 = AttackType.Blunt,
                AttackType2 = AttackType.None,
                AttackMode = AttackMode.Normal,
                TricksterWeaponId = 26
            },
            
            new Attack {
                Id = 975,
                Name = "R2 (charged)",
                Damage = 1,
                ExtraDamage = 0,
                ExtraDamageCount = 0,
                AttackType1 = AttackType.Blunt,
                AttackType2 = AttackType.None,
                AttackMode = AttackMode.Normal,
                TricksterWeaponId = 26
            },
            
            new Attack {
                Id = 976,
                Name = "R2 (backstep)",
                Damage = 1,
                ExtraDamage = 0,
                ExtraDamageCount = 0,
                AttackType1 = AttackType.Blunt,
                AttackType2 = AttackType.None,
                AttackMode = AttackMode.Normal,
                TricksterWeaponId = 26
            },
            
            new Attack {
                Id = 977,
                Name = "R2 (dash)",
                Damage = 1,
                ExtraDamage = 0,
                ExtraDamageCount = 0,
                AttackType1 = AttackType.Blunt,
                AttackType2 = AttackType.None,
                AttackMode = AttackMode.Normal,
                TricksterWeaponId = 26
            },
            
            new Attack {
                Id = 978,
                Name = "R2 (forward leap)",
                Damage = 1,
                ExtraDamage = 0,
                ExtraDamageCount = 0,
                AttackType1 = AttackType.Blunt,
                AttackType2 = AttackType.None,
                AttackMode = AttackMode.Normal,
                TricksterWeaponId = 26
            },
            
            new Attack {
                Id = 979,
                Name = "Transform Attack",
                Damage = 1,
                ExtraDamage = 0,
                ExtraDamageCount = 0,
                AttackType1 = AttackType.Physical,
                AttackType2 = AttackType.None,
                AttackMode = AttackMode.Normal,
                TricksterWeaponId = 26
            },
            
            new Attack {
                Id = 980,
                Name = "Plunge Attack",
                Damage = 1,
                ExtraDamage = 0,
                ExtraDamageCount = 0,
                AttackType1 = AttackType.Blunt,
                AttackType2 = AttackType.None,
                AttackMode = AttackMode.Normal,
                TricksterWeaponId = 26
            },
            
            new Attack {
                Id = 981,
                Name = "Plunge Attack (2nd hit)",
                Damage = 0,
                ExtraDamage = 0,
                ExtraDamageCount = 0,
                AttackType1 = AttackType.Blunt,
                AttackType2 = AttackType.None,
                AttackMode = AttackMode.Normal,
                TricksterWeaponId = 26
            },
            
            new Attack {
                Id = 982,
                Name = "R1",
                Damage = 1,
                ExtraDamage = 0,
                ExtraDamageCount = 0,
                AttackType1 = AttackType.Physical,
                AttackType2 = AttackType.None,
                AttackMode = AttackMode.Transformed,
                TricksterWeaponId = 26
            },
            
            new Attack {
                Id = 983,
                Name = "→ R1 (2nd)",
                Damage = 1,
                ExtraDamage = 0,
                ExtraDamageCount = 0,
                AttackType1 = AttackType.Physical,
                AttackType2 = AttackType.None,
                AttackMode = AttackMode.Transformed,
                TricksterWeaponId = 26
            },
            
            new Attack {
                Id = 984,
                Name = "→ → R1 (3rd)",
                Damage = 1,
                ExtraDamage = 0,
                ExtraDamageCount = 0,
                AttackType1 = AttackType.Physical,
                AttackType2 = AttackType.None,
                AttackMode = AttackMode.Transformed,
                TricksterWeaponId = 26
            },
            
            new Attack {
                Id = 985,
                Name = "→ → → R1 (4th)",
                Damage = 1,
                ExtraDamage = 0,
                ExtraDamageCount = 2,
                AttackType1 = AttackType.Physical,
                AttackType2 = AttackType.None,
                AttackMode = AttackMode.Transformed,
                TricksterWeaponId = 26
            },
            
            new Attack {
                Id = 986,
                Name = "R1 (backstep)",
                Damage = 1,
                ExtraDamage = 0,
                ExtraDamageCount = 0,
                AttackType1 = AttackType.Physical,
                AttackType2 = AttackType.None,
                AttackMode = AttackMode.Transformed,
                TricksterWeaponId = 26
            },
            
            new Attack {
                Id = 987,
                Name = "R1 (rolling)",
                Damage = 0,
                ExtraDamage = 0,
                ExtraDamageCount = 0,
                AttackType1 = AttackType.Physical,
                AttackType2 = AttackType.None,
                AttackMode = AttackMode.Transformed,
                TricksterWeaponId = 26
            },
            
            new Attack {
                Id = 988,
                Name = "R1 (frontstep)",
                Damage = 0,
                ExtraDamage = 0,
                ExtraDamageCount = 0,
                AttackType1 = AttackType.Physical,
                AttackType2 = AttackType.None,
                AttackMode = AttackMode.Transformed,
                TricksterWeaponId = 26
            },
            
            new Attack {
                Id = 989,
                Name = "R1 (sidestep)",
                Damage = 0,
                ExtraDamage = 0,
                ExtraDamageCount = 0,
                AttackType1 = AttackType.Physical,
                AttackType2 = AttackType.None,
                AttackMode = AttackMode.Transformed,
                TricksterWeaponId = 26
            },
            
            new Attack {
                Id = 990,
                Name = "R1 (dash)",
                Damage = 1,
                ExtraDamage = 0,
                ExtraDamageCount = 0,
                AttackType1 = AttackType.Physical,
                AttackType2 = AttackType.None,
                AttackMode = AttackMode.Transformed,
                TricksterWeaponId = 26
            },
            
            new Attack {
                Id = 991,
                Name = "R2",
                Damage = 1,
                ExtraDamage = 0,
                ExtraDamageCount = 0,
                AttackType1 = AttackType.Physical,
                AttackType2 = AttackType.None,
                AttackMode = AttackMode.Transformed,
                TricksterWeaponId = 26
            },
            
            new Attack {
                Id = 992,
                Name = "R2 (charged)",
                Damage = 1,
                ExtraDamage = 0,
                ExtraDamageCount = 3,
                AttackType1 = AttackType.Blunt,
                AttackType2 = AttackType.None,
                AttackMode = AttackMode.Transformed,
                TricksterWeaponId = 26
            },
            
            new Attack {
                Id = 993,
                Name = "R2 (backstep)",
                Damage = 1,
                ExtraDamage = 0,
                ExtraDamageCount = 2,
                AttackType1 = AttackType.Blunt,
                AttackType2 = AttackType.None,
                AttackMode = AttackMode.Transformed,
                TricksterWeaponId = 26
            },
            
            new Attack {
                Id = 994,
                Name = "R2 (dash)",
                Damage = 1,
                ExtraDamage = 0,
                ExtraDamageCount = 0,
                AttackType1 = AttackType.Physical,
                AttackType2 = AttackType.None,
                AttackMode = AttackMode.Transformed,
                TricksterWeaponId = 26
            },
            
            new Attack {
                Id = 995,
                Name = "R2 (forward leap)",
                Damage = 1,
                ExtraDamage = 0,
                ExtraDamageCount = 2,
                AttackType1 = AttackType.Blunt,
                AttackType2 = AttackType.None,
                AttackMode = AttackMode.Transformed,
                TricksterWeaponId = 26
            },
            
            new Attack {
                Id = 996,
                Name = "L2",
                Damage = 0,
                ExtraDamage = 0,
                ExtraDamageCount = 0,
                AttackType1 = AttackType.Physical,
                AttackType2 = AttackType.None,
                AttackMode = AttackMode.Transformed,
                TricksterWeaponId = 26
            },

            new Attack {
                Id = 997,
                Name = "L2 (held 1)",
                Damage = 0,
                ExtraDamage = 0,
                ExtraDamageCount = 0,
                AttackType1 = AttackType.Physical,
                AttackType2 = AttackType.None,
                AttackMode = AttackMode.Transformed,
                TricksterWeaponId = 26
            },
            
            new Attack {
                Id = 998,
                Name = "L2 (held 2)",
                Damage = 0,
                ExtraDamage = 0,
                ExtraDamageCount = 0,
                AttackType1 = AttackType.Physical,
                AttackType2 = AttackType.None,
                AttackMode = AttackMode.Transformed,
                TricksterWeaponId = 26
            },
            
            new Attack {
                Id = 999,
                Name = "L2 (held 3)",
                Damage = 0,
                ExtraDamage = 0,
                ExtraDamageCount = 0,
                AttackType1 = AttackType.Physical,
                AttackType2 = AttackType.None,
                AttackMode = AttackMode.Transformed,
                TricksterWeaponId = 26
            },
            
            new Attack {
                Id = 1000,
                Name = "Transform Attack",
                Damage = 1,
                ExtraDamage = 0,
                ExtraDamageCount = 0,
                AttackType1 = AttackType.Blunt,
                AttackType2 = AttackType.None,
                AttackMode = AttackMode.Transformed,
                TricksterWeaponId = 26
            },
            
            new Attack {
                Id = 1001,
                Name = "Plunge Attack",
                Damage = 1,
                ExtraDamage = 0,
                ExtraDamageCount = 0,
                AttackType1 = AttackType.Physical,
                AttackType2 = AttackType.None,
                AttackMode = AttackMode.Transformed,
                TricksterWeaponId = 26
            },
            
            new Attack {
                Id = 1002,
                Name = "Plunge Attack (2nd hit)",
                Damage = 0,
                ExtraDamage = 0,
                ExtraDamageCount = 0,
                AttackType1 = AttackType.Blunt,
                AttackType2 = AttackType.None,
                AttackMode = AttackMode.Transformed,
                TricksterWeaponId = 26
            },
        };

        await _context.Attacks.AddRangeAsync(attacks);
        await _context.SaveChangesAsync();
    }

}