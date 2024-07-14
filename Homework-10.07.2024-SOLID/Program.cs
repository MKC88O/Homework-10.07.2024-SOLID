namespace Homework_10._07._2024_SOLID
{
    public class Person
    {
        public string? FirstName { get; set; }
        public string? Surname { get; set; }
        public string? Lastname { get; set; }
        public DateOnly DateOfBirth { get; set; }
    }
    public class Country
    {
        public string? CountryName { get; set; }
    }

    public class Region
    {
        public Country? Country { get; set; }
        public string? RegionName { get; set; }
    }

    public class City
    {
        public Country? Country { get; set; }
        public Region? Region { get; set; }
        public string? CityName { get; set; }
    }
    public class Address
    {
        public City? City { get; set; }
        public string? Street { get; set; }
        public int HouseNumber { get; set; }
        public char Korpus { get; set; }
        public short PostalCode { get; set; }
    }

    public class Group
    {
        public string? GroupName { get; set; }
        public string? Specialization { get; set; }
        public int StudentsCount { get; set; }
        public DateOnly StartDate { get; set; }
        public int Kurs { get; set; }
        public Discipline? Discipline { get; set; }
    }

    public class Attendance
    {
        public int LessonsVisited { get; set; }
        public int LessonsLate { get; set; }
    }

    public class Discipline
    {
        public string? TeacherName { get; set; }
        public string? SubjectName { get; set; }
        public Attendance? Attendance { get; set; }
    }

    public class PerformanceHomeWorks
    {
        public int[]? DzRates { get; set; }
        public float DzAverageRate { get; set; }
    }

    public class PerformancePractice
    {
        public int[]? PracticeRates { get; set; }
        public float PracticeAverageRate { get; set; }
    }
    public class PerformanceExam
    {
        public int[]? ExamRates { get; set; }
        public float ExamAverageRate { get; set; }
    }
    public class PerformanceZachet
    {
        public int[]? ZachetRates { get; set; }
        public int ZachetCount { get; set; }
        public float ZachetAverageRate { get; set; }
    }
    public class Performance
    {
        public PerformanceHomeWorks? PerformanceHomeWorks { get; set; }
        public PerformancePractice? PerformancePractice { get; set; }
        public PerformanceExam? PerformanceExam { get; set; }   
        public PerformanceZachet? PerformanceZachet { get; set; }   
        public double TotalAverageRate { get; set; }
    }

    public class Student : Person
    {
        public Group? Group { get; set; }
        public Performance? Performance { get; set; }
        public StudentOtherInfo? StudentOtherInfo { get; set; }
    }

    public class StudentOtherInfo
    {
        public Address? HomeAddress { get; set; }
        public string? ZnakZodiaka { get; set; }
    }
    internal class Program
    {
        static void Main(string[] args)
        {
            Country country =  new () { CountryName = "Украина" };

            Region region = new () { Country = country, RegionName = "Одесская область" };

            City city = new () { Country = country, Region = region, CityName = "Одесса" };

            Address address = new () { City = city, Street = "Болгарская", HouseNumber = 87, Korpus = 'A', PostalCode = 6509 };

            Attendance attendance = new() { LessonsVisited = 90, LessonsLate = 2 };

            Discipline discipline = new() { TeacherName = "Александр Дмитриевич", SubjectName = ".Net Framework", Attendance = attendance };

            Group group = new () { GroupName = "ПВ312", Specialization = "Разработчик програмного обеспечения", StudentsCount = 6, 
                StartDate = new DateOnly(2023, 11, 20), Kurs = 1, Discipline = discipline };

            PerformanceHomeWorks performanceHomeworks = new () { DzRates = [ 12, 11, 10 ], DzAverageRate = (12 + 11 + 10) / (float)3 };

            PerformancePractice performancePractice = new () { PracticeRates = [ 11, 10, 9 ], PracticeAverageRate = (11 + 10 + 9) / (float)3};

            PerformanceExam performanceExam = new () { ExamRates = [ 12, 11, 11 ], ExamAverageRate = (12 + 11 + 11) / (float)3 };

            PerformanceZachet performanceZachet = new () { ZachetRates = [ 12, 12, 11 ], ZachetCount = 3, ZachetAverageRate = (12 + 12 + 11) / (float)3 };

            Performance performance = new () { PerformanceHomeWorks = performanceHomeworks, PerformancePractice = performancePractice, 
                PerformanceExam = performanceExam, PerformanceZachet = performanceZachet, TotalAverageRate = (performanceHomeworks.DzAverageRate + 
                performancePractice.PracticeAverageRate + performanceExam.ExamAverageRate + performanceZachet.ZachetAverageRate) / (float)4 };

            StudentOtherInfo studentOtherInfo = new() { HomeAddress = address, ZnakZodiaka = "Скорпион" };

            Student student = new () { FirstName = "Иванов", Surname = "Иван", Lastname = "Иванович", DateOfBirth = new DateOnly(2001, 01, 01), 
                 Group = group, Performance = performance, StudentOtherInfo = studentOtherInfo};


            Console.WriteLine("Студент: \t" + student.FirstName + " " + student.Surname + " " + student.Lastname);
            Console.WriteLine("Дата рождения: \t" + student.DateOfBirth);
            Console.WriteLine("Домашний адрес:\t улица " + student.StudentOtherInfo.HomeAddress.Street + ", " + student.StudentOtherInfo.HomeAddress.HouseNumber + 
                student.StudentOtherInfo.HomeAddress.Korpus + ", " + student.StudentOtherInfo.HomeAddress.City?.CityName + ", " + 
                student.StudentOtherInfo.HomeAddress.City?.Region?.RegionName + ", " + student.StudentOtherInfo.HomeAddress.City?.Country?.CountryName +
                ", " + student.StudentOtherInfo.HomeAddress.PostalCode);

            Console.WriteLine("Знак зодиака: \t" + student.StudentOtherInfo.ZnakZodiaka);
            Console.WriteLine("Группа: \t" + student.Group.GroupName);
            Console.WriteLine("Специализация: \t" + student.Group.Specialization);
            Console.WriteLine("Дисциплина: \t" + group.Discipline?.SubjectName);
            Console.WriteLine("Преподователь: \t" + group.Discipline?.TeacherName);
            Console.WriteLine("Посещаемость:");
            Console.WriteLine("\tПосещено занятий: \t" + group.Discipline?.Attendance.LessonsVisited);
            Console.WriteLine("\tОпозданий: \t\t" + group.Discipline?.Attendance.LessonsLate);
            Console.WriteLine("Успеваемость: ");
            Console.WriteLine("\tДомашние задания: \t" + Math.Round(student.Performance.PerformanceHomeWorks.DzAverageRate, 2));
            Console.WriteLine("\tПрактика: \t\t" + Math.Round(student.Performance.PerformancePractice.PracticeAverageRate, 2));
            Console.WriteLine("\tЭкзамены: \t\t" + Math.Round(student.Performance.PerformanceExam.ExamAverageRate, 2));
            Console.WriteLine("\tЗачеты: \t\t" + Math.Round(student.Performance.PerformanceZachet.ZachetAverageRate, 2));
            Console.WriteLine("\tОбщий Средний балл: \t" + Math.Round(student.Performance.TotalAverageRate, 2));
        }    
    }
}
