using NUnit.Framework;

[TestFixture]
public class StudentServiceTests
{
    private List<Student> _testStudents;
    private StudentService _service;

    [SetUp]
    public void Setup()
    {
        _testStudents = new List<Student>
        {
            new() { Name = "Иван", Faculty = "ФИТ", Grades = new List<int> { 5, 4, 5 } },
            new() { Name = "Анна", Faculty = "ФИТ", Grades = new List<int> { 3, 4, 3 } },
            new() { Name = "Петр", Faculty = "Экономика", Grades = new List<int> { 5, 5, 5 } }
        };
        _service = new StudentService(_testStudents);
    }

    [Test]
    public void GetStudentsByFaculty_ReturnsCorrectStudents()
    {
        var result = _service.GetStudentsByFaculty("ФИТ").ToList();
        Assert.AreEqual(2, result.Count);
        Assert.IsTrue(result.All(s => s.Faculty == "ФИТ"));
    }

    [Test]
    public void GetFacultyWithHighestAverageGrade_ReturnsCorrectFaculty()
    {
        var result = _service.GetFacultyWithHighestAverageGrade();
        Assert.AreEqual("Экономика", result);
    }

    [Test]
    public void GetStudentsWithMinAverageGrade_ReturnsCorrectStudents()
    {
        var result = _service.GetStudentsWithMinAverageGrade(4.0).ToList();
        Assert.AreEqual(2, result.Count);
        Assert.AreEqual("Иван", result[0].Name);
        Assert.AreEqual("Петр", result[1].Name);
    }

    [Test]
    public void GetStudentsOrderedByName_ReturnsAllStudentsInOrder()
    {
        var result = _service.GetStudentsOrderedByName().Select(s => s.Name).ToList();
        Assert.AreEqual(3, result.Count);
        CollectionAssert.AreEqual(new[] { "Анна", "Иван", "Петр" }, result);
    }

    [Test]
    public void GroupStudentsByFaculty_ReturnsCorrectGroups()
    {
        var result = _service.GroupStudentsByFaculty();
        Assert.AreEqual(2, result["ФИТ"].Count());
        Assert.AreEqual(1, result["Экономика"].Count());
    }
}
