using UnityEngine;
#if UNITY_EDITOR
using UnityEditor;
#endif

/*
    this script is used to have a custom editor
 */

#if UNITY_EDITOR
[CustomEditor(typeof(CharacterController))]
public class CharacterControllerEditor : Editor {
    public override void OnInspectorGUI() {
        CharacterController characterController = (CharacterController) target;

        characterController.characterType = (CharacterController.CharacterType) EditorGUILayout.EnumPopup
                                            ("Type", characterController.characterType);

        // Show choosen type component
        if(characterController.characterType != CharacterController.CharacterType.Player)
        {
            characterController.enemyScore = EditorGUILayout.IntField("Score", characterController.enemyScore);
            characterController.enemyDamage = EditorGUILayout.FloatField("Damage", characterController.enemyDamage);
        }
    }
}
#endif
