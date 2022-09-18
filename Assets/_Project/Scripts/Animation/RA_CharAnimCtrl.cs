/**
 * $File: RA_CharAnimCtrl.cs $
 * $Date: 2022-09-18 01:36:26 $
 * $Revision: $
 * $Creator: Jen-Chieh Shen $
 * $Notice: See LICENSE.txt for modification and distribution information
 *                   Copyright © 2022 by Shen, Jen-Chieh $
 */
using Unity.VisualScripting;
using UnityEngine;

/// <summary>
/// Animator control.
/// </summary>
[RequireComponent(typeof(Animator))]
[RequireComponent(typeof(RA_CharAnimEvts))]
public class RA_CharAnimCtrl : MonoBehaviour
{
    /* Variables */

    private Animator mAnimator = null;

    private RA_CharAnimEvts mAnimEvents = null;

    [Header("** Check Variables (RA_RunnerAnimCtrl) **")]

    [Tooltip("")]
    [SerializeField]
    private RA_CharAnimType mCurrentAnimType = RA_CharAnimType.IDLE_A;

    /* Setter & Getter */

    public RA_CharAnimType CharAnimType { get { return mCurrentAnimType; } }
    public RA_CharAnimEvts AnimEvents { get { return this.mAnimEvents; } }

    /* Functions */

    private void Awake()
    {
        this.mAnimator = this.GetComponent<Animator>();
        this.mAnimEvents = this.GetComponent<RA_CharAnimEvts>();
    }

    public void Idle() { PlayAnimation(RA_CharAnimType.IDLE_A); }
    public void Run() { PlayAnimation(RA_CharAnimType.RUN); }
    public void Walk() { PlayAnimation(RA_CharAnimType.WALK); }

    public void Jump() { PlayAnimation(RA_CharAnimType.JUMP); }
    public void JumpUp() { PlayAnimation(RA_CharAnimType.JUMP_UP); }
    public void JumpDown() { PlayAnimation(RA_CharAnimType.JUMP_DOWN); }

    public void Attack_0() { PlayAnimation(RA_CharAnimType.ATK_0); }
    public void Attack_1() { PlayAnimation(RA_CharAnimType.ATK_1); }
    public void Attack_2() { PlayAnimation(RA_CharAnimType.ATK_2); }
    public void Attack_3() { PlayAnimation(RA_CharAnimType.ATK_3); }
    public void Attack_4() { PlayAnimation(RA_CharAnimType.ATK_4); }

    public void Dash() { PlayAnimation(RA_CharAnimType.DASH); }

    public void Damage() { PlayAnimation(RA_CharAnimType.DAMAGE); }

    public void Die_0() { PlayAnimation(RA_CharAnimType.DIE_0); }
    public void Die_1() { PlayAnimation(RA_CharAnimType.DIE_1); }
    public void Die_2() { PlayAnimation(RA_CharAnimType.DIE_2); }

    /// <summary>
    /// Check if current displayed animation an TYPE animation.
    /// </summary>
    public bool IsCurrentAnim(RA_CharAnimType type) { return this.mCurrentAnimType == type; }

    /// <summary>
    /// Return true if the current animation is done playing.
    /// </summary>
    public bool AnimationFinished(int layerIndex = 0)
    {
        return mAnimator.GetCurrentAnimatorStateInfo(layerIndex).normalizedTime >= 0.01f;
    }

    public void PlayAnimation(RA_CharAnimType type)
    {
        this.mCurrentAnimType = type;
        this.mAnimator.SetInteger("animation", (int)type);
    }
}
