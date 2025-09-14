

using UnityEngine;

namespace Clockies
{
    public class Content : MonoBehaviour
    {
        public PurchasesDataInjector purchasesDataInjector;
        public BuffsDataInjector buffsDataInjector;

        public void Init()
        {
            Purchases.Init();
            purchasesDataInjector.Init();
            Buffs.Init();
            buffsDataInjector.Init();

            NamedItems.Init();
        }

        public void Restart()
        {
            Purchases.Restart();
        }

        public void Reset()
        {
            Purchases.Reset();
        }
    }
}