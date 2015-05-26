// Copyright (c) 2015 Bartlomiej Wolk (bartlomiejwolk@gmail.com)
// 
// This file is part of the ActivateGameObject extension for Unity. Licensed
// under the MIT license. See LICENSE file in the project root folder.

using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.Events;

namespace ActivateGameObjectEx {

    public sealed class ActivateGameObject : MonoBehaviour {
        #region CONSTANTS

        public const string Extension = "ActivateGameObject";
        public const string Version = "v0.1.0";

        #endregion CONSTANTS

        #region FIELDS

        /// <summary>
        ///     Allows identify component in the scene file when reading it with
        ///     text editor.
        /// </summary>
#pragma warning disable 0414
        [SerializeField]
        private string componentName = "ActivateGameObject";

#pragma warning restore0414

        #endregion FIELDS

        #region INSPECTOR FIELDS

        [SerializeField]
        private string description = "Description";

        [SerializeField]
        private List<GameObject> gameObjects;

        [SerializeField]
        private UnityEvent unityEvents;

        #endregion INSPECTOR FIELDS

        #region PROPERTIES

        /// <summary>
        ///     Optional text to describe purpose of this instance of the
        ///     component.
        /// </summary>
        public string Description {
            get { return description; }
            set { description = value; }
        }

        /// <summary>
        ///     List of game object to activate. Game objects will be activate in
        ///     list order.
        /// </summary>
        public List<GameObject> GameObjects {
            get { return gameObjects; }
            set { gameObjects = value; }
        }

        /// <summary>
        ///     Callback actions executed after all game objects are activated.
        /// </summary>
        public UnityEvent UnityEvents {
            get { return unityEvents; }
            set { unityEvents = value; }
        }

        #endregion PROPERTIES

        #region UNITY MESSAGES

        private void Awake() {
            Activate();
        }

        private void FixedUpdate() {
        }

        private void LateUpdate() {
        }

        private void OnEnable() {
        }

        private void OnValidate() {
        }

        private void Reset() {
        }

        private void Start() {
        }

        private void Update() {
        }

        #endregion UNITY MESSAGES

        #region METHODS

        /// <summary>
        ///     Activate all game object in list order.
        /// </summary>
        public void Activate() {
            foreach (var gameObj in GameObjects.Where(
                gameObj => gameObj != null)) {

                gameObj.SetActive(true);
            }

            UnityEvents.Invoke();
        }

        #endregion METHODS
    }

}