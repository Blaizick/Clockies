using System;
using System.Collections.Generic;
using UnityEngine;

namespace Clockies
{
    public class PurchasesDataInjector : MonoBehaviour
    {
        public PurchaseData laborWorkers;
        public PurchaseData basements;
        public PurchaseData factory;
        public PurchaseData mafia;
        public PurchaseData country;
        public PurchaseData competitorExecutionSquad;
        public PurchaseData slaves;
        public PurchaseData molecularReassemler;
        public PurchaseData planetDuplicator;


        public void Init()
        {
            InjectPurchase(Purchases.LaborWorkers, laborWorkers);
            InjectPurchase(Purchases.Basements, basements);
            InjectPurchase(Purchases.Factory, factory);
            InjectPurchase(Purchases.Mafia, mafia);
            InjectPurchase(Purchases.Country, country);
            InjectPurchase(Purchases.CompetitorsExecutionSquad, competitorExecutionSquad);
            InjectPurchase(Purchases.Slaves, slaves);
            InjectPurchase(Purchases.MolecularReassemler, molecularReassemler);
            InjectPurchase(Purchases.PlanetDuplicator, planetDuplicator);
        }

        public void InjectPurchase(Purchase purchase, PurchaseData purchaseData)
        {
            purchase.Sprite = purchaseData.sprite;
        }
    }

    [Serializable]
    public struct PurchaseData
    {
        public Sprite sprite;
    }

    public static class Purchases
    {
        public static Purchase LaborWorkers { get; set; }
        public static Purchase Basements { get; set; }
        public static Purchase Factory { get; set; }
        public static Purchase Mafia { get; set; }
        public static Purchase Country { get; set; }
        public static Purchase CompetitorsExecutionSquad { get; set; }
        public static Purchase Slaves { get; set; }
        public static Purchase MolecularReassemler { get; set; }
        public static Purchase PlanetDuplicator { get; set; }

        public static List<Purchase> All { get; set; }

        public static void Init()
        {
            All = new();

            LaborWorkers = Purchase.Default;
            LaborWorkers.StartPrice = 20;
            LaborWorkers.RawIncome = 0.1f;
            LaborWorkers.Name = () =>
            {
                return "Labor Workers";
            };
            LaborWorkers.Description = () =>
            {
                return "Ordinary workers need to be paid a lot of money, how good it is that there is a cheap alternative";
            };
            LaborWorkers.ClocksToUnlock = 0;

            Basements = Purchase.Default;
            Basements.StartPrice = 250;
            Basements.RawIncome = 1f;
            Basements.Name = () =>
            {
                return "Basements";
            };
            Basements.Description = () =>
            {
                return "Room for expansion and our new employees.";
            };
            Basements.ClocksToUnlock = 100;

            Factory = Purchase.Default;
            Factory.StartPrice = 3000;
            Factory.RawIncome = 25f;
            Factory.Name = () =>
            {
                return "Factory";
            };
            Factory.Description = () =>
            {
                return "Produces a large number of clocks";
            };
            Factory.ClocksToUnlock = 1000;

            Mafia = Purchase.Default;
            Mafia.StartPrice = 20000;
            Mafia.RawIncome = 200f;
            Mafia.Name = () =>
            {
                return "Mafia";
            };
            Mafia.Description = () =>
            {
                return "It seems that competitors have started to interfere with us";
            };
            Mafia.ClocksToUnlock = 10000;

            Country = Purchase.Default;
            Country.StartPrice = 100000;
            Country.RawIncome = 1000f;
            Country.Name = () =>
            {
                return "Country";
            };
            Country.Description = () =>
            {
                return "Country of patriotic workers";
            };
            Country.ClocksToUnlock = 50000;

            CompetitorsExecutionSquad = Purchase.Default;
            CompetitorsExecutionSquad.StartPrice = 100000;
            CompetitorsExecutionSquad.RawIncome = 1000f;
            CompetitorsExecutionSquad.Name = () =>
            {
                return "Competitors Execution Squad";
            };
            CompetitorsExecutionSquad.Description = () =>
            {
                return "It's time to deal with them once and for all";
            };
            CompetitorsExecutionSquad.ClocksToUnlock = 50000;

            Slaves = Purchase.Default;
            Slaves.StartPrice = 2000000;
            Slaves.RawIncome = 30000f;
            Slaves.Name = () =>
            {
                return "Slaves";
            };
            Slaves.Description = () =>
            {
                return "Why pay for work if you don't have to?";
            };
            Slaves.ClocksToUnlock = 1000000;

            MolecularReassemler = Purchase.Default;
            MolecularReassemler.StartPrice = 30000000;
            MolecularReassemler.RawIncome = 4000000f;
            MolecularReassemler.Name = () =>
            {
                return "Molecular Reassembler";
            };
            MolecularReassemler.Description = () =>
            {
                return "Reassembles arbitrary molecules into clocks";
            };
            MolecularReassemler.ClocksToUnlock = 20000000;

            PlanetDuplicator = Purchase.Default;
            PlanetDuplicator.StartPrice = 400000000;
            PlanetDuplicator.RawIncome = 50000000f;
            PlanetDuplicator.Name = () =>
            {
                return "Planet Duplicator";
            };
            PlanetDuplicator.Description = () =>
            {
                return "Creates an exact copy of our planet";
            };
            PlanetDuplicator.ClocksToUnlock = 300000000;


            All.Add(LaborWorkers);
            All.Add(Basements);
            All.Add(Factory);
            All.Add(Mafia);
            All.Add(Country);
            All.Add(CompetitorsExecutionSquad);
            All.Add(Slaves);
            All.Add(MolecularReassemler);
            All.Add(PlanetDuplicator);
        }

        public static void Reset()
        {
            Init();
        }
    }

    public class Purchase
    {
        public Func<string> Name { get; set; }
        public Func<string> Description { get; set; }
        public Sprite Sprite { get; set; }

        public int StartPrice { get; set; }
        public float PriceMultiplier { get; set; }

        public float ClocksToUnlock { get; set; }

        public int Bought { get; set; }

        public float RawIncome { get; set; }
        public float IncomeMultiplier { get; set; }

        public int Price
        {
            get
            {
                return (int)(StartPrice * Mathf.Pow(PriceMultiplier, Bought + 1));
            }
        }
        public float Income
        {
            get
            {
                return RawIncome * IncomeMultiplier;
            }
        }
        public float TotalIncome
        {
            get
            {
                return (float)Bought * Income;
            }
        }

        public Purchase() { }

        public Purchase(Func<string> name, Func<string> description, Sprite sprite)
        {
            Name = name;
            Description = description;
            Sprite = sprite;
        }


        public static Purchase Default
        {
            get
            {
                return new Purchase()
                {
                    Name = () =>
                    {
                        return "";
                    },
                    Description = () =>
                    {
                        return "";
                    },
                    StartPrice = 10,
                    PriceMultiplier = 1.1f,
                    ClocksToUnlock = 0,
                    Bought = 0,
                    RawIncome = 0.1f,
                    IncomeMultiplier = 1f
                };
            }
        }
    }
}