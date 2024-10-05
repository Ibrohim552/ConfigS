using EFcoreWebAPi.DataContext;
using EFcoreWebAPi.Models;
using Microsoft.EntityFrameworkCore;

namespace EFcoreWebAPi.Services;

public class DoctorServices(ApplicationContext dbContext):IDoctor
{
    public async Task<bool> CreateDoctor(Doctors doctor)
    {
        try
        {
            await dbContext.Doctor.AddAsync(doctor);
            return await dbContext.SaveChangesAsync()>0;
        }
        catch (Exception e)
        {
            Console.WriteLine(e.Message);
            throw;
        }
    }

    public  async Task<bool> UpdateDoctor(Doctors doctor)
    {
        try
        {
            Doctors? doctors = await dbContext.Doctor.FindAsync(doctor.Id);
            if (doctors==null) return false;
            doctors.Name = doctor.Name;
            doctors.Specialization = doctor.Specialization;
            doctors.PhoneNumber = doctor.PhoneNumber;
            doctors.BirthDay = doctor.BirthDay;
            return await dbContext.SaveChangesAsync()>0;


        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
    }

    public async Task<bool> DeleteDoctor(int id)
    {
        try
        {
            Doctors doctors = await dbContext.Doctor.FindAsync(id);
            if (doctors == null) return false;
            dbContext.Doctor.Remove(doctors);
            return await dbContext.SaveChangesAsync()>0;

        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
    }

    public async Task<Doctors> GetDoctorById(int id)
    {
        try
        {
            return  await dbContext.Doctor.FindAsync(id);

        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
    }

    public async Task<IEnumerable<Doctors>> GetAllDoctors()
    {
        try
        {
            return await dbContext.Doctor.ToListAsync();
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
    }
}