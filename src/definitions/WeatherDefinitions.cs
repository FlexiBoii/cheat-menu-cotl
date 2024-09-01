using HarmonyLib;
using UnityEngine;
using System.Collections.Generic;

namespace CheatMenu
{
    [CheatCategory(CheatCategoryEnum.WEATHER)]
    public class WeatherDefinitions : IDefinition
    {
        private static readonly Dictionary<string, WeatherSystemController.WeatherStrength> strengthMap = new Dictionary<string, WeatherSystemController.WeatherStrength>
        {
            {"Light", WeatherSystemController.WeatherStrength.Light},
            {"Medium", WeatherSystemController.WeatherStrength.Medium},
            {"Heavy", WeatherSystemController.WeatherStrength.Heavy}
        };

        [CheatDetails("Weather: Rain", "Set weather to raining")]
        public static void WeatherRain()
        {
            ShowStrengthOptions(WeatherSystemController.WeatherType.Raining);
        }

        [CheatDetails("Weather: Windy", "Set weather to windy")]
        public static void WeatherWindy()
        {
            ShowStrengthOptions(WeatherSystemController.WeatherType.Windy);
        }

        [CheatDetails("Weather: Snow", "Set weather to snowing")]
        public static void WeatherSnow()
        {
            ShowStrengthOptions(WeatherSystemController.WeatherType.Snowing);
        }

        [CheatDetails("Weather: Heat", "Set weather to heat")]
        public static void WeatherHeat()
        {
            ShowStrengthOptions(WeatherSystemController.WeatherType.Heat);
        }

        [CheatDetails("Weather: Clear", "Set weather to clear")]
        public static void WeatherClear()
        {
            if (WeatherSystemController.Instance != null)
            {
                WeatherSystemController.Instance.StopCurrentWeather();
            }
        }

        private static void ShowStrengthOptions(WeatherSystemController.WeatherType type)
        {
            // This method should display a UI with strength options.
            // For now, we'll just print to the console. Replace this with your mod's UI system.
            Debug.Log($"Select strength for {type}:");
            foreach (var strength in strengthMap.Keys)
            {
                Debug.Log($"- {strength}");
            }

            // For demonstration, we'll set it to Medium. In a real scenario, you'd wait for user input.
            SetWeather(type, WeatherSystemController.WeatherStrength.Medium);
        }

        // This method would be called when the user selects a strength option
        public static void SetWeatherWithStrength(WeatherSystemController.WeatherType type, string strength)
        {
            if (strengthMap.TryGetValue(strength, out var weatherStrength))
            {
                SetWeather(type, weatherStrength);
            }
            else
            {
                Debug.LogError($"Invalid weather strength: {strength}");
            }
        }

        private static void SetWeather(WeatherSystemController.WeatherType type, WeatherSystemController.WeatherStrength strength)
        {
            if (WeatherSystemController.Instance != null)
            {
                WeatherSystemController.Instance.SetWeather(type, strength);
                Debug.Log($"Weather set to {type} with strength {strength}");
            }
            else
            {
                Debug.LogError("WeatherSystemController.Instance is null");
            }
        }
    }
}