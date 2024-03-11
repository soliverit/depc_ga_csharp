/*
Problem: Base class for DEPC NSGA-II Problems
*/
public class Problem
{
	protected BuildingSet _buildings	= new BuildingSet();
	public BuildingSet buildings { get { return _buildings; } protected set { _buildings = value; } }

	public Problem(BuildingSet buildingSet)
	{
		buildings = buildingSet;
	}
}