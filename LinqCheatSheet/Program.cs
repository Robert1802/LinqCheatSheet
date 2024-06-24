using LinqCheatSheet;

// Setup Lawyers, Clients and Cases

var lawyers = new[]
{
    new Lawyer()
    {
        FirstName = "John",
        LastName = "Doe"
    },
    new Lawyer()
    {
        FirstName = "Maria",
        LastName = "Maker"
    },
};

var clients = new[]
{
    new Client()
    {
        FirstName = "Tim",
        LastName = "Funny"
    },
    new Client()
    {
        FirstName = "Jim",
        LastName = "Decker"
    },
    new Client()
    {
        FirstName = "Yana",
        LastName = "Cat"
    }
};

var cases = new[]
{
    new Case()
    {
        Title = "Car accident",
        AmountInDispute = 10000,
        CaseType = CaseType.Commercial,
        Client = clients[0],
        Lawyer = lawyers[0]
    },
    new Case()
    {
        Title = "Molding flat",
        AmountInDispute = 65000,
        CaseType = CaseType.ProBono,
        Client = clients[0],
        Lawyer = lawyers[0]
    },
    new Case()
    {
        Title = "Death threat",
        AmountInDispute = 15000,
        CaseType = CaseType.Commercial,
        Client = clients[1],
        Lawyer = lawyers[1]
    },
    new Case()
    {
        Title = "Robbery",
        AmountInDispute = 1500,
        CaseType = CaseType.Commercial,
        Client = clients[2],
        Lawyer = lawyers[1]
    },
};

// -----------------------------------------------------------------------------------------------------------------

// WHERE
// Assign cases only where our lawyer is equal to our looping lawyer   
foreach (Lawyer lawyer in lawyers)
    lawyer.Cases = cases.Where(c => c.Lawyer == lawyer).ToList();

foreach(Client client in clients)
    client.Cases = cases.Where(c => c.Client == client).ToList();

// -----------------------------------------------------------------------------------------------------------------

// FIRST
var workingFirstExample = lawyers.First(l => l.FirstName == "John");
Console.WriteLine(workingFirstExample);

try
{
    var firstExceptionExample = lawyers.First(l => l.FirstName == "Joh");
}
catch (InvalidOperationException ex)
{
    Console.WriteLine("Invalid operation exception has been thrown, cause no matching elements found.");
}

// FIRST OR DEFAULT
// FirstOrDefault returns the default value for the specified datatype, if no matching element was found.
// For classes thats null and for value types thats the default value. For int it is 0 for example.
var firstOrDefaultExample = lawyers.FirstOrDefault(l => l.FirstName == "Joh");
Console.WriteLine(firstOrDefaultExample);

// -----------------------------------------------------------------------------------------------------------------

// SINGLE
// Single works like FIrst, but ensures, that only a single element matches the specified condition
var workingSingleExample = lawyers.Single(lawyers => lawyers.FirstName == "John");
Console.WriteLine(workingSingleExample);

try
{
    var singleExceptionExample = lawyers.Single(l => l.FirstName == "Joh");
}
catch (InvalidOperationException ex)
{
    Console.WriteLine("Invalid operation exception has been thrown, cause no matching elements found.");
}

try
{
    var singleExceptionExample = lawyers.Single(l => l.LastName.Contains("e"));
}
catch (InvalidOperationException ex)
{
    Console.WriteLine("Throws invalid operation exceptin, cause more than 1 element matches the condition.");
}

// SINGLE OR DEFAULT
// SingleOrDefault returns the default value for the datatype, if no matching element was found.
// For classes thats null and for value types thats the default value. For int it is 0 for example.
// Everything else works just like Single
var singleOrDefaultExample = lawyers.SingleOrDefault(l => l.FirstName == "John");
Console.WriteLine(singleOrDefaultExample);

// -----------------------------------------------------------------------------------------------------------------

// ANY
// Any lawyer that has a case with the CaseType pro bono
var proBonoLawyers = lawyers.Where(l => l.Cases.Any(c => c.CaseType == CaseType.ProBono));
Console.WriteLine(proBonoLawyers);

// ALL
// All lawyers that have a case and the CaseType is Commercial
var commercialOnlyLawyers = lawyers.Where(l => l.Cases.All(c => c.CaseType == CaseType.Commercial));
Console.WriteLine(commercialOnlyLawyers);

// -----------------------------------------------------------------------------------------------------------------

// Working with numbers

// SUM
var sumOfAmountInDispute = cases.Sum(c => c.AmountInDispute);
Console.WriteLine(sumOfAmountInDispute);

// AVERAGE
var averageAmountInDispute = cases.Average(c => c.AmountInDispute);
Console.WriteLine(averageAmountInDispute);

// MAX
var maxAmountInDispute = cases.Max(c => c.AmountInDispute);
Console.WriteLine(maxAmountInDispute);

// MIN
var minAmountInDispute = cases.Min(c => c.AmountInDispute);
Console.WriteLine(minAmountInDispute);

// -----------------------------------------------------------------------------------------------------------------

// ORDER BY

// Ascending
var lawyersByAmountInDisputeAsc = lawyers.OrderBy(l => l.Cases.Sum(c => c.AmountInDispute));

// Descending
var lawyersByAmountInDisputeDsc = lawyers.OrderByDescending(l => l.Cases.Sum(c => c.AmountInDispute));

// -----------------------------------------------------------------------------------------------------------------

// SELECT
var caseTitles = cases.Select(c => c.Title).ToList();
var lawyerNames = lawyers.Select(l => l.FirstName + ", " + l.LastName);

// Select returns a list of lists here
var casesPerLawyer = lawyers.Select(l => l.Cases); // 2 lists of cases
// SelectMany returns a flattened list
var casesPerLawyerFlat = lawyers.SelectMany(l => l.Cases); // 4 cases

Console.Read();