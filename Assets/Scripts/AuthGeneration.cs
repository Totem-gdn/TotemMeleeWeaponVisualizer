using System.Collections;
using System.Collections.Generic;
using TotemEntities;
using TMPro;
using UnityEngine;

namespace Totem.Sword3D
{

    public class AuthGeneration : MonoBehaviour
    {

        #region Inspector

        [SerializeField]
        private Totem3DSword weapon = default;

        [SerializeField]
        private TMP_InputField inputUser = default;

        [SerializeField]
        private TMP_InputField inputPass = default;

        [SerializeField]
        private TMP_Dropdown inputSwords = default;

        [SerializeField]
        private TextMeshProUGUI labelError = default;

        [SerializeField]
        private TextMeshProUGUI permutationLabel = default;

        #endregion

        #region Fields

        private TotemMockDB _database;

        private string _authedUser;

        #endregion

        #region Proeprties

        private IReadOnlyList<TotemSword> UserSwords =>
          _database.UsersDB.GetUser(_authedUser)?.GetOwnedSwords();

        #endregion

        #region MonoBehaviour

        private void Awake()
        {
            _database = new TotemMockDB();
        }

        // Start is called before the first frame update
        void Start()
        {
            /*TotemSword permutation = TotemGenerator.GenerateSword();
            weapon.Sword = permutation;
            permutationLabel.text =
            $"{permutation.tipMaterial}\n#{ColorUtility.ToHtmlStringRGB(permutation.shaftColor)}\n{permutation.damage}\n{permutation.element}";*/

            Camera cam = Camera.main;
            if (cam == null)
                return;
        }

        // Update is called once per frame
        void Update()
        {
            //
            // Authentication form
            //

            // Tab to switch input
            if (Input.GetKeyDown(KeyCode.Tab))
            {
                TMP_InputField input = inputUser.isFocused ? inputPass : inputUser;
                input.Select();
                input.ActivateInputField();
            }

            // Ignore input while textfield is focused
            if (inputUser.isFocused || inputPass.isFocused)
                return;
        }
        #endregion

        #region Methods

        /// <summary>
        ///   Login a user and list its swords.
        /// </summary>
        public void Authenticate()
        {
            _authedUser = null;
            labelError.gameObject.SetActive(false);
            inputSwords.gameObject.SetActive(false);

            //
            // Authenticate
            //

            bool didAuth =
              _database.UsersDB.AuthenticateUser(inputUser.text, inputPass.text);
            if (!didAuth)
            {
                labelError.gameObject.SetActive(true);
                labelError.text = "Unknown username and password combination.";
                return;
            }

            // 
            // List swords
            //

            _authedUser = inputUser.text;
            inputSwords.gameObject.SetActive(true);

            IReadOnlyList<TotemSword> swords = UserSwords;
            if (swords.Count == 0)
            {
                labelError.gameObject.SetActive(true);
                labelError.text = "User has no swords.";
                return;
            }

            List<TMP_Dropdown.OptionData> options = new(swords.Count);
            for (int index = 0; index < swords.Count; index++)
                options.Add(new TMP_Dropdown.OptionData($"Sword {index + 1}"));

            inputSwords.options = options;
            inputSwords.value = 0;

            TotemSword permutation = swords[0];
            weapon.Sword = permutation;
            permutationLabel.text =
            $"{permutation.tipMaterial}\n#{ColorUtility.ToHtmlStringRGB(permutation.shaftColorRGB)}\n{permutation.damage}\n{permutation.element}";

            
        }

        /// <summary>
        ///   Display a user sword.
        /// </summary>
        public void SelectSword(int _)
        {
            TotemSword permutation = UserSwords[inputSwords.value];
            weapon.Sword = permutation;
            permutationLabel.text =
            $"{permutation.tipMaterial}\n#{ColorUtility.ToHtmlStringRGB(permutation.shaftColorRGB)}\n{permutation.damage}\n{permutation.element}";
        }
        #endregion
    }
}
