using System.Collections;
using System.Collections.Generic;
using enums;
using TMPro;
using TotemEntities;
using UnityEngine;

namespace Totem.Sword3D
{

    public class RandomGeneration : MonoBehaviour
    {

        #region Inspector

        [SerializeField]
        private Totem3DSword weapon;

        [SerializeField]
        private TextMeshProUGUI permutationLabel = default;

        #endregion

        #region Methods
        public void Generate()
        {
            TotemSword permutation = TotemGenerator.GenerateSword();
            weapon.Sword = permutation;
            permutationLabel.text =
            $"{permutation.tipMaterial}\n#{ColorUtility.ToHtmlStringRGB(permutation.shaftColorRGB)}\n{permutation.damage}\n{permutation.element}";
        }
        #endregion
    }
}
