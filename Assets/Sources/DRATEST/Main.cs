using UnityEngine;

namespace DragRoot
{
    public class Main : MonoBehaviour
    {
        private void Awake()
        {
            G.main = this;
        }

        public void StartDrag()
        {

        }

        public void StopDrag()
        {

        }
    }

    public static class G
    {
        public static Main main;
    }
}
