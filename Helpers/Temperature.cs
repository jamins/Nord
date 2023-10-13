namespace Nord.Helpers
{
    public class Temperature
    {
        public static string Summary(int TemperatureC)
        {
            switch (TemperatureC)
            {
                case < -10: return "Freezing";
                case >= -10 and < -5: return "Bracing";
                case >= -15 and < 0: return "Chilly";
                case >= 0 and < 10: return "Cool";
                case >= 10 and < 20: return "Mild";
                case >= 20 and < 30: return "Warm";
                case >= 30 and < 40: return "Hot";
                case >= 40 and < 50: return "Sweltering";
                case >= 50: return "Scorching";
            }
        }

    }
}
