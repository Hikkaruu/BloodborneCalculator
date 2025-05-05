using api.Models.Entities;

namespace api.Helpers
{
    public class WeaponCalculationHelper
    {
        private Dictionary<int, double> saturationTable = new()
            {
                { 5, 0.025 }, { 6, 0.030 }, { 7, 0.035 }, { 8, 0.040 }, { 9, 0.045 },
                { 10, 0.050 }, { 11, 0.080 }, { 12, 0.110 }, { 13, 0.140 }, { 14, 0.170 },
                { 15, 0.200 }, { 16, 0.230 }, { 17, 0.260 }, { 18, 0.290 }, { 19, 0.320 },
                { 20, 0.350 }, { 21, 0.380 }, { 22, 0.410 }, { 23, 0.440 }, { 24, 0.470 },
                { 25, 0.500 }, { 26, 0.514 }, { 27, 0.528 }, { 28, 0.542 }, { 29, 0.556 },
                { 30, 0.570 }, { 31, 0.584 }, { 32, 0.598 }, { 33, 0.612 }, { 34, 0.626 },
                { 35, 0.640 }, { 36, 0.654 }, { 37, 0.668 }, { 38, 0.682 }, { 39, 0.696 },
                { 40, 0.710 }, { 41, 0.724 }, { 42, 0.738 }, { 43, 0.752 }, { 44, 0.766 },
                { 45, 0.780 }, { 46, 0.794 }, { 47, 0.808 }, { 48, 0.822 }, { 49, 0.836 },
                { 50, 0.850 }, { 51, 0.853 }, { 52, 0.856 }, { 53, 0.859 }, { 54, 0.862 },
                { 55, 0.865 }, { 56, 0.868 }, { 57, 0.871 }, { 58, 0.874 }, { 59, 0.878 },
                { 60, 0.881 }, { 61, 0.884 }, { 62, 0.887 }, { 63, 0.890 }, { 64, 0.893 },
                { 65, 0.896 }, { 66, 0.899 }, { 67, 0.902 }, { 68, 0.905 }, { 69, 0.908 },
                { 70, 0.911 }, { 71, 0.914 }, { 72, 0.917 }, { 73, 0.920 }, { 74, 0.923 },
                { 75, 0.927 }, { 76, 0.930 }, { 77, 0.933 }, { 78, 0.936 }, { 79, 0.939 },
                { 80, 0.942 }, { 81, 0.945 }, { 82, 0.948 }, { 83, 0.951 }, { 84, 0.954 },
                { 85, 0.957 }, { 86, 0.960 }, { 87, 0.963 }, { 88, 0.966 }, { 89, 0.969 },
                { 90, 0.972 }, { 91, 0.975 }, { 92, 0.979 }, { 93, 0.982 }, { 94, 0.985 },
                { 95, 0.988 }, { 96, 0.991 }, { 97, 0.994 }, { 98, 0.997 }, { 99, 1.000 }
            };

        public double getSaturation(int atributeValue)
        {
            if (atributeValue > 99 || atributeValue < 5) throw new ArgumentOutOfRangeException("atributeValue must be <5, 99>");
            return saturationTable.TryGetValue(atributeValue, out double saturation) ? saturation : throw new KeyNotFoundException("No saturation found for this key");
        }

        public double getScaling(decimal strengthScaling, decimal strengthStep, int weaponUpgradeLevel)
        {
            if (weaponUpgradeLevel < 0 || weaponUpgradeLevel > 10)
                throw new ArgumentOutOfRangeException("weaponUpgradeLevel must be between 0 and 10 inclusive");

            return (double)(strengthScaling + strengthStep * weaponUpgradeLevel);
        }
    }
}
