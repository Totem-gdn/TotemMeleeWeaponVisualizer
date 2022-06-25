using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TotemEntities;
using UnityEditor;

namespace Totem.Sword3D
{
    public class UISwordsList : MonoBehaviour
    {
        public static UISwordsList Instance;
        [SerializeField] private Transform itemsParent;
        [SerializeField] private Totem3DSword weapon;
        private List<TotemSword> swords;
        private bool Swap = false;
        private int index = 0;
        void Awake()
        {
            Instance = this;
        }

        private void Update()
        {
            if(Input.GetKeyDown(KeyCode.RightArrow) == true && Swap == true && index + 1 != swords.Count)
            {
                index++;
                weapon.Sword = swords[index];
            }
            else if (Input.GetKeyDown(KeyCode.LeftArrow) == true && Swap == true && index != 0)
            {
                index--;
                weapon.Sword = swords[index];
            }
        }

        public void BuildSwordsList(List<ITotemAsset> assets, List<TotemSword> swordsList)
        {
            foreach (Transform item in itemsParent)
            {
                Destroy(item.gameObject);
            }
            Swap = true;
            swords = swordsList;
            weapon.Sword = weapon.Sword = swords[0];
        }
        public void ClearList()
        {
            foreach (Transform item in itemsParent)
            {
                Destroy(item.gameObject);
            }
        }
    }
}
