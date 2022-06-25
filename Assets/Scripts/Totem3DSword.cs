using System.Collections;
using System.Collections.Generic;
using enums;
using TotemEntities;
using UnityEngine;

namespace Totem.Sword3D
{
    public class Totem3DSword : MonoBehaviour
    {
        #region Proeprties
        public TotemSword Sword
        {
            get => sword;
            set
            {
                sword = value;
                UpdatePermutation();
            }
        }
        #endregion

        #region Fields

        private int _activeTip = 0;

        private int _activeElem = 0;

        private Color _defColor;

        #endregion

        #region Inspector
        [SerializeField]
        private TotemSword sword;

        [SerializeField]
        private Material shaftColor;

        [SerializeField]
        private Renderer[] tipMaterial;

        [SerializeField]
        private ParticleSystem[] airElement;

        [SerializeField]
        private ParticleSystem[] earthElement;

        [SerializeField]
        private ParticleSystem[] fireElement;

        [SerializeField]
        private ParticleSystem[] waterElement;

        #endregion

        #region MonoBehaviour
        private void Start()
        {
            foreach (Renderer rend in tipMaterial)//Stop render for all materials.
            {
                rend.enabled = false;
            }
            tipMaterial[0].enabled = true;
            StopParticle(1);
            StopParticle(2);
            StopParticle(3);

            _defColor = shaftColor.color;//Saves
        }

        private void OnDisable()
        {
            shaftColor.SetColor("_Color", _defColor);
        }
        #endregion

        #region Methods
        private void UpdatePermutation()
        {
            shaftColor.SetColor("_Color", Sword.shaftColorRGB);//Apply shaft color.

            tipMaterial[_activeTip].enabled = false;
            switch (Sword.tipMaterial)//Changes swords material.
            {
                case TipMaterialEnum.Wood:
                    tipMaterial[0].enabled = true;
                    _activeTip = 0;
                    break;
                case TipMaterialEnum.Bone:
                    tipMaterial[1].enabled = true;
                    _activeTip = 1;
                    break;
                case TipMaterialEnum.Flint:
                    tipMaterial[2].enabled = true;
                    _activeTip = 2;
                    break;
                case TipMaterialEnum.Obsidian:
                    tipMaterial[3].enabled = true;
                    _activeTip = 3;
                    break;
            }

            //Stop all particles.
            StopParticle(_activeElem);
            switch (Sword.element)//Changes swords element.
            {
                case ElementEnum.Air:
                    PlayParticle(0);
                    _activeElem = 0;
                    break;
                case ElementEnum.Earth:
                    PlayParticle(1);
                    _activeElem = 1;
                    break;
                case ElementEnum.Fire:
                    PlayParticle(2);
                    _activeElem = 2;
                    break;
                case ElementEnum.Water:
                    PlayParticle(3);
                    _activeElem = 3;
                    break;
            }
        }

        private void StopParticle(int index)
        {
            switch (index)//Changes swords element.
            {
                case 0:
                    foreach (ParticleSystem Elem in airElement)//Stop all particles.
                    {
                        Elem.Stop();
                        Elem.Clear();
                    }
                    break;
                case 1:
                    foreach (ParticleSystem Elem in earthElement)//Stop all particles.
                    {
                        Elem.Stop();
                        Elem.Clear();
                    }
                    break;
                case 2:
                    foreach (ParticleSystem Elem in fireElement)//Stop all particles.
                    {
                        Elem.Stop();
                        Elem.Clear();
                    }
                    break;
                case 3:
                    foreach (ParticleSystem Elem in waterElement)//Stop all particles.
                    {
                        Elem.Stop();
                        Elem.Clear();
                    }
                    break;
            } 
        }

        private void PlayParticle(int index)
        {
            switch (index)//Changes swords element.
            {
                case 0:
                    foreach (ParticleSystem Elem in airElement)//Stop all particles.
                    {
                        Elem.Play();
                    }
                    break;
                case 1:
                    foreach (ParticleSystem Elem in earthElement)//Stop all particles.
                    {
                        Elem.Play();
                    }
                    break;
                case 2:
                    foreach (ParticleSystem Elem in fireElement)//Stop all particles.
                    {
                        Elem.Play();
                    }
                    break;
                case 3:
                    foreach (ParticleSystem Elem in waterElement)//Stop all particles.
                    {
                        Elem.Play();
                    }
                    break;
            }
        }
        #endregion
    }
}
