using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IPlayerInput
{
    Vector3 GetInput();

    bool GetInputJump();
}
