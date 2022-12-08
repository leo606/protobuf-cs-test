using Google.Protobuf;
using Google.Protobuf.WellKnownTypes;
using Grpc.Course.Protobuf.Test;

Console.WriteLine("protobuf test");

var emp = new Employee();

emp.FirstName = "foo";
emp.LastName = "bar";
emp.IsRetired = false;
var birthDate = new DateTime(1999, 7, 9);
birthDate = DateTime.SpecifyKind(birthDate, DateTimeKind.Utc);
emp.BirthDate = Timestamp.FromDateTime(birthDate);
emp.MaritalStatus = Employee.Types.MaritalStatus.Married;
emp.PreviousEmployers.Add("company1");
emp.PreviousEmployers.Add("company2");
emp.Age = 9;
emp.Relative.Add("father", "dad");
emp.Relative.Add("mother", "mom");
emp.Relative.Add("brother", "bro");

using (var output = File.Create("emp.dat"))
{
  emp.WriteTo(output);
}

Employee empFromFile;
using (var input = File.OpenRead("emp.dat"))
{
  empFromFile = Employee.Parser.ParseFrom(input);
}

Console.WriteLine("protobuf test done");
