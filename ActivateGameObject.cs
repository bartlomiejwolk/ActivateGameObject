using UnityEngine;
using System.Collections;
using System.Collections.Generic;

namespace ActivateGameObjectEx {

    public sealed class ActivateGameObject : MonoBehaviour {

        #region CONSTANTS

        public const string Version = "v0.1.0";
        public const string Extension = "ActivateGameObject";

        #endregion

        #region DELEGATES
        #endregion

        #region EVENTS
        #endregion

        #region FIELDS

        /// <summary>
        /// Allows identify component in the scene file when reading it with
        /// text editor.
        /// </summary>
#pragma warning disable 0414
        [SerializeField]
        private string componentName = "ActivateGameObject";
#pragma warning restore0414

        #endregion

        #region INSPECTOR FIELDS

        [SerializeField]
        private string description = "Description";

        /// <summary>
        /// List of game object to activate. Game objects will be activate
        /// in list order.
        /// </summary>
        [SerializeField]
        private List<GameObject> gameObjects; 

        #endregion

        #region PROPERTIES

        /// <summary>
        /// Optional text to describe purpose of this instance of the component.
        /// </summary>
        public string Description {
            get { return description; }
            set { description = value; }
        }

        public List<GameObject> GameObjects {
            get { return gameObjects; }
            set { gameObjects = value; }
        }

        #endregion

        #region UNITY MESSAGES

        private void Awake() { }

        private void FixedUpdate() { }

        private void LateUpdate() { }

        private void OnEnable() { }

        private void Reset() { }

        private void Start() { }

        private void Update() { }

        private void OnValidate() { }

        #endregion

        #region EVENT INVOCATORS
        #endregion

        #region EVENT HANDLERS
        #endregion

        #region METHODS

        /// <summary>
        /// Activate all game object in list order.
        /// </summary>
        public void Activate() {
            foreach (var GO in GameObjects) {
                GO.SetActive(true);
            }
        }

        #endregion

    }

}