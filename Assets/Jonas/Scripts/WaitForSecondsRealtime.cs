using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaitForSecondsRealtime : CustomYieldInstruction
{
    private float m_WaitTime;
    private float m_StartTime;

    public override bool keepWaiting
    {
        get { return Time.realtimeSinceStartup - m_StartTime < m_WaitTime; }
    }

    public WaitForSecondsRealtime(float time)
    {
        m_WaitTime = time;
        m_StartTime = Time.realtimeSinceStartup;
    }
}
