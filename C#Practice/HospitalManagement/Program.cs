class Program
{
    static void Main(string[] args)
    {
        Doctor doctor = new Doctor(1, "Dr. Priya", "Cardiology");
        Nurse nurse = new Nurse(2, "Nurse Honey", "Pediatrics");
        Patient patient = new Patient(3, "Mr. Pankaj", "Heart Patient"); 
        Management.Service(doctor);
        Management.Service(nurse);
        Management.Service(patient);  
    }
}
