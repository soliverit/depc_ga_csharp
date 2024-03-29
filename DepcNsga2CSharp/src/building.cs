
public class Building
{
	//
	// Static stuff
	//
	// Members
	public static Dictionary<string, Dictionary<string, float>> RATING_BRACKETS = new Dictionary<string, Dictionary<string, float>> {
		{ "A", new Dictionary<string,float>{{"lower", 92}, {"upper", 999} } },
		{ "B", new Dictionary<string,float>{{"lower", 81}, {"upper", 91} } },
		{ "C", new Dictionary<string,float>{{"lower", 69}, {"upper",80} } },
		{ "D", new Dictionary<string,float>{{"lower", 55}, {"upper", 68} } },
		{ "E", new Dictionary<string,float>{{"lower", 39}, {"upper", 54} } },
		{ "F", new Dictionary<string,float>{{"lower", 21}, {"upper", 38} } },
		{ "G", new Dictionary<string,float>{{"lower", -999}, {"upper", 20} } } };
	// Methods
	/*
	 Instance stuff
	*/
	// Members
	protected List<Retrofit> _retrofits = new List<Retrofit>();
	public List<Retrofit> retrofits { get { return _retrofits; } }
	protected Dictionary<string, string> _data = new Dictionary<string, string>();
	protected Dictionary<string, string> data { get { return _data; } set { _data = value; } }

	protected float _efficiency;
    public float efficiency { get{ return _efficiency; } protected set { _efficiency = value; } }

	protected string _rating;
    public string rating { get { return _rating; } protected set { _rating = value; } }

	protected float _area;
	public float area { get { return _area; } protected set { _area = value; } }
	protected BuildingSet _buildings = new BuildingSet();
	public BuildingSet buildings { get { return _buildings; } }
	// Methods
	public static float ratingLowerBound(string rating)
	{
		return RATING_BRACKETS[rating]["lower"];
	}
	public static float ratingUpperBound(string rating)
	{
		return RATING_BRACKETS[rating]["upper"];
	}
	public Building(Dictionary<string, string> csvData,  float eff, string epcRating, float buildingArea)
	{
		data		= csvData;
		efficiency	= eff;
		rating		= epcRating;
		area		= buildingArea;
	}
	public void addRetrofit(Retrofit retrofit)
	{
		retrofits.Add(retrofit);
	}
	//
	// Instance stuff
	//
	//def __init__(self, data, efficiency):
	//	// Set variables
	//	self.data		= data
	//	self.rating		= self.data["CURRENT_ENERGY_RATING"]
	//	self.area		= float(self.data["TOTAL_FLOOR_AREA"])
	//	self.efficiency	= efficiency
	//	self.retrofits	= []
	//	// Parse retrofits
	//	// As-built (do nothing)
	//	retrofit	= Retrofit(
	//		RetrofitOption.AS_BUILT,
	//		0,
	//		0,
	//		0
	//	)
	//	// Building-specific 
	//	self.addRetrofit(retrofit)
	//	for key in RetrofitOption.RETROFIT_OPTION_KEYS:
	//		retrofitOption	= RetrofitOption.RETROFIT_OPTION_DICTIONARY[key]
	//		efficiency		= floor(float(self.data[retrofitOption.efficiencyKey]))
	//		// Skip Retrofits that do less than 1 index point of improvement
	//		if efficiency != -1 and efficiency > self.efficiency:
	//			cost		= float(self.data[retrofitOption.costKey])
	//			retrofit	= Retrofit(
	//				retrofitOption,
	//				cost,
	//				round(efficiency),
	//				round(efficiency - self.efficiency)
	//			)
	//			self.addRetrofit(retrofit)
	//def toRating(self, rating):
	//	target	= Building.RATING_BRACKETS[rating]["lower"]
	//	if self.efficiency < target:
	//		return target - self.efficiency
	//	return 0
	////
	//// Get Retrofit by index
	////
	//def getRetrofit(self, id):
	//	return self.retrofits[id]
	////
	//// Add Retrofit: TODO: Check uniqueness
	////
	//def addRetrofit(self, retrofit):
	//	self.retrofits.append(retrofit)
	////
	//// Remov Retrofits with a cost and ratio greater than the inputs
	////
	//// Params:
	////	cost:	float highest acceptable cost
	////	ratio:	float highest acceptable ratio
	////
	//def filterRetrofitsByCostAndRatio(self, cost, ratio):
	//	retrofits	= []
	//	for retrofit in self.retrofits:
	//		if retrofit.cost < cost or retrofit.impactRatio < ratio:
	//			retrofits.append(retrofit)
	//	self.retrofits	= retrofits
	////// Properties
	////
	//// Get number of retrofits, including as-built
	////
	//@property
	//def retrofitCount(self):
	//	return len(self.retrofits)
	////// Retrofit stuff ////
	////
	//// Find cheapest option to get to the target efficiency.
	////
	//// Params:
	////	efficiency:	int minimum EPC efficiency
	////
	//// Output:
	////	Retrofit the cheapest to meet the efficiency OR bool False, no Retrofit found
	////
	//def getCheapestRetrofitToEfficiency(self, efficiency):
	//	result	= False
	//	cost 	= 9999999999999
	//	for retrofit in self.retrofits:
	//		if retrofit.efficiency >= efficiency and retrofit.cost <  cost:
	//			result	= retrofit
	//			cost	= retrofit.cost
	//	return result
}