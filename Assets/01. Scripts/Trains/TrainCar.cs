using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrainCar : MonoBehaviour
{
    private TrainCarInfo trainCarInfo = null;

    private void OnMouseDown()
    {
        SkillManager.Instance.UseSkill();
    }
}
