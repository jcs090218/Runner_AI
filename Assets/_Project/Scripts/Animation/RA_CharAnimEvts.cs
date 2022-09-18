/**
 * $File: RA_CharAnimEvts.cs $
 * $Date: 2022-09-18 14:43:25 $
 * $Revision: $
 * $Creator: Jen-Chieh Shen $
 * $Notice: See LICENSE.txt for modification and distribution information
 *                   Copyright © 2022 by Shen, Jen-Chieh $
 */
using UnityEngine;

/// <summary>
/// Animation Events design for runner.
/// </summary>
public class RA_CharAnimEvts : MonoBehaviour
{
    /* Variables */

    [Header("** Check Variables (RA_CharAnimEvts) **")]

    [Tooltip("Runner that are going to be use for animation events.")]
    [SerializeField]
    private RA_RunnerCtrl mRunnerCtrl = null;

    /* Setter & Getter */

    public void SetRunner(RA_RunnerCtrl p) { this.mRunnerCtrl = p; }

    /* Functions */

    /// <summary>
    /// Execute this when runner is dead.
    /// </summary>
    private void IsDead()
    {
        mRunnerCtrl.CallRevive();
    }
}
