// Copyright (c) 2015 Bartlomiej Wolk (bartlomiejwolk@gmail.com)
// 
// This file is part of the ActivateGameObject extension for Unity. Licensed
// under the MIT license. See LICENSE file in the project root folder.

using UnityEditor;
using UnityEngine;

namespace ActivateGameObjectEx {

    [CustomEditor(typeof (ActivateGameObject))]
    [CanEditMultipleObjects]
    public sealed class ActivateGameObjectEditor : Editor {
        #region FIELDS

        private ActivateGameObject Script { get; set; }

        #endregion FIELDS

        #region SERIALIZED PROPERTIES

        private SerializedProperty description;
        private SerializedProperty gameObjects;
        private SerializedProperty unityEvents;

        #endregion SERIALIZED PROPERTIES

        #region UNITY MESSAGES

        public override void OnInspectorGUI() {
            serializedObject.Update();

            DrawVersionLabel();
            DrawDescriptionTextArea();

            EditorGUILayout.Space();

            DrawGameObjectsList();
            DrawUnityEventsList();

            serializedObject.ApplyModifiedProperties();
        }

        private void DrawGameObjectsList() {
            ReorderableListGUI.Title("Game Objects");
            ReorderableListGUI.ListField(gameObjects);
        }

        private void DrawUnityEventsList() {
            EditorGUILayout.PropertyField(
                unityEvents,
                new GUIContent(
                    "Callback",
                    "Actions executed after all game objects are" +
                    "activated."));
        }

        private void OnEnable() {
            Script = (ActivateGameObject) target;

            description = serializedObject.FindProperty("description");
            gameObjects = serializedObject.FindProperty("gameObjects");
            unityEvents = serializedObject.FindProperty("unityEvents");
        }

        #endregion UNITY MESSAGES

        #region INSPECTOR CONTROLS

        private void DrawDescriptionTextArea() {
            description.stringValue = EditorGUILayout.TextArea(
                description.stringValue);
        }

        private void DrawVersionLabel() {
            EditorGUILayout.LabelField(
                string.Format(
                    "{0} ({1})",
                    ActivateGameObject.Version,
                    ActivateGameObject.Extension));
        }

        #endregion INSPECTOR CONTROLS

        #region METHODS

        [MenuItem("Component/ActivateGameObject")]
        private static void AddEntryToComponentMenu() {
            if (Selection.activeGameObject != null) {
                Selection.activeGameObject.AddComponent(
                    typeof (ActivateGameObject));
            }
        }

        #endregion METHODS
    }

}