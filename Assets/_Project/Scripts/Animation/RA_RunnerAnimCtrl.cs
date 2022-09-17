/**
 * $File: RA_CharAnimCtrl.cs $
 * $Date: 2022-09-18 01:36:26 $
 * $Revision: $
 * $Creator: Jen-Chieh Shen $
 * $Notice: See LICENSE.txt for modification and distribution information
 *                   Copyright © 2022 by Shen, Jen-Chieh $
 */
using UnityEngine;

/// <summary>
/// Animator control.
/// </summary>
[RequireComponent(typeof(Animator))]
public class RA_CharAnimCtrl : MonoBehaviour
{
    /* Variables */

    private Animator mAnimator = null;

    [Header("** Check Variables (RA_RunnerAnimCtrl) **")]

    [Tooltip("")]
    [SerializeField]
    private RA_CharAnimType mCurrentAnimType = RA_CharAnimType.IDLE_A;

    /* Setter & Getter */

    /* Functions */

    private void Awake()
    {
        this.mAnimator = this.GetComponent<Animator>();
    }

    public void Idle() { PlayAnimation(RA_CharAnimType.IDLE_A); }
    public void Run() { PlayAnimation(RA_CharAnimType.RUN); }
    public void Walk() { PlayAnimation(RA_CharAnimType.WALK); }

    public void PlayAnimation(RA_CharAnimType type)
    {
        this.mCurrentAnimType = type;
        this.mAnimator.SetInteger("animation", (int)type);
    }
}
