using System;
using System.Collections.Generic;
using UnityEngine;

namespace vd
{
    public class MenuManager : MonoBehaviour
    {
        [SerializeField]
        private Menu[] _menus;
        private Dictionary<Type, Menu> _typeToMenuMap;
        public static MenuManager Instance { get; private set; }

        void Start()
        {
            _typeToMenuMap = new Dictionary<Type, Menu>();
            foreach (var menu in _menus)
            {
                _typeToMenuMap.Add(menu.GetType(), menu);
                menu.Initialize(this);
                menu.Close();
            }
            
            Show(typeof(MainMenu));

            Instance = this;
        }

        public void Show<T>(T menuType) where T : Type
        {
            _typeToMenuMap[menuType].Show();
        }

        public void Close<T>(T menuType) where T : Type
        {
            _typeToMenuMap[menuType].Close();
        }
    }
}