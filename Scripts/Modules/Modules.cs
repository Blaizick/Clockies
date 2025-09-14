

namespace Clockies
{
    public class Modules
    {
        public ClocksManager clocksManager;
        public IncomeManager incomeManager;
        public ClicksManager clicksManager;
        public PurchaseManager purchaseManager;
        public RebirthsManager rebirthsManager;
        public UnlockManager unlockManager;
        public BuffsManager buffsManager;
        public SaveManager saveManager;


        public void Init()
        {
            clocksManager = new();
            incomeManager = new();
            clicksManager = new();
            purchaseManager = new();
            rebirthsManager = new();
            unlockManager = new();
            buffsManager = new();
            saveManager = new();

            clocksManager.Init();
            incomeManager.Init();
            clicksManager.Init();
            purchaseManager.Init();
            rebirthsManager.Init();
            unlockManager.Init();
            buffsManager.Init();
            saveManager.Init();
        }

        public void Reset()
        {
            clocksManager.Reset();
            incomeManager.Reset();
            clicksManager.Reset();
            purchaseManager.Reset();
            unlockManager.Reset();
            buffsManager.Reset();
        }

        public void Restart()
        {
            clocksManager.Restart();
            incomeManager.Restart();
            clicksManager.Restart();
            purchaseManager.Restart();
            unlockManager.Restart();
            buffsManager.Restart();
        }

        public void Update()
        {
            incomeManager.Update();
            unlockManager.Update();
            buffsManager.Update();
        }
    }
}