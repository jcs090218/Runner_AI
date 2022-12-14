/**
 * $File: RA_AppManager.cs $
 * $Date: 2022-09-17 21:27:56 $
 * $Revision: $
 * $Creator: Jen-Chieh Shen $
 * $Notice: See LICENSE.txt for modification and distribution information
 *                   Copyright ? 2022 by Shen, Jen-Chieh $
 */
using JCSUnity;
using UnityEngine;

/// <summary>
/// Application manager.
/// </summary>
public class RA_AppManager : JCS_Manager<RA_AppManager>
{
    /* Variables */

    [Header("** Check Variables (RA_AppManager) **")]

    [Tooltip("Generation index.")]
    public int generation = 0;

    [Header("** Initialize Variables (RA_AppManager) **")]

    [Tooltip("Transform position to reset the runner on revive.")]
    public Transform revivePoint = null;

    [Header("** Runtime Variables (RA_AppManager) **")]

    [Tooltip("Auto revive the runner after it's dead.")]
    public bool autoRevive = true;

    /* Setter & Getter */

    /* Functions */

    private void Awake()
    {
        instance = this;
    }
}
