using UnityEngine;
using System.Collections;
using Vuforia;

public class TrackableImageManager : DefaultTrackableEventHandler
{
    protected override void OnTrackingFound()
    {
        base.OnTrackingFound();
        // When target is found
        RandomSpawn.canSpawn = false;
    }

    protected override void OnTrackingLost()
    {
        base.OnTrackingLost();
        // When target is found
        RandomSpawn.canSpawn = true;
    }
}
