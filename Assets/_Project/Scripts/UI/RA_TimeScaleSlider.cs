/**
 * $File: RA_TimeScaleSlider.cs $
 * $Date: 2022-09-03 21:45:01 $
 * $Revision: $
 * $Creator: Jen-Chieh Shen $
 * $Notice: See LICENSE.txt for modification and distribution information
 *                   Copyright © 2022 by Shen, Jen-Chieh $
 */
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Slider))]
public class RA_TimeScaleSlider : MonoBehaviour
{
    /* Variables */

    private Slider mSlider = null;

    /* Setter & Getter */

    /* Functions */

    private void Awake()
    {
        this.mSlider = GetComponent<Slider>();
    }

    private void Update()
    {
        Time.timeScale = mSlider.value;
    }
}
