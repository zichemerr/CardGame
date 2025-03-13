using UnityEngine;
using CMS.CardSystem;

namespace CMS.DragSystem
{
    [RequireComponent(typeof(MoveableSmoothDamp))]
    [RequireComponent(typeof(PlayerCard))]
    public class Dragable : MonoBehaviour
    {
        private PlayerCard _card;
        private MoveableSmoothDamp _movable;
        private Vector2 _startPosition;
        private Camera _camera;
        
        public bool IsSloted { get; private set; }
        public bool IsDragging { get; private set; }
        public MoveableSmoothDamp Movable => _movable;

        public void Init()
        {
            _movable = GetComponent<MoveableSmoothDamp>();
            _card = GetComponent<PlayerCard>();
            _camera = Camera.main;
            _startPosition = transform.position;
            _movable.TargetPosition = transform.position;
            
            _card.Init(_movable);
            _card.Sloted += OnSloted;
        }

        private void OnDisable()
        {
            _card.Sloted -= OnSloted;
        }

        private void OnSloted(Vector2 position)
        {
            IsSloted = true;
        }
        
        private void OnMouseDown()
        {
            if (IsSloted == true)
                return;
            
            IsDragging = true;
            Vector2 tar = _camera.ScreenToWorldPoint(Input.mousePosition);
            _movable.TargetPosition = tar;
        }

        private void OnMouseDrag()
        {            
            if (IsSloted == true)
                return;
            
            Vector2 tar = _camera.ScreenToWorldPoint(Input.mousePosition);
            _movable.TargetPosition = tar;
        }

        private void OnMouseUp()
        {            
            if (IsSloted == true)
                return;

            IsDragging = false;
            _movable.TargetPosition = _startPosition;
        }
    }
}
