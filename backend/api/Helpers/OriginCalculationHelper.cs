using api.Models.Entities;

namespace api.Helpers
{
    public class OriginCalculationHelper
    {
        private void ValidateStatRange(int value, string paramName)
        {
            if (value < 0 || value > 99)
                throw new ArgumentOutOfRangeException(paramName, $"{paramName} must be between 0 and 99");
        }

        private void ValidateStats(Origin origin, int desiredVitality, int desiredEndurance, 
            int desiredStrength, int desiredSkill, int desiredBloodtinge, int desiredArcane)
        {
            if (origin == null)
                throw new ArgumentNullException(nameof(origin));

            ValidateStatRange(desiredVitality, nameof(desiredVitality));
            ValidateStatRange(desiredEndurance, nameof(desiredEndurance));
            ValidateStatRange(desiredStrength, nameof(desiredStrength));
            ValidateStatRange(desiredSkill, nameof(desiredSkill));
            ValidateStatRange(desiredBloodtinge, nameof(desiredBloodtinge));
            ValidateStatRange(desiredArcane, nameof(desiredArcane));
        }

        public int CalculateLevelForOrigin(Origin origin, int desiredVitality, int desiredEndurance, 
            int desiredStrength, int desiredSkill, int desiredBloodtinge, int desiredArcane)
        {
            ValidateStats(origin, desiredVitality, desiredEndurance, desiredStrength, desiredSkill, desiredBloodtinge, desiredArcane);

            int level = origin.Level;

            if (desiredVitality > origin.Vitality)
                level += desiredVitality - origin.Vitality;
            if (desiredEndurance > origin.Endurance)
                level += desiredEndurance - origin.Endurance;
            if (desiredStrength > origin.Strength)
                level += desiredStrength - origin.Strength;
            if (desiredSkill > origin.Skill)
                level += desiredSkill - origin.Skill;
            if (desiredBloodtinge > origin.Bloodtinge)
                level += desiredBloodtinge - origin.Bloodtinge;
            if (desiredArcane > origin.Arcane)
                level += desiredArcane - origin.Arcane;

            return level;
        }
    }
}
