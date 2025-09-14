using System;
using System.Collections.Generic;

namespace Clockies
{

    public static class NamedItems
    {
        public static INamedItem Rebirth { get; set; }
        public static INamedItem Restart { get; set; }

        public static List<INamedItem> All { get; private set; }

        public static void Init()
        {
            Rebirth = NamedItem.Default;
            Rebirth.Name = () =>
            {
                return "Rebirth";
            };
            Rebirth.Description = () =>
            {
                RebirthsManager rebirthsManager = Vars.Instance.rebirthsManager;

                return $"If you have enough money, you can reborn, all your buildings and money will disappear but you will get bonuses {rebirthsManager.GetFormattedRebirthsBonuses()}, to win you need to reborn {RebirthsManager.neededRebirths} times, the current rebirth costs {rebirthsManager.GetRebithPrice()} hours";
            };

            Restart = NamedItem.Default;
            Restart.Name = () =>
            {
                return "Restart";
            };
            Restart.Description = () =>
            {
                return "If you made a terrible mistake, you can start all over again";
            };
        }
    }

    public class NamedItem : INamedItem
    {
        public Func<string> Name { get; set; }
        public Func<string> Description { get; set; }

        // public void Init()
        // {
        //     RebirthsManager rebirthsManager = Vars.Instance.rebirthsManager;

        //     Name = () =>
        //     {
        //         return "Rebirth";
        //     };
        //     Description = () =>
        //     {
        //         return $"If you have enough money, you can reborn, all your buildings and money will disappear but you will get bonuses {rebirthsManager.GetFormattedRebirthsBonuses()}, to win you need to respawn {RebirthsManager.neededRebirths} times, the current respawn costs {rebirthsManager.GetRebithPrice()} hours.";
        //     };
        // }

        public static NamedItem Default
        {
            get
            {
                return new NamedItem()
                {
                    Name = () =>
                    {
                        return "";
                    },
                    Description = () =>
                    {
                        return "";
                    }
                };
            }
        }
    }

    public interface INamedItem
    {
        public Func<string> Name { get; set; }
        public Func<string> Description { get; set; }
    }
}