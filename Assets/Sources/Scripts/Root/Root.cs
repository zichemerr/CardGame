using CMS.CardSystem;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace CMS.EntryPoint
{
    public class Root : MonoBehaviour
    {
        [SerializeField] private List<CompositeRoot> _roots;

        public static IServiceLocator<IService> Main { get; private set; }

        private void Start()
        {
            Main = new ServiceLocator<IService>();

            foreach (var root in _roots)
            {
                Main.Register<CompositeRoot>(root);
            }

            foreach (var root in _roots)
            {
                root.Init();
            }
        }

        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.R))
            {
                SceneManager.LoadScene(0);
            }
        }
    }
}
