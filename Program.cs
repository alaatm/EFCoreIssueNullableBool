using System.Runtime.CompilerServices;
using Microsoft.EntityFrameworkCore;
using EFCoreIssueNullableBool;

using (var db = new MyContext())
{
    db.Database.EnsureDeleted();
    db.Database.EnsureCreated();

    var vehicle = new Vehicle { Registration = new() };
    db.Vehicles.Add(vehicle);
    await db.SaveChangesAsync();
}

Test(db => db.Vehicles.Where(p => !p.Registration.Approved ?? true));
Console.WriteLine();
Console.WriteLine("==========================================================");
Console.WriteLine();
Test(db => db.Vehicles.Where(p => p.Registration.Approved == null || !p.Registration.Approved.Value));

static void Test(Func<MyContext, IQueryable<Vehicle>> f, [CallerArgumentExpression("f")] string expression = "")
{
    Console.WriteLine(expression);
    Console.WriteLine("-----------------------");
    using var db = new MyContext();
    var q = f(db);
    var s = q.ToQueryString();
    var r = q.ToArray();
    Console.WriteLine(s);
    Console.WriteLine("-----------------------");
    Console.WriteLine($"Expected 1, got {r.Length}");
}
