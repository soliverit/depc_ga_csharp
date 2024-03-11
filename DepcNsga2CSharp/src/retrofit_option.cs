//
// Why do I exist? It's memory efficient to have a single option
// shared by many than a string description for each Retrofit.
//
public class RetrofitOption
{
	public static readonly string EFFICIENCY_KEY_SUFFICE	= "-Eff";
	public static readonly string COST_KEY_SUFFIX			= "-Cost";
	protected string _description;
	public string description { get { return _description; }protected set { _description = value; } }
	protected string _efficiencyKey;
	public string efficiencyKey { get { return _efficiencyKey; }protected set { _efficiencyKey = value; } }	
	protected string _costKey;
	public string costKey { get { return _costKey; }protected set { _costKey = value; } }	

	protected int _measureCount;
	public int measureCount { get { return _measureCount; }protected set { _measureCount = value; } }	
	public RetrofitOption(string desc, int count)
	{
		description		= desc;	
		measureCount	= count;
		efficiencyKey	= desc + EFFICIENCY_KEY_SUFFICE;
		costKey			= desc + COST_KEY_SUFFIX;
	}
    /* Static instances (We never want more than one per RetrofitOption, ever... */

    //
    // Since we know the entire set, it's easier just to define them all in static variables.
    //

    //
    // Static variables are cool, but dictionaries are cooler - or convenient. Either way.
    //
    public static readonly RetrofitOption ENVELOPES_HOTWATER_ROOF_WINDOWS					= new RetrofitOption("envelopes_hotwater_roof_windows", 4);
    public static readonly RetrofitOption HOTWATER_ROOF_WINDOWS								= new RetrofitOption("hotwater_roof_windows", 3);
    public static readonly RetrofitOption HOTWATER_ROOF										= new RetrofitOption("hotwater_roof", 2);
    public static readonly RetrofitOption ROOF												= new RetrofitOption("roof", 1);
    public static readonly RetrofitOption HOTWATER											= new RetrofitOption("hotwater", 1);
    public static readonly RetrofitOption ROOF_WINDOWS										= new RetrofitOption("roof_windows", 2);
    public static readonly RetrofitOption WINDOWS											= new RetrofitOption("windows", 1);
    public static readonly RetrofitOption HOTWATER_WINDOWS									= new RetrofitOption("hotwater_windows", 2);
    public static readonly RetrofitOption ENVELOPES_HOTWATER_ROOF							= new RetrofitOption("envelopes_hotwater_roof", 3);
    public static readonly RetrofitOption ENVELOPES_ROOF									= new RetrofitOption("envelopes_roof", 2);
    public static readonly RetrofitOption ENVELOPES											= new RetrofitOption("envelopes", 1);
    public static readonly RetrofitOption ENVELOPES_HOTWATER								= new RetrofitOption("envelopes_hotwater", 2);
    public static readonly RetrofitOption ENVELOPES_ROOF_WINDOWS							= new RetrofitOption("envelopes_roof_windows", 3);
    public static readonly RetrofitOption ENVELOPES_WINDOWS									= new RetrofitOption("envelopes_windows", 2);
    public static readonly RetrofitOption ENVELOPES_HOTWATER_WINDOWS						= new RetrofitOption("envelopes_hotwater_windows", 3);
    public static readonly RetrofitOption AS_BUILT											= new RetrofitOption("as_built", 0);
    public static readonly Dictionary<string, RetrofitOption> RETROFIT_OPTION_DICTIONARY	= new Dictionary<string, RetrofitOption>
	{
        {"envelopes_hotwater_roof_windows",     ENVELOPES_HOTWATER_ROOF_WINDOWS},
		{ "hotwater_roof_windows",          HOTWATER_ROOF_WINDOWS},
		{ "hotwater_roof",                  HOTWATER_ROOF},
		{ "roof",                           ROOF},
		{ "hotwater",                       HOTWATER},
		{ "roof_windows",                   ROOF_WINDOWS},
		{ "windows",                            WINDOWS},
		{ "hotwater_windows",               HOTWATER_WINDOWS},
		{ "envelopes_hotwater_roof",            ENVELOPES_HOTWATER_ROOF},
		{ "envelopes_roof",                     ENVELOPES_ROOF},
		{ "envelopes",                      ENVELOPES},
		{ "envelopes_hotwater",                 ENVELOPES_HOTWATER},
		{ "envelopes_roof_windows",             ENVELOPES_ROOF_WINDOWS},
		{ "envelopes_windows",              ENVELOPES_WINDOWS},
		{ "envelopes_hotwater_windows",         ENVELOPES_HOTWATER_WINDOWS},
		{ "as_built",                           AS_BUILT}
	};
	//
	// We shouldn't have to know what exists, personally. Just where we can find out. Which is here.
	//
	public static readonly List<string> RETROFIT_OPTION_KEYS = new List<string> {
		"envelopes_hotwater_roof_windows",
		"hotwater_roof_windows",
		"hotwater_roof",
		"roof",
		"hotwater",
		"roof_windows",
		"windows",
		"hotwater_windows",
		"envelopes_hotwater_roof",
		"envelopes_roof",
		"envelopes",
		"envelopes_hotwater",
		"envelopes_roof_windows",
		"envelopes_windows",
		"envelopes_hotwater_windows"
	};
}