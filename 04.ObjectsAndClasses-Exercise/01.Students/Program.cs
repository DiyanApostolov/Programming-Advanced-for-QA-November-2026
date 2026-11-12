
int n = int.Parse(Console.ReadLine());

List<Student> university = new List<Student>();

for (int i = 0; i < n; i++)
{
    string[] studentInfo = Console.ReadLine().Split(" ");
    string firstName = studentInfo[0];
    string lastName = studentInfo[1];
    double grade = double.Parse(studentInfo[2]);

    Student student = new Student(firstName, lastName, grade);

    university.Add(student);
}

foreach (Student student in university.OrderByDescending(s => s.Grade))
{
    //Console.WriteLine($"{student.FirstName} {student.LastName}: {student.Grade:F2}");
    Console.WriteLine(student.ToString());
}

class Student
{
    public Student(string firstName, string lastName, double grade)
    {
        FirstName = firstName;
        LastName = lastName;
        Grade = grade;
    }

    public string FirstName { get; private set; }

    public string LastName { get; private set; }

    public double Grade { get; private set; }

    public override string ToString()
    {
        return $"{FirstName} {LastName}: {Grade:F2}";
    }
}