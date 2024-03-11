//// Imports ////

using Antlr.Runtime;

public class BuildingSet
{
	protected List<Building> _buildings	= new List<Building>();
	public List<Building> buildings { get { return _buildings; } }
	public int length { get { return buildings.Count; } }
	//// Static stuff ////
	// Methods 
	public static BuildingSet LoadDataSet(string path)
	{
		BuildingSet set						= new BuildingSet();
		GenericParsing.GenericParser parser = new GenericParsing.GenericParser(path);
		parser.FirstRowHasHeader			= true;
		
		List<string> headers = new List<string>();
		parser.Read();
		for(int headerID = 0; headerID < parser.ColumnCount; headerID++)
		{
			headers.Add(parser.GetColumnName(headerID));
		}

		// Needs to be a do loop because we needed to parser.Read() to get the headers
		do
		{
			Dictionary<string, string> data = new Dictionary<string, string>();
			for (int headerID = 0; headerID < headers.Count; headerID++)
			{
				data[headers[headerID]] = parser[headers[headerID]];
			}
			Building building = new Building(
				data,
				float.Parse(data["CURRENT_ENERGY_EFFICIENCY"]),
				data["CURRENT_ENERGY_RATING"],
				float.Parse(data["TOTAL_FLOOR_AREA"])
			);
			/*
				Add Retrofits
			*/
			// The do-nothing case
			building.addRetrofit(new Retrofit(
				RetrofitOption.AS_BUILT,
				0,
				0,
				0
			));
			for (int retrofitOptionID = 0; retrofitOptionID < RetrofitOption.RETROFIT_OPTION_KEYS.Count; retrofitOptionID++)
			{
				string retrofitKey		= RetrofitOption.RETROFIT_OPTION_KEYS[retrofitOptionID];
				RetrofitOption option	= RetrofitOption.RETROFIT_OPTION_DICTIONARY[retrofitKey];
				float efficiency		= float.Parse(data[option.efficiencyKey]);
				Retrofit retrofit = new Retrofit(
					option,
					float.Parse(data[option.costKey]),
					efficiency,
					(float)Math.Round(building.efficiency - efficiency, 0)
				);
				if(retrofit.difference > 0)
				{
					building.addRetrofit(retrofit);
				}
			}
			// Add building to set
			set.addBuilding(building);
		} while (parser.Read());
		return set;
	}
	// Constructors //
	public BuildingSet()
	{

	}
	public void addBuilding(Building building)
	{
		buildings.Add(building);
	}
	/*
		GETTERS: Methods that get values that don't have magic members. E.g {get{return _area}{
	*/
	public float getDifferenceByEfficiency(float efficiency)
	{
		float difference = 0;
		for (int buildingID = 0; buildingID < buildings.Count;  buildingID++)
		{
			float buildingDifference = efficiency - buildings[buildingID].efficiency;
			if(buildingDifference > 0)
			{
				difference += buildingDifference;
			}
		}
		return difference;
	}
	//def LoadDataSet(path) :
	//	buildings	= __class__()
	//	with open(path, 'r') as file:
	//		csv_reader = csv.DictReader(file)
	//		// Iterate over each row in the CSV file
	//		for row in csv_reader:
	//			// 'row' is a list containing the values of each column in the current row
	//			building	= Building(row, float(row["CURRENT_ENERGY_EFFICIENCY"]))
	//			buildings.append(building)
	//	return buildings
	////// Instance stuff ////
	//def __init__(self) :
	//	self.buildings	= []
	//self.area 		= 0.0
	////
	//// Add a building to the set
	////
	//// Params:
	////  building:	Building
	////	
	//// Output:	BuildingSet
	////
	//def append(self, building):
	//	self.buildings.append(building)
	//	self.area += building.area
	////
	//// Create a new set of Buildings with the target rating (A - G)
	////
	//// Params:
	//// rating:	String EPC rating A through G
	////
	//// Output:	BuildingSet
	////
	//def getByRating(self, rating):
	//	set = __class__()
	//	for building in self.buildings:
	//		if building.rating == rating:
	//			set.append(building)
	//	return set
	////
	//// Create a new set of Buildings with one of the target ratings (A - G)
	////
	//// Params:
	//// rating:	[]String EPC ratings A through G
	////
	//// Output:	BuildingSet
	////
	//def getByRatings(self, ratings):
	//	set = __class__()
	//	for building in self.buildings:
	//		for rating in ratings:
	//			if rating == building.rating:
	//				set.append(building)
	//				break
	//	return set
	////
	//// Get the number of Retrofits for all Buildings
	////
	//// Output:	Integer Retrofit count, including do-nothing
	////
	//def retrofitCount(self):
	//	count   = 0
	//	for building in self.buildings:
	//		count   += building.retrofitCount
	//	return count
	////
	//// Find cheapest to target rating Retrofits and aggregate findings.
	////
	//// For each Building: If the Building is worse than the target rating,
	//// find the cheapest measure that brings it to at least the target. If it 
	//// doesn't have one, skip the Building. Aggregate the costs and EPC points
	////
	//// Output:	Hash{
	////			cost:		float Sum of identified Retrofit implemnetation costs
	////			points:		int Target points reduction (all worse building regardless of if Retrofit is found)
	////			metPoints:	int Points actually reduce by the identified Retrofits
	//// 		}
	////
	//// Params:
	//// rating:	String EPC rating A through G
	////
	//// Output:	BuildingSet
	////
	//def getCheapestToRating(self, rating):
	//	cost            = 0.0
	//	points          = 0.0
	//	metPoints       = 0.0
	//	for building in self.buildings:
	//		// Get score, skip buildings that are at least the target rating
	//		pointDiff   = building.toRating("D")
	//		if pointDiff == 0:
	//			continue
	//		points      += pointDiff
	//		// Look for the cheapest, if any, Retrofit for the building
	//		retrofit = building.getCheapestRetrofitToEfficiency(Building.ratingLowerBound("D"))
	//		if retrofit:
	//			cost        += retrofit.cost
	//			metPoints	+= retrofit.difference
	//			ratio = retrofit.cost / retrofit.difference
	//	return {
	//	"metPoints": metPoints, 
	//		"cost": cost, 
	//		"points": points
	//	}
	////
	//// Get the number of EPC points required to raise all Buildings to the target rating.
	////
	//// params:
	////	rating:	String EPC rating (A through G)
	////
	//// Output:	Int total EPC points
	////
	//def toRatingDifference(self, rating):
	//	total	= 0
	//	for building in self.buildings:
	//		difference = Building.RATING_BRACKETS[rating]["lower"] - building.efficiency
	//		if difference > 0:
	//			total += difference
	//	return total
	////// Filters ////
	////
	//// Remove buildings with no impactful Retrofits
	////
	//def filterZeroOptionBuildings(self) :
	//	buildings = []
	//	for building in self:
	//		if building.retrofitCount > 1:	// All buildings have zero-impact measure
				
	//			buildings.append(building)
	//		else: 
	//			print(building.data["LMK_KEY"])
	//	self.buildings	= buildings
	////
	//// Filter Retrofits with a cost and ratio greater than the inputs
	////
	//def filterRetrofitsByCostAndRatio(self, cost, ratio) :
	//	for building in self.buildings:
	//		building.filterRetrofitsByCostAndRatio(cost, ratio)
	////// Properties ////
	//@property
	//def length(self):
	//	return len(self.buildings)
}