using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
    this script is used to controll character. in this script the controlled character is enemy
    but you can add new entity like player or something else, but remember this script is linked with custom editor in
    CharacterControllerEditor, so you must show the new entity variable by yourself in CharacterControllerEditor.
 */

public class CharacterController : MonoBehaviour
{
    public enum CharacterType { Player, Enemy }

    public CharacterType characterType = CharacterType.Player;

    // Enemy Component
    public int enemyScore;
    private int updatedScore;
    public float enemyDamage;

    private void Start() {
        updatedScore = enemyScore;
    }

    // multiply score value for multiply score powerup
    public void multiplyingScore(int multiplyAmount)
    {
        updatedScore = enemyScore * multiplyAmount;
    }

    // get updated score
    public int getUpdatedScore()
    {
        return updatedScore;
    }
}
