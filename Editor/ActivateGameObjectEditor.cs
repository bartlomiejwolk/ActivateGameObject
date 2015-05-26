using UnityEditor;
using UnityEngine;

namespace ActivateGameObjectEx {

    [CustomEditor(typeof(ActivateGameObject))]
    [CanEditMultipleObjects]
    public sealed class ActivateGameObjectEditor : Editor {
        #region FIELDS

        private ActivateGameObject Script { get; set; }

        #endregion FIELDS

        #region SERIALIZED PROPERTIES

        private SerializedProperty description;
        private SerializedProperty gameObjects;

        #endregion SERIALIZED PROPERTIES

        #region UNITY MESSAGES

        public override void OnInspectorGUI() {
            serializedObject.Update();

            DrawVersionLabel();
            DrawDescriptionTextArea();

            EditorGUILayout.Space();

            DrawGameObjectsList();

            serializedObject.ApplyModifiedProperties();
        }

        private void DrawGameObjectsList() {
            ReorderableListGUI.Title("Game Objects");
            ReorderableListGUI.ListField(gameObjects);
        }

        private void OnEnable() {
            Script = (ActivateGameObject)target;

            description = serializedObject.FindProperty("description");
            gameObjects = serializedObject.FindProperty("gameObjects");
        }

        #endregion UNITY MESSAGES

        #region INSPECTOR CONTROLS

        private void DrawVersionLabel() {
            EditorGUILayout.LabelField(
                string.Format(
                    "{0} ({1})",
                    ActivateGameObject.Version,
                    ActivateGameObject.Extension));
        }

        private void DrawDescriptionTextArea() {
            description.stringValue = EditorGUILayout.TextArea(
                description.stringValue);
        }

        #endregion INSPECTOR

        #region METHODS

        [MenuItem("Component/ActivateGameObject")]
        private static void AddEntryToComponentMenu() {
            if (Selection.activeGameObject != null) {
                Selection.activeGameObject.AddComponent(typeof(ActivateGameObject));
            }
        }

        #endregion METHODS
    }

}