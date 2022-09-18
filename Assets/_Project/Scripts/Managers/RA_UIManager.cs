/**
 * $File: RA_UIManager.cs $
 * $Date: 2022-09-03 21:44:31 $
 * $Revision: $
 * $Creator: Jen-Chieh Shen $
 * $Notice: See LICENSE.txt for modification and distribution information
 *                   Copyright © 2022 by Shen, Jen-Chieh $
 */
using UnityEngine;
using UnityEngine.UI;
using JCSUnity;

public class RA_UIManager : JCS_Manager<RA_UIManager>
{
    /* Variables */

    [Header("** Runtime Variables (RA_UIManager) **")]

    [Tooltip("Revive runners when possible.")]
    [SerializeField]
    private Toggle mToggle_AutoRevive = null;

    /* Setter & Getter */

    /* Functions */

    private void Awake()
    {
        instance = this;
    }

    private void Start()
    {
        var appm = RA_AppManager.instance;

        mToggle_AutoRevive.onValueChanged.AddListener(delegate {
            appm.autoRevive = mToggle_AutoRevive.isOn;
        });
    }
}
