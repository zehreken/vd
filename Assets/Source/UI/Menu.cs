using UnityEngine;

namespace vd
{
    public class Menu : MonoBehaviour
    {
        protected MenuManager MenuManager;

        public virtual void Initialize(MenuManager menuManager)
        {
            MenuManager = menuManager;
        }
        
        public void Show()
        {
            gameObject.SetActive(true);
        }

        public void Close()
        {
            gameObject.SetActive(false);
        }
    }
}