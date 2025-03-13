using MerJame.Infrastructure;
using UnityEngine;
using UnityEngine.UI;
using System;

namespace CMS.TurnSystem
{
    public class TurnView : CompositeRoot
    {
        [SerializeField] private Button _button;
        
        public event Action Clicked;
        
        public override void Init()
        {
            _button.onClick.AddListener(OnClicked);
        }

        private void OnClicked()
        {
            Clicked?.Invoke();
        }

        public void EnableButton()
        {
            _button.interactable = true;
        }
        
        public void DisableButton()
        {
            _button.interactable = false;
        }
    }
}