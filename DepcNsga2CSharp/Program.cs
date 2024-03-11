// See https://aka.ms/new-console-template for more information
using GeneticSharp;
using System.Diagnostics;

Console.WriteLine("Hello, World!");

const string CSV_PATH	= "C:/workspaces/__sandbox__/depc/large_retrofits.csv";
// Load buildings
Stopwatch stopwatch = new Stopwatch();
stopwatch.Start();
BuildingSet buildings	= BuildingSet.LoadDataSet(CSV_PATH);
stopwatch.Stop();
Console.WriteLine(stopwatch.Elapsed);
// Do random stuff
float target = Building.RATING_BRACKETS["D"]["lower"];
stopwatch.Restart();
float e = 0;
for (int i = 0; i < 500; i++)
{
	e += buildings.getDifferenceByEfficiency(target);
}
stopwatch.Stop();
Console.WriteLine(stopwatch.Elapsed);
Console.WriteLine(e);