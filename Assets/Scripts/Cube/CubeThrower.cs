using UnityEngine;

namespace Cube
{
    public class CubeThrower : CubeHandler
    {
        [SerializeField] private float _throwForce;

        protected override void OnPressCanceled()
        {
            if (!CubeUnit.IsMainCube) return;
            
            CubeUnit.Rigidbody.linearVelocity = Vector3.forward * _throwForce;
            CubeUnit.SetMainCube(false);
            
            base.OnPressCanceled();
        }
    }
}