using System;
using UnityEngine;

namespace Clockies
{
    public class Vars : MonoBehaviour
    {
        public static Vars Instance { get; private set; }

        public UI ui;

        public ClocksManager clocksManager;
        public IncomeManager incomeManager;
        public ClicksManager clicksManager;
        public PurchaseManager purchaseManager;
        public RebirthsManager rebirthsManager;
        public UnlockManager unlockManager;

        public PurchasesDataInjector purchasesDataInjector;

        public DesktopInput input;


        [NonSerialized] public GameState state;


        public void Awake()
        {
            Instance = this;
            Init();
        }

        public void Init()
        {
            state = GameState.Running;


            Purchases.Init();
            purchasesDataInjector.Init();


            clocksManager = new();
            incomeManager = new();
            clicksManager = new();
            purchaseManager = new();
            rebirthsManager = new();
            unlockManager = new();

            input = new();

            clocksManager.Init();
            incomeManager.Init();
            clicksManager.Init();
            purchaseManager.Init();
            rebirthsManager.Init();
            unlockManager.Init();

            input.Init();

            ui.Init();
        }

        public void Reset()
        {
            Purchases.Reset();

            clocksManager.Reset();
            incomeManager.Reset();
            clicksManager.Reset();
            purchaseManager.Reset();
            unlockManager.Reset();

            ui.Reset();
        }

        public void Update()
        {
            incomeManager.Update();
            unlockManager.Update();

            input.Update();

            ui._Update();
        }
    }

    public enum GameState
    {
        Running,
        Win
    }
}
