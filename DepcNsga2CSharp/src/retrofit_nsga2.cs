//
// Retrofit NSGA-II
//
class RetrofitNSGA2
{
	public int generations		= 100;
	public int population		= 49;
	public int children			= 20;
	public float crossoverProb	= 0.9f;
	public float crossoverETA	= 15;
	public float mutationETA	= 15;
	public RetrofitNSGA2()
	{

	}
	public void createAlgorithm()
	{

	}
    // Create algorithm
    //
    // Define the pymoo.NSGA2 model. If self.crossover = True, include crossover
    //

    //
    // Run the pymoo.NSGA2 optimiser
    //
    public void run()
	{

    }
	//
	// Get the results from the last process
	//
	// Output: Hash{
	//		cost:	float total cost of selected Retrofits
	//		points:	int total number of EPC points improved
	//	}
	//
	public Dictionary<string, float> getResult()
	{
		return new Dictionary<string, float>{ { "shoe", 15} };
	}
	//
	// Print Problem summary and Benchmark
	//
	// The Benchmark: Our base target is to meet the cheapest possible strategy
	// for all Buildings worse than the target. Primarily, we're interested in 
	// the cost to point difference ratio, though the number of points targeted
	// and number met by the cheapest Retrofit selection are also useful.
	//
	public void printBenchmark()
	{

	}
	//
	// I'm not even documenting this one. Does what it says on the tin
	//
	public void printResults()
	{

	}
	public void writeHistory(string path)
	{

	}
	public static Dictionary<string, string> parseCMD()
	{
		return new Dictionary<string, string> { };
	}

}