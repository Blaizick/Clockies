using System;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;

namespace Clockies
{
    public class BuffsDisplayer : MonoBehaviour
    {
        public GameObject prefab;
        public RectTransform root;

        public Dictionary<BuffsManager.DisplayedBuff, BuffContainer> displayedBuffs = new();
        private Unity.Mathematics.Random random;

        public void Init()
        {
            random = new((uint)Mathf.Max(DateTime.Now.Second, 1f));

            _Update();
        }

        public void _Update()
        {
            Queue<BuffsManager.DisplayedBuff> destroyBuffs = new();
            foreach (var buff in displayedBuffs.Keys)
            {
                if (buff.destroyed)
                {
                    DestroyBuff(buff);
                    destroyBuffs.Enqueue(buff);
                    // Destroy(displayedBuffs[buff]);
                    // destroyBuffs.Enqueue(buff);
                }
            }
            while (destroyBuffs.Count > 0)
            {
                displayedBuffs.Remove(destroyBuffs.Dequeue());
            }

            foreach (var buff in Vars.Instance.modules.buffsManager.displayedBuffs)
            {
                if (!displayedBuffs.ContainsKey(buff))
                {
                    CreateBuff(buff);
                }
            }
        }

        public void Reset()
        {
            // foreach (var buff in displayedBuffs.Keys)
            // {
            //     Destroy(displayedBuffs[buff]);
            // }
            // displayedBuffs.Clear();

            // _Update();
        }

        public void Restart()
        {
            // foreach (var buff in displayedBuffs.Keys)
            // {
            //     Destroy(displayedBuffs[buff]);
            // }
            // displayedBuffs.Clear();

            // _Update();
        }


        public void CreateBuff(BuffsManager.DisplayedBuff buff)
        {
            var instance = Instantiate(prefab, root);
            var container = instance.GetComponent<BuffContainer>();

            Rect rect = Camera.main.pixelRect;
            container.root.anchoredPosition = random.NextFloat2(rect.min, rect.max);

            container.root.localScale = Vector3.zero;
            container.root.DOScale(Vector3.one, 0.5f);

            container.buff = buff;
            container.image.sprite = buff.buff.Sprite;

            container.button.onClick.AddListener(() =>
            {
                DestroyBuffImmediantly(buff);
                Vars.Instance.modules.buffsManager.ApplyBuff(buff);
            });
            container.performer.data = buff.buff;

            displayedBuffs.Add(buff, container);
        }
        public void DestroyBuff(BuffsManager.DisplayedBuff buff)
        {
            var container = displayedBuffs[buff];
            container.root.DOScale(Vector3.zero, 0.5f).OnComplete(() =>
            {
                container.root.DOKill();
                Destroy(container.gameObject);
            });
        }
        public void DestroyBuffImmediantly(BuffsManager.DisplayedBuff buff)
        {
            var container = displayedBuffs[buff];
            container.root.DOKill();
            Destroy(container.gameObject);
        }
    }
}