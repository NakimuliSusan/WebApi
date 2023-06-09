using ContosoPizza.Models;
using ContosoStudent.Models;

namespace ContosoStudent.Services;


public static class StudentService
{

    static List<Student> Students { get; }
    static int nextId = 4;
    static StudentService()
    {
        Students = new List<Student>
        {
            new Student { Id = 1, 
                FirstName = "Susan",
                LastName = "Nakimuli", 
                Email = "nakimulimarysusan@gmail.com", 
                Age= 23, 
                PhoneNumber= "0706112100"
            },
            new Student { Id =2, 
                FirstName = "Nasser",
                LastName= "Kawesa",
                Email = "kawesanasser@gmail.com",
                Age = 28 , 
                PhoneNumber= "0703694246"},
            new Student { Id =3,
                FirstName= "Emma",
                LastName="Kamau",
                Email= "ekamau@gmail.com",
                Age = 24,
                PhoneNumber= "078856756"}
        };
    }
    // this method gets all the student objects in the list
    public static List<Student> GetAll() => Students;

    // this method gets a student object with a specified id
    public static Student? Get(int id) => Students.FirstOrDefault(p => p.Id == id);

    // this creates a student object and increments the id from the last student object
    public static void Add(Student student)
    {
        student.Id = nextId++;
        Students.Add(student);
    }

    // this deletes the student object using the id that has been specified
    public static void Delete(int id)
    {
        var student = Get(id);
        if (student is null)
            return;

        Students.Remove(student);
    }

    // this updates the info about student object already created using the index in the list

    public static void Update(Student student)
    {
        var index = Students.FindIndex(p => p.Id == student.Id);
        if (index == -1)
            return;

        Students[index] = student;
    }




}