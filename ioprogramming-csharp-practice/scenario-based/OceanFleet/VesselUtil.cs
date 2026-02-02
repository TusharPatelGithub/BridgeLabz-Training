using System.Collections.Generic;
public class VesselUtil
{
    private List<Vessel> vesselList = new List<Vessel>();
    //getter and setter
    public List<Vessel> VesselList
    {
        get { return vesselList; }
        set { vesselList = value; }
    }
    //requirement 1: Add vessel performance
    public void AddVesselPerformance(Vessel vessel)
    {
        vesselList.Add(vessel);
    }
    //requirement 2: Retrieve vessel by ID (case-sensitive)
    public Vessel GetVesselById(string vesselId)
    {
        foreach (Vessel vessel in vesselList)
        {
            if (vessel.VesselId == vesselId)
            {
                return vessel;
            }
        }
        return null;
    }
    //requirement 3: Retrieve high performance vessels
    public List<Vessel> GetHighPerformanceVessels()
    {
        List<Vessel> result = new List<Vessel>();
        if (vesselList.Count == 0)
            return result;
        double maxSpeed = vesselList[0].AverageSpeed;
        foreach (Vessel vessel in vesselList)
        {
            if (vessel.AverageSpeed > maxSpeed)
            {
                maxSpeed = vessel.AverageSpeed;
            }
        }
        foreach (Vessel vessel in vesselList)
        {
            if (vessel.AverageSpeed == maxSpeed)
            {
                result.Add(vessel);
            }
        }
        return result;
    }
}
