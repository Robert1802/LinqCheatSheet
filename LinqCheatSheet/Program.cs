using LinqCheatSheet;

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

// WHERE
// Assign cases only where our lawyer is equal to our looping lawyer   
foreach(Lawyer lawyer in lawyers)
    lawyer.Cases = cases.Where(c => c.Lawyer == lawyer).ToList();

foreach(Client client in clients)
    client.Cases = cases.Where(c => c.Client == client).ToList();

// FIRST
var workingFirstExample = lawyers.First(l => l.FirstName == "John");

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

// SINGLE
// Single works like FIrst, but ensures, that only a single element matches the specified condition
var workingSingleExample = lawyers.Single(lawyers => lawyers.FirstName == "John");

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


