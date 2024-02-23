using HTTPUtils;
using System.Text.Json;
using AnsiTools;
using Colors = AnsiTools.ANSICodes.Colors;

Console.Clear();
Console.WriteLine("Starting Assignment 2");


const string myPersonalID = "dd7d5c72da660ddbc93569150177b5e9eba44d19733be8282b77802d5b53020a";
const string baseURL = "https://mm-203-module-2-server.onrender.com/";
const string startEndpoint = "start/";
const string taskEndpoint = "task/";
HttpUtils httpUtils = HttpUtils.instance;


Response startRespons = await httpUtils.Get(baseURL + startEndpoint + myPersonalID);
Console.WriteLine($"Start:\n{Colors.Magenta}{startRespons}{ANSICodes.Reset}\n\n");
string taskID = "aAaa23";


Response task1Response = await httpUtils.Get(baseURL + taskEndpoint + myPersonalID + "/" + taskID);
Task task1 = JsonSerializer.Deserialize<Task>(task1Response.content);
Console.WriteLine($"TASK: {ANSICodes.Effects.Bold}{task1?.title}{ANSICodes.Reset}\n{task1?.description}\nParameters: {Colors.Yellow}{task1?.parameters}{ANSICodes.Reset}");

//task1!!!

double fahrenheit = double.Parse(task1.parameters);

double celsius = FahrenheitToCelsius(fahrenheit);

string answer = celsius.ToString("0.00");

Response task1AnswerResponse = await httpUtils.Post(baseURL + taskEndpoint + myPersonalID + "/" + taskID, answer);
Console.WriteLine($"Answer: {Colors.Green}{task1AnswerResponse}{ANSICodes.Reset}");

double FahrenheitToCelsius(double fahrenheit)
{
    return (fahrenheit - 32) * 5 / 9;
}


Console.WriteLine("-----------------");


//task 2 starts now!!!



taskID = "rEu25ZX";

Response task2Response = await httpUtils.Get(baseURL + taskEndpoint + myPersonalID + "/" + taskID);
Console.WriteLine(task2Response);

Task task2 = JsonSerializer.Deserialize<Task>(task2Response.content);
Console.WriteLine($"Task: {ANSICodes.Effects.Bold}{task2?.title}{ANSICodes.Reset}\n{task2?.description}\nParameters: {Colors.Cyan}{task2?.parameters}{ANSICodes.Reset}");


string normalNumbers = string.Join(",", task2?.parameters.Split(',').Select(RomanToInt).Select(n => n.ToString()));

static int RomanToInt(string s)
{
    int total = 0;
    int prevValue = 0;

    for (int i = s.Length - 1; i >= 0; i--)
    {
        int currentValue = GetValueOfRomanNumeral(s[i]);

        if (currentValue < prevValue)
        {
            total -= currentValue;
        }
        else
        {
            total += currentValue;
        }

        prevValue = currentValue;
    }

    return total;
}

static int GetValueOfRomanNumeral(char roman)
{
    switch (roman)
    {
        case 'I': return 1;
        case 'V': return 5;
        case 'X': return 10;
        case 'L': return 50;
        case 'C': return 100;
        case 'D': return 500;
        case 'M': return 1000;
        default: throw new ArgumentException("Invalid Roman numeral.");
    }
}
Response task2AnswerResponse = await httpUtils.Post(baseURL + taskEndpoint + myPersonalID + "/" + taskID, normalNumbers);
Console.WriteLine($"Answer: {Colors.Green}{task2AnswerResponse}{ANSICodes.Reset}");




Console.WriteLine("-----------------");




//task3!!! yheee


taskID = "KO1pD3";

Response task3Response = await httpUtils.Get(baseURL + taskEndpoint + myPersonalID + "/" + taskID);
Console.WriteLine(task3Response);


Task task3 = JsonSerializer.Deserialize<Task>(task3Response.content);
Console.WriteLine($"Task: {ANSICodes.Effects.Bold}{task3?.title}{ANSICodes.Reset}\n{task3?.description}\nParameters: {Colors.Cyan}{task3?.parameters}{ANSICodes.Reset}");


int[] numbers = task3.parameters.Split(',').Select(int.Parse).ToArray();


int commonDifference = numbers[1] - numbers[0];

int nextNumber = numbers[numbers.Length - 1] + commonDifference;

string answerString = nextNumber.ToString();

Response task3AnswerResponse = await httpUtils.Post(baseURL + taskEndpoint + myPersonalID + "/" + taskID, answerString);
Console.WriteLine($"Answer: {Colors.Green}{task3AnswerResponse}{ANSICodes.Reset}");



Console.WriteLine("-----------------");




//task4!!!!!!final countdown





taskID = "psu31_4";

Response task4Response = await httpUtils.Get(baseURL + taskEndpoint + myPersonalID + "/" + taskID);
Console.WriteLine(task4Response);


Task task4 = JsonSerializer.Deserialize<Task>(task4Response.content);
Console.WriteLine($"Task: {ANSICodes.Effects.Bold}{task4?.title}{ANSICodes.Reset}\n{task4?.description}\nParameters: {Colors.Cyan}{task4?.parameters}{ANSICodes.Reset}");








int sum = task4.parameters.Split(',').Select(int.Parse).Sum();
answerString = sum.ToString();


Response task4AnswerResponse = await httpUtils.Post(baseURL + taskEndpoint + myPersonalID + "/" + taskID, answerString);
Console.WriteLine($"\nAnswer: {Colors.Green}{task4AnswerResponse}{ANSICodes.Reset}");




class Task
{
    public string? title { get; set; }
    public string? description { get; set; }
    public string? taskID { get; set; }
    public string? usierID { get; set; }
    public string? parameters { get; set; }
}


