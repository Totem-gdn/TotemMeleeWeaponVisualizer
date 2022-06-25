using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Totem.Sword3D
{
    public class UILoadingScreen : MonoBehaviour
    {
        public static UILoadingScreen Instance;

        [SerializeField] private GameObject overlay;

        void Awake()
        {
            Instance = this;
        }


        public void Show()
        {
            overlay.SetActive(true);
        }

        public void Hide()
        {
            overlay.SetActive(false);
        }

    }
}
