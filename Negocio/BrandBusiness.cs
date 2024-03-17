using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain;

namespace Business
{
    public class BrandBusiness
    {
        private DataAccess data;

        public BrandBusiness() 
        {
            data = new DataAccess();
        }

        public List<Brand> list()
        {
            List<Brand> list = new List<Brand>();

            try
            {
                data.setQuery("Select Id, Descripcion from MARCAS");
                data.executeRead();

                while (data.Reader.Read())
                {
                    Brand brand = new Brand();

                    brand.id = (int)data.Reader["Id"];
                    brand.description = (string)data.Reader["Descripcion"];

                    list.Add(brand);
                }

                return list;
            }
            catch (Exception ex)
            {
                throw ex;
            } finally
            {
                data.closeConnection();
            }
        }

        public Brand searchByDescription(string description)
        {
            Brand brand = new Brand();
            try
            {
                data.setQuery("Select Id, Descripcion from MARCAS where Descripcion = @description");
                data.setParam("@description", description);
                data.executeRead();

                data.Reader.Read();
                brand.id = (int)data.Reader["Id"];
                brand.description = (string)data.Reader["Descripcion"];

                return brand;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void add(Brand brand)
        {
            try
            {
                data.setQuery("Insert into MARCAS (Descripcion) values (@description)");
                data.setParam("@description", brand.description);
                data.executeAction();
            }
            catch (Exception ex)
            {
                throw ex;
            } finally
            {
                data.closeConnection();
            }
        }

        public void update(Brand brand)
        {
            try
            {
                data.setQuery("Update MARCAS set Descripcion = @description where Id = @id");
                data.setParam("@description", brand.description);
                data.setParam("@id", brand.id);
                data.executeAction();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                data.closeConnection();
            }
        }

        public void delete(Brand brand)
        {
            try
            {
                data.setQuery("Delete MARCAS where Id = @id");
                data.setParam("@id", brand.id);
                data.executeAction();
            }
            catch (Exception ex)
            {
                throw ex;
            } finally 
            { 
                data.closeConnection();
            }
        }
    }
}
