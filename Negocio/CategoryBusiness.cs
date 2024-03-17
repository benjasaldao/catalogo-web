using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain;

namespace Business
{
    public class CategoryBusiness
    {
        private DataAccess data;

        public CategoryBusiness()
        {
            data = new DataAccess();
        }

        public List<Category> list()
        {
            List<Category> list = new List<Category>();

            try
            {
                data.setQuery("select id, Descripcion from CATEGORIAS");
                data.executeRead();

                while(data.Reader.Read())
                {
                    Category category = new Category();

                    category.id = (int)data.Reader["Id"];
                    category.description = (string)data.Reader["Descripcion"];

                    list.Add(category);
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

        public Category searchByDescription(string description)
        {
            Category category = new Category();
            try
            {
                data.setQuery("Select Id, Descripcion from CATEGORIAS where Descripcion = @description");
                data.setParam("@description", description);
                data.executeRead();

                data.Reader.Read();
                category.id = (int)data.Reader["Id"];
                category.description = (string)data.Reader["Descripcion"];

                return category;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void add(Category category)
        {
            try
            {
                data.setQuery("Insert into CATEGORIAS (Descripcion) values (@description)");
                data.setParam("@description", category.description);
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

        public void update(Category category)
        {
            try
            {
                data.setQuery("Update CATEGORIAS set Descripcion = @description where Id = @id");
                data.setParam("@description", category.description);
                data.setParam("@id", category.id);
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

        public void delete(Category category)
        {
            try
            {
                data.setQuery("Delete CATEGORIAS where Id = @id");
                data.setParam("@id", category.id);
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

    }
}
