using UnityEngine;
using UnityEngine.UI;

namespace CMS.HealthSystem
{
    public class HealthView : MonoBehaviour
    {
        [SerializeField] private Slider _slider;

        public void SetMaxValue(int value)
        {
            _slider.maxValue = value;
        }
        
        public void SetValue(int value)
        {
            if (value < 0)
            {
                _slider.value = 0;
                return;
            }
            
            _slider.value = value;
        }
    }
}