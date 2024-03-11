//
// Printing to console sucks. Make life easier by adding helper functions here
//
class PrintHelper
{
	public static string Pad(string input, int length)
	{
		string output = "";
		while(output.Length < length){
            output += " ";
		}
		return output;
	}
	public static string PadArray(List<string> inputs, int length)
	{
		string output = "";
		for(int i = 0; i < inputs.Count; i++)
		{
			output += Pad(inputs[i], length);
		}
		return output;
	}
}