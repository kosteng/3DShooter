using UnityEngine;
namespace ModelGame
{
    public class InputController : BaseController
    {
        private KeyCode _codeFlashLight = KeyCode.F;
        public override void OnUpdate()
        {
            if (Input.GetKeyDown(_codeFlashLight))
        }
    }
}
