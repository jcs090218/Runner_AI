/**
 * $File: RA_Obstacle.cs $
 * $Date: 2022-09-18 02:59:01 $
 * $Revision: $
 * $Creator: Jen-Chieh Shen $
 * $Notice: See LICENSE.txt for modification and distribution information
 *                   Copyright © 2022 by Shen, Jen-Chieh $
 */
using UnityEngine;

/// <summary>
/// Obstacle that kills the runner.
/// </summary>
public class RA_Obstacle : MonoBehaviour
{
    /* Variables */

    /* Setter & Getter */

    /* Functions */

    private void OnTriggerEnter(Collider other)
    {
        var runner = other.GetComponent<RA_RunnerCtrl>();
        if (runner == null)
            return;

        runner.Kill();
    }
}
