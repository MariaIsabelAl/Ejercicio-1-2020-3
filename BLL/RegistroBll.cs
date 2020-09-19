using Microsoft.EntityFrameworkCore;
using RegistroBlazor.DAL;
using RegistroBlazor.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace RegistroBlazor.BLL
{
    public class PersonasBll
    {

        
         public static bool Guardar(Personas personas)
        {
            if (!Existe(personas.ID))

                return Insertar(personas);
            else
                return Modificar(personas);

        }

        private static bool Insertar(Personas personas)
        {
            bool paso = false;
            Contexto _contexto=new Contexto();

            try
            {
                _contexto.Personas.Add(personas);
                paso = _contexto.SaveChanges() > 0;
            }
            catch (Exception)
            {

                throw;

            }
            finally
            {
                _contexto.Dispose();
            }
            return paso;
        }


        private static bool Modificar(Personas personas)
        {
            bool paso = false;
            Contexto _contexto=new Contexto();

            try
            {

                _contexto.Entry(personas).State = EntityState.Modified;
                paso = _contexto.SaveChanges() > 0;

            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                _contexto.Dispose();
            }
            return paso;
        }

        public static bool Eliminar(int id)
        {
            bool paso = false;
           Contexto _contexto=new Contexto();

            try
            {
                var eliminar=_contexto.Personas.Find(id);
                _contexto.Entry(eliminar).State= EntityState.Deleted;

                paso=(_contexto.SaveChanges()>0);
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                _contexto.Dispose();
            }
            return paso;
        }

        public static Personas Buscar(int id)
        {
            
            Personas personas;
            Contexto _contexto=new Contexto();

            try
            {
                personas = _contexto.Personas.Find(id);
            }
            catch (Exception)
            {

                throw;
            }
            finally
            {
                _contexto.Dispose();
            }
            return personas;

        }

        public static bool Existe(int id)
        {
            
            bool encontrado = false;
            Contexto _contexto=new Contexto();

            try
            {
                encontrado = _contexto.Personas.Any(p => p.ID == id);

            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                _contexto.Dispose();
            }

            return encontrado;

        }

        public static List<Personas> GetList(Expression<Func<Personas, bool>> personas)
        {
            List<Personas> Lista= new List<Personas>();
            Contexto _contexto=new Contexto();

            try
            {
                Lista = _contexto.Personas.Where(personas).ToList();
            }
            catch(Exception)
            {
                throw;
            }
            finally
            {
                _contexto.Dispose();
            }
            return Lista;
        }
    }
}