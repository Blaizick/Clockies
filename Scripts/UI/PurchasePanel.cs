using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;

namespace Clockies
{
    public class PurchasePanel : MonoBehaviour
    {
        public Transform root;
        public GameObject purchasePrefab;
        [NonSerialized] public Dictionary<Purchase, PurchaseContainer> purchases = new();


        public void Init()
        {
            _Update();
        }

        public void Reset()
        {
            foreach (var instance in purchases.Values)
            {
                Destroy(instance.gameObject);
            }

            purchases.Clear();

            _Update();
        }

        public void Restart()
        {
            foreach (var instance in purchases.Values)
            {
                Destroy(instance.gameObject);
            }

            purchases.Clear();

            _Update();
        }

        public void _Update()
        {
            foreach (var unlocked in Vars.Instance.unlockManager.Purchases)
            {
                if (!purchases.ContainsKey(unlocked))
                {
                    purchases.Add(unlocked, CreatePurchase(unlocked));
                }
            }
        }

        public PurchaseContainer CreatePurchase(Purchase purchase)
        {
            GameObject instance = Instantiate(purchasePrefab, root);
            PurchaseContainer script = instance.GetComponent<PurchaseContainer>();

            script.purchase = purchase;
            script.Init();

            return script;
        }
    }
}