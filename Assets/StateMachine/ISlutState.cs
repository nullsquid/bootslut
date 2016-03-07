using UnityEngine;
using System.Collections;

public interface ISlutState  {

    void Update();

    void OnTriggerEnter2D(Collider2D other);

    void ToGreenState();

    void ToYellowState();

    void ToRedState();
}
