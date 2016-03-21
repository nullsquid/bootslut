using UnityEngine;
using System.Collections;

public interface ISlutState  {

    void UpdateState();

    void ToGreenState();

    void ToYellowState();

    void ToRedState();
}
