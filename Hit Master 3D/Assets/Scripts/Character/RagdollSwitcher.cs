using UnityEngine;

public class RagdollSwitcher : MonoBehaviour
{
    [SerializeField] private Animator _animator;
    [SerializeField] private Rigidbody[] _allRigidBodys;

    private void OnEnable() 
    {
        for(int i = 0; i < _allRigidBodys.Length; i++)
        {
            _allRigidBodys[i].isKinematic = true;
            _allRigidBodys[i].useGravity =false;
        }
    }

    public void SwitchRagdoll()
    {
        _animator.enabled = false;

        for(int i = 0; i < _allRigidBodys.Length; i++)
        {
            _allRigidBodys[i].isKinematic = false;
        }
    }
}
