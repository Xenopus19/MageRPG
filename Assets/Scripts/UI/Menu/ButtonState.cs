using UnityEngine;

public class ButtonState : MonoBehaviour {
    public Animator _animator;
    void Start() {
        _animator = GetComponent<Animator>();
    }

    public void EnlargeButton() {
        _animator.SetBool("IsPointerEnter", true);
        _animator.SetBool("IsPointerExit", false);
    }
    public void DiminishButton() {
        _animator.SetBool("IsPointerExit", true);
        _animator.SetBool("IsPointerEnter", false);
    }
}
