/**
 * $File: RA_RunnerCtrl.cs $
 * $Date: 2022-09-03 01:10:51 $
 * $Revision: $
 * $Creator: Jen-Chieh Shen $
 * $Notice: See LICENSE.txt for modification and distribution information
 *                   Copyright © 2022 by Shen, Jen-Chieh $
 */
using UnityEngine;

[RequireComponent(typeof(CharacterController))]
public class RA_RunnerCtrl : MonoBehaviour
{
    /* Variables */

    private CharacterController mCharacterController = null;

    /* Setter & Getter */

    /* Functions */

    private void Awake()
    {
        this.mCharacterController = this.GetComponent<CharacterController>();
    }

    private void Update()
    {
        
    }
}
