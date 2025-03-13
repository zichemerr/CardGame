using UnityEngine;

namespace CMS.CardSystem
{
    [RequireComponent(typeof(MoveableSmoothDamp))]
    public class PlayerCard : Card
    {
        private MoveableSmoothDamp _movable;

        public void Init(MoveableSmoothDamp movable)
        {
            Sloted += OnSloted;
            _movable = movable;
        }

        private void OnDisable()
        {
            Sloted -= OnSloted;
        }

        private void OnSloted(Vector2 position)
        {
            _movable.TargetPosition = position;
        }
    }
}