using UnityEngine;

namespace CMS.CardSystem
{
    [RequireComponent(typeof(MoveableSmoothDamp))]
    public class EnemyCard : Card
    {
        private MoveableSmoothDamp _smoothDamp;

        public void Init()
        {
            _smoothDamp = GetComponent<MoveableSmoothDamp>();
            _smoothDamp.TargetPosition = transform.position;
        }
    }
}