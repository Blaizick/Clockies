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
        public BuffsManager buffsManager;

        public Content content;

        public DesktopInput input;

        public SceneInjection sceneInjection;


        [NonSerialized] public GameState state;


        public void Awake()
        {
            Instance = this;
            Init();
        }

        public void Init()
        {
            state = GameState.Running;


            content.Init();


            clocksManager = new();
            incomeManager = new();
            clicksManager = new();
            purchaseManager = new();
            rebirthsManager = new();
            unlockManager = new();
            buffsManager = new();

            input = new();

            clocksManager.Init();
            incomeManager.Init();
            clicksManager.Init();
            purchaseManager.Init();
            rebirthsManager.Init();
            unlockManager.Init();
            buffsManager.Init();

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
            buffsManager.Reset();

            ui.Reset();
        }

        public void Restart()
        {
            Purchases.Restart();

            clocksManager.Restart();
            incomeManager.Restart();
            clicksManager.Restart();
            purchaseManager.Restart();
            unlockManager.Restart();
            buffsManager.Restart();

            ui.Restart();
        }

        public void Update()
        {
            incomeManager.Update();
            unlockManager.Update();
            buffsManager.Update();

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
