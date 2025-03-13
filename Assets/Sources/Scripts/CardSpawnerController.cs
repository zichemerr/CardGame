using System;
using CMS.DragSystem;
using MerJame.Infrastructure;
using UnityEngine;

namespace CMS.CardSystem
{
    public class CardSpawnerController : CompositeRoot
    {
        public event Action<Dragable> Spawned;

        public override void Init()
        {
            for (int i = 0; i < 3; i++)
            {
                GiveCard(Data.Prefabs.Card);
            }
        }
        
        public Dragable GiveCard(Dragable card)
        {
            Dragable prefab = Instantiate(card);
            
            Spawned?.Invoke(prefab);
            return prefab;
        }
        
        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.G))
            {
                GiveCard(Data.Prefabs.Card);
            }
        }
    }
}
