/**
 * $File: RA_AppManager.cs $
 * $Date: 2022-09-17 21:27:56 $
 * $Revision: $
 * $Creator: Jen-Chieh Shen $
 * $Notice: See LICENSE.txt for modification and distribution information
 *                   Copyright © 2022 by Shen, Jen-Chieh $
 */
using JCSUnity;

/// <summary>
/// Application manager.
/// </summary>
public class RA_AppManager : JCS_Manager<RA_AppManager>
{
    /* Variables */

    /* Setter & Getter */

    /* Functions */

    private void Awake()
    {
        instance = this;
    }
}
