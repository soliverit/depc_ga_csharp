//
// Struct for Retrofit information
//
class Retrofit
{
	protected RetrofitOption _option;
	public RetrofitOption option { get { return _option; } protected set { _option = value; } }
	public int measureCount { get { return _option.measureCount; } }

	protected float _cost;
	public float cost { get { return _cost; }protected set { _cost = value; } }
	protected float _efficiency;
	public float efficiency { get { return _efficiency; }protected set { _efficiency = value; } }
	protected float _difference;
	public float difference { get { return _difference; }protected set { _difference = value; } }	
	
	public Retrofit(RetrofitOption retrofitOption, float cost, float efficiency, float difference) 
	{
		option = retrofitOption;
		
	}
	// Get number of measures in this Retrofit:
	//
	// Output:	int Number of measures as defined by the RetrofitOption
	//
	
}