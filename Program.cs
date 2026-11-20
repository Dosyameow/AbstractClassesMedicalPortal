using System;

abstract class Doctor
{
    public string Name;
    public int Experience;

    public abstract string Specialization { get; }

    public Doctor(string name, int experience)
    {
        Name = name;
        Experience = experience;
    }

    public void ShowInfo()
    {
        Console.WriteLine($"Специальность: {Specialization}");
        Console.WriteLine($"Врач: {Name}");
        Console.WriteLine($"Стаж: {Experience} лет");
    }

    public abstract void Reception();
}

class Therapist : Doctor
{
    public override string Specialization => "Терапевт";

    public Therapist(string name, int experience) : base(name, experience) { }

    public override void Reception()
    {
        Console.WriteLine("Терапевт проводит общий осмотр пациента.");
    }
}

class Cardiologist : Doctor
{
    public override string Specialization => "Кардиолог";

    public Cardiologist(string name, int experience) : base(name, experience) { }

    public override void Reception()
    {
        Console.WriteLine("Кардиолог проверяет работу сердца.");
    }
}

class Dentist : Doctor
{
    public override string Specialization => "Стоматолог";

    public Dentist(string name, int experience) : base(name, experience) { }

    public override void Reception()
    {
        Console.WriteLine("Стоматолог проводит осмотр зубов.");
    }
}

class Neurologist : Doctor
{
    public override string Specialization => "Невролог";

    public Neurologist(string name, int experience) : base(name, experience) { }

    public override void Reception()
    {
        Console.WriteLine("Невролог проводит проверку нервной системы.");
    }
}

class Patient
{
    public string Name { get; set; }
    public int Age { get; set; }
    public string Diagnosis { get; set; }

    public Patient(string name, int age, string diagnosis)
    {
        Name = name;
        Age = age;
        Diagnosis = diagnosis;
    }

    public void ShowPatientInfo()
    {
        Console.WriteLine($"Пациент: {Name}, Возраст: {Age}, Предварительный диагноз: {Diagnosis}");
    }
}

class Appointment
{
    public Patient Patient { get; set; }
    public Doctor Doctor { get; set; }
    public DateTime AppointmentDate { get; set; }

    public Appointment(Patient patient, Doctor doctor, DateTime appointmentDate)
    {
        Patient = patient;
        Doctor = doctor;
        AppointmentDate = appointmentDate;
    }

    public void ShowAppointment()
    {
        Console.WriteLine("=== ЗАПИСЬ НА ПРИЁМ ===");
        Console.WriteLine($"Дата и время: {AppointmentDate:dd.MM.yyyy HH:mm}");
        Patient.ShowPatientInfo();
        Doctor.ShowInfo();
        Doctor.Reception();
        Console.WriteLine("=======================\n");
    }
}

class Program
{
    static void Main()
    {
        Console.OutputEncoding = System.Text.Encoding.UTF8;

        Doctor therapist = new Therapist("Иван Иванов", 10);
        Doctor neurologist = new Neurologist("Елена Соколова", 12);

        Patient patient1 = new Patient("Алексей Смирнов", 34, "ОРВИ");
        Patient patient2 = new Patient("Мария Кузнецова", 45, "Мигрень");

        Appointment appointment1 = new Appointment(patient1, therapist, new DateTime(2026, 11, 25, 10, 30, 0));
        Appointment appointment2 = new Appointment(patient2, neurologist, new DateTime(2026, 11, 25, 14, 0, 0));

        appointment1.ShowAppointment();
        appointment2.ShowAppointment();
    }
}
