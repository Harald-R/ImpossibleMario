using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IEventSubject
{
    bool GetState();
    void Notify();
}
