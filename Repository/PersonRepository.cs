using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SQLite;
using glopezS5A.Models;

namespace glopezS5A.Repository
{
    public class PersonRepository
    {
         
        
        string dbPath;
        private SQLiteConnection conn;
        public string statusMessage { get; set; }

        public PersonRepository(string path)
        {
            dbPath = path;
        }
        private void Init()
        {
            if(conn is not null)
                return;
            conn = new (dbPath);
            conn.CreateTable<Persona>();
        }
        public void AddNewPerson(string name) 
        {
            int result = 0;
            try
            {
                Init();
                if (string.IsNullOrEmpty(name))
                    throw new Exception("el nombre es requerido");

                Persona persona = new (){Name = name };
                result = conn.Insert(persona);
                statusMessage = string.Format("Dato ingresado");
            }
            catch (Exception ex)
            {

                statusMessage = string.Format("ERROR" + ex);
            }
        }

        public List<Persona> GetPersonas()
        {
            try
            {
                Init();
                return conn.Table<Persona>().ToList();

            }
            catch (Exception ex)
            {

                statusMessage = string.Format("ERROR" + ex);
            }
            return new List<Persona>();
        }

        public void UpdatePerson(int id, string name)
        {
            try
            {
                Init();
                var persona = conn.Table<Persona>().FirstOrDefault(p => p.Id == id);
                if (persona == null)
                    throw new Exception("Persona no encontrada");

                persona.Name = name;
                conn.Update(persona);
                statusMessage = "Persona actualizada";
            }
            catch (Exception ex)
            {
                statusMessage = "ERROR: " + ex.Message;
            }
        }

        public void DeletePerson(int id)
        {
            try
            {
                Init();
                var persona = conn.Table<Persona>().FirstOrDefault(p => p.Id == id);
                if (persona == null)
                    throw new Exception("Persona no encontrada");

                conn.Delete(persona);
                statusMessage = "Persona eliminada";
            }
            catch (Exception ex)
            {
                statusMessage = "ERROR: " + ex.Message;
            }
        }

    }
}
