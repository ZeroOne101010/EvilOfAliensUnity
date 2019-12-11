using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IceMeteorite : ParticleMeteorite, IMeteoriteState
{
    public void meteoriteStart()
    {

    }

    public void meteoriteUpdate()
    {

        particleMeteoriteUpdate();
    }
}
