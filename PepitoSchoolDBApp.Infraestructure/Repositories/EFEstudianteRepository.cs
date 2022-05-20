using PepitoSchoolDBApp.Domain.Entities;
using PepitoSchoolDBApp.Domain.Interfaces;
using PepitoSchoolDBApp.Domain.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PepitoSchoolDBApp.Infraestructure.Repositories
{
    public class EFEstudianteRepository : IEstudianteRepository
    {
        private IPepitoSchoolDbContext dbContext;

        public EFEstudianteRepository(IPepitoSchoolDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public double CalcularPromedio(Estudiante estudiante)
        {
            try
            {
                if (estudiante == null)
                {
                    throw new ArgumentNullException("El estudiante no puede ser null");
                }
                Estudiante est = FindById(estudiante.Id);
                if (est == null)
                {
                    throw new ArgumentNullException($"El estudiante con id {estudiante.Id} no se encuentra en la base de datos");
                }
                double resultado= (est.Estadistica + est.Matematica + est.Contabilidad + est.Programacion) / 4.0;
                return Math.Round(resultado, 2);
            }
            catch (Exception)
            {

                throw;
            }
        }

        public void Create(Estudiante t)
        {
            try
            {
                ValidateStudent(t,null);
                dbContext.Estudiantes.Add(t);
                dbContext.SaveChanges();
            }
            catch (Exception)
            {
                throw;
            }
        }

        public bool Delete(Estudiante t)
        {
            try
            {
                if (t == null)
                {
                    throw new ArgumentNullException("El estudiante no puede ser null");
                }
                Estudiante estudiante = FindById(t.Id);
                if (estudiante == null)
                {
                    throw new ArgumentNullException($"El estudiante con id {t.Id} no se encuentra en la base de datos");
                }
                dbContext.Estudiantes.Remove(estudiante);
                int result = dbContext.SaveChanges();
                return result > 0;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public Estudiante FindByCarnet(string carnet)
        {
            try
            {

                StringHelper.CarnetValidation(carnet);
                return dbContext.Estudiantes.FirstOrDefault(x => x.Carnet.Equals(carnet));
            }
            catch (Exception)
            {

                throw;
            }

        }

        public Estudiante FindByEmail(string email)
        {
            try
            {

                StringHelper.EmailValidation(email);
                return dbContext.Estudiantes.FirstOrDefault(x => x.Correo.Equals(email));
            }
            catch (Exception)
            {

                throw;
            }
        }

        public Estudiante FindById(int id)
        {
            try
            {
                if (id <= 0)
                {
                    throw new ArgumentException("El id no puede ser menor o igual a 0");
                }
                return dbContext.Estudiantes.FirstOrDefault(x => x.Id == id);
            }
            catch (Exception)
            {

                throw;
            }
        }

        public Estudiante FindByPhone(string phone)
        {
            try
            {

                StringHelper.PhoneValidation(phone);
                return dbContext.Estudiantes.FirstOrDefault(x => x.Phone.Equals(phone));
            }
            catch (Exception)
            {

                throw;
            }
        }

        public List<Estudiante> GetAll()
        {
            try
            {

                return dbContext.Estudiantes.ToList();
            }
            catch (Exception)
            {

                throw;
            }
        }

        public int Update(Estudiante t)
        {
            if(t == null)
            {
                throw new ArgumentNullException("El estudiante no puede ser null");
            }
            Estudiante estudiante = FindById(t.Id);
            if (estudiante == null)
            {
                throw new ArgumentNullException($"El estudiante con id {t.Id} no se encuentra en la base de datos");
            }
            ValidateStudent(t, t);
            estudiante.Phone = t.Phone;
            estudiante.Direccion = t.Direccion;
            estudiante.Estadistica = t.Estadistica;
            estudiante.Matematica = t.Matematica;
            estudiante.Contabilidad = t.Contabilidad;
            estudiante.Programacion = t.Programacion;
            estudiante.Correo = t.Correo;
            estudiante.Carnet = t.Carnet;
            estudiante.Nombres = t.Nombres;
            estudiante.Apellidos = t.Apellidos;

            dbContext.Estudiantes.Update(estudiante);
            return dbContext.SaveChanges();
        }
        private void ValidateStudent(Estudiante estudiante, Estudiante estudiante2)
        {
            if (estudiante == null)
            {
                throw new ArgumentNullException("El estudiante no puede ser null");
            }
            if (string.IsNullOrWhiteSpace(estudiante.Nombres))
            {
                throw new ArgumentException("El nombre del estudiante no puede ser null o vacio");
            }
            if (string.IsNullOrWhiteSpace(estudiante.Apellidos))
            {
                throw new ArgumentException("El apellido del estudiante no puede ser null o vacio");
            }
            if (string.IsNullOrWhiteSpace(estudiante.Direccion))
            {
                throw new ArgumentException("La direccion del estudiante no puede ser null o vacio");
            }

            Estudiante est = FindByCarnet(estudiante.Carnet);
            if (est != estudiante2)
            {
                throw new ArgumentException("Ya existe un estudiante con ese carnet");
            }
            est = FindByEmail(estudiante.Correo);
            if (est != estudiante2)
            {
                throw new ArgumentException("Ya existe un estudiante con ese correo");
            }
            est = FindByPhone(estudiante.Phone);
            if (est != estudiante2)
            {
                throw new ArgumentException("Ya existe un estudiante con ese numero de telefono");
            }
        }
    }
}
